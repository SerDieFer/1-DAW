-----------------------------------------------------
-- Ejercicio 5.4. Escribe las siguientes consultas
--					utilizando la BD JARDINERIA
-----------------------------------------------------

USE JARDINERIA

--------------------------
--		CONSULTAS	    --
--------------------------

---------------------------------------
-- A) Consultas sobre una tabla (16) --
---------------------------------------

-- 1. Devuelve un listado con el código de oficina y la ciudad donde hay oficinas.

SELECT  codOficina AS codigoOficina, 
        ciudad AS ciudadOficina
  FROM OFICINAS

-- 2. Devuelve un listado con la ciudad y el teléfono de las oficinas del país España.

SELECT *
FROM OFICINAS

SELECT ciudad,
       telefono AS telefonoOficina
FROM OFICINAS
WHERE LOWER(pais) = 'españa'
       

-- 3. Devuelve un listado con el nombre, apellidos y email de los empleados cuyo jefe tiene un código de jefe igual a 7.

SELECT *
FROM EMPLEADOS

SELECT nombre,
       CONCAT(apellido1, ' ', apellido2) AS apellidos,
       email
  FROM EMPLEADOS
WHERE  codEmplJefe = 7

-- 4. Devuelve el nombre del puesto, nombre, apellidos y email del empleado que NO tiene ningún jefe/a

SELECT nombre,
       CONCAT(apellido1, ' ', apellido2) AS apellidos,
       email
  FROM EMPLEADOS
WHERE  codEmplJefe IS NULL

-- 5. Devuelve un listado con el nombre, apellidos y puesto de aquellos empleados que no sean representantes de ventas.

SELECT nombre,
       CONCAT(apellido1, ' ', apellido2) AS apellidos,
       puesto_cargo AS puestoEmpleado
  FROM EMPLEADOS
WHERE  LOWER(puesto_cargo) != 'representante ventas'

-- 6. Devuelve un listado con el nombre de los todos los clientes españoles.

SELECT *
FROM CLIENTES

SELECT nombre_cliente
  FROM CLIENTES
WHERE pais = 'SPAIN'

-- 7. Devuelve un listado con los distintos estados por los que puede pasar un pedido.

SELECT *
FROM PEDIDOS

SELECT codEstado
  FROM PEDIDOS
GROUP BY codEstado

-- 8. Devuelve un listado con el código de cliente de aquellos clientes que realizaron algún pago en 2023.
-- Ten en cuenta que deberás eliminar aquellos códigos de cliente que aparezcan repetidos.

SELECT *
FROM PAGOS

SELECT codCliente
  FROM PAGOS
 WHERE YEAR(fechaHora_pago) = 2023
 GROUP BY codCliente


-- 9. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.

SELECT pe.codPedido AS codigoPedido,
       cl.codCliente AS codigoCliente,
       pe.fecha_esperada AS fechaEntregaEsperada,
       pe.fecha_entrega AS fechaEntrega
  FROM PAGOS pa, 
       PEDIDOS pe,
       CLIENTES cl
WHERE fecha_entrega != fecha_esperada

-- 10. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los 
-- pedidos cuya fecha de entrega ha sido al menos dos días antes de la fecha esperada.

-- Utilizando la función DATEADD

SELECT codPedido AS codigoPedido,
       codCliente AS codigoCliente,
       fecha_esperada AS fechaEntregaEsperada,
       fecha_entrega AS fechaEntrega
  FROM PEDIDOS 
WHERE  DATEADD(day,2,fecha_entrega) <= fecha_esperada

-- 11. Misma consulta pero utilizando la función DATEDIFF

SELECT codPedido AS codigoPedido,
       codCliente AS codigoCliente,
       fecha_esperada AS fechaEntregaEsperada,
       fecha_entrega AS fechaEntrega,
       DATEDIFF(day, fecha_esperada, fecha_entrega) AS diasDiferencia
  FROM PEDIDOS 
WHERE  DATEDIFF(day, fecha_esperada, fecha_entrega) <= -2

-- 12. Devuelve un listado de todos los pedidos que fueron rechazados en 2022

SELECT codPedido
FROM PEDIDOS
WHERE UPPER(codEstado) = 'R'

-- 13. Devuelve un listado de todos los pedidos que han sido entregados en el mes de enero de cualquier año

SELECT codPedido,
       fecha_entrega
FROM PEDIDOS
WHERE UPPER(DATENAME(MONTH,fecha_entrega)) = 'january'


-- 14. Devuelve un listado con todos los pagos que se realizaron en el año 2022 mediante Paypal. Ordena el resultado de mayor a menor

SELECT *
FROM PAGOS

SELECT codPedido,
       fechaHora_pago
