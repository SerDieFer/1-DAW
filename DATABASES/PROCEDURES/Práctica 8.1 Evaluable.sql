USE JARDINERIA

				---------------------------
				--   UD8  -  PROC & FUNC -- 
				---------------------------
-------------------------------------------------------------------------------------------
-- NOTA: Recuerda cuidar la limpieza del código (tabulaciones, nombres de tablas en mayúscula,
--		nombres de variables en minúscula, poner comentarios sin excederse, código organizado y fácil de seguir, etc.)
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------
-- 1. Implementa un procedimiento llamado 'getNombreCliente' que devuelva el nombre de un cliente a partir de su código.
--		Parámetros de entrada:  codCliente INT
--		Parámetros de salida:   nombreCliente VARCHAR(50)
--		Tabla:                  CLIENTES
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--	
--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--      Recuerda utilizar en el script:
--              EXEC @ret = getNombreCliente @codCliente, @nombreCliente OUTPUT
--              IF @ret <> 0 ...
-------------------------------------------------------------------------------------------

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
				  'LINE: ', ERROR_LINE())
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

PRINT @cliName
PRINT CONCAT(CHAR(10), 'Succesful procedure')

-------------------------------------------------------------------------------------------
-- 2. Implementa un procedimiento llamado 'getPedidosPagosCliente' que devuelva el número de pedidos y de pagos a partir de un código de cliente.
--		Parámetros de entrada:  codCliente INT
--		Parámetros de salida:   numPedidos INT
--                              numPagos INT
--		Tabla:                  CLIENTES
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--	
--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--      Recuerda utilizar en el script:
--              EXEC @ret = getPedidosPagosCliente @codCliente, @numPedidos OUTPUT, @numPagos OUTPUT
--              IF @ret <> 0 ...
-------------------------------------------------------------------------------------------

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

		IF (@cliOrdersCount = 0) AND (@cliPaymentsCount = 0)
		BEGIN
			PRINT 'The selected client does not have orders or payments'
			RETURN -1
		END
	END TRY
	BEGIN CATCH
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE())
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
			 'Payments: ', @cliPaymentsCount);
PRINT CONCAT(CHAR(10),'Successful procedure.');


-------------------------------------------------------------------------------------------
-- 3. Implementa un procedimiento llamado 'crearCategoriaProducto' que inserte una nueva categoría de producto en la base de datos JARDINERIA.
--		Parámetros de entrada: codCategoria CHAR(2),
--							   nombre VARCHAR(50),
--                             descripcion_texto VARCHAR(MAX), 
--                             descripcion_html VARCHAR(MAX),
--                             imagen VARCHAR(256)

--		Parámetros de salida: <ninguno>
--		Tabla: CATEGORIA_PRODUCTOS
--		
--		# Se debe comprobar que todos los parámetros obligatorios están informados. Si falta alguno, devolver -1 y finalizar.
--		# Se debe comprobar que la categoría no exista previamente en la tabla. Si ya existe, imprimir mensaje indicándolo, devolver -1 y finalizar.
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--	
--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--      Recuerda utilizar en el script:
--              EXEC @ret = crearCategoriaProducto ...
--              IF @ret <> 0 ...
-------------------------------------------------------------------------------------------

EXEC SP_HELP CATEGORIA_PRODUCTOS
GO

CREATE OR ALTER PROCEDURE createProductCategory
						  @categoryCod CHAR(2),
						  @name VARCHAR(50),
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

		IF @categoryCod IS NULL OR @name IS NULL
		BEGIN
			PRINT 'Obligatory parameters not introduced'
			RETURN -1
		END

		BEGIN TRAN
			INSERT INTO CATEGORIA_PRODUCTOS (codCategoria, nombre, descripcion_texto, descripcion_html, imagen)
			VALUES (@categoryCod, @name, @txt_description, @html_description, @image)
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
					  'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
					  'LINE: ', ERROR_LINE())
	END CATCH
END

GO
DECLARE @categoryCod CHAR(2) = 'WP'
DECLARE @name VARCHAR(50) = 'Weapons'
DECLARE @txt_description VARCHAR(MAX)
DECLARE @html_description VARCHAR(MAX)
DECLARE @image VARCHAR(255)
DECLARE @return INT

EXEC @return = createProductCategory
			   @categoryCod,
			   @name,
			   @txt_description,
			   @html_description,
			   @image

IF @return <> 0
	RETURN

PRINT CONCAT('Category: ', @categoryCod, CHAR(10),
			 'Name: ', @name)
PRINT CONCAT(CHAR(10),'Successful procedure.');


