/* A) Crea un procedimiento llamado crearPedidoActualizaPago que reciba como parámetros de entrada:
 fecha_esperada, fecha_entrega, codEstado, comentarios, codCliente
 1º Validar los parámetros de entrada
 2º Insertar un pedido nuevo en la tabla PEDIDOS
 3º Actualizar la tabla PAGOS, el campo codPedido al nuevo codPedido para los pedidos del cliente que no tenga codPedido*/

USE JARDINERIA
GO
EXEC SP_HELP PEDIDOS
EXEC SP_HELP ESTADOS_PEDIDO
GO
CREATE OR ALTER PROCEDURE crearPedidoActualizarPago (@fechaEsperada DATE,
                                                     @fechaEntrega DATE, 
                                                     @codEstado CHAR(1), 
                                                     @comentarios VARCHAR(500), 
                                                     @codCliente INT)
AS
BEGIN
    BEGIN TRY

      IF NOT EXISTS (SELECT *
                       FROM PEDIDOS
                      WHERE codCliente = @codCliente)
		BEGIN
			PRINT 'El cliente seleccionado no tiene pedidos.';
			RETURN -1
		END

        IF @fechaEsperada IS NULL AND
           @codEstado IS NULL OR @codEstado = '' OR LEN(@codEstado) <> 1 OR @codEstado LIKE '%[0-9]%' AND
           @comentarios = '' AND 
           @codCliente IS NULL
        BEGIN
            PRINT 'Los parametros de entrada son erroneos.';
			   RETURN -1
        END

        DECLARE @codPedidoUltimo INT = (SELECT TOP(1) codPedido
                                          FROM PEDIDOS
                                         ORDER BY codPedido DESC)
        SET @codPedidoUltimo = @codPedidoUltimo + 1

        BEGIN TRAN

            INSERT INTO PEDIDOS (codPedido, fecha_pedido, 
                                 fecha_esperada, fecha_entrega, 
                                 codEstado, comentarios, codCliente )
                        VALUES (@codPedidoUltimo, GETDATE(), @fechaEsperada, 
                                 @fechaEntrega, @codEstado, @comentarios, @codCliente)

            UPDATE PAGOS
               SET codPedido = @codPedidoUltimo
             WHERE codPedido IS NULL
               AND codCliente = @codCliente

        COMMIT
END TRY
BEGIN CATCH
    ROLLBACK
        PRINT CONCAT('Codigo Error:', ERROR_NUMBER(), CHAR(10),
                     'Descripcion: ', ERROR_MESSAGE(),  CHAR(10),
                     'Linea: ', ERROR_LINE(), CHAR(10),
                     'Procedimiento: ', ERROR_PROCEDURE())
END CATCH
END
GO
DECLARE @fechaEntrega DATE = NULL
DECLARE @fechaEsperada DATE = GETDATE() + 3
DECLARE @codEstado CHAR(1) = 'P'
DECLARE @comentarios VARCHAR(500) = NULL
DECLARE @codCliente INT = 27
DECLARE @return INT
   EXEC @return = crearPedidoActualizarPago  @fechaEsperada,
                                             @fechaEntrega,
                                             @codEstado,
                                             @comentarios,
                                             @codCliente
    IF @return <> 0
    RETURN

     PRINT CONCAT ('El cliente ', @codCliente, ' tiene un nuevo pedido', 
                   CHAR(10), CHAR(10), 'Procedimiento con exito.')

SELECT *
FROM PAGOS
WHERE codCliente = 27

/* B) Crea una función llamada importePagosCliente que devuelva el importe de los pagos
	de un cliente pasado como parámetro. Llama a la función con la tabla CLIENTES.

   Crea otra función que devuelva los PAGOS cuyo importe sea inferior a la media del importe de 
	los pagos del cliente.

   Crea otra función que devuelva cuánto suma el importe total vendido para un producto.
	Debes comprobarlo en la tabla DETALLE_PEDIDOS (cantidad y precio). */

USE JARDINERIA
GO
EXEC SP_HELP CLIENTES
EXEC SP_HELP PAGOS

