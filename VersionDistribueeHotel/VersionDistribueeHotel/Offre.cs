using VersionDistribueeHotel.ServiceGestionDonnee;

namespace VersionDistribueeHotel
{

    public class Offre
    {
        private string identifiant;
        private ServiceGestionDonnee.TypeChambre typeChambre;
        private string dateDisponibilite;
        private double prix;
        private byte[] image;
        public string Identifiant { get => identifiant; set => identifiant = value; }
        public ServiceGestionDonnee.TypeChambre TypeChambre { get => typeChambre; set => typeChambre = value; }
        public string DateDisponibilite { get => dateDisponibilite; set => dateDisponibilite = value; }
        public double Prix { get => prix; set => prix = value; }
        public byte[] Image { get => image; set => image = value; }

        public Offre()
        {
        }

        public Offre(string identifiant, TypeChambre typeChambre, string dateDisponibilite, double prix, byte[] image)
        {
            this.identifiant = identifiant;
            this.typeChambre = typeChambre;
            this.dateDisponibilite = dateDisponibilite;
            this.prix = prix;
            this.image = image;
        }

        public override string ToString()
        {
            return Identifiant + "," + TypeChambre + "," + DateDisponibilite + "," + Prix + "," + image;
        }
    }
}