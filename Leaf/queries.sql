CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Evento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255),
    DataLocal DATETIME NOT NULL,
    Tipo SMALLINT NOT NULL,
    UsuarioId INT,

    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);

CREATE TABLE EventoUsuario (
    EventoId INT NOT NULL,
    UsuarioId INT NOT NULL,
    PRIMARY KEY (EventoId, UsuarioId), -- Define a combinação como chave primária
    FOREIGN KEY (EventoId) REFERENCES Evento(ID) ON DELETE CASCADE,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(ID) ON DELETE CASCADE
);

INSERT INTO Usuario (Nome, Email)
VALUES ('Fabricio Moraes', 'fabricio_moraes@gmail.com');

INSERT INTO Usuario (Nome, Email)
VALUES ('Henrique Alencar', 'henrique_alencar@gmail.com');

INSERT INTO Usuario (Nome, Email)
VALUES ('Fulano', 'fulano@gmail.com');


INSERT INTO Evento (Nome, Descricao, DataLocal, Tipo, UsuarioId)
VALUES ('Evento teste', 'Descrição do evento', '2024-12-15T18:00:00', 1, 1);

UPDATE Evento
SET Nome = 'Evento Atualizado',
    Descricao = 'Descrição atualizada',
    DataLocal = '2024-12-20T20:00:00',
    Tipo = 2,
    UsuarioId = 2
WHERE Id = 1;

DELETE FROM Evento
WHERE Id = 1;

CREATE VIEW Vw_Usuario_Eventos AS
SELECT 
    u.Nome AS NomeUsuario,
    e.Nome AS NomeEvento,
    e.DataLocal AS DataEvento,
    CASE 
        WHEN e.Tipo = 1 THEN 'EXCLUSIVO'
        WHEN e.Tipo = 2 THEN 'COMPARTILHADO'
    END AS TipoDescricao
FROM 
    [dbo].[Evento] e
INNER JOIN 
    [dbo].[Usuario] u ON e.UsuarioId = u.Id;