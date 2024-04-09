using imd_fingerprint_readers.Controls;

namespace imd_fingerprint_readers
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            textBox1 = new TextBox();
            brightness = new TrackBar();
            contrast = new TrackBar();
            gain = new TrackBar();
            gbDevice = new GroupBox();
            btnDisconnect = new Button();
            txtBoxDbPath = new TextBox();
            lblDbPath = new Label();
            btnConnect = new Button();
            cbDevices = new ComboBox();
            lblDevice = new Label();
            pnShadow = new Panel();
            pnHeader = new Panel();
            lblTitle = new Label();
            pbLogo = new PictureBox();
            tabControl = new CustomTabControl();
            tabPage1 = new TabPage();
            capturePanel = new CaptureControl();
            tabPage2 = new TabPage();
            captureControl1 = new EnrollControl();
            tabPage3 = new TabPage();
            authenticationControl = new AuthenticationControl();
            tabPage4 = new TabPage();
            verificationControl = new VerificationControl();
            statusStrip1 = new StatusStrip();
            statusStrip = new ToolStripStatusLabel();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)brightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain).BeginInit();
            gbDevice.SuspendLayout();
            pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(543, 601);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 2;
            // 
            // brightness
            // 
            brightness.LargeChange = 1;
            brightness.Location = new Point(448, 319);
            brightness.Maximum = 255;
            brightness.Name = "brightness";
            brightness.Size = new Size(261, 69);
            brightness.TabIndex = 3;
            // 
            // contrast
            // 
            contrast.LargeChange = 1;
            contrast.Location = new Point(448, 394);
            contrast.Maximum = 255;
            contrast.Name = "contrast";
            contrast.Size = new Size(261, 69);
            contrast.TabIndex = 4;
            // 
            // gain
            // 
            gain.LargeChange = 1;
            gain.Location = new Point(448, 469);
            gain.Maximum = 255;
            gain.Name = "gain";
            gain.Size = new Size(261, 69);
            gain.TabIndex = 5;
            // 
            // gbDevice
            // 
            gbDevice.BackColor = Color.White;
            gbDevice.Controls.Add(btnDisconnect);
            gbDevice.Controls.Add(txtBoxDbPath);
            gbDevice.Controls.Add(lblDbPath);
            gbDevice.Controls.Add(btnConnect);
            gbDevice.Controls.Add(cbDevices);
            gbDevice.Controls.Add(lblDevice);
            gbDevice.Location = new Point(12, 61);
            gbDevice.Name = "gbDevice";
            gbDevice.Size = new Size(864, 136);
            gbDevice.TabIndex = 6;
            gbDevice.TabStop = false;
            gbDevice.Text = "Connection";
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(696, 48);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(136, 34);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // txtBoxDbPath
            // 
            txtBoxDbPath.BackColor = Color.White;
            txtBoxDbPath.Location = new Point(153, 76);
            txtBoxDbPath.Name = "txtBoxDbPath";
            txtBoxDbPath.Size = new Size(340, 31);
            txtBoxDbPath.TabIndex = 4;
            txtBoxDbPath.Text = "./database";
            // 
            // lblDbPath
            // 
            lblDbPath.AutoSize = true;
            lblDbPath.Location = new Point(13, 79);
            lblDbPath.Name = "lblDbPath";
            lblDbPath.Size = new Size(129, 25);
            lblDbPath.TabIndex = 3;
            lblDbPath.Text = "Database Path:";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(528, 49);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 34);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cbDevices
            // 
            cbDevices.FormattingEnabled = true;
            cbDevices.Location = new Point(153, 31);
            cbDevices.Name = "cbDevices";
            cbDevices.Size = new Size(340, 33);
            cbDevices.TabIndex = 1;
            // 
            // lblDevice
            // 
            lblDevice.AutoSize = true;
            lblDevice.Location = new Point(13, 35);
            lblDevice.Name = "lblDevice";
            lblDevice.Size = new Size(68, 25);
            lblDevice.TabIndex = 0;
            lblDevice.Text = "Device:";
            // 
            // pnShadow
            // 
            pnShadow.BackColor = Color.Navy;
            pnShadow.Location = new Point(-1, 2);
            pnShadow.Name = "pnShadow";
            pnShadow.Size = new Size(893, 53);
            pnShadow.TabIndex = 8;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.FromArgb(51, 52, 144);
            pnHeader.Controls.Add(lblTitle);
            pnHeader.Controls.Add(pbLogo);
            pnHeader.Location = new Point(-3, -1);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(912, 53);
            pnHeader.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Lucida Sans Unicode", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(237, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 23);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Fingerprint Reader Demostration Toolkit";
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = Properties.Resources.logo;
            pbLogo.InitialImage = Properties.Resources.logo;
            pbLogo.Location = new Point(1, 4);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(144, 47);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Left;
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage4);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Enabled = false;
            tabControl.ItemSize = new Size(100, 144);
            tabControl.Location = new Point(12, 203);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(864, 700);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(capturePanel);
            tabPage1.Location = new Point(148, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(712, 692);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Capture";
            // 
            // capturePanel
            // 
            capturePanel.BackColor = Color.White;
            capturePanel.Location = new Point(7, 3);
            capturePanel.Name = "capturePanel";
            capturePanel.Size = new Size(704, 661);
            capturePanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(captureControl1);
            tabPage2.Location = new Point(148, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(712, 692);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Enroll";
            // 
            // captureControl1
            // 
            captureControl1.BackColor = Color.White;
            captureControl1.Location = new Point(7, 3);
            captureControl1.Name = "captureControl1";
            captureControl1.Size = new Size(704, 691);
            captureControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(authenticationControl);
            tabPage3.Location = new Point(148, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(712, 692);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Authentication";
            // 
            // authenticationControl
            // 
            authenticationControl.BackColor = Color.White;
            authenticationControl.Location = new Point(7, 3);
            authenticationControl.Name = "authenticationControl";
            authenticationControl.Size = new Size(704, 691);
            authenticationControl.TabIndex = 2;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.White;
            tabPage4.Controls.Add(verificationControl);
            tabPage4.Location = new Point(148, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(712, 692);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Vertification";
            // 
            // verificationControl
            // 
            verificationControl.BackColor = Color.White;
            verificationControl.Location = new Point(7, 3);
            verificationControl.Name = "verificationControl";
            verificationControl.Size = new Size(704, 691);
            verificationControl.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusStrip, toolStripStatusLabel, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 902);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(888, 32);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Transparent;
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(64, 25);
            statusStrip.Text = "Status:";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.BackColor = Color.Transparent;
            toolStripStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripStatusLabel.ForeColor = Color.ForestGreen;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(103, 25);
            toolStripStatusLabel.Text = "Connected";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Transparent;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripStatusLabel1.ForeColor = SystemColors.ControlDark;
            toolStripStatusLabel1.Margin = new Padding(580, 4, 0, 3);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Padding = new Padding(10, 0, 0, 0);
            toolStripStatusLabel1.RightToLeft = RightToLeft.No;
            toolStripStatusLabel1.Size = new Size(79, 25);
            toolStripStatusLabel1.Text = "V 1.0.0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(888, 934);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl);
            Controls.Add(pnHeader);
            Controls.Add(pnShadow);
            Controls.Add(gbDevice);
            Controls.Add(gain);
            Controls.Add(contrast);
            Controls.Add(brightness);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Imunik-Scot / iMD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)brightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)contrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain).EndInit();
            gbDevice.ResumeLayout(false);
            gbDevice.PerformLayout();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TrackBar brightness;
        private TrackBar contrast;
        private TrackBar gain;
        private GroupBox gbDevice;
        private Panel pnShadow;
        private Panel pnHeader;
        private PictureBox pbLogo;
        private Label lblTitle;
        private ComboBox cbDevices;
        private Label lblDevice;
        private Button btnConnect;
        private Label lblDbPath;
        private TextBox txtBoxDbPath;
        private Button btnDisconnect;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage1;
        private CustomTabControl tabControl;
        private CaptureControl capturePanel;
        private EnrollControl captureControl1;
        private AuthenticationControl authenticationControl;
        private VerificationControl verificationControl;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
