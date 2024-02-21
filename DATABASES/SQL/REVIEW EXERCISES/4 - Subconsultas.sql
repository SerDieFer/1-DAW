-------------------------------------------------------------------------
-- Ejercicios Refuerzo 4. Obtén las siguientes consultas con funciones --
-------------------------------------------------------------------------

			-----------------------------------------
			--			  SUBCONSULTAS			   --
			-----------------------------------------

USE TIENDAREPASO

-------------------------------------------
-- Con operadores básicos de comparación --
-------------------------------------------

-- 1. Devuelve todos los productos del fabricante Lenovo. (Sin utilizar INNER JOIN).

SELECT *
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
							  FROM FABRICANTE
						  	 WHERE LOWER(nombre) = 'lenovo') 

-- 2. Devuelve todos los datos de los productos que tienen el mismo precio que el producto más caro del fabricante Lenovo. (Sin utilizar INNER JOIN).

SELECT *
  FROM PRODUCTO
 WHERE precio = (SELECT MAX(precio)
			       FROM PRODUCTO
				  WHERE codigo_fabricante = (SELECT codigo
							                   FROM FABRICANTE
						  	                  WHERE nombre = 'lenovo'))

-- 3. Lista el nombre del producto más caro del fabricante Lenovo.

SELECT nombre
  FROM PRODUCTO
 WHERE codigo_fabricante = (SELECT codigo
				              FROM FABRICANTE
			                 WHERE nombre = 'lenovo')
  AND precio = (SELECT MAX(precio)
			      FROM PRODUCTO
				 WHERE codigo_fabricante = (SELECT codigo
							                  FROM FABRICANTE
						  	                 WHERE nombre = 'lenovo'))

-- 4. Lista el nombre del producto más barato del fabricante Hewlett-Packard.

SELECT nombre
  FROM PRODUCTO
 WHERE precio = ANY (SELECT MIN(precio)
			           FROM PRODUCTO
				      WHERE codigo_fabricante = (SELECT codigo
							                       FROM FABRICANTE
						  	                      WHERE nombre = 'hewlett-packard'))

-- 5. Devuelve todos los productos de la base de datos que tienen un precio mayor o igual al producto más caro del fabricante Lenovo.

SELECT *
  FROM PRODUCTO
 WHERE precio >= (SELECT MAX(precio)
			        FROM PRODUCTO
				   WHERE codigo_fabricante = (SELECT codigo
					 		                    FROM FABRICANTE
						  	                   WHERE nombre = 'lenovo'))

-- 6. Lista todos los productos del fabricante Asus que tienen un precio superior al precio medio de todos sus productos

SELECT *
  FROM PRODUCTO
 WHERE precio >= (SELECT AVG(precio)
			        FROM PRODUCTO
				   WHERE codigo_fabricante = (SELECT codigo
					 		                    FROM FABRICANTE
						  	                   WHERE nombre = 'asus'))
   AND codigo_fabricante = (SELECT codigo
							  FROM FABRICANTE
							 WHERE nombre = 'asus')

-------------------------------------------
--     Subconsultas con ALL y ANY	     --
-------------------------------------------

-- 8. Devuelve el producto más caro que existe en la tabla producto sin hacer uso de MAX, ORDER BY ni TOP.

SELECT *
  FROM PRODUCTO
 WHERE precio >= ALL (SELECT precio
			            FROM PRODUCTO)

-- 9. Devuelve el producto más barato que existe en la tabla producto sin hacer uso de MIN, ORDER BY ni TOP.

SELECT *
  FROM PRODUCTO
 WHERE precio <= ALL (SELECT precio
			            FROM PRODUCTO)

-- 10. Devuelve los nombres de los fabricantes que tienen productos asociados. (Utilizando ALL o ANY).

SELECT nombre
  FROM FABRICANTE
 WHERE codigo = ANY (SELECT codigo_fabricante
			           FROM PRODUCTO)

-- 11. Devuelve los nombres de los fabricantes que no tienen productos asociados. (Utilizando ALL o ANY).

SELECT nombre
  FROM FABRICANTE
 WHERE codigo <> ALL (SELECT codigo_fabricante
			            FROM PRODUCTO)

-------------------------------------------
--     Subconsultas con IN / NOT IN	     --
-------------------------------------------

-- 12. Devuelve los nombres de los fabricantes que tienen productos asociados. (Utilizando IN o NOT IN).

SELECT nombre
  FROM FABRICANTE
 WHERE codigo IN (SELECT codigo_fabricante
			        FROM PRODUCTO)


-- 13. Devuelve los nombres de los fabricantes que no tienen productos asociados. (Utilizando IN o NOT IN)

SELECT nombre
  FROM FABRICANTE
 WHERE codigo NOT IN (SELECT codigo_fabricante
			            FROM PRODUCTO)

-------------------------------------------
--  Subconsultas con EXISTS / NOT EXISTS --
-------------------------------------------

-- 14. Devuelve los nombres de los fabricantes que tienen productos asociados. (Utilizando EXISTS o NOT EXISTS).

SELECT nombre
  FROM FABRICANTE
  WHERE EXISTS (SELECT codigo_fabricante
			      FROM PRODUCTO
			     WHERE codigo_fabricante = FABRICANTE.codigo)

-- 15. Devuelve los nombres de los fabricantes que no tienen productos asociados. (Utilizando EXISTS o NOT EXISTS).

SELECT nombre
  FROM FABRICANTE
  WHERE NOT EXISTS (SELECT codigo_fabricante
			          FROM PRODUCTO
					 WHERE codigo_fabricante = FABRICANTE.codigo)

-- ¡BONUS! Devuelve un listado con todos los nombres de los fabricantes que tienen el mismo número de productos que el fabricante Lenovo.

SELECT nombre
  FROM FABRICANTE
 WHERE codigo IN (SELECT codigo_fabricante
    				FROM PRODUCTO
    			GROUP BY codigo_fabricante
   				  HAVING COUNT(codigo) = (SELECT COUNT(codigo)
        									FROM PRODUCTO
        								   WHERE codigo_fabricante = (SELECT codigo
																		FROM FABRICANTE
																	   WHERE LOWER(nombre) = 'lenovo')))
          
  
