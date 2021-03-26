using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Globalization;

namespace VersionDistribueeHotel
{
    /// <summary>
    /// Description résumée de ConsulterDisponibilite
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsulterDisponibilite : System.Web.Services.WebService
    {
        // instancier des agences 
        // proposer l'interface au client dans le dossier agence
        // faire l'appel au web service chercher disponibilité
        // recevoir les offre est l'afficher au client
        // envoyer l'offre choisis par client au web service 2
        // recevoir la réponse du second webService et l'afficher au client.

        private Hotel monHotel;
        private Agence monAgenceEnTraitement;
        Agence agence1;
        Agence agence2;
        Agence agence3;

        public ConsulterDisponibilite()
        {
            monHotel = new Hotel(1, "Hotel1", 5, new Adresse(1, 12, "Rue Hotel 1", "France", "43.6°N, 3.9°E", "Lieu dit Hotel 1"));

            TypeChambre typeChambre1 = new TypeChambre(1);
            TypeChambre typeChambre2 = new TypeChambre(2);
            TypeChambre typeChambre3 = new TypeChambre(3);

            Chambre chambre1 = new Chambre(1,1,monHotel,"01/03/2021", typeChambre1,42, true);
            Chambre chambre2 = new Chambre(2, 15, monHotel, "10/03/2021", typeChambre1, 40, true);
            Chambre chambre3 = new Chambre(3, 12, monHotel, "10/04/2021", typeChambre1, 30, true);

            Chambre chambre4 = new Chambre(4, 22, monHotel, "02/03/2021", typeChambre2, 70, true);
            Chambre chambre5 = new Chambre(5, 25, monHotel, "20/03/2021", typeChambre2, 65, true);
            Chambre chambre6 = new Chambre(6, 28, monHotel, "02/04/2021", typeChambre2, 60, true);

            Chambre chambre7 = new Chambre(7, 32, monHotel, "02/03/2021", typeChambre3, 100, true);
            Chambre chambre8 = new Chambre(8, 35, monHotel, "18/03/2021", typeChambre3, 90, true);
            Chambre chambre9 = new Chambre(9, 38, monHotel, "31/03/2021", typeChambre3, 85, true);

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
        public List<Offre> chercherDisponibilite(String login, String mdp, String dateDebut, String dateFin, int nbPersonne)
        {
            bool connexionReussi = false;
            connexionReussi = verifierConnexionAgence(login, mdp);
            List<Offre> listeOffres = new List<Offre>();
            if (connexionReussi)
            {
                List<Chambre> chambresDisponible = monHotel.getChambresDisponible(dateDebut, nbPersonne);
                listeOffres.AddRange(creerOffres(chambresDisponible));
            }
            return listeOffres;

        }

        public bool verifierConnexionAgence(string login, string mdp)
        {

            if (login.Equals("LoginAgence1") && mdp.Equals("123"))
            {
                this.monAgenceEnTraitement = this.agence1;
            }
            else if (login.Equals("LoginAgence2") && mdp.Equals("123"))
            {
                this.monAgenceEnTraitement = this.agence2;
            }
            else if (login.Equals("LoginAgence3") && mdp.Equals("123"))
            {
                this.monAgenceEnTraitement = this.agence3;
            }
            else
            {
                return false;
            }
            return true;
        }

        public  List <Offre> creerOffres(List <Chambre> chambres)
        {
            List<Offre> offres = new List<Offre>();
            Offre offre;
            double prix;
            foreach (Chambre chambre in chambres)
            {
                prix = chambre.PrixDeBase *(1- monAgenceEnTraitement.PourcentageReduction);
                offre = new Offre(monHotel.Identifiant + " - " + chambre.Numero, chambre.TypeChambre, chambre.DateDisponibilite, prix);
                offres.Add(offre);
            }
            return offres;
        }

        

    }
}
