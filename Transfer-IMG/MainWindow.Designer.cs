namespace Transfer_IMG
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.language = new System.Windows.Forms.Label();
            this.QRcodes = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.PDFtoJPG = new System.Windows.Forms.Button();
            this.JPGtoPDF = new System.Windows.Forms.Button();
            this.btnTransferIMG = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(936, 552);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(207)))));
            this.mainPanel.Location = new System.Drawing.Point(175, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(761, 528);
            this.mainPanel.TabIndex = 1;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.menuPanel.Controls.Add(this.language);
            this.menuPanel.Controls.Add(this.QRcodes);
            this.menuPanel.Controls.Add(this.btnHome);
            this.menuPanel.Controls.Add(this.PDFtoJPG);
            this.menuPanel.Controls.Add(this.JPGtoPDF);
            this.menuPanel.Controls.Add(this.btnTransferIMG);
            this.menuPanel.Location = new System.Drawing.Point(0, 24);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(176, 528);
            this.menuPanel.TabIndex = 2;
            // 
            // language
            // 
            this.language.AutoSize = true;
            this.language.ForeColor = System.Drawing.Color.White;
            this.language.Location = new System.Drawing.Point(3, 512);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(21, 13);
            this.language.TabIndex = 0;
            this.language.Text = "CZ";
            this.language.Click += new System.EventHandler(this.language_Click);
            // 
            // QRcodes
            // 
            this.QRcodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.QRcodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QRcodes.FlatAppearance.BorderSize = 0;
            this.QRcodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QRcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.QRcodes.ForeColor = System.Drawing.Color.White;
            this.QRcodes.Image = ((System.Drawing.Image)(resources.GetObject("QRcodes.Image")));
            this.QRcodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QRcodes.Location = new System.Drawing.Point(0, 184);
            this.QRcodes.Name = "QRcodes";
            this.QRcodes.Size = new System.Drawing.Size(176, 40);
            this.QRcodes.TabIndex = 4;
            this.QRcodes.Text = "  QR kody";
            this.QRcodes.UseVisualStyleBackColor = false;
            this.QRcodes.Click += new System.EventHandler(this.QRcodes_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(176, 40);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "              Domů";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // PDFtoJPG
            // 
            this.PDFtoJPG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PDFtoJPG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PDFtoJPG.FlatAppearance.BorderSize = 0;
            this.PDFtoJPG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDFtoJPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PDFtoJPG.ForeColor = System.Drawing.Color.White;
            this.PDFtoJPG.Image = ((System.Drawing.Image)(resources.GetObject("PDFtoJPG.Image")));
            this.PDFtoJPG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PDFtoJPG.Location = new System.Drawing.Point(0, 138);
            this.PDFtoJPG.Name = "PDFtoJPG";
            this.PDFtoJPG.Size = new System.Drawing.Size(176, 40);
            this.PDFtoJPG.TabIndex = 2;
            this.PDFtoJPG.Text = "       PDF to JPG";
            this.PDFtoJPG.UseVisualStyleBackColor = false;
            this.PDFtoJPG.Click += new System.EventHandler(this.PDFtoJPG_Click);
            // 
            // JPGtoPDF
            // 
            this.JPGtoPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.JPGtoPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JPGtoPDF.FlatAppearance.BorderSize = 0;
            this.JPGtoPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JPGtoPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.JPGtoPDF.ForeColor = System.Drawing.Color.White;
            this.JPGtoPDF.Image = ((System.Drawing.Image)(resources.GetObject("JPGtoPDF.Image")));
            this.JPGtoPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.JPGtoPDF.Location = new System.Drawing.Point(0, 92);
            this.JPGtoPDF.Name = "JPGtoPDF";
            this.JPGtoPDF.Size = new System.Drawing.Size(176, 40);
            this.JPGtoPDF.TabIndex = 1;
            this.JPGtoPDF.Text = "       JPG to PDF";
            this.JPGtoPDF.UseVisualStyleBackColor = false;
            this.JPGtoPDF.Click += new System.EventHandler(this.JPGtoPDF_Click);
            // 
            // btnTransferIMG
            // 
            this.btnTransferIMG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnTransferIMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferIMG.FlatAppearance.BorderSize = 0;
            this.btnTransferIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferIMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTransferIMG.ForeColor = System.Drawing.Color.White;
            this.btnTransferIMG.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferIMG.Image")));
            this.btnTransferIMG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferIMG.Location = new System.Drawing.Point(0, 46);
            this.btnTransferIMG.Name = "btnTransferIMG";
            this.btnTransferIMG.Size = new System.Drawing.Size(176, 40);
            this.btnTransferIMG.TabIndex = 0;
            this.btnTransferIMG.Text = "        Převod obrázku";
            this.btnTransferIMG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransferIMG.UseVisualStyleBackColor = false;
            this.btnTransferIMG.Click += new System.EventHandler(this.btnTransferIMG_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 552);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(952, 591);
            this.MinimumSize = new System.Drawing.Size(952, 591);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnTransferIMG;
        private System.Windows.Forms.Button JPGtoPDF;
        private System.Windows.Forms.Button PDFtoJPG;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button QRcodes;
        private System.Windows.Forms.Label language;
    }
}