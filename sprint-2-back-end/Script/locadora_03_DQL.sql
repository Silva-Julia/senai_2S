USE T_Rental_Julia;
GO

SELECT * FROM EMPRESA
SELECT * FROM MARCA
SELECT * FROM CLIENTE
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM ALUGUEL


--listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que 
--alugou e nome do modelo do carro
SELECT ALUGUEL.dataInicio, ALUGUEL.dataFim, CLIENTE.nomeCliente, MODELO.nomeModelo FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idAluguel = CLIENTE.idCliente
INNER JOIN VEICULO
ON ALUGUEL.idAluguel = VEICULO.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo;
GO


--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim 
--e o nome do modelo do carro
SELECT ALUGUEL.dataInicio, ALUGUEL.dataFim, CLIENTE.nomeCliente, MODELO.nomeModelo FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idAluguel = CLIENTE.idCliente
INNER JOIN VEICULO
ON ALUGUEL.idAluguel = VEICULO.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
WHERE CLIENTE.nomeCliente = 'JULIA';
GO