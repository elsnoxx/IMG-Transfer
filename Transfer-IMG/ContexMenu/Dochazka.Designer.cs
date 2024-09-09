namespace Transfer_IMG.ContexMenu
{
    partial class Dochazka
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dochazka));
            this.label4 = new System.Windows.Forms.Label();
            this.Prepocitat = new System.Windows.Forms.Button();
            this.celkem = new System.Windows.Forms.Label();
            this.celkemHodin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(592, 13);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(153, 33);
            this.label4.TabIndex = 27;
            this.label4.Text = "Docházka";
            // 
            // Prepocitat
            // 
            this.Prepocitat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Prepocitat.BackgroundImage")));
            this.Prepocitat.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.Prepocitat.ForeColor = System.Drawing.Color.White;
            this.Prepocitat.Location = new System.Drawing.Point(595, 65);
            this.Prepocitat.Name = "Prepocitat";
            this.Prepocitat.Size = new System.Drawing.Size(139, 44);
            this.Prepocitat.TabIndex = 28;
            this.Prepocitat.Text = "Prepocitat";
            this.Prepocitat.UseVisualStyleBackColor = true;
            this.Prepocitat.Click += new System.EventHandler(this.Prepocitat_Click);
            // 
            // celkem
            // 
            this.celkem.AutoSize = true;
            this.celkem.Location = new System.Drawing.Point(586, 131);
            this.celkem.Name = "celkem";
            this.celkem.Size = new System.Drawing.Size(148, 13);
            this.celkem.TabIndex = 29;
            this.celkem.Text = "Celkem odpracovaných hodin";
            // 
            // celkemHodin
            // 
            this.celkemHodin.AutoSize = true;
            this.celkemHodin.Location = new System.Drawing.Point(614, 153);
            this.celkemHodin.Name = "celkemHodin";
            this.celkemHodin.Size = new System.Drawing.Size(0, 13);
            this.celkemHodin.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Ulozeni do excelu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(598, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Nahrani z excelu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dochazka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.celkemHodin);
            this.Controls.Add(this.celkem);
            this.Controls.Add(this.Prepocitat);
            this.Controls.Add(this.label4);
            this.Name = "Dochazka";
            this.Size = new System.Drawing.Size(761, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Prepocitat;
        private System.Windows.Forms.Label celkem;
        private System.Windows.Forms.Label celkemHodin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
