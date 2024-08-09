using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfer_IMG.General;

namespace Transfer_IMG
{
    /// <summary>
    /// UserControl for transferring and compressing images.
    /// Provides functionality to select, compress, and save images in different formats.
    /// </summary>
    public partial class IMGTransfer : UserControl
    {
        private Common common;

        /// <summary>
        /// Initializes a new instance of the <see cref="IMGTransfer"/> class.
        /// Sets up default values for ComboBoxes and enables drag-and-drop functionality.
        /// </summary>
        public IMGTransfer()
        {
            InitializeComponent();
            common = new Common();
            // Set default values for ComboBoxes
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            // Enable drag and drop on the form
            SetupDragAndDrop();
        }

        /// <summary>
        /// Event handler for the <c>openFile</c> button click event.
        /// Opens a file dialog to select an image file and displays the file path in a TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
                    // Display the selected file path in TextBox
                    string selectedFileName = openFileDialog.FileName;
                    Path.Text = selectedFileName;
                }
            }
            label5.Visible = false;
        }

        /// <summary>
        /// Event handler for the DragEnter event.
        /// Determines whether the dragged object can be processed (i.e., if it is a file).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> containing event data.</param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
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
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length > 0)
                {
                    string filePath = files[0];
                    Path.Text = filePath;
                }
            }
            label5.Visible = false;
        }

        /// <summary>
        /// Event handler for the <c>transfer</c> button click event.
        /// Validates input, compresses the image, and saves it in the specified format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void transfer_Click(object sender, EventArgs e)
        {
            // Validate input data
            if (!ValidateInput())
            {
                return;
            }

            label5.Visible = false;
            progressBar1.Visible = true;
            progressBar1.Value = 10;

            try
            {
                // Get output format and quality
                string outputFormat = comboBox1.SelectedItem.ToString().ToLower();
                byte quality = byte.Parse(comboBox2.Text);

                // Load image
                Bitmap originalImage = new Bitmap(Path.Text);
                common.ProgressBarLoading(10, progressBar1);

                // Compress image
                MemoryStream memoryStream = CompressImage(originalImage, quality);
                common.ProgressBarLoading(10, progressBar1);

                // Get output file path
                string outputFilePath = GetOutputFilePath(outputFormat);
                common.ProgressBarLoading(10, progressBar1);

                // Save compressed image
                SaveCompressedImage(memoryStream, outputFilePath);
                common.ProgressBarLoading(70, progressBar1);
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show("Nastala chyba při převodu: " + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                label5.Visible = true;
            }
        }

        /// <summary>
        /// Validates input data for the image transfer process.
        /// </summary>
        /// <returns><c>true</c> if all input data is valid; otherwise, <c>false</c>.</returns>
        private bool ValidateInput()
        {
            if (System.IO.Path.GetExtension(Path.Text).Equals("." + comboBox1.Text, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Vybrali jste stejný formát jako je již v obrázku. Vyberte prosím jiný formát.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Path.Text))
            {
                MessageBox.Show("Vyberte soubor k převodu.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(FolderPath.Text) && !checkBox1.Checked)
            {
                MessageBox.Show("Vyberte složku kam chcete soubor uložit.");
                return false;
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Vyberte formát pro uložení.");
                return false;
            }

            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Vyberte kvalitu pro uložení.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compresses the given image with the specified quality.
        /// </summary>
        /// <param name="originalImage">The image to compress.</param>
        /// <param name="quality">The quality of the compressed image (0-100).</param>
        /// <returns>A <see cref="MemoryStream"/> containing the compressed image data.</returns>
        private MemoryStream CompressImage(Bitmap originalImage, byte quality)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Setup encoder parameters
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                // Get the JPEG codec
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Save the image with the specified quality
                originalImage.Save(memoryStream, jpgEncoder, encoderParameters);

                return new MemoryStream(memoryStream.ToArray()); // Return a new memory stream with the image data
            }
        }

        /// <summary>
        /// Gets the path for the output file based on the selected format and folder.
        /// </summary>
        /// <param name="outputFormat">The format to save the image in.</param>
        /// <returns>The path for the output file.</returns>
        private string GetOutputFilePath(string outputFormat)
        {
            string directory = checkBox1.Checked ? System.IO.Path.GetDirectoryName(Path.Text) : FolderPath.Text;
            return System.IO.Path.Combine(directory, System.IO.Path.GetFileNameWithoutExtension(Path.Text) + "." + outputFormat);
        }

        /// <summary>
        /// Saves the compressed image data to a file.
        /// </summary>
        /// <param name="memoryStream">The <see cref="MemoryStream"/> containing the compressed image data.</param>
        /// <param name="outputPath">The path where the image should be saved.</param>
        private void SaveCompressedImage(MemoryStream memoryStream, string outputPath)
        {
            File.WriteAllBytes(outputPath, memoryStream.ToArray());
        }

        /// <summary>
        /// Gets the image codec info for the specified image format.
        /// </summary>
        /// <param name="format">The <see cref="ImageFormat"/> for which to get the codec info.</param>
        /// <returns>The <see cref="ImageCodecInfo"/> for the specified format.</returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return Array.Find(ImageCodecInfo.GetImageDecoders(), codec => codec.FormatID == format.Guid);
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
        /// Opens a folder picker dialog to select the folder for saving the image.
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
    }
}
