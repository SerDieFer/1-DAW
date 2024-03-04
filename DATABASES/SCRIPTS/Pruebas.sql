USE JARDINERIA

DECLARE @varPrecio TINYINT
SET @varPrecio = 75

SELECT *
FROM PRODUCTOS
WHERE precio_venta >= @varPrecio

DECLARE @codCategoria CHAR(2)
SET @codCategoria = 'FR'

DECLARE @nombre VARCHAR(100)
SET @nombre = 'pera'

SELECT *
FROM CATEGORIA_PRODUCTOS ct, PRODUCTOS p
WHERE ct.codCategoria = p.codCategoria
AND LOWER(p.nombre) LIKE CONCAT(@nombre, '%')
AND UPPER(ct.codCategoria) = @codCategoria

DECLARE @precioMin DECIMAL(9,2)
DECLARE @precioMax DECIMAL(9,2)

SET @precioMin = 8.69

SELECT TOP(1) @precioMin = precio_venta
  FROM PRODUCTOS
 ORDER BY precio_venta ASC

 PRINT @precioMin

 EXEC sp_columns EMPLEADOS

DECLARE @primerNombre  VARCHAR(50)
DECLARE @apellido1     VARCHAR(50)
DECLARE @apellido2     VARCHAR(50)

SELECT @primerNombre = nombre,
       @apellido1 = apellido1,
       @apellido2 = apellido2
  FROM EMPLEADOS
 WHERE codEmpleado = 27

 PRINT CONCAT(@primerNombre,' ', @apellido1, ' ', @apellido2)

 
        