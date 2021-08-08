USE CLINICAPET_JULIA;
GO

INSERT INTO CLINICA(nomeClinica)
VALUES ('RPets'), ('SCuidados');
GO

INSERT INTO VETERINARIO(idClinica, nomeVeterinario, crmv)
VALUES (1,'SAULO',354785), (2,'JULIA', 213456);
GO

INSERT INTO TIPOPET(nomeTipo)
VALUES ('GATO'), ('CACHORRO'), ('CALOPSITA');
GO

INSERT INTO RACA(idTipo, nomeRaca)
VALUES (1, 'SIAMES'), (2, 'GOLDEN'), (3, 'ARLEQUO');
GO

INSERT INTO DONO(nomeDono)
VALUES ('THIAGO'), ('CLAUDIA');
GO

INSERT INTO PETS(idDono, nomePet)
VALUES (2, 'CHARLIE'), (1, 'DUCK');
GO

INSERT INTO CONSULTA(idPets, idVeterinario)
VALUES (1,2),(2,1);
GO