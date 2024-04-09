using System;
using System.Drawing;
using System.Runtime.InteropServices;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;

namespace imd_fingerprint_readers.Devices.FingerprintReaders
{
    /// <summary>
    /// Fingerprint reader device interface.
    /// </summary>
    public interface IFingerprintReader
    {
        #region Events

        /// <summary>
        /// Occurs when [preview image is ready].
        /// </summary>
        event Action<Fingerprint> PreviewImageReady;

        /// <summary>
        /// Occurs when [final image is ready].
        /// </summary>
        event Action<Fingerprint> FinalImageReady;

        /// <summary>
        /// Occurs when an error is thrown.
        /// </summary>
        event Action<string> ErrorOccurred;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the requested finger(s) is(are) present in the fingerprint reader.
        /// </summary>
        /// <value><c>true</c> if fingers are present; otherwise, <c>false</c>.</value>
        bool AreFingersPresent { get; }

        /// <summary>
        /// Gets a value indicating whether the reader can capture multiple fingers
        /// </summary>
        /// <value><c>true</c> if the reader can capture multiple fingers; otherwise, <c>false</c>.</value>
        bool IsMultiFingerReader { get; }

        /// <summary>
        /// Gets or sets the image brightness.
        /// </summary>
        /// <value>The image brightness between 0 and 255.</value>
        byte Brightness { get; set; }

        /// <summary>
        /// Gets or sets the image contrast.
        /// </summary>
        /// <value>The image contrast between 0 and 255.</value>
        byte Contrast { get; set; }

        /// <summary>
        /// Gets or sets the image gain.
        /// </summary>
        /// <value>The image gain between 0 and 255.</value>
        byte Gain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the image colors are inverted.
        /// </summary>
        /// <value><c>true</c> if the image colors are inverted; otherwise, <c>false</c>.</value>
        bool Inverted { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the capture.
        /// </summary>
        /// <param name="mode">The capture mode.</param>
        /// <param name="fingers">The finger(s) to capture.</param>
        void Start(FingerCaptureMode mode, Fingers fingers);

        /// <summary>
        /// Stops the capture.
        /// </summary>
        void Stop();

        /// <summary>
        /// Forces the capture.
        /// </summary>
        void ForceCapture();

        /// <summary>
        /// Gets the fingerprint image.
        /// </summary>
        /// <param name="quality">The image quality.</param>
        /// <returns>The fingerprint image.</returns>
        Fingerprint GetImage(ImageQuality quality);

        #endregion
    }
}
