# Prueba Técnica IQ Outsourcing!

Este repositorio contiene la resolución de la prueba técnica para la vacante de Desarrollador .NET - Angular

# Requisitos 

 - Mínimo 3 Capas
 - Capa Front en Angular 13 o Superor
 - Capa Back en API Rest C#
 - Capa Datos SQL Server


# Requerimientos

- # Funcionales

- R1 Interfaz y Lógica de Inicio de Sesión. Si no está en la tabla de Usuarios, reportar error. Si está en la tabla de Usuarios, pasar a R2
- R2. Registrar los inicios de sesión correctos en una tabla auditoría.
- R3. Interfaz y lógica de menú para ver los inicios de sesión. Se debe presentar una grilal con todos los inicios de sesión del sistema.
- R4. Interfaz y lógica de Menú para la gestión de Usuarios (CRUD de Usuarios)

-  # No Funcionales
- Acceso a la API através de JWT.
- Aplicar configuraciones de CORS.
- Debe permitir cerrar sesión


# Información del Proyecto

# Backend

## Tecnologías:

 - NET 6
 - Entity Framework
 - SQL Server
 - AutoMapper
 - Json Web Token
 - Web API

## Arquitectura

![Imgur](https://i.imgur.com/jwqfsto.jpg)

Este proyecto implementa una arquitectura limpia

Se usa el principio DDD (Domain Driven Design)

En *Domain* define las reglas del negocio; Entidades, Interfaces para los servicios y repositorios, y objetos de transfencia (DTO)

En la capa *Infrastructure* se implementa la lógica que definirá como se tratarán los objetos hacia la base de datos, se define el tipo de base de datos a usar y la configuracion de las entidades para ser mapeadas a la base de datos.

Esta capa implementa:

 1. UnitOfWork
 2. Conexión hacia la base de datos
 3. Configura el contexto y las tablas con Entity Framework
 4. Repositorios

En la capa *Application* se implementa la lógica del negocio y se configura una librería que será la encargada de manipular los datos y transformarlos de la base de datos hacia el cliente y viceversa.

Esta capa implementa:

1.  Servicios
2.  AutoMapper


En la capa *Presentation* se configura la UI por la que ingresarán y se manejarán las peticiones (endpoints)

Esta capa implementa:

1.  WebApi
2. Inyecta los servicios de las demás capas

*Transversal* es una capa extra multipropósito, la cual no referencia a ninguna otra capa. Es usada para que las demás capas la referencien y hagan uso de sus helpers.

Esta capa implementa:

1. RestException - Clase que se invocará para manejar las excepciones
2. JWT - Clase que se invocará para obtener la información del token


## Patrones utilizados

 - UnitOfWork
 - Repository
 - Singleton
 - Dependency Injection
 - 
## Arquitectura
 - Clean Architecture

# Frontend
## Tecnologías Utilizadas

 - Angular 14
 - Bootstrap
 -  Angular Toastr
 - Angular Router
 - Angular HttpClient
 - Typescript
 - SCSS

## Patrones utilizados

 - Dependency Injection

# Como ejecutar el proyecto

 1. Clonar el repositorio: `https://github.com/F-balanta/IQOusorcing-PruebaTecnica.git`

 2. Ingresar al repositorio y abrir el archivo `appsettings.json` que se encuentra en la ruta `IQOUTSOURCING\IQOUTSOURCING.RestApi`
 3. Modificar el valor del parámetro `CadenaConexion` con la cadena de conexión correspondiente a tu base de datos local (Recuerda que el proyecto se ejecuta sobre SQL Server)
 4. Abrir la consola en la ruta `IQOUTSOURCING\IQOUTSOURCING.RestApi` y ejecutar el comando `dotnet run`
 5. Ahora, en la raiz del proyecto, abrir la carpeta `client-app` , abrir la consola en este directorio y escribir el comando `ng serve -o`

# Autor
Juan Felipe Balanta - Desarrollador de Software
