USE SUPERTIENDA
GO
				---------------------------
				--   UD8  -  PROC & FUNC -- 
				---------------------------
-------------------------------------------------------------------------------------------
-- NOTA: Recuerda cuidar la limpieza del código (tabulaciones, nombres de tablas en mayúscula,
--		nombres de variables en minúscula, poner comentarios sin excederse, código organizado y fácil de seguir, etc.)
--
--	Si alguna tabla fuera IDENTITY y haces una inserción, puedes obtener el id llamando a la función SCOPE_IDENTITY()
--
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------
-- 1. Implementa un procedimiento llamado 'crearCategoria' que inserte una nueva categoría de productos.
--		Parámetros de entrada: codCategoria, nombreCategoria
--		Parámetros de salida: <ninguno>
--		Tabla: CATEGORIAS
--		
--		# Se debe comprobar que todos los parámetros obligatorios están informados, sino devolver -1 y finalizar
--		# Se debe comprobar que el codCategoria no exista en la tabla, y si así fuera, 
--			imprimir un mensaje indicándolo, devolver -1 y finalizar
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--	
--	  * Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

GO
EXEC SP_HELP CATEGORIAS
GO
CREATE OR ALTER PROCEDURE crearCategoria (@codCategoriaCrear CHAR(2),
                                          @nombreCategoriaCrear VARCHAR(100))
AS
BEGIN
  BEGIN TRY
    IF @codCategoriaCrear IS NULL OR LEN(@codCategoriaCrear) <> 2 OR
       @nombreCategoriaCrear IS NULL OR @nombreCategoriaCrear = ''
    BEGIN
      PRINT 'Parametros obligatorios no declarados o inválidos'
      RETURN -1
    END

    IF EXISTS (SELECT *
                 FROM CATEGORIAS
                WHERE codCategoria = @codCategoriaCrear)
    BEGIN
      PRINT 'CodCategoria ya existe'
      RETURN -1
    END

      INSERT INTO CATEGORIAS(codCategoria, nombre)
      VALUES (@codCategoriaCrear, @nombreCategoriaCrear)

  END TRY
  BEGIN CATCH 
    IF @@TRANCOUNT > 0
    ROLLBACK
    PRINT CONCAT('ERROR:', ERROR_NUMBER(), CHAR(10),
                 'LINE: ', ERROR_LINE(), CHAR(10),
                 'MESSAGE: ', ERROR_MESSAGE(), CHAR(10),
                 'PROCEDURE: ', ERROR_PROCEDURE(), CHAR(10))
  END CATCH
END


DECLARE @codCategoria CHAR(2) = 'PP'
DECLARE @nombreCategoria VARCHAR(100) = 'Pepinillos'
DECLARE @return INT

EXEC @return = crearCategoria @codCategoria,
                              @nombreCategoria

IF @return <> 0
BEGIN
    PRINT 'Error al crear Categoria'
    RETURN
END

select *
from CATEGORIAS

-------------------------------------------------------------------------------------------
-- 2. Implementa un procedimiento que cree una nueva subcategoría de producto.
--		Parámetros de entrada: codCategoria, nombreSubCategoria
--		Parámetros de salida: codSubCategoria
--		Tabla: SUBCATEGORIAS

--		# Se debe comprobar que todos los parámetros obligatorios están informados, sino devolver -1 y finalizar
--		# Se debe comprobar que el idCategoria SI existe en la tabla (sino no podemos crear la subcategoria)
--			Si no existiera, imprimir un mensaje indicándolo, devolver -1 y finalizar
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--		
--	  *Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

GO
EXEC SP_HELP SUBCATEGORIAS
GO
CREATE OR ALTER PROCEDURE crearSubcategoriaProducto (@codSubcategoriaCreado INT OUTPUT,
                                                     @codCategoriaCrear CHAR(2),
                                                     @nombreSubcategoriaCrear VARCHAR(100))
