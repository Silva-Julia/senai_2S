USE OPTUS; 
GO

INSERT INTO ARTISTA(nomeArtista)
VALUES ('FERRUGEM'), ('IVETE');
GO

INSERT INTO ESTILO(nomeEstilo)
VALUES ('PAGODE'), ('POP'), ('SAMBA');
GO

INSERT INTO ALBUM(idArtista, idEstilo, nomeAlbum)
VALUES (2,3,'LOCALIZEI'), (1,2,'CHAO DE ESTRELAS');
GO

INSERT INTO USUARIO (nomeUsuario)
VALUES ('SAULO'), ('LUCAS'), ('PEDRO');
GO