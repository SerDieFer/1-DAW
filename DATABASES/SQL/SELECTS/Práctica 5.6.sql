--------------------------------------------------
-- Ejercicio de ampliación 5.6. Escribe las siguientes
-- consultas utilizando la base de datos SUPERTIENDA
--------------------------------------------------
USE SUPERTIENDA
-------------------------
-- 		CONSULTAS      --
-------------------------

-- 1. Obtener todos los productos ordenados alfabéticamente por el nombre 

SELECT *
FROM PRODUCTOS
ORDER BY nombre ASC

-- 2. Obtener todos los campos de todos los clientes que pertenezcan a la provincia de Madrid y sean del municipio de Alcorcón

SELECT *
  FROM CLIENTES
 WHERE codProv IN (SELECT codProv
				     FROM PROVINCIAS
				    WHERE LOWER(nombre) = 'madrid')
   AND codMuni IN (SELECT codMuni
				     FROM MUNICIPIOS
				    WHERE LOWER(nombre) = 'alcorcón')

-- 3. Obtener los productos que tengan un precio entre 20 y 22 € y cuyo IVA sea del 10%

SELECT nombre AS nombreProducto,
	   precioUnitario,
	   IVA
  FROM PRODUCTOS
 WHERE precioUnitario BETWEEN 20 AND 22
   AND IVA = 10

-- 4. Devuelve las tiendas que pertenezcan a la Comunidad Valenciana.

SELECT *
  FROM TIENDAS
 WHERE codProv IN (SELECT codProv
			         FROM PROVINCIAS
				    WHERE LOWER(nombre) LIKE 'castellón%' 
				       OR LOWER(nombre) LIKE 'valencia%'
				       OR LOWER(nombre) LIKE 'alicante%')

-- 5. Devuelve el número de clientes cuyo nombre empiece por JOSE

SELECT nombre
  FROM CLIENTES
 WHERE LOWER(LEFT(nombre,4)) = 'jose'

SELECT COUNT(nombre) AS numCLientesJose
  FROM CLIENTES
 WHERE LOWER(LEFT(nombre,4)) = 'jose'

-- 6. Devuelve el número de empresas dadas de alta utilizando el campo NIFCIF

SELECT NIFCIF
  FROM CLIENTES 
 WHERE LEFT(NIFCIF, 1) BETWEEN 'A' AND 'Z'

SELECT COUNT(codCliente)
  FROM CLIENTES
 WHERE LEFT(NIFCIF, 1) BETWEEN 'A' AND 'Z'

-- 7. Devuelve el nombre y apellidos (en una sola columna) de los empleados que trabajan en la tienda 7

SELECT CONCAT(nombre, ' ', apellidos)   
  FROM VENDEDORES
 WHERE codTienda = 7

-- 8. Devuelve el nombre los/as jefes/as de las tiendas ubicadas en la Comunidad Valenciana

SELECT CONCAT(nombre, ' ', apellidos)   
  FROM VENDEDORES
 WHERE codVendedorJefe IS NULL
   AND codTienda IN (SELECT codTienda
   					   FROM TIENDAS
					  WHERE codProv IN (SELECT codProv
										  FROM PROVINCIAS
										 WHERE LOWER(nombre) LIKE 'castellón%' 
											OR LOWER(nombre) LIKE 'valencia%'
											OR LOWER(nombre) LIKE 'alicante%'))

-- 9. Devuelve el nombre los/as jefes/as de las tiendas ubicadas de la Comunidad Valenciana y además el nombre de la tienda

SELECT CONCAT(ven.nombre, ' ', ven.apellidos) AS nombreJefe,
	   tie.nombre AS nombreTienda
  FROM VENDEDORES ven,
	   TIENDAS tie
 WHERE ven.codVendedorJefe IS NULL
   AND ven.codTienda = tie.codTienda
   AND tie.codProv IN (SELECT codProv
					     FROM PROVINCIAS
						WHERE LOWER(nombre) LIKE 'castellón%' 
						   OR LOWER(nombre) LIKE 'valencia%'
						   OR LOWER(nombre) LIKE 'alicante%')
   
-- 10. Devuelve los municipios de la provincia de alicante ordenados alfabéticamente de mayor a menor

SELECT muni.codProv,
	   muni.nombre AS nombreMunicipioDeAlc
  FROM PROVINCIAS pro,
	   MUNICIPIOS muni
 WHERE muni.codProv = pro.codProv 
   AND LOWER(pro.nombre) LIKE 'alicante%'
 ORDER BY muni.nombre DESC

