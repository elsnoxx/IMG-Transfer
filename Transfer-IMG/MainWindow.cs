using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Transfer_IMG.ContexMenu;
using Transfer_IMG.General;
using Transfer_IMG.Popup;

namespace Transfer_IMG
{
    /// <summary>
    /// Represents the main window of the application, providing navigation and control loading features.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets the initial language and loads the home control.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WT WT = new WT();

            WT.language = "1";

            LoadControl(new Home());
        }

        /// <summary>
        /// Event handler for the <c>btnTransferIMG</c> button click event.
        /// Highlights the clicked button and loads the <see cref="IMGTransfer"/> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void btnTransferIMG_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new IMGTransfer());
        }

        /// <summary>
        /// Event handler for the <c>JPGtoPDF</c> button click event.
        /// Highlights the clicked button and loads the <see cref="JPGtoPDF"/> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void JPGtoPDF_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new JPGtoPDF());
        }

        /// <summary>
        /// Event handler for the <c>PDFtoJPG</c> button click event.
        /// Highlights the clicked button and loads the <see cref="PDFtoJPG"/> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void PDFtoJPG_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new PDFtoJPG());
        }

        /// <summary>
        /// Event handler for the <c>btnHome</c> button click event.
        /// Highlights the clicked button and loads the <see cref="Home"/> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new Home());
        }

        /// <summary>
        /// Event handler for the <c>QRcodes</c> button click event.
        /// Highlights the clicked button and loads the <see cref="QRcodes"/> control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void QRcodes_Click(object sender, EventArgs e)
        {
            Highlight(sender);
            LoadControl(new QRcodes());
        }

        /// <summary>
        /// Loads the specified <see cref="UserControl"/> into the main panel.
        /// Clears any existing controls and sets the new control to fill the panel.
        /// </summary>
        /// <param name="userControl">The user control to be loaded.</param>
        private void LoadControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userControl);
        }

        /// <summary>
        /// Highlights the clicked button by changing its background color.
        /// Resets the background color of all other buttons to the default color.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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

        /// <summary>
        /// Toggles the language between Czech (CZ) and English (EN).
        /// Updates the language property and the display text of the language button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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

        /// <summary>
        /// Displays an <see cref="AboutBox"/> dialog showing information about the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void about_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
