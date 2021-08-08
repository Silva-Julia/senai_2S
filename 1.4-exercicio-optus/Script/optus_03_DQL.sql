USE OPTUS_JULIA;
GO

SELECT * FROM ARTISTA
SELECT * FROM ESTILO
SELECT * FROM ALBUM
SELECT * FROM USUARIO

-- listar todos os usu�rios administradores, sem exibir suas senhas
SELECT USUARIO.nomeUsuario, USUARIO.email, USUARIO.permissao FROM USUARIO
WHERE permissao = 2;
GO

-- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT ALBUM.nomeAlbum, ALBUM.dataLanca, ALBUM.ativo, ARTISTA.nomeArtista FROM ALBUM
INNER JOIN ARTISTA
ON ALBUM.idArtista = ARTISTA.idArtista
WHERE ALBUM.dataLanca > '2015';
GO

-- listar os dados de um usu�rio atrav�s do e-mail e senha
SELECT USUARIO.nomeUsuario, USUARIO.email, USUARIO.permissao FROM USUARIO
--SELECT * FROM USUARIO
WHERE email ='pedro@gmail.com' AND senha = '22222';
GO

-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
SELECT ALBUM.nomeAlbum, ALBUM.dataLanca, ALBUM.ativo, ARTISTA.nomeArtista, ESTILO.nomeEstilo FROM ALBUM
left JOIN ARTISTA
ON ALBUM.idArtista = ARTISTA.idArtista
left JOIN ALBUMESTILO
ON ALBUM.idAlbum = ALBUMESTILO.idAlbum
left JOIN ESTILO
ON ALBUMESTILO.idEstilo = ESTILO.idEstilo
WHERE ativo = 1;
GO