﻿namespace Transfer_IMG
{
    partial class PDFtoJPG
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
            this.label1 = new System.Windows.Forms.Label();
            this.Choose = new System.Windows.Forms.Button();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.Path = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDF to JPG";
            // 
            // Choose
            // 
            this.Choose.AutoSize = true;
            this.Choose.BackColor = System.Drawing.Color.Moccasin;
            this.Choose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Choose.Location = new System.Drawing.Point(600, 335);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(111, 30);
            this.Choose.TabIndex = 22;
            this.Choose.Text = "Vybrat složku";
            this.Choose.UseVisualStyleBackColor = false;
            this.Choose.Visible = false;
            // 
            // FolderPath
            // 
            this.FolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FolderPath.Location = new System.Drawing.Point(49, 339);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(484, 24);
            this.FolderPath.TabIndex = 21;
            this.FolderPath.Visible = false;
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(49, 169);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(484, 20);
            this.Path.TabIndex = 20;
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.Moccasin;
            this.openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.openFile.ForeColor = System.Drawing.Color.Black;
            this.openFile.Location = new System.Drawing.Point(600, 163);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(107, 28);
            this.openFile.TabIndex = 19;
            this.openFile.Text = "Otevřít";
            this.openFile.UseVisualStyleBackColor = false;
            // 
            // PDFtoJPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.label1);
            this.Name = "PDFtoJPG";
            this.Size = new System.Drawing.Size(761, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Choose;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button openFile;
    }
}
