using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgenceGUI
{
    public partial class PictureViewer : Form
    {
        public Image image;
        public PictureViewer()
        {
            InitializeComponent();
        }

        public PictureViewer(Image image)
        {
            InitializeComponent();
            pictureBoxChambre.Image = image;
        }

        private void pictureBoxChambre_Click(object sender, EventArgs e)
        {
            ((Form)TopLevelControl).Close();
        }
    }
}
