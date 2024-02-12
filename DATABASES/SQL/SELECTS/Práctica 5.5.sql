		-----------------------------------------------------
		-- Ejercicio 5.5. Escribe las siguientes consultas
		--					utilizando la BD JARDINERIA
		-----------------------------------------------------

					--------------------------
					--		CONSULTAS	    --
					--------------------------
USE JARDINERIA
-----------------------------------
-- A) Consultas de conjuntos (4) --
-----------------------------------

-- 1. Devuelve los códigos de los clientes que realizaron pedidos en 2022 y los clientes que realizaron pagos por transferencia. Utiliza la unión.

SELECT codCliente
  FROM PAGOS
 WHERE codFormaPago = 'T'
 UNION
SELECT codCliente
  FROM PEDIDOS
 WHERE YEAR(fecha_pedido) = 2022

	-- Con subconsultas
	SELECT codCliente
	  FROM PAGOS
	 WHERE codFormaPago = (SELECT codFormaPago
							 FROM FORMA_PAGO
							WHERE LOWER(descripcion) = 'transferencia')
	 UNION
	SELECT codCliente
	  FROM PEDIDOS
	 WHERE codCliente IN (SELECT codCliente
						    FROM PEDIDOS
						   WHERE YEAR(fecha_pedido) = 2022)

-- 2. Devuelve los códigos de los clientes que realizaron pedidos en 2022 y que también realizaron algún pago por transferencia. Utiliza la intersección.

	SELECT codCliente
	  FROM PAGOS
	 WHERE codFormaPago = 'T'
 INTERSECT
	SELECT codCliente
	  FROM PEDIDOS
	 WHERE YEAR(fecha_pedido) = 2022

		-- Con subconsultas
		SELECT DISTINCT cl.CodCLiente
		  FROM CLIENTES cl,	
			   PAGOS pa
		 WHERE cl.codCliente = pa.codCliente
		   AND pa.codFormaPago = (SELECT codFormaPago
									FROM FORMA_PAGO
								   WHERE LOWER(descripcion) = 'transferencia')
		   AND pa.codCliente IN (SELECT codCliente
								   FROM PEDIDOS
								  WHERE YEAR(fecha_pedido) = 2022)

-- 3. Devuelve los códigos de los clientes que realizaron pedidos en 2022 PERO QUE NO los clientes que realizaron pagos por transferencia. Utiliza la diferencia.

SELECT codCliente
  FROM PEDIDOS
 WHERE YEAR(fecha_pedido) = 2022
EXCEPT
SELECT codCliente
  FROM PAGOS
 WHERE codFormaPago = 'T'

-- 4. Propón el enunciado de una consulta de conjuntos y escribe la consulta SQL.
	-- Devuelve los códigos de los clientes que realizaron pagos por tarjeta de crédito o realizaron pedidos en el primer trimestre de 
	-- 2023, pero excluye a aquellos clientes que realizaron ambos tipos de transacciones. Utiliza la operación de diferencia.

    SELECT DISTINCT codCliente AS clienteCredito
	  FROM PAGOS
	 WHERE codFormaPago = 'C'
	 UNION
	SELECT DISTINCT codCliente AS Cliente1Trimestre2023
	  FROM PEDIDOS
	 WHERE YEAR(fecha_pedido) = 2023
	   AND MONTH(fecha_pedido) BETWEEN 1 AND 3
	EXCEPT
	SELECT codCliente
	  FROM PAGOS
	 WHERE codFormaPago = 'C'
 INTERSECT
	SELECT codCliente
	  FROM PEDIDOS
	 WHERE YEAR(fecha_pedido) = 2023
	   AND MONTH(fecha_pedido) BETWEEN 1 AND 3

----------------------------------
--    B) Subconsultas (20)      --
----------------------------------
-- Con operadores básicos de comparación

-- 1. Devuelve el nombre del cliente con mayor límite de crédito.

SELECT TOP(1) limite_credito,
	   nombre_cliente
  FROM CLIENTES
 GROUP BY nombre_cliente, limite_credito
 ORDER BY limite_credito DESC

SELECT nombre_cliente
  FROM CLIENTES
 WHERE limite_credito = (SELECT TOP(1) limite_credito
					       FROM CLIENTES
						  ORDER BY limite_credito DESC)

