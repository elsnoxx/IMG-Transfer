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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void LoadControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userControl);
        }

        private void Highlight(object sender)
        {
            // Reset color of all buttons
            btnTransferIMG.BackColor = SystemColors.InactiveBorder;
            JPGtoPDF.BackColor = SystemColors.InactiveBorder;
            PDFtoJPG.BackColor = SystemColors.InactiveBorder;
            btnHome.BackColor = SystemColors.InactiveBorder;

            // Highlight the clicked button
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.BackColor = Color.Bisque;
            }
        }

    }
}
