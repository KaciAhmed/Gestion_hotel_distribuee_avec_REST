using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgenceGUI
{
    public partial class AgenceGraphique : Form
    {
        public string dateArriver = "18/06/2021";
        public string dateDepart = "19/06/2021";
        public int nombrePersonne = 1;
        public string nom = "La victime";
        public string prenom = "Jon";
        public string creditCardNumber = "4556816546446609";
        private ReferenceServiceDisponibilte.Offre[] tabOffres;
        private List<ReferenceServiceDisponibilte.Offre> offres;
        private readonly static string LoginAgence = "LoginAgence1";
        private readonly static string mdp = "123";
        private static ReferenceServiceDisponibilte.ConsulterDisponibilite serviceDisponibiliteHotel = new ReferenceServiceDisponibilte.ConsulterDisponibilite();
        private static ReferenceServiceReservation.WebServiceReservation serviceReservation = new ReferenceServiceReservation.WebServiceReservation();
        private static int idOffreCourante = 0;
        public AgenceGraphique()
        {
            InitializeComponent();
        }
        private void panelNbPersonne_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonSearchFillProfil1_Click(object sender, EventArgs e)
        {
            dateTimePickerArriver.Value = new DateTime(2021, 06, 18);
            dateTimePickerDepart.Value = new DateTime(2021, 06, 19);
            radioButtonNb1.Checked = true;
        }
        private void buttonSearchFillProfil2_Click(object sender, EventArgs e)
        {
            dateTimePickerArriver.Value = new DateTime(2021, 06, 22);
            dateTimePickerDepart.Value = new DateTime(2021, 06, 29);
            radioButtonNb2.Checked = true;
        }
        private void buttonSearchFillProfil3_Click(object sender, EventArgs e)
        {
            dateTimePickerArriver.Value = new DateTime(2021, 06, 28);
            dateTimePickerDepart.Value = new DateTime(2021, 06, 29);
            radioButtonNb3.Checked = true;
        }

        private void buttonResetSaisieRecherche_Click(object sender, EventArgs e)
        {
            dateTimePickerArriver.Value = DateTime.Today;
            dateTimePickerDepart.Value = DateTime.Today;
            radioButtonNb1.Checked = false;
            radioButtonNb2.Checked = false;
            radioButtonNb3.Checked = false;
        }
        private void buttonClientFillProfil1_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "Kaci";
            textBoxLastName.Text = "Yanis";
            textBoxCreditCardNumber.Text = "4556517655594573";
            dateTimePickerCreditCard.Value = new DateTime(2023, 12, 01);
            textBoxCreditCardCVV.Text = "269";
        }
        private void buttonClientFillProfil2_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "Allouch";
            textBoxLastName.Text = "Ahmed";
            textBoxCreditCardNumber.Text = "4532182908400661";
            dateTimePickerCreditCard.Value = new DateTime(2021, 08, 01);
            textBoxCreditCardCVV.Text = "574";
        }
        private void buttonResetDetails_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxCreditCardNumber.Text = "";
            dateTimePickerCreditCard.Value = DateTime.Today;
            textBoxCreditCardCVV.Text = "";
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dateArriver = dateTimePickerArriver.Value.Date.ToString("dd/MM/yyyy");
            dateDepart = dateTimePickerDepart.Value.Date.ToString("dd/MM/yyyy");
            if (radioButtonNb3.Checked)
            {
                nombrePersonne = 3;
            }
            else if (radioButtonNb2.Checked)
            {
                nombrePersonne = 2;
            }
            else
            {
                nombrePersonne = 1;
            }
            prenom = textBoxName.Text.ToString();
            nom = textBoxLastName.Text.ToString();
            creditCardNumber = textBoxCreditCardNumber.Text.ToString();
            tabControlMain.SelectedIndex = 1;
            try
            {
                tabOffres = serviceDisponibiliteHotel.chercherDisponibilite(LoginAgence, mdp, dateArriver, dateDepart, nombrePersonne);
            }
            catch
            {
                tabOffres = new ReferenceServiceDisponibilte.Offre[0];
            }
            
            offres = new List<ReferenceServiceDisponibilte.Offre>(tabOffres);

            idOffreCourante = offres.Count - 1;

            afficherOffre(offres, idOffreCourante);
            tabPageReserver.UseWaitCursor = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void afficherOffre(List<ReferenceServiceDisponibilte.Offre> offres, int id)
        {
            Image image;
            if (id < 0 || id >= offres.Count)
            {
                labelPrice.Text = "0 €";
                label1OfferID.Text = "0_0";
                pictureBoxChambre.SizeMode = PictureBoxSizeMode.StretchImage;
                image = Image.FromFile(@"./assets/404.png");
            }
            else
            {
                labelPrice.Text = offres[id].Prix.ToString() + " €";
                label1OfferID.Text = offres[id].Identifiant.ToString();
                pictureBoxChambre.SizeMode = PictureBoxSizeMode.StretchImage;
                image = byteArrayToImage(offres[id].Image);
            }
            pictureBoxChambre.Image = image;
            pictureBoxChambre.UseWaitCursor = false;
            pictureBoxChambre.Cursor = Cursors.Hand;
        }
        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private static void afficherResultatReservation(String resultat)
        {
            MessageBox.Show("Réservation " + resultat);
        }
        public static ReferenceServiceDisponibilte.Offre getOffre(String id, List<ReferenceServiceDisponibilte.Offre> offres)
        {
            foreach (ReferenceServiceDisponibilte.Offre offre in offres)
            {
                if (offre.Identifiant.Equals(id))
                {
                    return offre;
                }
            }
            return null;
        }
        public static string effectuerReservation(string LoginAgence, string mdp, string identifiantOffre, String dateDebut, String dateFin, int nombrePersonnes, string nomClient, string prenomClient, string infoCarteCreditClient)
        {
            return serviceReservation.creerReservation(LoginAgence, mdp, identifiantOffre, dateDebut, dateFin, nombrePersonnes, nomClient, prenomClient, infoCarteCreditClient);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void pictureBoxChambre_Click(object sender, EventArgs e)
        {
            if (pictureBoxChambre != null && pictureBoxChambre.Image != null)
            {
                PictureViewer pictureViewer = new PictureViewer(pictureBoxChambre.Image);
                pictureViewer.ShowDialog();
            }

        }
        private void buttonFlecheGauche_Click(object sender, EventArgs e)
        {
            idOffreCourante--;
            idOffreCourante = idOffreCourante % offres.Count;
            afficherOffre(offres, idOffreCourante);
        }

        private void buttonFlecheDroite_Click(object sender, EventArgs e)
        {
            idOffreCourante++;
            idOffreCourante = idOffreCourante % offres.Count;
            afficherOffre(offres, idOffreCourante);
        }

        private void buttonReserver_Click(object sender, EventArgs e)
        {
            string res = "";
            try
            {
                res = effectuerReservation(LoginAgence, mdp, offres[idOffreCourante].Identifiant, dateDepart, dateArriver, nombrePersonne, textBoxName.Text, textBoxLastName.Text, textBoxCreditCardNumber.Text);
            }catch
            {
                res = "not happenning ;-)";
            }
            
            afficherResultatReservation(res);
        }
    }
}
