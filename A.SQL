CREATE OR ALTER PROCEDURE caca @caca1 INT,
                               @caca2 INT OUTPUT
AS
BEGIN
    BEGIN TRY

        IF @caca1 IS NULL
            PRINT 'Valores mal'
            RETURN -1
        
        INSERT INTO CACA
        VALUES (@caca1)

        SET @caca2 = SCOPE_IDENTITY()

    END TRY
    BEGIN CATCH
        PRINT CONCAT(ERROR_NUMBER(),
                     ERROR_LINE(),
                     ERROR_MESSAGE(),
                     ERROR_PROCEDURE())
    END CATCH
END

DECLARE @cacaA1 INT = 2
DECLARE @cacaA2 INT 
DECLARE @return INT

EXEC @return = caca @cacaA1,
                    @cacaA2 OUTPUT

IF @return <> 0
    RETURN

PRINT 'CACA EXITO'

GO
CREATE OR ALTER FUNCTION CACA (@CACA1 INT, @CACA2 INT)
RETURNS INT
AS
BEGIN
    RETURN @CACA1 * @CACA2
END
GO

DECLARE @caca1 INT = 3
DECLARE @caca2 INT = 40
SELECT cacacodigo, dbo.CACA(@caca1, @caca2)
FROM CACA


GO
SELECT *
  INTO CACA_COPIA
  FROM CACA
WHERE 1 = 0
ALTER TABLE CACA
ADD fechaCaca SMALLDATETIME
GO
CREATE OR ALTER TRIGGER TX_CACA ON CACA
INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        DECLARE @transaccion  BIT = @@TRANCOUNT

        IF @transaccion = 0
        BEGIN TRAN

        INSERT INTO CACA_COPIA
        SELECT *,
               GETDATE()
         FROM DELETED

        INSERT INTO CACALIBRO_PERDIDO
        SELECT DELETED.ID,
               CACA.cacaPersona,
               CACALIBRO.codigo,
               GETDATE()
          FROM DELETED, 
               CACALIBRO,
               CACA
         WHERE CACALIBRO.codigoPersona = DELETED.ID
           AND CACALIBRO.devuelto = null

        DELETE FROM CACALIBRO
        WHERE codigoPersona IN (SELECT ID 
                                  FROM DELETED)

        DELETE FROM CACA
        WHERE cacaPersona IN (SELECT ID 
                                FROM DELETED)

        IF @transaccion = 0
        COMMIT
    END TRY
    BEGIN CATCH
        IF @transaccion = 0
        ROLLBACK

        PRINT CONCAT(ERROR_NUMBER(),
                ERROR_LINE(),
                ERROR_MESSAGE(),
                ERROR_PROCEDURE())
    END CATCH
END

DECLARE CUR_CACA CURSOR FOR
SELECT caca
FROM CACA

DECLARE @cacavalor INT

OPEN CUR_CACA
FETCH NEXT CUR_CACA INTO @cacavalor

WHILE @@FETCH_STATUS = 0
BEGIN

        DECLARE CUR_CACA2 CURSOR FOR
        SELECT caca2
        FROM CACA
        
        DECLARE @cacavalor2 INT

        OPEN CUR_CACA2
        FETCH NEXT CUR_CACA2 INTO @cacavalor2

        WHILE @@FETCH_STATUS = 0
        BEGIN
            PRINT @cacavalor2
            FETCH NEXT CUR_CACA2
        END 
        
        CLOSE CUR_CACA2
        DEALLOCATE CUR_CACA2

        PRINT @cacavalor1
        FETCH NEXT CUR_CACA INTO @cacavalor
END
    CLOSE CUR_CACA1
    DEALLOCATE CUR_CACA1



GO
USE TIENDA

EXEC SP_HELP FABRICANTE
EXEC SP_HELP PRODUCTO

GO
DECLARE Cur_NombreFabricante CURSOR FOR
 SELECT nombre
  FROM FABRICANTE

DECLARE @nombreFabricante VARCHAR(100)

OPEN Cur_NombreFabricante

