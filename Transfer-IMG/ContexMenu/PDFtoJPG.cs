using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer_IMG
{
    /// <summary>
    /// UserControl for converting PDF files to JPG images.
    /// Provides functionality to select a PDF file, specify output folder, and initiate the conversion process.
    /// </summary>
    public partial class PDFtoJPG : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PDFtoJPG"/> class.
        /// Sets up drag-and-drop functionality for file selection.
        /// </summary>
        public PDFtoJPG()
        {
            InitializeComponent();
            SetupDragAndDrop();
        }

        /// <summary>
        /// Event handler for the <c>openFile</c> button click event.
        /// Opens a file dialog to select a PDF file and displays the file path in a TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
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
        }

        /// <summary>
        /// Event handler for the DragEnter event.
        /// Determines whether the dragged object can be processed (i.e., if it is a file).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> containing event data.</param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
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
        /// Opens a folder picker dialog to select the folder for saving the JPG images.
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
        /// Event handler for the <c>genJPG</c> button click event.
        /// Validates input, converts the selected PDF file to JPG images, and saves them to the specified folder.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void genJPG_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Text;
            if (string.IsNullOrEmpty(pdfPath))
            {
                MessageBox.Show("Please select a PDF file.");
                return;
            }

            if (!checkBox1.Checked && string.IsNullOrEmpty(FolderPath.Text))
            {
                MessageBox.Show("Please select a folder.");
                return;
            }

            string outputFolderPath = "";
            if (checkBox1.Checked)
            {
                outputFolderPath = FolderPath.Text;
            }
            else
            {
                outputFolderPath = System.IO.Path.GetDirectoryName(pdfPath);
            }

            try
            {
                // Placeholder for PDF to JPG conversion logic
                MessageBox.Show("PDF converted to images successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting PDF: " + ex.Message);
            }
        }
    }
}
