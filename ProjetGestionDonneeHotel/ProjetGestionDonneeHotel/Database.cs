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
        
        private static string databaseName = "DB_Hotels.db";
        private static string pathCompletDatabase = pathDossierAChanger + pathDossierAssets + databaseName;
        private static string dataSource = @"Data Source=" + pathCompletDatabase;
        static Database()
        {
            myConnection = new SQLiteConnection(dataSource);
            OpenConnection();
            if (!File.Exists(pathCompletDatabase))
            {
                SQLiteConnection.CreateFile(pathCompletDatabase);
            }
            createDatabase();

            int identifiantHotel = 1;
            monHotel = GetHotelFromDB(identifiantHotel);

            TypeChambre typeChambre1 = GetTypeChambreFromDB(1);
            TypeChambre typeChambre2 = GetTypeChambreFromDB(2);
            TypeChambre typeChambre3 = GetTypeChambreFromDB(3);

            Chambre chambre1 = GetChambreFromDB(1);
            Chambre chambre2 = GetChambreFromDB(2);
            Chambre chambre3 = GetChambreFromDB(3);

            Chambre chambre4 = GetChambreFromDB(4);
            Chambre chambre5 = GetChambreFromDB(5);
            Chambre chambre6 = GetChambreFromDB(6);

            Chambre chambre7 = GetChambreFromDB(7);
            Chambre chambre8 = GetChambreFromDB(8);
            Chambre chambre9 = GetChambreFromDB(9);

            monHotel.Chambres.Add(chambre1);
            monHotel.Chambres.Add(chambre2);
            monHotel.Chambres.Add(chambre3);
            monHotel.Chambres.Add(chambre4);
            monHotel.Chambres.Add(chambre5);
            monHotel.Chambres.Add(chambre6);
            monHotel.Chambres.Add(chambre7);
            monHotel.Chambres.Add(chambre8);
            monHotel.Chambres.Add(chambre9);

            agence1 = GetAgenceFromDB(1);
            agence2 = GetAgenceFromDB(2);
            agence3 = GetAgenceFromDB(3);

            monHotel.Agences.Add(agence1);
            monHotel.Agences.Add(agence2);
            monHotel.Agences.Add(agence3);
            CloseConnection();
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
        public static void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public static void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
        private static void createDatabase()
        {
            string createTables = File.ReadAllText(pathDossierImages + "drop_create.sql");
            string insertRows = File.ReadAllText(pathDossierImages + "insert.sql");
          //  
            SQLiteCommand command = new SQLiteCommand(createTables, myConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(insertRows, myConnection);
            command.ExecuteNonQuery();
           // 
        }

        public static Hotel GetHotelFromDB(int identifiant)
        {
            //
            Hotel hotelARetourner = new Hotel();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Hotel H WHERE H.Identifiant = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                hotelARetourner.Identifiant = dataReader.GetInt32(0);
                hotelARetourner.Nom = dataReader.GetString(1);
                hotelARetourner.NbEtoile = dataReader.GetInt32(2);
                hotelARetourner.Adresse = GetAdresseFromDB(dataReader.GetInt32(3));
            }
            
            

            dataReader.Close();
           // 
            return hotelARetourner;
        }

        private static Adresse GetAdresseFromDB(int identifiant)
        {
            
            Adresse AdresseARetourner = new Adresse();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Adresse A WHERE A.Identifiant = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                AdresseARetourner.Identifiant = dataReader.GetInt32(0);
                AdresseARetourner.Numero = dataReader.GetInt32(1);
                AdresseARetourner.Rue = dataReader.GetString(2);
                AdresseARetourner.Pays = dataReader.GetString(3);
                AdresseARetourner.PositionGPS = dataReader.GetString(4);
                AdresseARetourner.LieuDit = dataReader.GetString(5);
            }

            dataReader.Close();
            
            return AdresseARetourner;
        }

        private static TypeChambre GetTypeChambreFromDB(int identifiant)
        {
            
            TypeChambre typeChambreARetourner = new TypeChambre();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM TypeChambre TC WHERE TC.Identifiant = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                typeChambreARetourner.NbLits = dataReader.GetInt32(1);
            }

            dataReader.Close();
            
            return typeChambreARetourner;
        }

        private static Chambre GetChambreFromDB(int identifiant)
        {
            
            Chambre chambreARetourner = new Chambre();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Chambre C WHERE C.Identifiant = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                chambreARetourner.Identifiant = dataReader.GetInt32(0);
                chambreARetourner.Numero = dataReader.GetInt32(1);
                chambreARetourner.EstLibre = dataReader.GetBoolean(2);
                chambreARetourner.DateDisponibilite = dataReader.GetString(3);
                chambreARetourner.PrixDeBase = dataReader.GetFloat(4);
                chambreARetourner.UrlImage = dataReader.GetString(5);
                chambreARetourner.TypeChambre = GetTypeChambreFromDB(dataReader.GetInt32(6));
                chambreARetourner.Image = chambreARetourner.StreamToByteArray(chambreARetourner.UrlImage);
            }

            dataReader.Close();
            
            return chambreARetourner;
        }

        private static Agence GetAgenceFromDB(int identifiant)
        {
            
            Agence agenceARetourner = new Agence();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Agence A WHERE A.Identifiant = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                agenceARetourner.Identifiant = dataReader.GetInt32(0);
                agenceARetourner.Nom = dataReader.GetString(1);
                agenceARetourner.Login = dataReader.GetString(2);
                agenceARetourner.MotDePasse = dataReader.GetString(3);
                agenceARetourner.PourcentageReduction = dataReader.GetFloat(4);
                agenceARetourner.Adresse = GetAdresseFromDB(dataReader.GetInt32(5));
            }

            dataReader.Close();
            
            return agenceARetourner;
        }


    }
}