AS
BEGIN
  BEGIN TRY

    IF @codCategoriaCrear IS NULL OR LEN(@codCategoriaCrear) <> 2 OR
       @nombreSubcategoriaCrear IS NULL OR @nombreSubcategoriaCrear = ''
    BEGIN
      PRINT 'Parametros obligatorios nulos o incorrectos'
      RETURN -1
    END

    IF NOT EXISTS (SELECT *
                     FROM CATEGORIAS
                    WHERE codCategoria = @codCategoriaCrear)
    BEGIN
      PRINT 'El codigo de categoria seleccionado no existe'
      RETURN -1
    END

    BEGIN TRAN

      INSERT INTO SUBCATEGORIAS
      VALUES (@codCategoriaCrear, @nombreSubcategoriaCrear)

      SET @codSubcategoriaCreado = SCOPE_IDENTITY()

    COMMIT

  END TRY
  BEGIN CATCH

    IF @@TRANCOUNT > 0
    ROLLBACK

    PRINT CONCAT('ERROR:', ERROR_NUMBER(), CHAR(10),
                 'LINE: ', ERROR_LINE(), CHAR(10), 
                 'MESSAGE: ', ERROR_MESSAGE(), CHAR(10), 
                 'PROCEDURE: ', ERROR_PROCEDURE(), CHAR(10))

  END CATCH
END

DECLARE @codSubcategoria INT
DECLARE @codCategoriaSubcategoria CHAR(2) = 'AL'
DECLARE @nombreSubcategoria VARCHAR(100) = 'Pitos'
DECLARE @return INT

EXEC @return = crearSubcategoriaProducto @codSubcategoria OUTPUT,
                                         @codCategoriaSubcategoria,
                                         @nombreSubcategoria

IF @return <> 0
BEGIN
  PRINT 'Error al crear subcategoria'
  RETURN
END
ELSE
BEGIN
  PRINT CONCAT('Categoría creada con exito', CHAR(10), 'Codigo: ' , @codSubcategoria)
END


-------------------------------------------------------------------------------------------
-- 3. Implementa un procedimiento que cree un nuevo producto en la base de datos.
--		Parámetros de entrada: nombre, precioUnitario, IVA e codSubCategoria
--		Parámetros de salida: codProducto creado
--		Tabla: PRODUCTOS
--		
--		# Se debe comprobar que todos los parámetros *obligatorios* están informados, sino devolver -1 y finalizar
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--		
--	  * Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

EXEC SP_HELP PRODUCTOS
GO
CREATE OR ALTER PROCEDURE crearProducto @nombreProducto VARCHAR(100),
                                        @precioProductoUnitario DECIMAL(5,2),
                                        @IVAproducto TINYINT,
                                        @codSubCategoriaProducto INT,
                                        @codProductoCreado INT OUTPUT
AS
BEGIN
  BEGIN TRY

    IF @nombreProducto IS NULL OR @nombreProducto = '' OR
       @precioProductoUnitario IS NULL OR
       @IVAproducto IS NULL
    BEGIN
      PRINT 'Parametros obligatorios nulos o invalidos'
    END

    BEGIN TRAN

      INSERT INTO PRODUCTOS
      VALUES (@nombreProducto, @precioProductoUnitario, @IVAproducto, @codSubCategoriaProducto)

      SET @codProductoCreado = SCOPE_IDENTITY()

    COMMIT

  END TRY
  BEGIN CATCH
  
    IF @@TRANCOUNT > 0
      ROLLBACK
      PRINT CONCAT('ERROR: ', ERROR_NUMBER(), CHAR(10),
                   'LINE: ', ERROR_LINE(),CHAR(10),
                   'MESSAGE: ', ERROR_MESSAGE(), CHAR(10),
                   'PROCEDURE: ', ERROR_PROCEDURE(), CHAR(10))
  END CATCH
END

DECLARE @return INT
DECLARE @codProducto INT
DECLARE @nombrePro VARCHAR(100) = 'Pepinillo de Caca'
DECLARE @precioProducto DECIMAL(5,2) = 999.32
DECLARE @IVA TINYINT = 21
DECLARE @codSubPro INT = null

