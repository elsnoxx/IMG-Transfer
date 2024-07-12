namespace IMGTransefere
{
    partial class Form1
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
            button1 = new Button();
            progressBar = new ProgressBar();
            Path = new TextBox();
            imgTransfer = new Button();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            Choose = new Button();
            FolderPath = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(360, 106);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 0;
            button1.Text = "Otevřít";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.IndianRed;
            progressBar.Location = new Point(37, 317);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(410, 23);
            progressBar.TabIndex = 1;
            progressBar.Visible = false;
            // 
            // Path
            // 
            Path.Location = new Point(37, 106);
            Path.Name = "Path";
            Path.Size = new Size(317, 23);
            Path.TabIndex = 2;
            // 
            // imgTransfer
            // 
            imgTransfer.BackColor = Color.PeachPuff;
            imgTransfer.ForeColor = SystemColors.ControlText;
            imgTransfer.Location = new Point(172, 254);
            imgTransfer.Name = "imgTransfer";
            imgTransfer.Size = new Size(131, 57);
            imgTransfer.TabIndex = 3;
            imgTransfer.Text = "Převést";
            imgTransfer.UseVisualStyleBackColor = false;
            imgTransfer.Click += imgTransfer_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(37, 184);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(266, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Uložení na stejné místo jako nahraný obrázek.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "JPG", "PNG", "JPEG" });
            comboBox1.Location = new Point(106, 135);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(50, 23);
            comboBox1.TabIndex = 6;
            // 
            // Choose
            // 
            Choose.Location = new Point(358, 209);
            Choose.Name = "Choose";
            Choose.Size = new Size(89, 23);
            Choose.TabIndex = 7;
            Choose.Text = "Vybrat složku";
            Choose.UseVisualStyleBackColor = true;
            Choose.Visible = false;
            Choose.Click += Choose_Click;
            // 
            // FolderPath
            // 
            FolderPath.Location = new Point(37, 209);
            FolderPath.Name = "FolderPath";
            FolderPath.Size = new Size(317, 23);
            FolderPath.TabIndex = 8;
            FolderPath.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            label2.Location = new Point(115, 36);
            label2.Name = "label2";
            label2.Size = new Size(256, 33);
            label2.TabIndex = 9;
            label2.Text = "Převodník obrázků";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(40, 135);
            label3.Name = "label3";
            label3.Size = new Size(60, 21);
            label3.TabIndex = 10;
            label3.Text = "Formát";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(218, 135);
            label4.Name = "label4";
            label4.Size = new Size(115, 21);
            label4.TabIndex = 11;
            label4.Text = "Míra komprese";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "100", "80", "75", "50", "25" });
            comboBox2.Location = new Point(339, 137);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(55, 23);
            comboBox2.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(400, 137);
            label5.Name = "label5";
            label5.Size = new Size(23, 21);
            label5.TabIndex = 13;
            label5.Text = "%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(484, 361);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(FolderPath);
            Controls.Add(Choose);
            Controls.Add(comboBox1);
            Controls.Add(checkBox1);
            Controls.Add(imgTransfer);
            Controls.Add(Path);
            Controls.Add(progressBar);
            Controls.Add(button1);
            MaximizeBox = false;
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(500, 400);
            Name = "Form1";
            Text = "Převodník obrázků";
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupDragAndDrop()
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar;
        private TextBox Path;
        private Button imgTransfer;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Button Choose;
        private TextBox FolderPath;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
    }
}
