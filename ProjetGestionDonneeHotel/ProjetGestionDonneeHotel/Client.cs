using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetGestionDonneeHotel
{
    public class Client
    {
        private int identifiant;
        private string nom;
        private string prenom;
       // private List<Reservation> historiqueReservations;

        public Client()
        {
         //   historiqueReservations = new List<Reservation>();
        }

        public Client(int identifiant, string nom, string prenom, List<Reservation> historiqueReservations)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.prenom = prenom;
         //   this.historiqueReservations = historiqueReservations;
        }
        public Client(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
          //  historiqueReservations = new List<Reservation>();
        }
        public int Identifiant { get => identifiant; set => identifiant = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
     //   public List<Reservation> HistoriqueReservations { get => historiqueReservations; set => historiqueReservations = value; }
    }
}