EXEC @return = crearProducto @nombrePro,
                             @precioProducto,
                             @IVA,
                             @codSubPro,
                             @codProducto OUTPUT

IF @return <> 0
  BEGIN
    PRINT 'Error al crear producto'
    RETURN
  END
ELSE
  BEGIN
    PRINT CONCAT('El produto ha sido creado correctamente y su codigo es: ', @codProducto)
  END
                                        
-------------------------------------------------------------------------------------------
-- 4. Implementa un procedimiento que cree una nueva valoración de un cliente a un producto
--		Parámetros de entrada: codCliente, codProducto, estrellas, fechaValoracion y comentario
--		Parámetros de salida: <ninguno>
--		Tabla: VALORACIONES_PRODUCTOS
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros, transacciones si fueran necesarias, etc.
--	
--	 
--	  * Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

EXEC SP_HELP VALORACIONES_PRODUCTOS

GO
CREATE OR ALTER PROCEDURE nuevaValoracionProducto @codCli INT,
                                                  @codProducto INT,
                                                  @estre TINYINT,
                                                  @fecha DATE,
                                                  @coment VARCHAR(250)
AS
BEGIN
  BEGIN TRY

    IF @codCli IS NULL OR
       @codProducto IS NULL OR
       @estre IS NULL OR @estre NOT BETWEEN 0 AND 5 OR
       @fecha IS NULL OR
       @coment IS NULL OR @coment = ''
    BEGIN
      PRINT 'Parametros obligatorios nulos o incorrectos'
      RETURN -1
    END

    IF NOT EXISTS (SELECT codCliente
                     FROM CLIENTES
                    WHERE codCliente = @codCli)
    BEGIN
      PRINT 'Este cliente no existe'
      RETURN -1
    END

    IF NOT EXISTS (SELECT codProducto
                     FROM PRODUCTOS
                    WHERE codProducto = @codProducto)
    BEGIN
      PRINT 'Este producto no existe'
      RETURN -1
    END

    INSERT INTO VALORACIONES_PRODUCTOS
    VALUES (@codCli, @codProducto, @estre, @fecha, @coment)

  END TRY
  BEGIN CATCH
    IF @@TRANCOUNT > 0
      ROLLBACK
      PRINT CONCAT('ERROR: ', ERROR_NUMBER(), CHAR(10),
                   'LINEA: ', ERROR_LINE(), CHAR(10),
                   'PROCEDIMIENTO: ', ERROR_PROCEDURE(), CHAR(10),
                   'MENSAJE: ', ERROR_MESSAGE())
  END CATCH
END

DECLARE @codiCli INT = 2
DECLARE @codiPro INT = 100
DECLARE @estrellitas TINYINT = 4
DECLARE @fechaComen DATE = GETDATE()
DECLARE @comentario VARCHAR(250) = 'Ta xulo'
DECLARE @return INT

EXEC @return = nuevaValoracionProducto @codiCli,
                                       @codiPro,
                                       @estrellitas,
                                       @fechaComen,
                                       @comentario
IF @return <> 0
BEGIN
  PRINT 'Error al crear nueva valoracion'
  RETURN
END

-------------------------------------------------------------------------------------------
-- 5. Implementa un procedimiento que cree un nuevo pedido
--		Parámetros de entrada: codCliente, codVendedor, codTransportista, costeEnvio, recogidaTiendaSN
--		Parámetros de salida: codPedido
--		Tabla: PEDIDOS
--		
--		# Se debe comprobar que los parámetros codCliente e codVendedor están informados, sino devolver -1 y finalizar
--		# El resto de campos de la tabla que no se pasan como parámetro de entrada se informarán a cero en la sentencia INSERT
--		# NO hace falta comprobar que el codCliente y el codVendedor existan. Si no existieran, fallará la sentencia INSERT
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--		
--	  * Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

EXEC SP_HELP PEDIDOS

GO
CREATE OR ALTER PROCEDURE nuevoPedido @codCliente INT,
                                      @codVendedor INT,
                                      @codTransportista INT,
                                      @costeEnvio DECIMAL(5,2),
                                      @recogidaTienda CHAR(1),
                                      @codPedido INT OUTPUT
