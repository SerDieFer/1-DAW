-------------------------
--					   --
--  UD8 (PROC & FUNC)  -- 
--					   --
-------------------------

-----------------------------------------------------------------
--															   --
--  NOTA: Recuerda cuidar la limpieza del código               --
--  (tabulaciones, nombres de tablas en mayúscula,             --
--  nombres de variables en minúscula, poner comentarios       --
--  sin excederse, código organizado y fácil de seguir, etc.)  --
--                                                             --
-----------------------------------------------------------------

USE JARDINERIA

-----------------------------------------------------------------
--                                                             --
--  1. Implementa un procedimiento llamado 'getNombreCliente'  --
--  que devuelva el nombre de un cliente a partir de su        --
--  código.                                                    --
--                                                             --
--  Parámetros de entrada:  codCliente INT                     --
--	Parámetros de salida:   nombreCliente VARCHAR(50)          --
--	Tabla:                  CLIENTES                           --
--                                                             --
--	El procedimiento devolverá 0 si finaliza correctamente.    --
--															   --
--	Debes utilizar TRY/CATCH, validación de parámetros y       --
--  transacciones si fueran necesarias.                        --
--                                                             --
--	Comprueba que el funcionamiento es correcto realizando     --
--  una llamada desde un script y comprobando la               --
--  finalización del mismo.                                    --
--                                                             --
--  Recuerda utilizar en el script:                            --
--    	EXEC @ret = getNombreCliente @codCliente,              --
--            @nombreCliente OUTPUT                            --
--      IF @ret <> 0 ...                                       --
--                                                             --
-----------------------------------------------------------------


EXEC SP_HELP CLIENTES
GO
CREATE OR ALTER PROCEDURE getClientName
						  @cliCod INT,
						  @cliName VARCHAR(50) OUTPUT
AS
BEGIN
   BEGIN TRY 
   	SELECT @cliName = CONCAT('The client name is: ', nombre_cliente)
      FROM CLIENTES
     WHERE codCliente = @cliCod

	IF @cliName IS NULL
		BEGIN
			PRINT CONCAT('The client Nº', @cliCod, ' does not exist')
			RETURN -1
		END
   END TRY
   BEGIN CATCH
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
   END CATCH
END

GO
DECLARE @cliCod INT = 4000
DECLARE @return INT
DECLARE @cliName VARCHAR(50)
   EXEC @return = getClientName
			      @cliCod,
			      @cliName OUTPUT

	 IF @return <> 0
	    RETURN

  PRINT CONCAT(@cliName, CHAR(10), CHAR(10), 'Succesful procedure')

------------------------------------------------------------------------------
--                                                                          --
--  2. Implementa un procedimiento llamado 'getPedidosPagosCliente'         --
--  que devuelva el número de pedidos y de pagos a partir de un             --
--  código de cliente.                                                      --
--                                                                          --
--  Parámetros de entrada:  codCliente INT                                  --
--  Parámetros de salida:   numPedidos INT                                  --
--                          numPagos INT                                    --
--  Tabla:                  CLIENTES                                        --
--                                                                          --
--  El procedimiento devolverá 0 si finaliza correctamente.                 --
--  Debes utilizar TRY/CATCH, validación de parámetros y transacciones      --
--  si fueran necesarias.                                                   --
--                                                                          --
--  Comprueba que el funcionamiento es correcto realizando una llamada      --
--  desde un script y comprobando la finalización del mismo.                --
--                                                                          --
--  Recuerda utilizar en el script:                                         --
--      EXEC @ret = getPedidosPagosCliente @codCliente,                     --
--                                         @numPedidos OUTPUT,              --
--                                         @numPagos OUTPUT                 --
--      IF @ret <> 0 ...                                                    --
--                                                                          --
------------------------------------------------------------------------------

EXEC SP_HELP PAGOS
GO

CREATE OR ALTER PROCEDURE getClientOrderPayments
						  @cliCod INT,
						  @cliOrdersCount INT OUTPUT,
						  @cliPaymentsCount INT OUTPUT
