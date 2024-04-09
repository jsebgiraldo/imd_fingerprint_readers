using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using imd_fingerprint_readers;
using System.Text.Json;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace imd_fingerprint_readers.Devices.FingerprintReaders.Definitions
{
    /// <summary>
    /// Fingerprint class.
    /// </summary>
    [Serializable]
    public class Fingerprint : IDisposable
    {
        [JsonIgnore]
        public Bitmap Bitmap { get; set; }
        public int Score { get; set; }
        public byte[] RawBytes { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public byte[] Template { get; set; }

        public Fingers Finger { get; set; }

        /// <summary>
        /// Creates a clone of the fingerprint class.
        /// </summary>
        /// <returns>The clone Fingerprint instance.</returns>
        public Fingerprint Clone()
        {
            Fingerprint fingerprint = new Fingerprint();
            fingerprint.Bitmap = (Bitmap)Bitmap.Clone();
            fingerprint.Score = Score;

            if (RawBytes != null)
                fingerprint.RawBytes = (byte[])RawBytes.Clone();

            if (Template != null)
                fingerprint.Template = (byte[])Template.Clone();

            fingerprint.Width = Width;
            fingerprint.Height = Height;

            return fingerprint;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
                if (Bitmap != null)
                {
                    Bitmap.Dispose();
                    Bitmap = null;
                }
            }
        }


        /// <summary>
        /// Serialize this object to a JSON string
        /// </summary>
        /// <returns>The serialized string.</returns>
        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Deserializes this object from a JSON string
        /// </summary>
        /// <returns>The Fingerprint object.</returns>
        public static Fingerprint Deserialize(string jsonString)
        {
            Fingerprint fingerprint =  JsonSerializer.Deserialize<Fingerprint>(jsonString);

            fingerprint.Bitmap = FromRaw(fingerprint.Width, fingerprint.Height, fingerprint.RawBytes);

            return fingerprint;
        }

        /// <summary>
        /// Creates a Bitmap from fingerprint raw data.
        /// </summary>
        /// <param name="w">The width of the image.</param>
        /// <param name="h">The height of the image.</param>
        /// <param name="rawData">The raw data.</param>
        /// <returns></returns>
        private static Bitmap FromRaw(int w, int h, byte[] rawData)
        {
            Bitmap result = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
            ColorPalette palette = result.Palette;

            for (int i = 0; i < 256; ++i)
                palette.Entries[i] = Color.FromArgb(i, i, i);

            result.Palette = palette;

            BitmapData bmpData = result.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            Marshal.Copy(rawData, 0, bmpData.Scan0, w * h);
            result.UnlockBits(bmpData);

            return result;
        }
    }
}
