-- RECUERDA PARA OBTENER EL VALOR DE UNA CLAVE IDENTITY A CREAR

    SET @nuevaIdentity = SCOPE_IDENTITY()


-- RECUERDA PARA CONTAR FILAS ACTUALIZADAS

    DECLARE @cuenta INT
    SET @cuenta = @@ROWCOUNT

-- RECUERDA PARA CONTAR NUMERO DE TRANSACCIONES PENDIENTES

    DECLARE @transacciones INT
    SET @transacciones = @@TRANCOUNT

-- RECUERDA BLOQUE CATCH

		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
                      'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
                      'LINE: ', ERROR_LINE(), CHAR(10),
                      'PROCEDURE: ', ERROR_PROCEDURE())

------------------------------------------------------------------------------------------------

-- ESTRUCTURA PROCEDIMIENTO

    GO                          -- ASIGNAMOS VARIABLES Y TIPOS
    CREATE OR ALTER PROCEDURE X @element1 INT,
                                @element2 INT OUTPUT
    AS
    BEGIN
        BEGIN TRY

        -- CONDICIONES QUE EN CASO DE DAR ERROR DEVUELVEN (RETURN) -1

        -- SI HAY DIVERSAS OPERACIONES
                -- SINO INTRODUCIR SIN BLOQUE TRAN
        BEGIN TRAN

            --UPDATE, DELETE, INSERT, SELECT, SET, ETC

        COMMIT
        END TRY
        BEGIN CATCH
        
            -- SI HAY TRANSACCIONES PENDIENTES VOLVER AL ESTADO ANTERIOR
            IF @@TRANCOUNT > 0
            ROLLBACK
            
            -- BLOQUE CATCH DE ERRORES

        END CATCH
    END

    -- DECLARAMOS VARIABLES Y SUS VALORES
        -- EN CASO DE SER OUTPUT NO SE DECLARA SU VALOR

    DECLARE @theElement1 INT = 1
    DECLARE @theElement2 INT
    
    -- DECLARAMOS UN RETORNO POR CODIGO DE ERROR

    DECLARE @return INT

    -- EJECUTAMOS ESTE CON EL PROCEDIMIENTO
        -- LE ASIGNAMOS LAS NUEVAS VARIABLES

    EXEC @return = X @theElement1,
                     @theElement2

    -- BLOQUE COMPROBANTE DEL RETURN

    IF @return <> 0
        BEGIN
            RETURN
        END
    ELSE
        BEGIN
            PRINT CONCAT('Elemento OUTPUT es :' , @theElement2)
        END

---------------------------------------------------------------------------------------------------

-- ESTRUCTURA FUNCION  

GO                          -- ASIGNAMOS VARIABLES Y TIPOS
CREATE OR ALTER FUNCTION X (@element1 INT, @element2 INT)
RETURNS INT -- LE ASIGNAMOS QUE TIPO DE VALOR DEVUELVE
AS
BEGIN

    -- DECLARAMOS PARAMETROS A USAR Y LES SETEAMOS MEDIANTE SELECT
        -- EN CASO DE DEVOLVER UNA TABLA TENDREMOS QUE HACER UNA SELECT CON LOS PARAMETROS DESEADOS
    DECLARE @id INT = @elent1 * @element2

    -- DEVOLVEMOS EL RESULTADO
    RETURN @id
END
GO

-- DECLARAMOS LOS VALORES DE LAS VARIABLES A USAR EN ESA FUNCION

DECLARE @cod1 INT = 2
DECLARE @cod2 INT = 1

-- HACEMOS LA SELECT Y LLAMAMOS A LA FUNCION

SELECT codX, dbo.X(@cod1,@cod2)
  FROM X

---------------------------------------------------------------------------------------------------

-- ESTRUCTURA TRIGGER

GO                               -- TABLA EN LA QUE SEA ACTIVA
CREATE OR ALTER TRIGGER TX_TABLA ON TABLA
-- AFTER INSERT / UPDATE / DELTE 
INSTEAD OF INSERT, UPDATE, DELETE
AS
BEGIN
    BEGIN TRY
         DECLARE @hayTransaccion BIT = @@TRANCOUNT
        
        IF @hayTransaccion = 0
        BEGIN TRAN

            -- CODIGO DEL TRIGGER
                -- RECUERDA QUE LA TABLA INTERNA ES INSERTED PARA ACTUALIZADOS Y NUEVOS
                -- MIENTRAS QUE LA TABLA INTERNA ES DELETED PARA BORRADOS

                -- RECUERDA QUE SI SE HACE UN BORRADO TIENE QUE SER EN CASCADA

        IF @hayTransaccion = 0
        COMMIT
    END TRY
    BEGIN CATCH

    IF @hayTransaccion = 0
        ROLLBACK

        PRINT CONCAT('CODERROR: ', ERROR_NUMBER(),
                     ' MSG: ', ERROR_MESSAGE(),
                     ' LINEA: ', ERROR_LINE(),
                     ' PROCEDURE: ', ERROR_PROCEDURE())
    END CATCH
END


-- RECUERDA QUE PARA CREAR BACKUPS SIN DATOS ES

SELECT *
  INTO TABLA_BACKUP
  FROM TABLA
 WHERE 1 = 0

    -- EN CASO DE NECESITAR POSTERIORES ALTERACIONES

    ALTER TABLE TABLA_BACKUP
    ADD X INT -- EL TIPO QUE NECESITES (NORMALMENTE FECHA)

---------------------------------------------------------------------------------------------------

-- RECUERDA PARA SABER EL ESTADO DEL FETCH
    WHILE @@FETCH_STATUS = 0

-- ESTRUCTURA CURSORES

-- CREAR EL CURSOR PARA UNA SELECT DETERMINADA

DECLARE Cur_X CURSOR FOR
 SELECT X
   FROM X

-- ASIGNAR VARIABLES PARA LOS VALORES DESEADOS
DECLARE @x INT

-- ABRIR EL INICIO DEL CURSOR Y DARLE LA PRIMERA LECTURA EN LAS VARIABLES ANTERIORMENTE CREADAS

OPEN Cur_X
FETCH NEXT FROM Cur_X INTO @x

-- CREAMOS EL BUCLE QUE RECORRERÁ ESE CURSOR

WHILE @@FETCH_STATUS = 0
BEGIN

    -- CODIGO A USAR EN EL CURSOR
        -- EN CASO DE ANIDACIÓN HAY QUE REPETIR LO MISMO PERO INTERNAMENTE
            --    DECLARE Cur_Y CURSOR FOR
            --     SELECT Y
            --       FROM Y

            --    DECLARE @y INT

            --       OPEN Cur_Y
            --      FETCH NEXT FROM Cur_X INTO @y

            --      WHILE @@FETCH_STATUS = 0
            --      BEGIN
            --         --CODIGO A USAR EN EL CURSOR
            --         PRINT @y
            --         FETCH NEXT FROM Cur_X INTO @y
            --      END

            --      CLOSE Cur_Y
            --      DEALLOCATE Cur_Y

    -- MOSTRAMOS RESULTADO DESEADO DEPENDE DE QUE
    PRINT @x

    -- PASAMOS A LA SIGUIENTE LECTURA EN EL CURSOR
    FETCH NEXT FROM Cur_X INTO @x
END

-- CERRAMOS EL CURSOR Y DESALOJAMOS DE LA MEMORIA LOS DATOS

CLOSE Cur_X
DEALLOCATE Cur_X