-- 11. Obtener las provincias cuyo nombre NO contiene ninguna 'o'

SELECT nombre
  FROM PROVINCIAS
 WHERE nombre NOT LIKE '%o%'
   AND nombre NOT LIKE '%ó%'
 
-- 12. Obtener las provincias cuyo nombre NO contiene ninguna 'o' NI NINGUNA 'e'

SELECT nombre
  FROM PROVINCIAS
 WHERE nombre NOT LIKE '%o%'
   AND nombre NOT LIKE '%ó%'
   AND nombre NOT LIKE '%e%'
   AND nombre NOT LIKE '%é%'
  
-- 13. Disponemos de una tabla para almacenar el periodo de las campañas de marketing de la empresa.
-- Obtén qué campaña teníamos activa el día 22 de diciembre

SELECT *
  FROM CAMPANYAS
 WHERE '2024-12-22' BETWEEN fechaInicio AND fechaFin;

-- 14. Obtén la información de los 5 primeros clientes cuyo nombre empiece por la letra 'A' y su primer apellido por la 'B'

SELECT *
  FROM CLIENTES
 WHERE LEFT(UPPER(nombre), 1) = 'A'
   AND LEFT(UPPER(apellidos), 1) = 'B'

-- 15. Obtén la información de los 5 primeros clientes cuyo nombre empiece por la letra 'A', su primer apellido por la 'B'
-- y el segundo apellido por L (suponemos que el segundo apellido es el que viene después del primer espacio en blanco en 
-- los apellidos)

SELECT *
  FROM CLIENTES
 WHERE LEFT(UPPER(nombre), 1) = 'A'
   AND UPPER(apellidos) LIKE 'B% L%'

-- 16. Devuelve el precio del producto más barato y el más caro en la misma consulta

SELECT MAX(precioUnitario) AS precioMáximo,
	   MIN(precioUnitario) AS precioMínimo
  FROM PRODUCTOS

-- 17. Devuelve el número de productos totales que tengan un precio entre 100€ y 200€ (ambos inclusive) -> 

SELECT COUNT(codProducto)
  FROM PRODUCTOS
 WHERE precioUnitario BETWEEN 100 AND 200 

-- 18. Disponemos de una tabla para almacenar qué compañías de transporte trabajan con la empresa y su estado.
-- Obtén cuántas empresas de transporte tenemos en cada estado.

SELECT COUNT(estadoAlta),
	   estadoAlta
FROM COMPANYIAS_TRANSPORTE
GROUP BY estadoAlta

-- 19. Obtén él número de municipios que tenemos en cada provincia (ordenado de mayor a menor)

SELECT COUNT(muni.codMuni) AS numMunicipios,
	   prov.nombre
  FROM PROVINCIAS prov,
	   MUNICIPIOS muni
 WHERE prov.codProv = muni.codProv
 GROUP BY prov.nombre
 ORDER BY numMunicipios DESC

-- 20. Modifica la consulta anterior para que solo aparezcan aquellas provincias que AL MENOS tengan 250 municipios

SELECT COUNT(muni.codMuni) AS numMunicipios,
	   prov.nombre
  FROM PROVINCIAS prov,
	   MUNICIPIOS muni
 WHERE prov.codProv = muni.codProv
 GROUP BY prov.nombre
HAVING COUNT(muni.codMuni) >= 250
 ORDER BY numMunicipios DESC

-- 21. Modifica la consulta anterior para que en lugar del código de la provincia aparezca su nombre

SELECT COUNT(muni.codMuni) AS numMunicipios,
	   prov.nombre
  FROM PROVINCIAS prov,
	   MUNICIPIOS muni
 WHERE prov.codProv = muni.codProv
 GROUP BY prov.nombre
HAVING COUNT(muni.codMuni) >= 250
 ORDER BY numMunicipios DESC

-- 22. Modifica la consulta anterior para que en lugar de aparecer los que tengan más de 250 municipios, 
-- aparezcan los que tengan entre 50 y 75 municipios.

SELECT COUNT(muni.codMuni) AS numMunicipios,
	   prov.nombre
  FROM PROVINCIAS prov,
	   MUNICIPIOS muni
 WHERE prov.codProv = muni.codProv
 GROUP BY prov.nombre
