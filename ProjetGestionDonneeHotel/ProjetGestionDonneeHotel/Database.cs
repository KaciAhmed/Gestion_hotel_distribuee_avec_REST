using System;
using System.Data.SQLite;
using System.IO;

namespace ProjetGestionDonneeHotel
{
    public static class Database
    {
        private static SQLiteConnection myConnection;
        private static Hotel monHotel;
        private static Agence agence1;
        private static Agence agence2;
        private static Agence agence3;

        private static string pathDossierAChanger = @"E:\gitlab.com\";
        private static string pathDossierAssets = @"gestionhoteldistribueparagencedevoyage\ProjetGestionDonneeHotel\ProjetGestionDonneeHotel\assets\";
        private static string pathDossierImages = pathDossierAChanger + pathDossierAssets;
        private static string databaseName = "hotel.db";
        private static string pathCompletDatabase = pathDossierAChanger + pathDossierAssets + databaseName;
        private static string dataSource = @"Data Source=" + pathCompletDatabase;
        static Database()
        {
            myConnection = new SQLiteConnection(dataSource);
            if (!File.Exists(pathCompletDatabase))
            {
                SQLiteConnection.CreateFile(pathCompletDatabase);
                createTables();
            }
            monHotel = new Hotel(1, "Hotel1", 5, new Adresse(1, 12, "Rue Hotel 1", "France", "43.6°N, 3.9°E", "Lieu dit Hotel 1"));

            TypeChambre typeChambre1 = new TypeChambre(1);
            TypeChambre typeChambre2 = new TypeChambre(2);
            TypeChambre typeChambre3 = new TypeChambre(3);

            Chambre chambre1 = new Chambre(1, 1, "01/03/2021", typeChambre1, 42, true, pathDossierImages + "1_lit.png");
            Chambre chambre2 = new Chambre(2, 15, "10/03/2021", typeChambre1, 40, true, pathDossierImages + "1_lit.png");
            Chambre chambre3 = new Chambre(3, 12, "10/04/2021", typeChambre1, 30, true, pathDossierImages + "1_lit.png");

            Chambre chambre4 = new Chambre(4, 22, "02/03/2021", typeChambre2, 70, true, pathDossierImages + "2_lit.png");
            Chambre chambre5 = new Chambre(5, 25, "20/03/2021", typeChambre2, 65, true, pathDossierImages + "2_lit.png");
            Chambre chambre6 = new Chambre(6, 28, "02/04/2021", typeChambre2, 60, true, pathDossierImages + "2_lit.png");

            Chambre chambre7 = new Chambre(7, 32, "02/03/2021", typeChambre3, 100, true, pathDossierImages + "3_lit.png");
            Chambre chambre8 = new Chambre(8, 35, "18/03/2021", typeChambre3, 90, true, pathDossierImages + "3_lit.png");
            Chambre chambre9 = new Chambre(9, 38, "31/03/2021", typeChambre3, 85, true, pathDossierImages + "3_lit.png");

            monHotel.Chambres.Add(chambre1);
            monHotel.Chambres.Add(chambre2);
            monHotel.Chambres.Add(chambre3);
            monHotel.Chambres.Add(chambre4);
            monHotel.Chambres.Add(chambre5);
            monHotel.Chambres.Add(chambre6);
            monHotel.Chambres.Add(chambre7);
            monHotel.Chambres.Add(chambre8);
            monHotel.Chambres.Add(chambre9);

            agence1 = new Agence(1, "NomAgence1", "LoginAgence1", "123", 0.25, new Adresse(1, 25, "Rue Agence 1", "France", "43.6°N, 3.9°E", "Lieu dit Agence 1"));
            agence2 = new Agence(2, "NomAgence2", "LoginAgence2", "123", 0.2, new Adresse(2, 2, "Rue Agence 2", "France", "43.6°N, 3.9°E", "Lieu dit Agence 2"));
            agence3 = new Agence(3, "NomAgence3", "LoginAgence3", "123", 0.12, new Adresse(3, 13, "Rue Agence 3", "France", "43.6°N, 3.9°E", "Lieu dit Agence 3"));

            monHotel.Agences.Add(agence1);
            monHotel.Agences.Add(agence2);
            monHotel.Agences.Add(agence3);
        }
        public static Hotel getHotel()
        {
            return Database.monHotel;
        }
        public static void updateStatusChambre(Chambre chambre)
        {
            foreach (Chambre c in monHotel.Chambres)
            {
                if (chambre.Numero == c.Numero)
                {
                    c.EstLibre = chambre.EstLibre;
                    c.DateDisponibilite = chambre.DateDisponibilite;
                }
            }
        }
        public  static void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public static void CloseConnection()
        {
            if(myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
        private static void createTables()
        {
            // méthode qui peut etre remplacé par un fichier SQL create table + insert into 
            // ici faire les insert dans la base de donnée
        }

        public static Hotel GetHotelFromDB()
        {
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql, Output = "";
            sql = "Select * from hotel";
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            dataReader.Close();
            return null;
        }
    }
}