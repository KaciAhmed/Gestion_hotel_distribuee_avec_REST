using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VersionDistribueeHotel
{
    
    public class Offre 
    {
        private string identifiant;
        private TypeChambre typeChambre;
        private string dateDisponibilite;
        private double prix;
        public string Identifiant { get=> identifiant; set=>identifiant=value; }
        public TypeChambre TypeChambre { get=>typeChambre; set=> typeChambre=value; }
        public string DateDisponibilite { get=>dateDisponibilite; set=>dateDisponibilite=value; }  
        public double Prix { get=>prix; set=>prix=value; }

        public Offre()
        {
        }

        public Offre(string identifiant, TypeChambre typeChambre, string dateDisponibilite, double prix)
        {
            Identifiant = identifiant;
            TypeChambre = typeChambre;
            DateDisponibilite = dateDisponibilite;
            Prix = prix;
        }

        public override string ToString()
        {
            return Identifiant+","+TypeChambre+","+DateDisponibilite+","+Prix;
        }
    }
}