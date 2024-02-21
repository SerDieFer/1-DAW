-------------------------------------------------------------------------
-- Ejercicios Refuerzo 1. Obtén las siguientes consultas con funciones --
-------------------------------------------------------------------------

			-----------------------------------------
			--	   CONSULTAS SOBRE UNA TABLA	   --
			-----------------------------------------

USE TIENDAREPASO

-- 1. Lista el nombre de todos los productos que hay en la tabla producto.

SELECT nombre
  FROM PRODUCTO

-- 2. Lista los nombres y los precios de todos los productos de la tabla producto.

SELECT nombre,
	     precio
  FROM PRODUCTO

-- 3. Lista todas las columnas de la tabla producto.

SELECT *
  FROM PRODUCTO

-- 4. Lista el nombre de los productos, el precio en euros y el precio en dólares estadounidenses (USD).
-- El cambio actual de € a $ está en que 1€ = 1,06$

SELECT nombre AS nombreProducto,
	     CONCAT(CAST(ROUND((precio),2) AS FLOAT),' ','€') AS euros,
	     CONCAT(CAST(ROUND((precio * 1.06),2) AS FLOAT),' ','$') AS dolares
  FROM PRODUCTO

-- 5. Lista el nombre de los productos, el precio en euros y el precio en dólares estadounidenses (USD). 
--		El cambio actual de € a $ está en que 1€ = 1,06$. Utiliza los siguientes alias para las columnas: nombre de producto, euros, dólares.

SELECT nombre AS nombreProducto,
	     CONCAT(CAST(ROUND((precio),2) AS FLOAT),' ','€') AS euros,
	     CONCAT(CAST(ROUND((precio * 1.06),2) AS FLOAT),' ','$') AS dolares
  FROM PRODUCTO

-- 6. Lista los nombres y los precios de todos los productos de la tabla producto, convirtiendo los nombres a mayúscula.

SELECT UPPER(nombre),
	     precio
  FROM PRODUCTO

-- 7. Lista los nombres y los precios de todos los productos de la tabla producto, convirtiendo los nombres a minúscula.

SELECT LOWER(nombre),
	     precio
  FROM PRODUCTO

-- 8. Lista el nombre de todos los fabricantes en una columna, y en otra columna obtén en mayúsculas los dos primeros caracteres del nombre del fabricante

SELECT nombre,
	     UPPER(LEFT(nombre,2))
  FROM FABRICANTE

-- 9. Lista los nombres y los precios de todos los productos de la tabla producto, redondeando el valor del precio.

SELECT nombre,
	     ROUND(precio,2)
  FROM PRODUCTO

-- 10. Lista el identificador de los fabricantes que tienen productos en la tabla producto.

SELECT codigo_fabricante AS codFab
  FROM PRODUCTO

-- 11. Lista el identificador de los fabricantes que tienen productos en la tabla producto, eliminando los identificadores que aparecen repetidos.

SELECT DISTINCT codigo_fabricante AS codFab
  FROM PRODUCTO


SELECT codigo AS codFab
  FROM FABRICANTE
 WHERE codigo IN (SELECT codigo_fabricante
				    FROM PRODUCTO)

-- 12. Lista los nombres de los fabricantes ordenados de forma ascendente.

SELECT nombre
  FROM FABRICANTE
 ORDER BY nombre ASC

-- 13. Lista los nombres de los fabricantes ordenados de forma descendente.

SELECT nombre
  FROM FABRICANTE
 ORDER BY nombre DESC

-- 14. Lista los nombres de los productos ordenados en primer lugar por el nombre de forma ascendente y en segundo lugar por el precio de forma descendente.

SELECT nombre,
	   precio
  FROM PRODUCTO
 ORDER BY nombre ASC, precio DESC

-- 15. Devuelve una lista con las 5 primeras filas de la tabla fabricante.

SELECT TOP(5) *
  FROM FABRICANTE

-- 16. Lista el nombre y el precio del producto más barato. (Utiliza solamente las cláusulas ORDER BY y TOP)