GO
CREATE OR ALTER FUNCTION importePagosCliente (@codCliente INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @resultado DECIMAL(12,2)

    SET @resultado = (SELECT ISNULL(SUM(importe_pago), 0)
                        FROM PAGOS
                       WHERE codCliente = @codCliente)
    RETURN @resultado
END
GO
SELECT codCliente, dbo.importePagosCliente(codCliente) AS importePagosCliente
  FROM CLIENTES
 WHERE codCliente = 1

GO
CREATE OR ALTER FUNCTION pedidosInferioresAlImportePagosCliente (@codCliente INT)
RETURNS TABLE
AS
    RETURN (SELECT *
              FROM PAGOS
             WHERE importe_pago < dbo.importePagosCliente(@codCliente)
               AND codCliente = @codCliente)
GO
SELECT *
  FROM dbo.pedidosInferioresAlImportePagosCliente(1);

GO
CREATE OR ALTER FUNCTION importeTotalVendidoProducto (@codProducto INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @resultado DECIMAL(12,2)

    SET @resultado = (SELECT ISNULL(SUM(cantidad * precio_unidad), 0)
                        FROM DETALLE_PEDIDOS
                       WHERE codProducto = @codProducto)
    RETURN @resultado
END
GO
SELECT DISTINCT codProducto, dbo.importeTotalVendidoProducto(codProducto) AS importeTotalVendidoProducto
  FROM DETALLE_PEDIDOS
 WHERE codProducto = 87


/* C) Crea un cursor que itere por la tabla EMPLEADOS, muestre su código, nombre y el 
	número de clientes que tienen a su cargo (con doble cursor o con SELECT).

   Crea un cursor que itere por la tabla PRODUCTOS e indique la siguiente información:
	El producto XXX con referencia YYY aparece ZZZ veces en la tabla DETALLE_PEDIDOS. */

USE JARDINERIA
GO
EXEC SP_HELP EMPLEADOS
EXEC SP_HELP CLIENTES

GO
DECLARE Cur_DatosEmpleado CURSOR FOR
 SELECT codEmpleado,
        CONCAT(nombre,' ', apellido1, ' ', apellido2) AS nombreCompleto
   FROM EMPLEADOS

DECLARE @codEmpleado INT
DECLARE @nombreCompleto VARCHAR(150)

OPEN Cur_DatosEmpleado
FETCH NEXT FROM Cur_DatosEmpleado INTO @codEmpleado, @nombreCompleto

WHILE @@FETCH_STATUS = 0
BEGIN
   DECLARE Cur_ClientesEmpleado CURSOR FOR
    SELECT COUNT(*)
      FROM CLIENTES
     WHERE codEmpl_ventas = @codEmpleado

   DECLARE @numClientesEmpleado INT
    
      OPEN Cur_ClientesEmpleado
     FETCH NEXT FROM Cur_ClientesEmpleado INTO @numClientesEmpleado

     CLOSE Cur_ClientesEmpleado
DEALLOCATE Cur_ClientesEmpleado

     PRINT CONCAT('Nº Empleado: ', @codEmpleado, CHAR(10),
                  'Nombre: ', @nombreCompleto, CHAR(10),
                  'Nº Clientes: ', @numClientesEmpleado, CHAR(10))

     FETCH NEXT FROM Cur_DatosEmpleado INTO @codEmpleado, @nombreCompleto 
END

     CLOSE Cur_DatosEmpleado
DEALLOCATE Cur_DatosEmpleado

EXEC SP_HELP PRODUCTOS

GO
 DECLARE Cur_DatosProducto CURSOR FOR
  SELECT codProducto,
         refInterna
    FROM PRODUCTOS

 DECLARE @codProducto INT
 DECLARE @refProducto VARCHAR(15)

    OPEN Cur_DatosProducto
   FETCH NEXT FROM Cur_DatosProducto INTO @codProducto, @refProducto

   WHILE @@FETCH_STATUS = 0
   BEGIN
      DECLARE Cur_CantidadPedidaProducto CURSOR FOR
       SELECT COUNT(*)
         FROM DETALLE_PEDIDOS
        WHERE codProducto = @codProducto

        DECLARE @cantidadPedidaProducto INT

           OPEN Cur_CantidadPedidaProducto
          FETCH NEXT FROM Cur_CantidadPedidaProducto INTO @cantidadPedidaProducto

          CLOSE Cur_CantidadPedidaProducto
     DEALLOCATE Cur_CantidadPedidaProducto

       PRINT CONCAT('Nº Producto: ', @codProducto, CHAR(10),
                    'Referencia: ', @refProducto, CHAR(10),
                    'Nº Veces Pedido: ', @cantidadPedidaProducto, CHAR(10))

       FETCH NEXT FROM Cur_DatosProducto INTO @codProducto, @refProducto   
     END

     CLOSE Cur_DatosProducto
DEALLOCATE Cur_DatosProducto

/*
D) Crea un trigger que se active cuando se inserte un nuevo cliente y que en caso 
	de no tener un limite_credito > 10000 se impida su inserción.

   Crea un trigger que haga una copia de seguridad de la tabla FORMA_PAGO en la tabla
	HIST_FORMA_PAGO cuando se actualice o borre algún registro de esta tabla.
	La tabla HIST_FORMA_PAGO tendrá además la fecha de operación que corresponderá
	con la fecha en la que se ejecute el trigger. */

GO
USE JARDINERIA

EXEC SP_HELP CLIENTES

GO
CREATE OR ALTER TRIGGER TX_LIMITECREDITO_NUEVOCLIENTE ON CLIENTES
INSTEAD OF INSERT
AS
BEGIN
   BEGIN TRY

         DECLARE @limiteCredito INT = 10000
         DECLARE @transaccionPrevia INT = @@TRANCOUNT

         IF (@transaccionPrevia = 0)
         BEGIN TRAN
               INSERT INTO CLIENTES
               SELECT *
                 FROM INSERTED
                WHERE limite_credito > @limiteCredito

         IF (@transaccionPrevia = 0)
         COMMIT

   END TRY
   BEGIN CATCH
      IF @transaccionPrevia = 0
         ROLLBACK
         PRINT CONCAT('CODIGO DE ERROR: ', ERROR_NUMBER(),
                     ' MENSAJE DE ERROR: ', ERROR_MESSAGE(),
                     ' LINEA DE ERROR: ', ERROR_LINE(),
                     ' ERROR DE PROCEDIMIENTO: ', ERROR_PROCEDURE())
   END CATCH
END

DECLARE @nuevoCliente INT;
SET @nuevoCliente = ISNULL((SELECT MAX(codCliente)
                              FROM CLIENTES), 0) + 1

INSERT INTO CLIENTES
VALUES (@nuevoCliente, 'Santi', 'Pls', 'Copion', '696969696', null, 'Argentina', null, 'Alicante', null, null, null, 15000),
       (@nuevoCliente + 1, 'Pedro', 'Gómez', 'López', '666666666', null, 'España', null, 'Madrid', null, null, null, 8000),
       (@nuevoCliente + 2, 'María', 'Fernández', 'García', '555555555', null, 'España', null, 'Barcelona', null, null, null, 12000),
       (@nuevoCliente + 3, 'Laura', 'Martínez', 'Rodríguez', '777777777', null, 'España', null, 'Valencia', null, null, null, 9500);



GO
EXEC SP_HELP FORMA_PAGO

SELECT * 
  INTO FORMA_PAGO_BACKUP
  FROM FORMA_PAGO
 WHERE 1 = 0

 ALTER TABLE FORMA_PAGO_BACKUP
 ADD fechaModificacion SMALLDATETIME NOT NULL

GO
CREATE OR ALTER TRIGGER TX_FORMAPAGO_BACKUP ON FORMA_PAGO
AFTER DELETE, UPDATE
AS
BEGIN
   
   INSERT INTO FORMA_PAGO_BACKUP
   SELECT *, GETDATE()
    FROM DELETED
END
GO
