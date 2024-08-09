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
    /// <summary>
    /// Represents a form that allows users to download a QR code in different formats (PNG, SVG, PDF).
    /// </summary>
    public partial class QRdownload : Form
    {
        /// <summary>
        /// The text to encode in the QR code and its SVG representation.
        /// </summary>
        public string QRtext_SVG = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="QRdownload"/> class.
        /// Sets the QR code image and text, and initializes the width selection box.
        /// </summary>
        /// <param name="qrCodeImage">The image of the QR code.</param>
        /// <param name="QRtext">The text to encode in the QR code.</param>
        public QRdownload(Bitmap qrCodeImage, string QRtext)
        {
            InitializeComponent();

            qrCodePictureBox.Image = qrCodeImage;
            QRtext_SVG = QRtext;
            widthBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for the <c>btnSaveQR</c> button click event.
        /// Resizes the QR code image based on user input and saves it as a PNG file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            // Resize the image according to user input
            System.Drawing.Image resizedQrCodeImage = ResizeImage(qrCodePictureBox.Image, widthBox);

            // Save the resized QR code image to a file
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

        /// <summary>
        /// Displays a label indicating that the file has been saved.
        /// </summary>
        private void saveLabel_dysplayed()
        {
            saveLabel.Visible = true;
        }

        /// <summary>
        /// Resizes the given image based on the width specified in the provided ComboBox.
        /// </summary>
        /// <param name="imgToResize">The image to resize.</param>
        /// <param name="widthBox">The ComboBox containing the width value.</param>
        /// <returns>A new resized image, or <c>null</c> if the width input is invalid.</returns>
        private static System.Drawing.Image ResizeImage(System.Drawing.Image imgToResize, ComboBox widthBox)
        {
            int Width;

            // Check if the width input is valid
            if (!int.TryParse(widthBox.Text, out Width))
            {
                MessageBox.Show("Zadal jsi špatnou velikost");
                return null;
            }

            Size size = new Size(Width, Width);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        /// <summary>
        /// Generates a QR code bitmap from the specified text with the given size.
        /// </summary>
        /// <param name="qrText">The text to encode in the QR code.</param>
        /// <param name="size">The size of the QR code.</param>
        /// <returns>A bitmap representing the QR code.</returns>
        private Bitmap GenerateQrCodeBitmap(string qrText, int size)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // Create a QR code bitmap with the desired size
            Bitmap qrCodeBitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true);
            return qrCodeBitmap;
        }

        /// <summary>
        /// Resizes the given bitmap to the specified width.
        /// </summary>
        /// <param name="imgToResize">The bitmap to resize.</param>
        /// <param name="newWidth">The new width for the bitmap.</param>
        /// <returns>A new resized bitmap.</returns>
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

        /// <summary>
        /// Converts a bitmap to an SVG string encoded in Base64.
        /// </summary>
        /// <param name="bitmap">The bitmap to convert.</param>
        /// <returns>An SVG string containing the Base64 encoded image.</returns>
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

        /// <summary>
        /// Event handler for the <c>btnSaveQRSVG</c> button click event.
        /// Generates and saves the QR code as an SVG file with the specified size.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void btnSaveQRSVG_Click(object sender, EventArgs e)
        {
            // Get the new width
            int newWidth;
            if (!int.TryParse(widthBox.Text, out newWidth))
            {
                MessageBox.Show("Zadal jsi špatnou velikost");
                return;
            }

            // Generate QR code bitmap
            Bitmap qrCodeBitmap = GenerateQrCodeBitmap(QRtext_SVG, newWidth);

            // Resize bitmap
            Bitmap resizedBitmap = ResizeBitmap(qrCodeBitmap, newWidth);

            // Convert bitmap to SVG
            string resizedSvgCode = BitmapToSvgBase64(resizedBitmap);

            // Save SVG code to a file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SVG Image|*.svg";
                saveFileDialog.Title = "Save QR Code as SVG";
                saveFileDialog.FileName = "QRCode.svg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        // Save SVG code to file
                        System.IO.File.WriteAllText(saveFileDialog.FileName, resizedSvgCode);
                        saveLabel_dysplayed();
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the <c>savAsPDF</c> button click event.
        /// Saves the QR code image as a PDF file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void savAsPDF_Click(object sender, EventArgs e)
        {
            // Bitmap for displaying the QR code
            Bitmap qrCodeImage = (Bitmap)qrCodePictureBox.Image;

            // Save QR code as a PDF file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Document|*.pdf";
                saveFileDialog.Title = "Save QR Code as PDF";
                saveFileDialog.FileName = "QRCode.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        // Create PDF document
                        using (PdfDocument document = new PdfDocument())
                        {
                            // Add page
                            PdfPage page = document.AddPage();

                            // Set graphics for drawing on the page
                            XGraphics gfx = XGraphics.FromPdfPage(page);

                            // Create XImage from Bitmap
                            using (MemoryStream ms = new MemoryStream())
                            {
                                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                XImage img = XImage.FromStream(ms);

                                // Draw image centered on the page
                                double x = (page.Width - img.PointWidth) / 2;
                                double y = (page.Height - img.PointHeight) / 2;

                                gfx.DrawImage(img, x, y, img.PointWidth, img.PointHeight);
                            }

                            // Save PDF document
                            document.Save(saveFileDialog.FileName);
                        }
                        saveLabel_dysplayed();
                    }
                }
            }
        }
    }
}
