namespace imd_fingerprint_readers.Controls
{
    partial class CaptureControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox3 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            captureScore = new NumericUpDown();
            cbCaptureMode = new ComboBox();
            label4 = new Label();
            btnStartCapture = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            btbResetCalib = new Button();
            numGain = new NumericUpDown();
            numContrast = new NumericUpDown();
            numBrightness = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblScore = new Label();
            label8 = new Label();
            button1 = new Button();
            pbFinal = new PictureBox();
            Preview = new GroupBox();
            lblPreviwScore = new Label();
            pbPreview = new PictureBox();
            label10 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)captureScore).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBrightness).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFinal).BeginInit();
            Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(captureScore);
            groupBox3.Controls.Add(cbCaptureMode);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(btnStartCapture);
            groupBox3.Controls.Add(button3);
            groupBox3.Location = new Point(3, 504);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(693, 138);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "Capture Options";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 90);
            label7.Name = "label7";
            label7.Size = new Size(171, 25);
            label7.TabIndex = 32;
            label7.Text = "Auto Capture Score:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 47);
            label6.Name = "label6";
            label6.Size = new Size(130, 25);
            label6.TabIndex = 24;
            label6.Text = "Capture Mode:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-196, 83);
            label5.Name = "label5";
            label5.Size = new Size(171, 25);
            label5.TabIndex = 31;
            label5.Text = "Auto Capture Score:";
            // 
            // captureScore
            // 
            captureScore.Location = new Point(194, 88);
            captureScore.Name = "captureScore";
            captureScore.Size = new Size(139, 31);
            captureScore.TabIndex = 30;
            captureScore.TextAlign = HorizontalAlignment.Center;
            captureScore.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // cbCaptureMode
            // 
            cbCaptureMode.FormattingEnabled = true;
            cbCaptureMode.Location = new Point(194, 44);
            cbCaptureMode.Name = "cbCaptureMode";
            cbCaptureMode.Size = new Size(139, 33);
            cbCaptureMode.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(-196, 42);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 26;
            label4.Text = "Capture Mode:";
            // 
            // btnStartCapture
            // 
            btnStartCapture.Location = new Point(372, 64);
            btnStartCapture.Name = "btnStartCapture";
            btnStartCapture.Size = new Size(136, 34);
            btnStartCapture.TabIndex = 28;
            btnStartCapture.Text = "Start";
            btnStartCapture.UseVisualStyleBackColor = true;
            btnStartCapture.Click += btnStartCapture_Click;
            // 
            // button3
            // 
            button3.Location = new Point(528, 64);
            button3.Name = "button3";
            button3.Size = new Size(136, 34);
            button3.TabIndex = 27;
            button3.Text = "Force Capture";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btbResetCalib);
            groupBox1.Controls.Add(numGain);
            groupBox1.Controls.Add(numContrast);
            groupBox1.Controls.Add(numBrightness);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 407);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(693, 91);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Calibration";
            // 
            // btbResetCalib
            // 
            btbResetCalib.Location = new Point(543, 37);
            btbResetCalib.Name = "btbResetCalib";
            btbResetCalib.Size = new Size(114, 34);
            btbResetCalib.TabIndex = 35;
            btbResetCalib.Text = "Reset";
            btbResetCalib.UseVisualStyleBackColor = true;
            btbResetCalib.Click += btbResetCalib_Click;
            // 
            // numGain
            // 
            numGain.Location = new Point(455, 38);
            numGain.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numGain.Name = "numGain";
            numGain.Size = new Size(71, 31);
            numGain.TabIndex = 23;
            numGain.TextAlign = HorizontalAlignment.Center;
            numGain.Value = new decimal(new int[] { 128, 0, 0, 0 });
            numGain.ValueChanged += numGain_ValueChanged;
            // 
            // numContrast
            // 
            numContrast.Location = new Point(296, 38);
            numContrast.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numContrast.Name = "numContrast";
            numContrast.Size = new Size(71, 31);
            numContrast.TabIndex = 22;
            numContrast.TextAlign = HorizontalAlignment.Center;
            numContrast.Value = new decimal(new int[] { 128, 0, 0, 0 });
            numContrast.ValueChanged += numContrast_ValueChanged;
            // 
            // numBrightness
            // 
            numBrightness.Location = new Point(121, 40);
            numBrightness.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numBrightness.Name = "numBrightness";
            numBrightness.Size = new Size(71, 31);
            numBrightness.TabIndex = 21;
            numBrightness.TextAlign = HorizontalAlignment.Center;
            numBrightness.Value = new decimal(new int[] { 128, 0, 0, 0 });
            numBrightness.ValueChanged += numBrightness_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(398, 40);
            label3.Name = "label3";
            label3.Size = new Size(51, 25);
            label3.TabIndex = 14;
            label3.Text = "Gain:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 40);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 13;
            label2.Text = "Contrast:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 40);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 6;
            label1.Text = "Brightness:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblScore);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(pbFinal);
            groupBox2.Location = new Point(363, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(333, 395);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            groupBox2.Text = "Capture";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(142, 356);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(22, 25);
            lblScore.TabIndex = 34;
            lblScore.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 356);
            label8.Name = "label8";
            label8.Size = new Size(121, 25);
            label8.TabIndex = 33;
            label8.Text = "Quality Score:";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(183, 351);
            button1.Name = "button1";
            button1.Size = new Size(114, 34);
            button1.TabIndex = 20;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // pbFinal
            // 
            pbFinal.BackColor = Color.White;
            pbFinal.Location = new Point(63, 32);
            pbFinal.Name = "pbFinal";
            pbFinal.Size = new Size(234, 301);
            pbFinal.SizeMode = PictureBoxSizeMode.Zoom;
            pbFinal.TabIndex = 5;
            pbFinal.TabStop = false;
            // 
            // Preview
            // 
            Preview.Controls.Add(lblPreviwScore);
            Preview.Controls.Add(pbPreview);
            Preview.Controls.Add(label10);
            Preview.Location = new Point(3, 3);
            Preview.Name = "Preview";
            Preview.Size = new Size(333, 395);
            Preview.TabIndex = 27;
            Preview.TabStop = false;
            Preview.Text = "Preview";
            // 
            // lblPreviwScore
            // 
            lblPreviwScore.AutoSize = true;
            lblPreviwScore.Location = new Point(144, 356);
            lblPreviwScore.Name = "lblPreviwScore";
            lblPreviwScore.Size = new Size(22, 25);
            lblPreviwScore.TabIndex = 36;
            lblPreviwScore.Text = "0";
            // 
            // pbPreview
            // 
            pbPreview.BackColor = Color.White;
            pbPreview.Location = new Point(56, 32);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(234, 301);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 4;
            pbPreview.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 356);
            label10.Name = "label10";
            label10.Size = new Size(121, 25);
            label10.TabIndex = 35;
            label10.Text = "Quality Score:";
            // 
            // CaptureControl
            // 
            BackColor = Color.White;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(Preview);
            Name = "CaptureControl";
            Size = new Size(702, 658);
            Load += CaptureControl_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)captureScore).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGain).EndInit();
            ((System.ComponentModel.ISupportInitialize)numContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBrightness).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFinal).EndInit();
            Preview.ResumeLayout(false);
            Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private Label label7;
        private Label label6;
        private Label label5;
        private NumericUpDown captureScore;
        private ComboBox cbCaptureMode;
        private Label label4;
        private Button btnStartCapture;
        private Button button3;
        private GroupBox groupBox1;
        private Button btbResetCalib;
        private NumericUpDown numGain;
        private NumericUpDown numContrast;
        private NumericUpDown numBrightness;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label lblScore;
        private Label label8;
        private Button button1;
        private PictureBox pbFinal;
        private GroupBox Preview;
        private Label lblPreviwScore;
        private PictureBox pbPreview;
        private Label label10;
    }
}