AS
BEGIN
	BEGIN TRY 
		IF NOT EXISTS (SELECT *
						 FROM CLIENTES
						WHERE codCliente = @cliCod) 
		BEGIN
			PRINT 'The selected client does not exist.';
			RETURN -1
		END

		SELECT @cliOrdersCount = COUNT(codPedido)
		FROM PEDIDOS
		WHERE codCliente = @cliCod

		SELECT @cliPaymentsCount = COUNT(id_transaccion)
		FROM PAGOS
		WHERE codCliente = @cliCod

		IF (@cliOrdersCount = 0 AND @cliPaymentsCount = 0)
		BEGIN
			PRINT 'The selected client does not have orders or payments'
			RETURN -1
		END
	END TRY
	BEGIN CATCH
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
	END CATCH
END

GO
DECLARE @cliCod INT = 3
DECLARE @return INT
DECLARE @cliOrdersCount INT
DECLARE @cliPaymentsCount INT
   EXEC @return = getClientOrderPayments
			      @cliCod,
			      @cliOrdersCount OUTPUT,
			      @cliPaymentsCount OUTPUT

	 IF @return <> 0
		RETURN

  PRINT CONCAT('Client Nº', @cliCod, CHAR(10),
			   'Orders: ', @cliOrdersCount, CHAR(10),
			   'Payments: ', @cliPaymentsCount, CHAR(10),
			    CHAR(10),'Successful procedure.');

----------------------------------------------------------------------------
--                                                                        --
--   3. Implementa un procedimiento llamado 'crearCategoriaProducto'      --
--   que inserte una nueva categoría de producto                          --
--   en la base de datos JARDINERIA.                                      --
--                                                                        --
--   Parámetros de entrada: codCategoria CHAR(2),                         --
--                          nombre VARCHAR(50),                           --
--                          descripcion_texto VARCHAR(MAX),               --
--                          descripcion_html VARCHAR(MAX),                --
--                          imagen VARCHAR(256)                           --
--                                                                        --
--   Parámetros de salida: <ninguno>                                      --
--   Tabla: CATEGORIA_PRODUCTOS                                           --
--                                                                        --
--   # Se debe comprobar que todos los parámetros obligatorios están      --
--   informados. Si falta alguno, devolver -1 y finalizar.                --
--                                                                        --
--   # Se debe comprobar que la categoría no exista previamente en la     --
--   tabla. Si ya existe, imprimir mensaje indicándolo, devolver -1 y     --
--   finalizar.                                                           --
--                                                                        --
--   El procedimiento devolverá 0 si finaliza correctamente.              --
--                                                                        --
--   Debes utilizar TRY/CATCH, validación de parámetros y transacciones   --
--   si fueran necesarias.                                                --
--                                                                        --
--   * Comprueba que el funcionamiento es correcto realizando una l       --
--   lamada desde un script y comprobando la finalización del mismo.      --
--   																      --
--                                                                        --
--   Recuerda utilizar en el script:                                      --
--      EXEC @ret = crearCategoriaProducto ...                            --
--      IF @ret <> 0 ...                                                  --
--                                                                        --
----------------------------------------------------------------------------


EXEC SP_HELP CATEGORIA_PRODUCTOS
GO

CREATE OR ALTER PROCEDURE createProductCategory
						  @categoryCod CHAR(2),
						  @categoryName VARCHAR(50),
                          @txt_description VARCHAR(MAX), 
                          @html_description VARCHAR(MAX),
                          @image VARCHAR(255)
