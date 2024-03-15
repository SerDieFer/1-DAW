USE JARDINERIA
						---------------------------
						-- EJERCICIOS UD7 - TSQL -- 
						---------------------------
-------------------------------------------------------------------------------------------
-- NOTA: Recuerda cuidar la limpieza del código (tabulaciones, nombres de tablas en mayúscula,
--		nombres de variables en minúscula, poner comentarios sin excederse, código organizado y fácil de seguir, etc.)
-------------------------------------------------------------------------------------------
-- 1. Crea un script que use un bucle para calcular la potencia de un número.
--		Tendremos dos variables: el número y la potencia
--
--		Ejemplo.
--		Número = 3		Potencia = 4		Resultado = 3*3*3*3 = 81
--
--		Si el número o la potencia son 0 o <0 devolverá el mensaje: “La operación no se puede realizar.
-------------------------------------------------------------------------------------------

DECLARE @num INT = FLOOR(RAND()*10)
DECLARE @potencia INT = FLOOR(RAND()*10)
DECLARE @contador INT = 1
DECLARE @resultado INT = @num
DECLARE @txtResultadoFinal VARCHAR(50) = CONCAT('Resultado = ', @num)

IF (@num <> 0 AND @potencia <> 0)
BEGIN
	WHILE (@contador < @potencia)
		BEGIN
			SET @resultado *= @num
			SET @txtResultadoFinal += CONCAT('*', @num)
			SET @contador += 1
		END
	PRINT CONCAT(@txtResultadoFinal, ' = ', @resultado)
END

-------------------------------------------------------------------------------------------
-- 2. Crea un script que calcule las soluciones de una ecuación de segundo grado ax^2 + bx + c = 0
--
--	Debes crear variables para los valores a, b y c.
--  Al principio debe comprobarse que los tres valores son positivos, en otro caso, 
--		se devolverá el mensaje 'Cálculo no implementado'
--	
--	Consulta esta página para obtener la fórmula a implementar (recuerda que habrá DOS soluciones): 
--		http://recursostic.educacion.es/descartes/web/Descartes1/4a_eso/Ecuacion_de_segundo_grado/Ecua_seg.htm#solgen

--	Salida esperada para los valores: a=3, b=-4, c=1 --> sol1= 1 y sol2= 0.33
--	
--	NOTA: Si no sale lo mismo, te recomiendo revisar bien el orden de prioridad de los operadores... ()
-------------------------------------------------------------------------------------------

DECLARE @a INT = 3
DECLARE @b INT = -4
DECLARE @c INT = 1
DECLARE @sol1 DECIMAL(4,2)
DECLARE @sol2 DECIMAL(4,2)

BEGIN TRY
	IF( @a > 0 AND @c > 0 )
	BEGIN
		SET @sol1 = ( ( @b * -1 ) + ( SQRT(POWER(@b, 2) - ( 4 * @a * @c ) ) ) )  / (2 * @a)
		SET @sol2 = ( ( @b * -1 ) - ( SQRT(POWER(@b, 2) - ( 4 * @a * @c ) ) ) ) / (2 * @a) 
		PRINT CONCAT('sol1 = ', @sol1, CHAR(10), 'sol2 = ', @sol2)
	END
END TRY
BEGIN CATCH
	PRINT 'Los valores tienen que ser mayores que 0'
END CATCH

-------------------------------------------------------------------------------------------
-- 3. Crea un script que calcule la serie de Fibonacci para un número dado.
--
-- La sucesión es: 1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597...
-- Si te fijas, se calcula sumando el número anterior al siguiente:
--	Ejemplo. Si se introduce el numero 3 significa que tendremos que hacer 3 iteraciones:
--			ini = 1
--			0+1 = 1
--			1+1 = 2
--			2+1 = 3
--			3+2 = 5
--			5+3 = 8
--			...
-- 
--	Ayuda: Quizás necesites guardar en algún sitio el valor actual de la serie antes de sumarlo...
-------------------------------------------------------------------------------------------

DECLARE @limite INT = 5
DECLARE @iteracion INT = 0
DECLARE @res INT = 1
DECLARE @aux1 INT = 0
DECLARE @aux2 INT = 0

DECLARE @txt VARCHAR(50) = 'ini = 1'
  PRINT @txt

WHILE (@iteracion < @limite) 
BEGIN
	SET @aux1 = @aux2
	SET @aux2 = @res
	SET @res = @aux1 + @aux2
	SET @iteracion += 1
	PRINT CONCAT(@aux1, ' + ', @aux2, ' = ' , @res)
END

-------------------------------------------------------------------------------------------
-- 4. Utilizando la BD JARDINERIA, crea un script que realice lo siguiente:
--		Obtén el nombre del cliente con código 3 y guárdalo en una variable
--		Obtén el número de pedidos realizados por dicho cliente y guárdalo en una variable
--		Muestra por pantalla el mensaje: 'El cliente XXXX ha realizado YYYY pedidos.'
--		
--		Resultado esperado: El cliente Gardening Associates ha realizado 9 pedidos.
--
--	    Reto opcional: Implementa el script utilizando una única consulta.
-------------------------------------------------------------------------------------------

