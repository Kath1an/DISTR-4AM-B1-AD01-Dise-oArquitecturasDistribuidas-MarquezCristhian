# AD01 - Diseño de Arquitecturas Distribuidas - Comercio Multibodega

**Instituto Superior Tecnológico Cordillera**  
Carrera de Desarrollo de Software | Aplicaciones Distribuidas  
Cristhian Marquez - 4A | Primer Bimestre

---

## Descripción

Sistema de 3 microservicios REST independientes para una empresa comercializadora multibodega. Cada microservicio tiene su propia base de datos y opera de forma independiente, aplicando separación de responsabilidades por dominio de negocio.

## Microservicios

| Microservicio | Responsabilidad | Base de datos | Puerto |
|---------------|-----------------|---------------|--------|
| Catalogo.Api | Gestión de productos, categorías y marcas | CatalogoDB | http://localhost:5100 |
| Inventario.Api | Control de bodegas, stock y movimientos | InventarioDB | http://localhost:5200 |
| Pedidos.Api | Registro de clientes y órdenes de compra | PedidosDB | http://localhost:5300 |

## Tecnologías

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server Express
- Swagger (documentación y pruebas)

## Requisitos previos

- .NET 10 SDK
- SQL Server Express
- Visual Studio 2022

## Configuración y ejecución

1. Ejecutar el script SQL de cada microservicio en SQL Server para crear las bases de datos y tablas.

2. Verificar la cadena de conexión en el `appsettings.json` de cada proyecto:
```json
"Server=localhost\\SQLEXPRESS;Database=<NombreDB>;Trusted_Connection=True;TrustServerCertificate=true;"
```

3. Abrir cada solución `.slnx` en Visual Studio y ejecutar con `F5`.

## Estructura del proyecto

```
├── Catalogo.Api/
│   ├── Catalogo.Api/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   └── Models/
│   ├── Catalogo.Api.slnx
│   └── CatalogoDB.sql
├── Inventario.Api/
│   ├── Inventario.Api/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   └── Models/
│   ├── Inventario.Api.slnx
│   └── InventarioDB.sql
├── Pedidos.Api/
│   ├── Pedidos.Api/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   └── Models/
│   ├── Pedidos.Api.slnx
│   └── PedidosDB.sql
└── .gitignore
```


