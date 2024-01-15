USE JARDINERIA
GO

-- Mostrar numClientes para cada ciudad

SELECT ciudad,COUNT(codCliente) AS numClientes
FROM CLIENTES
WHERE ciudad IN ('Barcelona' , 'Madrid')
GROUP BY ciudad
ORDER BY numClientes DESC

-- Mostrar el pedido y el importe total de todas las líneas de estos.

SELECT *
FROM DETALLE_PEDIDOS

SELECT codPedido, SUM(cantidad*precio_unidad) AS importeTotal
  FROM DETALLE_PEDIDOS
  GROUP BY codPedido
  ORDER BY importeTotal DESC

-- Mostrar numArticulos de cada gama cuyo precio venta sea mayor a 20

SELECT *
FROM PRODUCTOS

SELECT codCategoria, COUNT(codProducto) AS numArticulos, SUM(precio_venta) AS precioTotalCat
FROM PRODUCTOS
WHERE precio_venta > 20
GROUP BY codCategoria
ORDER BY codCategoria DESC


-- Mostrar numero de articulos de cada categoria cuyo numero total sea mayor o igual a 40.

SELECT codCategoria, COUNT(codProducto) AS numProdCat
FROM PRODUCTOS
GROUP BY codCategoria
HAVING COUNT(codProducto) >= 40
ORDER BY numProdCat DESC


-- Mostrar numero de pagos totales por cliente. Que su pago haya sido mayor a 1000.

SELECT *
FROM PAGOS

SELECT codCliente, COUNT(id_transaccion) AS numPagosCliente
FROM PAGOS
WHERE importe_pago > 1000
GROUP BY codCliente
HAVING COUNT(id_transaccion) > 2


-- Mostrar numero de pedidos totales por cliente.

SELECT codCliente, COUNT(codPedido) AS numPedidosCliente
FROM PEDIDOS
GROUP BY codCliente

-- Mostrar cuanto valdrían todos los pagos de un solo cliente

SELECT codCliente, 
       COUNT(id_transaccion) AS numPagosCliente,
       SUM(importe_pago) AS importeTotalPagos
  FROM PAGOS
GROUP BY codCliente
ORDER BY importeTotalPagos DESC

-- 

SELECT *
FROM  PAGOS

SELECT c.codCliente AS codigoCliente,
       c.nombre_cliente AS nombreCliente, 
       p.*
  FROM PAGOS p, 
       CLIENTES c
 WHERE p.codCliente = c.codCliente

-- 

SELECT *
FROM  PEDIDOS

SELECT c.nombre_cliente, p.*
 FROM PEDIDOS p,
      CLIENTES c
WHERE p.codCliente = c.codCliente;

--

SELECT e.codEmpleado,
       e.nombre,
       e.codEmplJefe,
       j.nombre AS nombreJefe
  FROM EMPLEADOS e, EMPLEADOS j
 WHERE e.codEmplJefe = j.codEmpleado

SELECT e.codEmpleado, 
       e.nombre, 
       e.codEmplJefe, 
       ISNULL(j.nombre, e.nombre) AS nombreJefe
  FROM EMPLEADOS e LEFT JOIN EMPLEADOS j
    ON e.codEmplJefe = j.codEmpleado

--

SELECT *
FROM  PEDIDOS

SELECT *
FROM  DETALLE_PEDIDOS

SELECT *
FROM  PRODUCTOS


SELECT pe.codPedido AS codigoPedido, 
       fecha_pedido AS fechaPedido, 
       dp.codProducto AS codigoProducto, 
       dp.cantidad AS cantidadProducto, 
       pr.nombre AS nombreProducto, 
       pr.codCategoria AS categoriaProducto,
       cpr.nombre AS nombreCategoria
  FROM PEDIDOS pe,
       DETALLE_PEDIDOS dp,
       PRODUCTOS pr,
       CATEGORIA_PRODUCTOS cpr
 WHERE dp.codPedido = pe.codPedido
   AND dp.codPedido = pr.codProducto
   AND pr.codCategoria = cpr.codCategoria