SELECT nombre_cliente
  FROM CLIENTES
 WHERE limite_credito = (SELECT MAX(limite_credito)
					       FROM CLIENTES)	 

-- 2. Devuelve el nombre del producto que tenga el precio de venta más caro.

SELECT TOP(1) nombre,
	   precio_venta 
  FROM PRODUCTOS
 GROUP BY nombre, precio_venta
 ORDER BY precio_venta DESC

SELECT nombre
  FROM PRODUCTOS
 WHERE precio_venta = (SELECT TOP(1) precio_venta
					     FROM PRODUCTOS
					    ORDER BY precio_venta DESC)

SELECT nombre
  FROM PRODUCTOS
 WHERE precio_venta = (SELECT MAX(precio_venta)
					     FROM PRODUCTOS)
						 
-- 3. Devuelve el producto que más unidades tiene en stock. Si salen varios, quédate solo con uno.

SELECT TOP(1) *
  FROM PRODUCTOS
 GROUP BY nombre, cantidad_en_stock
 ORDER BY cantidad_en_stock DESC

SELECT TOP(1) *
  FROM PRODUCTOS
 WHERE cantidad_en_stock = (SELECT TOP(1) cantidad_en_stock
					          FROM PRODUCTOS 
						     ORDER BY cantidad_en_stock DESC)

SELECT TOP(1) *
  FROM PRODUCTOS
 WHERE cantidad_en_stock = (SELECT MAX(cantidad_en_stock)
					          FROM PRODUCTOS)
						 
-- 4. Devuelve el producto que menos unidades tiene en stock.

SELECT TOP(1) *
  FROM PRODUCTOS
 GROUP BY nombre, cantidad_en_stock
 ORDER BY cantidad_en_stock ASC

SELECT TOP(1) *
  FROM PRODUCTOS
 WHERE cantidad_en_stock = (SELECT TOP(1) cantidad_en_stock
					          FROM PRODUCTOS 
						     ORDER BY cantidad_en_stock ASC)

SELECT TOP(1) *
  FROM PRODUCTOS
 WHERE cantidad_en_stock = (SELECT MIN(cantidad_en_stock)
					          FROM PRODUCTOS)

-- 5. Devuelve el nombre, los apellidos y el email de los empleados que están a cargo de Alberto Soria.

SELECT nombre,
	   CONCAT(apellido1,' ', apellido2) AS apellidos,
	   email
  FROM EMPLEADOS
 WHERE codEmplJefe = (SELECT codEmpleado
						FROM EMPLEADOS
					   WHERE LOWER(nombre) = 'alberto'
					     AND LOWER(apellido1) = 'soria'
					     AND LOWER(apellido2) = 'carrasco')

-- 6. Propón el enunciado de una consulta de conjuntos y escribe la consulta SQL (puede ser de cualquier tipo, con IN, NOT IN, ALL, ANY, etc).
	-- Devuelve el código y nombre del cliente, el contacto de este y la ciudad de los clientes que tienen un límite de crédito superior al límite de crédito promedio y 
	-- que hayan realizado al menos un pedido en el último trimestre de 2023.

SELECT codCliente,
	   nombre_cliente AS nombreCliente,
	   CONCAT(nombre_contacto, ' ', apellido_contacto) AS nombreContactoCliente,
	   ciudad
  FROM CLIENTES
 WHERE limite_credito > (SELECT AVG(limite_credito)
						   FROM CLIENTES)
   AND codCliente IN (SELECT codCliente
					    FROM PEDIDOS
				       WHERE YEAR(fecha_pedido) = 2023
	   			         AND MONTH(fecha_pedido) BETWEEN 1 AND 3)

--------------------------------------------------------------------
--  Subconsultas con ALL y ANY  --
--  IMPORTANTE: NO UTILIZAR MAX o MIN en las subconsultas
--------------------------------------------------------------------

-- 1. Devuelve el nombre del cliente con mayor límite de crédito.

SELECT nombre_cliente
  FROM CLIENTES
 WHERE limite_credito >= ALL (SELECT limite_credito 
 							    FROM CLIENTES) 	 

-- 2. Devuelve el nombre del producto que tenga el precio de venta más caro.

SELECT nombre
  FROM PRODUCTOS
 WHERE precio_venta >= ALL (SELECT precio_venta 
 					          FROM PRODUCTOS) 	 

