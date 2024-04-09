using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using imd_fingerprint_readers.Devices.FingerprintReaders;
using FingerprintReaders;

namespace imd_fingerprint_readers.Controls
{
    public partial class CaptureControl : UserControl
    {
        Fap30Reader reader;
        Matcher matcher;

        public CaptureControl()
        {
            InitializeComponent();
        }

        public void InitializeDevices(Fap30Reader reader, Matcher matcher)
        {
            this.reader = reader;
            this.matcher = matcher;
        }

        private void CaptureControl_Load(object sender, EventArgs e)
        {
            this.cbCaptureMode.Items.Add("Live");
            this.cbCaptureMode.Items.Add("Auto Capture");
            this.cbCaptureMode.SelectedIndex = 0;
        }

        private void btbResetCalib_Click(object sender, EventArgs e)
        {
            this.numBrightness.Value = 128;
            this.numContrast.Value = 128;
            this.numGain.Value = 128;

            this.reader.Brightness = 128;
            this.reader.Contrast = 128;
            this.reader.Gain = 128;
        }

        private void numBrightness_ValueChanged(object sender, EventArgs e)
        {
            this.reader.Brightness = ((byte)this.numBrightness.Value);
        }

        private void numContrast_ValueChanged(object sender, EventArgs e)
        {
            this.reader.Contrast = ((byte)this.numContrast.Value);
        }

        private void numGain_ValueChanged(object sender, EventArgs e)
        {
            this.reader.Gain = ((byte)this.numGain.Value);
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            this.reader.AutoCaptureScore = (byte)this.captureScore.Value;
            this.reader.PreviewImageReady += new Action<Fingerprint>(Reader_PreviewImageReady);
            this.reader.FinalImageReady += new Action<Fingerprint>(Reader_FinalImageReady);
            this.reader.Start(this.cbCaptureMode.SelectedIndex == 0 ? FingerCaptureMode.Live : FingerCaptureMode.AutoCapture, Fingers.Unknown);
        }

        private void Reader_FinalImageReady(Fingerprint fingerprint)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { Reader_FinalImageReady(fingerprint); }));
                return;
            }

            Bitmap img = (Bitmap)fingerprint.Bitmap;
            Image oldImage = this.pbFinal.Image;

            this.pbFinal.Image = img;
            this.lblScore.Text = fingerprint.Score.ToString();

            if (oldImage != null)
            {
                oldImage.Dispose();
            }

            reader.PreviewImageReady -= new Action<Fingerprint>(Reader_PreviewImageReady);
            reader.FinalImageReady -= new Action<Fingerprint>(Reader_FinalImageReady);
            reader.Stop();
        }

        private void Reader_PreviewImageReady(Fingerprint fingerprint)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { Reader_PreviewImageReady(fingerprint); }));
                return;
            }

            Bitmap img = (Bitmap)fingerprint.Bitmap;
            Image oldImage = this.pbPreview.Image;

            this.pbPreview.Image = img;
            this.lblPreviwScore.Text = fingerprint.Score.ToString();

            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reader.ForceCapture();
        }
    }
}