FETCH NEXT FROM Cur_NombreFabricante INTO @nombreFabricante

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE Cur_PrecioTotalProductosFabricante CURSOR FOR
     SELECT precio
       FROM PRODUCTO
      WHERE codigo_fabricante = (SELECT codigo
                                   FROM FABRICANTE
                                  WHERE nombre = @nombreFabricante)

    DECLARE @acumulado DECIMAL(12,2)
    SET @acumulado = 0
    DECLARE @costeTotal DECIMAL(12,2)

    OPEN Cur_PrecioTotalProductosFabricante
    FETCH NEXT FROM Cur_PrecioTotalProductosFabricante INTO @costeTotal

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @acumulado = @acumulado + @costeTotal
            FETCH NEXT FROM Cur_PrecioTotalProductosFabricante INTO @costeTotal
        END

    CLOSE Cur_PrecioTotalProductosFabricante
    DEALLOCATE Cur_PrecioTotalProductosFabricante

    PRINT CONCAT(' Fabricante: ', @nombreFabricante, ' lleva un total de  ', @acumulado, ' € en productos', CHAR(10))

    FETCH NEXT FROM Cur_NombreFabricante INTO @nombreFabricante
END

     CLOSE Cur_NombreFabricante
DEALLOCATE Cur_NombreFabricante


USE JARDINERIA
GO
DECLARE CUR_EMPLEADOS CURSOR FOR
SELECT nombre,
       apellido1,
       apellido2,
       email
  FROM EMPLEADOS

  DECLARE @nombre VARCHAR(50)
  DECLARE @apellido1 VARCHAR(50)
  DECLARE @apellido2 VARCHAR(50)
  DECLARE @Email VARCHAR(100)

  OPEN CUR_EMPLEADOS
  FETCH NEXT FROM CUR_EMPLEADOS INTO @nombre, @apellido1, @apellido2, @email

  WHILE @@FETCH_STATUS = 0
  BEGIN
        PRINT CONCAT('Nombre: ', @nombre , ' ', @apellido1, ' ', @apellido2, CHAR(10),
                     'Email: ', @email, CHAR(10))

        FETCH NEXT FROM CUR_EMPLEADOS INTO @nombre, @apellido1, @apellido2, @email
  END
     CLOSE CUR_EMPLEADOS
DEALLOCATE CUR_EMPLEADOS


EXEC SP_HELP DETALLE_PEDIDOS

DECLARE CUR_PEDIDOS CURSOR FOR
SELECT codPedido
  FROM PEDIDOS

DECLARE @codPedido INT

OPEN CUR_PEDIDOS
FETCH NEXT FROM CUR_PEDIDOS INTO @codPedido

WHILE @@FETCH_STATUS = 0
BEGIN

    DECLARE CUR_COSTEPEDIDO CURSOR FOR
     SELECT precio_unidad,
            cantidad
       FROM DETALLE_PEDIDOS
      WHERE codPedido = @codPedido

    DECLARE @precioUnidad DECIMAL (5,2)
    DECLARE @cantidad INT
    DECLARE @costoTotal DECIMAL (9,2)
    SET @costoTotal = 0

     OPEN CUR_COSTEPEDIDO
    FETCH NEXT FROM CUR_COSTEPEDIDO INTO @precioUnidad, @cantidad

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @costoTotal = @costoTotal + (@cantidad * @precioUnidad)
        FETCH NEXT FROM CUR_COSTEPEDIDO INTO @precioUnidad, @cantidad
    END

     CLOSE CUR_COSTEPEDIDO
DEALLOCATE CUR_COSTEPEDIDO

PRINT CONCAT('Nº Pedido: ', @codPedido, CHAR(10),
            'Coste total: ', @costoTotal, '€', CHAR(10))

FETCH NEXT FROM CUR_PEDIDOS INTO @codPedido
END
    CLOSE CUR_PEDIDOS
    DEALLOCATE CUR_PEDIDOS

CREATE DATABASE PRUEBATRIGGERS
GO
USE PRUEBATRIGGERS
GO
CREATE TABLE ALMACENES (
    codAlmacen INT NOT NULL,
    descripcion VARCHAR(100) NOT NULL, 
    direccion VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,

    CONSTRAINT PK_ALMACENES PRIMARY KEY (codAlmacen)
)

CREATE TABLE PROVEEDORES (
    codProveedor INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,
    deuda DECIMAL(12,2) NOT NULL,
    tipo CHAR(6) NOT NULL,

    CONSTRAINT PK_PROVEEDORES PRIMARY KEY (codProveedor)
)

