# CollectedBack
Aplicación back prueba fullstack

Recomendaciones generales:

# Usuario para obtención del token del MS de seguridad
- Usuario admin
{
  "userName": "dduran",
  "password": "Admin123*"
}

Para la visualización del reporte desde visual satudio 2022 se debe instalar la siguiente herramienta:
https://marketplace.visualstudio.com/items?itemName=ProBITools.MicrosoftRdlcReportDesignerforVisualStudio2022

O desde VS2022 ingresamos al menú Extensiones > Administrar Extensiones. Y filtramos por RDLC, esto nos permitirá descargar desde el IDE esta extensión para la visualización de reportes desde el entorno de desarrollo. Posteriormente a la descarga e instalacion volvemos al menu de Administrar Extensiones y validamos en las instalaciones instaladas que el diseñador de informes RDLC esté habilitado para su uso.

Para el desarrollo de la solución Front se utilizaron las siguientes versiones de tecnologías, las cuales describo a continuación:

dot net 6
ReportDesignerforVisualStudio2022
OS: win32 x64

Pasos para la correcta descarga de código y ejecución de la aplicación back

Pre-requisito:
Ejecutar el siguiente script en base de datos:

USE [DiegoDuran]
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'diego')
BEGIN
    EXEC('CREATE SCHEMA [diego]')
    PRINT 'Esquema [diego] creado.'
END
ELSE
BEGIN
    PRINT 'El esquema [diego] ya existe.'
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[diego].[JwtAuth]'))
BEGIN
	CREATE TABLE [diego].[JwtAuth](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[token] [text] NULL,
		[expiration] [datetime] NULL
	) ON [PRIMARY]
	
	PRINT 'Tabla JwtAuth creada correctamente'
END
ELSE
BEGIN
	print 'Tabla JwtAuth ya existe'
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[diego].[control_consolidado_recaudos]'))
BEGIN
	CREATE TABLE [diego].[control_consolidado_recaudos](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[fecha] [date] NULL,
		[ultima_ejecucion] [datetime] NULL,
		[en_ejecucion] [bit] NULL
	) ON [PRIMARY]

	PRINT 'Tabla control_consolidado_recaudos creada correctamente'
END
ELSE
BEGIN
	print 'Tabla control_consolidado_recaudos ya existe'
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[diego].[recaudos]'))
BEGIN
	CREATE TABLE [diego].[recaudos](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[estacion] [varchar](10) NULL,
		[sentido] [varchar](15) NULL,
		[hora] [tinyint] NULL,
		[categoria] [varchar](5) NULL,
		[cantidad] [int] NULL,
		[valorTabulado] [decimal](12, 2) NULL,
		[fecha] [date] NULL
	) ON [PRIMARY]

	PRINT 'Tabla recaudos creada correctamente'
END
ELSE
BEGIN
	PRINT 'Tabla recaudos ya existe'
END

1. Abrir la terminal y ubicarse en la carpeta que se desee descargar el proyecto.
2. Desde la terminal ejecutar el siguiente comando: git clone https://github.com/diegodurandaza6/CollectedBack.git
3. Reubicarse a la raiz del proyecto (folder clonado desde GitHub)
4. Desde Visual Studio 2022 abrir la solución de nombre 'CollectedSln'
5. Seleccionar los proyectos 'Api.Gateway', 'Collected.Api', y 'Security.Api' para ejecución con inicio de multiples proyectos.