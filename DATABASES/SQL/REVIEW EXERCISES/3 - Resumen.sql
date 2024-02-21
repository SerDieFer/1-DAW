-------------------------------------------------------------------------
-- Ejercicios Refuerzo 3. Obtén las siguientes consultas con funciones --
-------------------------------------------------------------------------

			-----------------------------------------
			--		   CONSULTAS RESUMEN		   --
			-----------------------------------------
			--     GROUP BY / HAVING			   --
			--	   COUNT, MIN, MAX, AVG, SUM	   --
			-----------------------------------------

USE TIENDAREPASO

-- 1. Calcula el número total de productos que hay en la tabla productos.

SELECT COUNT(codigo)
  FROM PRODUCTO

-- 2. Calcula el número total de fabricantes que hay en la tabla fabricante.

SELECT COUNT(codigo)
  FROM FABRICANTE

-- 3. Calcula el número de valores distintos de identificador de fabricante aparecen en la tabla productos.

SELECT COUNT(DISTINCT codigo_fabricante)
  FROM PRODUCTO

-- 4. Calcula la media del precio de todos los productos.

SELECT AVG(precio)
  FROM PRODUCTO

-- 5. Calcula el precio más barato de todos los productos.

SELECT MIN(precio)
  FROM PRODUCTO

-- 6. Calcula el precio más caro de todos los productos.

SELECT MAX(precio)
  FROM PRODUCTO

-- 7. Lista el nombre y el precio del producto más barato.

SELECT nombre,
	   precio
  FROM PRODUCTO
 WHERE precio = (SELECT MIN(precio)
 				   FROM PRODUCTO)

-- 8. Lista el nombre y el precio del producto más caro.

SELECT nombre,
	   precio
  FROM PRODUCTO
 WHERE precio = (SELECT MAX(precio)
 				   FROM PRODUCTO)

-- 9. Calcula la suma de los precios de todos los productos.

SELECT SUM(precio)
  FROM PRODUCTO

-- 10. Calcula el número de productos que tiene el fabricante Asus.

SELECT COUNT(codigo)
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'asus')

-- 11. Calcula la media del precio de todos los productos del fabricante Asus.

SELECT AVG(precio)
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'asus')

-- 12. Calcula el precio más barato de todos los productos del fabricante Asus.

SELECT MIN(precio)
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'asus')

-- 13. Calcula el precio más caro de todos los productos del fabricante Asus.

SELECT MAX(precio)
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'asus')


-- 14. Calcula la suma de todos los productos del fabricante Asus.

SELECT SUM(precio)
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'asus')

-- 15. Muestra el precio máximo, precio mínimo, precio medio y el número total de productos que tiene el fabricante Crucial.

SELECT MAX(precio) AS precioMaximo,
	   MIN(precio) AS precioMinimo,
	   AVG(precio) AS precioMedio,
	   COUNT(codigo) As numProd
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
 							  FROM FABRICANTE
							 WHERE LOWER(nombre) = 'crucial')

-- 16. Muestra el número total de productos que tiene cada uno de los fabricantes. El listado también debe
-- incluir los fabricantes que no tienen ningún producto. El resultado mostrará dos columnas, una con el
-- nombre del fabricante y otra con el número de productos que tiene. Ordene el resultado descendentemente por el número de productos.

	  SELECT fa.nombre,
	  	     COUNT(pro.codigo) AS numProductos
        FROM PRODUCTO pro
	   RIGHT JOIN FABRICANTE fa
		  ON pro.codigo_fabricante = fa.codigo
	   GROUP BY fa.nombre
	   ORDER BY numProductos DESC
    
	SELECT fa.nombre,
		   COUNT(pro.codigo) AS numProductos
	  FROM FABRICANTE fa
	  LEFT JOIN PRODUCTO pro
	    ON pro.codigo_fabricante = fa.codigo
	 GROUP BY fa.nombre
	 ORDER BY numProductos DESC
    
-- 17. Muestra el precio máximo, precio mínimo y precio medio de los productos de cada uno de los fabricantes.
-- El resultado mostrará el nombre del fabricante junto con los datos que se solicitan.

SELECT fa.codigo AS codFabricante,
	   fa.nombre As nombreFabricante,
	   MAX(pro.precio) AS precioMaximo,
	   MIN(pro.precio) AS precioMinimo,
	   AVG(pro.precio) AS precioMedio
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.codigo, fa.nombre

-- 18. Muestra el precio máximo, precio mínimo, precio medio y el número total de productos de los fabricantes
-- que tienen un precio medio superior a 200€. No es necesario mostrar el nombre del fabricante, con el
-- identificador del fabricante es suficiente.

SELECT fa.codigo AS codFabricante,
	   MAX(pro.precio) AS precioMaximo,
	   MIN(pro.precio) AS precioMinimo,
	   AVG(pro.precio) AS precioMedio,
	   COUNT(pro.codigo) AS numProductos
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.codigo, fa.nombre
HAVING AVG(pro.precio) > 200

