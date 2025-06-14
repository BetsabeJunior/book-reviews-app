# 📘 Descripción Técnica - Aplicación de Reseñas de Libros

## 🧱 Arquitectura General

La aplicación sigue una arquitectura cliente-servidor desacoplada basada en API RESTful.  
Backend implementado en ASP.NET Core (con Clean Architecture) y frontend en Angular + Tailwind CSS.

## 🤖 Tecnologías Seleccionadas

- **Frontend:** Angular 17, Tailwind CSS, Angular Router, JWT Auth
- **Backend:** ASP.NET Core 8, Entity Framework Core, PostgreSQL, AutoMapper, FluentValidation
- **DB:** PostgreSQL (Railway, Supabase o local)
- **Deploy:** Vercel (Frontend), Render/Fly.io (Backend)
- **CI/CD:** GitHub Actions

## 📦 Estructura de Capas (Backend Clean Architecture)

- `Domain`: Entidades y lógica de negocio pura
- `Application`: DTOs, interfaces, validaciones, casos de uso
- `Infrastructure`: EF Core, JWT, correo (opcional)
- `API`: Endpoints, middlewares, documentación Swagger

## 🗂️ Modelado de Datos

### Usuario
- Id
- Nombre de usuario
- Email
- Contraseña (hash)
- Reseñas[]

### Libro
- Id
- Título
- Autor
- CategoríaId
- ImagenUrl
- Reseñas[]

### Reseña
- Id
- UsuarioId
- LibroId
- Calificación (1–5)
- Comentario
- FechaCreación

### Categoría
- Id
- Nombre

## 🔐 Autenticación y Autorización

- Login / Registro con JWT
- Middleware para validar token y proteger endpoints
- Usuarios autenticados pueden dejar/editar sus propias reseñas

## 🔄 Flujo de desarrollo

1. Configuración de estructura Clean Architecture
2. Autenticación (registro, login)
3. CRUD de libros y categorías
4. CRUD de reseñas
5. Frontend (login, listado, detalle, reseñas)
6. Perfil del usuario
7. Deploy backend + frontend
8. CI/CD con GitHub Actions

## ⏳ Estimación de Tiempo

| Fase                | Tiempo estimado |
|---------------------|-----------------|
| Backend completo     | 10 horas        |
| Frontend completo    | 10 horas        |
| Deploy + CI/CD       | 4 horas         |
| Documentación y pruebas | 3 horas     |
| **Total Aproximado** | **27 horas**    |

## ⚠️ Desafíos técnicos

- Gestión de tokens JWT entre frontend y backend
- Validaciones robustas en formularios y backend
- Seguridad (no exponer endpoints sin token)
- Despliegue sincronizado de backend + frontend

---

