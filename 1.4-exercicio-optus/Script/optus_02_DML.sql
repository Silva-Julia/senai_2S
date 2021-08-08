USE OPTUS_JULIA; 
GO

INSERT INTO ARTISTA(nomeArtista)
VALUES ('FERRUGEM'), ('IVETE');
GO

INSERT INTO ESTILO(nomeEstilo)
VALUES ('PAGODE'), ('POP'), ('SAMBA');
GO

INSERT INTO ALBUM(idArtista, nomeAlbum, dataLanca, ativo)
VALUES (2,'LOCALIZEI', '20/10/2017', 0), (1,'CHAO DE ESTRELAS', '10/03/2020',1);
GO

INSERT INTO ALBUMESTILO
VALUES (1,2), (2,2), (1,3);
GO


INSERT INTO USUARIO (nomeUsuario, email, senha, permissao)
VALUES ('SAULO', 'saulo@gmail.com', 33333, 'ADM'), 
       ('LUCAS', 'lucas@gmail.com', 55555, 'ADM'), 
       ('PEDRO', 'pedro@gmail.com', 22222,'COMUM');
GO