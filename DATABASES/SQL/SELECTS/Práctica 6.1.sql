---------------------------
-- Actividad. Jardinería --
---------------------------
USE JARDINERIA

-- 1. Inserta una nueva oficina en Alicante.

INSERT OFICINAS(codOficina, ciudad, pais,
                codPostal, telefono, linea_direccion1,
                linea_direccion2)
VALUES ('ALC-ES', 'Alicante', 'España', 
        '03008', '+34 965936520', 'Beato Francisco Castelló Aleu',
        NULL);

-- 2. Inserta un nuevo empleado para la oficina de Alicante que sea representante de ventas.

INSERT EMPLEADOS(codEmpleado, nombre, apellido1,
                 apellido2, tlf_extension_ofi,
                 email, puesto_cargo, salario,
                 codOficina, codEmplJefe)
VALUES (32,'Santiago', 'Lorenzano',
        NULL, '69', 'aminadiemetose@programador.jefe',
        'Representante Ventas Latinoamerica ', 1.25, 'ALC-ES', NULL);

DELETE FROM EMPLEADOS
 WHERE codEmpleado = 32;

--3. Inserta un cliente que tenga como representante de ventas el empleado que creamos en el paso anterior.

INSERT CLIENTES(codCliente, nombre_cliente, nombre_contacto,
                apellido_contacto, telefono, email,
                linea_direccion1, linea_direccion2, ciudad,
                pais, codPostal, codEmpl_ventas, limite_credito)
VALUES (39, 'AbelTM', 'Abel',
        'True', '+34 123456789', 'sileesestoeresfalse@abel.XD',
        'Abismo de los Lamentos', 'Grieta del Invocador', 'Aspe',
        'España', '03680', 32,
        9999999.99);

DELETE FROM CLIENTES
 WHERE codCliente = 39;

-- 4. Inserta un pedido que contenga al menos tres productos para el cliente que acabamos de crear.

INSERT PEDIDOS(codPedido, fecha_pedido, fecha_esperada,
               fecha_entrega, codEstado, comentarios, 
               codCliente)
VALUES (129, GETDATE(), GETDATE(), 
        GETDATE(), 'E', 'Pues si que reparte rápido Santiago',
        39)

INSERT INTO DETALLE_PEDIDOS(codPedido, codProducto, cantidad, 
                            precio_unidad, numeroLinea)
VALUES (129, 271, 2, 462.00, 1),
       (129, 237, 4, 266.00, 2),
       (129, 236, 4, 217.00, 3);

DELETE FROM PEDIDOS
 WHERE codPedido = 129;
 
DELETE FROM DETALLE_PEDIDOS
 WHERE codPedido = 129;

--5. Actualiza y/o borra el código del cliente que creamos en el paso anterior. ¿Ha sido posible
--actualizarlo o borrarlo? ¿Por qué? Averigua si hubo cambios en las tablas relacionadas.

    -- No sería posible borrarlo ya que otras tablas dependen de su PK, como FK.
    DELETE FROM CLIENTES
     WHERE codCliente = 39;

    -- Actualizarlo por ende si es posible aplicando ciertos cambios.
    UPDATE CLIENTES
       SET apellido_contacto = 'False',
           email = 'sileesestoerestrue@abel.XD'
     WHERE codCliente = 39;

--6. Actualiza la cantidad de unidades solicitadas en el pedido que has creado del siguiente modo:
-- para el 1er producto serán 3 unidades, para el producto 2 serán 2 unidades y el tercero 1 unidad.

UPDATE DETALLE_PEDIDOS
   SET cantidad = 1
 WHERE codPedido = 129
   AND codProducto = 271

UPDATE DETALLE_PEDIDOS
   SET cantidad = 2
 WHERE codPedido = 129
   AND codProducto = 237

UPDATE DETALLE_PEDIDOS
   SET cantidad = 3
 WHERE codPedido = 129
   AND codProducto = 236

--7. Modifica la fecha del pedido que hemos creado a la fecha y hora actuales.

    -- Como ya le puse la fecha actual anteriormente le pondré otra distinta.
    UPDATE PEDIDOS
       SET fecha_pedido = '2000-01-01',
           fecha_esperada = '2000-01-02',
           fecha_entrega = NULL,
           codEstado = 'P',
           comentarios = 'Si que llega tarde Santiago, 24 años despues y sigo esperando, ni Aliexpress tarda tanto'
     WHERE codPedido = 129

--8. Incrementa en un 5% el precio de los productos que están incluidos en el pedido que has creado.
-- Recuerda que puede que tengas que redondear y/o utilizar la función CAST (XXX as FLOAT)

UPDATE DETALLE_PEDIDOS
   SET precio_unidad = precio_unidad * 1.05
 WHERE codPedido = 129

      --Comprobar
    SELECT *
      FROM DETALLE_PEDIDOS
    WHERE codPedido = 129

--9. Vuelve a dejar el precio de dichos productos como estaba anteriormente.

UPDATE DETALLE_PEDIDOS
   SET precio_unidad = precio_unidad / 1.05
 WHERE codPedido = 129

     --Comprobar
    SELECT *
      FROM DETALLE_PEDIDOS
    WHERE codPedido = 129

--10. ¿Cuál sería la secuencia de borrado de registros de tablas hasta que finalmente se pueda borrar la oficina 
-- de Alicante que creamos en el ejercicio 1? Una vez tengas el script, comprueba que se puede eliminar.

DELETE FROM DETALLE_PEDIDOS
WHERE codPedido = 129

