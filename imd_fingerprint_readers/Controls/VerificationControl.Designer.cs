namespace imd_fingerprint_readers.Controls
{
    partial class VerificationControl
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
            Preview = new GroupBox();
            lblPreviwScore = new Label();
            pictureBox2 = new PictureBox();
            label10 = new Label();
            groupBox2 = new GroupBox();
            lblScore = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            comboBox2 = new ComboBox();
            label4 = new Label();
            btnStartCapture = new Button();
            button3 = new Button();
            groupBox4 = new GroupBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label11 = new Label();
            label13 = new Label();
            label14 = new Label();
            Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // Preview
            // 
            Preview.Controls.Add(lblPreviwScore);
            Preview.Controls.Add(pictureBox2);
            Preview.Controls.Add(label10);
            Preview.Location = new Point(3, 3);
            Preview.Name = "Preview";
            Preview.Size = new Size(333, 395);
            Preview.TabIndex = 29;
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
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(56, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(234, 301);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(lblScore);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Location = new Point(363, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(333, 395);
            groupBox2.TabIndex = 30;
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
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(63, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(234, 301);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(numericUpDown4);
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(btnStartCapture);
            groupBox3.Controls.Add(button3);
            groupBox3.Location = new Point(3, 404);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(693, 138);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Capture Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 94);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 34;
            label2.Text = "Matching Threshold:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(539, 92);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(118, 31);
            numericUpDown1.TabIndex = 33;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 50, 0, 0, 0 });
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
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(194, 88);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(139, 31);
            numericUpDown4.TabIndex = 30;
            numericUpDown4.TextAlign = HorizontalAlignment.Center;
            numericUpDown4.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(194, 44);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(139, 33);
            comboBox2.TabIndex = 29;
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
            btnStartCapture.Location = new Point(360, 42);
            btnStartCapture.Name = "btnStartCapture";
            btnStartCapture.Size = new Size(136, 34);
            btnStartCapture.TabIndex = 28;
            btnStartCapture.Text = "Start";
            btnStartCapture.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(521, 43);
            button3.Name = "button3";
            button3.Size = new Size(136, 34);
            button3.TabIndex = 27;
            button3.Text = "Force Capture";
            button3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(textBox2);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label14);
            groupBox4.Location = new Point(0, 547);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(693, 79);
            groupBox4.TabIndex = 32;
            groupBox4.TabStop = false;
            groupBox4.Text = "Verification";
            // 
            // button1
            // 
            button1.Location = new Point(363, 30);
            button1.Name = "button1";
            button1.Size = new Size(136, 34);
            button1.TabIndex = 35;
            button1.Text = "Verify";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(179, 30);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(157, 31);
            textBox2.TabIndex = 36;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(110, 33);
            label11.Name = "label11";
            label11.Size = new Size(63, 25);
            label11.TabIndex = 35;
            label11.Text = "ID No:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(-196, 83);
            label13.Name = "label13";
            label13.Size = new Size(171, 25);
            label13.TabIndex = 31;
            label13.Text = "Auto Capture Score:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(-196, 42);
            label14.Name = "label14";
            label14.Size = new Size(130, 25);
            label14.TabIndex = 26;
            label14.Text = "Capture Mode:";
            // 
            // VerificationControl
            // 
            BackColor = Color.White;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(Preview);
            Controls.Add(groupBox2);
            Name = "VerificationControl";
            Size = new Size(702, 695);
            Preview.ResumeLayout(false);
            Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Preview;
        private Label lblPreviwScore;
        private PictureBox pictureBox2;
        private Label label10;
        private GroupBox groupBox2;
        private Label lblScore;
        private Label label8;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private Label label7;
        private Label label6;
        private Label label5;
        private NumericUpDown numericUpDown4;
        private ComboBox comboBox2;
        private Label label4;
        private Button btnStartCapture;
        private Button button3;
        private GroupBox groupBox4;
        private Label label13;
        private Label label14;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private TextBox textBox2;
        private Label label11;
    }
}
