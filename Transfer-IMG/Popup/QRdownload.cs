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

namespace Transfer_IMG.Popup
{
    public partial class QRdownload : Form
    {
        public string QRtext_SVG = "";
        public QRdownload(Bitmap qrCodeImage, string QRtext)
        {
            InitializeComponent();

            qrCodePictureBox.Image = qrCodeImage;
            QRtext_SVG = QRtext;
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            // Bitmapa pro zobrazení QR kódu
            Bitmap qrCodeImage = (Bitmap)qrCodePictureBox.Image;

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

        private void btnSaveQRSVG_Click(object sender, EventArgs e)
        {

            // Zajistěte, že máte stále přístup k původnímu qrCodeData
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRtext_SVG, QRCodeGenerator.ECCLevel.Q);
            SvgQRCode svgQRCode = new SvgQRCode(qrCodeData);

            // Získání SVG jako řetězce
            string svgCode = svgQRCode.GetGraphic(20);

            // Uložení QR kódu do SVG souboru
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SVG Image|*.svg";
                saveFileDialog.Title = "Save QR Code as SVG";
                saveFileDialog.FileName = "QRCode.svg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        // Uložení SVG kódu do souboru
                        System.IO.File.WriteAllText(saveFileDialog.FileName, svgCode);
                        saveLabel_dysplayed();
                    }
                }
            }
        }
    }
}