FROM PAGOS
WHERE UPPER(DATENAME(YEAR,fechaHora_pago)) = 2022
  AND UPPER(codFormaPago) = 'p'
ORDER BY codPedido DESC


-- 15. Devuelve un listado con todas las formas de pago que aparecen en la tabla PAGOS. Ten en cuenta que no deben aparecer formas de pago repetidas.

SELECT DISTINCT codFormaPago
from PAGOS


-- 16. Devuelve un listado con todos los productos que pertenecen a la categoría Ornamentales y que tienen más de 100 unidades en stock.
-- El listado deberá estar ordenado por su precio de venta, mostrando en primer lugar los de mayor precio.

SELECT *
FROM PRODUCTOS

SELECT nombre AS nombreProducto,
       codCategoria
  FROM PRODUCTOS
 WHERE codCategoria IN (SELECT codCategoria
                          FROM CATEGORIA_PRODUCTOS
                         WHERE UPPER(nombre) = 'Ornamentales')
   AND cantidad_en_stock > 100


-- 17. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y cuyo representante de ventas tenga el código de empleado 11 o 30

SELECT codEmpleado
FROM EMPLEADOS

SELECT nombre_cliente,
       ciudad,
       codEmpl_ventas
  FROM CLIENTES
WHERE  LOWER(ciudad) = 'madrid'
AND    codEmpl_ventas IN (SELECT codEmpl_ventas
                            FROM EMPLEADOS
                           WHERE codEmpleado BETWEEN 11 AND 30)


----------------------------------------------------------------
-- B) Consultas de agrupación o de funciones de agregado (18) --
----------------------------------------------------------------

-- 18. ¿Cuántos empleados hay en la compañía?

SELECT COUNT(codEmpleado) AS numEmpleados
FROM EMPLEADOS

-- 19. ¿Cuántos clientes tiene cada país?

SELECT COUNT(codCliente) AS numClientes,
       pais AS nombrePais
FROM CLIENTES
GROUP BY pais

-- 20. ¿Cuál fue el pago medio de 2022?

SELECT *
FROM CLIENTES

SELECT fechaHora_pago
FROM PAGOS

SELECT CAST(ROUND(AVG(importe_pago),2) AS FLOAT) AS mediaPago2022,
       YEAR(fechaHora_pago) AS fecha
  FROM PAGOS
GROUP BY YEAR(fechaHora_pago)
HAVING YEAR(fechaHora_pago) = 2022

-- 21. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.

SELECT codEstado AS estadoPedido,
       COUNT(codEstado) AS numPedidos
FROM PEDIDOS
GROUP BY codEstado
ORDER BY COUNT(codEstado) DESC

-- HACER REPLACE /

-- 22. Calcula el precio de venta del producto más caro y más barato en una misma consulta.

SELECT MAX(precio_venta) AS productoMasCaro,
       MIN(precio_venta) AS productoMasBarato
FROM PRODUCTOS


-- 23. ¿Cuántos clientes tiene la ciudad de Madrid?

SELECT COUNT(codCliente) AS numClientesMadrid
FROM CLIENTES
WHERE LOWER(ciudad) = 'madrid'

-- 24. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M?

SELECT COUNT(codCliente) AS numClientesCiudad,
       ciudad AS nombreCiudad
FROM CLIENTES
WHERE UPPER(LEFT(ciudad, 1)) = 'M'
GROUP BY ciudad

-- 25. Devuelve el código de los representantes de ventas y el número de clientes al que atiende cada uno.

SELECT codEmpl_ventas AS representanteVentas,
       COUNT(codCliente) AS numClientes
FROM CLIENTES
GROUP BY codEmpl_ventas

-- 26. Calcula el número de clientes que no tiene asignado representante de ventas.

SELECT COUNT(codCliente) AS numClientesSinRepresentante
FROM CLIENTES
WHERE codEmpl_ventas IS NULL

-- 27. Calcula el número de productos diferentes que hay en cada uno de los pedidos.

SELECT *
FROM DETALLE_PEDIDOS

SELECT codPedido AS numPedido,
       COUNT(codProducto) AS numeroProductos
FROM DETALLE_PEDIDOS
GROUP BY codPedido

-- 28. Calcula la suma de la cantidad total de todos los productos que aparecen en cada uno de los pedidos

SELECT codPedido AS numPedido,
       SUM(cantidad) AS cantidadProductos
FROM DETALLE_PEDIDOS
GROUP BY codPedido

-- 29. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno.
-- El listado deberá estar ordenado por el número total de unidades vendidas.

SELECT TOP(20) codProducto,
       cantidad
  FROM DETALLE_PEDIDOS
ORDER BY cantidad DESC

