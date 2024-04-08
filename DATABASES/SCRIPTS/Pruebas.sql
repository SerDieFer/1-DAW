USE JARDINERIA

-- DECLARE @varPrecio TINYINT
-- SET @varPrecio = 75

-- SELECT *
-- FROM PRODUCTOS
-- WHERE precio_venta >= @varPrecio

-- DECLARE @codCategoria CHAR(2)
-- SET @codCategoria = 'FR'

-- DECLARE @nombre VARCHAR(100)
-- SET @nombre = 'pera'

-- SELECT *
-- FROM CATEGORIA_PRODUCTOS ct, PRODUCTOS p
-- WHERE ct.codCategoria = p.codCategoria
-- AND LOWER(p.nombre) LIKE CONCAT(@nombre, '%')
-- AND UPPER(ct.codCategoria) = @codCategoria

-- DECLARE @precioMin DECIMAL(9,2)
-- DECLARE @precioMax DECIMAL(9,2)

-- SET @precioMin = 8.69

-- SELECT TOP(1) @precioMin = precio_venta
--   FROM PRODUCTOS
--  ORDER BY precio_venta ASC

--  PRINT @precioMin

--  EXEC sp_columns EMPLEADOS

-- DECLARE @primerNombre  VARCHAR(50)
-- DECLARE @apellido1     VARCHAR(50)
-- DECLARE @apellido2     VARCHAR(50)

-- SELECT @primerNombre = nombre,
--        @apellido1 = apellido1,
--        @apellido2 = apellido2
--   FROM EMPLEADOS
--  WHERE codEmpleado = 27

--  PRINT CONCAT(@primerNombre,' ', @apellido1, ' ', @apellido2)

 
-- DECLARE @i INT = 1

-- WHILE @i <= 200
-- BEGIN
--   IF (@i%7 = 0 AND @i <> 7)
--     BEGIN
--       PRINT @i
--       BREAK
--     END
--   SET @i += 1
-- END

-- DECLARE @firstCodCliente INT
-- DECLARE @lastCodCliente INT
-- DECLARE @nameCliente VARCHAR(50)

-- SELECT @lastCodCliente = MAX(codCliente),
--        @firstCodCliente = MIN(codCliente)
-- FROM CLIENTES

-- WHILE @firstCodCliente <= @lastCodCliente
-- BEGIN
--   SET @nameCliente = NULL
--   SET @nameCliente  = (SELECT nombre_cliente
--                          FROM CLIENTES
--                         WHERE codCliente = @firstCodCliente)
--   IF @nameCliente IS NOT NULL
--   BEGIN
--     PRINT @nameCliente
--   END
--   SET @firstCodCliente += 1
-- END


GO
CREATE OR ALTER PROCEDURE holiwi
AS
BEGIN
  PRINT 'Holis lokis'
END 

EXEC holiwi

----------------------------------------------------------------

GO
CREATE OR ALTER PROCEDURE guessNumber 
                            @number INT
AS
BEGIN
  PRINT CONCAT('The number is: ', @number)
  RETURN -1
END
GO

DECLARE @number INT = FLOOR(RAND() * (100 - 1 + 1)) + 1
DECLARE @return INT
EXEC @return = guessNumber @number

IF @return <> -1
  RETURN
PRINT 'Succesful procedure'

----------------------------------------------------------------

GO
CREATE OR ALTER PROCEDURE guessNumber
                            @number INT,
                            @hemlo VARCHAR(5)
AS
BEGIN
  PRINT CONCAT('The number is: ', @number)
  PRINT @hemlo
  RETURN -1
END
GO

DECLARE @number INT = FLOOR(RAND() * (100 - 1 + 1)) + 1
DECLARE @hemlo VARCHAR(5) = 'Hemlo'
DECLARE @return INT

EXEC @return = guessNumber
                @number,
                @hemlo

IF @return <> -1
  RETURN
PRINT 'Succesful procedure'


--------------------------------------------------------------------

GO
CREATE OR ALTER PROCEDURE printClientName 
                            @cliCod INT,
                            @cliName VARCHAR(125) OUTPUT
AS
BEGIN
  SELECT @cliName = CONCAT('The client name is: ', nombre_cliente, CHAR(10), 'Whose representative is: ', nombre_contacto, ' ', apellido_contacto)
  FROM CLIENTES
  WHERE codCliente = @cliCod

IF @cliName IS NULL
  PRINT CONCAT('The the client Nº', @cliCod, ' does not exist')
  RETURN -1
END

GO
DECLARE @cliCod INT = 9
DECLARE @return INT
DECLARE @cliName VARCHAR(125)

EXEC @return = printClientName 
                @cliCod,
                @cliName OUTPUT

IF @return <> -1
  RETURN

PRINT @cliName
PRINT CONCAT (CHAR(10), 'Succesful procedure')
