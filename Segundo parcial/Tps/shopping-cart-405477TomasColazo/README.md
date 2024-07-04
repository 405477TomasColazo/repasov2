[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/Gq8O6FUs)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=15330719&assignment_repo_type=AssignmentRepo)
Consigna del Proyecto

Descripción General

Desarrollar una aplicación web que permita a los usuarios iniciar sesión y, tras autenticarse,
realizar operaciones de CRUD (Crear, Leer, Actualizar, Borrar) 
sobre productos, La API se implementará con .NET Core utilizando AutoMapper, FluentValidation y
JWT Tokens para la autenticación. La base de datos se creará con enfoque Code First
usando Entity Framework Core y un patrón de repositorio. 

¡OPCIONAL!
Gestionar un carrito de compras, 
el carrito de compras se conectará a la API de Mercado Pago para realizar pagos.


Requisitos del Frontend

Página de Inicio de Sesión:

Debe tener un formulario con campos para Email y Password.

Debe enviar las credenciales al endpoint de inicio de sesión de la API.

Si las credenciales son correctas, debe redirigir al usuario a la página de gestión de productos con su email como parámetro de consulta.

Página de Gestión de Productos:

Debe mostrar una lista de productos.

Debe tener un formulario para agregar un nuevo producto con los campos Nombre, Descripción y Precio.

Cada producto en la lista debe tener opciones para editar y eliminar el producto.

Debe permitir la edición de los productos existentes.

Página de Carrito de Compras:

Debe mostrar una lista de productos agregados al carrito.

Debe permitir la eliminación de productos del carrito.

Debe tener un botón para realizar el pago que se conecte a la API de Mercado Pago.

Requisitos del Backend

Autenticación con JWT Tokens:

Crear un endpoint para iniciar sesión que verifique las credenciales y devuelva un token JWT.

Validación con FluentValidation:

Validar los datos de entrada para las operaciones de creación y actualización de productos.

Patrón de Repositorio y Code First con Entity Framework Core:

Configurar el contexto de la base de datos.

Crear repositorios para manejar las operaciones de la base de datos.

Integración con la API de Mercado Pago:

Crear endpoints para gestionar el carrito de compras y realizar pagos utilizando la API de Mercado Pago.


¡Opcional la conexión con la api de mercado pago!

Documentación para la api:

https://www.mercadopago.com.ar/developers/es/docs
https://www.mercadopago.com.ar/developers/es/docs/sdks-library/server-side
https://github.com/mercadopago/sdk-dotnet

# Tablas de la Base de Datos

## Users

| Columna       | Tipo   | Descripción               |
|---------------|--------|---------------------------|
| Id            | int    | Clave primaria (PK)       |
| Email         | string | Correo electrónico        |
| PasswordHash  | string | Hash de la contraseña     |

## Products

| Columna       | Tipo     | Descripción               |
|---------------|----------|---------------------------|
| Id            | int      | Clave primaria (PK)       |
| Name          | string   | Nombre del producto       |
| Description   | string   | Descripción del producto  |
| Price         | decimal  | Precio del producto       |

## Carts

| Columna       | Tipo     | Descripción                     |
|---------------|----------|---------------------------------|
| Id            | int      | Clave primaria (PK)             |
| UserId        | int      | Clave foránea (FK) a Users      |
| TotalAmount   | decimal  | Monto total del carrito         |

## CartItems

| Columna       | Tipo     | Descripción                           |
|---------------|----------|---------------------------------------|
| Id            | int      | Clave primaria (PK)                   |
| CartId        | int      | Clave foránea (FK) a Carts            |
| ProductId     | int      | Clave foránea (FK) a Products         |
| Quantity      | int      | Cantidad de productos en el carrito   |
| Price         | decimal  | Precio del producto en el carrito     |
