CREATE DATABASE AYUNTAMIENTO
GO
USE AYUNTAMIENTO
GO
CREATE TABLE PERSONAS(
    DNI         CHAR(10),
    nombre      VARCHAR(100) NOT NULL,
    apellido1   VARCHAR(75) NOT NULL,
    apellido2   VARCHAR(75),
    direccion   VARCHAR(200) NOT NULL,
    ciudad      VARCHAR(50) NOT NULL,
    codPostal   CHAR(5) NOT NULL,
    tlfMovil    CHAR(9)

    CONSTRAINT PK_PERSONAS PRIMARY KEY (DNI),
    CONSTRAINT CK_PERSONAS_codPostal CHECK (LEFT(tlfMovil,1) IN (6,7))
)
GO
CREATE INDEX IX_PERSONAS_nombre 
ON PERSONAS(nombre)
GO
CREATE TABLE IMPUESTOS(
    idImpuesto INT IDENTITY(1,1),
    tipoImpuesto CHAR(1) NOT NULL,
    descripcion VARCHAR(50) DEFAULT '_',
    importe DECIMAL(7,2) NOT NULL,
    ciudadOficina VARCHAR(50),
    fechaAlta SMALLDATETIME

    CONSTRAINT PK_IMPUESTOS PRIMARY KEY (idImpuesto),
    CONSTRAINT CK_IMPUESTOS_importe CHECK (importe <= 60000)
)
GO
CREATE INDEX IX_IMPUESTOS_importe
ON IMPUESTOS(importe)
GO
CREATE TABLE PAGOS(
    codPago INT IDENTITY(1,1),
    DNI_contrib CHAR(10) NOT NULL,
    idImpuesto INT NOT NULL,
    fechaPago SMALLDATETIME NOT NULL,
    concepto VARCHAR(70),
    importe DECIMAL(7,2) NOT NULL

    CONSTRAINT PK_PAGOS PRIMARY KEY (codPago),
    CONSTRAINT FK_PAGOS_PERSONAS FOREIGN KEY (DNI_contrib)
    REFERENCES PERSONAS(DNI),
    CONSTRAINT FK_PAGOS_IMPUESTOS FOREIGN KEY (idImpuesto)
    REFERENCES IMPUESTOS(idImpuesto)
)
GO
CREATE INDEX IX_PAGOS_concepto
ON PAGOS(concepto)


DROP TABLE IMPUESTOS
DROP TABLE PAGOS

SELECT *
FROM PERSONAS

GO
INSERT INTO IMPUESTOS(tipoImpuesto, descripcion, importe, ciudadOficina, fechaAlta)
VALUES ('E', NULL, 722.25, 'Alicante', '2022-08-08'),
('S', NULL, 722.25, 'Alicante', null)


UPDATE IMPUESTOS
SET importe = importe * 1.2
FROM IMPUESTOS
WHERE idImpuesto IN (1,6)
AND tipoImpuesto NOT IN('L', 'E')

DELETE FROM IMPUESTOS
WHERE fechaAlta IS NULL

INSERT INTO PERSONAS (DNI, nombre, apellido1, apellido2, 
        	 direccion, ciudad, codPostal, tlfMovil)
VALUES ('133456789M', 'Sergio', 'Diez', 'Fernández', 'Catral 42 3A', 'Alicante' , '03007', '608340957')

UPDATE PERSONAS 
SET ciudad = 'Teruel'
WHERE DNI = (SELECT DNI_contrib
               FROM PAGOS
               GROUP BY DNI_contrib
               HAVING COUNT(codPago) = 2)

DELETE FROM PERSONAS
 WHERE DNI LIKE '_3%M'

 USE JARDINERIA

 SELECT *
 FROM CLIENTES

  SELECT *
 FROM EMPLEADOS


 SELECT c.nombre_cliente,
        CONCAT(e.nombre,' ',e.apellido1, ' ', e.apellido2) AS nombreApellidosEmpleados
FROM CLIENTES c,
     EMPLEADOS e
WHERE c.codEmpl_ventas = e.codEmpleado

SELECT *
FROM DETALLE_PEDIDOS
SELECT *
FROM PRODUCTOS


--

SELECT nombre,
       cantidad_en_stock
 FROM PRODUCTOS
 WHERE codProducto = (SELECT codProducto
                        FROM DETALLE_PEDIDOS
                       WHERE cantidad <= ANY (SELECT *)
                         AND codProducto = (SELECT codProducto
                                             FROM PRODUCTOS
                                            WHERE codCategoria = (SELECT codCategoria
                                                                    FROM CATEGORIA_PRODUCTOS
                                                                   WHERE UPPER(codCategoria) = 'OR')))

SELECT pro.nombre,
       pro.cantidad_en_stock,
       pro.codProducto
FROM PRODUCTOS pro,
     DETALLE_PEDIDOS dt
WHERE pro.codProducto = dt.codProducto


SELECT nombre,
       cantidad_en_stock
 FROM PRODUCTOS
 WHERE codProducto = (SELECT codProducto
                        FROM DETALLE_PEDIDOS
                       WHERE cantidad <= (SELECT MIN(cantidad)
                                                FROM DETALLE_PEDIDOS))


SELECT TOP(1) pro.nombre,
      pro.cantidad_en_stock
 FROM PRODUCTOS pro,
      DETALLE_PEDIDOS dp
WHERE pro.codProducto = dp.codProducto
AND pro.cantidad_en_stock = (SELECT TOP(1)cantidad
                              FROM PRODUCTOS
                              WHERE UPPER(codCategoria) = 'OR'
                              ORDER BY cantidad DESC)
ORDER BY cantidad_en_stock DESC
            

SELECT TOP(1) nom

--








SELECT *
FROM CLIENTES
WHERE codCliente IN (SELECT codCliente
                           FROM PAGOS
                           WHERE importe_pago >= 100)
AND codCliente IN (SELECT codCliente
                    FROM PEDIDOS
                    WHERE MONTH(fecha_pedido) = '08'
                    GROUP BY codCliente
                    HAVING COUNT(codPedido) >= 2)


SELECT ct.nombre,
       COUNT(pro.codProducto) AS numProductos
  FROM CATEGORIA_PRODUCTOS ct
  LEFT JOIN PRODUCTOS pro
    ON ct.codCategoria = pro.codCategoria
 GROUP BY ct.nombre
 ORDER BY numProductos DESC

 
SELECT ct.nombre,
       COUNT(pro.codProducto) AS numProductos
  FROM CATEGORIA_PRODUCTOS ct
  LEFT JOIN PRODUCTOS pro
    ON ct.codCategoria = pro.codCategoria
 GROUP BY ct.nombre
 ORDER BY numProductos DESC


 SELECT *
 FROM PRODUCTOS pro,
      DETALLE_PEDIDOS