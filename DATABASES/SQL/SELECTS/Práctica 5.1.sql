-----------------------------------------------------------------
-- Ejercicio 5.1. Obtén las siguientes consultas con funciones --
-----------------------------------------------------------------


/* Obtén el valor absoluto de un número entero (-17) -> resultado 17 */


/* Número parte entera de un número decimal (35.789) -> resultado 35 */


/* Resto de una división entre dos números enteros (15 y 4) */


/* Potencia de un número y su exponente: 5 elevado a 3 -> resultado = 125 */


/* Raíz cuadrada de un número (81) */


/* Número aleatorio decimal entre 0 y 1 */


/* Número aleatorio decimal entre 0 y 10 */


/* Número aleatorio decimal entre 0 y 100 */


/* Redondea el número 45.267 a un decimal */


/* Obtén el signo del número (-45.6) */


/* Concatena estas cadenas en una sola: José García López */


/* Convierte la cadena a mayúsculas: Estudio FP en el IES Mare Nostrum */


/* Convierte la cadena a minúsculas: Estudio FP en el IES Mare Nostrum */


/* Obtén el principio de una cadena (el nombre) de José García López -> José */


/* Obtener una parte final de la cadena anterior (apellido2) -> García */


/* Obtener una parte central de la cadena anterior (apellido1) -> López */


/* Obtener la longitud la cadena José García López -> 17 */


/* Obtén la letra del siguiente DNI 12345678M -> M */


/* Eliminar de la cadena '   Juan López García   ' los espacios al principio y al final*/


/* Obtén la longitud de la cadena '   Juan López García   ' */


/* Obtén la longitud de la cadena '   Juan López García   ' sin los espacios (utiliza la función del ejercicio anterior para quitarlos) */


/* Reemplaza en la cadena 'SQL Tutorial', SQL por HTML */


/* Muestra 'SQL Tutorial' de forma inversa */


/* Obtener la FECHA y HORA actual */


/* Añadir 10 días a la FECHA ‘03/05/2023’ */


/* Añadir 2 años a la FECHA ‘29/10/2022’ */


/* Diferencia de días entre las FECHAS: 10/02/2023 y 25/03/2023 */


/* Obtener el valor del DÍA de la FECHA ACTUAL */
SELECT DAY(GETDATE());

/* Obtener el valor del MES de la FECHA ACTUAL */
SELECT MONTH(GETDATE());

/* Obtener el valor del AÑO de la FECHA ACTUAL */
SELECT YEAR(GETDATE());

/*Obtener nombre del mes con letras de la fecha 19/03/2023 */
SELECT DATENAME(MONTH,'2023-03-19');

/* Utilizando la función CHARINDEX() obtén la palabra 'viernes' de la frase 'Hoy es el último viernes del año'
Debes utilizar también la función LEFT y/o RIGHT
Nota: Su equivalente en Oracle es la función INSTR() */

    -- Solución utilizando variables declaradas y CHARINDEX + SUBSTRING

DECLARE @texto VARCHAR(100)
DECLARE @busca VARCHAR(10)
    SET @texto = 'Hoy es el último viernes del año'
    SET @busca =  'viernes'

SELECT CHARINDEX(@busca, @texto)
SELECT LEN('viernes')
SELECT SUBSTRING('Hoy es el último viernes del año', 18, 7)

    -- Solución utilizando CHARINDEX y LEFT o RIGHT
    -- Solución en la que NO se indican los 7 caracteres que queremos seleccionar con LEFT o RIGHT

SELECT RIGHT(
/* Cadena a recortar desde la izquierda */    LEFT('Hoy es el último viernes del año', 
/* Busca posición inicial de viernes */       CHARINDEX('viernes','Hoy es el último viernes del año') + LEN('viernes')-1), 
/* Designa hasta donde llega la longitud a recortar */  LEN('viernes'))


/* Supón que tenemos una tabla llamada PIE_FIRMA que consta de dos campos (no se hará con la tabla, sino con strings)
    - fechaFirma DATE
    - lugarFirma VARCHAR(100)

    A partir de la siguiente SELECT, genera el siguiente pie de firma a este:
    'En Alicante, a 8 de junio de 2022' */

DECLARE @fechaFirma DATE
DECLARE @lugarFirma VARCHAR(10)
    SET @fechaFirma = '2022-06-08'
    SET @lugarFirma = 'Alicante'

 SELECT CONCAT('En ', @lugarFirma, ', a ', DAY(@fechaFirma ), ' de ',
        DATENAME(MONTH, @fechaFirma ), ' de ', YEAR(@fechaFirma ))


/* Utiliza la función ASCII() para obtener el valor ASCII de un carácter
Para el carácter A debe devolver 65 */

SELECT ASCII('A'), CHAR(65+32)

/* Investiga el uso de la función TRANSLATE() y haz un ejemplo de uso */

SELECT TRANSLATE('Hoy es el último viernes del año', 'oi', 'ea')

/* Investiga el uso de la función REPLICATE() y haz un ejemplo de uso */

SELECT REPLICATE('Holiwi ', 5)

/* Investiga el uso de la función SPACE() y haz un ejemplo de uso */

SELECT CONCAT('Hola,', SPACE(10), 'que tal todo?')