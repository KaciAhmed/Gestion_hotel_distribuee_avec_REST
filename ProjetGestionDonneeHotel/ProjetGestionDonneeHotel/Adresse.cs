using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetGestionDonneeHotel
{
    public class Adresse
    {
        private int identifiant;
        private int numero;
        private string rue;
        private string pays;
        private string positionGPS;
        private string lieuDit;
        public Adresse()
        {
        }

        public Adresse(int identifiant, int numero, string rue, string pays, string positionGPS, string lieuDit)
        {
            this.identifiant = identifiant;
            this.numero = numero;
            this.rue = rue;
            this.pays = pays;
            this.positionGPS = positionGPS;
            this.lieuDit = lieuDit;
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Rue { get => rue; set => rue = value; }
        public string Pays { get => pays; set => pays = value; }
        public string PositionGPS { get => positionGPS; set => positionGPS = value; }
        public string LieuDit { get => lieuDit; set => lieuDit = value; }
    }
}