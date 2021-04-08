--
-- File generated with SQLiteStudio v3.3.2 on Thu Apr 8 10:04:03 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Adresse
CREATE TABLE Adresse (Identifiant NUMERIC CONSTRAINT PK_ADRESSE PRIMARY KEY, Numero NUMERIC, Rue VARCHAR, Pays VARCHAR, PositionGPS VARCHAR, LieuDit VARCHAR);

-- Table: Agence
CREATE TABLE Agence (Identifiant NUMERIC CONSTRAINT PK_AGENCE PRIMARY KEY, Nom VARCHAR, Login VARCHAR, MotDePasse VARCHAR, PourcentageReduction NUMERIC (3, 2), Adresse NUMERIC REFERENCES Adresse (Identifiant));

-- Table: Chambre
CREATE TABLE Chambre (Identifiant NUMERIC CONSTRAINT PK_CHAMBRE PRIMARY KEY, Numero NUMERIC, EstLibre BOOLEAN, DateDisponibilite VARCHAR, PrixDeBase NUMERIC (10, 2), UrlImage VARCHAR, TypeChambre NUMERIC CONSTRAINT FK_CHAMBRE_TYPE_CHAMBRE REFERENCES TypeChambre (Identifiant), Image CHAR);

-- Table: Client
CREATE TABLE Client (Identifiant NUMERIC CONSTRAINT PK_CLIENT PRIMARY KEY, Nom VARCHAR, Prenom VARCHAR);

-- Table: Hotel
CREATE TABLE Hotel (Identifiant NUMERIC CONSTRAINT PK_HOTEL PRIMARY KEY, Nom VARCHAR, NbEtoile NUMERIC CONSTRAINT CHECK_HOTEL_NB_ETOILE CHECK (NbEtoile >= 0 AND NbEtoile <= 5), Adresse NUMERIC REFERENCES Adresse (Identifiant));

-- Table: Hotel_Possede_Chambre
CREATE TABLE Hotel_Possede_Chambre (Chambre NUMERIC REFERENCES Chambre (Identifiant), Hotel NUMERIC REFERENCES Hotel (Identifiant), CONSTRAINT PK_HOTEL_POSSEDE_CHAMBRE PRIMARY KEY (Chambre, Hotel));

-- Table: Partenaire
CREATE TABLE Partenaire (Hotel NUMERIC REFERENCES Hotel (Identifiant), Agence NUMERIC REFERENCES Agence (Identifiant), CONSTRAINT PK_PARTENAIRE PRIMARY KEY (Hotel, Agence));

-- Table: Reservation
CREATE TABLE Reservation (Identifiant NUMERIC CONSTRAINT PK_RESERVATION PRIMARY KEY, Reference VARCHAR, DateDebut VARCHAR, DateFin VARCHAR, NbPersonne NUMERIC, CarteCredit VARCHAR, Client NUMERIC REFERENCES Client (Identifiant), Agence NUMERIC REFERENCES Agence (Identifiant), Chambre NUMERIC  REFERENCES Chambre (Identifiant));

-- Table: TypeChambre
CREATE TABLE TypeChambre (Identifiant NUMERIC CONSTRAINT PK_TYPE_CHAMBRE PRIMARY KEY, NbLit NUMERIC CONSTRAINT UNIQUE_TYPE_CHAMBRE_NBLIT UNIQUE CONSTRAINT CHECK_TYPE_CHAMBRE_NBLIT CHECK (NbLit >= 1 AND NbLit <= 3));

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