AS
BEGIN
	BEGIN TRY 
		IF EXISTS (SELECT *
				   FROM CATEGORIA_PRODUCTOS
				   WHERE codCategoria = @categoryCod)
		BEGIN
			PRINT 'The selected category already exists.';
			RETURN -1
		END

		IF (@categoryCod IS NULL OR @categoryCod = '' OR LEN(@categoryCod) <> 2 OR @categoryCod LIKE '%[0-9]%')
        BEGIN
            PRINT 'Category code must have 2 characters and use only alphabetical characters. Example: BD';
            RETURN -1
        END

		IF (@categoryName IS NULL OR @categoryName LIKE '%[0-9]%')
		BEGIN
			PRINT 'Category name must contain only alphabetical characters. Example: Food';
            RETURN -1
		END
		
		INSERT INTO CATEGORIA_PRODUCTOS (codCategoria, nombre, descripcion_texto, descripcion_html, imagen)
		VALUES (@categoryCod, @categoryName, @txt_description, @html_description, @image)
		
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
	END CATCH
END

GO
DECLARE @categoryCod CHAR(2) = 'WP'
DECLARE @categoryName VARCHAR(50) = 'Weapons'
DECLARE @txt_description VARCHAR(MAX)
DECLARE @html_description VARCHAR(MAX)
DECLARE @image VARCHAR(255)
DECLARE @return INT
   EXEC @return = createProductCategory
			      @categoryCod,
			      @categoryName,
			      @txt_description,
			      @html_description,
			      @image

     IF @return <> 0
	    RETURN

PRINT CONCAT('Category: ', @categoryCod, CHAR(10),
			 'Name: ', @categoryName, CHAR(10),
			  CHAR(10), 'Successful procedure.')


--------------------------------------------------------------------------------
--                                                                            --
--  4. Implementa un procedimiento llamado 'acuseRecepcionPedidosCliente'     --
--  que actualice la fecha de entrega de los pedidos a la fecha del momento   --
--  actual y su estado a 'Entregado' para el codCliente pasado por parámetro  --
--  parámetro y solo para los pedidos que estén en estado 'Pendiente'         --
--  y no tengan fecha de entrega.                                             --
--                                                                            --
--  Parámetros de entrada: codCliente INT                                     --
--	Parámetros de salida:  numPedidosAct INT                                  --
--	Tabla: PEDIDOS                                                            --
--                                                                            --
--	* Comprueba que el funcionamiento es correcto realizando una llamada      --
--  desde un script y comprobando la finalización del mismo.                  --
--                                                                            --
--  Ayuda: Recuerda utilizar:                                                 --
--         	  EXEC @ret = acuseRecepcionPedidosCliente ...                    --
--         	  IF @ret <> 0 ...                                                --
--                                                                            --
--	Ayuda para obtener el número de registros actualizados:                   --
--                                                                            --
--	Se puede hacer una SELECT antes de ejecutar la sentencia de               --
--  actualización o bien utilizar la variable @@ROWCOUNT                      --
--                                                                            --
--------------------------------------------------------------------------------

EXEC SP_HELP PEDIDOS
GO

CREATE OR ALTER PROCEDURE updateReceiptClientOrderReceived
						  @clientCod INT,
						  @countUpdatedReceivedOrders INT OUTPUT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT *
						 FROM CLIENTES
						WHERE codCliente = @clientCod)
		BEGIN
			PRINT 'The selected client do not exists.';
			RETURN -1
		END

		IF NOT EXISTS (SELECT *
						 FROM PEDIDOS
						WHERE codCliente = @clientCod)
		BEGIN
			PRINT 'The selected client did not order anything.';
			RETURN -1
		END

		IF (@clientCod IS NULL)
		BEGIN
			PRINT 'Obligatory parameters not introduced'
			RETURN -1
		END

			UPDATE PEDIDOS
			   SET fecha_entrega = GETDATE(),
			       codEstado = 'E'
			 WHERE codCliente = @clientCod
			   AND fecha_entrega IS NULL 
			   AND codEstado <> 'E'

			   SET @countUpdatedReceivedOrders = @@ROWCOUNT
	END TRY
	BEGIN CATCH
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
	END CATCH
END

