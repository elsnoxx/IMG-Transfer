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
        }

        private void btnTransferIMG_Click(object sender, EventArgs e)
        {
            LoadControl(new IMGTransfer());
        }

        private void JPGtoPDF_Click(object sender, EventArgs e)
        {
            LoadControl(new JPGtoPDF());
        }

        private void PDFtoJPG_Click(object sender, EventArgs e)
        {
            LoadControl(new PDFtoJPG());
        }

        private void LoadControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userControl);
        }
    }
}
