USE master
GO

CREATE DATABASE Vitrine
GO

USE [Vitrine]
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Experiences')
	BEGIN
		CREATE TABLE Experiences (
			IdExperience INT PRIMARY KEY IDENTITY(1,1),
			DateDebut DATE,
			DateFin DATE,
			Poste NVARCHAR(MAX),
			Entreprise NVARCHAR(MAX),
			Emplacement NVARCHAR(MAX))

		-- '2022-10-01,2024-10-01,Développeur Informatique,Infotel Conseil,Aix-En-Provence'
		-- '2020-10-01,2022-10-01,Développeur Informatique,BPCE-IT,Aix-En-Provence'
	    -- '2016-09-01,2017-12-31,Fondateur,SAS Dealz,Martigues'
	END
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name = 'Taches')
	BEGIN
		CREATE TABLE Taches (
			IdExp INT FOREIGN KEY (IdExp) REFERENCES Experiences(IdExperience), 
			Tache NVARCHAR(MAX)
		)
	END
GO

CREATE PROCEDURE InsertExperience 
	@DateDebut DATE,
	@DateFin DATE,
	@Poste NVARCHAR(MAX),
	@Entreprise NVARCHAR(MAX),
	@Emplacement NVARCHAR(MAX),
	@Taches NVARCHAR(MAX)
AS
	BEGIN
		SET NOCOUNT ON;
		DECLARE @IdExperience INT 
	
		INSERT INTO Experiences (DateDebut, DateFin, Poste, Entreprise, Emplacement) VALUES (@DateDebut, @DateFin, @Poste, @Entreprise, @Emplacement);
		SET @IdExperience = SCOPE_IDENTITY();
	    
		INSERT INTO Taches (IdExp, Tache) SELECT @IdExperience, TRIM(value) FROM STRING_SPLIT(@Taches, ',');
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
				-- '2022-10-01', '2024-10-01', 'Manager en architecture et applications logicielles des systèmes d''information', 'CESI', 'Aix-En-Provence', 'Bac+5'
				-- '2020-10-01', '2022-10-01', 'Développeur Informatique', 'CESI', 'Aix-En-Provence', 'Bac+2'
				-- '2013-09-01', '2016-07-01', 'Bachelor in Business Administration Spé Banque/Finance', 'Kedge Business School', 'Marseille', 'Bac+3'
	END
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Cours')
	BEGIN
		CREATE TABLE Cours (
			IdCours INT FOREIGN KEY (IdCours) REFERENCES Formations(IdFormation), 
			Cour NVARCHAR(MAX)
		)
	END
GO

CREATE PROCEDURE InsertFormation 
	@DateDebut DATE,
	@DateFin DATE,
	@Titre NVARCHAR(MAX),
	@Organisme NVARCHAR(MAX),
	@Emplacement NVARCHAR(MAX),
	@Cours NVARCHAR(MAX)
AS
	BEGIN
		SET NOCOUNT ON;
		DECLARE @IdFormation INT 
	
		INSERT INTO Formations(DateDebut, DateFin, Titre, Organisme, Emplacement) VALUES (@DateDebut, @DateFin, @Titre, @Organisme, @Emplacement);
		SET @IdFormation = SCOPE_IDENTITY();
	    
		INSERT INTO Cours (IdCours, Cour) SELECT @IdFormation, TRIM(value) FROM STRING_SPLIT(@Cours, ',');
	END
GO

IF NOT EXISTS(SELECT name FROM sysobjects WHERE name = 'Certifications')
	BEGIN
		CREATE TABLE Certifications(
			IdCertification INT PRIMARY KEY IDENTITY(1,1),
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