DELETE FROM PEDIDOS
WHERE codPedido = 129

DELETE FROM CLIENTES
WHERE codCliente = 39

DELETE FROM EMPLEADOS
WHERE codEmpleado = 32

DELETE FROM OFICINAS
WHERE codOficina = 'ALC-ES'

--11. Incrementa en un 20% el precio de los productos que NO estén incluidos en ningún pedido.
-- Recuerda que puede que tengas que redondear y/o utilizar la función CAST (XXX as FLOAT)

SELECT *
  FROM DETALLE_PEDIDOS

UPDATE PRODUCTOS
   SET precio_venta = precio_venta * 1.20
 WHERE codProducto NOT IN (SELECT codProducto
                           FROM DETALLE_PEDIDOS)

    --Comprobar
    SELECT  precio_venta AS precioActual,
            CAST((precio_venta / 1.2) AS FLOAT) AS precioAnteriorSinModificar
      FROM PRODUCTOS 
      WHERE codProducto NOT IN (SELECT codProducto
                                  FROM DETALLE_PEDIDOS)

--12. Vuelve a dejar el precio de los productos como estaba anteriormente.

UPDATE PRODUCTOS
   SET precio_venta = precio_venta / 1.20
 WHERE codProducto NOT IN (SELECT codProducto
                           FROM DETALLE_PEDIDOS)

    --Comprobar
    SELECT  precio_venta AS precioActual,
            CAST((precio_venta * 1.2) AS FLOAT) AS precioAnteriorSinModificar
      FROM PRODUCTOS 
      WHERE codProducto NOT IN (SELECT codProducto
                                  FROM DETALLE_PEDIDOS)

--13. Elimina los clientes que no hayan realizado ningún pago.

DELETE FROM CLIENTES
 WHERE codCliente NOT IN (SELECT DISTINCT codCliente
                            FROM PAGOS)
    --Comprobar
    SELECT *
     FROM CLIENTES
    WHERE codCliente NOT IN (SELECT DISTINCT codCliente
                               FROM PAGOS)

--14. Elimina los clientes que no hayan realizado un mínimo de 2 pedidos 
-- (NOTA: al ejecutar la sentencia fallará por la integridad referencial, es decir, porque hay tablas que tiene relacionado el idCliente como FK).

DELETE CLIENTES
 WHERE codCliente IN (SELECT codCliente
                        FROM PEDIDOS
                       GROUP BY codCliente
                      HAVING COUNT(codCliente) <= 2)
    --Comprobar
    SELECT *
      FROM CLIENTES
     WHERE codCliente IN (SELECT codCliente
                            FROM PEDIDOS
                           GROUP BY codCliente
                          HAVING COUNT(codCliente) <= 2)

-- 15. Borra los pagos del cliente con menor límite de crédito.

DELETE FROM CLIENTES
WHERE limite_credito <= ANY (SELECT MIN(limite_credito)
                               FROM CLIENTES)
    --Comprobar                  
    SELECT *
    FROM CLIENTES
    WHERE limite_credito <= ANY (SELECT MIN(limite_credito)
                                  FROM CLIENTES)

-- 16. Actualiza la ciudad a Alicante para aquellos clientes que tengan un límite de crédito inferior a TODOS 
-- los precios de los productos de la categoría Ornamentales (puede que no haya ninguno).

    UPDATE CLIENTES
    SET ciudad = 'Alicante'
    WHERE limite_credito < ALL (SELECT precio_venta
                                  FROM PRODUCTOS
                                  WHERE codCategoria = (SELECT codCategoria
                                                          FROM CATEGORIA_PRODUCTOS
                                                         wHERE LOWER(nombre) = 'ornamentales'))
    --Comprobar   
    SELECT ciudad
    FROM CLIENTES
    WHERE limite_credito < ALL (SELECT precio_venta
                                  FROM PRODUCTOS
                                  WHERE codCategoria = (SELECT codCategoria
                                                          FROM CATEGORIA_PRODUCTOS
                                                         wHERE LOWER(nombre) = 'ornamentales'))

--17. Actualiza la ciudad a Madrid para aquellos clientes que tengan un límite de crédito mensual inferior a ALGUNO de los precios de los productos de la categoría Ornamentales.



--18. Establece a 0 el límite de crédito del cliente que menos unidades pedidas del producto OR-179.



--19. Modifica la tabla detalle_pedido para insertar un campo numérico llamado IVA. Establece el
--valor de ese campo a 18 para aquellos registros cuyo pedido tenga fecha a partir de Enero de
--2009. A continuación, actualiza el resto de pedidos estableciendo el IVA al 21.



--20. Modifica la tabla detalle_pedido para incorporar un campo numérico llamado total_linea y
--actualiza todos sus registros para calcular su valor con la fórmula:
--total_linea = precio_unidad*cantidad * (1 + (iva/100));


--21. Crea una tabla llamada HISTORICO_CLIENTES que tenga la misma estructura que CLIENTES y además un campo llamado fechaAlta de tipo DATE.
--Deberás insertar en una única sentencia los clientes cuyo nombre contenga la letra ‘s’ e informar el campo fechaAlta como la fecha/hora del momento en el que se inserta.


--22. Actualiza a NULL los campos region, pais y codigo_postal en la tabla CLIENTES para todos los registros. Utiliza una sentencia de actualización en la que se actualicen estos 3 campos a partir de los datos existentes en la tabla HISTORICO_CLIENTES. Comprueba que los datos se han trasladado correctamente.


