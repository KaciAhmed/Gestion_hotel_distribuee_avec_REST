using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace VersionDistribueeHotel
{
    /// <summary>
    /// Description résumée de WebServiceReservation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceReservation : System.Web.Services.WebService
    {
        ServiceGestionDonnee.WebServiceGestionDonnee webServiceGestionDonnee = new ServiceGestionDonnee.WebServiceGestionDonnee();
        [WebMethod]
        public string creerReservation(string LoginAgence, string mdp, string identifiantOffre,string dateDebut,string dateFin,int nombrePersonnes, string nomClient, string prenomClient, string infoCarteCreditClient)
        {
            ServiceGestionDonnee.Agence agence = verifierConnexionAgence(LoginAgence, mdp);
            if(agence == null)
            {
                return " PROBLEME : Erreur d'authentification de l'agence.";
            }
            else
            {
                string resultat = webServiceGestionDonnee.sauvegarderReservation(agence, identifiantOffre, dateDebut, dateFin, nombrePersonnes, nomClient, prenomClient, infoCarteCreditClient);
                return resultat;

            }
           
        }
        public ServiceGestionDonnee.Agence verifierConnexionAgence(string login, string mdp)
        {
            ServiceGestionDonnee.Agence[] tabAgences = webServiceGestionDonnee.getAgences();
            List<ServiceGestionDonnee.Agence> agences = new List<ServiceGestionDonnee.Agence>(tabAgences);
            foreach (ServiceGestionDonnee.Agence agence in agences)
            {
                if (login.Equals(agence.Login) && mdp.Equals(agence.MotDePAsse))
                {
                    return agence;
         
                }
            }
            return null;
        }
    }
}
