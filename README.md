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

1. Abrir la terminal y ubicarse en la carpeta que se desee descargar el proyecto.
2. Desde la terminal ejecutar el siguiente comando: git clone https://github.com/diegodurandaza6/CollectedBack.git
3. Reubicarse a la raiz del proyecto (folder clonado desde GitHub)
4. Desde Visual Studio 2022 abrir la solución de nombre 'CollectedSln'
5. Seleccionar los proyectos 'Api.Gateway', 'Collected.Api', y 'Security.Api' para ejecución con inicio de multiples proyectos.