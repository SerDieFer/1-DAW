------------------
--- EXERCISE 1 ---
------------------

----------------------------------------------------------------------

-- CREACIÓN DE LA BASE DE DATOS DE LA LIBRERÍA Y POSTERIOR USO DE ESTA
GO
CREATE DATABASE LIBRARY
GO
USE LIBRARY

-- CREACIÓN DE LAS TABLAS DE LA LIBRERIA
GO
CREATE TABLE BOOKS(
    ISBN        CHAR(13) NOT NULL,
    bookTitle   VARCHAR(50) NOT NULL,
    bookPrice   DECIMAL(7,2) NOT NULL

    CONSTRAINT PK_BOOKS PRIMARY KEY (ISBN)
)
GO
CREATE TABLE MEMBERS(
    ID          CHAR(10) NOT NULL,
    memberName  VARCHAR(50) NOT NULL,
    memberCity  VARCHAR(50) NOT NULL

    CONSTRAINT PK_MEMBERS PRIMARY KEY (ID)
)
GO
CREATE TABLE LOANS (
    loanID      INT NOT NULL,
    loanData    SMALLDATETIME NOT NULL,
    loanReturn  SMALLDATETIME,
    bookISBN    CHAR(13) NOT NULL,
    memberID    CHAR(10) NOT NULL

    CONSTRAINT PK_LOANS PRIMARY KEY (loanID),
    CONSTRAINT FK_BOOKSLOANS FOREIGN KEY (bookISBN) 
    REFERENCES BOOKS(ISBN),
    CONSTRAINT FK_MEMBERSLOANS FOREIGN KEY (memberID) 
    REFERENCES MEMBERS(ID)
)
GO
CREATE TABLE LOST_BOOKS (
    ISBN         CHAR(13) NOT NULL,
    ID           CHAR(10) NOT NULL,
    memberName   VARCHAR(50) NOT NULL,
    lostDate     SMALLDATETIME NOT NULL
)   

-- INSERTO REGISTROS PARA COMPROBAR EN LAS TABLAS
GO
INSERT INTO BOOKS (ISBN, bookTitle, bookPrice) 
VALUES ('9780141182605', '1984', 15.99),
       ('9780061120084', 'To Kill a Mockingbird', 12.50),
       ('9780743273565', 'The Great Gatsby', 10.75)
GO
INSERT INTO MEMBERS (ID, memberName, memberCity) 
VALUES ('12345678A', 'John Smith', 'New York'),
       ('23456789B', 'Maria Garcia', 'Madrid'),
       ('34567890C', 'Emily Johnson', 'London')
GO
INSERT INTO LOANS (loanID, loanData, loanReturn, bookISBN, memberID) 
VALUES (1, '2024-04-25', NULL, '9780141182605', '12345678A'),
       (2, '2024-04-26', '2024-04-29', '9780061120084', '23456789B'),
       (3, '2024-04-27', NULL, '9780743273565', '34567890C')

-- CREACION DE BACKUP DE MIEMBROS HISTORICOS
GO
SELECT *
  INTO MEMBERS_HISTORIC
  FROM MEMBERS
 WHERE 1 = 0
 ALTER TABLE MEMBERS_HISTORIC
   ADD changeDate SMALLDATETIME

