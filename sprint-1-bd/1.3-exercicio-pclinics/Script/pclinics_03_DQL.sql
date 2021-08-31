USE CLINICAPET_JULIA;
GO

SELECT * FROM CLINICA
SELECT * FROM VETERINARIO
SELECT * FROM TIPOPET
SELECT * FROM RACA
SELECT * FROM DONO
SELECT * FROM PETS
SELECT * FROM CONSULTA

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT VETERINARIO.nomeVeterinario, VETERINARIO.crmv, CLINICA.nomeClinica FROM VETERINARIO
LEFT JOIN CLINICA
ON VETERINARIO.idVeterinario = CLINICA.idClinica
WHERE CLINICA.nomeClinica = 'SCuidados';
GO

-- listar todas as raças que começam com a letra S
SELECT RACA.nomeRaca FROM RACA
WHERE RACA.nomeRaca LIKE 'S%';
GO

-- listar todos os tipos de pet que terminam com a letra O
SELECT TIPOPET.nomeTipo FROM TIPOPET
WHERE TIPOPET.nomeTipo LIKE '%O';
GO

-- listar todos os pets mostrando os nomes dos seus donos
SELECT PETS.nomePet, DONO.nomeDono FROM PETS
LEFT JOIN DONO
ON PETS.idDono = DONO.idDono;
GO

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, 
-- o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e 
--o nome da clínica onde o pet foi atendido
SELECT VETERINARIO.nomeVeterinario, PETS.nomePet, RACA.nomeRaca, TIPOPET.nomeTipo, Dono.nomeDono, CLINICA.nomeClinica FROM CONSULTA
LEFT JOIN VETERINARIO
ON CONSULTA.idVeterinario = VETERINARIO.idVeterinario
LEFT JOIN PETS
ON CONSULTA.idPets = PETS.idPets
LEFT JOIN RACA
ON PETS.idPets = RACA.idRaca
LEFT JOIN TIPOPET
ON RACA.idTipo = TIPOPET.idTipo
LEFT JOIN DONO
ON PETS.idDono = DONO.idDono
LEFT JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica;
GO