USE OPTUS_JULIA;
GO

SELECT * FROM ARTISTA
SELECT * FROM ESTILO
SELECT * FROM ALBUM
SELECT * FROM USUARIO

-- listar todos os usu�rios administradores, sem exibir suas senhas
SELECT USUARIO.nomeUSUARIO, USUARIO.email, USUARIO.permissao FROM USUARIO
WHERE USUARIO.permissao LIKE 'ADM';
GO

-- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT ALBUM.nomeAlbum, ALBUM.dataLanca, ALBUM.ativo, ARTISTA.nomeArtista FROM ALBUM
INNER JOIN ARTISTA
ON ALBUM.idArtista = ARTISTA.idArtista
WHERE ALBUM.dataLanca > '2015';
GO

-- listar os dados de um usu�rio atrav�s do e-mail e senha
SELECT USUARIO.nomeUsuario, USUARIO.email, USUARIO.permissao FROM USUARIO
WHERE USUARIO.email LIKE 'pedro@gmail.com' AND USUARIO.senha LIKE '22222';
GO

-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
SELECT ALBUM.nomeAlbuns, ALBUM.dataLanca, ALBUM.ativo, ARTISTA.nomeArtista, ESTILO.nomeEstilo FROM ALBUM
INNER JOIN ARTISTA
ON ALBUM.idArtista = ARTISTA.idArtista
INNER JOIN ALBUMESTILO
ON ALBUM.idAlbum = ALBUMESTILO.idAlbum
INNER JOIN ESTILO
ON ALBUMESTILO.idEstilo = ESTILO.idEstilo
WHERE ALBUM.ativo = 'true';
GO