GO
DECLARE @clientCod INT = 1
DECLARE @countUpdatedReceivedOrders INT
DECLARE @ordersUpdateString VARCHAR(100)
DECLARE @return INT
   EXEC @return = updateReceiptClientOrderReceived
			      @clientCod,
				  @countUpdatedReceivedOrders OUTPUT

	IF @return <> 0
	RETURN

	IF (@countUpdatedReceivedOrders <> 0)
		SET @ordersUpdateString = CONCAT('The client has ', @countUpdatedReceivedOrders, ' recieved orders updated.')
	ELSE
		SET @ordersUpdateString = 'The client does not have orders to update'

    PRINT CONCAT('Client Code: ', @clientCod, CHAR(10),
			     @ordersUpdateString, CHAR(10),
			     CHAR(10), 'Successful procedure.')

---------------------------------------------------------------------------------
--                                                                             --
--  5. Implementa un procedimiento llamado 'crearOficina'                      --
--  que inserte una nueva oficina en JARDINERIA.                               --
--                                                                             --
--  Parámetros de entrada: codOficina CHAR(6)                                  --
--                         ciudad VARCHAR(40)                                  --
--                         pais VARCHAR(50)                                    --
--                         codigo_postal CHAR(5)                               --
--                         telefono VARCHAR(15)                                --
--                         linea_direccion1 VARCHAR(100)                       --
--                         linea_direccion2 VARCHAR(100) (no obligatorio)      --
--                                                                             --
--  Parámetros de salida: <ninguno>                                            --
--  Tabla: OFICINAS                                                            --
--                                                                             --
--  # Se debe comprobar que todos los parámetros obligatorios están            --
--   informados, sino devolver -1 y finalizar                                  --
--                                                                             --
--  # Se debe comprobar que el codOficina no exista previamente en la tabla,   --
--  y si así fuera, imprimir un mensaje indicándolo y se devolverá -1          --
--                                                                             --
--  El procedimiento devolverá 0 si finaliza correctamente.                    --
--                                                                             --
--  Debes utilizar TRY/CATCH, validación de parámetros y transacciones         --
--  si fueran necesarias.                                                      --
--                                                                             --
--  * Comprueba que el funcionamiento es correcto realizando una llamada       --
--  desde un script y comprobando la finalización del mismo.                   --
--                                                                             --
--  Ayuda: Recuerda utilizar:                                                  --
--         	  EXEC @ret = crearOficina ...                                     --
--         	  IF @ret <> 0 ...                                                 --
--                                                                             --
---------------------------------------------------------------------------------

EXEC SP_HELP OFICINAS
GO
CREATE OR ALTER PROCEDURE createOffice
						  @officeCod CHAR(6),
                          @officeCity VARCHAR(40),
                          @officeCountry VARCHAR(50),
                          @officePostalCode CHAR(5),
                          @officePhone VARCHAR(15),
                          @officeAdress1 VARCHAR(100),
                          @officeAdress2 VARCHAR(100)