-- 30. Obtener el número de empleados por oficina, siempre que el número de empleados sea mayor que 4.

SELECT *
FROM OFICINAS

SELECT codOficina AS oficina,
       COUNT(codEmpleado) AS numEmpleados
FROM EMPLEADOS
GROUP BY codOficina
HAVING COUNT(codEmpleado) > 4

-- 31. Obtener los clientes que hayan realizado más de dos pagos de mínimo 1000 euros.
-- Mostrar también el número de pagos realizados.

SELECT *
FROM PAGOS

SELECT codCliente AS numClientes,
       COUNT(id_transaccion) AS numPagosTotales
FROM PAGOS
WHERE importe_pago >= 1000
GROUP BY codCliente
HAVING COUNT(id_transaccion) > 2

----------------------------------------------------------------
--				C) Consultas multitabla (10)				  --
----------------------------------------------------------------

SELECT *
FROM PAGOS

SELECT *
FROM CLIENTES

-- 32. Obtén los nombres de los productos, la cantidad y el precio para los productos incluidos en los pedidos 3 y 5. Ordénalo por número de pedido y número de producto ascendentemente.

SELECT pr.codProducto,
       pr.nombre,
       de.cantidad,
       pr.precio_venta AS precio
  FROM PRODUCTOS pr, PEDIDOS pe, DETALLE_PEDIDOS de
 WHERE de.codPedido = pe.codPedido
   AND de.codProducto = pr.codProducto
   AND pe.codPedido IN(3,5)
ORDER BY pe.codPedido, de.codProducto ASC
 
-- 33. Obtén un listado con los nombres de los clientes que han realizado algún pago. Deben aparecer los campos nombre cliente, fecha de pago y total ordenado ascendentemente por cliente y fecha.

SELECT cl.codCliente AS codigoCliente,
       cl.nombre_cliente AS nombre,
       pe.fechaHora_Pago AS fechaPago,
       pe.importe_pago AS totalPago
FROM CLIENTES cl, PAGOS pe
WHERE cl.codCLiente = pe.codCliente
ORDER BY cl.codCliente, pe.fechaHora_Pago

-- 34. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su representante de ventas.

SELECT cl.nombre_cliente AS nombreCliente,
       em.nombre AS nombreRepresentante,
       CONCAT(em.apellido1, ' ', em.apellido2) AS apellidosRepresentante
FROM CLIENTES cl, EMPLEADOS em
WHERE cl.codEmpl_ventas = em.codEmpleado


-- 35. Muestra el nombre de los clientes que hayan realizado pagos junto con el nombre de sus representantes de ventas. Solo deben aparecer una vez.

SELECT DISTINCT cl.nombre_cliente AS nombreCliente,
       em.nombre AS nombreRepresentante
FROM CLIENTES cl, 
     EMPLEADOS em, 
     PEDIDOS pe
WHERE cl.codCliente = pe.codCliente
AND cl.codEmpl_ventas = em.codEmpleado

-- 36. Devuelve el nombre de los clientes que han hecho pedidos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.

select *
from OFICINAS

SELECT DISTINCT cl.nombre_cliente AS nombreCliente,
       em.nombre AS nombreRepresentante,
       ofi.ciudad AS ciudadOficina
FROM CLIENTES cl, 
     EMPLEADOS em, 
     OFICINAS ofi, 
     PEDIDOS pe
WHERE cl.codCliente = pe.codCliente
AND cl.codEmpl_ventas = em.codEmpleado
AND em.codOficina = ofi.codOficina

-- 37. Lista la dirección de las oficinas que tengan clientes en Fuenlabrada.

SELECT *
FROM OFICINAS -- ACABAR ESTA SIN ARREGLAR

SELECT CONCAT(ofi.linea_direccion1, ',', ofi.linea_direccion2) AS direccionOficina,
       ofi.ciudad,
       cl.ciudad,
       cl.codCliente
FROM CLIENTES cl, 
     EMPLEADOS em,
     OFICINAS ofi
WHERE cl.codEmpl_ventas = em.codEmpleado
AND LOWER(cl.ciudad) = 'fuenlabrada'

-- 38. Devuelve un listado con el nombre de los empleados junto con el nombre de sus jefes (debes utilizar dos alias para la tabla EMPLEADOS).
SELECT ;

-- 39. Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido. Si se han retrasado varios pedidos, el cliente solo debe aparecer una vez.
SELECT ;

-- 40. Muestra el nombre de los clientes y el número de pagos que han realizado.
-- Deben aparecer todos, independientemente de si han realizado un pago o no.
SELECT ;

-- 41. Muestra el nombre de los clientes y el número de pedidos que han sido Entregados.
-- Deben aparecer todos, independientemente de si han realizado un pedido o no.
SELECT ;


