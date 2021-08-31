USE EMPRESA_JULIA;
GO

INSERT INTO PESSOA (nomePessoa)
VALUES ('SAULO'),('LUCAS');
GO

INSERT INTO  TELEFONE (idPessoa,numeroTelefone)
VALUES (1,'999'), (1,'888'), (2,'777');
GO

INSERT INTO EMAIL (idPessoa,end_email)
VALUES (1,'s.santos@email.com'),
	   (2,'l.aragao@email.com');
GO

INSERT INTO CNH (idPessoa,descricao)
VALUES (1,'132'),(2,'4343');
GO
