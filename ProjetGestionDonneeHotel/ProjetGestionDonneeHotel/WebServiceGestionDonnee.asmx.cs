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
            string pathDossierImages = @"C:\Users\DELL\source\repos\gestionhoteldistribueparagencedevoyage\ProjetGestionDonneeHotel\ProjetGestionDonneeHotel\assets\";
            monHotel = new Hotel(1, "Hotel1", 5, new Adresse(1, 12, "Rue Hotel 1", "France", "43.6°N, 3.9°E", "Lieu dit Hotel 1"));

            TypeChambre typeChambre1 = new TypeChambre(1);
            TypeChambre typeChambre2 = new TypeChambre(2);
            TypeChambre typeChambre3 = new TypeChambre(3);

            Chambre chambre1 = new Chambre(1, 1, "01/03/2021", typeChambre1, 42, true, pathDossierImages + "1_lit.png");
            Chambre chambre2 = new Chambre(2, 15, "10/03/2021", typeChambre1, 40, true, pathDossierImages + "1_lit.png");
            Chambre chambre3 = new Chambre(3, 12, "10/04/2021", typeChambre1, 30, true, pathDossierImages + "1_lit.png");

            Chambre chambre4 = new Chambre(4, 22, "02/03/2021", typeChambre2, 70, true, pathDossierImages + "2_lit.png");
            Chambre chambre5 = new Chambre(5, 25, "20/03/2021", typeChambre2, 65, true, pathDossierImages + "2_lit.png");
            Chambre chambre6 = new Chambre(6, 28, "02/04/2021", typeChambre2, 60, true, pathDossierImages + "2_lit.png");

            Chambre chambre7 = new Chambre(7, 32, "02/03/2021", typeChambre3, 100, true, pathDossierImages + "3_lit.png");
            Chambre chambre8 = new Chambre(8, 35, "18/03/2021", typeChambre3, 90, true, pathDossierImages + "3_lit.png");
            Chambre chambre9 = new Chambre(9, 38, "31/03/2021", typeChambre3, 85, true, pathDossierImages + "3_lit.png");



            monHotel.Chambres.Add(chambre1);
            monHotel.Chambres.Add(chambre2);
            monHotel.Chambres.Add(chambre3);
            monHotel.Chambres.Add(chambre4);
            monHotel.Chambres.Add(chambre5);
            monHotel.Chambres.Add(chambre6);
            monHotel.Chambres.Add(chambre7);
            monHotel.Chambres.Add(chambre8);
            monHotel.Chambres.Add(chambre9);

            agence1 = new Agence(1, "NomAgence1", "LoginAgence1", "123", 0.25, new Adresse(1, 25, "Rue Agence 1", "France", "43.6°N, 3.9°E", "Lieu dit Agence 1"));
            agence2 = new Agence(2, "NomAgence2", "LoginAgence2", "123", 0.2, new Adresse(2, 2, "Rue Agence 2", "France", "43.6°N, 3.9°E", "Lieu dit Agence 2"));
            agence3 = new Agence(3, "NomAgence3", "LoginAgence3", "123", 0.12, new Adresse(3, 13, "Rue Agence 3", "France", "43.6°N, 3.9°E", "Lieu dit Agence 3"));

            monHotel.Agences.Add(agence1);
            monHotel.Agences.Add(agence2);
            monHotel.Agences.Add(agence3);
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

                Reservation reservation = new Reservation("#"+idReservation, chambre, dateDebut, dateFin, nombrePersonnes, infoCarteCreditClient, client, agence);
                chambre.EstLibre = false;
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