-- 19. Muestra el nombre de cada fabricante, junto con el precio máximo, precio mínimo, precio medio y el
-- número total de productos de los fabricantes que tienen un precio medio superior a 200€. Es necesario
-- mostrar el nombre del fabricante

SELECT fa.codigo AS codFabricante,
	   fa.nombre As nombreFabricante,
	   MAX(pro.precio) AS precioMaximo,
	   MIN(pro.precio) AS precioMinimo,
	   AVG(pro.precio) AS precioMedio,
	   COUNT(pro.codigo) AS numProductos
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.codigo, fa.nombre
HAVING AVG(pro.precio) > 200

-- 20. Calcula el número de productos que tienen un precio mayor o igual a 180€.

SELECT COUNT(codigo)
  FROM PRODUCTO
 WHERE precio >= 180

-- 21. Calcula el número de productos que tiene cada fabricante con un precio mayor o igual a 180€.

SELECT COUNT(pro.codigo) AS numProductos,
	   fa.nombre
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo 
 WHERE precio >= 180
 GROUP BY fa.nombre

-- 22. Lista el precio medio los productos de cada fabricante, mostrando solamente el identificador del fabricante.

SELECT COUNT(pro.codigo_fabricante) AS codFabricante,
	   AVG(pro.precio) AS precioMedio
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.codigo

-- 23. Lista el precio medio los productos de cada fabricante, mostrando solamente el nombre del fabricante.

SELECT fa.nombre AS nombreFabricante,
	   AVG(pro.precio) AS precioMedio
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.nombre

-- 24. Lista los nombres de los fabricantes cuyos productos tienen un precio medio mayor o igual a 150€.

SELECT fa.nombre AS nombreFabricante,
	   AVG(pro.precio) AS precioMedio
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.nombre
HAVING AVG(pro.precio) >= 150

-- 25. Devuelve un listado con los nombres de los fabricantes que tienen 2 o más productos.

SELECT fa.nombre AS nombreFabricante
  FROM PRODUCTO pro
  JOIN FABRICANTE fa
    ON pro.codigo_fabricante = fa.codigo
 GROUP BY fa.nombre
HAVING COUNT(pro.codigo) >= 2


-- 26. Devuelve un listado con los nombres de los fabricantes y el número de productos que tiene cada uno con
--	un precio superior o igual a 220 €. No es necesario mostrar el nombre de los fabricantes que no tienen
--	productos que cumplan la condición

	-- Resultado esperado:
	-- -------------------
	--	nombre   | total
	-- -------------------
	--  Lenovo   |   2
	--  Asus     |   1
	--  Crucial  |   1
	-- -------------------

	SELECT fa.nombre AS nombreFabricante,
		   COUNT(pro.precio) AS numProd
      FROM PRODUCTO pro
	  JOIN FABRICANTE fa
		ON pro.codigo_fabricante = fa.codigo
	   AND pro.precio >= 220
	 GROUP BY fa.nombre


-- 27. Devuelve un listado con los nombres de los fabricantes y el número de productos que tiene cada uno con
--	un precio superior o igual a 220 €. El listado debe mostrar el nombre de todos los fabricantes, es decir, si
--	hay algún fabricante que no tiene productos con un precio superior o igual a 220€ deberá aparecer en el
--	listado con un valor igual a 0 en el número de productos

	-- Resultado esperado:
	-- ----------------------------
	--	nombre				| total
	-- ----------------------------
	--  Lenovo				|  2
	--  Crucial				|  1
	--  Asus				|  1
	--  Huawei				|  0
	--  Samsung				|  0
	--  Gigabyte			|  0
	--  Hewlett-Packard		|  0
	--  Xiaomi				|  0
	--  Seagate				|  0

	SELECT fa.nombre,
		   COUNT(pro.codigo) AS numProductos
	  FROM FABRICANTE fa
	  LEFT JOIN PRODUCTO pro
		ON pro.codigo_fabricante = fa.codigo
	   AND pro.precio >= 220
	 GROUP BY fa.nombre
	 ORDER BY numProductos DESC

-- 28. Devuelve un listado con los nombres de los fabricantes donde la suma del precio de todos sus productos sea superior a 1000 €

SELECT fa.nombre
  FROM FABRICANTE fa
  LEFT JOIN PRODUCTO pro
    ON pro.codigo_fabricante = fa.codigo
   AND pro.precio >= 220
 GROUP BY fa.nombre
 HAVING SUM(pro.precio) > 1000

-- 29. Devuelve un listado con el nombre del producto más caro que tiene cada fabricante. El resultado debe
-- tener tres columnas: nombre del producto, precio y nombre del fabricante. El resultado tiene que estar
-- ordenado alfabéticamente de menor a mayor por el nombre del fabricante

SELECT pro.nombre,
	   pro.precio,
	   fb.nombre AS nombreFabricante
  FROM PRODUCTO pro,
       FABRICANTE fb
 WHERE pro.codigo_fabricante = fb.codigo
   AND pro.precio IN (SELECT MAX(precio)
                        FROM PRODUCTO
			           GROUP BY codigo_fabricante)
 ORDER BY fb.nombre ASC
