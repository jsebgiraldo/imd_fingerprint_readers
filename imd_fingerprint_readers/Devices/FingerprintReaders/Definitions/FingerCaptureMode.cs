using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace imd_fingerprint_readers.Devices.FingerprintReaders.Definitions
{
    /// <summary>
    /// Fingerprint capture mode enumeration.
    /// </summary>
    public enum FingerCaptureMode
    {
        /// <summary>
        /// Live mode. No auto-capture is done.
        /// </summary>
        Live,

        /// <summary>
        /// Auto-capture flat mode. The first valid fingerprint image detected is automatic captured.
        /// </summary>
        AutoCapture
    }
}
