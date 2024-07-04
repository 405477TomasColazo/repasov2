# utn-prog3-ef-flight

Se deberá realizar un sitio web para una aerolínea en donde a continuación se detallarán las páginas
webs a crear:

1. Primera página que debe llamarse “login.html” la cual deberá permitir ingresar un mail y
contraseña para poder acceder al sistema.
Se deberá validar (Jquery validate) que el mail sea correcto (formato email) y no esté en
vacío, lo mismo para el password. Cuando se hace el submit se debe verificar que el usuario exista en la base de datos,
en caso de existir debe redirigir a la siguiente página enviando por query string
el mail de usuario, en caso contrario se deberá mostrar mensaje de error. (Tabla Usuarios)
2. Segunda página donde se deba realizar el submit del formulario para dar de alta un piloto,
en donde se deberá validar (Jquery validate) los campos obligatorios (todos). En caso de
algún error de validación se deberá mostrar un alert con dicho error, y si las validaciones son
exitosas se deberá mostrar el mensaje de éxito mostrando además el email recibido por
query string. (Tabla Pilotos)
3. Se debe permitir editar un piloto el cual debe ser cargado en base al email provisto en el querystring
y luego enviar la nueva información a la API para su correcta edicion (no se debe permitir cambiar el email). 
En caso de no existir el piloto debe crearlo.


| Formulario                            |
|---------------------------------------|
| Alta de Piloto            |           |
| Nombre                    | Apellido  |
| Cantidad de hs de vuelo   | Sexo      |
| Nacionalidad              |           |


Aclaraciones:

* El campo “Nacionalidad” deberá ser un select con los siguientes ítems cargados en una tabla en la base de datos:
    - Seleccionar
    - Argentina
    - Uruguay
    - Chile

* Se debe cargar un usuario con email email es “tup2022@tup.com.ar” y el password sea “123456” en la base de datos para poder hacer las pruebas.

Aclaración:
• TODAS LAS PÁGINAS DEBERÁN ESTAR DESARROLLADAS USANDO EL FRAMEWORK DE
BOOTSTRAP, UTILIZANDO LAS CLASES, Y LOS ESTILOS PERTINENTES PARA QUE DICHAS
PÁGINAS SEAN RESPONSIVES Y SE LOGREN ADAPTAR A TODO TIPO DE PANTALLA.
• CON LA FINALIDAD DE QUE LA CARPETA DEL PROYECTO PESE LO MENOS POSIBLE, SE
DEBERAN REFERENCIAR LAS IMÁGENES, SCRIPTS, Y ARCHIVOS CSS A SUS RESPECTIVOS
LINKS DE INTERNET Y NO REFERENCIARLOS LOCALMENTE.
• TODOS LOS FORMULARIOS DEBERÁN ESTAR COLOCADOS EN UN CONTENEDOR QUE
POSEA MÁRGENES EN LA IZQUIERDA Y EN LA DERECHA. 