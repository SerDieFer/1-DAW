-------------------------------------------------------------------------
-- Ejercicios Refuerzo 2. Obtén las siguientes consultas con funciones --
-------------------------------------------------------------------------

			-----------------------------------------
			--		   CONSULTAS MULTITABLA	       --
			-----------------------------------------

USE TIENDAREPASO

-- 1. Devuelve una lista con el nombre del producto, precio y nombre de fabricante de todos los productos de la BD.

SELECT pr.nombre,
       pr.precio,
       fa.nombre AS nombreFab
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo

-- 2. Devuelve una lista con el nombre del producto, precio y nombre de fabricante de todos los productos de la BD.
-- Ordena el resultado por el nombre del fabricante, por orden alfabético.

SELECT pr.nombre,
       pr.precio,
       fa.nombre AS nombreFab
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 ORDER BY fa.nombre ASC

-- 3. Devuelve una lista con el identificador del producto, nombre del producto, identificador del fabricante y 
-- nombre del fabricante, de todos los productos de la base de datos.

SELECT pr.codigo,
	   pr.nombre,
       pr.codigo_fabricante,
       fa.nombre AS nombreFab
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo

-- 4. Devuelve el nombre del producto, su precio y el nombre de su fabricante, del producto más barato.

SELECT TOP(1) pr.nombre,
	   pr.precio,
       fa.nombre AS nombreFab
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 ORDER BY precio ASC

-- 5. Devuelve el nombre del producto, su precio y el nombre de su fabricante, del producto más caro.

SELECT TOP(1) pr.nombre,
	   pr.precio,
       fa.nombre AS nombreFab
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 ORDER BY precio DESC

-- 6. Devuelve una lista de todos los productos del fabricante Lenovo.

SELECT *
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE LOWER(fa.nombre) = 'lenovo'

-- 7. Devuelve una lista de todos los productos del fabricante Crucial que tengan un precio mayor que 200€.

SELECT *
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE LOWER(fa.nombre) = 'crucial'
   AND pr.precio > 200

-- 8. Devuelve un listado con todos los productos de los fabricantes Asus, Hewlett-Packardy Seagate. Sin utilizar el operador IN.

SELECT *
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE LOWER(fa.nombre) = 'ASUS'
    OR LOWER(fa.nombre) = 'Hewlett-Packard'
	OR LOWER(fa.nombre) = 'Seagate'

-- 9. Devuelve un listado con todos los productos de los fabricantes Asus, Hewlett-Packardy Seagate. Utilizando el operador IN.

SELECT *
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE LOWER(fa.nombre) IN ('ASUS','Hewlett-Packard','Seagate')

-- 10. Devuelve un listado con el nombre y el precio de todos los productos de los fabricantes cuyo nombre termine por la vocal e.

SELECT pr.nombre,
	   pr.precio
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE RIGHT(LOWER(fa.nombre),1) = 'e'

-- 11. Devuelve un listado con el nombre y el precio de todos los productos cuyo nombre de fabricante contenga el carácter w en su nombre.

SELECT pr.nombre,
	   pr.precio
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE LOWER(fa.nombre) LIKE '%w%'

-- 12. Devuelve un listado con el nombre de producto, precio y nombre de fabricante, de todos los productos
-- que tengan un precio mayor o igual a 180€. Ordene el resultado en primer lugar por el precio (en orden
-- descendente) y en segundo lugar por el nombre (en orden ascendente)

SELECT pr.nombre,
	   pr.precio,
	   fa.nombre
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo
 WHERE pr.precio >= 180
 ORDER BY pr.precio DESC, pr.nombre ASC

-- 13. Devuelve un listado con el identificador y el nombre de fabricante, solamente de aquellos fabricantes 
-- que tienen productos asociados en la BD

SELECT DISTINCT pr.codigo_fabricante,
	   fa.nombre
  FROM PRODUCTO pr 
  JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo


								-----------------------------------
								-- Uso de LEFT JOIN / RIGHT JOIN --
								-----------------------------------

-- 14. Devuelve un listado de todos los fabricantes que existen en la base de datos, junto con los productos que
-- tiene cada uno de ellos. El listado deberá mostrar también aquellos fabricantes que no tienen productos asociados.

SELECT *
  FROM PRODUCTO pr 
  RIGHT JOIN FABRICANTE fa
    ON pr.codigo_fabricante = fa.codigo

SELECT *
  FROM FABRICANTE fa
  LEFT JOIN PRODUCTO pr
    ON fa.codigo = pr.codigo_fabricante

-- 15. Devuelve un listado donde sólo aparezcan aquellos fabricantes que no tienen ningún producto asociado.

SELECT *
  FROM FABRICANTE fa
  LEFT JOIN PRODUCTO pr 
    ON fa.codigo = pr.codigo_fabricante
 WHERE pr.codigo_fabricante IS NULL;

-- 16. ¿Pueden existir productos que no estén relacionados con un fabricante? Justifica tu respuesta.

	-- No es posible pues no estarían creados estos
	SELECT *
      FROM PRODUCTO
	 WHERE codigo_fabricante IS NULL;