HAVING COUNT(muni.codMuni) BETWEEN 50 AND 75
 ORDER BY numMunicipios DESC

-- 23. Obtén el nombre de las subcategorías incluidas dentro de la categoría principal 'Series y películas'
	-- NOTA: Deberá aparecer tanto el nombre de la categoría principal como el nombre de todas las subcategorías
	-- Los nombres de las columnas serán: nombreCat y nombreSubCat
	-- Ordena el resultado alfabéticamente de menor a mayor por el nombre de la subcategoría

SELECT cat.nombre AS nombreCat,
	   sub.nombre AS nombreSubCat 
  FROM SUBCATEGORIAS sub,
	   CATEGORIAS cat
 ORDER BY sub.nombre ASC

-- 24. Obtener el nombre de las tiendas y la cantidad en stock, en las que el juego 'PS5 The Eternal Cylinder' 
-- se encuentra en stock. Ordénalo por el que tenga mayor cantidad en stock primero

SELECT tien.nombre AS tiendaQueTieneStock,
	   st.stock AS numUnidades
  FROM TIENDAS tien,
	   STOCK_PRODUCTOS st
 WHERE st.codProducto IN (SELECT codProducto
						    FROM PRODUCTOS
						   WHERE nombre = 'PS5 The Eternal Cylinder'
						     AND stock >= 1)
   AND tien.codTienda = st.codTienda
 ORDER BY st.stock DESC

-- 25. A partir de la consulta anterior, obtén qué tiendas necesitan solicitar unidades de ese juego a la central

SELECT tien.nombre AS tiendaQueTieneStock,
	   st.stock AS numUnidades
  FROM TIENDAS tien,
	   STOCK_PRODUCTOS st
 WHERE st.codProducto IN (SELECT codProducto
							FROM PRODUCTOS
						   WHERE nombre = 'PS5 The Eternal Cylinder'
							 AND stock = 0)
   AND tien.codTienda = st.codTienda
 ORDER BY st.stock DESC

-- 26. Obtén el coste medio de los envíos realizados por cada transportista, obteniendo el nombre del transportista y el coste medio

SELECT AVG(pe.costeEnvio) AS precioMedioEnvios,
	   trans.nombre AS nombreTransportista
  FROM PEDIDOS pe,
	   COMPANYIAS_TRANSPORTE trans
  WHERE pe.codTransportista = trans.codTransportista
    AND pe.fecEntrega IS NOT NULL -- Duda de si se cobra el envío en caso de que sea NULL
  GROUP BY trans.nombre

 ---------------------------------------------------------------------------------------
-- 27. Obtener los pedidos que se hayan entregado a través de cualquier agencia de transporte 
-- en un plazo no superior a 3 días
	--
	-- Los campos que deben salir son:
	-- - idPedido, plazo, fecHoraPedido, fecEntrega, datosCliente, datosVendedor
	-- - datosCliente se forma concatenando el nombre y los apellidos del cliente
	-- - datosVendedor se forma concatenando el nombre y los apellidos del vendedor
	-- - Se debe ordenar ascendentemente por codPedido
---------------------------------------------------------------------------------------

SELECT pe.codPedido,
	   DATEDIFF(DAY, pe.fecHoraPedido, pe.fecPrevEntrega) AS plazoEntrega,
	   pe.fecHoraPedido,
	   pe.fecPrevEntrega,
	   pe.fecEntrega,
	   CONCAT(cli.nombre,' ',cli.apellidos) AS nombreCliente,
	   CONCAT(ven.nombre,' ',ven.apellidos) AS datosVendedor
  FROM PEDIDOS pe,
	   CLIENTES cli,
	   VENDEDORES ven
 WHERE DATEDIFF(DAY, pe.fecPrevEntrega, pe.fecEntrega) <= 3
   AND pe.codCliente = cli.codCliente
   AND ven.codVendedor = pe.codVendedor
 ORDER BY pe.codPedido ASC

 ---------------------------------------------------------------------------------------
-- 29. Obtén el número de pedidos realizados por cada cliente (si un cliente no ha realizado ningún pedido 
-- no aparecerá en la consulta) Deberá devolver el codCliente, el nombre completo del cliente y el número 
-- de pedidos realizados por cada uno de ellos
 ---------------------------------------------------------------------------------------

