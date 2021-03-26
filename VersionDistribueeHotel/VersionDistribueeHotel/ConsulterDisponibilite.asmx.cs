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

        private ServiceGestionDonnee.Hotel monHotel;
        private ServiceGestionDonnee.Agence monAgenceEnTraitement;
        
   

        ServiceGestionDonnee.WebServiceGestionDonnee webServiceGestionDonnee = new ServiceGestionDonnee.WebServiceGestionDonnee();

       
        [WebMethod]
        public List<Offre> chercherDisponibilite(String login, String mdp, String dateDebut, String dateFin, int nbPersonne)
        {
            bool connexionReussi = false;
            connexionReussi = verifierConnexionAgence(login, mdp);
            List<Offre> listeOffres = new List<Offre>();
            if (connexionReussi)
            {
                monHotel = webServiceGestionDonnee.getHotel();
                ServiceGestionDonnee.Chambre [] tabchambres= webServiceGestionDonnee.getChambresDisponible(dateDebut, nbPersonne);
                List<ServiceGestionDonnee.Chambre> chambresDisponible = tabchambres.ToList();
                listeOffres.AddRange(creerOffres(chambresDisponible));
            }
            return listeOffres;

        }

        public bool verifierConnexionAgence(string login, string mdp)
        {
            ServiceGestionDonnee.Agence [] tabAgences= webServiceGestionDonnee.getAgences();
            List<ServiceGestionDonnee.Agence> agences = new List<ServiceGestionDonnee.Agence>(tabAgences);
            foreach(ServiceGestionDonnee.Agence agence in agences)
            {
                if (login.Equals(agence.Login) && mdp.Equals(agence.MotDePAsse))
                {
                    this.monAgenceEnTraitement = agence;
                    return true;
                }
            }
            return false;
        }

        public  List <Offre> creerOffres(List <ServiceGestionDonnee.Chambre> chambres)
        {
            List<Offre> offres = new List<Offre>();
            Offre offre;
            double prix;
            foreach (ServiceGestionDonnee.Chambre chambre in chambres)
            {
                prix = chambre.PrixDeBase *(1- monAgenceEnTraitement.PourcentageReduction);
                offre = new Offre(monHotel.Identifiant + "_" + chambre.Numero, chambre.TypeChambre, chambre.DateDisponibilite, prix);
                offres.Add(offre);
            }
            return offres;
        }

        

    }
}