AS
BEGIN
	BEGIN TRY 
		IF EXISTS (SELECT *
				     FROM OFICINAS
				    WHERE codOficina = @officeCod)
		BEGIN
			PRINT 'The selected office already exists.';
			RETURN -1
		END

		IF (@officeCod IS NULL OR @officeCod = '' OR LEN(@officeCod) <> 6 OR SUBSTRING(@officeCod, 4, 1) <> '-')
        BEGIN
            PRINT 'Office code must have 6 characters and be in the format "AAA-AA". Example: ELX-ES';
            RETURN -1
        END

        IF (@officeCity IS NULL OR @officeCity = '' OR @officeCity LIKE '%[0-9]%')
        BEGIN
            PRINT 'Office city must contain only alphabetical characters. Example: London';
            RETURN -1
        END

        IF (@officeCountry IS NULL OR @officeCountry = '' OR @officeCountry LIKE '%[0-9]%')
        BEGIN
            PRINT 'Office country must contain only alphabetical characters. Example: Spain';
            RETURN -1
        END

        IF (@officePostalCode IS NULL OR @officePostalCode = '' OR LEN(@officePostalCode) <> 5
		    OR @officePostalCode NOT LIKE '[0-9][0-9][0-9][0-9][0-9]')
        BEGIN
            PRINT 'Office postal code must contain exactly 5 numerical characters. Example: 03007';
            RETURN -1
        END

        IF (@officePhone IS NULL OR @officePhone = '' OR LEN(@officePhone) <> 9 
		   OR @officePhone NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
        BEGIN
            PRINT 'Office phone must contain exactly 9 numerical characters. Example: 612345678';
            RETURN -1
        END

		INSERT INTO OFICINAS (codOficina, ciudad, pais, codPostal, telefono, 
							  linea_direccion1, linea_direccion2)
	    VALUES (@officeCod, @officeCity, @officeCountry, @officePostalCode, @officePhone, 
			    @officeAdress1, @officeAdress2)
	END TRY
	BEGIN CATCH
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
	END CATCH
END

GO
DECLARE @officeCod CHAR(6) = 'ELX-ES'
DECLARE @officeCity VARCHAR(40) = 'Elx'
DECLARE @officeCountry VARCHAR(50) = 'España'
DECLARE @officePostalCode CHAR(5) = '03201'
DECLARE @officePhone VARCHAR(15) = '612345678'
DECLARE @officeAdress1 VARCHAR(100) = 'Avenida Ocho Once Ocho'
DECLARE @officeAdress2 VARCHAR(100)
DECLARE @return INT
   EXEC @return = createOffice
				    @officeCod,
				    @officeCity,
				    @officeCountry,
				    @officePostalCode,
				    @officePhone,
				    @officeAdress1,
				    @officeAdress2

	IF @return <> 0
	   RETURN

	PRINT CONCAT ('Office Code: ', @officeCod, CHAR(10),
				  'Office City: ', @officeCity, CHAR(10),
				  'Office Country: ', @officeCountry, CHAR(10),
				  'Office Postal Code: ', @officePostalCode, CHAR(10),
				  'Office Phone: ', @officePhone, CHAR(10),
				  'Office Principal Adress: ', @officeAdress1, CHAR(10),
				  'Office Secondary Adress: ', @officeAdress2, CHAR(10),
				  'Successful procedure.')

--------------------------------------------------------------------------------------
--                                                                                  --
--  6. Implementa un procedimiento llamado 'cambioJefes' que actualice el           --
--  jefe/a de los empleados/as del que tuvieran inicialmente (ant_codEmplJefe)      -- 
--  al nuevo/a (des_codEmplJefe)                                                    --
--                                                                                  --
--  NOTA: Es un proceso que ocurre si alguien asciende de categoría.                --
--                                                                                  --
--  Parámetros de entrada: ant_codEmplJefe INT                                      --
--                         des_codEmplJefe INT                                      --
--                                                                                  --
--  Parámetros de salida: numEmpleados INT (número de empleados                     --
--                                          que han actualizado  su jefe)           --
--                                                                                  --
--  Tabla: EMPLEADOS                                                                --
--                                                                                  --
--  * Comprueba que el funcionamiento es correcto realizando una                    --
--  llamada desde un script y comprobando la finalización del mismo.                --
--                                                                                  --
--  Ayuda: Recuerda utilizar:                                                       --
--         	  EXEC @ret = cambioJefes ...                                           --
--         	  IF @ret <> 0 ...                                                      --
--                                                                                  --
--------------------------------------------------------------------------------------

EXEC SP_HELP EMPLEADOS
GO
CREATE OR ALTER PROCEDURE interchangeBoss
						  @oldBossCode INT,
                          @newBossCode INT,
						  @newBossEmployeeQuantity INT OUTPUT
AS
BEGIN
	BEGIN TRY 
		IF NOT EXISTS (SELECT *
				         FROM EMPLEADOS
				        WHERE codEmpleado = @oldBossCode)
		BEGIN
			 PRINT 'The selected boss do not exist.';
			RETURN -1
		END
		IF NOT EXISTS (SELECT *
				         FROM EMPLEADOS
				        WHERE codEmpleado = @newBossCode)
		BEGIN
			 PRINT 'The selected employee do not exist.';
			RETURN -1
		END

		IF (@oldBossCode IS NULL OR @oldBossCode = '' OR @oldBossCode NOT LIKE '%[0-9]%')
        BEGIN
             PRINT 'The selected boss code must have only numeric values. Example: 12';
            RETURN -1
        END

		IF (@newBossCode IS NULL OR @newBossCode = '' OR @newBossCode NOT LIKE '%[0-9]%')
        BEGIN
             PRINT 'The selected employee code must have only numeric values. Example: 2';
            RETURN -1
        END

		BEGIN TRAN

		  UPDATE EMPLEADOS
		     SET codEmplJefe = NULL
		   WHERE codEmpleado = @newBossCode

		   SET @newBossEmployeeQuantity = @@ROWCOUNT

		  UPDATE EMPLEADOS
			 SET codEmplJefe = @newBossCode
		   WHERE codEmplJefe = @oldBossCode

		     SET @newBossEmployeeQuantity += @@ROWCOUNT

		  UPDATE EMPLEADOS
		  	 SET codEmplJefe = @newBossCode
		   WHERE codEmpleado = @oldBossCode

		     SET @newBossEmployeeQuantity += @@ROWCOUNT
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE(), CHAR(10),
					  'PROCEDURE: ', ERROR_PROCEDURE())
	END CATCH	
