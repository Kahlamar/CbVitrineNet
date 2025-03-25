USE master
GO

IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'Vitrine')
	BEGIN
		CREATE DATABASE [Vitrine]
		USE [Vitrine]
	END
ELSE
	BEGIN
		USE [Vitrine]
		PRINT 'Vitrine existe d�j�'
	END
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Experiences')
	BEGIN
		CREATE TABLE Experiences (
			IdExperience INT PRIMARY KEY IDENTITY(1,1),
			DateDebut DATE,
			DateFin DATE,
			Poste NVARCHAR(MAX),
			Entreprise NVARCHAR(MAX),
			Emplacement NVARCHAR(MAX),
			Description NVARCHAR(MAX))

		INSERT INTO Experiences (DateDebut, DateFin, Poste, Entreprise, Emplacement, Description)
			VALUES 
				('2022-10-01', '2024-10-01', 'D�veloppeur Informatique', 'Infotel Conseil', 'Aix-En-Provence', '� compl�ter'),
				('2020-10-01', '2022-10-01', 'D�veloppeur Informatique', 'BPCE-IT', 'Aix-En-Provence', '� compl�ter'),
				('2016-09-01', '2017-12-31', 'Fondateur', 'SAS Dealz', 'Martigues', '� compl�ter')
	END
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Formations')
	BEGIN
		CREATE TABLE Formations(
			IdFormation INT PRIMARY KEY IDENTITY(1,1),
			DateDebut DATE,
			DateFin DATE,
			Titre NVARCHAR(MAX),
			Organisme NVARCHAR(MAX),
			Emplacement NVARCHAR(MAX),
			NiveauAtteint NVARCHAR(MAX),
			Cours NVARCHAR(MAX))

		INSERT INTO Formations (DateDebut, DateFin, Titre, Organisme, Emplacement, NiveauAtteint, Cours)
			VALUES 
				('2022-10-01', '2024-10-01', 'Manager en architecture et applications logicielles des syst�mes d''information', 'CESI', 'Aix-En-Provence', 'Bac+5', 'Cours � compl�ter'),
				('2020-10-01', '2022-10-01', 'D�veloppeur Informatique', 'CESI', 'Aix-En-Provence', 'Bac+2', 'Cours � compl�ter'),
				('2013-09-01', '2016-07-01', 'Bachelor in Business Administration Sp� Banque/Finance', 'Kedge Business School', 'Marseille', 'Bac+3', 'Cours � compl�ter')
	END
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Certifications')
	BEGIN
		CREATE TABLE Certifications(
			IdFormation INT PRIMARY KEY IDENTITY(1,1),
			Titre NVARCHAR(MAX),
			OrganismeCertifiant NVARCHAR(MAX),
			DureeValiditeAnnees INT)

		INSERT INTO Certifications (Titre, OrganismeCertifiant, DureeValiditeAnnees)
			VALUES 
				('Python Associate Programmer', 'Python Institute', 3),
				('C++ Associate Programmer', 'C++ Institute', 3),
				('Certified Tester Foundation Level', 'ISTQB', 100)
	END
GO


