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