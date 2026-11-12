CREATE DATABASE CatalogoDB;
GO

USE CatalogoDB;
GO

CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre      NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Marca (
    IdMarca    INT PRIMARY KEY IDENTITY(1,1),
    Nombre     NVARCHAR(100) NOT NULL,
    PaisOrigen NVARCHAR(100)
);

CREATE TABLE Producto (
    IdProducto  INT PRIMARY KEY IDENTITY(1,1),
    IdCategoria INT NOT NULL,
    IdMarca     INT NOT NULL,
    Nombre      NVARCHAR(150) NOT NULL,
    SKU         NVARCHAR(50)  NOT NULL UNIQUE,
    Precio      DECIMAL(10,2) NOT NULL,
    Estado      BIT           NOT NULL DEFAULT 1,
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    FOREIGN KEY (IdMarca)     REFERENCES Marca(IdMarca)
);
