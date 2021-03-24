using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VersionDistribueeHotel
{
    public class Hotel
    {
        private int identifiant;
        private string nom;
        private int nbEtoile;
        private Adresse adresse;
        private List<Chambre> chambres;

        public Hotel()
        {
            chambres = new List<Chambre>();
        }
        public Hotel(int identifiant, string nom, int nbEtoile, Adresse adresse, List<Chambre> chambres)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.nbEtoile = nbEtoile;
            this.adresse = adresse;
            this.chambres = chambres;
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        private string Nom { get => nom; set => nom = value; }
        private int NbEtoile { get => nbEtoile; set => nbEtoile = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }

    }
}