# Proyecto Solicitudes API

Este proyecto es una API REST desarrollada en ASP.NET Core para gestionar solicitudes.

## Requisitos Previos

- .NET 8.0 SDK
- SQL Server Express
- Visual Studio 2022 (recomendado) o VS Code

## Configuración del Proyecto

### 1. Base de Datos

El proyecto utiliza SQL Server. La cadena de conexión se encuentra en `appsettings.json`. Necesitarás modificar el servidor según tu configuración local:

```json
{
  "ConnectionStrings": {
    "SolicitudesConnection": "Server=TU-SERVIDOR\\SQLEXPRESS;Database=SolicitudesDev;User ID=sa;Password=TU-PASSWORD;TrustServerCertificate=True"
  }
}

Reemplaza:

- TU-SERVIDOR con el nombre de tu servidor SQL Server
- TU-PASSWORD con tu contraseña de SQL Server
### 2. Estructura del Proyecto
El proyecto está organizado en capas:

- Solicitudes.API : Capa de presentación (Controllers y configuración)
- Solicitudes.API.Aplicacion : Capa de aplicación (Servicios)
- Solicitudes.API.Entidades : Capa de dominio (Entidades y DTOs)
- Solicitudes.API.Infraestructura : Capa de acceso a datos
### 3. Pasos para Ejecutar
1. Clona el repositorio
2. Modifica la cadena de conexión en appsettings.json
3. Abre la solución en Visual Studio
4. Ejecuta las migraciones de Entity Framework:
dotnet ef database update
5. Ejecuta el proyecto:
dotnet run
### 4. Endpoints Disponibles
- POST /crearSolicitud : Crear una nueva solicitud
- GET /solicitud/{id} : Obtener una solicitud por ID
- PUT /actualizarEstado/{id} : Actualizar el estado de una solicitud
### 5. CORS
La API está configurada para aceptar peticiones desde http://localhost:4200 (Angular frontend).

## Notas Importantes
- Asegúrate de tener los permisos necesarios en SQL Server
- La base de datos se creará automáticamente al ejecutar las migraciones
- El usuario 'sa' debe tener los permisos necesarios en SQL Server


Este README proporciona la información básica necesaria para configurar y ejecutar el proyecto. La parte más importante es la configuración de la cadena de conexión, donde deberás reemplazar `DESKTOP-RT5MIU3` con el nombre de tu servidor local