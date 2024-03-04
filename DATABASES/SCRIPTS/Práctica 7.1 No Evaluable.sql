USE JARDINERIA

						---------------------------
						-- EJERCICIOS UD7 - TSQL -- 
						---------------------------
-------------------------------------------------------------------------------------------
-- NOTA: Recuerda cuidar la limpieza del código (tabulaciones, nombres de tablas en mayúscula,
--		nombres de variables en minúscula, poner comentarios sin excederse, código organizado y fácil de seguir, etc.)
-------------------------------------------------------------------------------------------
-- ¡IMPORTANTE! Siempre que sea posible deberás utilizar variables 	(no es correcto indicar directamente el valor en una SELECT)
--  Esta práctica incorrecta se conoce como "hardcoding" y genera muchos problemas en el código y en su depuración
--  Aquí tenéis más información: https://es.wikipedia.org/wiki/Hard_code
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------
-- 1. Crea un script que obtenga el nombre de la gama que tenga más cantidad de productos diferentes
--
-- Salida: 'La gama que más productos tiene es Ornamentales'
-------------------------------------------------------------------------------------------

EXEC sp_columns CATEGORIA_PRODUCTOS 

DECLARE @nombreCategoriaConMasProductos VARCHAR(50)

SELECT TOP(1) @nombreCategoriaConMasProductos = cp.nombre
  FROM PRODUCTOS pro,
	   CATEGORIA_PRODUCTOS cp
 WHERE pro.codCategoria = cp.codCategoria
 GROUP BY cp.nombre
 ORDER BY COUNT(pro.codProducto) DESC

 PRINT CONCAT('La categoría con más productos es: ', @nombreCategoriaConMasProductos)

-------------------------------------------------------------------------------------------
-- 2. Crea un script que obtenga el nombre del empleado con id 7 y el nombre de su jefe
--
-- Salida: 'El empleado Carlos Soria Jimenez tiene como jefe al empleado Alberto Soria Carrasco'
-------------------------------------------------------------------------------------------

EXEC sp_columns EMPLEADOS

DECLARE @empleadoID7     VARCHAR(152)
DECLARE @jefeEmpleadoID7 VARCHAR(152)

SELECT @empleadoID7 = CONCAT(tra.nombre, ' ', tra.apellido1, ' ', tra.apellido2),
	   @jefeEmpleadoID7 = CONCAT(jef.nombre, ' ', jef.apellido1, ' ', jef.apellido2)
  FROM EMPLEADOS tra,
	   EMPLEADOS jef
 WHERE tra.codEmpleado = 7
   AND jef.codEmpleado = tra.codEmplJefe

   PRINT CONCAT('EMPLEADO: ', @empleadoID7, CHAR(10),
   				'JEFE: ' , @jefeEmpleadoID7)

-------------------------------------------------------------------------------------------
-- 3. Crea un script que devuelva el número de pedidos realizados por el cliente 9
--
-- Salida: 'El cliente Naturagua ha realizado 5 pedido/s'
-------------------------------------------------------------------------------------------

EXEC sp_columns CLIENTES

DECLARE @numerosPedidosTotalesClienteID9 INT
DECLARE @nombreCLienteID9 VARCHAR(50)

SELECT @numerosPedidosTotalesClienteID9 = COUNT(pe.codPedido),
	   @nombreCLienteID9 = cli.nombre_cliente
  FROM CLIENTES cli,
	   PEDIDOS pe
 WHERE cli.codCliente = 9
   AND cli.codCliente = pe.codCliente
 GROUP BY cli.codCliente, cli.nombre_cliente

PRINT CONCAT('CLIENTE: ',@nombreCLienteID9, CHAR(10),
   			 'PEDIDOS: ' , @numerosPedidosTotalesClienteID9)

-------------------------------------------------------------------------------------------
-- 4. Crea un script que dado un codPedido en una variable, obtenga la siguiente información:
--		nombre_cliente, Fecha pedido, estado
--
-- Salida: 'El pedido XXXX realizado por el cliente YYYYYYY se realizó el ZZ/ZZ/ZZZZ y su estado es EEEEEEEE
-------------------------------------------------------------------------------------------

EXEC sp_columns PEDIDOS

DECLARE @codPedido INT
DECLARE @codCliente INT
DECLARE @nombreCliente VARCHAR(50)
DECLARE @fechaPedido DATE
DECLARE @codEstado CHAR(1)
DECLARE @nombreEstado VARCHAR(15)

SELECT TOP(1)
	   @codPedido = pe.codPedido,
	   @codCliente = cli.codCliente,
       @fechaPedido = pe.fecha_pedido,
	   @codEstado = pe.codEstado
  FROM CLIENTES cli,
	   PEDIDOS pe
 WHERE cli.codCliente = pe.codCliente
 ORDER BY NEWID()

SELECT @nombreCliente = nombre_cliente
  FROM CLIENTES
 WHERE codCliente = @codCliente

 SELECT @nombreEstado = descripcion
  FROM ESTADOS_PEDIDO
 WHERE codEstado = @codEstado

PRINT CONCAT('PEDIDO: ',       @codPedido,       CHAR(10),
			 'CLIENTE: ',      @nombreCliente,   CHAR(10),
			 'FECHA PEDIDO: ', @fechaPedido,     CHAR(10),
			 'ESTADO: ',       @nombreEstado)

-------------------------------------------------------------------------------------------
-- 5. Crea un script que dadas dos variables: porcentaje y gama
--		Incremente el precio de los productos de dicha gama en el porcentaje que se le pasa
--
-- Salida: 'Se ha aumentado el precio un XXXX% de la gama YYYY'
-------------------------------------------------------------------------------------------




-------------------------------------------------------------------------------------------
-- 6. Crea un script que devuelva cuántos clientes han realizado algún pedido de
--   al menos 3 productos (siendo el número de productos una variable).
--	
-- Salida: 'Existen XXXX clientes en la BD que han realizado pedidos de al menos YYYY productos'
-------------------------------------------------------------------------------------------





-------------------------------------------------------------------------------------------
-- 7. Crea un script que a partir de una variable codCliente devuelva el nombre completo de su
-- 		representante de ventas y la ciudad de la oficina en la que trabaja.
--	
-- Salida: 'El cliente XXXX tiene como representante a YYYY y trabaja en la ciudad de ZZZZ'
-------------------------------------------------------------------------------------------

