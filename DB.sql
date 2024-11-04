-- Crear la base de datos
CREATE DATABASE SnakeGameDB;
GO

-- Usar la base de datos recién creada
USE SnakeGameDB;
GO

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    ContraseñaHash NVARCHAR(255) NOT NULL,
    FotoPerfil NVARCHAR(MAX) -- Puedes usar NVARCHAR(MAX) para almacenar strings en base64 o URLs de imágenes
);
GO

-- Crear la tabla Partidas
CREATE TABLE Partidas (
    PartidaID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Resultado INT NOT NULL,
    TiempoDeJuego TIME
);
GO