END

GO
DECLARE @newBossCode INT = 2
DECLARE @oldBossCode INT = 1
DECLARE @newBossEmployeeQuantity INT
DECLARE @return INT
   EXEC @return = interchangeBoss
				    @oldBossCode,
				    @newBossCode,
				    @newBossEmployeeQuantity OUTPUT

	 IF @return <> 0
	    RETURN

     PRINT CONCAT ('A quantity of ', @newBossEmployeeQuantity, ' employees had the boss updated',
	 			   CHAR(10), CHAR(10), 'Successful procedure.')


---------------------------------------------
--                                         --
--  7. Implementa una función llamada      --
--  getCostePedidos que reciba como        --
--  parámetro un codCliente y devuelva     --
--	el coste de todos los pedidos          --
--  realizados por dicho cliente.          --
--	                                       --
--	Recuerda que debes incluir la SELECT   --
--  y comprobar el funcionamiento.         --
--                                         --
---------------------------------------------

	-- WAY 1 // ONLY 1 FUNCTION

EXEC SP_HELP DETALLE_PEDIDOS
GO

CREATE OR ALTER FUNCTION getTotalOrdersCost (@clientCode INT)
RETURNS DECIMAL(14,2)
AS
BEGIN
	DECLARE @return DECIMAL(14,2)
		SET @return = (SELECT ISNULL(SUM(cantidad*precio_unidad), 0)
						 FROM DETALLE_PEDIDOS
						WHERE codPedido IN (SELECT codPedido
											  FROM PEDIDOS
											 WHERE codCliente = @clientCode))
	 RETURN @return
END

GO
SELECT codCliente, 
	   dbo.getTotalOrdersCost(codCliente) AS totalOrdersCost
  FROM CLIENTES
 WHERE codCliente = 9

	-- WAY 2 // USES TWO FUNCTIONS

EXEC SP_HELP DETALLE_PEDIDOS
GO

CREATE OR ALTER FUNCTION getOrderCost (@orderCode INT)
RETURNS DECIMAL(14,2)
AS
BEGIN
	DECLARE @return DECIMAL(14,2)
		SET @return = (SELECT ISNULL(SUM(cantidad*precio_unidad), 0)
						 FROM DETALLE_PEDIDOS
						WHERE codPedido = @orderCode)
	 RETURN @return