AS
BEGIN
  BEGIN TRY

    IF @codCliente IS NULL OR @codVendedor IS NULL OR @codTransportista IS NULL OR
       @costeEnvio IS NULL OR 
       @recogidaTienda IS NULL OR LEN(@recogidaTienda) <> 1 OR @recogidaTienda NOT IN ('N', 'n', 'S', 's')
    BEGIN
      PRINT 'Parametros obligatorios nulos o incorrectos'
      RETURN -1
    END

    IF NOT EXISTS (SELECT codCliente
                     FROM CLIENTES
                    WHERE codCliente = @codCliente)
    BEGIN
      PRINT 'Cliente seleccionado no existe'
      RETURN -1
    END

    IF NOT EXISTS (SELECT codVendedor
                     FROM VENDEDORES
                    WHERE codVendedor = @codVendedor)
    BEGIN
      PRINT 'Vendedor seleccionado no existe'
      RETURN -1
    END

    IF NOT EXISTS (SELECT codTransportista
                     FROM COMPANYIAS_TRANSPORTE
                    WHERE codTransportista = @codTransportista)
    BEGIN
      PRINT 'Transportista seleccionado no existe'
      RETURN -1
    END

    BEGIN TRAN

      SET @codPedido = ((SELECT TOP(1) codPedido
                          FROM PEDIDOS
                         ORDER BY codPedido DESC) +1)

      INSERT INTO PEDIDOS (codPedido, codCliente, codVendedor, codTransportista, costeEnvio, recogidaTiendaSN)
      VALUES(@codPedido, @codCliente, @codVendedor, @codTransportista, @costeEnvio, @recogidaTienda)

    COMMIT
  END TRY
  BEGIN CATCH

    IF @@TRANCOUNT > 0
      ROLLBACK
      PRINT CONCAT('ERROR: ', ERROR_NUMBER(), CHAR(10),
                   'LINEA: ', ERROR_LINE(), CHAR(10),
                   'MENSAJE: ', ERROR_MESSAGE(), CHAR(10),
                   'PROCEDIMIENTO: ', ERROR_PROCEDURE())

  END CATCH
END

DECLARE @codiClie INT = 2
DECLARE @codiVende INT = 3
DECLARE @codiTrans INT =  4
DECLARE @costEnv DECIMAL(5,2) = 2.2
DECLARE @recogidaTiendaSN CHAR(1) = 'S'
DECLARE @codPedi INT
DECLARE @return INT

EXEC @return = nuevoPedido @codiClie,
                           @codiVende,
                           @codiTrans,
                           @costEnv,
                           @recogidaTiendaSN,
                           @codPedi OUTPUT
IF @return <> 0
BEGIN
  PRINT 'Error al crear pedido'
END
ELSE
BEGIN
  PRINT CONCAT('Exito al crear nuevo pedido con el codigo ', @codPedi)
END

-------------------------------------------------------------------------------------------
-- 6. Implementa un procedimiento crearLineaPedido que cree una nueva línea de pedido
--		Parámetros de entrada: codPedido, codProducto y unidades
--		Parámetros de salida: <ninguno>
--		Tabla: LINEAS_PEDIDOS
--		
--		# El precio del producto (campo 'precioCompra') debes obtenerlo previamente de la tabla PRODUCTOS
--		# El campo totalLinea es un campo derivado (se actualiza automáticamente), por lo que NO hay que indicarlo en la INSERT.
--		# Se debe comprobar que los parámetros codPedido, codProducto y unidades están informados, sino devolver -1 y finalizar
--		# NO hace falta comprobar que el codPedido y el codProducto existan. Si no existieran, fallará la sentencia INSERT
--		
--		El procedimiento devolverá 0 si finaliza correctamente.
--		Debes utilizar TRY/CATCH, validación de parámetros y transacciones si fueran necesarias.
--		
--	  * Comprueba que el funcionamiento es correcto realizando una desde un script y comprobando la finalización del mismo
-------------------------------------------------------------------------------------------

