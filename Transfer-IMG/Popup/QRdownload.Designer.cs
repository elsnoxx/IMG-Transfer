namespace Transfer_IMG.Popup
{
    partial class QRdownload
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRdownload));
            this.qrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.saveLabel = new System.Windows.Forms.Label();
            this.btnSaveQRSVG = new System.Windows.Forms.Button();
            this.btnSaveQR = new System.Windows.Forms.Button();
            this.widthBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.savAsPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // qrCodePictureBox
            // 
            this.qrCodePictureBox.BackColor = System.Drawing.Color.White;
            this.qrCodePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrCodePictureBox.Location = new System.Drawing.Point(12, 12);
            this.qrCodePictureBox.Name = "qrCodePictureBox";
            this.qrCodePictureBox.Size = new System.Drawing.Size(250, 250);
            this.qrCodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qrCodePictureBox.TabIndex = 7;
            this.qrCodePictureBox.TabStop = false;
            // 
            // saveLabel
            // 
            this.saveLabel.AutoSize = true;
            this.saveLabel.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.saveLabel.Location = new System.Drawing.Point(336, 12);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(113, 27);
            this.saveLabel.TabIndex = 15;
            this.saveLabel.Text = "Uloženo";
            this.saveLabel.Visible = false;
            // 
            // btnSaveQRSVG
            // 
            this.btnSaveQRSVG.FlatAppearance.BorderSize = 0;
            this.btnSaveQRSVG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveQRSVG.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveQRSVG.ForeColor = System.Drawing.Color.White;
            this.btnSaveQRSVG.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveQRSVG.Image")));
            this.btnSaveQRSVG.Location = new System.Drawing.Point(398, 212);
            this.btnSaveQRSVG.Name = "btnSaveQRSVG";
            this.btnSaveQRSVG.Size = new System.Drawing.Size(100, 50);
            this.btnSaveQRSVG.TabIndex = 14;
            this.btnSaveQRSVG.Text = "SVG";
            this.btnSaveQRSVG.UseVisualStyleBackColor = true;
            this.btnSaveQRSVG.Click += new System.EventHandler(this.btnSaveQRSVG_Click);
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.FlatAppearance.BorderSize = 0;
            this.btnSaveQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveQR.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveQR.ForeColor = System.Drawing.Color.White;
            this.btnSaveQR.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveQR.Image")));
            this.btnSaveQR.Location = new System.Drawing.Point(292, 212);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(100, 50);
            this.btnSaveQR.TabIndex = 13;
            this.btnSaveQR.Text = "PNG";
            this.btnSaveQR.UseVisualStyleBackColor = true;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // widthBox
            // 
            this.widthBox.FormattingEnabled = true;
            this.widthBox.Items.AddRange(new object[] {
            "1000",
            "800",
            "750",
            "500",
            "250"});
            this.widthBox.Location = new System.Drawing.Point(360, 74);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(64, 21);
            this.widthBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Šířka";
            // 
            // savAsPDF
            // 
            this.savAsPDF.FlatAppearance.BorderSize = 0;
            this.savAsPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savAsPDF.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.savAsPDF.ForeColor = System.Drawing.Color.White;
            this.savAsPDF.Image = ((System.Drawing.Image)(resources.GetObject("savAsPDF.Image")));
            this.savAsPDF.Location = new System.Drawing.Point(292, 156);
            this.savAsPDF.Name = "savAsPDF";
            this.savAsPDF.Size = new System.Drawing.Size(100, 50);
            this.savAsPDF.TabIndex = 30;
            this.savAsPDF.Text = "PDF";
            this.savAsPDF.UseVisualStyleBackColor = true;
            this.savAsPDF.Click += new System.EventHandler(this.savAsPDF_Click);
            // 
            // QRdownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(507, 274);
            this.Controls.Add(this.savAsPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.btnSaveQRSVG);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.qrCodePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QRdownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QRdownload";
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox qrCodePictureBox;
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.Button btnSaveQRSVG;
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.ComboBox widthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savAsPDF;
    }
}