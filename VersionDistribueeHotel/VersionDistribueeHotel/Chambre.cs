using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VersionDistribueeHotel
{
    public class Chambre
    {
        private int identifiant;
        private int numero;
        private bool estLibre;
        private string dateDisponibilite;
        private float prixDeBase;
        private List<Reservation> historiqueReservations;
        private TypeChambre typeChambre;
        private Hotel hotel;

        public Chambre()
        {
            historiqueReservations = new List<Reservation>();
        }

        public Chambre(int identifiant, int numero, string dateDisponibilite,  float prixDeBase, bool estLibre, List<Reservation> historiqueReservations, TypeChambre typeChambre, Hotel hotel)
        {
            this.identifiant = identifiant;
            this.numero = numero;
            this.dateDisponibilite = dateDisponibilite;
            this.estLibre = estLibre;
            this.prixDeBase = prixDeBase;
            this.historiqueReservations = historiqueReservations;
            this.typeChambre = typeChambre;
            this.hotel = hotel;
        }
        public Chambre(int identifiant, int numero, Hotel hotel, string dateDisponibilite, TypeChambre typeChambre, float prixDeBase, bool estLibre)
        {
            this.identifiant = identifiant;
            this.numero = numero;
            this.dateDisponibilite = dateDisponibilite;
            this.estLibre = estLibre;
            this.prixDeBase = prixDeBase;
            this.typeChambre = typeChambre;
            this.hotel = hotel;
            historiqueReservations = new List<Reservation>();
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public int Numero { get => numero; set => numero = value; }
        public bool EstLibre { get => estLibre; set => estLibre = value; }
        public string DateDisponibilite { get => dateDisponibilite; set => dateDisponibilite = value; }
        public float PrixDeBase { get => prixDeBase; set => prixDeBase = value; }
        public List<Reservation> HistoriqueReservations { get => historiqueReservations; set => historiqueReservations = value; }
        public TypeChambre TypeChambre { get => typeChambre; set => typeChambre = value; }
        public Hotel Hotel { get => hotel; set => hotel = value; }

    }
}