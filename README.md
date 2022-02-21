# WebAPINubimetrics
Proyecto realizado para superar el Challenge propuesto por Nubimetrics

## Resumen técnico

Se creó una solución con los 2 proyectos requeridos:
El proyecto API llamado WebAPINubimetrics se encarga de las tareas referidas al Punto 1 del challenge, conteniendo un controller para consumir los servicios de Mercadolibre y otro Controller para realizar el ABM de usuarios 
El proyecto API llamado WebAPINubimetrics2 se encarga de las tareas referidas al Punto 2 del challenge, conteniendo un solo Controller.
Ambas están realizadas con .Net Core 5.0, IDE de Visual Studio 2019, lenguaje de programación C# y base de datos en SQL Server para el ABM, para el cual se utilizó las herramientas de Scaffolding que Visual Studio proveé. Se testeó la misma interactuando con Swagger, ya incorporado en el framework, el cual también permite su documentacion. 

## Despliege y ejecución

## Pre-requisitos
* Instalaciones necesarias: Visual studio 2019 version 16.11.5 o superior, .Net Framework Versión 4.8.04084 o superior, .NET CORE 5.0 o superior, SQL Express 2017, SQL Server Managment Studio, Swagger, Git integrado con Visual Studio para el versionado y NUnit.Framework para proyecto TEST
* * Paquetes instalados desde NuGet: Swashbuckle.AspNetCore, Microsoft.AspNet.WebApi.Core, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer.

