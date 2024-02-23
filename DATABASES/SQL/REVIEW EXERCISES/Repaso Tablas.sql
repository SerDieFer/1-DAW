-----------------
-- EJERCICIO 1 --
-----------------
CREATE DATABASE CONCESIONARIO
GO
USE CONCESIONARIO
GO
CREATE TABLE DUENYO(
    DNI CHAR(10),
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(200) NOT NULL

    CONSTRAINT PK_DUENYO PRIMARY KEY(DNI)
)
GO
CREATE INDEX DUENYO_DNI_nombre
ON DUENYO (DNI,nombre)
GO
CREATE TABLE COCHE(
    numBastidor CHAR(17),
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    DNI_DUENYO CHAR(10) NOT NULL

    CONSTRAINT PK_COCHE PRIMARY KEY(numBastidor),
    CONSTRAINT FK_COCHE_DUENYO FOREIGN KEY(DNI_DUENYO)
    REFERENCES DUENYO(DNI)
)
GO
CREATE INDEX COCHE_numBastidor_marca_modelo_DNI
ON COCHE(numBastidor,marca,modelo,DNI_DUENYO)
GO
-----------------
-- EJERCICIO 2 --
-----------------
CREATE DATABASE DISTRIBUIDOR
GO
USE DISTRIBUIDOR
GO
CREATE TABLE PROVEEDORES(
    codProveedor INT,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(200) NOT NULL

    CONSTRAINT PK_PROVEEDORES PRIMARY KEY(codProveedor)
)
GO
CREATE INDEX PROVEEDORES_codProveedor_nombre
ON PROVEEDORES (codProveedor,nombre)
GO
CREATE TABLE ARTICULOS(
    codArticulo INT,
    descripcion VARCHAR(1000),
    precio DECIMAL(6,2) NOT NULL,
    stock SMALLINT 

    CONSTRAINT PK_ARTICULOS PRIMARY KEY(codArticulo)
)
GO
CREATE INDEX ARTICULOS_codArticulos_precio_stock
ON ARTICULOS (codArticulo,precio,stock)
GO
CREATE TABLE SUMINISTROS(
    codProveedor INT,
    codArticulo INT

    CONSTRAINT PK_SUMINISTROS PRIMARY KEY(codProveedor,codArticulo),
    CONSTRAINT FK_SUMINISTROS_PROVEEDORES FOREIGN KEY(codProveedor)
    REFERENCES PROVEEDORES(codProveedor),
    CONSTRAINT FK_SUMINISTROS_ARTICULOS FOREIGN KEY(codArticulo)
    REFERENCES ARTICULOS(codArticulo)
)
GO
CREATE INDEX SUMINISTROS_codProveedor_codArticulo
ON SUMINISTROS (codProveedor,codArticulo)
GO
-----------------
-- EJERCICIO 3 --
-----------------
CREATE DATABASE LIBRERIA
GO
USE LIBRERIA
GO
CREATE TABLE LIBROS(
    ISBN CHAR(13),
    titulo VARCHAR(100) NOT NULL,
    precio DECIMAL(4,2)

    CONSTRAINT PK_LIBROS PRIMARY KEY(ISBN),
    CONSTRAINT CK_LIBROS_precio CHECK(precio <= 59)
)
GO
CREATE INDEX LIBROS_ISBN_titulo_precio
ON LIBROS (ISBN,titulo, precio)
GO
CREATE TABLE SOCIOS(
    DNI CHAR(10),
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(200) NOT NULL,
    ciudad VARCHAR(100) DEFAULT 'Alicante',

    CONSTRAINT PK_SOCIOS PRIMARY KEY(DNI),
)
GO
CREATE INDEX SOCIOS_DNI_nombre_apellidos_ciudad
ON SOCIOS (DNI,nombre,apellidos, ciudad)
GO
CREATE TABLE PRESTAMOS(
    idPrestamo INT IDENTITY(1,1),
    ISBN CHAR(13),
    DNI CHAR(10),
    FechaPrestamo SMALLDATETIME NOT NULL,
    FechaDevolucion SMALLDATETIME

    CONSTRAINT PK_PRESTAMOS PRIMARY KEY(idPrestamo),
    CONSTRAINT FK_PRESTAMOS_LIBROS FOREIGN KEY(ISBN)
    REFERENCES LIBROS(ISBN),
    CONSTRAINT FK_PRESTAMOS_SOCIOS FOREIGN KEY(DNI)
    REFERENCES SOCIOS(DNI),
)
GO
CREATE INDEX PRESTAMOS_id_ISBN_DNI_fechaPrestamo_fechaDevolucion
ON PRESTAMOS (idPrestamo,ISBN,DNI, FechaPrestamo, FechaDevolucion)
GO
-----------------
-- EJERCICIO 4 --
-----------------
GO
USE CONCESIONARIO

-- 1) Inserta un nuevo Dueño con los datos que tú quieras. 

SELECT *
FROM DUENYO

