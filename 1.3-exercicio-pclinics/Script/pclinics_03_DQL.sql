USE CLINICAPET_JULIA;
GO

SELECT * FROM CLINICA
SELECT * FROM VETERINARIO
SELECT * FROM TIPOPET
SELECT * FROM RACA
SELECT * FROM DONO
SELECT * FROM PETS
SELECT * FROM CONSULTA

-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
SELECT VETERINARIO.nomeVeterinario, VETERINARIO.crmv, CLINICA.nomeClinica FROM VETERINARIO
INNER JOIN CLINICA
ON VETERINARIO.idVeterinario = CLINICA.idClinica
WHERE CLINICA.nomeClinica = 'SCuidados';
GO

-- listar todas as ra�as que come�am com a letra S
SELECT RACA.nomeRaca FROM RACA
WHERE RACA.nomeRaca LIKE 'S%';
GO

-- listar todos os tipos de pet que terminam com a letra O
SELECT TIPOPET.nomeTipo FROM TIPOPET
WHERE TIPOPET.nomeTipo LIKE '%O';
GO

-- listar todos os pets mostrando os nomes dos seus donos
SELECT PETS.nomePet, DONO.nomeDono FROM PET
INNER JOIN DONO
ON PET.idDono = DONO.idDono;
GO

-- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, 
-- o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e 
--o nome da cl�nica onde o pet foi atendido
SELECT VETERINARIO.nomeVeterinario, PET.nomePet, RACA.nomeRaca, TIPOPET.nomeTipo, Dono.nomeDono, CLINICA.nomeClinica FROM CONSULTA
INNER JOIN VETERINARIO
ON CONSULTA.idVeterinario = VETERINARIO.idVeterinario
INNER JOIN PETS
ON CONSULTA.idPets = PETS.idPets
INNER JOIN RACA
ON PETS.idRaca = RACA.idRaca
INNER JOIN TIPOPET
ON RACA.idTipo = TIPOPET.idTipo
INNER JOIN DONO
ON PET.idDono = DONO.idDono
INNER JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica;
GO