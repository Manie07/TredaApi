# 📦 TredaApi - API de Productos

Este proyecto es una API REST desarrollada en **ASP.NET Core 8** con **Entity Framework Core** y **SQL Server**, que permite gestionar productos (Id, Nombre, Descripción y Precio).  

Incluye operaciones **CRUD (Create, Read, Update, Delete)** y soporta **búsqueda y filtrado** de productos por nombre y rango de precio.

---

## 🚀 1. Cómo correr la aplicación

### Requisitos previos
- [Visual Studio 2022](https://visualstudio.microsoft.com/)  
- [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)  

### Pasos
- Clonar este repositorio:
   ```bash
   git clone https://github.com/Manie07/TredaApi.git
   cd TredaApi
   
- Restaurar dependencias:
  ```bash
  dotnet restore


- Aplicar migraciones a la base de datos:
  ```bash
  dotnet ef database update


- Ejecutar la aplicación:
  ```bash
  dotnet run

## 🗄️ 2. Configuración de la base de datos
- La cadena de conexión se encuentra en appsettings.json:
  ```bash
  "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TredaDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }

## 📌 3. Endpoints disponibles
- 🔍 Obtener todos los productos
  ```bash
  GET /api/productos

- 🔍 Buscar productos por nombre o precio
  ```bash
  GET /api/productos?nombre=mouse&precioMin=1000&precioMax=5000

- 📄 Obtener un producto por Id
  ```bash
  GET /api/productos/{id}

- ➕ Crear un nuevo producto
  ```bash
  POST /api/productos
  Content-Type: application/json

  {
    "nombre": "Teclado Mecánico",
    "descripcion": "Teclado gamer retroiluminado",
    "precio": 150.00
  }


- ✏️ Actualizar un producto
  ```bash
  PUT /api/productos/{id}
  Content-Type: application/json
  
  {
    "id": 1,
    "nombre": "Teclado Mecánico RGB",
    "descripcion": "Teclado gamer retroiluminado con luces RGB",
    "precio": 180.00
  }


- ❌ Eliminar un producto
  ```bash
  DELETE /api/productos/{id}

📚 Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- LINQ
- Swagger (para probar la API desde navegador)
