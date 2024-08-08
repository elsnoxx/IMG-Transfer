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
using Transfer_IMG.Popup;

namespace Transfer_IMG.ContexMenu
{
    public partial class QRcodes : UserControl
    {
        public QRcodes()
        {
            InitializeComponent();
        }

        private void GenQr_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            QRdownload QRdownloadPopup = new QRdownload((Bitmap)qrCodePictureBox.Image, textBox.Text);

            // Show the settings form
            QRdownloadPopup.ShowDialog();
        }

        private void GenQr_Update(object sender, EventArgs e)
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
            GenQr_Update(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            qrCodePictureBox.Image = null;
        }        
    }
}
