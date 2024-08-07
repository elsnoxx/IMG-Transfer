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
    public partial class IMGTransfer : UserControl
    {
        private Common common;

        public IMGTransfer()
        {
            InitializeComponent();
            common = new Common();
            // Nastavení výchozích hodnot pro ComboBoxy
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            // Povolí drag and drop na formuláři
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
            label5.Visible = false;
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
            label5.Visible = false;
        }

        // Handler pro tlačítko pro převod obrázku
        private void transfer_Click(object sender, EventArgs e)
        {
            // Validace vstupních údajů
            if (!ValidateInput())
            {
                return;
            }

            label5.Visible = false;
            progressBar1.Visible = true;
            progressBar1.Value = 10;

            try
            {
                // Získání výstupního formátu a kvality
                string outputFormat = comboBox1.SelectedItem.ToString().ToLower();
                byte quality = byte.Parse(comboBox2.Text);

                // Načtení obrázku
                Bitmap originalImage = new Bitmap(Path.Text);
                common.ProgressBarLoading(10, progressBar1);

                

                // Komprimace obrázku
                MemoryStream memoryStream = CompressImage(originalImage, quality);
                common.ProgressBarLoading(10, progressBar1);

                // Získání cesty k výstupnímu souboru
                string outputFilePath = GetOutputFilePath(outputFormat);
                common.ProgressBarLoading(10, progressBar1);

                // Uložení komprimovaného obrázku
                SaveCompressedImage(memoryStream, outputFilePath);
                common.ProgressBarLoading(70, progressBar1);

            }
            catch (Exception ex)
            {
                // Zobrazení chybové zprávy
                MessageBox.Show("Nastala chyba při převodu: " + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                label5.Visible = true;
            }
        }

        // Metoda pro validaci vstupních údajů
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

        // Metoda pro kompresi obrázku
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

        // Metoda pro získání cesty k výstupnímu souboru
        private string GetOutputFilePath(string outputFormat)
        {
            string directory = checkBox1.Checked ? System.IO.Path.GetDirectoryName(Path.Text) : FolderPath.Text;
            return System.IO.Path.Combine(directory, System.IO.Path.GetFileNameWithoutExtension(Path.Text) + "." + outputFormat);
        }

        // Metoda pro uložení komprimovaného obrázku
        private void SaveCompressedImage(MemoryStream memoryStream, string outputPath)
        {
            File.WriteAllBytes(outputPath, memoryStream.ToArray());
        }

        // Metoda pro získání encoderu pro daný formát
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return Array.Find(ImageCodecInfo.GetImageDecoders(), codec => codec.FormatID == format.Guid);
        }

        // Handler pro změnu stavu checkBoxu - zobrazení/skrytí výběru složky
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FolderPath.Visible = Choose.Visible = !checkBox1.Checked;
        }

        // Handler pro tlačítko výběru složky
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
