namespace imd_fingerprint_readers.Controls
{
    partial class EnrollControl
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
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            comboBox2 = new ComboBox();
            label4 = new Label();
            btnStartCapture = new Button();
            button3 = new Button();
            groupBox4 = new GroupBox();
            lblRecordCount = new Label();
            label16 = new Label();
            button5 = new Button();
            comboBox3 = new ComboBox();
            label15 = new Label();
            textBox2 = new TextBox();
            label11 = new Label();
            textBox1 = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            btnEnroll = new Button();
            Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
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
            btnStartCapture.Location = new Point(372, 64);
            btnStartCapture.Name = "btnStartCapture";
            btnStartCapture.Size = new Size(136, 34);
            btnStartCapture.TabIndex = 28;
            btnStartCapture.Text = "Start";
            btnStartCapture.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(528, 64);
            button3.Name = "button3";
            button3.Size = new Size(136, 34);
            button3.TabIndex = 27;
            button3.Text = "Force Capture";
            button3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblRecordCount);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(button5);
            groupBox4.Controls.Add(comboBox3);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(textBox2);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(btnEnroll);
            groupBox4.Location = new Point(0, 547);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(693, 138);
            groupBox4.TabIndex = 32;
            groupBox4.TabStop = false;
            groupBox4.Text = "Person";
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Location = new Point(345, 90);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(22, 25);
            lblRecordCount.TabIndex = 39;
            lblRecordCount.Text = "0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(260, 90);
            label16.Name = "label16";
            label16.Size = new Size(79, 25);
            label16.TabIndex = 38;
            label16.Text = "Records:";
            // 
            // button5
            // 
            button5.Location = new Point(519, 90);
            button5.Name = "button5";
            button5.Size = new Size(136, 34);
            button5.TabIndex = 37;
            button5.Text = "Clear DB";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(346, 48);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(148, 33);
            comboBox3.TabIndex = 36;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(260, 51);
            label15.Name = "label15";
            label15.Size = new Size(65, 25);
            label15.TabIndex = 35;
            label15.Text = "Finger:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(86, 88);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 91);
            label11.Name = "label11";
            label11.Size = new Size(63, 25);
            label11.TabIndex = 33;
            label11.Text = "ID No:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(86, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(17, 51);
            label12.Name = "label12";
            label12.Size = new Size(63, 25);
            label12.TabIndex = 24;
            label12.Text = "Name:";
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
            // btnEnroll
            // 
            btnEnroll.Location = new Point(519, 46);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(136, 34);
            btnEnroll.TabIndex = 27;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = true;
            // 
            // EnrollControl
            // 
            BackColor = Color.White;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(Preview);
            Controls.Add(groupBox2);
            Name = "EnrollControl";
            Size = new Size(702, 695);
            Preview.ResumeLayout(false);
            Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private Label label12;
        private Label label13;
        private Label label14;
        private Button btnEnroll;
        private Label lblRecordCount;
        private Label label16;
        private Button button5;
        private ComboBox comboBox3;
        private Label label15;
        private TextBox textBox2;
        private Label label11;
        private TextBox textBox1;
    }
}
