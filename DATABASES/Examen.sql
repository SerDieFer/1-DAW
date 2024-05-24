USE JARDINERIA

GO
EXEC SP_HELP OFICINAS
GO

DECLARE Cur_RegistrosOficina CURSOR FOR
 SELECT codOficina,
        ciudad
   FROM OFICINAS

DECLARE @codigoOfi CHAR(6)
DECLARE @ciudadOfi VARCHAR(40)

OPEN Cur_RegistrosOficina
FETCH NEXT FROM Cur_RegistrosOficina INTO @codigoOfi, @ciudadOfi

WHILE @@FETCH_STATUS = 0
BEGIN

    DECLARE @numEmpleados INT
     SELECT @numEmpleados = COUNT(*)
       FROM EMPLEADOS
      WHERE codOficina = @codigoOfi

    PRINT CONCAT('La oficina ', @codigoOfi, ', ubicada en la ciudad ', 
                 @ciudadOfi, ', tiene un total de ', @numEmpleados, ' empleados')
    FETCH NEXT FROM Cur_RegistrosOficina INTO @codigoOfi, @ciudadOfi

END 

CLOSE Cur_RegistrosOficina
DEALLOCATE Cur_RegistrosOficina

EXEC SP_HELP PRODUCTOS

GO

CREATE OR ALTER FUNCTION cuentaProductosCategoria (@codCategoria CHAR(2), @minPrecio DECIMAL(9,2), @maxPrecio DECIMAL(9,2))
RETURNS INT
AS
BEGIN

    RETURN (SELECT ISNULL(COUNT(*), 0)
              FROM PRODUCTOS
             WHERE codCategoria = @codCategoria
               AND precio_venta > @minPrecio
               AND precio_venta < @maxPrecio
             GROUP BY codCategoria)
END

GO
DECLARE @categoria CHAR(2) = 'HR'
DECLARE @minPrecio DECIMAL(9,2) =  12
DECLARE @maxPrecio DECIMAL(9,2) =  15

SELECT codCategoria,
       dbo.cuentaProductosCategoria(@categoria, @minPrecio, @maxPrecio ) AS ProductosEntrePrecioSeleccionado
  FROM PRODUCTOS
 WHERE codCategoria = @categoria
 GROUP BY codCategoria

GO
CREATE OR ALTER FUNCTION obtenerCostePedido (@codPedido INT)
RETURNS DECIMAL(9,2)
AS
BEGIN

    DECLARE @costoPedido DECIMAL(9,2)

    RETURN (SELECT ISNULL(SUM(cantidad * precio_unidad), 0)
              FROM DETALLE_PEDIDOS
             WHERE codPedido = @codPedido)
END

GO
DECLARE @codPedido INT = 1

SELECT codPedido,
       dbo.obtenerCostePedido(@codPedido) AS precioTotalPedido
  FROM PEDIDOS
 WHERE codPedido = @codPedido

EXEC SP_HELP CLIENTES
EXEC SP_HELP PAGOS
EXEC SP_HELP PEDIDO

GO
CREATE OR ALTER PROCEDURE realizarPago (@codCliente INT,
                                        @codFormaPago CHAR(1),
                                        @importePago DECIMAL(9,2),
                                        @codPedido INT)
