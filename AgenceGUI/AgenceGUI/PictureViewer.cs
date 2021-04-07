using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ((Form)this.TopLevelControl).Close();
        }
    }
}
