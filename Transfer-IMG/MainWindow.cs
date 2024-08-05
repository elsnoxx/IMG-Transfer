using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Transfer_IMG.ContexMenu;
using Transfer_IMG.General;

namespace Transfer_IMG
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();

            WT WT = new WT();

            WT.language = "1";


            LoadControl(new Home());
        }

        private void btnTransferIMG_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new IMGTransfer());
        }

        private void JPGtoPDF_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new JPGtoPDF());
        }

        private void PDFtoJPG_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new PDFtoJPG());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new Home());
        }

        private void QRcodes_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new QRcodes());
        }

        private void LoadControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userControl);
        }

        private void Highlight(object sender)
        {
            foreach (Control control in menuPanel.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = WT.colorDefault;
                }
            }

            // Highlight the clicked button
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.BackColor = WT.color;
            }
        }

        private void language_Click(object sender, EventArgs e)
        {
            if (language.Text == "CZ")
            {
                language.Text = "EN";
                WT.language = language.Text;
            }
            else
            {
                language.Text = "CZ";
                WT.language = language.Text;
            }
        }
    }
}
