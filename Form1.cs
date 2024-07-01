using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace IMGTransefere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Nastavení vlastností vyberu checkBox1
            checkBox1.Checked = true;

            // Nastavení vlastností vyberu comboBox1
            comboBox1.Items.Add("JPG");
            comboBox1.Items.Add("PNG");
            comboBox1.Items.Add("JPEG");
            comboBox1.SelectedIndex = 0;

            // Nastavení vlastností vyberu comboBox2
            comboBox2.Items.Add("100");
            comboBox2.Items.Add("80");
            comboBox2.Items.Add("75");
            comboBox2.Items.Add("50");
            comboBox2.Items.Add("25");
            comboBox2.SelectedIndex = 0;

            // Nastavení vlastností ProgressBar
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Visible = true;


            FolderPath.Visible = false;
            Choose.Visible = false;

            // Příklad načtení a nastavení obrázku z disku
            logo.Image = Image.FromFile("logoSmall1.png");


        }

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
                    // Například vypište cestu k souboru do konzole

                    Path.Text = selectedFileName;
                }
            }
        }

        private void imgTransfer_Click(object sender, EventArgs e)
        {
            if (System.IO.Path.GetExtension(Path.Text).Equals("." + comboBox1.Text, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Vybrali jste stejný formát jako je již v obrázku. Vyberte prosím jiný formát.");
                return;
            }

            if (Path.Text == "")
            {
                MessageBox.Show("Vyberte soubor k převodu.");
                return;
            }
            if (FolderPath.Text == "" && !checkBox1.Checked)
            {
                MessageBox.Show("Vyberte složku kam chcete soubor uložit.");
                return;
            }

            progressBar.Visible = true;
            string vybranaPolozka = comboBox1.SelectedItem.ToString();

            progressBar.Value += 10;

            // Načtení obrázku
            Bitmap originalImage = new Bitmap(Path.Text);
            progressBar.Value += 10;

            // Komprimace obrázku
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, long.Parse(comboBox2.Text));
            progressBar.Value += 10;

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            MemoryStream memoryStream = new MemoryStream();

            originalImage.Save(memoryStream, jpgEncoder, encoderParameters);
            progressBar.Value += 10;

            string compressedImagePath = "";
            // Nový název pro komprimovaný obrázek
            if (checkBox1.Checked)
            {
                compressedImagePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(Path.Text) + "." + comboBox1.Text.ToLower());
                progressBar.Value += 10;
            }
            else
            {
                compressedImagePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(FolderPath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(Path.Text) + "." + comboBox1.Text.ToLower());
                progressBar.Value += 10;
            }




            // Uložení komprimovaného obrázku do výstupní složky
            File.WriteAllBytes(compressedImagePath, memoryStream.ToArray());
            for (int i = 0; i <= 40; i++)
            {
                progressBar.Value++;
            }


            progressBar.Visible = false;
            progressBar.Value = 0;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Choose.Visible == true)
            {
                FolderPath.Visible = false;
                Choose.Visible = false;
            }
            else
            {
                FolderPath.Visible = true;
                Choose.Visible = true;
            }
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Vyberte složku";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Získání vybrané složky
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Nastavení cesty složky do FolderPath.Text
                    FolderPath.Text = selectedFolderPath;
                }
            }
        }
    }
}