EXEC sp_columns CLIENTES

DECLARE @nombreCliente VARCHAR(50)
DECLARE @numPedidos INT
DECLARE @numCliente INT = 3

SELECT @nombreCliente = cli.nombre_cliente,
	   @numPedidos = COUNT(pe.codPedido)
  FROM PEDIDOS pe,
	   CLIENTES cli
 WHERE cli.codCliente = pe.codCliente
   AND @numCliente = cli.codCliente
 GROUP BY cli.nombre_cliente

 PRINT CONCAT('Cliente: ', @nombreCliente, CHAR(10), 'Pedidos: ' , @numPedidos)

-------------------------------------------------------------------------------------------
-- 5. Utilizando la BD JARDINERIA, crea un script que realice lo siguiente:
--		Obtén el nombre y los apellidos de todos los empleados de la empresa
--		Deberás mostrar cada uno de ellos línea a línea utilizando PRINT
--		
--		Salida esperada:
--			Magaña Perez, Marcos
--			López Martinez, Ruben
--			Soria Carrasco, Alberto
--			Solís Jerez, Maria
--			...
--
--		Reto opcional: Modifica el script anterior para que muestre sólo los que trabajen en la oficina de Londres
--		Salida esperada:
--			Johnson , Amy
--			Westfalls , Larry
--			Walton , John
-------------------------------------------------------------------------------------------

EXEC sp_columns OFICINAS

DECLARE @nombreCompleto VARCHAR(153)
DECLARE @posicionEmpleado INT = 1

DECLARE @totalEmpleados INT 
DECLARE @ciudadOficina VARCHAR(40) = 'londres'

 SELECT @totalEmpleados = COUNT(codEmpleado)
   FROM EMPLEADOS

WHILE (@posicionEmpleado <= @totalEmpleados)
BEGIN
	   SET @nombreCompleto = NULL
	SELECT @nombreCompleto = CONCAT(em.apellido1, ' ', em.apellido2, ', ', em.nombre),
		   @posicionEmpleado = em.codEmpleado
	  FROM EMPLEADOS em,
	       OFICINAS ofi
	 WHERE em.codEmpleado = @posicionEmpleado
	   AND em.codOficina = ofi.codOficina
	   AND LOWER(ofi.ciudad) = @ciudadOficina 

		IF (@nombreCompleto IS NOT NULL)
		BEGIN
			PRINT CONCAT('ID (', @posicionEmpleado, ') Nombre: ',  @nombreCompleto)
		END

	SET @posicionEmpleado += 1
END

-------------------------------------------------------------------------------------------
-- 6. Utilizando la BD JARDINERIA, crea un script que realice lo siguiente:
--		Reutilizando el script del ejercicio 4, agrega la siguiente información a la salida:
--			Número de pedidos realizados por cada cliente
--			NOTA: Realízalo utilizando una consulta específica para obtener el número de pedidos de cada cliente.

--		Salida esperada:
--			El cliente GoldFish Garden ha realizado 11 pedidos.
--			El cliente Gardening Associates ha realizado 9 pedidos.
--			El cliente Gerudo Valley ha realizado 5 pedidos.
--			El cliente Tendo Garden ha realizado 5 pedidos.
--			El cliente Lasas S.A. ha realizado 0 pedidos.
--			...
--
--		Reto opcional:
--		Muestra también el coste total de todos los pedidos para cada cliente.
--
--		Salida esperada:
--			El cliente GoldFish Garden ha realizado 11 pedidos por un coste total de 10365.00.
--			El cliente Gardening Associates ha realizado 9 pedidos por un coste total de 13726.00.
--			El cliente Gerudo Valley ha realizado 5 pedidos por un coste total de 81849.00.
--			El cliente Tendo Garden ha realizado 5 pedidos por un coste total de 23794.00.
--			El cliente Lasas S.A. ha realizado 0 pedidos por un coste total de 0.00.
--			...
-------------------------------------------------------------------------------------------

SELECT *
FROM CLIENTES

DECLARE @nomCliente VARCHAR(50)
DECLARE @numPed INT
DECLARE @costoPedido INT
DECLARE @posCliente INT = 1

DECLARE @totalClientes INT
 SELECT @totalClientes = COUNT(codCliente)
   FROM CLIENTES