SELECT COUNT(pe.codPedido) AS pedidosCliente,
	   cli.codCliente,
	   CONCAT(cli.nombre,' ',cli.apellidos) AS nombreCliente
  FROM PEDIDOS pe,
	   CLIENTES cli
 WHERE cli.codCliente = pe.codCliente
 GROUP BY cli.codCliente, CONCAT(cli.nombre,' ',cli.apellidos)
 ORDER BY pedidosCliente ASC

SELECT COUNT(pe.codPedido) AS pedidosCliente,
       cli.codCliente,
       CONCAT(cli.nombre, ' ', cli.apellidos) AS nombreCliente
  FROM CLIENTES cli JOIN PEDIDOS pe 
    ON cli.codCliente = pe.codCliente
 GROUP BY cli.codCliente, CONCAT(cli.nombre, ' ', cli.apellidos)
 ORDER BY pedidosCliente ASC
    
 ---------------------------------------------------------------------------------------
-- 29. Obtén el número de pedidos realizados por cada cliente
	-- IMPORTANTE: si un cliente no ha realizado ningún pedido aparecerá igualmente con 0 pedidos
	-- Los campos a obtener en la consulta son los mismos que los de la consulta anterior.
	--
	-- NOTA: Las consultas RIGHT/LEFT JOIN a veces no funcionan porque hay que mostrar el campo 
	-- de la tabla que aparece en la LEFT (c.idCliente)
 ---------------------------------------------------------------------------------------

SELECT COUNT(pe.codPedido) AS pedidosCliente,
       cli.codCliente,
       CONCAT(cli.nombre, ' ', cli.apellidos) AS nombreCliente
  FROM CLIENTES cli LEFT JOIN PEDIDOS pe 
    ON cli.codCliente = pe.codCliente
 GROUP BY cli.codCliente, CONCAT(cli.nombre, ' ', cli.apellidos)
 ORDER BY pedidosCliente ASC

 ---------------------------------------------------------------------------------------
-- 30. Obtén el número de pedidos realizados por cada cliente y el total gastado en todos los pedidos
	-- IMPORTANTE: si un cliente no ha realizado ningún pedido aparecerá igualmente con 0 pedidos y 0 € gastados
	-- Los campos a obtener en la consulta son los mismos que los de la consulta anterior.
	--
	-- Nivel: DIFICIL
	--
	-- Ayuda: al introducir la tabla LINEA_PEDIDO es posible que el mismo codPedido se cuente varias veces (uno por línea)
	-- por lo que sería interesante que te asegures de que sean DIFERENTES antes de CONTARLOS ;-)
	--
	-- Ayuda2: piensa que si el cliente NO ha hecho pedidos, tampoco tendrá registros en LINEA_PEDIDO 
	-- (por lo que INNER JOIN no es una buena opción) para unir las tablas PEDIDO y LINEA_PEDIDO
	--
	-- Ayuda3: si en gasto te aparece NULL, seguro que hay una función que puede cambiar el NULL por un 0 dentro de una SELECT...
 ---------------------------------------------------------------------------------------

SELECT cli.codCliente,
       CONCAT(cli.nombre, ' ', cli.apellidos) AS nombreCliente,
	   COALESCE(COUNT(DISTINCT pe.codPedido), 0) AS numPedidos,
       COALESCE(SUM(lpe.totalLinea), 0) AS sumaPrecioPedidos  
 FROM CLIENTES cli LEFT JOIN PEDIDOS pe 
   ON cli.codCliente = pe.codCliente
 LEFT JOIN LINEAS_PEDIDOS lpe
   ON pe.codPedido = lpe.codPedido
GROUP BY cli.codCliente, CONCAT(cli.nombre, ' ', cli.apellidos)

-- SUBCONSULTAS (operadores básicos de comparación)
------------------------------------------------------------------------------------------------------------------
-- 30. Devuelve el nombre y el precio del producto que tenga el precio de venta más caro.
	-- Evidentemente, no se puede introducir un codProducto directamente, habrá que obtenerlo mediante una subconsulta
------------------------------------------------------------------------------------------------------------------

SELECT nombre,
	   precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario = (SELECT MAX(precioUnitario)
						   FROM PRODUCTOS)

-- 31. Devuelve el codProducto que más unidades tiene en stock en la tienda con codTienda=1. Si salen varios, quédate solo con uno.

