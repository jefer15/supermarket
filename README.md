# 🛒 Supermarket MVC
Este proyecto es una **aplicación web de gestión para un supermercado**, desarrollada en **ASP.NET Core 6 MVC**.  

Cuenta con un sistema de **autenticación y registro de usuarios** implementado con **ASP.NET Core Identity**.  

Permite administrar **clientes, productos y ventas**, además de generar **reportes en PDF** con las siguientes tecnologías y librerías:

- **Entity Framework Core** (SQL Server)  
- **ASP.NET Core Identity** (autenticación y registro de usuarios)  
- **Rotativa.AspNetCore** (generación de reportes en PDF)  

---

## 📦 Dependencias instaladas

```powershell
Microsoft.AspNetCore.Identity.EntityFramework
Microsoft.AspNetCore.Identity.UI
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGeneration.Design
Rotativa.AspNetCore
```

---

## ⚙️ Base de datos

### 1. Crear la base de datos en SQL Server

```sql
CREATE DATABASE Supermarket;
USE Supermarket;
```

### 2. Configuración de conexión en `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVER;Database=Supermarket;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 🔧 Herramientas necesarias

- **SQL Server** (para la base de datos)  
- **.NET 6.0 Runtime (LTS)**  
- **Entity Framework Core CLI**:  

```powershell
dotnet tool install --global dotnet-ef
```

---

## 🗄️ Migraciones y scaffolding

### Migración inicial para Identity
```powershell
dotnet ef database update
```
---

## 🚀 Ejecución del proyecto

1. Ejecutar el proyecto:
   ```powershell
   dotnet run
   ```

2. Navegar a las siguientes rutas:

   - `/Identity/Account/Register` → Registro de usuarios  
   - `/Identity/Account/Login` → Login  
   - `/Products` → CRUD de productos  
   - `/Customers` → CRUD de clientes  
   - `/Sales` → Registro de ventas  
   - `/Reports` → Reportes en PDF  

---

## ✅ Funcionalidades implementadas

- [x] CRUD de Clientes  
- [x] CRUD de Productos  
- [x] Registro de Ventas y Detalles  
- [x] Autenticación con **Identity** (Login, Register, Logout)  
- [x] Reportes en PDF con **Rotativa**  

---

## 🏗️ Arquitectura del Proyecto

```text
                   ┌────────────────────────────┐
                   │        Cliente (UI)        │
                   │    Navegador Web (MVC)     │
                   └─────────────┬──────────────┘
                                 │ HTTP Request
                                 ▼
                   ┌────────────────────────────┐
                   │     ASP.NET Core MVC       │
                   │ - Controladores            │
                   │ - Vistas (Razor Pages)     │
                   │ - Identity (Auth)          │
                   │ - Rotativa (PDF)           │
                   └─────────────┬──────────────┘
                                 │ EF Core
                                 ▼
                   ┌────────────────────────────┐
                   │     ApplicationDbContext   │
                   │ (Entity Framework Core)    │
                   └─────────────┬──────────────┘
                                 │
                                 ▼
                   ┌────────────────────────────┐
                   │        SQL Server          │
                   │  Tablas:                   │
                   │  - Customers               │
                   │  - Products                │
                   │  - Sales                   │
                   │  - SaleDetails             │
                   │  - AspNetUsers (Identity)  │
                   └────────────────────────────┘
```

---

📅 **Tecnologías:** ASP.NET Core 6, EF Core, SQL Server, Identity, Rotativa  