-- CREACION DEL TRIGGER CUANDO UN MIEMBRO ES BORRADO
GO
CREATE OR ALTER TRIGGER TX_MEMBER_LEAVE ON MEMBERS INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        DECLARE @hasTransaction BIT = 1

        -- SI NO EXISTEN TRANSACCIONES ABIERTAS SE INICIA UNA TRANSACCION
        IF @@TRANCOUNT = 0 
            SET @hasTransaction = 0
        
        IF @hasTransaction = 0
        BEGIN TRAN
    
            -- COPIA DEL HISTORICO DE MIEMBROS DE LA LIBRERIA
            INSERT INTO MEMBERS_HISTORIC
            SELECT *, 
                   GETDATE()
              FROM DELETED

            -- ACTUALIZACIÓN DE LOS DATOS BORRADOS A LA TABLA DE LIBROS PERDIDOS
            INSERT INTO LOST_BOOKS
            SELECT LOANS.bookISBN, 
                   DELETED.ID, 
                   MEMBERS.memberName, 
                   GETDATE()
              FROM LOANS, 
                   MEMBERS,
                   DELETED
             WHERE LOANS.memberID = DELETED.ID
               AND LOANS.loanReturn IS NULL

            -- BORRADO EN CASCADA DE LOS DATOS DEL MIEMBRO A BORRAR
            DELETE FROM LOANS
             WHERE memberID IN (SELECT ID
                            FROM DELETED)

            DELETE FROM MEMBERS
             WHERE ID IN (SELECT ID
                            FROM DELETED)

        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        COMMIT
    END TRY
    BEGIN CATCH
        PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
                      'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
                      'LINE: ', ERROR_LINE(), CHAR(10),
                      'PROCEDURE: ', ERROR_PROCEDURE())
        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        ROLLBACK
    END CATCH
END

/* PRUEBA DEL TRIGGER

BEGIN TRAN
    BEGIN TRY
        DELETE FROM MEMBERS
        WHERE ID = '12345678A'
           OR ID = '23456789B'
        COMMIT
    END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

SELECT *
FROM MEMBERS

SELECT *
FROM MEMBERS_HISTORIC

SELECT *
FROM BOOKS

SELECT *
FROM LOST_BOOKS

*/

------------------
--- EXERCISE 2 ---
------------------

----------------------------------------------------------------------------

-- CREACIÓN DE LA BASE DE DATOS DEL SERVICIO TÉCNICO Y POSTERIOR USO DE ESTA
GO
CREATE DATABASE TECHNICAL_SERVICE
GO
USE TECHNICAL_SERVICE

-- CREACIÓN DE LAS TABLAS DEL SERVICIO TÉCNICO
GO
CREATE TABLE TECHNICIANS(
    ID               CHAR(10) NOT NULL,
    technicianName   VARCHAR(50) NOT NULL,
    technicianCity   VARCHAR(50) NOT NULL,
    technicianSalary DECIMAL(7,2) NOT NULL

    CONSTRAINT PK_TECHNICIANS PRIMARY KEY (ID)
)
GO
CREATE TABLE REPAIRMENTS(
    repairmentID         INT NOT NULL,
    repairmentOrderDate  SMALLDATETIME NOT NULL,
    repairConcept        VARCHAR(50) NOT NULL,
    repairCost           DECIMAL(8,2) NOT NULL,
    technicianID         CHAR(10) NOT NULL

    CONSTRAINT PK_REPAIRMENTS PRIMARY KEY (repairmentID),
    CONSTRAINT FK_TECHNICIANS_REPAIRMENTS FOREIGN KEY (technicianID) 
    REFERENCES TECHNICIANS(ID),
)

-- INSERTO REGISTROS PARA COMPROBAR EN LAS TABLAS
GO
INSERT INTO TECHNICIANS (ID, technicianName, technicianCity, technicianSalary) 
VALUES ('12345678Z', 'Juan Pérez', 'Madrid', 2500.00),
       ('23456789Q', 'María López', 'Barcelona', 2700.00),
       ('34567890P', 'David García', 'Valencia', 2600.00)

INSERT INTO REPAIRMENTS (repairmentID, repairmentOrderDate, repairConcept, repairCost, technicianID) 
VALUES (4, '2024-05-01', 'Reparación de impresora', 1500.00, '12345678Z'),
       (5, '2024-05-02', 'Reparación de ordenador', 2550.00, '23456789Q'),
       (6, '2024-05-03', 'Reparación de móvil', 10000.00, '34567890P')