SELECT TOP(1) codProducto AS productoConMayorStock,
	   stock AS cantidadProducto
  FROM STOCK_PRODUCTOS
 WHERE codTienda = (SELECT codTienda
					  FROM TIENDAS
					 WHERE codTienda = 1)
 ORDER BY stock DESC

-----------------------------------------------------------------------------------------
-- 32. Modifica la consulta anterior y devuelve los datos de dicho producto (sin introducir el codProducto directamente, claro)
-----------------------------------------------------------------------------------------

SELECT *
  FROM PRODUCTOS
 WHERE codProducto = (SELECT TOP(1) codProducto AS productoConMayorStock
  					    FROM STOCK_PRODUCTOS
					   WHERE codTienda = (SELECT codTienda
					                        FROM TIENDAS
					                       WHERE codTienda = 1)
					   ORDER BY stock DESC)

-----------------------------------------------------------------------------------------
-- 33. Devuelve el nombre y el precio de los productos cuyo precio sea MAYOR o IGUAL 
--		que la media del precio de todos los productos
-----------------------------------------------------------------------------------------

SELECT nombre,
       precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario >= (SELECT AVG(precioUnitario)
  							FROM PRODUCTOS)
 ORDER BY precioUnitario ASC

-- 34. Devuelve los vendedores que están a cargo de la vendedora con nombre 'EVA' y apellidos 'ALCAIDE MORILLA'
	-- Debes utilizar una subconsulta para obtener los vendedores a su cargo
	-- Devuelve los campos: NIF, nombre, apellidos y el nombre de la tienda en la que trabajan

SELECT DISTINCT CONCAT(tra.nombre, ' ', tra.apellidos) AS datosVendedorACargo,
       tra.NIF AS NIFVendedorACargo,
       tie.nombre AS nombreTienda
  FROM VENDEDORES tra,
	   VENDEDORES jef,
	   TIENDAS tie
 WHERE tra.codVendedorJefe = (SELECT codVendedor
  						        FROM VENDEDORES
					           WHERE UPPER(nombre) = 'EVA'
						         AND UPPER(apellidos) ='ALCAIDE MORILLA')
   AND tra.codTienda = tie.codTienda

-- 35. Devuelve el nombre y el precio del producto que tenga el precio de venta más caro (utiliza ALL/ANY)

SELECT nombre,
	   precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario = ANY (SELECT MAX(precioUnitario)
 					  		   FROM PRODUCTOS)

SELECT nombre,
	   precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario = ALL (SELECT MAX(precioUnitario)
 					  		   FROM PRODUCTOS)						   

-- 36. Devuelve el nombre y el precio del producto que tenga el precio de venta más barato (utiliza ALL/ANY)

SELECT nombre,
	   precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario = ANY (SELECT MIN(precioUnitario)
 					  		   FROM PRODUCTOS)

SELECT nombre,
	   precioUnitario
  FROM PRODUCTOS
 WHERE precioUnitario = ALL (SELECT MIN(precioUnitario)
 					  		   FROM PRODUCTOS)	

-- 37. Devuelve los pedidos que tengan un coste de envío igual o superior a TODOS los productos de la subcategoría 72

SELECT *
  FROM PEDIDOS
 WHERE costeEnvio >= ANY (SELECT SUM(precioUnitario)
					        FROM PRODUCTOS
					       WHERE codSubcategoria = '72')
 ORDER BY costeEnvio DESC

-- 38. Devuelve los pedidos que tengan un coste de envío MENOR que el precio unitario de cualquier producto de la subcategoría 72

SELECT *
  FROM PEDIDOS
 WHERE costeEnvio <= ANY (SELECT SUM(precioUnitario)
					        FROM PRODUCTOS
					       WHERE codSubcategoria = '72')
 ORDER BY costeEnvio DESC


-- 39. Contabiliza cuántos pedidos están sin entregar a la espera de recogerlos en las tiendas
	-- Solo se deben contabilizar los pedidos que se recogen en tienda, no los que se envían online

SELECT COUNT(codPedido) AS pedidosSinEntregar
  FROM PEDIDOS
 WHERE recogidaTiendaSN = 'S'
   AND fecEntrega IS NULL

