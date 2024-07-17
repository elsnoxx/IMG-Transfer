using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Transfer_IMG
{
    public partial class JPGtoPDF : UserControl
    {
        public JPGtoPDF()
        {
            InitializeComponent();
            SetupDragAndDrop();
        }

        // Handler pro tlačítko výběru souboru
        private void openFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Všechny soubory (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Zde můžete pracovat se vybraným souborem
                    string selectedFileName = openFileDialog.FileName;
                    // Zobrazení cesty k souboru v TextBoxu
                    Path.Text = selectedFileName;
                }
            }
        }

        // Handler pro událost DragEnter - určuje, zda lze přetahovaný objekt zpracovat
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // Kontrola, zda přetažené data jsou soubory
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Handler pro událost DragDrop - zpracovává přetažené soubory
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Získání přetažených souborů
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Načtení první cesty souboru do TextBoxu nebo jiné logiky
                if (files.Length > 0)
                {
                    string filePath = files[0];
                    Path.Text = filePath;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FolderPath.Visible = Choose.Visible = !checkBox1.Checked;
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "-";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FolderPath.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
        }

        private void btnPDFGen_Click(object sender, EventArgs e)
        {
            string imagePath = Path.Text;
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please select an image file.");
                return;
            }

            string pdfPath = "";
            if (!checkBox1.Checked)
            {
                pdfPath = FolderPath.Text + "\\" +System.IO.Path.GetFileNameWithoutExtension(imagePath) + ".pdf";
            }
            else 
            {
                pdfPath = System.IO.Path.ChangeExtension(imagePath, ".pdf");
            }


            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage img = XImage.FromFile(imagePath);

                    double x = (page.Width - img.PixelWidth * 72 / img.HorizontalResolution) / 2;
                    double y = (page.Height - img.PixelHeight * 72 / img.VerticalResolution) / 2;

                    gfx.DrawImage(img, x, y, img.PixelWidth * 72 / img.HorizontalResolution, img.PixelHeight * 72 / img.VerticalResolution);

                    document.Save(pdfPath);
                }
                MessageBox.Show("PDF generated successfully: " + pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }

    }
}