-- CREACION DE BACKUP DE TECNICOS Y REPARACIONES
GO
SELECT *
  INTO TECHNICIANS_BACKUP
  FROM TECHNICIANS
 WHERE 1 = 0
 ALTER TABLE TECHNICIANS_BACKUP
   ADD jobLeaveDate SMALLDATETIME
GO
SELECT *
  INTO REPAIRMENTS_BACKUP
  FROM REPAIRMENTS
 WHERE 1 = 0

-- CREACION DEL TRIGGER CUANDO UN TÉCNICO CON MÁS DE 2500 EUROS EN REPARACIONES HECHAS ES BORRADO
GO
CREATE OR ALTER TRIGGER TX_2500PLUS_TECHNICIAN_LEAVE ON TECHNICIANS INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        DECLARE @hasTransaction BIT = 1

        -- SI NO EXISTEN TRANSACCIONES ABIERTAS SE INICIA UNA TRANSACCION
        IF @@TRANCOUNT = 0 
            SET @hasTransaction = 0
        
        IF @hasTransaction = 0
        BEGIN TRAN

            -- ACTUALIZACIÓN DE LOS DATOS BORRADOS A LA TABLA DE RESERVA DE TECNICOS (BACKUP)
            INSERT INTO TECHNICIANS_BACKUP
            SELECT DELETED.*,
                   GETDATE()
              FROM DELETED
             WHERE ID IN (SELECT technicianID
                            FROM REPAIRMENTS
                           GROUP BY technicianID
                          HAVING SUM(repairCost) > 2500)

            -- COPIA DEL BACKUP DE REPARACIONES
            INSERT INTO REPAIRMENTS_BACKUP
            SELECT *
              FROM REPAIRMENTS
             WHERE technicianID IN (SELECT ID
                                      FROM DELETED)

            -- BORRADO EN CASCADA DE LOS DATOS DEL TECNICO A BORRAR
            DELETE FROM REPAIRMENTS
             WHERE technicianID IN (SELECT ID
                                      FROM DELETED)

            DELETE FROM TECHNICIANS
             WHERE ID IN (SELECT ID
                            FROM DELETED)

        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        COMMIT
    END TRY
    BEGIN CATCH
        PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
                      'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
                      'LINE: ', ERROR_LINE(), CHAR(10),
                      'PROCEDURE: ', ERROR_PROCEDURE())
        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        ROLLBACK
    END CATCH
END

/* PRUEBA DEL TRIGGER

BEGIN TRAN
    BEGIN TRY
        DELETE FROM TECHNICIANS
        WHERE ID = '12345678Z'
           OR ID = '23456789Q'
        COMMIT
    END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

SELECT *
FROM REPAIRMENTS_BACKUP

SELECT *
FROM REPAIRMENTS

SELECT *
FROM TECHNICIANS_BACKUP

SELECT *
FROM TECHNICIANS

*/

------------------
--- EXERCISE 3 ---
------------------

----------------------------------------------------------------------

-- CREACIÓN DE LA BASE DE DATOS DEL ALMACEN Y POSTERIOR USO DE ESTE
GO
CREATE DATABASE WAREHOUSE_MANAGEMENT
GO
USE WAREHOUSE_MANAGEMENT

