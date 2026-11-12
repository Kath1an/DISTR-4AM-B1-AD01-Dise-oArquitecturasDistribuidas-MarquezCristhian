CREATE DATABASE PedidosDB;
GO

USE PedidosDB;
GO

CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombres   NVARCHAR(150) NOT NULL,
    Cedula    NVARCHAR(20)  NOT NULL UNIQUE,
    Correo    NVARCHAR(150) NOT NULL
);

CREATE TABLE Pedido (
    IdPedido  INT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT           NOT NULL,
    Fecha     DATETIME      NOT NULL DEFAULT GETDATE(),
    Total     DECIMAL(10,2) NOT NULL DEFAULT 0,
    Estado    NVARCHAR(50)  NOT NULL DEFAULT 'PENDIENTE',  
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetallePedido (
    IdDetalle      INT PRIMARY KEY IDENTITY(1,1),
    IdPedido       INT           NOT NULL,
    IdProducto     INT           NOT NULL,
    Cantidad       INT           NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)
);