SELECT TOP(1) nombre,
	   precio
  FROM PRODUCTO
 ORDER BY precio ASC

-- 17. Lista el nombre y el precio del producto más caro. (Utiliza solamente las cláusulas ORDER BY y TOP)

SELECT TOP(1) nombre,
	   precio
  FROM PRODUCTO
 ORDER BY precio DESC

-- 18. Lista el nombre de todos los productos del fabricante cuyo identificador de fabricante es igual a 2.

SELECT nombre
  FROM PRODUCTO
 WHERE codigo_fabricante = 2

-- 19. Lista el nombre de los productos que tienen un precio menor o igual a 120€.

SELECT nombre
  FROM PRODUCTO
 WHERE precio <= 120

-- 20. Lista el nombre de los productos que tienen un precio mayor o igual a 400€.

SELECT nombre
  FROM PRODUCTO
 WHERE precio >= 400

-- 21. Lista el nombre de los productos que no tienen un precio mayor o igual a 400€.

SELECT nombre
  FROM PRODUCTO
 WHERE precio < 400

-- 22. Lista todos los productos que tengan un precio entre 80€ y 300€. Sin utilizar el operador BETWEEN.

SELECT *
  FROM PRODUCTO
 WHERE precio >= 80 AND precio <= 300

-- 23. Lista todos los productos que tengan un precio entre 60€ y 200€. Utilizando el operador BETWEEN.

SELECT *
  FROM PRODUCTO
 WHERE precio BETWEEN 60 AND 200

-- 24. Lista todos los productos que tengan un precio mayor que 200€ y que el identificador de fabricante sea igual a 6.

SELECT *
  FROM PRODUCTO
 WHERE precio > 200
   AND codigo_fabricante = 6

-- 25. Lista todos los productos donde el identificador de fabricante sea 1, 3 o 5. Sin utilizar el operador IN.

SELECT *
  FROM PRODUCTO
 WHERE codigo_fabricante = 1
    OR codigo_fabricante = 3
	OR codigo_fabricante = 5

-- 26. Lista todos los productos donde el identificador de fabricante sea 1, 3 o 5. Utilizando el operador IN.

SELECT *
  FROM PRODUCTO
 WHERE codigo_fabricante IN (1,3,5)

-- 27. Lista el nombre y el precio de los productos en céntimos (Habrá que multiplicar por 100 el valor del precio).
--	Crea un alias para la columna que contiene el precio que se llame céntimos.

SELECT nombre AS nombreProducto,
	     CONCAT(CAST(ROUND((precio),2) AS FLOAT),' ','€') AS euros,
	     CONCAT(CAST(ROUND((precio * 100),2) AS FLOAT),' ','¢') AS centimos
  FROM PRODUCTO

-- 28. Lista los nombres de los fabricantes cuyo nombre empiece por la letra S.

SELECT nombre
  FROM FABRICANTE
 WHERE LEFT(UPPER(nombre),1) = 'S'

-- 29. Lista los nombres de los fabricantes cuyo nombre termine por la vocal e.

SELECT nombre
  FROM FABRICANTE
 WHERE RIGHT(UPPER(nombre),1) = 'E'

-- 30. Lista los nombres de los fabricantes cuyo nombre contenga el carácter w.

SELECT nombre
  FROM FABRICANTE
 WHERE UPPER(nombre) LIKE '%W%'

-- 31. Lista los nombres de los fabricantes cuyo nombre sea de 4 caracteres.

SELECT nombre
  FROM FABRICANTE
 WHERE LEN(nombre) = 4

-- 32. Devuelve una lista con el nombre de todos los productos que contienen la cadena Portátil en el nombre

SELECT nombre
  FROM PRODUCTO
 WHERE LOWER(nombre) LIKE '%port%til%'

-- 33. Devuelve una lista con el nombre de todos los productos que contienen la cadena Monitor en el nombre y tienen un precio inferior a 215 €.

SELECT nombre
  FROM PRODUCTO
 WHERE LOWER(nombre) LIKE '%monitor%'
   AND precio < 215