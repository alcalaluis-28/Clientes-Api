# Clientes-Api

🔗 **Repositorio de GitHub:** https://github.com/alcalaluis-28/Clientes-Api

## 1. Descripción del proyecto

Clientes-Api es un proyecto académico desarrollado en C# con ASP.NET Core Web API, orientado a la gestión de productos mediante una API REST. El sistema utiliza SQL Server como base de datos y Entity Framework Core para el acceso y manejo de la información.

## 2. Objetivo del proyecto

Desarrollar y probar una API REST que permita consultar, registrar, actualizar y eliminar productos mediante solicitudes HTTP, verificando su funcionamiento y la comunicación con la base de datos.

## 3. Tecnologías utilizadas

- C# 
- Visual Studio
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- SQL Server Management Studio (SSMS)
- Postman
- Git y GitHub

## 4. Estructura del proyecto

- **Controllers:** contiene los controladores que gestionan las solicitudes HTTP.
- **Data:** contiene el contexto de datos utilizado para interactuar con SQL Server.
- **Models:** contiene las clases que representan las entidades del sistema, como Producto.
- **appsettings.json:** permite configurar opciones de la aplicación y la conexión a la base de datos.
- **Program.cs:** contiene la configuración e inicialización de la aplicación.

## 5. Funcionalidades de la API

La API contempla las siguientes operaciones para la gestión de productos:

- **GET:** consultar todos los productos y buscar un producto por su identificador.
- **POST:** registrar un nuevo producto.
- **PUT:** actualizar la información de un producto existente.
- **DELETE:** eliminar un producto mediante su identificador.

Las operaciones verifican la existencia de los registros cuando corresponde y devuelven respuestas HTTP según el resultado de la solicitud.

## 6. Base de datos

Se utiliza SQL Server para almacenar la información de los productos. La tabla correspondiente contiene campos relacionados con el identificador, nombre, descripción, precio, garantía y número de serie.

Entity Framework Core facilita el acceso a los datos desde la aplicación mediante el contexto de datos.

## 7. Instalación y ejecución

1. Clonar o descargar el repositorio desde GitHub.
2. Abrir la solución del proyecto en Visual Studio.
3. Verificar que los paquetes NuGet necesarios estén instalados.
4. Configurar la cadena de conexión de SQL Server en el archivo de configuración correspondiente.
5. Comprobar que la base de datos y la tabla de productos estén disponibles.
6. Compilar y ejecutar el proyecto desde Visual Studio.
7. Utilizar Postman para probar los endpoints de la API.

## 8. Pruebas de funcionamiento

Las pruebas se realizan utilizando Postman para enviar solicitudes HTTP y verificar las respuestas de la API.

Se consideran las operaciones GET, POST, PUT y DELETE, comprobando las consultas, el registro de productos, la actualización de información y la eliminación de registros.

## 9. Autor

**Luis Alcala Meneses**

Proyecto académico desarrollado para el curso Seminario de Complementación Práctica III.

**Instructor:** Jhon Fracia Minaya.
