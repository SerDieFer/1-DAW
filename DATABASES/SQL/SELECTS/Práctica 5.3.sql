-----------------------------------------------------------------------------
-- Ejercicio 5.3. Escribe las siguientes consultas utilizando la BD TIENDA --			
-----------------------------------------------------------------------------

--------------------------
------- CONSULTAS --------
--------------------------

USE TIENDA
GO

-- 1. Calcula el número total de productos que hay en la tabla productos.

SELECT *
FROM PRODUCTO

SELECT COUNT(codigo) AS productosTotales
FROM PRODUCTO

-- 2. Calcula el número de valores distintos de código de fabricante aparecen 
-- en la tabla productos.

SELECT COUNT(DISTINCT codigo_fabricante) AS codFabricanteDistintos
FROM PRODUCTO

-- 3. Calcula la media del precio de todos los productos.

SELECT CAST(ROUND(AVG(precio),2) AS FLOAT) AS mediaPrecioProductos
FROM PRODUCTO

-- 4. Calcula el precio más barato de todos los productos.

SELECT MIN(precio) AS productoMin
FROM PRODUCTO

    -- Para todos los datos de este

    SELECT TOP(1) *
    FROM PRODUCTO
    ORDER BY precio ASC

-- 5. Calcula el precio más caro de todos los productos.

SELECT MAX(precio) AS productoMax
FROM PRODUCTO

   -- Para todos los datos de este

    SELECT TOP(1) *
    FROM PRODUCTO
    ORDER BY precio DESC

-- 6. Calcula la suma de los precios de todos los productos.

SELECT SUM(precio) AS sumaProductos
FROM PRODUCTO

-- 7. Calcula el precio más barato de todos los productos del fabricante Asus
--  y Crucial.

SELECT *
FROM FABRICANTE

SELECT codigo
FROM FABRICANTE
WHERE nombre = 'Asus'

SELECT MIN(precio) AS precioMin
FROM PRODUCTO
WHERE codigo_fabricante IN (SELECT codigo
                             FROM FABRICANTE
                            WHERE nombre IN ('Asus', 'Crucial'))

-- 8. Calcula la suma de todos los productos del fabricante Asus.

SELECT SUM(precio) AS sumaPrecioAsus
FROM PRODUCTO
WHERE codigo_fabricante = (SELECT codigo
                             FROM FABRICANTE
                            WHERE nombre = 'Asus')

-- 9. Muestra el precio máximo, precio mínimo, precio medio y el número total
--  de productos que tiene el fabricante Crucial.

SELECT MIN(precio) AS precioMinCrucial,
       MAX(precio) AS precioMaxCrucial,
       CAST(ROUND(AVG(precio),2) AS FLOAT) AS precioMedioCrucial,   
       COUNT(codigo) AS productosCrucial
FROM PRODUCTO
WHERE codigo_fabricante = (SELECT codigo
                             FROM FABRICANTE
                            WHERE nombre = 'Crucial')

-- 10. Calcula el número de productos que tienen un precio mayor o igual a 180€.

SELECT COUNT(codigo) AS numProductos180Plus
FROM PRODUCTO
WHERE precio >= 180

-- 11. Calcula el número de productos que tiene cada fabricante con un precio mayor
-- o igual a 180€.

SELECT codigo_fabricante AS fabricante, COUNT(codigo) AS numProductos180Plus
FROM PRODUCTO
WHERE precio >= 180
GROUP BY codigo_fabricante

    -- Con JOINTS y SUBCONSULTAS

    SELECT COUNT(p.codigo) AS numProductos180Plus,
        p.codigo_fabricante,
        f.nombre
    FROM PRODUCTO p,
        FABRICANTE f
    WHERE p.codigo_fabricante = f.codigo 
    AND p.precio >= 180
    GROUP BY p.codigo_fabricante, f.nombre

-- 12. Lista el precio medio los productos de cada fabricante.

SELECT codigo_fabricante, CAST(ROUND(AVG(precio),2) AS FLOAT) AS precioMedioProductosFabricante
FROM PRODUCTO
GROUP BY codigo_fabricante

-- 13. Lista el código de los fabricantes cuyos productos tienen un precio medio mayor 
-- o igual a 150€.

select *
FROM PRODUCTO

SELECT codigo_fabricante AS fabricante, CAST(ROUND(AVG(precio),2) AS FLOAT) AS mediaProductoS150
FROM PRODUCTO
GROUP BY codigo_fabricante
HAVING AVG(precio) >=150

-- 14. Devuelve un listado con los códigos de los fabricantes que tienen 2 o más productos.

SELECT codigo_fabricante AS fabricante, COUNT(codigo) NumProductos
FROM PRODUCTO
GROUP BY codigo_fabricante
HAVING COUNT(codigo) >=2

-- 15. Devuelve un listado con los códigos de los fabricantes y el número de productos que 
-- tiene cada uno con un precio superior o igual a 220 €. No es necesario mostrar el nombre
--  de los fabricantes que no tienen productos que cumplan la condición.

    /*  Ejemplo del resultado esperado.
    	codFabricante | NumProductos
        1				1
        2				2
        6				1			*/

SELECT codigo_fabricante AS fabricante, COUNT(codigo) AS numProductos
FROM PRODUCTO
WHERE precio >= 220
GROUP BY codigo_fabricante

-- 16. Devuelve un listado con los códigos de los fabricantes donde la suma del precio de 
-- todos sus productos es superior a 1000 €.

SELECT codigo_fabricante AS fabricante, SUM(precio) sumaPrecio
FROM PRODUCTO
GROUP BY codigo_fabricante
HAVING SUM(precio) > 1000
