using System;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using Utils;
using Devices.Exceptions;

namespace imd_fingerprint_readers.Devices.FingerprintReaders
{
    /// <summary>
    /// Basic abstract fingerprint reader device.
    /// </summary>
    public abstract class AbstractFingerprintReader : IFingerprintReader
    {
        #region Constants

        private const int AUTOCAPTURE_PRESENT_COUNT = 4;

        #endregion

        #region Fields

        private bool isDisposed = false;
        private bool forceCapture = false;
        private bool isCapturing = false;
        private Thread thread = null;
        private byte brightness = 128;
        private byte contrast = 128;
        private byte gain = 128;
        private byte captureScore = 50;
        private bool inverted = false;
        private FingerCaptureMode captureMode = FingerCaptureMode.Live;
        private Fingers captureFingers = Fingers.Unknown;

        #endregion

        #region Constructors

        /// <summary>
        /// Finalizes an instance of the <see cref="AbstractFingerprintReader"/> class, releases unmanaged resources and performs
        /// other cleanup operations before the is reclaimed by garbage collection.
        /// </summary>
        ~AbstractFingerprintReader()
        {
            Dispose(false);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when preview image is ready.
        /// </summary>
        public event Action<Fingerprint> PreviewImageReady;

        /// <summary>
        /// Occurs when the final image is ready.
        /// </summary>
        public event Action<Fingerprint> FinalImageReady;

        /// <summary>
        /// Occurs when an error is thrown.
        /// </summary>
        public event Action<string> ErrorOccurred;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the requested finger(s) is(are) present in the fingerprint reader.
        /// </summary>
        /// <value><c>true</c> if fingers are present; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public abstract bool AreFingersPresent { get; }

        /// <summary>
        /// Gets a value indicating whether the device is connected.
        /// </summary>
        /// <value><c>true</c> if the device is connected; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public abstract bool IsConnected { get; }

        /// <summary>
        /// Gets a value indicating whether the reader can capture multiple fingers
        /// </summary>
        /// <value><c>true</c> if the reader can capture multiple fingers; otherwise, <c>false</c>.</value>
        public virtual bool IsMultiFingerReader
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the image brightness.
        /// </summary>
        /// <value>The image brightness between 0 and 255.</value>
        [DefaultValue(50)]
        public virtual byte AutoCaptureScore
        {
            get { return captureScore; }
            set { captureScore = value; }
        }


        /// <summary>
        /// Gets or sets the image brightness.
        /// </summary>
        /// <value>The image brightness between 0 and 255.</value>
        [DefaultValue(128)]
        public virtual byte Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }

        /// <summary>
        /// Gets or sets the image contrast.
        /// </summary>
        /// <value>The image contrast between 0 and 255.</value>
        [DefaultValue(128)]
        public virtual byte Contrast
        {
            get { return contrast; }
            set { contrast = value; }
        }

