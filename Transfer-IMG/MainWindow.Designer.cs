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
            this.PDFtoJPG = new System.Windows.Forms.Button();
            this.JPGtoPDF = new System.Windows.Forms.Button();
            this.btnTransferIMG = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(936, 24);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mainPanel.Location = new System.Drawing.Point(175, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(761, 528);
            this.mainPanel.TabIndex = 1;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuPanel.Controls.Add(this.PDFtoJPG);
            this.menuPanel.Controls.Add(this.JPGtoPDF);
            this.menuPanel.Controls.Add(this.btnTransferIMG);
            this.menuPanel.Location = new System.Drawing.Point(0, 24);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(176, 528);
            this.menuPanel.TabIndex = 2;
            // 
            // PDFtoJPG
            // 
            this.PDFtoJPG.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PDFtoJPG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PDFtoJPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PDFtoJPG.Location = new System.Drawing.Point(10, 84);
            this.PDFtoJPG.Name = "PDFtoJPG";
            this.PDFtoJPG.Size = new System.Drawing.Size(159, 33);
            this.PDFtoJPG.TabIndex = 2;
            this.PDFtoJPG.Text = "PDF to JPG";
            this.PDFtoJPG.UseVisualStyleBackColor = false;
            this.PDFtoJPG.Click += new System.EventHandler(this.PDFtoJPG_Click);
            // 
            // JPGtoPDF
            // 
            this.JPGtoPDF.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.JPGtoPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JPGtoPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.JPGtoPDF.Location = new System.Drawing.Point(10, 45);
            this.JPGtoPDF.Name = "JPGtoPDF";
            this.JPGtoPDF.Size = new System.Drawing.Size(159, 33);
            this.JPGtoPDF.TabIndex = 1;
            this.JPGtoPDF.Text = "JPG to PDF";
            this.JPGtoPDF.UseVisualStyleBackColor = false;
            this.JPGtoPDF.Click += new System.EventHandler(this.JPGtoPDF_Click);
            // 
            // btnTransferIMG
            // 
            this.btnTransferIMG.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnTransferIMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferIMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTransferIMG.Location = new System.Drawing.Point(10, 6);
            this.btnTransferIMG.Name = "btnTransferIMG";
            this.btnTransferIMG.Size = new System.Drawing.Size(159, 33);
            this.btnTransferIMG.TabIndex = 0;
            this.btnTransferIMG.Text = "Převod obrázku";
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
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnTransferIMG;
        private System.Windows.Forms.Button JPGtoPDF;
        private System.Windows.Forms.Button PDFtoJPG;
    }
}