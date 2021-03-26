using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agence1
{
    class Program
    {
        readonly static int identifiant = 1;
        readonly static string LoginAgence = "LoginAgence1";
        readonly static string mdp = "123";

     
        static void Main(string[] args)
        {
            
            ReferenceServiceDisponibilte.ConsulterDisponibilite serviceDisponibiliteHotel = new ReferenceServiceDisponibilte.ConsulterDisponibilite();
      
            string dateArrivee;
            string dateDepart;
            int nombrePersonnes;

            dateArrivee = saisie("date d'arriver");
            dateDepart = saisie("date de depart");
            nombrePersonnes = int.Parse(saisie("nombre de personne a heberger entre 1 et 3 (refaite une reservation pour plus de personne)"));

            ReferenceServiceDisponibilte.Offre [] tabOffres = serviceDisponibiliteHotel.chercherDisponibilite(LoginAgence, mdp, dateArrivee, dateDepart, nombrePersonnes);
            List<ReferenceServiceDisponibilte.Offre> offres = new List<ReferenceServiceDisponibilte.Offre>(tabOffres);
            afficherOffres(offres);
            Console.ReadLine();
        }
        private static string saisie(string nomAfficher)
        {
            Console.WriteLine("Saisir " + nomAfficher + " ?");
            string res = Console.ReadLine();
            return res;
        }
        public static void afficherOffres(List<ReferenceServiceDisponibilte.Offre> offres)
        {
            foreach(ReferenceServiceDisponibilte.Offre offre in offres)
            {
                Console.WriteLine("identifiant Offre : " + offre.Identifiant + ", Date Disponibilté : " + offre.DateDisponibilite + ", Type Chambre (nombre de lits) :" + offre.TypeChambre.NbLits + ", Prix :" + offre.Prix);
            }
        }
    }
}
