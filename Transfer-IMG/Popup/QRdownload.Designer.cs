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
            this.qrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.saveLabel = new System.Windows.Forms.Label();
            this.btnSaveQRSVG = new System.Windows.Forms.Button();
            this.btnSaveQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // qrCodePictureBox
            // 
            this.qrCodePictureBox.BackColor = System.Drawing.Color.White;
            this.qrCodePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrCodePictureBox.Location = new System.Drawing.Point(40, 99);
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
            this.saveLabel.Location = new System.Drawing.Point(486, 352);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(113, 27);
            this.saveLabel.TabIndex = 15;
            this.saveLabel.Text = "Uloženo";
            this.saveLabel.Visible = false;
            // 
            // btnSaveQRSVG
            // 
            this.btnSaveQRSVG.Location = new System.Drawing.Point(582, 299);
            this.btnSaveQRSVG.Name = "btnSaveQRSVG";
            this.btnSaveQRSVG.Size = new System.Drawing.Size(100, 50);
            this.btnSaveQRSVG.TabIndex = 14;
            this.btnSaveQRSVG.Text = "Uložit jako SVG";
            this.btnSaveQRSVG.UseVisualStyleBackColor = true;
            this.btnSaveQRSVG.Click += new System.EventHandler(this.btnSaveQRSVG_Click);
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.Location = new System.Drawing.Point(405, 299);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(100, 50);
            this.btnSaveQR.TabIndex = 13;
            this.btnSaveQR.Text = "Uložit jako PNG";
            this.btnSaveQR.UseVisualStyleBackColor = true;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // QRdownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.btnSaveQRSVG);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.qrCodePictureBox);
            this.Name = "QRdownload";
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
    }
}