WHILE(@posCliente <= @totalClientes)
BEGIN
	SET @nomCliente = NULL

   SELECT @numPed = COUNT(codPedido)
     FROM PEDIDOS
    WHERE codCliente = @posCliente

	SELECT @costoPedido = CAST(SUM(de.cantidad * de.precio_unidad) AS DECIMAL(10,2))
	  FROM DETALLE_PEDIDOS de,
		   PEDIDOS pe
	 WHERE pe.codPedido = de.codPedido
	   AND pe.codCliente = @posCliente

    SELECT @nomCliente = nombre_cliente
      FROM CLIENTES
     WHERE codCliente = @posCliente

	IF (@nomCliente IS NOT NULL)
    BEGIN
        PRINT CONCAT('Cliente ID(', @posCliente, '): ', @nomCliente)
        IF (@numPed > 0)
        BEGIN
            PRINT CONCAT('Pedidos: ', @numPed, CHAR(10),
                         'Costo Pedidos: ', @costoPedido, '€', CHAR(10))
        END
        ELSE
        BEGIN
            PRINT CONCAT('Este cliente no tiene pedidos.', CHAR(10))
        END
    END
 SET @posCliente += 1
END

-------------------------------------------------------------------------------------------
-- 7. Utilizando la BD JARDINERIA, crea un script que realice las siguientes operaciones:
--	Importante: debes utilizar TRY/CATCH y Transacciones si fueran necesarias.

--		Crea una nueva oficina (datos inventados)
--		Crea un nuevo empleado con datos inventados (el codEmpleado a insertar debes obtenerlo automáticamente)
--		Crea un nuevo cliente (datos inventados) (el codCliente a insertar debes obtenerlo automáticamente)
--		Asigna como representante de ventas el cliente anterior
-------------------------------------------------------------------------------------------


DECLARE @ERROR INT
BEGIN TRY

    BEGIN TRANSACTION;

    DECLARE @codOficina INT;
     INSERT INTO OFICINAS (ciudad, pais) VALUES ('Ciudad Inventada', 'País Inventado');
       SET @codOficina = SCOPE_IDENTITY(); 

    DECLARE @codEmpleado INT;
     INSERT INTO EMPLEADOS (nombre, apellido1, apellido2, tlf_extension_ofi, email, codOficina) 
     VALUES ('Nombre Inventado', 'Apellido1', 'Apellido2', '123', 'correo@inventado.com', @codOficina);
        SET @codEmpleado = SCOPE_IDENTITY(); 

    DECLARE @codCliente INT;
     INSERT INTO CLIENTES (nombre_cliente, linea_direccion1, ciudad, pais, telefono) 
     VALUES ('Cliente Inventado', 'Dirección Inventada', 'Ciudad Inventada', 'País Inventado', '123456789');
        SET @codCliente = SCOPE_IDENTITY(); 

     UPDATE CLIENTES SET codEmpl_ventas = @codEmpleado WHERE codCliente = @codCliente;
	
	SET @ERROR = 1/0
    COMMIT TRANSACTION; 

    PRINT 'Operaciones completadas exitosamente.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION; 
    PRINT 'Se produjo un error durante la ejecución del script:';
    PRINT ERROR_MESSAGE(); 
END CATCH;


-------------------------------------------------------------------------------------------
-- 8. Utilizando la BD JARDINERIA, crea un script que realice las siguientes operaciones:
--	Importante: debes utilizar TRY/CATCH y Transacciones si fueran necesarias.
--
--		Debes eliminar la oficina, el empleado y el cliente creados en el apartado anterior.
--		Debes crear variables con los identificadores de clave primaria para eliminar
--			todos los datos de cada una de las tablas en una sola ejecución
-------------------------------------------------------------------------------------------





-------------------------------------------------------------------------------------------
-- 9. Utilizando la BD JARDINERIA, crea un script que realice lo siguiente:
--		Crea un nuevo cliente (invéntate los datos). No debes indicar directamente el código, 
--			sino buscar cuál le tocaría con una SELECT y guardarlo en una variable.

--		Crea un nuevo pedido para dicho cliente (fechaPedido será la fecha actual, fecha esperada 10 días 
--				después de la fecha de pedido, fecha entrega y comentarios a NULL y estado PENDIENTE)
--			Dicho pedido debe constar de dos productos (los códigos de producto se declaran como variables y se utilizan después)
--			El precio de cada producto debes obtenerlo utilizando SELECT antes de insertarlo en DETALLE_PEDIDOS,
--			de tal manera que, si modificamos los códigos de producto, el script seguirá funcionando.
--			La cantidad de los productos comprados puede ser la que tú quieras.

--		Recuerda que debes utilizar TRANSACCIONES (si fueran necesarias) y TRY/CATCH

--		Reto opcional:
--			Crea también un nuevo pago para dicho cliente cuyo importe coincida con lo que cuesta el pedido completo
--				Puedes indicar directamente el idtransaccion como 'ak-std-000026', aunque es mejor que lo obtengas dinámicante
--				utilizando funciones de SQL Server (piensa que los 6 últimos caracteres son números...)
--				Forma de pago debe ser: 'PayPal' y Fechapago la del día
-------------------------------------------------------------------------------------------


