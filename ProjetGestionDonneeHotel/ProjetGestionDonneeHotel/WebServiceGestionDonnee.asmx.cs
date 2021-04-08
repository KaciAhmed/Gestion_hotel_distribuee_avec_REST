using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Services;

namespace ProjetGestionDonneeHotel
{
    /// <summary>
    /// Description résumée de WebServiceGestionDonnee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGestionDonnee : System.Web.Services.WebService
    {
        private Hotel monHotel;
        private Agence agence1;
        private Agence agence2;
        private Agence agence3;
        public WebServiceGestionDonnee()
        {
            Database.OpenConnection();
            monHotel = Database.getHotel();
            agence1 = monHotel.Agences[0];
            agence2 = monHotel.Agences[1];
            agence3 = monHotel.Agences[2];
        }
        [WebMethod]
        public List<Agence> getAgences()
        {
            return monHotel.Agences;
        }
        [WebMethod]
        public Hotel getHotel()
        {
            return monHotel;
        }
        [WebMethod]
        public List<Chambre> getChambresDisponible(String dateDebut, int nbPersonne)
        {
            DateTime dateDebutTemp = DateTime.ParseExact(dateDebut, "dd/MM/yyyy", new CultureInfo("fr-FR", false));
            DateTime dateDisponibilte;
            List<Chambre> chambres = new List<Chambre>();
            foreach (Chambre chambre in monHotel.Chambres)
            {
                dateDisponibilte = DateTime.ParseExact(chambre.DateDisponibilite, "dd/MM/yyyy", new CultureInfo("fr-FR", false));
                if (DateTime.Compare(dateDisponibilte, dateDebutTemp) <= 0 && chambre.TypeChambre.NbLits == nbPersonne && chambre.EstLibre)
                {
                    chambres.Add(chambre);
                }
            }
            return chambres;
        }
        public int RandomNumber(int min, int max)
        {
            Random _random = new Random();
            return _random.Next(min, max);
        }
        [WebMethod]
        public string sauvegarderReservation(Agence agence, string identifiantOffre, String dateDebut, String dateFin, int nombrePersonnes, string nomClient, string prenomClient, string infoCarteCreditClient)
        {
            Client client = creerClient(nomClient, prenomClient);
            Chambre chambre = getChambre(identifiantOffre);
            int idReservation = RandomNumber(1000, 9999);
            if (chambre == null)
            {
                return "PROBLEME : Erreur chambre invalide";
            }
            else
            {
                Reservation reservation = new Reservation("#" + idReservation, chambre, dateDebut, dateFin, nombrePersonnes, infoCarteCreditClient, client, agence);
                chambre.EstLibre = false;
                chambre.DateDisponibilite = dateFin;
                Database.updateStatusChambre(chambre);
                return reservation.Reference;
            }
        }
        public Client creerClient(string nomClient, string prenomClient)
        {
            return new Client(nomClient, prenomClient);
        }
        public Chambre getChambre(string identifiantOffre)
        {
            string[] idHotelEtNumChambre = identifiantOffre.Split('_');
            int numChambre = int.Parse(idHotelEtNumChambre[1]);
            foreach (Chambre chambre in monHotel.Chambres)
            {
                if (chambre.Numero == numChambre)
                {
                    return chambre;
                }
            }
            return null;
        }
    }
}
