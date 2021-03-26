using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetGestionDonneeHotel
{
    public class Hotel
    {
        private int identifiant;
        private string nom;
        private int nbEtoile;
        private Adresse adresse;
        private List<Chambre> chambres;
        private List<Agence> agences;

        public Hotel()
        {
            chambres = new List<Chambre>();
            agences = new List<Agence>();
        }
        public Hotel(int identifiant, string nom, int nbEtoile, Adresse adresse, List<Chambre> chambres, List<Agence> agences)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.nbEtoile = nbEtoile;
            this.adresse = adresse;
            this.chambres = chambres;
            this.agences = agences;
        }
        public Hotel(int identifiant, string nom, int nbEtoile, Adresse adresse)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.nbEtoile = nbEtoile;
            this.adresse = adresse;
            chambres = new List<Chambre>();
            agences = new List<Agence>();

        }
        public int Identifiant { get => identifiant; set => identifiant = value; }
        private string Nom { get => nom; set => nom = value; }
        private int NbEtoile { get => nbEtoile; set => nbEtoile = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }
        public List<Agence> Agences { get => agences; set => agences = value; }
    }
}