using System;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Transfer_IMG.General;

namespace Transfer_IMG
{
    /// <summary>
    /// UserControl for converting JPG images to PDF documents.
    /// Provides functionality to select an image, specify output location, and generate a PDF.
    /// </summary>
    public partial class JPGtoPDF : UserControl
    {
        private Common common;

        /// <summary>
        /// Initializes a new instance of the <see cref="JPGtoPDF"/> class.
        /// Sets up drag-and-drop functionality for file selection.
        /// </summary>
        public JPGtoPDF()
        {
            InitializeComponent();
            SetupDragAndDrop();
            common = new Common();
        }

        /// <summary>
        /// Event handler for the <c>openFile</c> button click event.
        /// Opens a file dialog to select a JPG file and displays the file path in a TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void openFile_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Všechny soubory (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path in TextBox
                    string selectedFileName = openFileDialog.FileName;
                    Path.Text = selectedFileName;
                }
            }
        }

        /// <summary>
        /// Event handler for the DragEnter event.
        /// Determines whether the dragged object can be processed (i.e., if it is a file).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> containing event data.</param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            label5.Visible = false;
            // Check if dragged data is files
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Event handler for the DragDrop event.
        /// Processes the dropped files and displays the path of the first file in a TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> containing event data.</param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            label5.Visible = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length > 0)
                {
                    string filePath = files[0];
                    Path.Text = filePath;
                }
            }
        }

        /// <summary>
        /// Event handler for the <c>checkBox1</c> checked changed event.
        /// Shows or hides the folder path selection controls based on the checkbox state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FolderPath.Visible = Choose.Visible = !checkBox1.Checked;
        }

        /// <summary>
        /// Event handler for the <c>Choose</c> button click event.
        /// Opens a folder picker dialog to select the folder for saving the PDF.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
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

        /// <summary>
        /// Event handler for the <c>btnPDFGen</c> button click event.
        /// Validates input, converts the selected JPG image to a PDF, and saves it to the specified location.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnPDFGen_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string imagePath = Path.Text;
            string pdfPath = "";
            progressBar1.Visible = true;
            progressBar1.Value = 10;

            // Determine output PDF path based on checkbox state
            if (!checkBox1.Checked)
            {
                pdfPath = FolderPath.Text + "\\" + System.IO.Path.GetFileNameWithoutExtension(imagePath) + ".pdf";
            }
            else
            {
                pdfPath = System.IO.Path.ChangeExtension(imagePath, ".pdf");
            }
            common.ProgressBarLoading(10, progressBar1);
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    if (!PageOrientation.Checked)
                    {
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                    }
                    common.ProgressBarLoading(10, progressBar1);
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage img = XImage.FromFile(imagePath);

                    // Calculate the scaling factor to fit the image on the PDF page
                    double scaleFactor = Math.Min(page.Width / img.PixelWidth, page.Height / img.PixelHeight);

                    // Calculate the new dimensions of the image
                    double scaledWidth = img.PixelWidth * scaleFactor;
                    double scaledHeight = img.PixelHeight * scaleFactor;

                    // Center the image on the page
                    double x = (page.Width - scaledWidth) / 2;
                    double y = (page.Height - scaledHeight) / 2;
                    common.ProgressBarLoading(10, progressBar1);
                    gfx.DrawImage(img, x, y, scaledWidth, scaledHeight);

                    document.Save(pdfPath);
                    common.ProgressBarLoading(60, progressBar1);
                }
                label5.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
        }

        /// <summary>
        /// Validates input data for the JPG to PDF conversion process.
        /// </summary>
        /// <returns><c>true</c> if all input data is valid; otherwise, <c>false</c>.</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(Path.Text))
            {
                MessageBox.Show("Please select an image file.");
                return false;
            }

            if (!checkBox1.Checked && string.IsNullOrEmpty(FolderPath.Text))
            {
                MessageBox.Show("Please select a folder.");
                return false;
            }

            return true;
        }
    }
}
