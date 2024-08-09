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
    /// <summary>
    /// UserControl for generating and displaying QR codes based on user input.
    /// Provides functionality to generate a QR code, insert special characters into the input text, and display the QR code in a PictureBox.
    /// </summary>
    public partial class QRcodes : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QRcodes"/> class.
        /// </summary>
        public QRcodes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the <c>GenQr</c> button click event.
        /// Opens a dialog to allow the user to download the generated QR code.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void GenQr_Click(object sender, EventArgs e)
        {
            // Create a new instance of the QRdownload class
            QRdownload QRdownloadPopup = new QRdownload((Bitmap)qrCodePictureBox.Image, textBox.Text);

            // Show the settings form
            QRdownloadPopup.ShowDialog();
        }

        /// <summary>
        /// Event handler for updating the QR code based on the input text in the TextBox.
        /// Generates a QR code with the specified text, replacing special sequences with corresponding characters.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void GenQr_Update(object sender, EventArgs e)
        {
            // Create an instance of QRCodeGenerator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Define replacement characters for special sequences
            var replacements = new Dictionary<string, char>
            {
                ["[GS]"] = (char)29,
                ["[RS]"] = (char)30,
                ["[CR]"] = (char)13,
                ["[LF]"] = (char)10,
                ["[EOT]"] = (char)4
            };

            // Original text
            string data = textBox.Text;

            // Replace special sequences in the text
            foreach (var replacement in replacements)
            {
                data = data.Replace(replacement.Key, replacement.Value.ToString());
            }

            // Generate QR code data
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            // Create QR code from the data
            QRCode qrCode = new QRCode(qrCodeData);

            // Generate QR code image
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Display QR code image in PictureBox
            qrCodePictureBox.Image = qrCodeImage;
        }

        /// <summary>
        /// Inserts the specified text at the current cursor position in the TextBox.
        /// </summary>
        /// <param name="textToInsert">The text to insert into the TextBox.</param>
        private void InsertTextAtCursor(string textToInsert)
        {
            int selectionIndex = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(selectionIndex, textToInsert);
            textBox.SelectionStart = selectionIndex + textToInsert.Length;
            textBox.Focus();
        }

        /// <summary>
        /// Event handler for the <c>btnInsertGS</c> button click event.
        /// Inserts the "[GS]" sequence into the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnInsertGS_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[GS]");
        }

        /// <summary>
        /// Event handler for the <c>btnInsertRS</c> button click event.
        /// Inserts the "[RS]" sequence into the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnInsertRS_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[RS]");
        }

        /// <summary>
        /// Event handler for the <c>btnInsertCR</c> button click event.
        /// Inserts the "[CR]" sequence into the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnInsertCR_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[CR]");
        }

        /// <summary>
        /// Event handler for the <c>btnInsertLF</c> button click event.
        /// Inserts the "[LF]" sequence into the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnInsertLF_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[LF]");
        }

        /// <summary>
        /// Event handler for the <c>btnInsertEOT</c> button click event.
        /// Inserts the "[EOT]" sequence into the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnInsertEOT_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[EOT]");
        }

        /// <summary>
        /// Event handler for the <c>bntinsertFirst</c> button click event.
        /// Inserts the "[)>" sequence at the cursor position in the TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void bntinsertFirst_Click(object sender, EventArgs e)
        {
            InsertTextAtCursor("[)>");
        }

        /// <summary>
        /// Event handler for the <c>textBox_TextChanged</c> event.
        /// Updates the QR code whenever the text in the TextBox changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            GenQr_Update(sender, e);
        }

        /// <summary>
        /// Event handler for the <c>btnClear</c> button click event.
        /// Clears the text in the TextBox and removes the QR code image from the PictureBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> containing event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            qrCodePictureBox.Image = null;
        }
    }
}
