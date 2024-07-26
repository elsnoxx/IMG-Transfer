using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfer_IMG.General;

namespace Transfer_IMG.ContexMenu
{
    public partial class QRcodes : UserControl
    {
        public QRcodes()
        {
            InitializeComponent();
            language();
        }

        public void language()
        {
            if (WT.language == "1")
            {
                this.saveLabel.Text = "Uloženo";
            }
            else
            {
                this.saveLabel.Text = "Saved";
            }
        }

        private void GenQr_Click(object sender, EventArgs e)
        {
            // Instance QRCodeGenerator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Definování znaků
            var replacements = new Dictionary<string, char>
            {
                ["[GS]"] = (char)29,
                ["[RS]"] = (char)30,
                ["[CR]"] = (char)13,
                ["[LF]"] = (char)10,
                ["[EOT]"] = (char)4
            };

            // Původní text
            string data = textBox.Text;

            // Procházení slovníku a nahrazení
            foreach (var replacement in replacements)
            {
                data = data.Replace(replacement.Key, replacement.Value.ToString());
            }
            // Instance QRCodeData a GenerateData
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            // Instance QRCode a QRCodeData
            QRCode qrCode = new QRCode(qrCodeData);

            // Bitmapa pro zobrazení QR kódu
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Nastavení PictureBox pro zobrazení QR kódu
            qrCodePictureBox.Image = qrCodeImage;
        }

        private void InsertTextAtCursor(string textToInsert)
        {
            int selectionIndex = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(selectionIndex, textToInsert);
            textBox.SelectionStart = selectionIndex + textToInsert.Length;
            textBox.Focus();
        }

        private void btnInsertGS_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[GS]");
        }

        private void btnInsertRS_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[RS]");
        }

        private void btnInsertCR_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[CR]");
        }

        private void btnInsertLF_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[LF]");
        }

        private void btnInsertEOT_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[EOT]");
        }

        private void bntinsertFirst_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[)>");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            saveLabel_hide();
            GenQr_Click(sender, e);
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Instance QRCodeData a GenerateData
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox.Text, QRCodeGenerator.ECCLevel.Q);

            // Instance QRCode a QRCodeData
            QRCode qrCode = new QRCode(qrCodeData);

            // Bitmapa pro zobrazení QR kódu
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Uložení QR kódu do souboru
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.FileName = "QRCode.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        qrCodeImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        saveLabel_dysplayed();
                    }
                }
            }
        }

        private void saveLabel_dysplayed()
        {
            saveLabel.Visible = true;
        }

        private void saveLabel_hide()
        {
            saveLabel.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
            qrCodePictureBox.Image = null;
        }

        private void btnSaveQRSVG_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Instance QRCodeData a GenerateData
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox.Text, QRCodeGenerator.ECCLevel.Q);

            // Instance QRCode a QRCodeData
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap svgCode = qrCode.GetGraphic(20, Color.Black, Color.White, true);

            // Uložení QR kódu do souboru
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.svg";
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.FileName = "QRCode.svg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, svgCode.ToString());
                        saveLabel_dysplayed();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving QR code: " + ex.Message);
                    }
                }
            }
        }

        
    }
}
