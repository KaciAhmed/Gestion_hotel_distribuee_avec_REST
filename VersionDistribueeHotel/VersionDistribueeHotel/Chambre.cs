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
        private Boolean estLibre;
        private string dateDisponibilite;
        private float prixDeBase;
        private List<Reservation> historiqueReservations;
        private TypeChambre typeChambre;
        private Hotel hotel;

        public Chambre()
        {
            historiqueReservations = new List<Reservation>();
        }

        public Chambre(int identifiant, int numero, bool estLibre, string dateDisponibilite, float prixDeBase, List<Reservation> historiqueReservations, TypeChambre typeChambre, Hotel hotel)
        {
            this.identifiant = identifiant;
            this.numero = numero;
            this.estLibre = estLibre;
            this.dateDisponibilite = dateDisponibilite;
            this.prixDeBase = prixDeBase;
            this.historiqueReservations = historiqueReservations;
            this.typeChambre = typeChambre;
            this.hotel = hotel;
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public int Numero { get => numero; set => numero = value; }
        public Boolean EstLibre { get => estLibre; set => estLibre = value; }
        public string DateDisponibilite { get => dateDisponibilite; set => dateDisponibilite = value; }
        public float PrixDeBase { get => prixDeBase; set => prixDeBase = value; }
        public List<Reservation> HistoriqueReservations { get => historiqueReservations; set => historiqueReservations = value; }
        public TypeChambre TypeChambre { get => typeChambre; set => typeChambre = value; }
        public Hotel Hotel { get => hotel; set => hotel = value; }

    }
}