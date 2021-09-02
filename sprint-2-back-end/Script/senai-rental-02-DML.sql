USE T_Rental_Julia;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('UNIDOS'), ('LOCALIZA');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('FIAT'),('BWM');
GO

INSERT INTO CLIENTE (nomeCliente, cpfCliente, sobrenomeCliente )
VALUES ('MARIA',444444, 'Leal' ), ('JULIA',77777, 'Mota');
GO

INSERT INTO MODELO(idMarca, nomeModelo)
VALUES (1,'GOL'), (2,'PALIO');
GO

INSERT INTO VEICULO(idModelo, idEmpresa, placa)
VALUES (1,2,'AAAA'), (2,1,'BBBB');
GO

INSERT INTO ALUGUEL(idVeiculo, idCliente, dataInicio, dataFim)
VALUES (1,2,'10/08/2021', '20/08/2021'), (2,1, '05/07/2020', '10/07/2020');
GO