END
GO
CREATE OR ALTER FUNCTION getVariousOrdersCost (@clientCode INT)
RETURNS DECIMAL(14,2)
AS
BEGIN
	DECLARE @return DECIMAL(14,2)
		SET @return = (SELECT SUM(dbo.getOrderCost(codPedido))
					     FROM PEDIDOS
						WHERE codCliente = @clientCode)
	 RETURN @return
END

GO
SELECT codCliente, 
	   dbo.getVariousOrdersCost(codCliente) AS totalOrdersCost
  FROM CLIENTES
 WHERE codCliente = 9

-----------------------------------------------
--                                           --
--  8. Implementa una función llamada        --
--  numEmpleadosOfic que reciba como         --
--  parámetro un codOficina y devuelva       --
--	el número de empleados que trabajan      --
--  en ella.                                 --
--	                                         --
--	Recuerda que debes incluir la SELECT     --
--  y comprobar el funcionamiento            --
--                                           --
-----------------------------------------------

EXEC SP_HELP EMPLEADOS
EXEC SP_HELP OFICINAS
GO

CREATE OR ALTER FUNCTION getEmployeeCountFromOffice (@officeCode CHAR(6))
RETURNS INT
AS
BEGIN
	DECLARE @return INT
		SET @return = (SELECT ISNULL(COUNT(codEmpleado), 0)
						 FROM EMPLEADOS
						WHERE codOficina = @officeCode)
	 RETURN @return
END

GO
SELECT DISTINCT codOficina, 
	   dbo.getEmployeeCountFromOffice(codOficina) AS totalEmployees
  FROM OFICINAS

---------------------------------------------
--                                         --
--  9. Implementa una función llamada      --
--  clientePagos_SN que reciba como        --
--  parámetro un codCliente y devuelva     --
--  'S' si ha realizado pagos y 'N' si     --
--  no ha realizado ningún pago.           --
--	                                       --
--	Recuerda que debes incluir la SELECT   --
--  y comprobar el funcionamiento          --
--                                         --
---------------------------------------------

EXEC SP_HELP CLIENTES
GO

CREATE OR ALTER FUNCTION clientHasOrders_YN (@clientCode INT)
RETURNS CHAR(1) 
AS
BEGIN
	DECLARE @return CHAR(1)
	DECLARE @totalOrders INT

	SET @totalOrders = (SELECT ISNULL(COUNT(*), 0)
						  FROM PEDIDOS
						 WHERE codCliente = @clientCode)

	IF (@totalOrders > 0)
	BEGIN
		SET @return = 'Y'
	END
	ELSE
	BEGIN
		SET @return = 'N'
	END

	RETURN @return
END

GO
SELECT codCliente, dbo.clientHasOrders_YN(codCliente) AS clientHasOrders
  FROM CLIENTES;

------------------------------------------------------------
--                                                        --
--  10. Implementa una función llamada                    --
--  pedidosPendientesAnyo que reciba como                 --
--  parámetros 'estado' y 'anyo' y devuelva               --
--  una TABLA con los pedidos pendientes del              --
--  año 2009 (estos datos deben ponerse directamente      --
--  en la SELECT, NO son dinámicos)                       --
--                                                        --        
--  Recuerda que debes incluir la SELECT y comprobar      --
--  el funcionamiento                                     --
--                                                        --
------------------------------------------------------------

EXEC SP_HELP PEDIDOS
GO

CREATE OR ALTER FUNCTION getTablePendingOrdersByYear (@status CHAR(1), @year INT)
RETURNS TABLE 
AS
	RETURN (SELECT *
			  FROM PEDIDOS
			 WHERE YEAR(fecha_pedido) = @year
			   AND codEstado = @status)

	-- WAY 1

GO
SELECT *
  FROM dbo.getTablePendingOrdersByYear('P', 2009)

	-- WAY 2

GO
DECLARE @status CHAR(1) = 'P'
DECLARE @year INT = 2009

SELECT *
  FROM dbo.getTablePendingOrdersByYear(@status, @year)
