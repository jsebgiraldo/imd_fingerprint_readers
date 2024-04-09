using IMD;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace imd_fingerprint_readers
{
    /// <summary>
    /// Matcher class. This class can create templates and match scores.
    /// </summary>
    public class Matcher
    {
        private Fap30Controller controller = Fap30Controller.Instance;

        /// <summary>
        /// Generates a template.
        /// </summary>
        /// <param name="fingerprint">The fingerprint</param>
        /// <returns>The template.</returns>
        public byte[] GenerateTemplate(Fingerprint fingerprint)
        {
            int size = controller.SafeGetTemplateSize();
            byte[] templateBytes = new byte[size];
            int templateSize = 0;

            int w = fingerprint.Bitmap.Width;
            int h = fingerprint.Bitmap.Height;

            controller.SafeCreateTemplate(fingerprint.RawBytes, w, h, templateBytes, ref templateSize);

            return templateBytes;
        }

        /// <summary>
        /// Match two given fingerprints and returns the matching score.
        /// </summary>
        /// <param name="lhs">The first fingerprint to be compared.</param>
        /// <param name="rhs">The second fingerprint to be compared.</param>
        /// <returns>The match score.</returns>
        public int Match(Fingerprint lhs, Fingerprint rhs)
        {
            if (rhs.Template == null || lhs.Template == null) return 0;

            return controller.SafeMatchTemplate(lhs.Template, rhs.Template);
        }
    }
}
