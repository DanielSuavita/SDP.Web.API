# SPD.Web.API

Api Prueba técnica para el trabajo de Desarrollador para Codifico. Hecho en .NET 9, SQL Server 2019 y Angular. Está compuesto de 2 soluciones:

**El Backend del Proyecto**

https://github.com/DanielSuavita/SDP.Web.API

**El Frontend del Proyecto**

https://github.com/DanielSuavita/SDP.Web.App

## Prerrequisitos

Para configurarlo y dejarlo listo para ejecutarse se necesita lo siguiente:

- Visual Studio 2022.
- SDK .NET 9.
- SQL Server 2019.
- NodeJS para instalar las dependencias de Angular.

## Configuración

### Base de Datos

Se debe ejecutar el script SQL dentro de la carpeta de Scripts que se encuentra dentro del proyecto del Backend.

### Aplicación Backend

Se debe descargar el código fuente de Github, abrirlo en Visual Studio 2022, restaurar los paquetes NuGet, compilar y ejecutar.

De forma alternativa se puede ejecutar en Visual Studio Code y en la terminal ejecutar lo siguientes comandos:

```powershell
dotnet restore
dotnet build
dotnet run --project src/SDP.Web.API
```

### Aplicación Frontend

Se debe descargar el código fuente de Github, abrirlo en Visual Studio Code, restaurar los paquetes NPM y ejecutar. Así se puede desde la terminal ubicándose sobre el proyecto ya descargado.

```powershell
npm i
ng serve -o
```

## Descripción de ejecución de una prueba

### Prerrequisitos

- Se debe haber seguido paso a paso la configuración
- Tener un navegador basado en Chromium (Google Chrome, Opera, Brave)

Una vez configurado y ejecutado el proyecto aparecerá la pantalla de inicio. 

Opcionalmente podemos dirigimos a la URL [http://localhost:4200](http://localhost:4200/) para ver la pantalla de inicio desde algún navegador.

### Ver las fechas prevista de ventas

Nos dirigimos a la URL [http://localhost:4200](http://localhost:4200/), allí se podrán visualizar y filtrar los clientes con el cuadro de texto en la esquina superior derecha de la lista de clientes con fecha prevista.

### Ver Órdenes

Para ver las órdenes por cliente se debe dar clic en el botón “VIEW ORDER”. Allí aparecerá una ventana emergente donde aparece un listado en forma de tabla que nos da los datos de las órdenes de compra.

Una vez finalizada la observación de las órdenes puede dar clic en el botón “Close” en la parte inferior derecha de la ventana emergente para cerrar la ventana emergente.

### Crear Nueva Orden de Compra

Para ver las órdenes por cliente se debe dar clic en el botón “NEW ORDER”. Allí aparecerá una ventana emergente donde aparece un formulario para agregar los datos de la nueva orden de compra.

Una vez finalizado el diligenciamiento se debe dar clic en el botón “Save” en la parte inferior derecha de la ventana emergente para guardar la orden. De ahí aparecerá una notificación en la parte inferior de la pantalla informando si se creó la orden de compra o hubo un error.