AS
BEGIN   
    BEGIN TRY

        IF NOT EXISTS (SELECT 1
                         FROM CLIENTES
                        WHERE codCliente = @codCliente )
        BEGIN
            PRINT 'El cliente no existe'
            RETURN -1
        END

        IF @codCliente IS NULL OR @codCliente = ''
        BEGIN
            PRINT 'El codigo de cliente es invalido'
            RETURN -1
        END

        IF NOT EXISTS (SELECT 1
                         FROM FORMA_PAGO
                        WHERE codFormaPago = @codFormaPago )
        BEGIN
            PRINT 'El metodo de pago no existe'
            RETURN -1
        END

        IF @codFormaPago IS NULL OR @codFormaPago = ''
        BEGIN
            PRINT 'El codigo de pago es invalido'
            RETURN -1
        END

        IF @importePago IS NULL OR @importePago = ''
        BEGIN
            PRINT 'El importe de pago es invalido'
            RETURN -1
        END

        IF NOT EXISTS (SELECT 1
                         FROM PEDIDOS
                        WHERE codPedido = @codPedido )
        BEGIN
            PRINT 'El codigo de pedido no existe'
            RETURN -1
        END

        IF @codPedido IS NULL OR @codPedido = ''
        BEGIN
            PRINT 'El codigo de pedido es invalido'
            RETURN -1
        END

        BEGIN TRAN

            DECLARE @denominacionTransaccion CHAR(7) = (SELECT MAX(SUBSTRING(id_transaccion,1,7))
                                                          FROM PAGOS)

            DECLARE @NumSiguienteTransaccion CHAR(8) = (SELECT MAX(SUBSTRING(id_transaccion,8,15) + 1)
                                              FROM PAGOS)

            DECLARE @id_transaccion CHAR(15) = CONCAT(@denominacionTransaccion, @NumSiguienteTransaccion)

            INSERT INTO PAGOS (codCliente, id_transaccion, fechaHora_pago, importe_pago, codFormaPago, codPedido)
            VALUES (@codCliente, CAST(@id_transaccion) as, GETDATE(), @importePago, @codFormaPago, @codPedido)

            -- Antes de poner el codEstado en F habria que comprobar que ese modelo de pago esta incluido en la tabla
            -- de ESTADOS_PEDIDO
            UPDATE PEDIDOS
               SET codEstado = 'F',
                   comentarios = CONCAT(comentarios, ' Pago realizado.')
             WHERE codPedido = @codPedido
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK

        PRINT CONCAT ('Error: ' , ERROR_NUMBER(), CHAR(10),
                      'Linea: ', ERROR_LINE(), CHAR(10),
                      'Mensaje: ', ERROR_MESSAGE(), CHAR(10),
                      'Procedimiento: ', ERROR_PROCEDURE(), CHAR(10))

    END CATCH
END

DECLARE @codCli INT = 1
DECLARE @codFormPago CHAR(1) = 'T'
DECLARE @impPago DECIMAL(9,2) = 100.2
DECLARE @codPed INT = 8
DECLARE @return INT

EXEC @return = realizarPago @codCli,
                            @codFormPago,
                            @impPago,
                            @codPed

IF @return <> 0
BEGIN
    PRINT 'El pago no ha sido realizado correctamente'
END
ELSE
BEGIN
    PRINT 'El pago ha sido realizado correctamente'
END



SELECT *
  INTO HIST_CAT_PRODUCTOS
  FROM CATEGORIA_PRODUCTOS
 WHERE 1 = 0
 ALTER TABLE HIST_CAT_PRODUCTOS
   ADD fechaOperacion SMALLDATETIME

GO
CREATE OR ALTER TRIGGER TR_CATEGORIA_PRODUCTOS ON CATEGORIA_PRODUCTOS
AFTER DELETE, INSERT
AS
BEGIN
    BEGIN TRY
        DECLARE @tranCount BIT = @@TRANCOUNT

        IF @tranCount = 0
        BEGIN TRAN


            INSERT INTO HIST_CAT_PRODUCTOS
            SELECT *, 
                   GETDATE()
              FROM DELETED
             

        IF @tranCount = 0
        COMMIT

    END TRY
    BEGIN CATCH
        IF @tranCount = 0
        ROLLBACK

        PRINT CONCAT ('Error: ' , ERROR_NUMBER(), CHAR(10),
                      'Linea: ', ERROR_LINE(), CHAR(10),
                      'Mensaje: ', ERROR_MESSAGE(), CHAR(10),
                      'Procedimiento: ', ERROR_PROCEDURE(), CHAR(10))

    END CATCH
END

DELETE FROM CATEGORIA_PRODUCTOS
WHERE codCategoria = 'AR'