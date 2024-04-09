using IMD;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System;
using System.Security.Policy;
using Imaging;
using System.Diagnostics.Contracts;
using FingerprintReaders;
using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using imd_fingerprint_readers.Devices.FingerprintReaders;
using System.Windows.Forms;


namespace imd_fingerprint_readers
{
    public partial class MainForm : Form
    {
        Fap30Reader reader = new Fap30Reader();
        Matcher matcher = new Matcher();
        LocalRepository repository;
        Brush control = new SolidBrush(Color.FromArgb(255, 240, 240, 240));
        bool isConnected = false;

        public MainForm()
        {
            InitializeComponent();
            repository = new LocalRepository("db", new Matcher());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            repository.Initialize();
            reader.ImproveImage = true;
            cbDevices.Items.Add("IMD Fap30");
            cbDevices.SelectedIndex = 0;
            toolStripStatusLabel.Text = "Disconnected";
            toolStripStatusLabel.ForeColor = Color.DarkRed;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.capturePanel.InitializeDevices(reader, matcher);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reader.IsConnected)
            {
                reader.PreviewImageReady -= new Action<Fingerprint>(OnImageReady);
                reader.FinalImageReady -= new Action<Fingerprint>(OnFinalImage);
                reader.Stop();
                reader.Disconnect();
            }
            else
            {
                if (reader.Detect())
                {
                    if (reader.Connect())
                    {
                        reader.PreviewImageReady += new Action<Fingerprint>(OnImageReady);
                        reader.FinalImageReady += new Action<Fingerprint>(OnFinalImage);
                        reader.Start(FingerCaptureMode.AutoCapture, Fingers.Unknown);
                    }
                }
            }

        }

        /// <summary>
        /// Called when the fingerprint reader image is ready.
        /// </summary>
        /// <param name="image">The image.</param>
        void OnImageReady(Fingerprint fingerprint)
        {/*
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { OnImageReady(fingerprint); }));
                return;
            }

            Bitmap img = (Bitmap)fingerprint.Bitmap;
            Image oldImage = this.pictureBox1.Image;

            this.pictureBox1.Image = img;
            this.textBox1.Text = fingerprint.Score.ToString();

            if (oldImage != null)
            {
                oldImage.Dispose();
            }*/
        }

        /// <summary>
        /// Called when the fingerprint reader image is ready.
        /// </summary>
        /// <param name="image">The image.</param>
        void OnFinalImage(Fingerprint fingerprint)
        {
            /* if (this.InvokeRequired)
             {
                 this.Invoke(new MethodInvoker(delegate () { OnFinalImage(fingerprint); }));
                 return;
             }

             fingerprint.Template = matcher.GenerateTemplate(fingerprint);
             Person person = this.repository.FindByFingerprint(fingerprint, 50);

             if (person != null)
             {
                 MessageBox.Show("Found record. ID " + person.Id + " Name " + person.Name);
             }
             else
             {
                 MessageBox.Show("Not Found");
             }

             reader.PreviewImageReady -= new Action<Fingerprint>(OnImageReady);
             reader.FinalImageReady -= new Action<Fingerprint>(OnFinalImage);
             reader.Stop();
             reader.Disconnect();
             /*
             if (left == null)
             {
                 left = fingerprint.Clone();
                 left.Template = matcher.GenerateTemplate(left);
                 Person person = new Person();
                 person.Name = "Left";
                 person.Id = "1234";
                 person.Fingerprint = left;
                 repository.AddRecord(person);
             }
             else
             {
                 right = fingerprint.Clone();
                 right.Template = matcher.GenerateTemplate(right);

                 Person person = new Person();
                 person.Name = "Right";
                 person.Id = "5678";
                 person.Fingerprint = right;
                 repository.AddRecord(person);
             }

             OnImageReady(fingerprint);

             if (left != null && right != null)
             {
                 int score = matcher.Match(left, right);
                 if (score > 80)
                 {
                     this.textBox1.Text = "Match with " + score.ToString();
                 }
                 else
                 {
                     this.textBox1.Text = "No match with " + score.ToString();
                 }

                 left = null;
                 right = null;
             }

             reader.PreviewImageReady -= new Action<Fingerprint>(OnImageReady);
             reader.FinalImageReady -= new Action<Fingerprint>(OnFinalImage);
             reader.Stop();
             reader.Disconnect();*/
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!this.isConnected)
            {
                if (!reader.Detect())
                {
                    MessageBox.Show("Fingerprint reader " + this.cbDevices.Text + " not detected.", "Device Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!reader.Connect())
                {
                    MessageBox.Show("Fingerprint reader " + this.cbDevices.Text + " could not be connected.", "Device Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.isConnected = true;
                this.btnDisconnect.Enabled = true;
                this.btnConnect.Enabled = false;
                this.tabControl.Enabled = true;
                this.txtBoxDbPath.Enabled = false;
                this.cbDevices.Enabled = false;
                toolStripStatusLabel.Text = "Connected";
                toolStripStatusLabel.ForeColor = Color.ForestGreen;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (this.isConnected)
            {
                reader.Disconnect();
                this.btnDisconnect.Enabled = false;
                this.btnConnect.Enabled = true;
                this.tabControl.Enabled = false;
                this.txtBoxDbPath.Enabled = true;
                this.cbDevices.Enabled = true;
                this.isConnected = false;
                toolStripStatusLabel.Text = "Disconnected";
                toolStripStatusLabel.ForeColor = Color.DarkRed;
            }
        }
    }
}