-- 3. Devuelve el producto que menos unidades tiene en stock.

SELECT *
  FROM PRODUCTOS
 WHERE cantidad_en_stock <= ALL (SELECT cantidad_en_stock 
 								   FROM PRODUCTOS)  

----------------------------------
-- Subconsultas con IN y NOT IN --
----------------------------------

-- 1. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.

SELECT *
  FROM CLIENTES
 WHERE codCliente NOT IN (SELECT codCliente
						    FROM PAGOS)

-- 2. Devuelve un listado que muestre solamente los clientes que han realizado algún pago.

SELECT *
  FROM CLIENTES
 WHERE codCliente IN (SELECT codCliente
					    FROM PAGOS)

-- 3. Devuelve un listado de los productos que nunca han aparecido en un pedido.

SELECT *
  FROM PRODUCTOS
 WHERE codProducto NOT IN (SELECT codProducto
						     FROM DETALLE_PEDIDOS)

-- 4. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente.

SELECT CONCAT(em.nombre,' ',em.apellido1,' ',em.apellido2) AS nombreEmpleado,
	   em.puesto_cargo,
	   ofi.telefono
  FROM EMPLEADOS em, OFICINAS ofi
 WHERE em.codEmpleado NOT IN (SELECT cl.codEmpl_ventas
						        FROM CLIENTES cl)
   AND em.codOficina = ofi.codOficina

-- 5. Devuelve las oficinas donde trabajan alguno de los empleados.

SELECT *
  FROM OFICINAS
 WHERE codOficina IN (SELECT codOficina
					    FROM EMPLEADOS)
			   
-- 6. Devuelve un listado con los clientes que han realizado algún pedido pero no que hayan realizado ningún pago.

	--Comprobar cuales no tienen pagos
	SELECT *
	FROM CLIENTES
	WHERE codCliente NOT IN (SELECT codCliente
								FROM PAGOS)
	-- Comprobar cuales tienen pedidos
	SELECT *
	FROM CLIENTES
	WHERE codCliente IN(SELECT codCliente
						FROM PEDIDOS)

SELECT *
  FROM CLIENTES
 WHERE codCliente NOT IN(SELECT codCliente
						   FROM PAGOS)
   AND codCliente IN(SELECT codCliente
					   FROM PEDIDOS)

------------------------------------------
-- Subconsultas con EXISTS y NOT EXISTS --
------------------------------------------

-- 1. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.

SELECT *
  FROM CLIENTES
 WHERE NOT EXISTS (SELECT *
				     FROM PAGOS
				    WHERE codCliente = clientes.codCliente)

-- 2. Devuelve un listado que muestre solamente los clientes que han realizado algún pago.

SELECT *
  FROM CLIENTES
 WHERE EXISTS (SELECT *
			     FROM PAGOS
				WHERE codCliente = clientes.codCliente)

-- 3. Devuelve un listado de los productos que nunca han aparecido en un pedido.

SELECT *
  FROM PRODUCTOS
 WHERE NOT EXISTS (SELECT *
				     FROM DETALLE_PEDIDOS
				    WHERE codProducto = productos.codProducto)

-- 4. Devuelve un listado de los productos que han aparecido en un pedido alguna vez.

SELECT *
  FROM PRODUCTOS
 WHERE EXISTS (SELECT *
				 FROM DETALLE_PEDIDOS
			    WHERE codProducto = productos.codProducto)

---------------------------
--		  Vistas		 --
---------------------------

-- 1. Crea una vista que devuelva los códigos de los clientes que realizaron pedidos en 2009 y los clientes que realizaron pagos por transferencia. Utiliza la unión.

GO
CREATE VIEW VPedidosTransferencia2009 AS
	 SELECT codCliente
  	   FROM PAGOS
 	  WHERE codFormaPago = 'T'
	  UNION
	 SELECT codCliente
  	   FROM PEDIDOS
	  WHERE YEAR(fecha_pedido) = 2009
GO

-- 2. Escribe el código SQL para realizar una consulta a dicha vista

SELECT *
  FROM VPedidosTransferencia2009

-- 3. Escribe el código SQL para eliminar dicha vista.

DROP VIEW VPedidosTransferencia2009