using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Imaging;
using imd_fingerprint_readers.Devices.FingerprintReaders;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using Devices;
using Devices.Exceptions;
using IMD;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace FingerprintReaders
{
    /// <summary>
    /// IMD Fap30 series fingerprint reader.
    /// </summary>
    public class Fap30Reader : AbstractFingerprintReader
    {
        #region Private Fields

        private bool isConnected = false;
        private bool improveImage = false;
        private Fap30Controller controller = Fap30Controller.Instance;
        private Bitmap dummyBitmap;
        private Bitmap lastValidFrame;
        private byte[] lastValidRaw;
        private int lastValidScore = 0;
        private int errorCount = 0;

        Stopwatch cooldown = new Stopwatch();

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the device is connected.
        /// </summary>
        /// <value><c>true</c> if the device is connected; otherwise, <c>false</c>.</value>
        public override bool IsConnected
        {
            get { return isConnected; }
        }

        /// <summary>
        /// Gets a value indicating whether the requested finger(s) is(are) present in the fingerprint reader.
        /// </summary>
        /// <value><c>true</c> if fingers are present; otherwise, <c>false</c>.</value>
        public override bool AreFingersPresent
        {
            get
            {
                if (!IsConnected)
                    return false;

                return this.lastValidScore > 0;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image colors are inverted.
        /// </summary>
        /// <value><c>true</c> if image colors are inverted; otherwise, <c>false</c>.</value>
        public override bool Inverted
        {
            get
            {
                return base.Inverted;
            }

            set
            {
                base.Inverted = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to improve the image.
        /// </summary>
        /// <value><c>true</c> if the improve image method is active; otherwise, <c>false</c>.</value>
        public bool ImproveImage
        {
            get
            {
                return improveImage;
            }

            set
            {
                improveImage = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            return "IMD Fap30";
        }

        /// <summary>
        /// Checks if device is connected and ready to use.
        /// </summary>
        /// <returns>
        /// <c>true</c> if device is connected and ready; otherwise, <c>false</c>.
        /// </returns>
        public override bool Detect()
        {
            DeviceInfo[] info = DeviceDiscover.GetDevices(
                "VID_2b41&PID_0301");

            return info.Length > 0;
        }

        /// <summary>
        /// Gets the number of fingerprint connected.
        /// </summary>
        /// <returns>
        /// The number of fingerprints connected.
        /// </returns>
        public static int DeviceCount()
        {
            DeviceInfo[] info = DeviceDiscover.GetDevices(
                "VID_2b41&PID_0301");

            return info.Length;
        }

        /// <summary>
        /// Connects the device.
        /// </summary>
        /// <returns><c>true</c> if the connection was successful; otherwise, <c>false</c>.</returns>
        public override bool Connect()
        {
            if (IsConnected)
                return true;

            controller.SafeCloseDevice();

            if (controller.SafeOpenDevice() == 1 && controller.SafeLinkDevice(0) == 1)
            {
                string hash;
                Nfiq2.InitNfiq2(out hash);

                this.isConnected = true;
            }
            else
            {
                controller.SafeCloseDevice();
                this.isConnected = false;
            }

            // Crete dummy frame
            int width = 100; // Width of the image
            int height = 100; // Height of the image
            dummyBitmap = new Bitmap(width, height);
            lastValidFrame = (Bitmap)dummyBitmap.Clone();

            using (Graphics gfx = Graphics.FromImage(dummyBitmap))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }

            return IsConnected;
        }

        /// <summary>
        /// Gets the Futronic device serial number.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if completes successfully; otherwise, <c>false</c>. To get extended error information, call <c>GetLastError</c>.
        /// </returns>
        public string GetSerialNumber()
        {
            int serial = controller.SafeGetDeviceSnNum();
            return serial.ToString();
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            byte version = controller.SafeGetDeviceVersion();
            return version.ToString();
        }

        /// <summary>
        /// Disconnect the device.
        /// </summary>
        /// <returns><c>true</c> if disconnection was successful; otherwise, <c>false</c>.</returns>
        public override bool Disconnect()
        {
            if (!IsConnected)
                return true;

            Stop();
            controller.SafeResetDevice();
            controller.SafeCloseDevice();
            this.isConnected = false;

            return true;
        }

        /// <summary>
        /// Gets the fingerprint image.
        /// </summary>
        /// <param name="quality">The image quality.</param>
        /// <returns>The fingerprint image.</returns>
        public override Fingerprint GetImage(ImageQuality quality)
        {
            if (!IsConnected)
                return null;

            Bitmap result = null;

            switch (quality)
            {
                case ImageQuality.Low:
                case ImageQuality.Default:
                case ImageQuality.High:
                    controller.SafeCaptureImage();
                    break;
                default:
                    throw new DeviceException("Unsupported image quality");
            }

           Thread.Sleep(50);

            int w = 0;
            int h = 0;

            int message = 0;
            cooldown.Restart();
            while (message != Fap30Controller.FPM_CAPTURE && cooldown.ElapsedMilliseconds <= 300)
            {
                message = controller.SafeGetWorkMsg();
                Thread.Sleep(10);
            }

            if (message == -1)
            {
                ++errorCount;
                Fingerprint f = new Fingerprint();
                f.Bitmap = (Bitmap)lastValidFrame.Clone();
                f.Score = lastValidScore;
                f.Width = lastValidFrame.Width;
                f.Height = lastValidFrame.Height;
                f.RawBytes = lastValidRaw;

                if (errorCount > 2)
                {
                    lastValidFrame = (Bitmap)dummyBitmap.Clone();
                    lastValidScore = 0;
                }
                return f;
            }

            if (cooldown.ElapsedMilliseconds > 500)
            {
                Fingerprint f = new Fingerprint();
                f.Bitmap = (Bitmap)dummyBitmap.Clone();
                f.Width = dummyBitmap.Width;
                f.Height = dummyBitmap.Height;
                f.Score = 0;
                lastValidScore = 0;

                return f;
            }

            controller.SafeGetImageSize(ref w, ref h);

            byte[] buffer = new byte[w * h];
            int imgSize = 0;

            int captureResult = controller.SafeGetRawImage(buffer, ref imgSize);

            controller.SafeResetDevice();

            result = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
            ColorPalette palette = result.Palette;

            for (int i = 0; i < 256; ++i)
                palette.Entries[i] = Color.FromArgb(i, i, i);

            result.Palette = palette;

            BitmapData bmpData = result.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            Marshal.Copy(buffer, 0, bmpData.Scan0, w * h);
            result.UnlockBits(bmpData);

            if (result != null)
            {
                result.SetResolution(500, 500);
            }

            IntPtr ptr = Nfiq2.ConvertToIntPtr(buffer);
            int score = Nfiq2.ComputeNfiq2Score(1, ptr, buffer.Length, w, h, 500);
            Nfiq2.FreeIntPtr(ptr);

            Fingerprint fingerprint = new Fingerprint();
            fingerprint.Bitmap = result;
            fingerprint.RawBytes = buffer;
            fingerprint.Width = w;
            fingerprint.Height = h;
            fingerprint.Score = score > 100 ? 0 : score;

            Bitmap old = lastValidFrame;

            if (improveImage)
            {
                if (result != null)
                {
                    ImageFiltering.ApplyImageSettings(result, this.Brightness, this.Contrast, this.Gain);
                    buffer = ConvertBitmapToRaw(result);
                }
            }

            lastValidFrame = (Bitmap)result.Clone();
            lastValidScore = score;
            lastValidRaw = (byte[])buffer.Clone();
            errorCount = 0;
            old.Dispose();

            return fingerprint;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Disconnect();
        }

        /// <summary>
        /// Convert a bitmap to its raw data.
        /// </summary>
        /// <param name="bitmap">The bitmap</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public byte[] ConvertBitmapToRaw(Bitmap bitmap)
        {
            // Ensure the bitmap is in the expected format to simplify the process.
            if (bitmap.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException("Bitmap must be in 8bppIndexed format for direct byte array conversion.");

            // Lock the bitmap's bits. 
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);

            // Declare an array to hold the bytes of the bitmap.
            // This code assumes an 8bppIndexed image, meaning each pixel is represented by a single byte.
            int bytes = bmpData.Stride * bitmap.Height;
            byte[] rawValues = new byte[bytes];

            // Copy the RGB values into the array.
            Marshal.Copy(bmpData.Scan0, rawValues, 0, bytes);

            // Unlock the bits.
            bitmap.UnlockBits(bmpData);

            return rawValues;
        }

        #endregion
    }
}
