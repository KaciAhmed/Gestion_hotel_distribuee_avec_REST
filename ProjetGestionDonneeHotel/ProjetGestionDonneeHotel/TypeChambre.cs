using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetGestionDonneeHotel
{
    public class TypeChambre
    {
        private int nbLit;
        public int NbLits { get => nbLit; set => nbLit = value; }

        public TypeChambre()
        {
        }
        public TypeChambre(int nbLits)
        {
            NbLits = nbLits;
        }

        public override string ToString()
        {
            return NbLits.ToString();
        }
    }
}