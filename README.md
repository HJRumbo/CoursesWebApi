# Back-end prueba ténica SICO

Este es el back-end de la prueba técnica para la empresa SICO.

Puede ejecutar el Back-end y luego el [Front-end](https://github.com/HJRumbo/CourseWeb), desarrollado en Angular, para probar toda la solución. 

## Probar 
Además, puede probar este Back-end en su máquina local con ayuda de Swagger (https://localhost:{your_local_port}/swagger/index.html)

## Base de datos
Utilicé el ORM Entity Framework.
Para crear la base de datos, puede ejecutar los comandos de entity framework para realizar la migración de cualquiera de las siguientes dos maneras.

### Comandos para la consola de administrador de paquetes
1. add-migration MigrationName.
2. update-database.

### Comandos Dotnet CLI
Nesecitamos estar en el proyecto 'DataAccess' y desde allí ejecutar los siguientes comandos

1. dotnet ef migrations add MigrationName -s ../CoursesWebApi
2. dotnet ef database update -s ../CoursesWebApi

De igual manera, dejo el [script de la base de datos](https://github.com/HJRumbo/CoursesWebApi/blob/master/Script.sql) con las tablas y algunos datos de prueba (De cursos y estudiantes) que puede utilizar para probar. 