INSERT INTO DUENYO (DNI,nombre,direccion)
VALUES ('123456789A', 'ErDueño', 'VillaSQL')

-- 2) Inserta un nuevo Coche con los datos que tú quieras. Ejemplo. 123456789, ‘Ford’, 

SELECT *
FROM COCHE

INSERT INTO COCHE (numBastidor, marca, modelo, DNI_DUENYO)
VALUES ('123456789', 'Ford', 'Fiesta','123456789A')

-- 3) Modifica el Dueño que has creado y cambia su nombre a ‘Alvaro Perez’. 

UPDATE DUENYO
SET nombre = 'Alvaro Perez'
WHERE DNI ='123456789A'

-- 4) Modifica el Coche que has creado y cambia su marca a ‘Citroen’ y su modelo a ‘C4’. 

UPDATE COCHE
SET marca = 'Citroen',
    modelo = 'C4'
WHERE DNI_DUENYO ='123456789A'

-- 5) Borra el Coche que tenga numbastidor = 123456789

DELETE FROM COCHE
WHERE numbastidor = '123456789'

-- 6) Borra el Dueño que tiene DNI = 123456789Q

DELETE FROM DUENYO
WHERE DNI = '123456789A'

-----------------
-- EJERCICIO 5 --
-----------------
GO
USE DISTRIBUIDOR

-- 1) Inserta un nuevo Proveedor (pon los datos que quieras). 

SELECT *
FROM PROVEEDORES

INSERT INTO PROVEEDORES (codProveedor,nombre,direccion)
VALUES ('123456789', 'ErProveedor', 'VillaSQL'),
       ('987654321', 'ErMercadona', 'RoigCity')

-- 2) Inserta dos Artículos (pon los datos que quieras). 

SELECT *
FROM ARTICULOS

INSERT INTO ARTICULOS (codArticulo,descripcion,precio, stock)
VALUES ('123456789', 'caca', 9999.99, 1),
       ('987654321', 'oro', 0.01, 1000)

-- 3) Inserta un registro en la tabla Suministro, ten en cuenta que deberás poner un codProveedor y un codArticulo que hayas creado en los pasos 1 y 2. 

SELECT *
FROM SUMINISTROS

INSERT INTO SUMINISTROS (codArticulo,codProveedor)
VALUES ('123456789','123456789'),
       ('987654321', '987654321')

-- 4) Modifica el Proveedor que has insertado y además aquel cuyo nombre empiece por la letra ‘E’ 

SELECT *
FROM PROVEEDORES

UPDATE PROVEEDORES
   SET direccion = 'Virgen del Puig'
 WHERE codproveedor = 987654321
    AND LOWER(LEFT(nombre,1)) = 'E'

-- 5) Modifica el Artículo con codArticulo = 1 y además aquellos que tengan un precio < 20. Cuidado con la condición del WHERE. 

UPDATE ARTICULOS
SET descripcion = 'tengo sueño vale ya'
WHERE codArticulo = 987654321
AND precio < 20

-- 6) Elimina el suministro que has creado. 

DELETE FROM SUMINISTROS
WHERE codArticulo ='123456789'
  AND codProveedor = '123456789'

-----------------
-- EJERCICIO 5 --
-----------------
GO
USE LIBRERIA  

-- 1) Inserta un nuevo libro. 

SELECT *
FROM LIBROS

INSERT INTO LIBROS(ISBN, titulo, precio)
VALUES ('9788441425132', 'Mistborn', 9.50)

-- 2) Inserta un nuevo socio. 

SELECT *
FROM SOCIOS

INSERT INTO SOCIOS(DNI, nombre, apellidos)
VALUES('48777861J', 'Sergio', 'Diez Fernández')

-- 3) Inserta un registro en la tabla préstamos en la que relaciones el ISBN del libro que 
-- has creado y el DNI del socio. La fecha de préstamo será la fecha del sistema 
-- GetDate() y la fechaDevol deberá estar a NULL. 

SELECT *
FROM PRESTAMOS

INSERT INTO PRESTAMOS(DNI,ISBN,FechaPrestamo)
VALUES('48777861J', '9788441425132', GETDATE())

-- 4) Actualiza la fecha de devolución del préstamo que has creado a la fecha ‘2021-06-05’ 

UPDATE PRESTAMOS
SET fechaDevolucion = '2021-06-05'
WHERE idPrestamo = 1

-- 5) Modifica el precio de los libros que acaben por la letra ‘N’ a 20 € 

UPDATE LIBROS
SET precio = 20
WHERE LOWER(RIGHT(titulo,1)) = 'n'

-- 6) Modifica la ciudad de los socios que sean de Alicante a Valencia. 

UPDATE SOCIOS
SET ciudad = 'Valencia'
WHERE LOWER(ciudad) = 'alicante'

-- 7)Elimina los préstamos que tengan una fecha de devolución mayor o igual a ‘2021-06-05’

 DELETE FROM PRESTAMOS
  WHERE fechaDevolucion >= '2021-06-05'