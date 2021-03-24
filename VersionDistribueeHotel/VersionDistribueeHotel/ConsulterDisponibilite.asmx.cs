using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;

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

        [WebMethod]
        public List<Offre> chercherDisponibilite(String login, String mdp, String dateDebut, String dateFin, int nbPersonne)
        {
            List<Offre> listeOffres = new List<Offre>();
            Offre offre = new Offre("foobar", new TypeChambre(2), new DateTime().ToString(), 10253.63);
            Offre offre2 = new Offre("foobar2", new TypeChambre(1), new DateTime().ToString(), 10883.63);
            listeOffres.Add(offre);
            listeOffres.Add(offre2);
            return listeOffres;
        }

    }
}
