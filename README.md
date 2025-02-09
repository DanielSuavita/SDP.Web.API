# SPD.Web.API

Api Prueba t�cnica para el trabajo de Desarrollador para Codifico. Hecho en .NET 9, SQL Server 2019 y Angular. Est� compuesto de 2 soluciones:

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

## Configuraci�n

### Base de Datos

Se debe ejecutar el script SQL dentro de la carpeta de Scripts que se encuentra dentro del proyecto del Backend.

### Aplicaci�n Backend

Se debe descargar el c�digo fuente de Github, abrirlo en Visual Studio 2022, restaurar los paquetes NuGet, compilar y ejecutar.

De forma alternativa se puede ejecutar en Visual Studio Code y en la terminal ejecutar lo siguientes comandos:

```powershell
dotnet restore
dotnet build
dotnet run --project src/SDP.Web.API
```

### Aplicaci�n Frontend

Se debe descargar el c�digo fuente de Github, abrirlo en Visual Studio Code, restaurar los paquetes NPM y ejecutar. As� se puede desde la terminal ubic�ndose sobre el proyecto ya descargado.

```powershell
npm i
ng serve -o
```

## Descripci�n de ejecuci�n de una prueba

### Prerrequisitos

- Se debe haber seguido paso a paso la configuraci�n
- Tener un navegador basado en Chromium (Google Chrome, Opera, Brave)

Una vez configurado y ejecutado el proyecto aparecer� la pantalla de inicio. 

Opcionalmente podemos dirigimos a la URL [http://localhost:4200](http://localhost:4200/) para ver la pantalla de inicio desde alg�n navegador.

### Ver las fechas prevista de ventas

Nos dirigimos a la URL [http://localhost:4200](http://localhost:4200/), all� se podr�n visualizar y filtrar los clientes con el cuadro de texto en la esquina superior derecha de la lista de clientes con fecha prevista.

### Ver �rdenes

Para ver las �rdenes por cliente se debe dar clic en el bot�n �VIEW ORDER�. All� aparecer� una ventana emergente donde aparece un listado en forma de tabla que nos da los datos de las �rdenes de compra.

Una vez finalizada la observaci�n de las �rdenes puede dar clic en el bot�n �Close� en la parte inferior derecha de la ventana emergente para cerrar la ventana emergente.

### Crear Nueva Orden de Compra

Para ver las �rdenes por cliente se debe dar clic en el bot�n �NEW ORDER�. All� aparecer� una ventana emergente donde aparece un formulario para agregar los datos de la nueva orden de compra.

Una vez finalizado el diligenciamiento se debe dar clic en el bot�n �Save� en la parte inferior derecha de la ventana emergente para guardar la orden. De ah� aparecer� una notificaci�n en la parte inferior de la pantalla informando si se cre� la orden de compra o hubo un error.