EXEC SP_HELP LINEAS_PEDIDOS

GO
CREATE OR ALTER PROCEDURE crearLineaPedido @codPedidoLinea INT,
                                           @codProductoLinea INT,
                                           @unidadesProductoLinea INT
AS
BEGIN
  BEGIN TRY

    IF @codPedidoLinea IS NULL OR @codProductoLinea IS NULL OR @unidadesProductoLinea IS NULL OR @unidadesProductoLinea <= 0
    BEGIN
      PRINT 'Parametros obligatorios nulos o invalidos'
      RETURN -1
    END

    IF EXISTS (SELECT codPedido,
                      codProducto
                 FROM LINEAS_PEDIDOS
                WHERE codPedido = @codPedidoLinea
                  AND codProducto = @codProductoLinea)
    BEGIN
      PRINT 'Esta linea ya existe'
      RETURN -1
    END

    BEGIN TRAN
    
    DECLARE @precioProducto DECIMAL(9,2)
    SET @precioProducto = (SELECT precioUnitario
                             FROM PRODUCTOS
                            WHERE codProducto = @codProductoLinea)

    INSERT INTO LINEAS_PEDIDOS
    VALUES (@codPedidoLinea, @codProductoLinea, @precioProducto, @unidadesProductoLinea)

    COMMIT
  END TRY
  BEGIN CATCH
    IF @@TRANCOUNT > 0
    ROLLBACK
    
    PRINT CONCAT('Error:', ERROR_NUMBER(), CHAR(10),
                 'Linea:', ERROR_LINE(), CHAR(10),
                 'Mensaje:', ERROR_MESSAGE(), CHAR(10),
                 'Procedimiento:', ERROR_PROCEDURE(), CHAR(10))
  END CATCH 
END

DECLARE @codPedido INT = 2
DECLARE @codProducto INT = 4
DECLARE @unidades INT = 100
DECLARE @return INT

EXEC @return = crearLineaPedido @codPedido,
                                @codProducto,
                                @unidades

IF @return <> 0
BEGIN
  PRINT 'Error al crear nueva linea de pedido'
END

-------------------------------------------------------------------------------------------
-- 7. Implementa un script que utilice los procedimientos crearPedido y crearLineaPedido y 
--		que cree un nuevo pedido y que el pedido tenga dentro 2 productos cualesquiera.
--	
--	Recuerda la utilización de TRY/CATCH y transacciones.
--		Ejemplo. Si se llega a crear el pedido y falla la creación de una de las líneas,
--			deberá retroceder los cambios al estado inicial (ROLLBACK)
--
--  Ayuda 1: Considera quitar las transacciones de dentro de los procedimientos.
--  Ayuda 2: Utiliza una transacción que se inicie en el script de llamada
--     y que el COMMIT se haga al final
-------------------------------------------------------------------------------------------

GO
BEGIN
  BEGIN TRY

    BEGIN TRAN

      DECLARE @codiClie INT = 2
      DECLARE @codiVende INT = 3
      DECLARE @codiTrans INT =  4
      DECLARE @costEnv DECIMAL(5,2) = 2.2
      DECLARE @recogidaTiendaSN CHAR(1) = 'S'
      DECLARE @codPedi INT
      DECLARE @return INT

      EXEC @return = nuevoPedido @codiClie,
                                 @codiVende,
                                 @codiTrans,
                                 @costEnv,
                                 @recogidaTiendaSN,
                                 @codPedi OUTPUT

      IF @return <> 0
      BEGIN
        PRINT 'Error al crear pedido'
        ROLLBACK
        RETURN
      END

      PRINT CONCAT('Éxito al crear nuevo pedido con el código ', @codPedi)

      DECLARE @codProducto1 INT = 5000
      DECLARE @codProducto2 INT = 2
      DECLARE @unidades1 INT = 10
      DECLARE @unidades2 INT = 20

      EXEC @return = crearLineaPedido @codPedi, 
                                      @codProducto1,
                                      @unidades1

      IF @return <> 0
      BEGIN
        PRINT 'Error al crear línea de pedido 1'
        ROLLBACK
        RETURN
      END

      EXEC @return = crearLineaPedido @codPedi, 
                                      @codProducto2, 
                                      @unidades2

      IF @return <> 0
      BEGIN
        PRINT 'Error al crear línea de pedido 2'
        ROLLBACK
        RETURN
      END

    COMMIT
    PRINT 'Pedido y líneas de pedido creados con exito'

  END TRY
  BEGIN CATCH
      IF @@TRANCOUNT > 0
      ROLLBACK
      
      PRINT CONCAT('Error:', ERROR_NUMBER(), CHAR(10),
                   'Linea:', ERROR_LINE(), CHAR(10),
                   'Mensaje:', ERROR_MESSAGE(), CHAR(10),
                   'Procedimiento:', ERROR_PROCEDURE(), CHAR(10))
  END CATCH