-------------------------------------------------------------------------------------------
-- 4. Implementa un procedimiento llamado 'acuseRecepcionPedidosCliente' que actualice la fecha de entrega de los pedidos
--      a la fecha del momento actual y su estado a 'Entregado' para el codCliente pasado por parámetro y solo para los 
--      pedidos que estén en estado 'Pendiente' y no tengan fecha de entrega.

--		Parámetros de entrada: codCliente INT
--		Parámetros de salida:  numPedidosAct INT
--		Tabla: PEDIDOS

--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--
--      Ayuda: Recuerda utilizar:
--              EXEC @ret = acuseRecepcionPedidosCliente ...
--              IF @ret <> 0 ...
--
--	  * Ayuda para obtener el número de registros actualizados:
--		Se puede hacer una SELECT antes de ejecutar la sentencia de actualización o bien utilizar la variable @@ROWCOUNT
--
-------------------------------------------------------------------------------------------


EXEC SP_HELP PEDIDOS
GO

CREATE OR ALTER PROCEDURE updateReceiptClientOrderReceived
						  @clientCod INT,
						  @numUpdatedReceivedOrders INT
AS
BEGIN
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

		IF @clientCod IS NULL
		BEGIN
			PRINT 'Obligatory parameters not introduced'
			RETURN -1
		END

		BEGIN TRAN
			UPDATE PEDIDOS (fecha_entrega, codEstado)
			SET fecha_entrega = GETDATE(),
				codEstado = 'E'
			WHERE fecha_entrega = null AND codPedido <> 'E'
		COMMIT



-------------------------------------------------------------------------------------------
-- 5. Implementa un procedimiento llamado 'crearOficina' que inserte una nueva oficina en JARDINERIA.
--		Parámetros de entrada: codOficina CHAR(6)
--                             ciudad VARCHAR(40)
--                             pais VARCHAR(50)
--                             region VARCHAR(50) (no obligatorio)
--                             codigo_postal CHAR(5)
--                             telefono VARCHAR(15)
--                             linea_direccion1 VARCHAR(100)
--                             linea_direccion2 VARCHAR(100) (no obligatorio)

--		Parámetros de salida: <ninguno>
--		Tabla: OFICINAS
--		
--		# Se debe comprobar que todos los parámetros obligatorios están informados, sino devolver -1 y finalizar
--		# Se debe comprobar que el codOficina no exista previamente en la tabla, y si así fuera, 
--			imprimir un mensaje indicándolo y se devolverá -1
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--	
--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--
--      Ayuda: Recuerda utilizar:
--              EXEC @ret = crearOficina ...
--              IF @ret <> 0 ...
-------------------------------------------------------------------------------------------





-------------------------------------------------------------------------------------------
-- 6. Implementa un procedimiento llamado 'cambioJefes' que actualice el jefe/a de los empleados/as del
--      que tuvieran inicialmente (ant_codEmplJefe) al nuevo/a (des_codEmplJefe)
--    NOTA: Es un proceso que ocurre si alguien asciende de categoría.

--		Parámetros de entrada: ant_codEmplJefe INT
--                             des_codEmplJefe INT

--		Parámetros de salida: numEmpleados INT (número de empleados que han actualizado su jefe)
--		Tabla: EMPLEADOS

--	  * Comprueba que el funcionamiento es correcto realizando una llamada desde un script y comprobando la finalización del mismo
--
--      Ayuda: Recuerda utilizar:
--              EXEC @ret = cambioJefes ...
--              IF @ret <> 0 ...
-------------------------------------------------------------------------------------------



-------------------------------------------------------------------------------------------
-- 7. Implementa una función llamada getCostePedidos que reciba como parámetro un codCliente y devuelva
--		el coste de todos los pedidos realizados por dicho cliente.
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------
SELECT idCliente, <llamada a tu funcion>
  FROM CLIENTES;


-------------------------------------------------------------------------------------------
-- 8. Implementa una función llamada numEmpleadosOfic que reciba como parámetro un codOficina y devuelva
--		el número de empleados que trabajan en ella
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------



-------------------------------------------------------------------------------------------
-- 9. Implementa una función llamada clientePagos_SN que reciba como parámetro un codCliente y devuelva
--		'S' si ha realizado pagos y 'N' si no ha realizado ningún pago.
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------



-------------------------------------------------------------------------------------------
-- 10. Implementa una función llamada pedidosPendientesAnyo que reciba como parámetros 'estado' y 'anyo'
--	    y devuelva una TABLA con los pedidos pendientes del año 2009 (estos datos deben ponerse directamente en la SELECT, NO son dinámicos)

--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------