        /// <summary>
        /// Gets or sets the image gain.
        /// </summary>
        /// <value>The image gain between 0 and 255.</value>
        [DefaultValue(128)]
        public virtual byte Gain
        {
            get { return gain; }
            set { gain = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image colors are inverted.
        /// </summary>
        /// <value><c>true</c> if the image colors are inverted; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public virtual bool Inverted
        {
            get { return inverted; }
            set { inverted = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the control has been disposed of.
        /// </summary>
        /// <value><c>true</c> if the device has been disposed of; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool IsDisposed
        {
            get { return isDisposed; }
        }

        /// <summary>
        /// Gets or sets the current fingerprint capture mode.
        /// </summary>
        protected virtual FingerCaptureMode CaptureMode
        {
            get { return captureMode; }
            set { captureMode = value; }
        }

        /// <summary>
        /// Gets or sets the current fingerprint capture mode.
        /// </summary>
        protected virtual Fingers CaptureFingers
        {
            get { return captureFingers; }
            set { captureFingers = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the capturing thread is running.
        /// </summary>
        /// <value><c>true</c> if the capturing thread is running; otherwise, <c>false</c>.</value>
        protected virtual bool IsCapturing
        {
            get { return isCapturing; }
        }

        /// <summary>
        /// Gets a value indicating whether to force capture.
        /// </summary>
        /// <value><c>true</c> to force capture; otherwise, <c>false</c>.</value>
        protected virtual bool IsCaptureForced
        {
            get { return forceCapture; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            isCapturing = false;
            PreviewImageReady = null;
            FinalImageReady = null;
        }

        /// <summary>
        /// Checks if device is connected and ready to use.
        /// </summary>
        /// <returns><c>true</c> if device is connected and ready; otherwise, <c>false</c>.</returns>
        public abstract bool Detect();

        /// <summary>
        /// Connects the device.
        /// </summary>
        /// <returns><c>true</c> if the connection was successful; otherwise, <c>false</c>.</returns>
        public abstract bool Connect();

        /// <summary>
        /// Disconnect the device.
        /// </summary>
        /// <returns><c>true</c> if disconnection was successful; otherwise, <c>false</c>.</returns>
        public abstract bool Disconnect();

        /// <summary>
        /// Gets the fingerprint image.
        /// </summary>
        /// <param name="quality">The image quality.</param>
        /// <returns>The fingerprint image.</returns>
        public abstract Fingerprint GetImage(ImageQuality quality);

        /// <summary>
        /// Starts the capture.
        /// </summary>
        /// <remarks>
        /// This implementation start a new thread where the method  <see cref="CaptureLiveFingerprint"/>
        /// or <see cref="CaptureAutoFingerprint"/> is safely call.
        /// Override this method if a more complex procedure is required.
        /// </remarks>
        /// <param name="mode">The capture mode.</param>
        /// <param name="fingers">The finger(s) to capture.</param>
        public virtual void Start(FingerCaptureMode mode, Fingers fingers)
        {
            uint count = BitwiseHelper.GetBitCount((uint)fingers);

            if (!IsMultiFingerReader && count > 1 || count > 4)
                throw new DeviceException("Number of finger exceeded");

            if (isCapturing)
                return;

            // Wait if a previous capturer thread is still alive.
            while (thread != null)
                Thread.Sleep(100);

            lock (this)
            {
                captureMode = mode;
                captureFingers = fingers;
                isCapturing = true;
                forceCapture = false;

                thread = new Thread(ThreadProc);
                thread.Name = "fingerprint capture thread";
                thread.IsBackground = true;
                thread.Start();
            }
        }

        /// <summary>
        /// Stops the capture.
        /// </summary>
        public virtual void Stop()
        {
            lock (this)
            {
                isCapturing = false;
            }
        }

        /// <summary>
        /// Forces the capture.
        /// </summary>
        public virtual void ForceCapture()
        {
            if (!IsCapturing)
                return;

            lock (this)
            {
                forceCapture = true;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            // Released unmanaged Resources
            isDisposed = true;
            isCapturing = false;
            PreviewImageReady = null;
            FinalImageReady = null;

            if (disposing)
            {
                // Released managed Resources
            }
        }

        /// <summary>
        /// Raise PreviewImageReady event safely.
        /// </summary>
        /// <param name="image">The image.</param>
        protected virtual void OnPreviewImageReady(Fingerprint image)
        {
            if (PreviewImageReady == null || !IsCapturing)
            {
                if (image != null)
                    image.Dispose();

                return;
            }

            if (image == null)
            {
                OnErrorOccurred("");
                Stop();
                return;
            }

            try
            {
                ReflectionHelper.RaiseEventSafely<Action<Fingerprint>>(PreviewImageReady, image);
            }
            catch (Exception exception)
            {
                string message = "Error.FireEvent";
                throw new DeviceException(message, exception);
            }
        }

        /// <summary>
        /// Fire FinalImageReady event safely.
        /// </summary>
        /// <param name="image">The image.</param>
        protected virtual void OnFinalImageReady(Fingerprint image)
        {
            if (FinalImageReady == null || !IsCapturing)
            {
                if (image != null)
                    image.Dispose();

                return;
            }

            try
            {
                ReflectionHelper.RaiseEventSafely<Action<Fingerprint>>(FinalImageReady, image);
            }
            catch (Exception exception)
            {
                string message = "Error.FireEvent";
                throw new DeviceException(message, exception);
            }
        }

        /// <summary>
        /// Called when [error occurred].
        /// </summary>
        /// <param name="message">The message.</param>
        protected virtual void OnErrorOccurred(string message)
        {
            if (ErrorOccurred == null)
                return;

            ReflectionHelper.RaiseEventSafely<Action<string>>(ErrorOccurred, message);
        }

        /// <summary>
        /// Auto-capture flat fingerprint. This mean that when the expected fingers are detected the image final image is captured and the capture process ends.
        /// </summary>
        /// <remarks>
        /// This implementation emulates the desired behavior using the <see cref="AreFingersPresent"/>
        /// property and <see cref="GetImage"/> method. If the fingerprint reader provides a better
        /// mechanism for this capture mode then override this method.
        /// </remarks>
        protected virtual void CaptureAutoFingerprint()
        {
            int count = 0;

            while (IsCapturing)
            {
                bool forced = IsCaptureForced;

                Fingerprint image = GetImage(ImageQuality.High);

                // Try to detect is finger is present and wait a certain number of frames
                // with the finger present before auto-capture the image.
                if (image.Score > captureScore)
                    count++;
                else
                    count = 0;

                bool isFinalImage = count >= AUTOCAPTURE_PRESENT_COUNT || forced;


                if (!isFinalImage)
                {
                    OnPreviewImageReady(image == null ? null : image.Clone());
                }
                else
                {
                    OnFinalImageReady(image.Clone());
                    isCapturing = false;
                }

                if (image != null)
                    image.Dispose();
            }
        }

        /// <summary>
        /// Live mode fingerprint capture. This mean that no auto capture is done. The capture process ends when force image or stop methods is called.
        /// </summary>
        /// <remarks>
        /// This implementation emulates the desired behavior using the <see cref="AreFingersPresent"/>
        /// property and <see cref="GetImage"/> method. If the fingerprint reader provides some
        /// mechanism for this capture mode then override this method.
        /// </remarks>
        protected virtual void CaptureLiveFingerprint()
        {
            while (IsCapturing)
            {
                bool forced = IsCaptureForced;
                Fingerprint image = GetImage(forced ? ImageQuality.High : ImageQuality.Low);

                if (!forced)
                {
                    OnPreviewImageReady(image == null ? null : image.Clone());
                }
                else
                {
                    OnFinalImageReady(image.Clone());
                    isCapturing = false;
                }

                if (image != null)
                    image.Dispose();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Implement the fingerprint image capture thread procedure.
        /// </summary>
        private void ThreadProc()
        {
            try
            {
                switch (captureMode)
                {
                    case FingerCaptureMode.AutoCapture:
                        CaptureAutoFingerprint();
                        break;
                    case FingerCaptureMode.Live:
                        CaptureLiveFingerprint();
                        break;
                }
            }
            catch (Exception ex)
            {
                OnErrorOccurred(ex.Message);
            }

            Stop();

            lock (this)
            {
                thread = null;
            }
        }

        #endregion
    }
}