END



-------------------------------------------------------------------------------------------
--8. Implementa una función llamada getNumPedidos que reciba como parámetro un idCliente y devuelva
--		el número de pedidos realizados por dicho cliente.
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
--
--  Ayuda: recuerda incluir el prefijo dbo. al llamar a la función
--   En las funciones nunca debes indicar un valor directamente (es decir, "hardcodeado")
-------------------------------------------------------------------------------------------

EXEC SP_HELP CLIENTES
GO
CREATE OR ALTER FUNCTION getNumPedidos (@idCliente INT)
RETURNS INT
AS
BEGIN
  RETURN (SELECT ISNULL(COUNT(*),0)
            FROM PEDIDOS
           WHERE codCliente = @idCliente)
END

GO
SELECT codCliente, dbo.getNumPedidos(codCliente) AS NumPedidos
  FROM CLIENTES
 WHERE codCliente = 1


-------------------------------------------------------------------------------------------
-- 9. Implementa una función llamada getCostePedidos que reciba como parámetro un idCliente y devuelva
--		el coste de todos los pedidos realizados por dicho cliente.
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------

EXEC SP_HELP LINEAS_PEDIDOS
GO
CREATE OR ALTER FUNCTION getCostePedidos (@idCliente INT)
RETURNS DECIMAL(9,2)
AS
BEGIN
  RETURN (SELECT ISNULL(SUM(totalLinea),0)
            FROM LINEAS_PEDIDOS
           WHERE codPedido IN (SELECT codPedido
                                 FROM PEDIDOS
                                WHERE codCliente = @idCliente))
END

GO
SELECT codCliente, dbo.getCostePedidos(codCliente)
  FROM CLIENTES
WHERE codCliente = 7


-------------------------------------------------------------------------------------------
-- 10. Implementa una función llamada ventasTotalesVendedor que reciba como parámetro un idVendedor y devuelva
--		el importe vendido por dicho vendedor.
--	
--	Recuerda que debes incluir la SELECT y comprobar el funcionamiento
-------------------------------------------------------------------------------------------

EXEC SP_HELP VENDEDORES
EXEC SP_HELP PEDIDOS

GO
CREATE OR ALTER FUNCTION ventasTotalesVendedor (@idVendedor INT)
RETURNS DECIMAL(9,2)
AS
BEGIN
  RETURN (SELECT ISNULL(SUM(totalLinea),0)
            FROM LINEAS_PEDIDOS
           WHERE codPedido IN (SELECT codPedido
                                 FROM PEDIDOS
                                WHERE codVendedor = @idVendedor))
END

GO
SELECT codVendedor, dbo.ventasTotalesVendedor(codVendedor)
  FROM VENDEDORES
 WHERE codVendedor = 2

-------------------------------------------------------------------------------------------
-- 11. Ampliación Describe el funcionamiento e implementa un procedimiento que incluya 
--	TRY/CATCH y transacciones utilizando la BD TIENDA_DB.
-------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------
-- 12. Ampliación Describe el funcionamiento e implementa una función que utilice
--	alguna de las tablas de la BD TIENDA_DB.
-------------------------------------------------------------------------------------------