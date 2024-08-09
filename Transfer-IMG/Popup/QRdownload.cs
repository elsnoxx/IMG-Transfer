using QRCoder;
using System;
using System.Drawing;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Drawing.Drawing2D;

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
            widthBox.SelectedIndex = 0;
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {

            // Změna velikosti obrázku podle zadaných rozměrů
            System.Drawing.Image resizedQrCodeImage = ResizeImage(qrCodePictureBox.Image, widthBox);

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
                        resizedQrCodeImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        saveLabel_dysplayed();
                    }
                }
            }
        }

        private void saveLabel_dysplayed()
        {
            saveLabel.Visible = true;
        }

        private static System.Drawing.Image ResizeImage(System.Drawing.Image imgToResize, ComboBox widthBox)
        {
            int Width;

            // Kontrola, zda je vstup validní, pokud ne, zobrazí se chybová zpráva a metoda se ukončí.
            if (!int.TryParse(widthBox.Text, out Width))
            {
                MessageBox.Show("Zadal jsi špatnou velikost");
                return null; // Ukončí metodu a vrátí null
            }

            Size size = new Size(Width, Width);
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;

        }

        private Bitmap GenerateQrCodeBitmap(string qrText, int size)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // Vytvoření bitmapy QR kódu s požadovanou velikostí
            Bitmap qrCodeBitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true);
            return qrCodeBitmap;
        }

        private Bitmap ResizeBitmap(Bitmap imgToResize, int newWidth)
        {
            Bitmap b = new Bitmap(newWidth, newWidth);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, newWidth, newWidth);
            }
            return b;
        }

        private string BitmapToSvgBase64(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{bitmap.Width}\" height=\"{bitmap.Height}\"><image href=\"data:image/png;base64,{base64String}\" width=\"{bitmap.Width}\" height=\"{bitmap.Height}\" /></svg>";
            }
        }

        private void btnSaveQRSVG_Click(object sender, EventArgs e)
        {
            // Získání nové velikosti
            int newWidth;
            if (!int.TryParse(widthBox.Text, out newWidth))
            {
                MessageBox.Show("Zadal jsi špatnou velikost");
                return;
            }

            // Vygenerování QR kódu jako bitmapa
            Bitmap qrCodeBitmap = GenerateQrCodeBitmap(QRtext_SVG, newWidth);

            // Změna velikosti bitmapy
            Bitmap resizedBitmap = ResizeBitmap(qrCodeBitmap, newWidth);

            // Převedení bitmapy na SVG
            string resizedSvgCode = BitmapToSvgBase64(resizedBitmap);

            // Uložení SVG kódu do souboru
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
                        System.IO.File.WriteAllText(saveFileDialog.FileName, resizedSvgCode);
                        saveLabel_dysplayed();
                    }
                }
            }
        }



        private void savAsPDF_Click(object sender, EventArgs e)
        {
            // Bitmapa pro zobrazení QR kódu
            Bitmap qrCodeImage = (Bitmap)qrCodePictureBox.Image;

            // Uložení QR kódu do souboru jako PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Document|*.pdf";
                saveFileDialog.Title = "Save QR Code as PDF";
                saveFileDialog.FileName = "QRCode.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        // Vytvoření PDF dokumentu
                        using (PdfDocument document = new PdfDocument())
                        {
                            // Přidání stránky
                            PdfPage page = document.AddPage();

                            // Nastavení grafiky pro vykreslování na stránku
                            XGraphics gfx = XGraphics.FromPdfPage(page);

                            // Vytvoření XImage z Bitmapy
                            using (MemoryStream ms = new MemoryStream())
                            {
                                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                XImage img = XImage.FromStream(ms);

                                // Vykreslení obrázku na střed stránky
                                double x = (page.Width - img.PointWidth) / 2;
                                double y = (page.Height - img.PointHeight) / 2;

                                gfx.DrawImage(img, x, y, img.PointWidth, img.PointHeight);
                            }

                            // Uložení PDF dokumentu
                            document.Save(saveFileDialog.FileName);
                        }
                        saveLabel_dysplayed();
                    }
                }
            }
        }

    }
}
