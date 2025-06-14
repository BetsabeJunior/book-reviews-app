# 📚 Controlbox - Book Reviews App

Aplicación web full stack que permite a los usuarios **registrarse, iniciar sesión, buscar libros y dejar reseñas**. Es una plataforma sencilla para explorar libros y compartir opiniones con otros lectores.

---

## 🔧 Tecnologías utilizadas

- **Frontend**: [Angular 19](https://angular.io/) + [Tailwind CSS](https://tailwindcss.com/)
- **Backend**: [ASP.NET Core 9](https://dotnet.microsoft.com/) con Clean Architecture
- **Base de datos**: PostgreSQL
- **Autenticación**: JSON Web Tokens (JWT)
- **Estilo de código**: StyleCop (C#)
- **Gestión de paquetes**: npm y NuGet
- **CI/CD**: GitHub Actions (opcional)

---

## 🧩 Funcionalidades principales

- Registro e inicio de sesión de usuarios.
- Listado de libros.
- Búsqueda por título, autor o categoría.
- Visualización de detalles del libro.
- Creación, edición y eliminación de reseñas.
- Visualización de reseñas de otros usuarios.
- Sistema de autenticación y autorización seguro.
- Arquitectura modular y mantenible.

---

## 📁 Estructura del repositorio

```
controlbox/
├── backend/        # API RESTful en .NET
│   ├── Controlbox.API/
│   ├── Controlbox.Application/
│   ├── Controlbox.Domain/
│   └── Controlbox.Infrastructure/
│
└── frontend/       # Aplicación Angular
    ├── src/
    ├── angular.json
    └── ...
```

---

## ▶️ Instrucciones de instalación

### 🔹 Backend (.NET)

1. Ve al directorio del backend:

```bash
cd backend/Controlbox.API
```

2. Restaura paquetes y ejecuta:

```bash
dotnet restore
dotnet ef database update    # Asegúrate de tener configurada la cadena de conexión
dotnet run
```

> ⚠️ Asegúrate de tener .NET 9 SDK instalado y una base de datos PostgreSQL corriendo.

---

### 🔹 Frontend (Angular)

1. Ve al directorio del frontend:

```bash
cd frontend
```

2. Instala dependencias y ejecuta:

```bash
npm install
ng serve
```

> La app estará disponible en: `http://localhost:4200`

---

## ⚙️ Variables de entorno

Asegúrate de configurar los entornos para desarrollo:

### Backend (`appsettings.Development.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=controlbox;Username=postgres;Password=tu_clave"
  },
  "Jwt": {
    "Key": "clave_super_secreta",
    "Issuer": "ControlboxAPI",
    "Audience": "ControlboxFrontend"
  }
}
```

### Frontend (`src/environments/environment.ts`)

```ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

---

## 🚀 Objetivo del proyecto

Este proyecto fue desarrollado como parte de una prueba técnica para el rol de **Desarrollador Back-End Jr.**, enfocándose en:

- Buenas prácticas de desarrollo (Clean Code, Clean Architecture)
- Seguridad básica con JWT
- Separación por capas
- Manejo de DTOs
- Documentación clara y mantenible

---

## 📜 Licencia

Este proyecto es de uso educativo y demostrativo. Todos los derechos reservados © Controlbox.