-- 40. Devuelve un listado que muestre los clientes que NUNCA hayan realizado ningún pedido.

	-- 40.1) Utiliza IN / NOT IN

	SELECT *
	  FROM CLIENTES
	 WHERE codCliente NOT IN (SELECT codCliente
							    FROM PEDIDOS)

	-- 40.2) Utiliza EXISTS / NOT EXISTS

	SELECT *
	  FROM CLIENTES cli
	 WHERE NOT EXISTS (SELECT codCliente
						 FROM PEDIDOS pe
						WHERE cli.codCliente = pe.codCliente)				  

---------------------------------------------
--- A PARTIR DE AQUI CUESTA COMPRENDERLOS ---
---------------------------------------------
-- 41. Devuelve un listado de los productos de la categoría 'SP' que nunca han aparecido en ningún pedido.  
	-- //TODO Preguntar a carlos

	-- 41.1) Utiliza IN / NOT IN

	SELECT *
	  FROM PRODUCTOS
	 WHERE codProducto NOT IN (SELECT codProducto
						         FROM LINEAS_PEDIDOS)
	   AND codSubcategoria IN (SELECT codSubcategoria
							     FROM SUBCATEGORIAS
							    WHERE codCategoria IN (SELECT codCategoria
							  						     FROM CATEGORIAS
													    WHERE codCategoria ='SP'))

	-- 41.2) Utiliza EXISTS / NOT EXISTS

    SELECT *
	  FROM PRODUCTOS pro
	 WHERE NOT EXISTS (SELECT codProducto
					 	 FROM LINEAS_PEDIDOS lpe
						WHERE pro.codProducto = lpe.codProducto)	
	   AND EXISTS (SELECT codCategoria
				     FROM CATEGORIAS
			        WHERE codCategoria ='SP')

-- 42. Obtén todos los campos del cliente que más unidades del juego Grand Theft Auto V de PS5 haya comprado 
	-- (No en un solo pedido, sino en todos). 
	-- //TODO Preguntar a carlos

SELECT cl.*
  FROM CLIENTES cl
  LEFT JOIN PEDIDOS pe 
    ON cl.codCliente = pe.codCliente
  LEFT JOIN LINEAS_PEDIDOS lp 
    ON pe.codPedido = lp.codPedido
 WHERE lp.codProducto = (SELECT codProducto
						   FROM PRODUCTOS
						  WHERE LOWER(nombre) = 'ps5 grand theft auto v')
   AND lp.unidades = (SELECT MAX(unidades)
                        FROM LINEAS_PEDIDOS
                       WHERE codProducto = (SELECT codProducto
					                          FROM PRODUCTOS
						                     WHERE LOWER(nombre) = 'ps5 grand theft auto v'))

SELECT *
  FROM LINEAS_PEDIDOS
 WHERE codProducto = (SELECT codProducto
					    FROM PRODUCTOS
					   WHERE LOWER(nombre) = 'ps5 grand theft auto v')
   AND unidades = (SELECT MAX())
 GROUP BY codPedido
  
	-- ????????? No se como abordarlo

-- 43. Obtén todos los campos del cliente que más dinero haya gastado en cualquier tienda
	-- //TODO Preguntar a carlos

SELECT *
  FROM PEDIDOS

SELECT *
  FROM CLIENTES
 WHERE codCliente IN (SELECT codCliente
					    FROM PEDIDOS)

	-- ????????? No se como abordarlo

-- 44. Obtén los datos del cliente que ha realizado el pedido más caro


-- 45. Obtén el coste para los pedidos comprendidos entre el 1 y el 5
	-- Recuerda que cada pedido tiene una o más LINEAS_PEDIDOS.
	-- Además se debe obtener el total para todos los pedidos.
	-- Ayuda: Hay un operador que se pone con GROUP BY que permite totalizar los resultados
	-- Ayuda2: El operador se llama ROLLUP


-- 46. Obtener el total vendido por cada uno de los vendedores y el total para todos los vendedores


-- 47. Obtener el total vendido por cada una de las tiendas, por cada vendedor y los subtotales
	-- Utilizar el operador ROLLUP


-- 48. Modifica la consulta anterior para que en lugar de aparecer NULL para el total por tienda aparezca 'Total tienda N'
	-- Siendo N el cod de cada una de las tiendas
	-- Ayuda: Debes utilizar la función COALESCE
	-- Ayuda2: Si tras utilizar la función COALESCE devuelve error de conversión a data type int, puedes probar a hacer un CAST de codTienda e codVendedor a VARCHAR.


