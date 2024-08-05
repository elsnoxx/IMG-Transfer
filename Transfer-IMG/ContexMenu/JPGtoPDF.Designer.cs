using System.Windows.Forms;

namespace Transfer_IMG
{
    partial class JPGtoPDF
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
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Choose = new System.Windows.Forms.Button();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.Path = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.btnPDFGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 21);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(274, 33);
            this.label4.TabIndex = 32;
            this.label4.Text = "Převodník obrázků";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBox1.Location = new System.Drawing.Point(42, 224);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(331, 22);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Uložení na stejné místo jako nahraný obrázek.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Choose
            // 
            this.Choose.AutoSize = true;
            this.Choose.BackColor = System.Drawing.Color.Moccasin;
            this.Choose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Choose.Location = new System.Drawing.Point(589, 249);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(111, 30);
            this.Choose.TabIndex = 30;
            this.Choose.Text = "Vybrat složku";
            this.Choose.UseVisualStyleBackColor = false;
            this.Choose.Visible = false;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // FolderPath
            // 
            this.FolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.FolderPath.Location = new System.Drawing.Point(42, 249);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(484, 30);
            this.FolderPath.TabIndex = 29;
            this.FolderPath.Visible = false;
            // 
            // Path
            // 
            this.Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Path.Location = new System.Drawing.Point(42, 120);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(484, 30);
            this.Path.TabIndex = 28;
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.Moccasin;
            this.openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.openFile.ForeColor = System.Drawing.Color.Black;
            this.openFile.Location = new System.Drawing.Point(589, 120);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(111, 30);
            this.openFile.TabIndex = 27;
            this.openFile.Text = "Otevřít";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // btnPDFGen
            // 
            this.btnPDFGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDFGen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDFGen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPDFGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPDFGen.Location = new System.Drawing.Point(254, 416);
            this.btnPDFGen.Name = "btnPDFGen";
            this.btnPDFGen.Size = new System.Drawing.Size(205, 70);
            this.btnPDFGen.TabIndex = 33;
            this.btnPDFGen.Text = "Generovat PDF";
            this.btnPDFGen.UseVisualStyleBackColor = false;
            this.btnPDFGen.Click += new System.EventHandler(this.btnPDFGen_Click);
            // 
            // JPGtoPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPDFGen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.openFile);
            this.Name = "JPGtoPDF";
            this.Size = new System.Drawing.Size(761, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SetupDragAndDrop()
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        #endregion

        private Label label4;
        private CheckBox checkBox1;
        public Button Choose;
        private TextBox FolderPath;
        private TextBox Path;
        private Button openFile;
        private Button btnPDFGen;
    }
}