CREATE TABLE ARTICULOS (
    codArticulo INT NOT NULL ,
    nombre VARCHAR(100) NOT NULL,
    stock INT NULL,
    pvp DECIMAL(9,2) NOT NULL,
    precio_compra DECIMAL(9,2) NOT NULL,
    codProveedor INT NULL,
    codAlmacen INT NOT NULL,


    CONSTRAINT PK_ARTICULOS PRIMARY KEY (codArticulo),
    CONSTRAINT FK_ALMACENES_ARTICULOS FOREIGN KEY (codAlmacen)
    REFERENCES ALMACENES(codAlmacen),
    CONSTRAINT FK_PROVEEDORES_ARTICULOS FOREIGN KEY (codProveedor)
    REFERENCES PROVEEDORES(codProveedor)
)

GO
INSERT INTO ALMACENES
VALUES (1, 'Central Warehouse', '456 Oak St', 'City I'),
       (2, 'West Warehouse', '789 Pine St', 'City J'),
       (3, 'East Warehouse', '123 Cedar St', 'City K'),
       (4, 'North Warehouse', '555 Elm St', 'City L')
GO
INSERT INTO PROVEEDORES
VALUES (1, 'Supplier 1', '777 Maple St', 'City M', 1200.00, 'Type B'),
       (2, 'Supplier 2', '888 Pine St', 'City N', 900.00, 'Type C'),
       (3, 'Supplier 3', '999 Cedar St', 'City O', 1500.00, 'Type A'),
       (4, 'Supplier 4', '111 Oak St', 'City P', 600.00, 'Type B')
GO
INSERT INTO ARTICULOS
VALUES (1, 'Good 1', 80, 25.00, 20.00, 1, 1),
       (2, 'Good 2', 0, 35.00, 30.00, 2, 2),
       (3, 'Good 3', 90, 45.00, 40.00, 3, 2),
       (4, 'Good 4', 0, 55.00, 50.00, 4, 4)

SELECT *
INTO PROVEEDORES_COPIA
FROM PROVEEDORES
WHERE 1 = 0
ALTER TABLE PROVEEDORES_COPIA
ADD fecha SMALLDATETIME

SELECT *
INTO ARTICULOS_INEXISTENTES
FROM ARTICULOS
WHERE 1 = 0
ALTER TABLE ARTICULOS_INEXISTENTES
ADD fecha SMALLDATETIME,
    nombreAntiguoProveedor VARCHAR(50)

GO
CREATE OR ALTER TRIGGER TX_BAJA_PROVEEDOR ON PROVEEDORES
INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        DECLARE @transaction BIT = @@TRANCOUNT

        IF @transaction = 0
        BEGIN TRAN

        INSERT INTO ARTICULOS_INEXISTENTES
        SELECT ARTICULOS.*,
               GETDATE(),
               DELETED.nombre
          FROM DELETED, 
               ARTICULOS
         WHERE DELETED.codProveedor = ARTICULOS.codProveedor
           AND ARTICULOS.stock = 0

        INSERT INTO PROVEEDORES_COPIA
        SELECT *,
               GETDATE()
          FROM PROVEEDORES
         WHERE codProveedor IN (SELECT codProveedor
                                  FROM DELETED)

        DELETE FROM ARTICULOS
         WHERE codProveedor IN (SELECT codProveedor
                                 FROM DELETED)
           AND stock = 0
        
        UPDATE ARTICULOS
        SET codProveedor = NULL
        WHERE codProveedor IN (SELECT codProveedor
                                 FROM DELETED)
        AND stock > 0

        DELETE FROM PROVEEDORES
        WHERE codProveedor IN (SELECT codProveedor
                                FROM DELETED)
        
        IF @transaction = 0
        COMMIT
    END TRY
    BEGIN CATCH
        IF @transaction = 0
        ROLLBACK
        
        PRINT CONCAT(ERROR_NUMBER(),
                ERROR_LINE(),
                ERROR_MESSAGE(),
                ERROR_PROCEDURE())
    END CATCH
END
GO

BEGIN TRAN
    BEGIN TRY
        DELETE FROM PROVEEDORES
        WHERE codProveedor = 1
           OR codProveedor = 2
        COMMIT
    END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

SELECT *
FROM PROVEEDORES

SELECT *
FROM PROVEEDORES_COPIA

SELECT *
FROM ARTICULOS

SELECT *
FROM ARTICULOS_INEXISTENTES