-- CREACIÓN DE LAS TABLAS DE LA GESTION DE ALMACÉN
GO
CREATE TABLE WAREHOUSES(
    warehouseID             INT NOT NULL,
    warehouseDescription    VARCHAR(100) NOT NULL,
    warehouseAdress         VARCHAR(75) NOT NULL,
    warehouseCity           VARCHAR(50) NOT NULL

    CONSTRAINT PK_WAREHOUSE PRIMARY KEY (warehouseID)
)
GO
CREATE TABLE SUPPLIERS(
    supplierID      INT NOT NULL,
    supplierName    VARCHAR(75) NOT NULL,
    supplierAdress  VARCHAR(75) NOT NULL,
    supplierCity    VARCHAR(50) NOT NULL,
    supplierDebt    DECIMAL(8,2) NOT NULL,
    supplierType    VARCHAR(20) NOT NULL

    CONSTRAINT PK_SUPPLIERS PRIMARY KEY (supplierID)
)
GO
CREATE TABLE GOODS(
    goodID       INT NOT NULL,
    goodName     VARCHAR(50) NOT NULL,
    goodStock    INT NOT NULL,
    goodPVP      DECIMAL(8,2) NOT NULL,
    goodPrice    DECIMAL(8,2) NOT NULL,
    warehouseID  INT NOT NULL,
    supplierID   INT NULL

    CONSTRAINT PK_GOODS PRIMARY KEY (goodID),
    CONSTRAINT FK_WAREHOUSES_GOODS FOREIGN KEY (warehouseID) 
    REFERENCES WAREHOUSES(warehouseID),
    CONSTRAINT FK_SUPPLIERS_GOODS FOREIGN KEY (supplierID) 
    REFERENCES SUPPLIERS(supplierID),
)

-- INSERTO REGISTROS PARA COMPROBAR EN LAS TABLAS
GO
INSERT INTO WAREHOUSES (warehouseID, warehouseDescription, warehouseAdress, warehouseCity)
VALUES (1, 'Central Warehouse', '456 Oak St', 'City I'),
       (2, 'West Warehouse', '789 Pine St', 'City J'),
       (3, 'East Warehouse', '123 Cedar St', 'City K'),
       (4, 'North Warehouse', '555 Elm St', 'City L')
GO
INSERT INTO SUPPLIERS (supplierID, supplierName, supplierAdress, supplierCity, supplierDebt, supplierType)
VALUES (1, 'Supplier 1', '777 Maple St', 'City M', 1200.00, 'Type B'),
       (2, 'Supplier 2', '888 Pine St', 'City N', 900.00, 'Type C'),
       (3, 'Supplier 3', '999 Cedar St', 'City O', 1500.00, 'Type A'),
       (4, 'Supplier 4', '111 Oak St', 'City P', 600.00, 'Type B')
GO
INSERT INTO GOODS (goodID, goodName, goodStock, goodPVP, goodPrice, warehouseID, supplierID)
VALUES (1, 'Good 1', 80, 25.00, 20.00, 1, 1),
       (2, 'Good 2', 0, 35.00, 30.00, 2, 2),
       (3, 'Good 3', 90, 45.00, 40.00, 3, 2),
       (4, 'Good 4', 0, 55.00, 50.00, 4, 4)

-- CREACION DE BACKUP DE ARTICULOS Y PROVEEDORES
GO
SELECT *
  INTO GOODS_NOTEXISTANCE
  FROM GOODS
 WHERE 1 = 0
 ALTER TABLE GOODS_NOTEXISTANCE
   ADD goodNoStock SMALLDATETIME,
       supplierName VARCHAR(75)
GO
SELECT *
  INTO SUPPLIERS_BACKUP
  FROM SUPPLIERS
 WHERE 1 = 0
 ALTER TABLE SUPPLIERS_BACKUP
   ADD supplierLeaveDate SMALLDATETIME

