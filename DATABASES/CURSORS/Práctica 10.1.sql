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