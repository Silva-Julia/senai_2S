USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('UNIDOS');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('FIAT'),('BWM'),('FORD');
GO

INSERT INTO CLIENTE (nomeCliente)
VALUES ('MARIA'), ('JULIA');
GO

INSERT INTO MODELO(idMarca, nomeModelo)
VALUES (1,'GOL'), (2,'PALIO'), (3,'JETTA');
GO

INSERT INTO VEICULO(idModelo, descricaoPlaca)
VALUES (1,'AAAA'), (2,'BBBB'), (3,'CCCC');
GO

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataRetirada, dataDevolucao)
VALUES (1,2,'10/08/2021', '20/08/2021'), (2,3, '05/07/2020', '10/07/2020'), (3,1, '20/05/2021', '31/05/2021');
GO