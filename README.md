# ge01-microservice-v1

Una API REST desarrollada con **C# y .NET 10** para el manejo de autenticación básica (Login) y un CRUD completo para el almacenamiento de clientes de una pequeña empresa. Utiliza **Entity Framework** como ORM y **SQL Server** como motor de base de datos.

---

## 🛠️ Requisitos previos

Antes de comenzar, asegúrate de tener instalado lo siguiente:

- [.NET 10 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/10.0) — necesario para compilar el proyecto.
- [.NET Runtime](https://dotnet.microsoft.com/es-es/download/dotnet/10.0) — necesario para ejecutar el compilado generado.
- [Docker Desktop](https://docs.docker.com/desktop/setup/install/windows-install/) — necesario para levantar los contenedores de la aplicación y la base de datos.

---

## 🚀 Instalación y ejecución

Sigue estos pasos en orden para poner en marcha el proyecto:

1. Instala el **SDK de .NET 10** usando el enlace de requisitos previos.
2. Instala el **Runtime de .NET** usando el enlace de requisitos previos.
3. Instala **Docker Desktop** usando el enlace de requisitos previos.
4. Importa la **colección de Postman** compartida por correo electrónico para ejecutar las peticiones.
5. Ejecuta el siguiente comando para construir el contenedor de Docker:
```bash
   docker-compose build
```
6. Ejecuta el siguiente comando para levantar el contenedor:
```bash
   docker-compose up
```
7. ¡Listo! Ya puedes realizar peticiones al WebService.

---

## 📦 Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| C# / .NET 10 | Lenguaje y framework principal |
| Entity Framework | ORM para manejo de base de datos |
| SQL Server | Motor de base de datos |
| Docker | Contenedorización del ambiente |

---

## 📬 Endpoints disponibles

> Importa la colección compartida por correo para ver todos los endpoints disponibles.
