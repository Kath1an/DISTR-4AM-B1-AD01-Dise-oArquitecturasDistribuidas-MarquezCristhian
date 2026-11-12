CREATE DATABASE InventarioDB;
GO

USE InventarioDB2;
GO

CREATE TABLE Bodega (
    IdBodega   INT PRIMARY KEY IDENTITY(1,1),
    Nombre     NVARCHAR(100) NOT NULL,
    Ciudad     NVARCHAR(100),
    Direccion  NVARCHAR(255)
);

CREATE TABLE Existencia (
    IdExistencia INT PRIMARY KEY IDENTITY(1,1),
    IdProducto   INT NOT NULL,
    IdBodega     INT NOT NULL,
    Stock        INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);

CREATE TABLE MovimientoInventario (
    IdMovimiento INT PRIMARY KEY IDENTITY(1,1),
    IdProducto   INT           NOT NULL,
    IdBodega     INT           NOT NULL,
    Tipo         NVARCHAR(50)  NOT NULL,  
    Cantidad     INT           NOT NULL,
    Fecha        DATETIME      NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);

CREATE TABLE ReservaStock (
    IdReserva  INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT          NOT NULL,
    IdBodega   INT          NOT NULL,
    Cantidad   INT          NOT NULL,
    Estado     NVARCHAR(50) NOT NULL DEFAULT 'PENDIENTE',  
    FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);
