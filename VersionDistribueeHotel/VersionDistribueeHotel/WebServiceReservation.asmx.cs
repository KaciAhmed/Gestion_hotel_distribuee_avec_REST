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
   
        
        public WebServiceReservation()
        {
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