-- CREACION DEL TRIGGER CUANDO SE DA DE BAJA UN PROVEEDOR
GO
CREATE OR ALTER TRIGGER TX_SUPPLIER_LEAVE ON SUPPLIERS INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        DECLARE @hasTransaction BIT = 1

        -- SI NO EXISTEN TRANSACCIONES ABIERTAS SE INICIA UNA TRANSACCION
        IF @@TRANCOUNT = 0 
            SET @hasTransaction = 0
        
        IF @hasTransaction = 0
        BEGIN TRAN

            -- ACTUALIZACIÓN DE LOS DATOS BORRADOS A LA TABLA DE ARTICULOS NO EXISTENTES
            INSERT INTO GOODS_NOTEXISTANCE
            SELECT GOODS.*,
                   GETDATE(),
                   DELETED.supplierName
              FROM GOODS,
                   DELETED
             WHERE DELETED.supplierID = GOODS.supplierID
               AND GOODS.goodStock = 0

            -- COPIA DEL BACKUP DE PROVEEDORES
            INSERT INTO SUPPLIERS_BACKUP
            SELECT *,
                   GETDATE()
              FROM SUPPLIERS
             WHERE supplierID IN (SELECT supplierID
                                    FROM DELETED)
 
            -- BORRADO EN CASCADA DE LOS DATOS DEL PRODUCTO Y EL PROVEEDOR A BORRAR
            DELETE FROM GOODS
             WHERE supplierID IN (SELECT supplierID
                                    FROM DELETED)
               AND goodStock = 0

            UPDATE GOODS
               SET supplierID = NULL
             WHERE supplierID IN (SELECT supplierID
                                    FROM DELETED)
               AND goodStock > 0

            DELETE FROM SUPPLIERS
             WHERE supplierID IN (SELECT supplierID
                                    FROM DELETED)

        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        COMMIT
    END TRY
    BEGIN CATCH
        PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
                      'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
                      'LINE: ', ERROR_LINE(), CHAR(10),
                      'PROCEDURE: ', ERROR_PROCEDURE())
        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        ROLLBACK
    END CATCH
END

/* PRUEBA DEL TRIGGER

BEGIN TRAN
    BEGIN TRY
        DELETE FROM SUPPLIERS
        WHERE supplierID = '1'
           OR supplierID = '2'
        COMMIT
    END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

SELECT *
FROM SUPPLIERS

SELECT *
FROM SUPPLIERS_BACKUP

SELECT *
FROM GOODS

SELECT *
FROM GOODS_NOTEXISTANCE

*/

------------------
--- EXERCISE 4 ---
------------------

----------------------------------------------------------------------------------------------------

GO
USE JARDINERIA

-- CREACION DE BACKUP DE CLIENTES
GO
SELECT *
  INTO CLIENTES_BACKUP
  FROM CLIENTES
 WHERE 1 = 0
 ALTER TABLE CLIENTES_BACKUP
   ADD clienteUpdateDate SMALLDATETIME,
       CONSTRAINT PK_CLIENTES_BACKUP PRIMARY KEY(clienteUpdateDate)

-- CREACION DEL TRIGGER CUANDO SE DA ACTUALIZA UN PROVEEDOR
GO
CREATE OR ALTER TRIGGER TX_CLIENT_UPDATE ON CLIENTES AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        DECLARE @hasTransaction BIT = 1

        -- SI NO EXISTEN TRANSACCIONES ABIERTAS SE INICIA UNA TRANSACCION
        IF @@TRANCOUNT = 0 
            SET @hasTransaction = 0
        
        IF @hasTransaction = 0
        BEGIN TRAN

            -- ACTUALIZACIÓN DE LOS DATOS BORRADOS A LA TABLA DE RESERVA DE TECNICOS (BACKUP)
            INSERT INTO CLIENTES_BACKUP
            SELECT INSERTED.*,
                   GETDATE()
              FROM INSERTED
              
        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        COMMIT
    END TRY
    BEGIN CATCH
        PRINT CONCAT ('CODERROR: ', ERROR_NUMBER(), CHAR(10),
                      'DESCRIPTION: ', ERROR_MESSAGE(), CHAR(10),
                      'LINE: ', ERROR_LINE(), CHAR(10),
                      'PROCEDURE: ', ERROR_PROCEDURE())
        -- SI SOLO EXISTE LA TRANSACCION PREVIA SE HACE COMMIT
        IF @hasTransaction = 0
        ROLLBACK
    END CATCH
END

/* PRUEBA DEL TRIGGER

BEGIN TRAN
    BEGIN TRY
        UPDATE CLIENTES
        SET nombre_cliente = 'Abel Pls'
        WHERE codCliente = 1
        COMMIT
    END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

SELECT *
FROM CLIENTES

SELECT *
FROM CLIENTES_BACKUP

*/