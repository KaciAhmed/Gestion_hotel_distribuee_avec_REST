using System;
using System.Collections.Generic;


namespace Agence1
{
    internal class Program
    {

        private readonly static string LoginAgence = "LoginAgence1";
        private readonly static string mdp = "123";
        private static ReferenceServiceDisponibilte.ConsulterDisponibilite serviceDisponibiliteHotel = new ReferenceServiceDisponibilte.ConsulterDisponibilite();
        private static ReferenceServiceReservation.WebServiceReservation serviceReservation = new ReferenceServiceReservation.WebServiceReservation();

        private static void Main(string[] args)
        {
            string dateArrivee;
            string dateDepart;
            int nombrePersonnes;
            string choix = "-1";
            ReferenceServiceDisponibilte.Offre offre;
            string nomClient;
            string prenomClient;
            string infoCarteCreditClient;
            ReferenceServiceDisponibilte.Offre[] tabOffres;
            List<ReferenceServiceDisponibilte.Offre> offres;
            String resultatReservation;

            do
            {
                dateArrivee = saisie("date d'arriver");
                dateDepart = saisie("date de depart");
                nombrePersonnes = int.Parse(saisie("nombre de personne a heberger entre 1 et 3 (refaite une reservation pour plus de personne)"));

                tabOffres = serviceDisponibiliteHotel.chercherDisponibilite(LoginAgence, mdp, dateArrivee, dateDepart, nombrePersonnes);
                offres = new List<ReferenceServiceDisponibilte.Offre>(tabOffres);
                afficherOffres(offres);

                choix = saisie("voulez vous continuer (1 = oui / -1 = non)");
                if (!choix.Equals(-1))
                {
                    nomClient = saisie("votre nom");
                    prenomClient = saisie("votre prénom");
                    infoCarteCreditClient = saisie("les informations de votre carte de crédit");
                    do
                    {
                        Console.WriteLine("Veillez sélectionner l'identifiant de l'offre que vous souhaitter, SVP (pour quitter tapez -1)");
                        choix = saisie("identifiant de l'offre");
                        offre = getOffre(choix, offres);
                    } while (offre == null);

                    resultatReservation = effectuerReservation(LoginAgence, mdp, offre.Identifiant, dateArrivee, dateDepart, nombrePersonnes, nomClient, prenomClient, infoCarteCreditClient);
                    Console.WriteLine(resultatReservation);

                    choix = saisie("voulez effectuer une autre réservation (1 = oui / -1 = non)");
                }
            } while (!choix.Equals("-1"));

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
            foreach (ReferenceServiceDisponibilte.Offre offre in offres)
            {
                Console.WriteLine("identifiant Offre : " + offre.Identifiant + ", Date Disponibilté : " + offre.DateDisponibilite + ", Type Chambre (nombre de lits) :" + offre.TypeChambre.NbLits + ", Prix :" + offre.Prix);
            }
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

    }
}
