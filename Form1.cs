using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace IMGTransefere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Nastavení výchozích hodnot pro ComboBoxy
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            // Povolí drag and drop na formuláři
            SetupDragAndDrop();
        }

        // Handler pro tlačítko výběru souboru
        private void button1_Click(object sender, EventArgs e)
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

        // Metoda pro aktualizaci progress baru
        private void ProgressBar(int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (progressBar.Value == 100)
                {
                    break;
                }
                progressBar.Value += 1;
                Thread.Sleep(20); // Pauza pro simulaci práce
            }
        }

        // Handler pro tlačítko pro převod obrázku
        private void imgTransfer_Click(object sender, EventArgs e)
        {
            // Validace vstupních údajů
            if (!ValidateInput())
            {
                return;
            }

            progressBar.Visible = true;
            progressBar.Value = 10;

            try
            {
                // Získání výstupního formátu a kvality
                string outputFormat = comboBox1.SelectedItem.ToString().ToLower();
                long quality = long.Parse(comboBox2.Text);

                // Načtení obrázku
                Bitmap originalImage = new Bitmap(Path.Text);
                ProgressBar(10);

                // Komprimace obrázku
                MemoryStream memoryStream = CompressImage(originalImage, quality);
                ProgressBar(10);

                // Získání cesty k výstupnímu souboru
                string outputFilePath = GetOutputFilePath(outputFormat);
                ProgressBar(10);

                // Uložení komprimovaného obrázku
                SaveCompressedImage(memoryStream, outputFilePath);
                ProgressBar(70);
            }
            catch (Exception ex)
            {
                // Zobrazení chybové zprávy
                MessageBox.Show("Nastala chyba při převodu: " + ex.Message);
            }
            finally
            {
                progressBar.Visible = false;
                progressBar.Value = 0;
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
        private MemoryStream CompressImage(Bitmap originalImage, long quality)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            MemoryStream memoryStream = new MemoryStream();

            originalImage.Save(memoryStream, jpgEncoder, encoderParameters);
            return memoryStream;
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
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Vyberte složku";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    FolderPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
