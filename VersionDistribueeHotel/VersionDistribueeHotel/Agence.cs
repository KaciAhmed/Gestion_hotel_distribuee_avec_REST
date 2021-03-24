using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VersionDistribueeHotel
{
    public class Agence
    {
        private int identifiant;
        private string nom;
        private string login;
        private string motDePAsse;
        private string pourcentageReduction;
        private Adresse adresse;
        private List<Hotel> hotels;
        private List<Reservation> historiqueReservations;
        private List<Client> clients;
        public Agence()
        {
            hotels = new List<Hotel>();
            historiqueReservations = new List<Reservation>();
            clients = new List<Client>();
        }

        public Agence(int identifiant, string nom, string login, string motDePAsse, string pourcentageReduction, Adresse adresse, List<Hotel> hotels, List<Reservation> historiqueReservations, List<Client> clients)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.login = login;
            this.motDePAsse = motDePAsse;
            this.pourcentageReduction = pourcentageReduction;
            this.adresse = adresse;
            this.hotels = hotels;
            this.historiqueReservations = historiqueReservations;
            this.clients = clients;
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Login { get => login; set => login = value; }
        public string MotDePAsse { get => motDePAsse; set => motDePAsse = value; }
        public string PourcentageReduction { get => pourcentageReduction; set => pourcentageReduction = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }
        public List<Hotel> Hotels { get => hotels; set => hotels = value; }
        public List<Reservation> HistoriqueReservations { get => historiqueReservations; set => historiqueReservations = value; }
        public List<Client> Clients { get => clients; set => clients = value; }


    }
}