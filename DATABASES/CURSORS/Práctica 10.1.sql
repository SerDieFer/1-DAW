------------------
--- EXERCISE 1 ---
------------------

----------------------------------------------------------------------

GO
USE TIENDA

EXEC SP_HELP PRODUCTO

/* DECLARE @shopRegistriesCounter INT, 
        @maxRegistryCount INT, 
        @productName VARCHAR(100) */

SELECT @shopRegistriesCounter = MIN(codigo)
  FROM PRODUCTO

SELECT @maxRegistryCount = MAX(codigo)
  FROM PRODUCTO

WHILE (@shopRegistriesCounter <= @maxRegistryCount)
BEGIN

    SELECT @productName = nombre
      FROM PRODUCTO
     WHERE codigo = @shopRegistriesCounter

     IF @productName IS NOT NULL
        PRINT CONCAT('ID: ', @shopRegistriesCounter, CHAR(10), 
                     'Product Name: ', @productName, CHAR(10))

    SET @productName = NULL
    SET @shopRegistriesCounter += 1
END

----------------------------------------------------------------------

------------------
--- EXERCISE 2 ---
------------------

----------------------------------------------------------------------

GO
USE TIENDA

EXEC SP_HELP PRODUCTO

DECLARE @shopRegistriesCounter INT, 
        @maxRegistryCount INT, 
        @productName VARCHAR(100),
        @productCost DECIMAL(9,2)

SELECT @shopRegistriesCounter = MIN(codigo)
  FROM PRODUCTO

SELECT @maxRegistryCount = MAX(codigo)
  FROM PRODUCTO

WHILE (@shopRegistriesCounter <= @maxRegistryCount)
BEGIN

    SELECT @productName = nombre
      FROM PRODUCTO
     WHERE codigo = @shopRegistriesCounter

    SELECT @productCost = precio
      FROM PRODUCTO
     WHERE codigo = @shopRegistriesCounter

     IF @productName IS NOT NULL
        PRINT CONCAT('Product Name: ', @productName, CHAR(10), 
                     'Product Cost: ', @productCost, ' €', CHAR(10))

    SET @productName = NULL
    SET @shopRegistriesCounter += 1
END

----------------------------------------------------------------------

------------------
--- EXERCISE 3 ---
------------------

----------------------------------------------------------------------

GO
USE TIENDA

EXEC SP_HELP FABRICANTE
EXEC SP_HELP PRODUCTO

-- DECLARAR CURSOR PRIMERO
DECLARE Cur_Manufacturer CURSOR FOR
 SELECT nombre
   FROM FABRICANTE

-- DECLARAR VARIABLE QUE OPERA PRIMER CURSOR
DECLARE @manufacturesName VARCHAR(100)

   -- ABRE EL CURSOR
   OPEN Cur_Manufacturer

   -- METE EL REGISTRO DEL CURSOR EN LA VARIABLE
   FETCH NEXT FROM Cur_Manufacturer INTO @manufacturesName

  -- MIENTRAS LA LECTURA SEA CORRECTA
  WHILE @@FETCH_STATUS = 0
  BEGIN
      -- DECLARAR SEGUNDO CURSOR DENTRO DEL PRIMER CURSOR
      DECLARE Cur_ManufacturerTotalProductsCost CURSOR FOR
       SELECT precio
         FROM PRODUCTO
        WHERE codigo_fabricante = (SELECT codigo
                                     FROM FABRICANTE
                                    WHERE nombre = @manufacturesName)

      -- DECLARAR VARIABLES QUE OPERAN SEGUNDO CURSOR
      DECLARE @totalCost NUMERIC(12,2), 
              @accumulated NUMERIC(15,2)
          SET @accumulated = 0;

      -- ABRIR EL SEGUNDO CURSOR
      OPEN Cur_ManufacturerTotalProductsCost
      FETCH NEXT FROM Cur_ManufacturerTotalProductsCost INTO @totalCost
            
      -- CREAR OTRO BUCLE QUE GESTIONARÁ LA ACUMULACIÓN DEL COSTE 
      -- TOTAL POR PRODUCTO DE ESE MISMO FABRICANTE
      WHILE @@FETCH_STATUS = 0
      BEGIN
          SET @accumulated = @accumulated + @totalCost
          FETCH NEXT FROM Cur_ManufacturerTotalProductsCost INTO @totalCost
      END

      -- CERRAR SEGUNDO CURSOR Y LIBERAR MEMORIA
      CLOSE Cur_ManufacturerTotalProductsCost
      DEALLOCATE Cur_ManufacturerTotalProductsCost

      -- IMPRIMIR DATOS FABRICANTE
      PRINT CONCAT('Manufacturer Name: ', @manufacturesName, 
                   ' has a total of ', @accumulated, ' € in products')

      -- IR SIGUIENTE REGISTRO DE PRIMER CURSOR
      FETCH NEXT FROM Cur_Manufacturer INTO @manufacturesName     
  END

  -- CERRAR PRIMER CURSOR Y LIBERAR MEMORIA
  CLOSE Cur_Manufacturer
  DEALLOCATE Cur_Manufacturer

----------------------------------------------------------------------

------------------
--- EXERCISE 4 ---
------------------

----------------------------------------------------------------------

GO
USE JARDINERIA

EXEC SP_HELP EMPLEADOS

-- DECLARAR CURSOR PRIMERO
DECLARE Cur_EmployeesData CURSOR FOR
 SELECT codEmpleado, nombre, apellido1, apellido2, email
   FROM EMPLEADOS

  -- DECLARAR VARIABLES QUE OPERAN PRIMER CURSOR
  DECLARE @employeeCode INT
  DECLARE @employeeName VARCHAR(50)
  DECLARE @employeeSurname1 VARCHAR(50)
  DECLARE @employeeSurname2 VARCHAR(50)
  DECLARE @employeeEmail VARCHAR(100)

  -- ABRE EL CURSOR
  OPEN Cur_EmployeesData

  -- METE EL REGISTRO DEL CURSOR EN LA VARIABLE
  FETCH NEXT FROM Cur_EmployeesData INTO @employeeCode, @employeeName, @employeeSurname1,
                                          @employeeSurname2, @employeeEmail

  -- MIENTRAS LA LECTURA SEA CORRECTA
  WHILE @@FETCH_STATUS = 0
  BEGIN

      -- IMPRIMIR DATOS FABRICANTE
      PRINT CONCAT('Employee Nº', @employeeCode, CHAR(10),
                   'Name: ', @employeeName, CHAR(10),
                   'First Surname: ', @employeeSurname1, CHAR(10),
                   'Second Surname: ', @employeeSurname2, CHAR(10),
                   'Email: ', @employeeEmail, CHAR(10))

      -- IR SIGUIENTE REGISTRO DE PRIMER CURSOR
      FETCH NEXT FROM Cur_EmployeesData INTO @employeeCode, @employeeName, @employeeSurname1,
                                             @employeeSurname2, @employeeEmail    
  END

  -- CERRAR PRIMER CURSOR Y LIBERAR MEMORIA
  CLOSE Cur_EmployeesData
  DEALLOCATE Cur_EmployeesData

  ----------------------------------------------------------------------

------------------
--- EXERCISE 5 ---
------------------

----------------------------------------------------------------------