Para ejecutar el programa de manera local: Clonar el repositorio o descargarlo Zipeado desde GitHub a una carpeta en su máquina. Abrir la solución desde en Visual Studio 2019 o posterior y correrlo.
Cabe aclarar que para poder desplegar las API requeridas para cada punto se debe cambiar al proyecto de inicio correspondiente, para esto seguir los siguientes pasos: 
Una vez abierta la solución en Visual Studio -> Abrir el Explorador de Soluciones -> click derecho sobre el proyecto correspondiente (  WebAPINubimetrics o WebAPINubimetrics2) -> click en la opción “Establecer como proyecto de inicio” y luego correr el proyecto:
Imagen de ejemplo:
![image](https://user-images.githubusercontent.com/32108894/154866381-24473d3a-9893-4d77-b2c6-71ebe8991d14.png)

Una vez levantado el programa deberia visualizar una pantalla como la siguiente, mostrando la UI que brinda Swagger:

![image](https://user-images.githubusercontent.com/32108894/154866457-3ba0979a-6f4f-401e-b404-86a1eb578498.png)

# Base de datos

## Para crear una base de datos local idéntica a la utilizada, correr el siguiente script en una nueva consulta en SQL SERVER Managment Studio:

```
USE [master]
GO
/****** Object:  Database [WebAPINubimetrics]    Script Date: 20/02/2022 13:16:17 ******/
CREATE DATABASE [WebAPINubimetrics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebAPINubimetrics', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WebAPINubimetrics.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebAPINubimetrics_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WebAPINubimetrics.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebAPINubimetrics] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebAPINubimetrics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebAPINubimetrics] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET ANSI_NULLS ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET ANSI_PADDING ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET ARITHABORT ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [WebAPINubimetrics] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [WebAPINubimetrics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebAPINubimetrics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebAPINubimetrics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET RECOVERY FULL 
GO
ALTER DATABASE [WebAPINubimetrics] SET  MULTI_USER 
GO
ALTER DATABASE [WebAPINubimetrics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebAPINubimetrics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebAPINubimetrics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebAPINubimetrics] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebAPINubimetrics] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebAPINubimetrics] SET QUERY_STORE = OFF
GO
USE [WebAPINubimetrics]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20/02/2022 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WebAPINubimetrics] SET  READ_WRITE 
GO

USE [WebAPINubimetrics]
GO

INSERT INTO [dbo].[User]
           ([Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           ('Pablo'
           ,'Sanabria'
           ,'pablosanabria@hotmail.com'	
           ,'123456')
GO

INSERT INTO [dbo].[User]
           ([Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           ('Miguel'
           ,'Angel'	
           ,'miguelangel@gmail.com'	
           ,'123456')
GO

INSERT INTO [dbo].[User]
           ([Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           ('Pedro'
           ,'Diaz'	
           ,'pedrodiaz@hotmail.com'	
           ,'123456')
GO

```
Con esto ya se debería tener creada la Base de datos "WebAPINubimetrics" con una tabla "User" populada con 3 registros.
* Luego dentro de la solución en Visual Studio buscar el archivo "appsettings.json" y modificar el connectionstring de manera que el servidor quede apuntando a su servidor local. Para esto ingresar el mismo en la sección Data source, como se indica en la imagen:
![image](https://user-images.githubusercontent.com/32108894/154866831-075d4cde-711c-40e7-aae5-9859a8c62b22.png)

Conectarse a la base de datos con SQL SERVER Managment Studio:

* Nombre del servidor: Nombre del Servidor SQL local de su máquina
* Autenticacion: Autenticacion de Windows
* Nombre de la BD:  WebAPINubimetrics

## Borrar todos los registros de la tabla y sus Keys
*-Por defecto la base de datos se encontrará cargada con 3 registros
* Ejecutar la siguiente consulta:
```
USE [WebAPINubimetrics]
GO

DELETE FROM [dbo].[User] WHERE ID IS NOT NULL;
USE [WebAPINubimetrics];
DBCC CHECKIDENT([dbo.User], RESEED, 0);
GO
```

## Pruebas

### Función GET Paises:
Para ejecutar pruebas desde Swagger realizar los siguientes pasos, hacer click en el endpoint deseado, por ejemplo en la Función Get de Paises:
![image](https://user-images.githubusercontent.com/32108894/154958484-d8a59509-9d91-42d3-bbea-bd0c1a7e557f.png)
Se desplegará una pantala como la siguiente, en donde debemos hacer click en el boton "Try it out":
![image](https://user-images.githubusercontent.com/32108894/154958736-020bd514-4b57-4dff-a182-65a0a978b5a6.png)
Luego de presionar el botón, el mismo desaparecerá y se mostraran 2 nuevos botones "Cancel", para cancelar la ejecución y "Execute" para ejecutar la acción, en este caso previo a la ejecución debemos colocar el IdPais (por Ej: AR), ya que es obligatorio:
![image](https://user-images.githubusercontent.com/32108894/154959629-1e2e816d-4410-416d-873b-e7868fa788c7.png)
Presionamos el boton "Execute" y deberiamos tener la siguiente respuesta:
#### *	Prueba superada
Como se ve en la siguiente imagen obtenemos un Json con los datos provenientes del endpoint, y el codigo Http. Si queremos realizar una nueva ejecución presionamos el botón "Clear"
![image](https://user-images.githubusercontent.com/32108894/154960117-7a288e51-7835-4849-bc05-495752d98200.png)

#### * Prueba Fallida
En la siguiente imagen vemos la respuesta que se obtiene cuando se coloca un IdPais incorrecto, por ejemplo en este caso "BR"
![image](https://user-images.githubusercontent.com/32108894/154960813-7ce04367-c586-413d-9635-9c579f4fcaf6.png)

### A continuación se visualizan algunos casos mas de pruebas que se realizaron para testear la API:

### Función POST Usarios:

#### *	Prueba superada
![image](https://user-images.githubusercontent.com/32108894/154966309-61e414e9-1075-484d-910f-ed427274ddc5.png)
![image](https://user-images.githubusercontent.com/32108894/154966373-016763e0-fb59-4087-bde4-70d649b81ec6.png)


#### * Prueba Fallida
![image](https://user-images.githubusercontent.com/32108894/154965571-8086e2b7-f165-4e9b-b2aa-7beb30485a2d.png)


### Función Get Currencies (WebAPINubimetrics2):

#### *	Prueba superada
![image](https://user-images.githubusercontent.com/32108894/154969071-ea652414-bd06-4e20-afaa-00169f5aa0b8.png)
![image](https://user-images.githubusercontent.com/32108894/154969258-268c57de-931f-4bd2-bd91-82bc1e2d697a.png)

#### * Prueba Fallida
![image](https://user-images.githubusercontent.com/32108894/154971105-81170b08-df20-4bf5-89bb-0cf5d35ed606.png)


NOTA IMPORTANTE: el endpoint https://api.mercadolibre.com/currencies/ devuelve 2 monedas (VEF y VES) que en el endpoint https://api.mercadolibre.com/currency_conversions/search?from=VEF&to=USD devuelven el siguiente error:
```
{
  "message": "VEF/VES currency convertion is not allowed",
  "error": "forbidden",
  "status": 403,
  "cause": [
  ]
}

```
Por lo que se decidió colocar una validación para que las mismas no sean tenidas en cuenta.
