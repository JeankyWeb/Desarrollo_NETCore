# Proyecto NETCore
Este es un proyecto de Sistema de Gestion de Transacciones.

## Requisitos del Proyecto
- contar con Visual Studio

El proyecto consta de cuatro proyectos dentro de una solución, siguiendo la arquitectura hexagonal:
- test.domain
Entidad: Transaction
Atributos:
Id (GUID)
Amount (decimal)
Currency (string)
Date (DateTime)
Status (string)
Interfaces: Definición de servicios y repositorios que manejarán la lógica de negocio y las operaciones sobre las bases de datos.

- test.application
Servicios de Negocio: Implementación de la lógica para:
Crear una nueva transacción.
Editar una transacción existente.
Consultar transacciones por ID o por estado.

- test.infraestructure
Repositorios:
MongoDB: Almacenamiento de transacciones.
SQL Server: Almacenamiento de logs de transacciones procesadas.
Modelo de Datos: Configuración necesaria para ambas bases de datos.
Contexto de SQL Server: Implementación mediante Entity Framework o Dapper (a elección).
Repositorio de MongoDB: Uso del cliente MongoDB.

- test.webapi
API RESTful: Exposición de los siguientes endpoints:
POST /transactions: Crear una nueva transacción.
PUT /transactions/{id}: Editar una transacción existente.
GET /transactions/{id}: Obtener una transacción por ID.
GET /transactions/status/{status}: Obtener transacciones por estado.
Seguridad:
Uso de JWT para asegurar los endpoints, permitiendo acceso solo a usuarios autenticados.
Implementación de un endpoint de login para generar el JWT (puede simularse con un usuario y contraseña fijos).
