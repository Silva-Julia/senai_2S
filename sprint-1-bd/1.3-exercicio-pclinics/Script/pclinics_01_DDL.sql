CREATE DATABASE CLINICAPET_JULIA;
GO

USE CLINICAPET_JULIA;
GO

CREATE TABLE CLINICA(
  idClinica TINYINT PRIMARY KEY IDENTITY(1,1),
  nomeClinica VARCHAR(30) NOT NULL
);
GO

CREATE TABLE VETERINARIO(
  idVeterinario TINYINT PRIMARY KEY IDENTITY(1,1),
  idClinica TINYINT FOREIGN KEY REFERENCES CLINICA(idClinica),
  nomeVeterinario VARCHAR(20) NOT NULL,
);
ALTER TABLE VETERINARIO
ADD crmv VARCHAR(6)
GO

CREATE TABLE TIPOPET(
 idTipo SMALLINT PRIMARY KEY IDENTITY(1,1),
 nomeTipo VARCHAR(20) NOT NULL
);
GO

CREATE TABLE RACA(
 idRaca SMALLINT PRIMARY KEY IDENTITY(1,1),
 idTipo TINYINT FOREIGN KEY REFERENCES TIPOPET(idTipo),
 nomeRaca VARCHAR(25) NOT NULL
);
GO

CREATE TABLE DONO(
  idDono SMALLINT PRIMARY KEY IDENTITY(1,1),
  nomeDono VARCHAR(25) NOT NULL
);
GO

CREATE TABLE PETS(
  idPets SMALLINT PRIMARY KEY IDENTITY(1,1), 
  idDono SMALLINT FOREIGN KEY REFERENCES DONO(idDono),
  nomePet VARCHAR(20) NOT NULL
);
GO

CREATE TABLE CONSULTA(
  idConsulta SMALLINT PRIMARY KEY IDENTITY(1,1), 
  idPets SMALLINT FOREIGN KEY REFERENCES PETS(idPets),
  idVeterinario TINYINT FOREIGN KEY REFERENCES VETERINARIO(idVeterinario)
);
GO