-- 49. Consulta con el operador CUBE
	-- CUBE es un operador que se utiliza con GROUP BY para mostrar el resultado de la agrupación con todas las combinaciones posibles.
	-- Es muy similar a hacer un producto cartesiano de los campos de la agrupación y mostrará los totales por cada uno de ellos.
	-- Realiza una consulta que muestre por categorías y subcategorías la cantidad de productos (en función del stock) que tenemos almacenados.


---- CONSULTAS DE CONJUNTOS -------

	-- 50. Devolver la unión de dos consultas:
		-- 1) Selecciona los pedidos realizados en febrero de 2009
		-- 2) Selecciona los pedidos realizados en diciembre de 2009


-- 51. Devuelve los códigos de los clientes que han realizado algún pedido en enero de 2019 pero NO han realizado ningún pedido en el año 2020


-- 52. Modifica la consulta anterior para que se devuelvan los datos de los clientes


-- 53. Realiza una consulta de INTERSECCION que:
	-- Muestre los clientes que NO han realizado pedidos en 2021 ni tampoco en 2022, utilizando dos consultas


-- 54. Muestra el número de clientes a los que les haya atendido el jefe de una tienda (mirando el PEDIDO) 
	-- Ayuda: si no devuelve el número previsto, podrías ordenarlos para ver si son correctos...


-----------------------------------------------------------------------------------
--  CREACION, CONSULTA Y ELIMINACION DE VISTAS
--  55. Crea una vista llamada 'V_SELECT' a partir una de las consultas realizadas.
--  Recuerda. En las VISTAS no se permite utilizar la cláusula ORDER BY.
-----------------------------------------------------------------------------------


-- 56. Utiliza la vista anterior. Debe devolver lo mismo que ejecutar la consulta que la contiene.


-- 57. Elimina la vista creada


----------------------------------------------------------------------------------------------
-- CONSULTA TIPICA QUE SE UTILIZA EN UNA PÁGINA WEB PARA MOSTRAR LOS PRODUCTOS DISPONIBLES QUE BUSCA UN USUARIO CON PAGINACIÓN
-- 58. Consulta que devuelva los productos disponibles en una tienda concreta cuyo nombre coincida con una cadena introducida por el usuario, como por ejemplo. 'juego'
	-- Se debe devolver: codProducto, nombre, precio, IVA, nombre de la subcategoría en la que se encuentra, el nombre de la categoría principal y el precio SIN el IVA
	-- Debe aparecer ordenado ascendentemente por codProducto y limitar el número de elementos devueltos a 20.
	-- Parámetros: codTienda, string con el nombre producto, elementos por página
----------------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------------
-- 59. Adapta la consulta anterior para que se puedan visualizar los siguientes 20 elementos 
-- (Imagina que el usuario pincha en la página 2)
----------------------------------------------------------------------------------------------


------------------------------------------------------------
-- 60. Obtén la facturación anual de cada una de las tiendas
	-- Deben aparecer las columnas:
	-- idTienda, nombre de la tienda, totalNeto, totalBruto (incluyendo IVA), unidades vendidas totales
	-- Ayuda: Para que los importes aparezcan a dos decimales puedes utilizar la función CAST
	-- Se debe ordenar por total neto descendente
------------------------------------------------------------


------------------------------------------------------------
-- 61. Misma consulta anterior, pero deben aparecer únicamente las tiendas que hayan facturado un neto superior a 1.000.000€
------------------------------------------------------------


------------------------------------------------------------
-- 62. Obtén el número de valoraciones tenemos en función de las estrellas que le haya dado el cliente
	-- Ordena ascendentemente por las estrellas
------------------------------------------------------------


-- 63. Obtén el producto que más valoraciones de 5 estrellas ha recibido


-- 64. Obtén un TOP de los 10 vendedores que más importe en productos ha vendido (ordenado de mayor a menor)
-- de toda la historia de la tienda y el nombre de la tienda en la que trabaja


-- 65. Obtén las tiendas que hayan vendido menos de 50.000€ en toda su historia


-- 66. Obtén un TOP de los 5 vendedores que más importe en productos ha vendido (ordenado de mayor a menor) de diciembre de 2019


-------------------------------------------------------------
-- 67. Obtén las ganancias de todas las tiendas ordenado de menor a mayor por meses y años
-------------------------------------------------------------


 -------------------------------------------------------------
-- 68. Realiza la misma consulta pero particularizándolo solo para una tienda (por ejemplo, codTienda = 6)
-------------------------------------------------------------


