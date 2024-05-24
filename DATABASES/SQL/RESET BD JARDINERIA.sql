USE MASTER;
GO
DROP DATABASE IF EXISTS JARDINERIA;
GO
CREATE DATABASE JARDINERIA;
GO
USE JARDINERIA;
GO

CREATE TABLE OFICINAS (
  codOficina		CHAR(6),
  ciudad 			VARCHAR(40) NOT NULL,
  pais 				VARCHAR(50) NOT NULL,
  codPostal 		CHAR(5) NOT NULL,
  telefono 			VARCHAR(15) NOT NULL,
  linea_direccion1 	VARCHAR(100) NOT NULL,
  linea_direccion2 	VARCHAR(100),
  CONSTRAINT PK_OFICINAS PRIMARY KEY (codOficina)
);


CREATE TABLE EMPLEADOS (
  codEmpleado 		INT,
  nombre 			VARCHAR(50) NOT NULL,
  apellido1 		VARCHAR(50) NOT NULL,
  apellido2 		VARCHAR(50),
  tlf_extension_ofi	CHAR(5) NOT NULL,
  email 			VARCHAR(100) NOT NULL,
  puesto_cargo 		VARCHAR(50),
  salario			DECIMAL(9,2) NOT NULL,
  codOficina	 	CHAR(6) NOT NULL,
  codEmplJefe 		INT,
  CONSTRAINT PK_EMPLEADOS PRIMARY KEY (codEmpleado),
  CONSTRAINT FK_EMPLEADOS_OFICINAS FOREIGN KEY (codOficina) REFERENCES OFICINAS (codOficina),
  CONSTRAINT FK_EMPLEADOS_EMPLEADOS FOREIGN KEY (codEmplJefe) REFERENCES EMPLEADOS (codEmpleado)
);

CREATE TABLE CATEGORIA_PRODUCTOS (
  codCategoria 		CHAR(2),
  nombre			VARCHAR(50),
  descripcion_texto	VARCHAR(100),
  descripcion_html	VARCHAR(100),
  imagen			VARCHAR(255)
  CONSTRAINT PK_CATEGORIA_PRODUCTOS PRIMARY KEY (codCategoria)
);

CREATE TABLE CLIENTES (
  codCliente 		INT,
  nombre_cliente 	VARCHAR(50) NOT NULL,
  nombre_contacto 	VARCHAR(50) NOT NULL,
  apellido_contacto VARCHAR(50),
  telefono 			VARCHAR(15) NOT NULL,
  email				VARCHAR(100),
  linea_direccion1 	VARCHAR(100) NOT NULL,
  linea_direccion2 	VARCHAR(100),
  ciudad 			VARCHAR(50) NOT NULL,
  pais 				VARCHAR(50),
  codPostal 		CHAR(5),
  codEmpl_ventas	INT,
  limite_credito	DECIMAL(9,2),
  CONSTRAINT PK_CLIENTES PRIMARY KEY (codCliente),
  CONSTRAINT FK_CLIENTES_EMPLEADOS FOREIGN KEY (codEmpl_ventas) REFERENCES EMPLEADOS (codEmpleado)
);


CREATE TABLE ESTADOS_PEDIDO (
  codEstado		CHAR(1),
  descripcion	VARCHAR(15),
  CONSTRAINT PK_ESTADOS_PEDIDO PRIMARY KEY (codEstado)
);


CREATE TABLE PEDIDOS (
  codPedido 		INT,
  fecha_pedido 		DATE NOT NULL,
  fecha_esperada 	DATE NOT NULL,
  fecha_entrega 	DATE,
  codEstado 		CHAR(1) NOT NULL DEFAULT 'P',
  comentarios 		VARCHAR(500),
  codCliente 		INT NOT NULL,
  CONSTRAINT PK_PEDIDOS PRIMARY KEY (codPedido),
  CONSTRAINT FK_PEDIDOS_ESTADOS_PED FOREIGN KEY (codEstado) REFERENCES ESTADOS_PEDIDO (codEstado),
  CONSTRAINT FK_PEDIDOS_CLIENTES FOREIGN KEY (codCliente) REFERENCES CLIENTES (codCliente)
);

CREATE TABLE PRODUCTOS (
  codProducto 		INT IDENTITY(1,1),
  refInterna		VARCHAR(15) NOT NULL,
  nombre 			VARCHAR(100) NOT NULL,
  codCategoria 		CHAR(2) NOT NULL,
  dimensiones		VARCHAR(25),
  proveedor 		VARCHAR(50),
  descripcion 		VARCHAR(2000) NULL,
  cantidad_en_stock SMALLINT NOT NULL,
  precio_venta 		DECIMAL(9,2) NOT NULL,
  precio_proveedor 	DECIMAL(9,2),
  CONSTRAINT PK_PRODUCTOS PRIMARY KEY (codProducto),
  CONSTRAINT FK_PRODUCTOS_CATEGORIA_PROD FOREIGN KEY (codCategoria) REFERENCES CATEGORIA_PRODUCTOS (codCategoria)
);

CREATE TABLE PRODUCTOS2 (
  codProducto 		VARCHAR(15), 
  nombre 			VARCHAR(100) NOT NULL,
  codCategoria 		CHAR(2) NOT NULL,
  dimensiones		VARCHAR(25),
  proveedor 		VARCHAR(50),
  descripcion 		VARCHAR(2000) NULL,
  cantidad_en_stock SMALLINT NOT NULL,
  precio_venta 		DECIMAL(9,2) NOT NULL,
  precio_proveedor 	DECIMAL(9,2),
  CONSTRAINT PK_PRODUCTOS2 PRIMARY KEY (codProducto),
  CONSTRAINT FK_PRODUCTOS_CATEGORIA_PROD2 FOREIGN KEY (codCategoria) REFERENCES CATEGORIA_PRODUCTOS (codCategoria)
);

CREATE TABLE DETALLE_PEDIDOS (
  codPedido 		INT,
  codProducto 		INT,
  cantidad 			INT NOT NULL,
  precio_unidad 	DECIMAL(9,2) NOT NULL,
  numeroLinea 		SMALLINT NOT NULL,
  CONSTRAINT PK_DETALLE_PEDIDOS PRIMARY KEY (codPedido, codProducto),
  CONSTRAINT FK_DETALLE_PEDIDOS_PEDIDOS FOREIGN KEY (codPedido) REFERENCES PEDIDOS (codPedido),
  CONSTRAINT FK_DETALLE_PEDIDOS_PRODUCTOS FOREIGN KEY (codProducto) REFERENCES PRODUCTOS (codProducto)
);

CREATE TABLE DETALLE_PEDIDOS2 (
  codPedido INT NOT NULL,
  codProducto VARCHAR(15) NOT NULL,
  cantidad INT NOT NULL,
  precio_unidad DECIMAL(9,2) NOT NULL,
  numero_linea SMALLINT NOT NULL,
  CONSTRAINT PK_detallepedido2 PRIMARY KEY (codPedido, codProducto),
  CONSTRAINT FK_detallepedido_pedido2 FOREIGN KEY (codPedido) REFERENCES PEDIDOS (codPedido),
  CONSTRAINT FK_detallepedido_producto2 FOREIGN KEY (codProducto) REFERENCES PRODUCTOS2 (codProducto)
);


CREATE TABLE FORMA_PAGO (
	codFormaPago	CHAR(1),
	descripcion		VARCHAR(30),
	CONSTRAINT PK_FORMA_PAGO PRIMARY KEY (codFormaPago)
);


CREATE TABLE PAGOS (
  codCliente		INT,
  id_transaccion 	CHAR(15) NOT NULL,
  fechaHora_pago 	SMALLDATETIME NOT NULL,
  importe_pago 		DECIMAL(9,2) NOT NULL,
  codFormaPago 		CHAR(1) NOT NULL,
  codPedido 		INT,
  CONSTRAINT PK_PAGOS PRIMARY KEY (codCliente, id_transaccion),
  CONSTRAINT FK_PAGOS_FORMA_PAGO FOREIGN KEY (codFormaPago) REFERENCES FORMA_PAGO (codFormaPago),
  CONSTRAINT FK_PAGOS_CLIENTES FOREIGN KEY (codCliente) REFERENCES CLIENTES (codCliente),
  CONSTRAINT FK_PAGOS_PEDIDOS FOREIGN KEY (codPedido) REFERENCES PEDIDOS (codPedido)
);

----------------------
--	    DATOS		--
----------------------
-- OFICINAS
INSERT INTO OFICINAS VALUES ('BCN-ES','Barcelona','España','08019','+34 93 3561182','Avenida Diagonal, 38','3A escalera Derecha');
INSERT INTO OFICINAS VALUES ('BOS-US','Boston','EEUU','02108','+1 215 837 0825','1550 Court Place','Suite 102');
INSERT INTO OFICINAS VALUES ('LON-UK','Londres','Inglaterra','12345','+44 20 78772041','52 Old Broad Street','Ground Floor');
INSERT INTO OFICINAS VALUES ('MAD-ES','Madrid','España','28032','+34 91 7514487','Bulevar Indalecio Prieto, 32',NULL);
INSERT INTO OFICINAS VALUES ('PAR-FR','Paris','Francia','75017','+33 14 723 4404','29 Rue Jouffroy d''abbans',NULL);
INSERT INTO OFICINAS VALUES ('SFC-US','San Francisco','EEUU','94080','+1 650 219 4782','100 Market Street','Suite 300');
INSERT INTO OFICINAS VALUES ('SYD-AU','Sydney','Australia','92010','+61 2 9264 2451','5-11 Wentworth Avenue','Floor #2');
INSERT INTO OFICINAS VALUES ('VAL-ES','Valencia','España','46712','+34 966 867231','Pça. de la Reina, s/n',NULL);
INSERT INTO OFICINAS VALUES ('TOK-JP','Tokyo','Japón','98578','+81 33 224 5000','4-1 Kioicho',NULL);

-- EMPLEADOS
INSERT INTO EMPLEADOS VALUES (1,'Marcos','Magaña','Perez','3897','marcos@jardineria.es','Director General',7200,'VAL-ES',NULL);
INSERT INTO EMPLEADOS VALUES (2,'Ruben','López','Martinez','2899','rlopez@jardineria.es','Subdirector Marketing',3500,'VAL-ES',1);
INSERT INTO EMPLEADOS VALUES (3,'Alberto','Soria','Carrasco','2837','asoria@jardineria.es','Subdirector Ventas',3500,'VAL-ES',2);
INSERT INTO EMPLEADOS VALUES (4,'Maria','Solís','Jerez','2847','msolis@jardineria.es','Secretaria',1800,'VAL-ES',2);
INSERT INTO EMPLEADOS VALUES (5,'Felipe','Rosas','Marquez','2844','frosas@jardineria.es','Representante Ventas',1500,'VAL-ES',3);
INSERT INTO EMPLEADOS VALUES (6,'Juan Carlos','Ortiz','Serrano','2845','cortiz@jardineria.es','Representante Ventas',1650,'VAL-ES',3);
INSERT INTO EMPLEADOS VALUES (7,'Carlos','Soria','Jimenez','2444','csoria@jardineria.es','Director Oficina',2300,'MAD-ES',3);
INSERT INTO EMPLEADOS VALUES (8,'Mariano','López','Murcia','2442','mlopez@jardineria.es','Representante Ventas', 1503,'MAD-ES',7);
INSERT INTO EMPLEADOS VALUES (9,'Lucio','Campoamor','Martín','2442','lcampoamor@jardineria.es','Representante Ventas', 1718,'MAD-ES',7);
INSERT INTO EMPLEADOS VALUES (10,'Hilario','Rodriguez','Huertas','2444','hrodriguez@jardineria.es','Representante Ventas',1412,'MAD-ES',7);
INSERT INTO EMPLEADOS VALUES (11,'Emmanuel','Magaña','Perez','2518','manu@jardineria.es','Director Oficina',2150,'BCN-ES',3);
INSERT INTO EMPLEADOS VALUES (12,'José Manuel','Martinez','De la Osa','2519','jmmart@hotmail.es','Representante Ventas',1400,'BCN-ES',11);
INSERT INTO EMPLEADOS VALUES (13,'David','Palma','Aceituno','2519','dpalma@jardineria.es','Representante Ventas',1500,'BCN-ES',11);
INSERT INTO EMPLEADOS VALUES (14,'Oscar','Palma','Aceituno','2519','opalma@jardineria.es','Representante Ventas',1600,'BCN-ES',11);
INSERT INTO EMPLEADOS VALUES (15,'Francois','Fignon',NULL,'9981','ffignon@gardening.com','Director Oficina',1980,'PAR-FR',3);
INSERT INTO EMPLEADOS VALUES (16,'Lionel','Narvaez',NULL,'9982','lnarvaez@gardening.com','Representante Ventas',1507,'PAR-FR',15);
INSERT INTO EMPLEADOS VALUES (17,'Laurent','Serra',NULL,'9982','lserra@gardening.com','Representante Ventas',1492,'PAR-FR',15);
INSERT INTO EMPLEADOS VALUES (18,'Michael','Bolton',NULL,'7454','mbolton@gardening.com','Director Oficina',1987,'SFC-US',3);
INSERT INTO EMPLEADOS VALUES (19,'Walter Santiago','Sanchez','Lopez','7454','wssanchez@gardening.com','Representante Ventas',1012,'SFC-US',18);
INSERT INTO EMPLEADOS VALUES (20,'Hilary','Washington',NULL,'7565','hwashington@gardening.com','Director Oficina',1714,'BOS-US',3);
INSERT INTO EMPLEADOS VALUES (21,'Marcus','Paxton',NULL,'7565','mpaxton@gardening.com','Representante Ventas',1390,'BOS-US',20);
INSERT INTO EMPLEADOS VALUES (22,'Lorena','Paxton',NULL,'7665','lpaxton@gardening.com','Representante Ventas',1478,'BOS-US',20);
INSERT INTO EMPLEADOS VALUES (23,'Nei','Nishikori',NULL,'8734','nnishikori@gardening.com','Director Oficina',2690,'TOK-JP',3);
INSERT INTO EMPLEADOS VALUES (24,'Narumi','Riko',NULL,'8734','nriko@gardening.com','Representante Ventas',1911,'TOK-JP',23);
INSERT INTO EMPLEADOS VALUES (25,'Takuma','Nomura',NULL,'8735','tnomura@gardening.com','Representante Ventas',2014,'TOK-JP',23);
INSERT INTO EMPLEADOS VALUES (26,'Amy','Johnson',NULL,'3321','ajohnson@gardening.com','Director Oficina',2100,'LON-UK',3);
INSERT INTO EMPLEADOS VALUES (27,'Larry','Westfalls',NULL,'3322','lwestfalls@gardening.com','Representante Ventas',1700,'LON-UK',26);
INSERT INTO EMPLEADOS VALUES (28,'John','Walton',NULL,'3322','jwalton@gardening.com','Representante Ventas',1699,'LON-UK',26);
INSERT INTO EMPLEADOS VALUES (29,'Kevin','Fallmer',NULL,'3210','kfalmer@gardening.com','Director Oficina',2900,'SYD-AU',3);
INSERT INTO EMPLEADOS VALUES (30,'Julian','Bellinelli',NULL,'3211','jbellinelli@gardening.com','Representante Ventas',2001,'SYD-AU',29);
INSERT INTO EMPLEADOS VALUES (31,'Mariko','Kishi',NULL,'3211','mkishi@gardening.com','Representante Ventas',1990,'SYD-AU',29);

-- CATEGORIA_PRODUCTOS
INSERT INTO CATEGORIA_PRODUCTOS VALUES ('HB','Herbáceas','Plantas para jardin decorativas',NULL,NULL);
INSERT INTO CATEGORIA_PRODUCTOS VALUES ('HR','Herramientas','Herramientas para todo tipo de acción',NULL,NULL);
INSERT INTO CATEGORIA_PRODUCTOS VALUES ('AR','Aromáticas','Plantas aromáticas',NULL,NULL);
INSERT INTO CATEGORIA_PRODUCTOS VALUES ('FR','Frutales','Árboles pequeños de producción frutal',NULL,NULL);
INSERT INTO CATEGORIA_PRODUCTOS VALUES ('OR','Ornamentales','Plantas vistosas para la decoración del jardín',NULL,NULL);

-- CLIENTES
INSERT INTO CLIENTES VALUES (1,'GoldFish Garden','Daniel G','GoldFish','5556901745','g.daniel@goldfish.com','False Street 52 2 A',NULL,'San Francisco','USA','24006',19,3000);
INSERT INTO CLIENTES VALUES (3,'Gardening Associates','Anne','Wright','5557410345','a.wright@gardassociates.com','Wall-e Avenue',NULL,'Miami','USA','24010',19,6000);
INSERT INTO CLIENTES VALUES (4,'Gerudo Valley','Link','Flaute','5552323129','l.flaute@gerudovalley.com','Oaks Avenue nº22',NULL,'New York','USA','85495',22,12000);
INSERT INTO CLIENTES VALUES (5,'Tendo Garden','Akane','Tendo','55591233210','a.tendo@tendogarden.com','Null Street nº69',NULL,'Miami','USA','67890',22,600000);
INSERT INTO CLIENTES VALUES (6,'Lasas S.A.','Antonio','Lasas','34916540145','a.lasas@lasas_sa.com','C/Leganes 15',NULL,'Fuenlabrada','Spain','28945',8,154310);
INSERT INTO CLIENTES VALUES (7,'Beragua','Jose','Bermejo','654987321','j.bermejo@beragua.com','C/pintor segundo','Getafe','Madrid','Spain','28942',11,20000);
INSERT INTO CLIENTES VALUES (8,'Club Golf Puerta del hierro','Paco','Lopez','62456810','p.lopez@golfpuerta.com','C/sinesio delgado','Madrid','Madrid','Spain','28930',11,40000);
INSERT INTO CLIENTES VALUES (9,'Naturagua','Guillermo','Rengifo','689234750','g.rengifo@naturagua.com','C/majadahonda','Boadilla','Madrid','Spain','28947',11,32000);
INSERT INTO CLIENTES VALUES (10,'DaraDistribuciones','David','Serrano','675598001','david.serrano@daradistribuciones.com','C/azores','Fuenlabrada','Madrid','Spain','28946',11,50000);
INSERT INTO CLIENTES VALUES (11,'Madrileña de riegos','Jose','Tacaño','655983045','madrilenya_riegos@gmail.com','C/Lagañas','Fuenlabrada','Madrid','Spain','28943',11,20000);
INSERT INTO CLIENTES VALUES (12,'Lasas S.A.','María','Lasas','34916540145','m.lasas@lasas_sa.com','C/Leganes 15',NULL,'Fuenlabrada','Spain','28945',8,154310);
INSERT INTO CLIENTES VALUES (13,'Camunas Jardines S.L.','Pedro','Camunas','34914873241','pedrocamunas@camunasjardines.com','C/Virgenes 45','C/Princesas 2 1ºB','San Lorenzo del Escorial','Spain','28145',8,16481);
INSERT INTO CLIENTES VALUES (14,'Dardena S.A.','Juan','Rodriguez','34912453217','j.rodriguez@dardena.es','C/Nueva York 74',NULL,'Madrid','Spain','28003',8,321000);
INSERT INTO CLIENTES VALUES (15,'Jardin de Flores','Javier','Villar','654865643','javier_villar@jardindeflores.es','C/ Oña 34',NULL,'Madrid','Spain','28950',30,40000);
INSERT INTO CLIENTES VALUES (16,'Flores Marivi','Maria','Rodriguez','666555444','marivi@mariviflores.com','C/Leganes24',NULL,'Fuenlabrada','Spain','28945',5,1500);
INSERT INTO CLIENTES VALUES (17,'Flowers, S.A','Beatriz','Fernandez','698754159','bea.fernandez@flowers.org','C/Luis Salquillo4',NULL,'Montornes del valles','Spain','24586',5,3500);
INSERT INTO CLIENTES VALUES (18,'Naturajardin','Victoria','Cruz','612343529','victoria@naturajardin.es','Plaza Magallón 15',NULL,'Madrid','Spain','28011',30,5050);
INSERT INTO CLIENTES VALUES (19,'Golf S.A.','Luis','Martinez','916458762','luis.mart@golf_sa.es','C/Estancado',NULL,'Santa cruz de Tenerife','Spain','38297',12,30000);
INSERT INTO CLIENTES VALUES (20,'Americh Golf Management SL','Mario','Suarez','964493063','mario.suarez@americh.golf','C/Letardo',NULL,'Barcelona','Spain','12320',12,20000);
INSERT INTO CLIENTES VALUES (21,'Aloha','Cristian','Rodrigez','916485852','cristian@aloha.com','C/Roman 3',NULL,'Canarias','Spain','35488',12,50000);
INSERT INTO CLIENTES VALUES (22,'El Prat','Francisco','Camacho','916882323','paco.camacho@elprat.org','Avenida Tibidabo',NULL,'Barcelona','Spain','12320',12,30000);
INSERT INTO CLIENTES VALUES (23,'Sotogrande','Maria','Santillana','915576622','santillana@sotogrande.com','C/Paseo del Parque',NULL,'Sotogrande','Spain','11310',12,60000);
INSERT INTO CLIENTES VALUES (24,'Vivero Humanes','Federico','Gomez','654987690','fede.gomez@vivero_humanes.es','C/Miguel Echegaray 54',NULL,'Humanes','Spain','28970',30,7430);
INSERT INTO CLIENTES VALUES (25,'Fuenla City','Tony','Muñoz Mena','675842139','admin@fuenlacity.es','C/Callo 52',NULL,'Fuenlabrada','Spain','28574',5,4500);
INSERT INTO CLIENTES VALUES (26,'Jardines y Mansiones Cactus SL','Eva María','Sánchez','914477777','jardines@cactus_y_mansiones.es','Polígono Industrial Maspalomas, Nº52','Móstoles','Madrid','Spain','29874',9,76000);
INSERT INTO CLIENTES VALUES (27,'Jardinerías Matías SL','Matías','San Martín','916544147','matias@jardmatias.es','C/Francisco Arce, Nº44','Bustarviejo','Madrid','Spain','37845',9,100500);
INSERT INTO CLIENTES VALUES (28,'Agrojardin','Benito','Lopez','675432926','benito@agrojardin.com','C/Mar Caspio 43',NULL,'Getafe','Spain','28904',30,8040);
INSERT INTO CLIENTES VALUES (29,'Top Campo','Joseluis','Sanchez','685746512','joseluis@topcampo.es','C/Ibiza 32',NULL,'Humanes','Spain','28574',5,5500);
INSERT INTO CLIENTES VALUES (30,'Jardineria Sara','Sara','Marquez','675124537','sara@jardineriasara.com','C/Lima 1',NULL,'Fuenlabrada','Spain','27584',5,7500);
INSERT INTO CLIENTES VALUES (31,'Campohermoso','Luis','Jimenez','645925376','luis.jimenez@campohermoso.com','C/Peru 78',NULL,'Fuenlabrada','Spain','28945',30,3250);
INSERT INTO CLIENTES VALUES (32,'france telecom','Francois','Toulou','(33)5120578961','paco@franc_telcom.org','6 place d Alleray 15',NULL,'Paris','France','75010',16,10000);
INSERT INTO CLIENTES VALUES (33,'Musée du Louvre','Pierre','Delacroux','(33)0140205050','pedro@mdlouvre.es','Quai du Louvre',NULL,'Paris','France','75058',16,30000);
INSERT INTO CLIENTES VALUES (35,'Tutifruti S.A','Jacob','Jones','2 9261-2433','j.jones@tutifruti.es','level 24, St. Martins Tower.-31 Market St.',NULL,'Sydney','Australia','02000',31,10000);
INSERT INTO CLIENTES VALUES (36,'Flores S.L.','Antonio','Romero','654352981','a.romero@floressl.com','Avenida España',NULL,'Madrid','Spain','29643',18,6000);
INSERT INTO CLIENTES VALUES (37,'The Magic Garden','Richard','Mcain','926523468','r.mcain@magicgarden.es','Lightning Park',NULL,'London','United Kingdom','65930',18,10000);
INSERT INTO CLIENTES VALUES (38,'El Jardin Viviente S.L','Justin','Smith','2 8005-7161','justin.smith@jardinviviente.es','176 Cumberland Street The rocks',NULL,'Sydney','Australia','2003',31,8000);


-- ESTADOS_PEDIDO
INSERT INTO ESTADOS_PEDIDO VALUES ('P', 'PENDIENTE');
INSERT INTO ESTADOS_PEDIDO VALUES ('E', 'ENTREGADO')
INSERT INTO ESTADOS_PEDIDO VALUES ('R', 'RECHAZADO');



-- PEDIDOS
INSERT INTO PEDIDOS VALUES (1,'2020-01-17','2020-01-19','2020-01-19','E','Pagado a plazos',5);
INSERT INTO PEDIDOS VALUES (2,'2021-10-23','2021-10-28','2021-10-26','E','La entrega llego antes de lo esperado',5);
INSERT INTO PEDIDOS VALUES (3,'2022-06-20','2022-06-25',NULL,'R','Limite de credito superado',5);
INSERT INTO PEDIDOS VALUES (4,'2023-01-20','2023-01-26',NULL,'P',NULL,5);
INSERT INTO PEDIDOS VALUES (8,'2022-11-09','2022-11-14','2022-11-14','E','El cliente paga la mitad con tarjeta y la otra mitad con efectivo, se le realizan dos facturas',1);
INSERT INTO PEDIDOS VALUES (9,'2022-12-22','2022-12-27','2022-12-28','E','El cliente comprueba la integridad del paquete, todo correcto',1);
INSERT INTO PEDIDOS VALUES (10,'2023-01-15','2023-01-20',NULL,'P','El cliente llama para confirmar la fecha - Esperando al proveedor',3);
INSERT INTO PEDIDOS VALUES (11,'2023-01-20','2023-01-27',NULL,'P','El cliente requiere que el pedido se le entregue de 16:00h a 22:00h',1);
INSERT INTO PEDIDOS VALUES (12,'2023-01-22','2023-01-27',NULL,'P','El cliente requiere que el pedido se le entregue de 9:00h a 13:00h',1);
INSERT INTO PEDIDOS VALUES (13,'2023-01-12','2023-01-14','2023-01-15','E',NULL,7);
INSERT INTO PEDIDOS VALUES (14,'2023-01-02','2023-01-02',NULL,'R','mal pago',7);
INSERT INTO PEDIDOS VALUES (15,'2023-01-09','2023-01-12','2023-01-11','E',NULL,7);
INSERT INTO PEDIDOS VALUES (16,'2023-01-06','2023-01-07','2023-01-15','E',NULL,7);
INSERT INTO PEDIDOS VALUES (17,'2023-01-08','2023-01-09','2023-01-11','E','mal estado',7);
INSERT INTO PEDIDOS VALUES (18,'2023-01-05','2023-01-06','2023-01-07','E',NULL,9);
INSERT INTO PEDIDOS VALUES (19,'2023-01-18','2023-02-12',NULL,'P','entregar en murcia',9);
INSERT INTO PEDIDOS VALUES (20,'2023-01-20','2023-02-15',NULL,'P',NULL,9);
INSERT INTO PEDIDOS VALUES (21,'2023-01-09','2023-01-09','2023-01-09','R','mal pago',9);
INSERT INTO PEDIDOS VALUES (22,'2023-01-11','2023-01-11','2023-01-13','E',NULL,9);
INSERT INTO PEDIDOS VALUES (23,'2022-12-30','2023-01-10',NULL,'R','El pedido fue anulado por el cliente',5);
INSERT INTO PEDIDOS VALUES (24,'2022-07-14','2022-07-31','2022-07-25','E',NULL,14);
INSERT INTO PEDIDOS VALUES (25,'2023-02-02','2023-02-08',NULL,'R','El cliente carece de saldo en la cuenta asociada',1);
INSERT INTO PEDIDOS VALUES (26,'2023-02-06','2023-02-12',NULL,'R','El cliente anula la operacion para adquirir mas producto',3);
INSERT INTO PEDIDOS VALUES (27,'2023-02-07','2023-02-13',NULL,'E','El pedido aparece como entregado pero no sabemos en que fecha',3);
INSERT INTO PEDIDOS VALUES (28,'2023-02-10','2023-02-17','2023-02-20','E','El cliente se queja bastante de la espera asociada al producto',3);
INSERT INTO PEDIDOS VALUES (29,'2022-08-01','2022-09-01','2022-09-01','R','El cliente no está conforme con el pedido',14);
INSERT INTO PEDIDOS VALUES (30,'2022-08-03','2022-09-03','2022-08-31','E',NULL,13);
INSERT INTO PEDIDOS VALUES (31,'2022-09-04','2022-09-30','2022-10-04','R','El cliente ha rechazado por llegar 5 dias tarde',13);
INSERT INTO PEDIDOS VALUES (32,'2021-01-07','2021-01-19','2021-01-27','E','Entrega tardia, el cliente puso reclamacion',4);
INSERT INTO PEDIDOS VALUES (33,'2021-05-20','2021-05-28',NULL,'R','El pedido fue anulado por el cliente',4);
INSERT INTO PEDIDOS VALUES (34,'2021-06-20','2022-06-28','2022-06-28','E','Pagado a plazos',4);
INSERT INTO PEDIDOS VALUES (35,'2022-03-10','2023-03-20',NULL,'R','Limite de credito superado',4);
INSERT INTO PEDIDOS VALUES (36,'2022-10-15','2022-12-15','2022-12-10','E',NULL,14);
INSERT INTO PEDIDOS VALUES (37,'2022-11-03','2023-11-13',NULL,'P','El pedido nunca llego a su destino',4);
INSERT INTO PEDIDOS VALUES (38,'2023-03-05','2023-03-06','2023-03-07','E',NULL,19);
INSERT INTO PEDIDOS VALUES (39,'2023-03-06','2023-03-07','2023-03-09','P',NULL,19);
INSERT INTO PEDIDOS VALUES (40,'2023-03-09','2023-03-10','2023-03-13','R',NULL,19);
INSERT INTO PEDIDOS VALUES (41,'2023-03-12','2023-03-13','2023-03-13','E',NULL,19);
INSERT INTO PEDIDOS VALUES (42,'2023-03-22','2023-03-23','2023-03-27','E',NULL,19);
INSERT INTO PEDIDOS VALUES (43,'2023-03-25','2023-03-26','2023-03-28','P',NULL,23);
INSERT INTO PEDIDOS VALUES (44,'2023-03-26','2023-03-27','2023-03-30','P',NULL,23);
INSERT INTO PEDIDOS VALUES (45,'2023-04-01','2023-03-04','2023-03-07','E',NULL,23);
INSERT INTO PEDIDOS VALUES (46,'2023-04-03','2023-03-04','2023-03-05','R',NULL,23);
INSERT INTO PEDIDOS VALUES (47,'2023-04-15','2023-03-17','2023-03-17','E',NULL,23);
INSERT INTO PEDIDOS VALUES (48,'2022-03-17','2022-03-30','2022-03-29','E','Según el Cliente, el pedido llegó defectuoso',26);
INSERT INTO PEDIDOS VALUES (49,'2022-07-12','2022-07-22','2022-07-30','E','El pedido llegó 1 día tarde, pero no hubo queja por parte de la empresa compradora',26);
INSERT INTO PEDIDOS VALUES (50,'2022-03-17','2022-08-09',NULL,'P','Al parecer, el pedido se ha extraviado a la altura de Sotalbo (Ávila)',26);
INSERT INTO PEDIDOS VALUES (51,'2022-10-01','2022-10-14','2022-10-14','E','Todo se entregó a tiempo y en perfecto estado, a pesar del pésimo estado de las carreteras.',26);
INSERT INTO PEDIDOS VALUES (52,'2022-12-07','2022-12-21',NULL,'P','El transportista ha llamado a Eva María para indicarle que el pedido llegará más tarde de lo esperado.',26);
INSERT INTO PEDIDOS VALUES (53,'2022-10-15','2022-11-15','2022-11-09','E','El pedido llega 6 dias antes',13);
INSERT INTO PEDIDOS VALUES (54,'2023-01-11','2023-02-11',NULL,'P',NULL,14);
INSERT INTO PEDIDOS VALUES (55,'2022-12-10','2023-01-10','2023-01-11','E','Retrasado 1 dia por problemas de transporte',14);
INSERT INTO PEDIDOS VALUES (56,'2022-12-19','2023-01-20',NULL,'R','El cliente ha anulado el pedido el dia 2023-01-10',13);
INSERT INTO PEDIDOS VALUES (57,'2023-01-05','2023-02-05',NULL,'P',NULL,13);
INSERT INTO PEDIDOS VALUES (58,'2023-01-24','2023-01-31','2023-01-30','E','Todo correcto',3);
INSERT INTO PEDIDOS VALUES (59,'2022-11-09','2022-11-14','2022-11-14','E','El cliente paga la mitad con tarjeta y la otra mitad con efectivo, se le realizan dos facturas',1);
INSERT INTO PEDIDOS VALUES (60,'2022-12-22','2022-12-27','2022-12-28','E','El cliente comprueba la integridad del paquete, todo correcto',1);
INSERT INTO PEDIDOS VALUES (61,'2023-01-15','2023-01-20',NULL,'P','El cliente llama para confirmar la fecha - Esperando al proveedor',3);
INSERT INTO PEDIDOS VALUES (62,'2023-01-20','2023-01-27',NULL,'P','El cliente requiere que el pedido se le entregue de 16:00h a 22:00h',1);
INSERT INTO PEDIDOS VALUES (63,'2023-01-22','2023-01-27',NULL,'P','El cliente requiere que el pedido se le entregue de 9:00h a 13:00h',1);
INSERT INTO PEDIDOS VALUES (64,'2023-01-24','2023-01-31','2023-01-30','E','Todo correcto',1);
INSERT INTO PEDIDOS VALUES (65,'2023-02-02','2023-02-08',NULL,'R','El cliente carece de saldo en la cuenta asociada',1);
INSERT INTO PEDIDOS VALUES (66,'2023-02-06','2023-02-12',NULL,'R','El cliente anula la operacion para adquirir mas producto',3);
INSERT INTO PEDIDOS VALUES (67,'2023-02-07','2023-02-13',NULL,'E','El pedido aparece como entregado pero no sabemos en que fecha',3);
INSERT INTO PEDIDOS VALUES (68,'2023-02-10','2023-02-17','2023-02-20','E','El cliente se queja bastante de la espera asociada al producto',3);
INSERT INTO PEDIDOS VALUES (74,'2023-01-14','2023-01-22',NULL,'R','El pedido no llego el dia que queria el cliente por fallo del transporte',15);
INSERT INTO PEDIDOS VALUES (75,'2023-01-11','2023-01-13','2023-01-13','E','El pedido llego perfectamente',15);
INSERT INTO PEDIDOS VALUES (76,'2022-11-15','2022-11-23','2022-11-23','E',NULL,15);
INSERT INTO PEDIDOS VALUES (77,'2023-01-03','2023-01-08',NULL,'P','El pedido no pudo ser entregado por problemas meteorologicos',15);
INSERT INTO PEDIDOS VALUES (78,'2022-12-15','2022-12-17','2022-12-17','E','Fue entregado, pero faltaba mercancia que sera entregada otro dia',15);
INSERT INTO PEDIDOS VALUES (79,'2023-01-12','2023-01-13','2023-01-13','E',NULL,28);
INSERT INTO PEDIDOS VALUES (80,'2023-01-25','2023-01-26',NULL,'P','No terminó el pago',28);
INSERT INTO PEDIDOS VALUES (81,'2023-01-18','2023-01-24',NULL,'R','Los producto estaban en mal estado',28);
INSERT INTO PEDIDOS VALUES (82,'2023-01-20','2023-01-29','2023-01-29','E','El pedido llego un poco mas tarde de la hora fijada',28);
INSERT INTO PEDIDOS VALUES (83,'2023-01-24','2023-01-28',NULL,'E',NULL,28);
INSERT INTO PEDIDOS VALUES (89,'2021-10-05','2021-12-13','2021-12-10','E','La entrega se realizo dias antes de la fecha esperada por lo que el cliente quedo satisfecho',35);
INSERT INTO PEDIDOS VALUES (90,'2023-02-07','2022-02-17',NULL,'P','Debido a la nevada caída en la sierra, el pedido no podrá llegar hasta el día ',27);
INSERT INTO PEDIDOS VALUES (91,'2023-03-18','2023-03-29','2023-03-27','E','Todo se entregó a su debido tiempo, incluso con un día de antelación',27);
INSERT INTO PEDIDOS VALUES (92,'2023-04-19','2023-04-30','2023-05-03','E','El pedido se entregó tarde debido a la festividad celebrada en España durante esas fechas',27);
INSERT INTO PEDIDOS VALUES (93,'2023-05-03','2023-05-30','2023-05-17','E','El pedido se entregó antes de lo esperado.',27);
INSERT INTO PEDIDOS VALUES (94,'2023-10-18','2023-11-01',NULL,'P','El pedido está en camino.',27);
INSERT INTO PEDIDOS VALUES (95,'2022-01-04','2022-01-19','2022-01-19','E',NULL,35);
INSERT INTO PEDIDOS VALUES (96,'2022-03-20','2022-04-12','2022-04-13','E','La entrega se retraso un dia',35);
INSERT INTO PEDIDOS VALUES (97,'2022-10-08','2022-11-25','2022-11-25','E',NULL,35);
INSERT INTO PEDIDOS VALUES (98,'2023-01-08','2023-02-13',NULL,'P',NULL,35);
INSERT INTO PEDIDOS VALUES (99,'2023-02-15','2023-02-27',NULL,'P',NULL,16);
INSERT INTO PEDIDOS VALUES (100,'2023-01-10','2023-01-15','2023-01-15','E','El pedido llego perfectamente',16);
INSERT INTO PEDIDOS VALUES (101,'2023-03-07','2023-03-27',NULL,'R','El pedido fue rechazado por el cliente',16);
INSERT INTO PEDIDOS VALUES (102,'2022-12-28','2023-01-08','2023-01-08','E','Pago pendiente',16);
INSERT INTO PEDIDOS VALUES (103,'2023-01-15','2023-01-20','2023-01-24','P',NULL,30);
INSERT INTO PEDIDOS VALUES (104,'2023-03-02','2023-03-06','2023-03-06','E',NULL,30);
INSERT INTO PEDIDOS VALUES (105,'2023-02-14','2023-02-20',NULL,'R','el producto ha sido rechazado por la pesima calidad',30);
INSERT INTO PEDIDOS VALUES (106,'2023-05-13','2023-05-15','2023-05-20','P',NULL,30);
INSERT INTO PEDIDOS VALUES (107,'2023-04-06','2023-04-10','2023-04-10','E',NULL,30);
INSERT INTO PEDIDOS VALUES (108,'2023-04-09','2023-04-15','2023-04-15','E',NULL,16);
INSERT INTO PEDIDOS VALUES (109,'2020-05-25','2020-07-28','2020-07-28','E',NULL,38);
INSERT INTO PEDIDOS VALUES (110,'2021-03-19','2021-04-24','2021-04-24','E',NULL,38);
INSERT INTO PEDIDOS VALUES (111,'2022-03-05','2022-03-30','2022-03-30','E',NULL,36);
INSERT INTO PEDIDOS VALUES (112,'2023-03-05','2023-04-06','2023-05-07','P',NULL,36);
INSERT INTO PEDIDOS VALUES (113,'2022-10-28','2022-11-09','2023-01-09','R','El producto ha sido rechazado por la tardanza de el envio',36);
INSERT INTO PEDIDOS VALUES (114,'2023-01-15','2023-01-29','2023-01-31','E','El envio llego dos dias más tarde debido al mal tiempo',36);
INSERT INTO PEDIDOS VALUES (115,'2022-11-29','2023-01-26','2023-02-27','P',NULL,36);
INSERT INTO PEDIDOS VALUES (116,'2022-06-28','2022-08-01','2022-08-01','E',NULL,38);
INSERT INTO PEDIDOS VALUES (117,'2022-08-25','2022-10-01',NULL,'R','El pedido ha sido rechazado por la acumulacion de pago pendientes del cliente',38);
INSERT INTO PEDIDOS VALUES (118,'2023-02-15','2023-02-27',NULL,'P',NULL,16);
INSERT INTO PEDIDOS VALUES (119,'2023-01-10','2023-01-15','2023-01-15','E','El pedido llego perfectamente',16);
INSERT INTO PEDIDOS VALUES (120,'2023-03-07','2023-03-27',NULL,'R','El pedido fue rechazado por el cliente',16);
INSERT INTO PEDIDOS VALUES (121,'2022-12-28','2023-01-08','2023-01-08','E','Pago pendiente',16);
INSERT INTO PEDIDOS VALUES (122,'2023-04-09','2023-04-15','2023-04-15','E',NULL,16);
INSERT INTO PEDIDOS VALUES (123,'2023-01-15','2023-01-20','2023-01-24','P',NULL,30);
INSERT INTO PEDIDOS VALUES (124,'2023-03-02','2023-03-06','2023-03-06','E',NULL,30);
INSERT INTO PEDIDOS VALUES (125,'2023-02-14','2023-02-20',NULL,'R','el producto ha sido rechazado por la pesima calidad',30);
INSERT INTO PEDIDOS VALUES (126,'2023-05-13','2023-05-15','2023-05-20','P',NULL,30);
INSERT INTO PEDIDOS VALUES (127,'2023-04-06','2023-04-10','2023-04-10','E',NULL,30);
INSERT INTO PEDIDOS VALUES (128,'2022-11-10','2022-12-10','2022-12-29','R','El pedido ha sido rechazado por el cliente por el retraso en la entrega',38);


-- PRODUCTOS
INSERT INTO PRODUCTOS VALUES ('11679','Sierra de Poda 400MM','HR','0,258','HiperGarden Tools','Gracias a la poda se consigue manipular un poco la naturaleza, dándole la forma que más nos guste. Este trabajo básico de jardinería también facilita que las plantas crezcan de un modo más equilibrado, y que las flores y los frutos vuelvan cada año con regularidad. Lo mejor es dar forma cuando los ejemplares son jóvenes, de modo que exijan pocos cuidados cuando sean adultos. Además de saber cuándo y cómo hay que podar, tener unas herramientas adecuadas para esta labor es también de vital importancia.',15,14,11);
INSERT INTO PRODUCTOS VALUES ('21636','Pala','HR','0,156','HiperGarden Tools','Palas de acero con cresta de corte en la punta para cortar bien el terreno. Buena penetración en tierras muy compactas.',15,14,13);
INSERT INTO PRODUCTOS VALUES ('22225','Rastrillo de Jardín','HR','1,064','HiperGarden Tools','Fabuloso rastillo que le ayudará a eliminar piedras, hojas, ramas y otros elementos incómodos en su jardín.',15,12,11);
INSERT INTO PRODUCTOS VALUES ('30310','Azadón','HR','0,168','HiperGarden Tools','Longitud:24cm. Herramienta fabricada en acero y pintura epoxi,alargando su durabilidad y preveniendo la corrosión.Diseño pensado para el ahorro de trabajo.',15,12,11);
INSERT INTO PRODUCTOS VALUES ('AR-001','Ajedrea','AR','15-20','Murcia Seasons','Planta aromática que fresca se utiliza para condimentar carnes y ensaladas, y seca, para pastas, sopas y guisantes',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-002','Lavándula Dentata','AR','15-20','Murcia Seasons','Espliego de jardín, Alhucema rizada, Alhucema dentada, Cantueso rizado. Familia: Lamiaceae.Origen: España y Portugal. Mata de unos 60 cm de alto. Las hojas son aromáticas, dentadas y de color verde grisáceas.  Produce compactas espigas de flores pequeñas, ligeramente aromáticas, tubulares,de color azulado y con brácteas púrpuras.  Frutos: nuececillas alargadas encerradas en el tubo del cáliz.  Se utiliza en jardineria y no en perfumeria como otros cantuesos, espliegos y lavandas.  Tiene propiedades aromatizantes y calmantes. Adecuadas para la formación de setos bajos. Se dice que su aroma ahuyenta pulgones y otros insectos perjudiciales para las plantas vecinas.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-003','Mejorana','AR','15-20','Murcia Seasons','Origanum majorana. No hay que confundirlo con el orégano. Su sabor se parece más al tomillo, pero es más dulce y aromático.Se usan las hojas frescas o secas, picadas, machacadas o en polvo, en sopas, rellenos, quiches y tartas, tortillas, platos con papas y, como aderezo, en ramilletes de hierbas.El sabor delicado de la mejorana se elimina durante la cocción, de manera que es mejor agregarla cuando el plato esté en su punto o en aquéllos que apenas necesitan cocción.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-004','Melissa ','AR','15-20','Murcia Seasons','Es una planta perenne (dura varios años) conocida por el agradable y característico olor a limón que desprenden en verano. Nunca debe faltar en la huerta o jardín por su agradable aroma y por los variados usos que tiene: planta olorosa, condimentaria y medicinal. Su cultivo es muy fácil. Le va bien un suelo ligero, con buen drenaje y riego sin exceso. A pleno sol o por lo menos 5 horas de sol por día. Cada año, su abonado mineral correspondiente.En otoño, la melisa pierde el agradable olor a limón que desprende en verano sus flores azules y blancas. En este momento se debe cortar a unos 20 cm. del suelo. Brotará de forma densa en primavera.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-005','Mentha Sativa','AR','15-20','Murcia Seasons','¿Quién no conoce la Hierbabuena? Se trata de una plantita muy aromática, agradable y cultivada extensamente por toda España. Es hierba perenne (por tanto vive varios años, no es anual). Puedes cultivarla en maceta o plantarla en la tierra del jardín o en un rincón del huerto. Lo más importante es que cuente con bastante agua. En primavera debes aportar fertilizantes minerales. Vive mejor en semisombra que a pleno sol.Si ves orugas o los agujeros en hojas consecuencia de su ataque, retíralas una a una a mano; no uses insecticidas químicos.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-006','Petrosilium Hortense (Peregil)','AR','15-20','Murcia Seasons','Nombre científico o latino: Petroselinum hortense, Petroselinum crispum. Nombre común o vulgar: Perejil, Perejil rizado Familia: Umbelliferae (Umbelíferas). Origen: el origen del perejil se encuentra en el Mediterraneo. Esta naturalizada en casi toda Europa. Se utiliza como condimento y para adorno, pero también en ensaladas. Se suele regalar en las fruterías y verdulerías.El perejil lo hay de 2 tipos: de hojas planas y de hojas rizadas.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-007','Salvia Mix','AR','15-20','Murcia Seasons','La Salvia es un pequeño arbusto que llega hasta el metro de alto.Tiene una vida breve, de unos pocos años.En el jardín, como otras aromáticas, queda muy bien en una rocalla o para hacer una bordura perfumada a cada lado de un camino de Salvia. Abona después de cada corte y recorta el arbusto una vez pase la floración.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-008','Thymus Citriodra (Tomillo limón)','AR','15-20','Murcia Seasons','Nombre común o vulgar: Tomillo, Tremoncillo Familia: Labiatae (Labiadas).Origen: Región mediterránea.Arbustillo bajo, de 15 a 40 cm de altura. Las hojas son muy pequeñas, de unos 6 mm de longitud; según la variedad pueden ser verdes, verdes grisáceas, amarillas, o jaspeadas. Las flores aparecen de mediados de primavera hasta bien entrada la época estival y se presentan en racimos terminales que habitualmente son de color violeta o púrpura aunque también pueden ser blancas. Esta planta despide un intenso y típico aroma, que se incrementa con el roce. El tomillo resulta de gran belleza cuando está en flor. El tomillo atrae a avispas y abejas. En jardinería se usa como manchas, para hacer borduras, para aromatizar el ambiente, llenar huecos, cubrir rocas, para jardines en miniatura, etc. Arranque las flores y hojas secas del tallo y añadálos a un popurri, introdúzcalos en saquitos de hierbas o en la almohada.También puede usar las ramas secas con flores para añadir aroma y textura a cestos abiertos.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-009','Thymus Vulgaris','AR','15-20','Murcia Seasons','Nombre común o vulgar: Tomillo, Tremoncillo Familia: Labiatae (Labiadas). Origen: Región mediterránea. Arbustillo bajo, de 15 a 40 cm de altura. Las hojas son muy pequeñas, de unos 6 mm de longitud; según la variedad pueden ser verdes, verdes grisáceas, amarillas, o jaspeadas. Las flores aparecen de mediados de primavera hasta bien entrada la época estival y se presentan en racimos terminales que habitualmente son de color violeta o púrpura aunque también pueden ser blancas. Esta planta despide un intenso y típico aroma, que se incrementa con el roce. El tomillo resulta de gran belleza cuando está en flor. El tomillo atrae a avispas y abejas.\r\n En jardinería se usa como manchas, para hacer borduras, para aromatizar el ambiente, llenar huecos, cubrir rocas, para jardines en miniatura, etc. Arranque las flores y hojas secas del tallo y añadálos a un popurri, introdúzcalos en saquitos de hierbas o en la almohada. También puede usar las ramas secas con flores para añadir aroma y textura a cestos abiertos.',140,1,0);
INSERT INTO PRODUCTOS VALUES ('AR-010','Santolina Chamaecyparys','AR','15-20','Murcia Seasons','',140,1,0);
INSERT INTO PRODUCTOS VALUES ('FR-1','Expositor Cítricos Mix','FR','100-120','Frutales Talavera S.A','',15,7,5);
INSERT INTO PRODUCTOS VALUES ('FR-10','Limonero 2 años injerto','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el hombre, en este caso buscando las necesidades del mercado.',15,7,5);
INSERT INTO PRODUCTOS VALUES ('FR-100','Nectarina','FR','8/10','Frutales Talavera S.A','Se trata de un árbol derivado por mutación de los melocotoneros comunes, y los únicos caracteres diferenciales son la ausencia de tomentosidad en la piel del fruto. La planta, si se deja crecer libremente, adopta un porte globoso con unas dimensiones medias de 4-6 metros',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-101','Nogal','FR','8/10','Frutales Talavera S.A','',50,13,10);
INSERT INTO PRODUCTOS VALUES ('FR-102','Olea-Olivos','FR','8/10','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,18,14);
INSERT INTO PRODUCTOS VALUES ('FR-103','Olea-Olivos','FR','10/12','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,25,20);
INSERT INTO PRODUCTOS VALUES ('FR-104','Olea-Olivos','FR','12/4','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-105','Olea-Olivos','FR','14/16','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-106','Peral','FR','8/10','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-107','Peral','FR','10/12','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-108','Peral','FR','12/14','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-11','Limonero 30/40','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,100,80);
INSERT INTO PRODUCTOS VALUES ('FR-12','Kunquat ','FR','','NaranjasValencianas.com','su nombre científico se origina en honor a un hoticultor escocés que recolectó especímenes en China, (\"Fortunella\"), Robert Fortune (1812-1880), y \"margarita\", del latín margaritus-a-um = perla, en alusión a sus pequeños y brillantes frutos. Se trata de un arbusto o árbol pequeño de 2-3 m de altura, inerme o con escasas espinas.Hojas lanceoladas de 4-8 (-15) cm de longitud, con el ápice redondeado y la base cuneada.Tienen el margen crenulado en su mitad superior, el haz verde brillante y el envés más pálido.Pecíolo ligeramente marginado.Flores perfumadas solitarias o agrupadas en inflorescencias axilares, blancas.El fruto es lo más característico, es el más pequeño de todos los cítricos y el único cuya cáscara se puede comer.Frutos pequeños, con semillas, de corteza fina, dulce, aromática y comestible, y de pulpa naranja amarillenta y ligeramente ácida.Sus frutos son muy pequeños y tienen un carácter principalmente ornamental.',15,21,16);
INSERT INTO PRODUCTOS VALUES ('FR-13','Kunquat  EXTRA con FRUTA','FR','150-170','NaranjasValencianas.com','su nombre científico se origina en honor a un hoticultor escocés que recolectó especímenes en China, (\"Fortunella\"), Robert Fortune (1812-1880), y \"margarita\", del latín margaritus-a-um = perla, en alusión a sus pequeños y brillantes frutos. Se trata de un arbusto o árbol pequeño de 2-3 m de altura, inerme o con escasas espinas.Hojas lanceoladas de 4-8 (-15) cm de longitud, con el ápice redondeado y la base cuneada.Tienen el margen crenulado en su mitad superior, el haz verde brillante y el envés más pálido.Pecíolo ligeramente marginado.Flores perfumadas solitarias o agrupadas en inflorescencias axilares, blancas.El fruto es lo más característico, es el más pequeño de todos los cítricos y el único cuya cáscara se puede comer.Frutos pequeños, con semillas, de corteza fina, dulce, aromática y comestible, y de pulpa naranja amarillenta y ligeramente ácida.Sus frutos son muy pequeños y tienen un carácter principalmente ornamental.',15,57,45);
INSERT INTO PRODUCTOS VALUES ('FR-14','Calamondin Mini','FR','','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,10,8);
INSERT INTO PRODUCTOS VALUES ('FR-15','Calamondin Copa ','FR','','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,25,20);
INSERT INTO PRODUCTOS VALUES ('FR-16','Calamondin Copa EXTRA Con FRUTA','FR','100-120','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,45,36);
INSERT INTO PRODUCTOS VALUES ('FR-17','Rosal bajo 1Âª -En maceta-inicio brotación','FR','','Frutales Talavera S.A','',15,2,1);
INSERT INTO PRODUCTOS VALUES ('FR-18','ROSAL TREPADOR','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS VALUES ('FR-19','Camelia Blanco, Chrysler Rojo, Soraya Naranja, ','FR','','NaranjasValencianas.com','',350,4,3);
INSERT INTO PRODUCTOS VALUES ('FR-2','Naranjo -Plantón joven 1 año injerto','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,6,4);
INSERT INTO PRODUCTOS VALUES ('FR-20','Landora Amarillo, Rose Gaujard bicolor blanco-rojo','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS VALUES ('FR-21','Kordes Perfect bicolor rojo-amarillo, Roundelay rojo fuerte','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS VALUES ('FR-22','Pitimini rojo','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS VALUES ('FR-23','Rosal copa ','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-24','Albaricoquero Corbato','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-25','Albaricoquero Moniqui','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-26','Albaricoquero Kurrot','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-27','Cerezo Burlat','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-28','Cerezo Picota','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-29','Cerezo Napoleón','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-3','Naranjo 2 años injerto','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,7,5);
INSERT INTO PRODUCTOS VALUES ('FR-30','Ciruelo R. Claudia Verde   ','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-31','Ciruelo Santa Rosa','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-32','Ciruelo Golden Japan','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-33','Ciruelo Friar','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-34','Ciruelo Reina C. De Ollins','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-35','Ciruelo Claudia Negra','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-36','Granado Mollar de Elche','FR','','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-37','Higuera Napolitana','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-38','Higuera Verdal','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-39','Higuera Breva','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-4','Naranjo calibre 8/10','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,29,23);
INSERT INTO PRODUCTOS VALUES ('FR-40','Manzano Starking Delicious','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-41','Manzano Reineta','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-42','Manzano Golden Delicious','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-43','Membrillero Gigante de Wranja','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-44','Melocotonero Spring Crest','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-45','Melocotonero Amarillo de Agosto','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-46','Melocotonero Federica','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-47','Melocotonero Paraguayo','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-48','Nogal Común','FR','','Frutales Talavera S.A','',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-49','Parra Uva de Mesa','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-5','Mandarino -Plantón joven','FR','','Frutales Talavera S.A','',15,6,4);
INSERT INTO PRODUCTOS VALUES ('FR-50','Peral Castell','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-51','Peral Williams','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-52','Peral Conference','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-53','Peral Blanq. de Aranjuez','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-54','Níspero Tanaca','FR','','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-55','Olivo Cipresino','FR','','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-56','Nectarina','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS VALUES ('FR-57','Kaki Rojo Brillante','FR','','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',400,9,7);
INSERT INTO PRODUCTOS VALUES ('FR-58','Albaricoquero','FR','8/10','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-59','Albaricoquero','FR','10/12','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-6','Mandarino 2 años injerto','FR','','Frutales Talavera S.A','',15,7,5);
INSERT INTO PRODUCTOS VALUES ('FR-60','Albaricoquero','FR','12/14','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-61','Albaricoquero','FR','14/16','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-62','Albaricoquero','FR','16/18','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-63','Cerezo','FR','8/10','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',300,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-64','Cerezo','FR','10/12','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',15,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-65','Cerezo','FR','12/14','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',200,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-66','Cerezo','FR','14/16','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-67','Cerezo','FR','16/18','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-68','Cerezo','FR','18/20','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,80,64);
INSERT INTO PRODUCTOS VALUES ('FR-69','Cerezo','FR','20/25','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,91,72);
INSERT INTO PRODUCTOS VALUES ('FR-7','Mandarino calibre 8/10','FR','','Frutales Talavera S.A','',15,29,23);
INSERT INTO PRODUCTOS VALUES ('FR-70','Ciruelo','FR','8/10','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-71','Ciruelo','FR','10/12','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-72','Ciruelo','FR','12/14','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-73','Granado','FR','8/10','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,13,10);
INSERT INTO PRODUCTOS VALUES ('FR-74','Granado','FR','10/12','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-75','Granado','FR','12/14','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-76','Granado','FR','14/16','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-77','Granado','FR','16/18','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-78','Higuera','FR','8/10','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,15,12);
INSERT INTO PRODUCTOS VALUES ('FR-79','Higuera','FR','10/12','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-8','Limonero -Plantón joven','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,6,4);
INSERT INTO PRODUCTOS VALUES ('FR-80','Higuera','FR','12/14','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-81','Higuera','FR','14/16','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-82','Higuera','FR','16/18','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-83','Higuera','FR','18/20','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,80,64);
INSERT INTO PRODUCTOS VALUES ('FR-84','Kaki','FR','8/10','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',50,13,10);
INSERT INTO PRODUCTOS VALUES ('FR-85','Kaki','FR','16/18','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-86','Manzano','FR','8/10','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-87','Manzano','FR','10/12','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-88','Manzano','FR','12/14','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-89','Manzano','FR','14/16','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-9','Limonero calibre 8/10','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,29,23);
INSERT INTO PRODUCTOS VALUES ('FR-90','Níspero','FR','16/18','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',50,70,56);
INSERT INTO PRODUCTOS VALUES ('FR-91','Níspero','FR','18/20','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',50,80,64);
INSERT INTO PRODUCTOS VALUES ('FR-92','Melocotonero','FR','8/10','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-93','Melocotonero','FR','10/12','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-94','Melocotonero','FR','12/14','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-95','Melocotonero','FR','14/16','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,49,39);
INSERT INTO PRODUCTOS VALUES ('FR-96','Membrillero','FR','8/10','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,11,8);
INSERT INTO PRODUCTOS VALUES ('FR-97','Membrillero','FR','10/12','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,22,17);
INSERT INTO PRODUCTOS VALUES ('FR-98','Membrillero','FR','12/14','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,32,25);
INSERT INTO PRODUCTOS VALUES ('FR-99','Membrillero','FR','14/16','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,49,39);
INSERT INTO PRODUCTOS VALUES ('OR-001','Arbustos Mix Maceta','OR','40-60','Valencia Garden Service','',25,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-100','Mimosa Injerto CLASICA Dealbata ','OR','100-110','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,12,9);
INSERT INTO PRODUCTOS VALUES ('OR-101','Expositor Mimosa Semilla Mix','OR','170-200','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-102','Mimosa Semilla Bayleyana  ','OR','170-200','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-103','Mimosa Semilla Bayleyana   ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-104','Mimosa Semilla Cyanophylla    ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-105','Mimosa Semilla Espectabilis  ','OR','160-170','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-106','Mimosa Semilla Longifolia   ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-107','Mimosa Semilla Floribunda 4 estaciones','OR','120-140','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-108','Abelia Floribunda','OR','35-45','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-109','Callistemom (Mix)','OR','35-45','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',100,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-110','Callistemom (Mix)','OR','40-60','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',100,2,1);
INSERT INTO PRODUCTOS VALUES ('OR-111','Corylus Avellana \"Contorta\"','OR','35-45','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-112','Escallonia (Mix)','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-113','Evonimus Emerald Gayeti','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-114','Evonimus Pulchellus','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-115','Forsytia Intermedia \"Lynwood\"','OR','35-45','Viveros EL OASIS','',120,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-116','Hibiscus Syriacus  \"Diana\" -Blanco Puro','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-117','Hibiscus Syriacus  \"Helene\" -Blanco-C.rojo','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-118','Hibiscus Syriacus \"Pink Giant\" Rosa','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-119','Laurus Nobilis Arbusto - Ramificado Bajo','OR','40-50','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-120','Lonicera Nitida ','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-121','Lonicera Nitida \"Maigrum\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-122','Lonicera Pileata','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-123','Philadelphus \"Virginal\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-124','Prunus pisardii  ','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-125','Viburnum Tinus \"Eve Price\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-126','Weigelia \"Bristol Ruby\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-127','Camelia japonica','OR','40-60','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-128','Camelia japonica ejemplar','OR','200-250','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,98,78);
INSERT INTO PRODUCTOS VALUES ('OR-129','Camelia japonica ejemplar','OR','250-300','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,110,88);
INSERT INTO PRODUCTOS VALUES ('OR-130','Callistemom COPA','OR','110/120','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',50,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-131','Leptospermum formado PIRAMIDE','OR','80-100','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-132','Leptospermum COPA','OR','110/120','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-133','Nerium oleander-CALIDAD \"GARDEN\"','OR','40-45','Viveros EL OASIS','',50,2,1);
INSERT INTO PRODUCTOS VALUES ('OR-134','Nerium Oleander Arbusto GRANDE','OR','160-200','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS VALUES ('OR-135','Nerium oleander COPA  Calibre 6/8','OR','50-60','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-136','Nerium oleander ARBOL Calibre 8/10','OR','225-250','Viveros EL OASIS','',100,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-137','ROSAL TREPADOR','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-138','Camelia Blanco, Chrysler Rojo, Soraya Naranja, ','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-139','Landora Amarillo, Rose Gaujard bicolor blanco-rojo','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-140','Kordes Perfect bicolor rojo-amarillo, Roundelay rojo fuerte','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-141','Pitimini rojo','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-142','Solanum Jazminoide','OR','150-160','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS VALUES ('OR-143','Wisteria Sinensis  azul, rosa, blanca','OR','','Viveros EL OASIS','',100,9,7);
INSERT INTO PRODUCTOS VALUES ('OR-144','Wisteria Sinensis INJERTADAS DECÃ“','OR','140-150','Viveros EL OASIS','',100,12,9);
INSERT INTO PRODUCTOS VALUES ('OR-145','Bougamvillea Sanderiana Tutor','OR','80-100','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS VALUES ('OR-146','Bougamvillea Sanderiana Tutor','OR','125-150','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-147','Bougamvillea Sanderiana Tutor','OR','180-200','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-148','Bougamvillea Sanderiana Espaldera','OR','45-50','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-149','Bougamvillea Sanderiana Espaldera','OR','140-150','Viveros EL OASIS','',100,17,13);
INSERT INTO PRODUCTOS VALUES ('OR-150','Bougamvillea roja, naranja','OR','110-130','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS VALUES ('OR-151','Bougamvillea Sanderiana, 3 tut. piramide','OR','','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-152','Expositor Árboles clima continental','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-153','Expositor Árboles clima mediterráneo','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-154','Expositor Árboles borde del mar','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-155','Acer Negundo  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-156','Acer platanoides  ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-157','Acer Pseudoplatanus ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-158','Brachychiton Acerifolius  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-159','Brachychiton Discolor  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-160','Brachychiton Rupestris','OR','170-200','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-161','Cassia Corimbosa  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-162','Cassia Corimbosa ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-163','Chitalpa Summer Bells   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-164','Erytrina Kafra','OR','170-180','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-165','Erytrina Kafra','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-166','Eucalyptus Citriodora  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-167','Eucalyptus Ficifolia  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-168','Eucalyptus Ficifolia   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-169','Hibiscus Syriacus  Var. Injertadas 1 Tallo ','OR','170-200','Viveros EL OASIS','',80,12,9);
INSERT INTO PRODUCTOS VALUES ('OR-170','Lagunaria Patersonii  ','OR','140-150','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-171','Lagunaria Patersonii   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-172','Lagunaria patersonii  calibre 8/10','OR','200-225','Viveros EL OASIS','',80,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-173','Morus Alba  ','OR','200-225','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-174','Morus Alba  calibre 8/10','OR','200-225','Viveros EL OASIS','',80,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-175','Platanus Acerifolia   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-176','Prunus pisardii  ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-177','Robinia Pseudoacacia Casque Rouge   ','OR','200-225','Viveros EL OASIS','',80,15,12);
INSERT INTO PRODUCTOS VALUES ('OR-178','Salix Babylonica  Pendula  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-179','Sesbania Punicea   ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-180','Tamarix  Ramosissima Pink Cascade   ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-181','Tamarix  Ramosissima Pink Cascade   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-182','Tecoma Stands   ','OR','200-225','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-183','Tecoma Stands  ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-184','Tipuana Tipu  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-185','Pleioblastus distichus-Bambú enano','OR','15-20','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-186','Sasa palmata ','OR','20-30','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-187','Sasa palmata ','OR','40-45','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-188','Sasa palmata ','OR','50-60','Viveros EL OASIS','',80,25,20);
INSERT INTO PRODUCTOS VALUES ('OR-189','Phylostachys aurea','OR','180-200','Viveros EL OASIS','',80,22,17);
INSERT INTO PRODUCTOS VALUES ('OR-190','Phylostachys aurea','OR','250-300','Viveros EL OASIS','',80,32,25);
INSERT INTO PRODUCTOS VALUES ('OR-191','Phylostachys Bambusa Spectabilis','OR','180-200','Viveros EL OASIS','',80,24,19);
INSERT INTO PRODUCTOS VALUES ('OR-192','Phylostachys biseti','OR','160-170','Viveros EL OASIS','',80,22,17);
INSERT INTO PRODUCTOS VALUES ('OR-193','Phylostachys biseti','OR','160-180','Viveros EL OASIS','',80,20,16);
INSERT INTO PRODUCTOS VALUES ('OR-194','Pseudosasa japonica (Metake)','OR','225-250','Viveros EL OASIS','',80,20,16);
INSERT INTO PRODUCTOS VALUES ('OR-195','Pseudosasa japonica (Metake) ','OR','30-40','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-196','Cedrus Deodara ','OR','80-100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-197','Cedrus Deodara \"Feeling Blue\" Novedad','OR','rastrero','Viveros EL OASIS','',80,12,9);
INSERT INTO PRODUCTOS VALUES ('OR-198','Juniperus chinensis \"Blue Alps\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-199','Juniperus Chinensis Stricta','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-200','Juniperus horizontalis Wiltonii','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-201','Juniperus squamata \"Blue Star\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-202','Juniperus x media Phitzeriana verde','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-203','Pinus Canariensis','OR','80-100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-204','Pinus Halepensis','OR','160-180','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-205','Pinus Pinea -Pino Piñonero','OR','70-80','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-206','Thuja Esmeralda ','OR','80-100','Viveros EL OASIS','',80,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-207','Tuja Occidentalis Woodwardii','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-208','Tuja orientalis \"Aurea nana\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-209','Archontophoenix Cunninghamiana','OR','80 - 100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-210','Beucarnea Recurvata','OR','130  - 150','Viveros EL OASIS','',2,39,31);
INSERT INTO PRODUCTOS VALUES ('OR-211','Beucarnea Recurvata','OR','180 - 200','Viveros EL OASIS','',5,59,47);
INSERT INTO PRODUCTOS VALUES ('OR-212','Bismarckia Nobilis','OR','200 - 220','Viveros EL OASIS','',4,217,173);
INSERT INTO PRODUCTOS VALUES ('OR-213','Bismarckia Nobilis','OR','240 - 260','Viveros EL OASIS','',4,266,212);
INSERT INTO PRODUCTOS VALUES ('OR-214','Brahea Armata','OR','45 - 60','Viveros EL OASIS','',0,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-215','Brahea Armata','OR','120 - 140','Viveros EL OASIS','',100,112,89);
INSERT INTO PRODUCTOS VALUES ('OR-216','Brahea Edulis','OR','80 - 100','Viveros EL OASIS','',100,19,15);
INSERT INTO PRODUCTOS VALUES ('OR-217','Brahea Edulis','OR','140 - 160','Viveros EL OASIS','',100,64,51);
INSERT INTO PRODUCTOS VALUES ('OR-218','Butia Capitata','OR','70 - 90','Viveros EL OASIS','',100,25,20);
INSERT INTO PRODUCTOS VALUES ('OR-219','Butia Capitata','OR','90 - 110','Viveros EL OASIS','',100,29,23);
INSERT INTO PRODUCTOS VALUES ('OR-220','Butia Capitata','OR','90 - 120','Viveros EL OASIS','',100,36,28);
INSERT INTO PRODUCTOS VALUES ('OR-221','Butia Capitata','OR','85 - 105','Viveros EL OASIS','',100,59,47);
INSERT INTO PRODUCTOS VALUES ('OR-222','Butia Capitata','OR','130 - 150','Viveros EL OASIS','',100,87,69);
INSERT INTO PRODUCTOS VALUES ('OR-223','Chamaerops Humilis','OR','40 - 45','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS VALUES ('OR-224','Chamaerops Humilis','OR','50 - 60','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS VALUES ('OR-225','Chamaerops Humilis','OR','70 - 90','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-226','Chamaerops Humilis','OR','115 - 130','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS VALUES ('OR-227','Chamaerops Humilis','OR','130 - 150','Viveros EL OASIS','',100,64,51);
INSERT INTO PRODUCTOS VALUES ('OR-228','Chamaerops Humilis \"Cerifera\"','OR','70 - 80','Viveros EL OASIS','',100,32,25);
INSERT INTO PRODUCTOS VALUES ('OR-229','Chrysalidocarpus Lutescens -ARECA','OR','130 - 150','Viveros EL OASIS','',100,22,17);
INSERT INTO PRODUCTOS VALUES ('OR-230','Cordyline Australis -DRACAENA','OR','190 - 210','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS VALUES ('OR-231','Cycas Revoluta','OR','55 - 65','Viveros EL OASIS','',100,15,12);
INSERT INTO PRODUCTOS VALUES ('OR-232','Cycas Revoluta','OR','80 - 90','Viveros EL OASIS','',100,34,27);
INSERT INTO PRODUCTOS VALUES ('OR-233','Dracaena Drago','OR','60 - 70','Viveros EL OASIS','',1,13,10);
INSERT INTO PRODUCTOS VALUES ('OR-234','Dracaena Drago','OR','130 - 150','Viveros EL OASIS','',2,64,51);
INSERT INTO PRODUCTOS VALUES ('OR-235','Dracaena Drago','OR','150 - 175','Viveros EL OASIS','',2,92,73);
INSERT INTO PRODUCTOS VALUES ('OR-236','Jubaea Chilensis','OR','','Viveros EL OASIS','',100,49,39);
INSERT INTO PRODUCTOS VALUES ('OR-237','Livistonia Australis','OR','100 - 125','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS VALUES ('OR-238','Livistonia Decipiens','OR','90 - 110','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS VALUES ('OR-239','Livistonia Decipiens','OR','180 - 200','Viveros EL OASIS','',50,49,39);
INSERT INTO PRODUCTOS VALUES ('OR-240','Phoenix Canariensis','OR','110 - 130','Viveros EL OASIS','',50,6,4);
INSERT INTO PRODUCTOS VALUES ('OR-241','Phoenix Canariensis','OR','180 - 200','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS VALUES ('OR-242','Rhaphis Excelsa','OR','80 - 100','Viveros EL OASIS','',50,21,16);
INSERT INTO PRODUCTOS VALUES ('OR-243','Rhaphis Humilis','OR','150- 170','Viveros EL OASIS','',50,64,51);
INSERT INTO PRODUCTOS VALUES ('OR-244','Sabal Minor','OR','60 - 75','Viveros EL OASIS','',50,11,8);
INSERT INTO PRODUCTOS VALUES ('OR-245','Sabal Minor','OR','120 - 140','Viveros EL OASIS','',50,34,27);
INSERT INTO PRODUCTOS VALUES ('OR-246','Trachycarpus Fortunei','OR','90 - 105','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS VALUES ('OR-247','Trachycarpus Fortunei','OR','250-300','Viveros EL OASIS','',2,462,369);
INSERT INTO PRODUCTOS VALUES ('OR-248','Washingtonia Robusta','OR','60 - 70','Viveros EL OASIS','',15,3,2);
INSERT INTO PRODUCTOS VALUES ('OR-249','Washingtonia Robusta','OR','130 - 150','Viveros EL OASIS','',15,5,4);
INSERT INTO PRODUCTOS VALUES ('OR-250','Yucca Jewel','OR','80 - 105','Viveros EL OASIS','',15,10,8);
INSERT INTO PRODUCTOS VALUES ('OR-251','Zamia Furfuracaea','OR','90 - 110','Viveros EL OASIS','',15,168,134);
INSERT INTO PRODUCTOS VALUES ('OR-99','Mimosa DEALBATA Gaulois Astier  ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,14,11);


-- PRODUCTOS2
INSERT INTO PRODUCTOS2 VALUES ('11679','Sierra de Poda 400MM','HR','0,258','HiperGarden Tools','Gracias a la poda se consigue manipular un poco la naturaleza, dándole la forma que más nos guste. Este trabajo básico de jardinería también facilita que las plantas crezcan de un modo más equilibrado, y que las flores y los frutos vuelvan cada año con regularidad. Lo mejor es dar forma cuando los ejemplares son jóvenes, de modo que exijan pocos cuidados cuando sean adultos. Además de saber cuándo y cómo hay que podar, tener unas herramientas adecuadas para esta labor es también de vital importancia.',15,14,11);
INSERT INTO PRODUCTOS2 VALUES ('21636','Pala','HR','0,156','HiperGarden Tools','Palas de acero con cresta de corte en la punta para cortar bien el terreno. Buena penetración en tierras muy compactas.',15,14,13);
INSERT INTO PRODUCTOS2 VALUES ('22225','Rastrillo de Jardín','HR','1,064','HiperGarden Tools','Fabuloso rastillo que le ayudará a eliminar piedras, hojas, ramas y otros elementos incómodos en su jardín.',15,12,11);
INSERT INTO PRODUCTOS2 VALUES ('30310','Azadón','HR','0,168','HiperGarden Tools','Longitud:24cm. Herramienta fabricada en acero y pintura epoxi,alargando su durabilidad y preveniendo la corrosión.Diseño pensado para el ahorro de trabajo.',15,12,11);
INSERT INTO PRODUCTOS2 VALUES ('AR-001','Ajedrea','AR','15-20','Murcia Seasons','Planta aromática que fresca se utiliza para condimentar carnes y ensaladas, y seca, para pastas, sopas y guisantes',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-002','Lavándula Dentata','AR','15-20','Murcia Seasons','Espliego de jardín, Alhucema rizada, Alhucema dentada, Cantueso rizado. Familia: Lamiaceae.Origen: España y Portugal. Mata de unos 60 cm de alto. Las hojas son aromáticas, dentadas y de color verde grisáceas.  Produce compactas espigas de flores pequeñas, ligeramente aromáticas, tubulares,de color azulado y con brácteas púrpuras.  Frutos: nuececillas alargadas encerradas en el tubo del cáliz.  Se utiliza en jardineria y no en perfumeria como otros cantuesos, espliegos y lavandas.  Tiene propiedades aromatizantes y calmantes. Adecuadas para la formación de setos bajos. Se dice que su aroma ahuyenta pulgones y otros insectos perjudiciales para las plantas vecinas.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-003','Mejorana','AR','15-20','Murcia Seasons','Origanum majorana. No hay que confundirlo con el orégano. Su sabor se parece más al tomillo, pero es más dulce y aromático.Se usan las hojas frescas o secas, picadas, machacadas o en polvo, en sopas, rellenos, quiches y tartas, tortillas, platos con papas y, como aderezo, en ramilletes de hierbas.El sabor delicado de la mejorana se elimina durante la cocción, de manera que es mejor agregarla cuando el plato esté en su punto o en aquéllos que apenas necesitan cocción.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-004','Melissa ','AR','15-20','Murcia Seasons','Es una planta perenne (dura varios años) conocida por el agradable y característico olor a limón que desprenden en verano. Nunca debe faltar en la huerta o jardín por su agradable aroma y por los variados usos que tiene: planta olorosa, condimentaria y medicinal. Su cultivo es muy fácil. Le va bien un suelo ligero, con buen drenaje y riego sin exceso. A pleno sol o por lo menos 5 horas de sol por día. Cada año, su abonado mineral correspondiente.En otoño, la melisa pierde el agradable olor a limón que desprende en verano sus flores azules y blancas. En este momento se debe cortar a unos 20 cm. del suelo. Brotará de forma densa en primavera.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-005','Mentha Sativa','AR','15-20','Murcia Seasons','¿Quién no conoce la Hierbabuena? Se trata de una plantita muy aromática, agradable y cultivada extensamente por toda España. Es hierba perenne (por tanto vive varios años, no es anual). Puedes cultivarla en maceta o plantarla en la tierra del jardín o en un rincón del huerto. Lo más importante es que cuente con bastante agua. En primavera debes aportar fertilizantes minerales. Vive mejor en semisombra que a pleno sol.Si ves orugas o los agujeros en hojas consecuencia de su ataque, retíralas una a una a mano; no uses insecticidas químicos.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-006','Petrosilium Hortense (Peregil)','AR','15-20','Murcia Seasons','Nombre científico o latino: Petroselinum hortense, Petroselinum crispum. Nombre común o vulgar: Perejil, Perejil rizado Familia: Umbelliferae (Umbelíferas). Origen: el origen del perejil se encuentra en el Mediterraneo. Esta naturalizada en casi toda Europa. Se utiliza como condimento y para adorno, pero también en ensaladas. Se suele regalar en las fruterías y verdulerías.El perejil lo hay de 2 tipos: de hojas planas y de hojas rizadas.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-007','Salvia Mix','AR','15-20','Murcia Seasons','La Salvia es un pequeño arbusto que llega hasta el metro de alto.Tiene una vida breve, de unos pocos años.En el jardín, como otras aromáticas, queda muy bien en una rocalla o para hacer una bordura perfumada a cada lado de un camino de Salvia. Abona después de cada corte y recorta el arbusto una vez pase la floración.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-008','Thymus Citriodra (Tomillo limón)','AR','15-20','Murcia Seasons','Nombre común o vulgar: Tomillo, Tremoncillo Familia: Labiatae (Labiadas).Origen: Región mediterránea.Arbustillo bajo, de 15 a 40 cm de altura. Las hojas son muy pequeñas, de unos 6 mm de longitud; según la variedad pueden ser verdes, verdes grisáceas, amarillas, o jaspeadas. Las flores aparecen de mediados de primavera hasta bien entrada la época estival y se presentan en racimos terminales que habitualmente son de color violeta o púrpura aunque también pueden ser blancas. Esta planta despide un intenso y típico aroma, que se incrementa con el roce. El tomillo resulta de gran belleza cuando está en flor. El tomillo atrae a avispas y abejas. En jardinería se usa como manchas, para hacer borduras, para aromatizar el ambiente, llenar huecos, cubrir rocas, para jardines en miniatura, etc. Arranque las flores y hojas secas del tallo y añadálos a un popurri, introdúzcalos en saquitos de hierbas o en la almohada.También puede usar las ramas secas con flores para añadir aroma y textura a cestos abiertos.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-009','Thymus Vulgaris','AR','15-20','Murcia Seasons','Nombre común o vulgar: Tomillo, Tremoncillo Familia: Labiatae (Labiadas). Origen: Región mediterránea. Arbustillo bajo, de 15 a 40 cm de altura. Las hojas son muy pequeñas, de unos 6 mm de longitud; según la variedad pueden ser verdes, verdes grisáceas, amarillas, o jaspeadas. Las flores aparecen de mediados de primavera hasta bien entrada la época estival y se presentan en racimos terminales que habitualmente son de color violeta o púrpura aunque también pueden ser blancas. Esta planta despide un intenso y típico aroma, que se incrementa con el roce. El tomillo resulta de gran belleza cuando está en flor. El tomillo atrae a avispas y abejas.\r\n En jardinería se usa como manchas, para hacer borduras, para aromatizar el ambiente, llenar huecos, cubrir rocas, para jardines en miniatura, etc. Arranque las flores y hojas secas del tallo y añadálos a un popurri, introdúzcalos en saquitos de hierbas o en la almohada. También puede usar las ramas secas con flores para añadir aroma y textura a cestos abiertos.',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('AR-010','Santolina Chamaecyparys','AR','15-20','Murcia Seasons','',140,1,0);
INSERT INTO PRODUCTOS2 VALUES ('FR-1','Expositor Cítricos Mix','FR','100-120','Frutales Talavera S.A','',15,7,5);
INSERT INTO PRODUCTOS2 VALUES ('FR-10','Limonero 2 años injerto','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el hombre, en este caso buscando las necesidades del mercado.',15,7,5);
INSERT INTO PRODUCTOS2 VALUES ('FR-100','Nectarina','FR','8/10','Frutales Talavera S.A','Se trata de un árbol derivado por mutación de los melocotoneros comunes, y los únicos caracteres diferenciales son la ausencia de tomentosidad en la piel del fruto. La planta, si se deja crecer libremente, adopta un porte globoso con unas dimensiones medias de 4-6 metros',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-101','Nogal','FR','8/10','Frutales Talavera S.A','',50,13,10);
INSERT INTO PRODUCTOS2 VALUES ('FR-102','Olea-Olivos','FR','8/10','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,18,14);
INSERT INTO PRODUCTOS2 VALUES ('FR-103','Olea-Olivos','FR','10/12','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,25,20);
INSERT INTO PRODUCTOS2 VALUES ('FR-104','Olea-Olivos','FR','12/4','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-105','Olea-Olivos','FR','14/16','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-106','Peral','FR','8/10','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-107','Peral','FR','10/12','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-108','Peral','FR','12/14','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-11','Limonero 30/40','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,100,80);
INSERT INTO PRODUCTOS2 VALUES ('FR-12','Kunquat ','FR','','NaranjasValencianas.com','su nombre científico se origina en honor a un hoticultor escocés que recolectó especímenes en China, (\"Fortunella\"), Robert Fortune (1812-1880), y \"margarita\", del latín margaritus-a-um = perla, en alusión a sus pequeños y brillantes frutos. Se trata de un arbusto o árbol pequeño de 2-3 m de altura, inerme o con escasas espinas.Hojas lanceoladas de 4-8 (-15) cm de longitud, con el ápice redondeado y la base cuneada.Tienen el margen crenulado en su mitad superior, el haz verde brillante y el envés más pálido.Pecíolo ligeramente marginado.Flores perfumadas solitarias o agrupadas en inflorescencias axilares, blancas.El fruto es lo más característico, es el más pequeño de todos los cítricos y el único cuya cáscara se puede comer.Frutos pequeños, con semillas, de corteza fina, dulce, aromática y comestible, y de pulpa naranja amarillenta y ligeramente ácida.Sus frutos son muy pequeños y tienen un carácter principalmente ornamental.',15,21,16);
INSERT INTO PRODUCTOS2 VALUES ('FR-13','Kunquat  EXTRA con FRUTA','FR','150-170','NaranjasValencianas.com','su nombre científico se origina en honor a un hoticultor escocés que recolectó especímenes en China, (\"Fortunella\"), Robert Fortune (1812-1880), y \"margarita\", del latín margaritus-a-um = perla, en alusión a sus pequeños y brillantes frutos. Se trata de un arbusto o árbol pequeño de 2-3 m de altura, inerme o con escasas espinas.Hojas lanceoladas de 4-8 (-15) cm de longitud, con el ápice redondeado y la base cuneada.Tienen el margen crenulado en su mitad superior, el haz verde brillante y el envés más pálido.Pecíolo ligeramente marginado.Flores perfumadas solitarias o agrupadas en inflorescencias axilares, blancas.El fruto es lo más característico, es el más pequeño de todos los cítricos y el único cuya cáscara se puede comer.Frutos pequeños, con semillas, de corteza fina, dulce, aromática y comestible, y de pulpa naranja amarillenta y ligeramente ácida.Sus frutos son muy pequeños y tienen un carácter principalmente ornamental.',15,57,45);
INSERT INTO PRODUCTOS2 VALUES ('FR-14','Calamondin Mini','FR','','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,10,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-15','Calamondin Copa ','FR','','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,25,20);
INSERT INTO PRODUCTOS2 VALUES ('FR-16','Calamondin Copa EXTRA Con FRUTA','FR','100-120','Frutales Talavera S.A','Se trata de un pequeño arbolito de copa densa, con tendencia a la verticalidad, inerme o con cortas espinas. Sus hojas son pequeñas, elípticas de 5-10 cm de longitud, con los pecíolos estrechamente alados.Posee 1 o 2 flores en situación axilar, al final de las ramillas.Sus frutos son muy pequeños (3-3,5 cm de diámetro), con pocas semillas, esféricos u ovales, con la zona apical aplanada; corteza de color naranja-rojizo, muy fina y fácilmente separable de la pulpa, que es dulce, ácida y comestible..',15,45,36);
INSERT INTO PRODUCTOS2 VALUES ('FR-17','Rosal bajo 1Âª -En maceta-inicio brotación','FR','','Frutales Talavera S.A','',15,2,1);
INSERT INTO PRODUCTOS2 VALUES ('FR-18','ROSAL TREPADOR','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS2 VALUES ('FR-19','Camelia Blanco, Chrysler Rojo, Soraya Naranja, ','FR','','NaranjasValencianas.com','',350,4,3);
INSERT INTO PRODUCTOS2 VALUES ('FR-2','Naranjo -Plantón joven 1 año injerto','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,6,4);
INSERT INTO PRODUCTOS2 VALUES ('FR-20','Landora Amarillo, Rose Gaujard bicolor blanco-rojo','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS2 VALUES ('FR-21','Kordes Perfect bicolor rojo-amarillo, Roundelay rojo fuerte','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS2 VALUES ('FR-22','Pitimini rojo','FR','','Frutales Talavera S.A','',350,4,3);
INSERT INTO PRODUCTOS2 VALUES ('FR-23','Rosal copa ','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-24','Albaricoquero Corbato','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-25','Albaricoquero Moniqui','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-26','Albaricoquero Kurrot','FR','','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-27','Cerezo Burlat','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-28','Cerezo Picota','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-29','Cerezo Napoleón','FR','','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-3','Naranjo 2 años injerto','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,7,5);
INSERT INTO PRODUCTOS2 VALUES ('FR-30','Ciruelo R. Claudia Verde   ','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-31','Ciruelo Santa Rosa','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-32','Ciruelo Golden Japan','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-33','Ciruelo Friar','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-34','Ciruelo Reina C. De Ollins','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-35','Ciruelo Claudia Negra','FR','','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-36','Granado Mollar de Elche','FR','','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-37','Higuera Napolitana','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-38','Higuera Verdal','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-39','Higuera Breva','FR','','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-4','Naranjo calibre 8/10','FR','','NaranjasValencianas.com','El naranjo es un árbol pequeño, que no supera los 3-5 metros de altura, con una copa compacta, cónica, transformada en esérica gracias a la poda. Su tronco es de color gris y liso, y las hojas son perennes, coriáceas, de un verde intenso y brillante, con forma oval o elíptico-lanceolada. Poseen, en el caso del naranjo amargo, un típico peciolo alado en forma de Â‘corazónÂ’, que en el naranjo dulce es más estrecho y menos patente.',15,29,23);
INSERT INTO PRODUCTOS2 VALUES ('FR-40','Manzano Starking Delicious','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-41','Manzano Reineta','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-42','Manzano Golden Delicious','FR','','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-43','Membrillero Gigante de Wranja','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-44','Melocotonero Spring Crest','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-45','Melocotonero Amarillo de Agosto','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-46','Melocotonero Federica','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-47','Melocotonero Paraguayo','FR','','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-48','Nogal Común','FR','','Frutales Talavera S.A','',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-49','Parra Uva de Mesa','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-5','Mandarino -Plantón joven','FR','','Frutales Talavera S.A','',15,6,4);
INSERT INTO PRODUCTOS2 VALUES ('FR-50','Peral Castell','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-51','Peral Williams','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-52','Peral Conference','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-53','Peral Blanq. de Aranjuez','FR','','Frutales Talavera S.A','Árbol piramidal, redondeado en su juventud, luego oval, que llega hasta 20 metros de altura y por término medio vive 65 años.Tronco alto, grueso, de corteza agrietada, gris, de la cual se destacan con frecuencia placas lenticulares.Las ramas se insertan formando ángulo agudo con el tronco (45º), de corteza lisa, primero verde y luego gris-violácea, con numerosas lenticelas.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-54','Níspero Tanaca','FR','','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-55','Olivo Cipresino','FR','','Frutales Talavera S.A','Existen dos hipótesis sobre el origen del olivo, una que postula que proviene de las costas de Siria, Líbano e Israel y otra que considera que lo considera originario de Asia menor. La llegada a Europa probablemente tuvo lugar de mano de los Fenicios, en transito por Chipre, Creta, e Islas del Mar Egeo, pasando a Grecia y más tarde a Italia. Los primeros indicios de la presencia del olivo en las costas mediterráneas españolas coinciden con el dominio romano, aunque fueron posteriormente los árabes los que impulsaron su cultivo en Andalucía, convirtiendo a España en el primer país productor de aceite de oliva a nivel mundial.',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-56','Nectarina','FR','','Frutales Talavera S.A','',400,8,6);
INSERT INTO PRODUCTOS2 VALUES ('FR-57','Kaki Rojo Brillante','FR','','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',400,9,7);
INSERT INTO PRODUCTOS2 VALUES ('FR-58','Albaricoquero','FR','8/10','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-59','Albaricoquero','FR','10/12','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-6','Mandarino 2 años injerto','FR','','Frutales Talavera S.A','',15,7,5);
INSERT INTO PRODUCTOS2 VALUES ('FR-60','Albaricoquero','FR','12/14','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-61','Albaricoquero','FR','14/16','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-62','Albaricoquero','FR','16/18','Melocotones de Cieza S.A.','árbol que puede pasar de los 6 m de altura, en la región mediterránea con ramas formando una copa redondeada. La corteza del tronco es pardo-violácea, agrietada; las ramas son rojizas y extendidas cuando jóvenes y las ramas secundarias son cortas, divergentes y escasas. Las yemas latentes son frecuentes especialmente sobre las ramas viejas.',200,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-63','Cerezo','FR','8/10','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',300,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-64','Cerezo','FR','10/12','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',15,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-65','Cerezo','FR','12/14','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',200,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-66','Cerezo','FR','14/16','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-67','Cerezo','FR','16/18','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-68','Cerezo','FR','18/20','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,80,64);
INSERT INTO PRODUCTOS2 VALUES ('FR-69','Cerezo','FR','20/25','Jerte Distribuciones S.L.','Las principales especies de cerezo cultivadas en el mundo son el cerezo dulce (Prunus avium), el guindo (P. cerasus) y el cerezo \"Duke\", híbrido de los anteriores. Ambas especies son naturales del sureste de Europa y oeste de Asia. El cerezo dulce tuvo su origen probablemente en el mar Negro y en el mar Caspio, difundiéndose después hacia Europa y Asia, llevado por los pájaros y las migraciones humanas. Fue uno de los frutales más apreciados por los griegos y con el Imperio Romano se extendió a regiones muy diversas. En la actualidad, el cerezo se encuentra difundido por numerosas regiones y países del mundo con clima templado',50,91,72);
INSERT INTO PRODUCTOS2 VALUES ('FR-7','Mandarino calibre 8/10','FR','','Frutales Talavera S.A','',15,29,23);
INSERT INTO PRODUCTOS2 VALUES ('FR-70','Ciruelo','FR','8/10','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-71','Ciruelo','FR','10/12','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-72','Ciruelo','FR','12/14','Frutales Talavera S.A','árbol de tamaño mediano que alcanza una altura máxima de 5-6 m. Tronco de corteza pardo-azulada, brillante, lisa o agrietada longitudinalmente. Produce ramas alternas, pequeñas, delgadas, unas veces lisas, glabras y otras pubescentes y vellosas',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-73','Granado','FR','8/10','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,13,10);
INSERT INTO PRODUCTOS2 VALUES ('FR-74','Granado','FR','10/12','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-75','Granado','FR','12/14','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-76','Granado','FR','14/16','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-77','Granado','FR','16/18','Frutales Talavera S.A','pequeño árbol caducifolio, a veces con porte arbustivo, de 3 a 6 m de altura, con el tronco retorcido. Madera dura y corteza escamosa de color grisáceo. Las ramitas jóvenes son más o menos cuadrangulares o angostas y de cuatro alas, posteriormente se vuelven redondas con corteza de color café grisáceo, la mayoría de las ramas, pero especialmente las pequeñas ramitas axilares, son en forma de espina o terminan en una espina aguda; la copa es extendida.',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-78','Higuera','FR','8/10','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,15,12);
INSERT INTO PRODUCTOS2 VALUES ('FR-79','Higuera','FR','10/12','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-8','Limonero -Plantón joven','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,6,4);
INSERT INTO PRODUCTOS2 VALUES ('FR-80','Higuera','FR','12/14','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-81','Higuera','FR','14/16','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-82','Higuera','FR','16/18','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-83','Higuera','FR','18/20','Frutales Talavera S.A','La higuera (Ficus carica L.) es un árbol típico de secano en los países mediterráneos. Su rusticidad y su fácil multiplicación hacen de la higuera un frutal muy apropiado para el cultivo extensivo.. Siempre ha sido considerado como árbol que no requiere cuidado alguno una vez plantado y arraigado, limitándose el hombre a recoger de él los frutos cuando maduran, unos para consumo en fresco y otros para conserva. Las únicas higueras con cuidados culturales esmerados, en muchas comarcas, son las brevales, por el interés económico de su primera cosecha, la de brevas.',50,80,64);
INSERT INTO PRODUCTOS2 VALUES ('FR-84','Kaki','FR','8/10','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',50,13,10);
INSERT INTO PRODUCTOS2 VALUES ('FR-85','Kaki','FR','16/18','NaranjasValencianas.com','De crecimiento algo lento los primeros años, llega a alcanzar hasta doce metros de altura o más, aunque en cultivo se prefiere algo más bajo (5-6). Tronco corto y copa extendida. Ramifica muy poco debido a la dominancia apical. Porte más o menos piramidal, aunque con la edad se hace más globoso.',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-86','Manzano','FR','8/10','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-87','Manzano','FR','10/12','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-88','Manzano','FR','12/14','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-89','Manzano','FR','14/16','Frutales Talavera S.A','alcanza como máximo 10 m. de altura y tiene una copa globosa. Tronco derecho que normalmente alcanza de 2 a 2,5 m. de altura, con corteza cubierta de lenticelas, lisa, adherida, de color ceniciento verdoso sobre los ramos y escamosa y gris parda sobre las partes viejas del árbol. Tiene una vida de unos 60-80 años. Las ramas se insertan en ángulo abierto sobre el tallo, de color verde oscuro, a veces tendiendo a negruzco o violáceo. Los brotes jóvenes terminan con frecuencia en una espina',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-9','Limonero calibre 8/10','FR','','NaranjasValencianas.com','El limonero, pertenece al grupo de los cítricos, teniendo su origen hace unos 20 millones de años en el sudeste asiático. Fue introducido por los árabes en el área mediterránea entre los años 1.000 a 1.200, habiendo experimentando numerosas modificaciones debidas tanto a la selección natural mediante hibridaciones espontáneas como a las producidas por el',15,29,23);
INSERT INTO PRODUCTOS2 VALUES ('FR-90','Níspero','FR','16/18','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',50,70,56);
INSERT INTO PRODUCTOS2 VALUES ('FR-91','Níspero','FR','18/20','Frutales Talavera S.A','Aunque originario del Sudeste de China, el níspero llegó a Europa procedente de Japón en el siglo XVIII como árbol ornamental. En el siglo XIX se inició el consumo de los frutos en toda el área mediterránea, donde se adaptó muy bien a las zonas de cultivo de los cítricos.El cultivo intensivo comenzó a desarrollarse a finales de los años 60 y principios de los 70, cuando comenzaron a implantarse las variedades y técnicas de cultivo actualmente utilizadas.',50,80,64);
INSERT INTO PRODUCTOS2 VALUES ('FR-92','Melocotonero','FR','8/10','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-93','Melocotonero','FR','10/12','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-94','Melocotonero','FR','12/14','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-95','Melocotonero','FR','14/16','Melocotones de Cieza S.A.','Árbol caducifolio de porte bajo con corteza lisa, de color ceniciento. Sus hojas son alargadas con el margen ligeramente aserrado, de color verde brillante, algo más claras por el envés. El melocotonero está muy arraigado en la cultura asiática.\r\nEn Japón, el noble heroe Momotaro, una especie de Cid japonés, nació del interior de un enorme melocotón que flotaba río abajo.\r\nEn China se piensa que comer melocotón confiere longevidad al ser humano, ya que formaba parte de la dieta de sus dioses inmortales.',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('FR-96','Membrillero','FR','8/10','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('FR-97','Membrillero','FR','10/12','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,22,17);
INSERT INTO PRODUCTOS2 VALUES ('FR-98','Membrillero','FR','12/14','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,32,25);
INSERT INTO PRODUCTOS2 VALUES ('FR-99','Membrillero','FR','14/16','Frutales Talavera S.A','arbolito caducifolio de 4-6 m de altura con el tronco tortuoso y la corteza lisa, grisácea, que se desprende en escamas con la edad. Copa irregular, con ramas inermes, flexuosas, parduzcas, punteadas. Ramillas jóvenes tomentosas',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('OR-001','Arbustos Mix Maceta','OR','40-60','Valencia Garden Service','',25,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-100','Mimosa Injerto CLASICA Dealbata ','OR','100-110','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,12,9);
INSERT INTO PRODUCTOS2 VALUES ('OR-101','Expositor Mimosa Semilla Mix','OR','170-200','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-102','Mimosa Semilla Bayleyana  ','OR','170-200','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-103','Mimosa Semilla Bayleyana   ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-104','Mimosa Semilla Cyanophylla    ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-105','Mimosa Semilla Espectabilis  ','OR','160-170','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-106','Mimosa Semilla Longifolia   ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-107','Mimosa Semilla Floribunda 4 estaciones','OR','120-140','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-108','Abelia Floribunda','OR','35-45','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-109','Callistemom (Mix)','OR','35-45','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',100,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-110','Callistemom (Mix)','OR','40-60','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',100,2,1);
INSERT INTO PRODUCTOS2 VALUES ('OR-111','Corylus Avellana \"Contorta\"','OR','35-45','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-112','Escallonia (Mix)','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-113','Evonimus Emerald Gayeti','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-114','Evonimus Pulchellus','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-115','Forsytia Intermedia \"Lynwood\"','OR','35-45','Viveros EL OASIS','',120,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-116','Hibiscus Syriacus  \"Diana\" -Blanco Puro','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-117','Hibiscus Syriacus  \"Helene\" -Blanco-C.rojo','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-118','Hibiscus Syriacus \"Pink Giant\" Rosa','OR','35-45','Viveros EL OASIS','Por su capacidad de soportar podas, pueden ser fácilmente moldeadas como bonsái en el transcurso de pocos años. Flores de muchos colores según la variedad, desde el blanco puro al rojo intenso, del amarillo al anaranjado. La flor apenas dura 1 día, pero continuamente aparecen nuevas y la floración se prolonga durante todo el periodo de crecimiento vegetativo.',120,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-119','Laurus Nobilis Arbusto - Ramificado Bajo','OR','40-50','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-120','Lonicera Nitida ','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-121','Lonicera Nitida \"Maigrum\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-122','Lonicera Pileata','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-123','Philadelphus \"Virginal\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-124','Prunus pisardii  ','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-125','Viburnum Tinus \"Eve Price\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-126','Weigelia \"Bristol Ruby\"','OR','35-45','Viveros EL OASIS','',120,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-127','Camelia japonica','OR','40-60','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-128','Camelia japonica ejemplar','OR','200-250','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,98,78);
INSERT INTO PRODUCTOS2 VALUES ('OR-129','Camelia japonica ejemplar','OR','250-300','Viveros EL OASIS','Arbusto excepcional por su floración otoñal, invernal o primaveral. Flores: Las flores son solitarias, aparecen en el ápice de cada rama, y son con una corola simple o doble, y comprendiendo varios colores. Suelen medir unos 7-12 cm de diÃ metro y tienen 5 sépalos y 5 pétalos. Estambres numerosos unidos en la mitad o en 2/3 de su longitud.',50,110,88);
INSERT INTO PRODUCTOS2 VALUES ('OR-130','Callistemom COPA','OR','110/120','Viveros EL OASIS','Limpitatubos. arbolito de 6-7 m de altura. Ramas flexibles y colgantes (de ahí lo de \"llorón\")..',50,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-131','Leptospermum formado PIRAMIDE','OR','80-100','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-132','Leptospermum COPA','OR','110/120','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-133','Nerium oleander-CALIDAD \"GARDEN\"','OR','40-45','Viveros EL OASIS','',50,2,1);
INSERT INTO PRODUCTOS2 VALUES ('OR-134','Nerium Oleander Arbusto GRANDE','OR','160-200','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS2 VALUES ('OR-135','Nerium oleander COPA  Calibre 6/8','OR','50-60','Viveros EL OASIS','',100,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-136','Nerium oleander ARBOL Calibre 8/10','OR','225-250','Viveros EL OASIS','',100,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-137','ROSAL TREPADOR','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-138','Camelia Blanco, Chrysler Rojo, Soraya Naranja, ','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-139','Landora Amarillo, Rose Gaujard bicolor blanco-rojo','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-140','Kordes Perfect bicolor rojo-amarillo, Roundelay rojo fuerte','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-141','Pitimini rojo','OR','','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-142','Solanum Jazminoide','OR','150-160','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS2 VALUES ('OR-143','Wisteria Sinensis  azul, rosa, blanca','OR','','Viveros EL OASIS','',100,9,7);
INSERT INTO PRODUCTOS2 VALUES ('OR-144','Wisteria Sinensis INJERTADAS DECÃ“','OR','140-150','Viveros EL OASIS','',100,12,9);
INSERT INTO PRODUCTOS2 VALUES ('OR-145','Bougamvillea Sanderiana Tutor','OR','80-100','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS2 VALUES ('OR-146','Bougamvillea Sanderiana Tutor','OR','125-150','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-147','Bougamvillea Sanderiana Tutor','OR','180-200','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-148','Bougamvillea Sanderiana Espaldera','OR','45-50','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-149','Bougamvillea Sanderiana Espaldera','OR','140-150','Viveros EL OASIS','',100,17,13);
INSERT INTO PRODUCTOS2 VALUES ('OR-150','Bougamvillea roja, naranja','OR','110-130','Viveros EL OASIS','',100,2,1);
INSERT INTO PRODUCTOS2 VALUES ('OR-151','Bougamvillea Sanderiana, 3 tut. piramide','OR','','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-152','Expositor Árboles clima continental','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-153','Expositor Árboles clima mediterráneo','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-154','Expositor Árboles borde del mar','OR','170-200','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-155','Acer Negundo  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-156','Acer platanoides  ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-157','Acer Pseudoplatanus ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-158','Brachychiton Acerifolius  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-159','Brachychiton Discolor  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-160','Brachychiton Rupestris','OR','170-200','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-161','Cassia Corimbosa  ','OR','200-225','Viveros EL OASIS','',100,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-162','Cassia Corimbosa ','OR','200-225','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-163','Chitalpa Summer Bells   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-164','Erytrina Kafra','OR','170-180','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-165','Erytrina Kafra','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-166','Eucalyptus Citriodora  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-167','Eucalyptus Ficifolia  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-168','Eucalyptus Ficifolia   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-169','Hibiscus Syriacus  Var. Injertadas 1 Tallo ','OR','170-200','Viveros EL OASIS','',80,12,9);
INSERT INTO PRODUCTOS2 VALUES ('OR-170','Lagunaria Patersonii  ','OR','140-150','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-171','Lagunaria Patersonii   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-172','Lagunaria patersonii  calibre 8/10','OR','200-225','Viveros EL OASIS','',80,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-173','Morus Alba  ','OR','200-225','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-174','Morus Alba  calibre 8/10','OR','200-225','Viveros EL OASIS','',80,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-175','Platanus Acerifolia   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-176','Prunus pisardii  ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-177','Robinia Pseudoacacia Casque Rouge   ','OR','200-225','Viveros EL OASIS','',80,15,12);
INSERT INTO PRODUCTOS2 VALUES ('OR-178','Salix Babylonica  Pendula  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-179','Sesbania Punicea   ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-180','Tamarix  Ramosissima Pink Cascade   ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-181','Tamarix  Ramosissima Pink Cascade   ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-182','Tecoma Stands   ','OR','200-225','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-183','Tecoma Stands  ','OR','200-225','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-184','Tipuana Tipu  ','OR','170-200','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-185','Pleioblastus distichus-Bambú enano','OR','15-20','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-186','Sasa palmata ','OR','20-30','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-187','Sasa palmata ','OR','40-45','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-188','Sasa palmata ','OR','50-60','Viveros EL OASIS','',80,25,20);
INSERT INTO PRODUCTOS2 VALUES ('OR-189','Phylostachys aurea','OR','180-200','Viveros EL OASIS','',80,22,17);
INSERT INTO PRODUCTOS2 VALUES ('OR-190','Phylostachys aurea','OR','250-300','Viveros EL OASIS','',80,32,25);
INSERT INTO PRODUCTOS2 VALUES ('OR-191','Phylostachys Bambusa Spectabilis','OR','180-200','Viveros EL OASIS','',80,24,19);
INSERT INTO PRODUCTOS2 VALUES ('OR-192','Phylostachys biseti','OR','160-170','Viveros EL OASIS','',80,22,17);
INSERT INTO PRODUCTOS2 VALUES ('OR-193','Phylostachys biseti','OR','160-180','Viveros EL OASIS','',80,20,16);
INSERT INTO PRODUCTOS2 VALUES ('OR-194','Pseudosasa japonica (Metake)','OR','225-250','Viveros EL OASIS','',80,20,16);
INSERT INTO PRODUCTOS2 VALUES ('OR-195','Pseudosasa japonica (Metake) ','OR','30-40','Viveros EL OASIS','',80,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-196','Cedrus Deodara ','OR','80-100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-197','Cedrus Deodara \"Feeling Blue\" Novedad','OR','rastrero','Viveros EL OASIS','',80,12,9);
INSERT INTO PRODUCTOS2 VALUES ('OR-198','Juniperus chinensis \"Blue Alps\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-199','Juniperus Chinensis Stricta','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-200','Juniperus horizontalis Wiltonii','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-201','Juniperus squamata \"Blue Star\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-202','Juniperus x media Phitzeriana verde','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-203','Pinus Canariensis','OR','80-100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-204','Pinus Halepensis','OR','160-180','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-205','Pinus Pinea -Pino Piñonero','OR','70-80','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-206','Thuja Esmeralda ','OR','80-100','Viveros EL OASIS','',80,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-207','Tuja Occidentalis Woodwardii','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-208','Tuja orientalis \"Aurea nana\"','OR','20-30','Viveros EL OASIS','',80,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-209','Archontophoenix Cunninghamiana','OR','80 - 100','Viveros EL OASIS','',80,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-210','Beucarnea Recurvata','OR','130  - 150','Viveros EL OASIS','',2,39,31);
INSERT INTO PRODUCTOS2 VALUES ('OR-211','Beucarnea Recurvata','OR','180 - 200','Viveros EL OASIS','',5,59,47);
INSERT INTO PRODUCTOS2 VALUES ('OR-212','Bismarckia Nobilis','OR','200 - 220','Viveros EL OASIS','',4,217,173);
INSERT INTO PRODUCTOS2 VALUES ('OR-213','Bismarckia Nobilis','OR','240 - 260','Viveros EL OASIS','',4,266,212);
INSERT INTO PRODUCTOS2 VALUES ('OR-214','Brahea Armata','OR','45 - 60','Viveros EL OASIS','',0,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-215','Brahea Armata','OR','120 - 140','Viveros EL OASIS','',100,112,89);
INSERT INTO PRODUCTOS2 VALUES ('OR-216','Brahea Edulis','OR','80 - 100','Viveros EL OASIS','',100,19,15);
INSERT INTO PRODUCTOS2 VALUES ('OR-217','Brahea Edulis','OR','140 - 160','Viveros EL OASIS','',100,64,51);
INSERT INTO PRODUCTOS2 VALUES ('OR-218','Butia Capitata','OR','70 - 90','Viveros EL OASIS','',100,25,20);
INSERT INTO PRODUCTOS2 VALUES ('OR-219','Butia Capitata','OR','90 - 110','Viveros EL OASIS','',100,29,23);
INSERT INTO PRODUCTOS2 VALUES ('OR-220','Butia Capitata','OR','90 - 120','Viveros EL OASIS','',100,36,28);
INSERT INTO PRODUCTOS2 VALUES ('OR-221','Butia Capitata','OR','85 - 105','Viveros EL OASIS','',100,59,47);
INSERT INTO PRODUCTOS2 VALUES ('OR-222','Butia Capitata','OR','130 - 150','Viveros EL OASIS','',100,87,69);
INSERT INTO PRODUCTOS2 VALUES ('OR-223','Chamaerops Humilis','OR','40 - 45','Viveros EL OASIS','',100,4,3);
INSERT INTO PRODUCTOS2 VALUES ('OR-224','Chamaerops Humilis','OR','50 - 60','Viveros EL OASIS','',100,7,5);
INSERT INTO PRODUCTOS2 VALUES ('OR-225','Chamaerops Humilis','OR','70 - 90','Viveros EL OASIS','',100,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-226','Chamaerops Humilis','OR','115 - 130','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS2 VALUES ('OR-227','Chamaerops Humilis','OR','130 - 150','Viveros EL OASIS','',100,64,51);
INSERT INTO PRODUCTOS2 VALUES ('OR-228','Chamaerops Humilis \"Cerifera\"','OR','70 - 80','Viveros EL OASIS','',100,32,25);
INSERT INTO PRODUCTOS2 VALUES ('OR-229','Chrysalidocarpus Lutescens -ARECA','OR','130 - 150','Viveros EL OASIS','',100,22,17);
INSERT INTO PRODUCTOS2 VALUES ('OR-230','Cordyline Australis -DRACAENA','OR','190 - 210','Viveros EL OASIS','',100,38,30);
INSERT INTO PRODUCTOS2 VALUES ('OR-231','Cycas Revoluta','OR','55 - 65','Viveros EL OASIS','',100,15,12);
INSERT INTO PRODUCTOS2 VALUES ('OR-232','Cycas Revoluta','OR','80 - 90','Viveros EL OASIS','',100,34,27);
INSERT INTO PRODUCTOS2 VALUES ('OR-233','Dracaena Drago','OR','60 - 70','Viveros EL OASIS','',1,13,10);
INSERT INTO PRODUCTOS2 VALUES ('OR-234','Dracaena Drago','OR','130 - 150','Viveros EL OASIS','',2,64,51);
INSERT INTO PRODUCTOS2 VALUES ('OR-235','Dracaena Drago','OR','150 - 175','Viveros EL OASIS','',2,92,73);
INSERT INTO PRODUCTOS2 VALUES ('OR-236','Jubaea Chilensis','OR','','Viveros EL OASIS','',100,49,39);
INSERT INTO PRODUCTOS2 VALUES ('OR-237','Livistonia Australis','OR','100 - 125','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS2 VALUES ('OR-238','Livistonia Decipiens','OR','90 - 110','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS2 VALUES ('OR-239','Livistonia Decipiens','OR','180 - 200','Viveros EL OASIS','',50,49,39);
INSERT INTO PRODUCTOS2 VALUES ('OR-240','Phoenix Canariensis','OR','110 - 130','Viveros EL OASIS','',50,6,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-241','Phoenix Canariensis','OR','180 - 200','Viveros EL OASIS','',50,19,15);
INSERT INTO PRODUCTOS2 VALUES ('OR-242','Rhaphis Excelsa','OR','80 - 100','Viveros EL OASIS','',50,21,16);
INSERT INTO PRODUCTOS2 VALUES ('OR-243','Rhaphis Humilis','OR','150- 170','Viveros EL OASIS','',50,64,51);
INSERT INTO PRODUCTOS2 VALUES ('OR-244','Sabal Minor','OR','60 - 75','Viveros EL OASIS','',50,11,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-245','Sabal Minor','OR','120 - 140','Viveros EL OASIS','',50,34,27);
INSERT INTO PRODUCTOS2 VALUES ('OR-246','Trachycarpus Fortunei','OR','90 - 105','Viveros EL OASIS','',50,18,14);
INSERT INTO PRODUCTOS2 VALUES ('OR-247','Trachycarpus Fortunei','OR','250-300','Viveros EL OASIS','',2,462,369);
INSERT INTO PRODUCTOS2 VALUES ('OR-248','Washingtonia Robusta','OR','60 - 70','Viveros EL OASIS','',15,3,2);
INSERT INTO PRODUCTOS2 VALUES ('OR-249','Washingtonia Robusta','OR','130 - 150','Viveros EL OASIS','',15,5,4);
INSERT INTO PRODUCTOS2 VALUES ('OR-250','Yucca Jewel','OR','80 - 105','Viveros EL OASIS','',15,10,8);
INSERT INTO PRODUCTOS2 VALUES ('OR-251','Zamia Furfuracaea','OR','90 - 110','Viveros EL OASIS','',15,168,134);
INSERT INTO PRODUCTOS2 VALUES ('OR-99','Mimosa DEALBATA Gaulois Astier  ','OR','200-225','Viveros EL OASIS','Acacia dealbata. Nombre común o vulgar: Mimosa fina, Mimosa, Mimosa común, Mimosa plateada, Aromo francés. Familia: Mimosaceae. Origen: Australia, Sureste, (N. G. del Sur y Victoria). Arbol de follaje persistente muy usado en parques por su atractiva floración amarilla hacia fines del invierno. Altura: de 3 a 10 metros generalmente. Crecimiento rápido. Follaje perenne de tonos plateados, muy ornamental. Sus hojas son de textura fina, de color verde y sus flores amarillas que aparecen en racimos grandes. Florece de Enero a Marzo (Hemisferio Norte). Legumbre de 5-9 cm de longitud, recta o ligeramente curvada, con los bordes algo constreñidos entre las semillas, que se disponen en el fruto longitudinalmente...',100,14,11);


-- DETALLE_PEDIDOS2
INSERT INTO DETALLE_PEDIDOS2 VALUES (1,'FR-67',10,70,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (1,'OR-127',40,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (1,'OR-141',25,4,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (1,'OR-241',15,19,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (1,'OR-99',23,14,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'FR-4',3,29,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'FR-40',7,8,7);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'OR-140',50,4,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'OR-141',20,5,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'OR-159',12,6,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'OR-227',67,64,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (2,'OR-247',5,462,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'FR-48',120,9,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'OR-122',32,5,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'OR-123',11,5,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'OR-213',30,266,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'OR-217',15,65,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (3,'OR-218',24,25,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'FR-31',12,8,7);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'FR-34',42,8,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'FR-40',42,9,8);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'OR-152',3,6,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'OR-155',4,6,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'OR-156',17,9,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'OR-157',38,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (4,'OR-222',21,59,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (8,'FR-106',3,11,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (8,'FR-108',1,32,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (8,'FR-11',10,100,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (9,'AR-001',80,1,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (9,'AR-008',450,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (9,'FR-106',80,8,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (9,'FR-69',15,91,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (10,'FR-82',5,70,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (10,'FR-91',30,75,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (10,'OR-234',5,64,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (11,'AR-006',180,1,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (11,'OR-247',80,8,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (12,'AR-009',290,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (13,'11679',5,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (13,'21636',12,14,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (13,'FR-11',5,100,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (14,'FR-100',8,11,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (14,'FR-13',13,57,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (15,'FR-84',4,13,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (15,'OR-101',2,6,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (15,'OR-156',6,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (15,'OR-203',9,10,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (16,'30310',12,12,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (16,'FR-36',10,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (17,'11679',5,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (17,'22225',5,12,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (17,'FR-37',5,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (17,'FR-64',5,22,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (17,'OR-136',5,18,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (18,'22225',4,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (18,'FR-22',2,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (18,'OR-159',10,6,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (19,'30310',9,12,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (19,'FR-23',6,8,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (19,'FR-75',1,32,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (19,'FR-84',5,13,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (19,'OR-208',20,4,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (20,'11679',14,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (20,'30310',8,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (21,'21636',5,14,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (21,'FR-18',22,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (21,'FR-53',3,8,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (22,'OR-240',1,6,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (23,'AR-002',110,1,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (23,'FR-107',50,22,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (23,'FR-85',4,70,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (23,'OR-249',30,5,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (24,'22225',3,15,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (24,'FR-1',4,7,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (24,'FR-23',2,7,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (24,'OR-241',10,20,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (25,'FR-77',15,69,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (25,'FR-9',4,30,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (25,'FR-94',10,30,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (26,'FR-15',9,25,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (26,'OR-188',4,25,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (26,'OR-218',14,25,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (27,'OR-101',22,6,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (27,'OR-102',22,6,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (27,'OR-186',40,6,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (28,'FR-11',8,99,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (28,'OR-213',3,266,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (28,'OR-247',1,462,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (29,'FR-82',4,70,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (29,'FR-9',4,28,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (29,'FR-94',20,31,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (29,'OR-129',2,111,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (29,'OR-160',10,9,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'AR-004',10,1,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'FR-108',2,32,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'FR-12',2,19,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'FR-72',4,31,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'FR-89',10,45,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (30,'OR-120',5,5,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (31,'AR-009',25,2,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (31,'FR-102',1,20,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (31,'FR-4',6,29,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (32,'11679',1,14,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (32,'21636',4,15,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (32,'22225',1,15,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (32,'OR-128',29,100,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (32,'OR-193',5,20,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (33,'FR-17',423,2,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (33,'FR-29',120,8,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (33,'OR-214',212,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (33,'OR-247',150,462,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (34,'FR-3',56,7,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (34,'FR-7',12,29,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (34,'OR-172',20,18,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (34,'OR-174',24,18,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (35,'21636',12,14,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (35,'FR-47',55,8,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (35,'OR-165',3,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (35,'OR-181',36,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (35,'OR-225',72,10,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (36,'30310',4,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (36,'FR-1',2,7,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (36,'OR-147',6,7,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (36,'OR-203',1,12,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (36,'OR-99',15,13,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (37,'FR-105',4,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (37,'FR-57',203,8,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (37,'OR-176',38,10,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (38,'11679',5,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (38,'21636',2,14,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (39,'22225',3,12,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (39,'30310',6,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (40,'AR-001',4,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (40,'AR-002',8,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (41,'AR-003',5,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (41,'AR-004',5,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (42,'AR-005',3,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (42,'AR-006',1,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (43,'AR-007',9,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (44,'AR-008',5,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (45,'AR-009',6,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (45,'AR-010',4,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (46,'FR-1',4,7,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (46,'FR-10',8,7,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (47,'FR-100',9,11,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (47,'FR-101',5,13,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (48,'FR-102',1,18,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (48,'FR-103',1,25,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (48,'OR-234',50,64,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (48,'OR-236',45,49,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (48,'OR-237',50,19,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (49,'OR-204',50,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (49,'OR-205',10,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (49,'OR-206',5,5,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (50,'OR-225',12,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (50,'OR-226',15,38,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (50,'OR-227',44,64,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (51,'OR-209',50,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (51,'OR-210',80,39,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (51,'OR-211',70,59,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (53,'FR-2',1,7,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (53,'FR-85',1,70,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (53,'FR-86',2,11,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (53,'OR-116',6,7,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'11679',3,14,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'FR-100',45,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'FR-18',5,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'FR-79',3,22,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'OR-116',8,7,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'OR-123',3,5,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (54,'OR-168',2,10,7);
INSERT INTO DETALLE_PEDIDOS2 VALUES (55,'OR-115',9,7,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (55,'OR-213',2,266,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (55,'OR-227',6,64,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (55,'OR-243',2,64,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (55,'OR-247',1,462,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-129',1,115,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-130',10,18,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-179',1,6,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-196',3,10,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-207',4,4,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (56,'OR-250',3,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (57,'FR-69',6,91,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (57,'FR-81',3,49,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (57,'FR-84',2,13,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (57,'FR-94',6,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (58,'OR-102',65,18,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (58,'OR-139',80,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (58,'OR-172',69,15,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (58,'OR-177',150,15,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (74,'FR-67',15,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (74,'OR-227',34,64,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (74,'OR-247',42,8,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (75,'AR-006',60,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (75,'FR-87',24,22,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (75,'OR-157',46,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (76,'AR-009',250,1,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (76,'FR-79',40,22,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (76,'FR-87',24,22,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (76,'FR-94',35,9,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (76,'OR-196',25,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (77,'22225',34,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (77,'30310',15,12,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (78,'FR-53',25,8,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (78,'FR-85',56,70,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (78,'OR-157',42,10,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (78,'OR-208',30,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (79,'OR-240',50,6,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (80,'FR-11',40,100,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (80,'FR-36',47,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (80,'OR-136',75,18,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (81,'OR-208',30,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (82,'OR-227',34,64,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (83,'OR-208',30,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'FR-108',3,32,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'FR-3',15,7,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'FR-42',12,8,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'FR-66',5,49,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'FR-87',4,22,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (89,'OR-157',8,10,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (90,'AR-001',19,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (90,'AR-002',10,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (90,'AR-003',12,1,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (91,'FR-100',52,11,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (91,'FR-101',14,13,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (91,'FR-102',35,18,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (92,'FR-108',12,23,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (92,'FR-11',20,100,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (92,'FR-12',30,21,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (93,'FR-54',25,9,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (93,'FR-58',51,11,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (93,'FR-60',3,32,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (94,'11679',12,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (94,'FR-11',33,100,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (94,'FR-4',79,29,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (95,'FR-10',9,7,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (95,'FR-75',6,32,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (95,'FR-82',5,70,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (96,'FR-43',6,8,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (96,'FR-6',16,7,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (96,'FR-71',10,22,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (96,'FR-90',4,70,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (97,'FR-41',12,8,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (97,'FR-54',14,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (97,'OR-156',10,10,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (98,'FR-33',14,8,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (98,'FR-56',16,8,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (98,'FR-60',8,32,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (98,'FR-8',18,6,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (98,'FR-85',6,70,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (99,'OR-157',15,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (99,'OR-227',30,64,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (100,'FR-87',20,22,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (100,'FR-94',40,9,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (101,'AR-006',50,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (101,'AR-009',159,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (102,'22225',32,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (102,'30310',23,12,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (103,'FR-53',12,8,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (103,'OR-208',52,4,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (104,'FR-85',9,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (104,'OR-157',113,10,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (105,'OR-227',21,64,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (105,'OR-240',27,6,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (106,'AR-009',231,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (106,'OR-136',47,18,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (107,'30310',143,12,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (107,'FR-11',15,100,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (108,'FR-53',53,8,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (108,'OR-208',59,4,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'FR-22',8,4,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'FR-36',12,9,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'FR-45',14,8,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'OR-104',20,10,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'OR-119',10,5,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'OR-125',3,5,6);
INSERT INTO DETALLE_PEDIDOS2 VALUES (109,'OR-130',2,18,7);
INSERT INTO DETALLE_PEDIDOS2 VALUES (110,'AR-010',6,1,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (110,'FR-1',14,7,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (110,'FR-16',1,45,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (116,'21636',5,14,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (116,'AR-001',32,1,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (116,'AR-005',18,1,5);
INSERT INTO DETALLE_PEDIDOS2 VALUES (116,'FR-33',13,8,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (116,'OR-200',10,4,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (117,'FR-78',2,15,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (117,'FR-80',1,32,3);
INSERT INTO DETALLE_PEDIDOS2 VALUES (117,'OR-146',17,4,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (117,'OR-179',4,6,4);
INSERT INTO DETALLE_PEDIDOS2 VALUES (128,'AR-004',15,1,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (128,'OR-150',18,2,2);
INSERT INTO DETALLE_PEDIDOS2 VALUES (52,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (59,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (60,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (61,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (62,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (63,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (64,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (65,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (66,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (67,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (68,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (111,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (112,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (113,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (114,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (115,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (118,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (119,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (120,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (121,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (122,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (123,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (124,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (125,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (126,'FR-67',10,70,1);
INSERT INTO DETALLE_PEDIDOS2 VALUES (127,'FR-67',10,70,1);

-- DETALLE_PEDIDOS
INSERT INTO DETALLE_PEDIDOS
  SELECT det2.codPedido, p1.codProducto,
		 det2.cantidad, det2.precio_unidad,
		 det2.numero_linea
    FROM DETALLE_PEDIDOS2 det2,
		 PRODUCTOS p1,
		 PRODUCTOS2 p2
   WHERE p1.nombre = p2.nombre
   AND p1.precio_venta = p2.precio_venta
   AND p1.proveedor = p2.proveedor
     AND det2.codProducto = p2.codProducto
  ORDER BY det2.codPedido, det2.numero_linea;
 
DROP TABLE DETALLE_PEDIDOS2

DROP TABLE PRODUCTOS2


-- FORMA_PAGO
INSERT INTO FORMA_PAGO VALUES ('T', 'TRANSFERENCIA');
INSERT INTO FORMA_PAGO VALUES ('C', 'CHEQUE');
INSERT INTO FORMA_PAGO VALUES ('P', 'PAYPAL');
INSERT INTO FORMA_PAGO VALUES ('B', 'BIZUM');


TRUNCATE TABLE PAGOS

-- PAGOS
DECLARE @codPedido INT = 1, @maxPedidos INT = (SELECT MAX(codPedido) FROM PEDIDOS), @contador INT = 1

WHILE @codPedido <= @maxPedidos
BEGIN
	DECLARE @codEstado CHAR(1) = NULL, @codCliente INT, @fechaPedido DATE, @importe DECIMAL(9,2)

	SELECT @codEstado = codEstado,
		   @codCliente = codCliente,
		   @fechaPedido = fecha_pedido
	  FROM PEDIDOS
	 WHERE codPedido = @codPedido;

	IF @codEstado IS NULL
	BEGIN
		SET @codPedido += 1
		CONTINUE
	END

	IF @codEstado = 'E' OR (@codEstado = 'P' AND (@codCliente BETWEEN 13 AND 30 OR @codCliente = 1))
	BEGIN
		SELECT @importe = ISNULL(SUM(cantidad * precio_unidad), 0)
		  FROM DETALLE_PEDIDOS
		 WHERE codPedido = @codPedido;

		DECLARE @formaPago CHAR(1) = (SELECT TOP(1) codFormaPago FROM FORMA_PAGO ORDER BY NEWID())

		INSERT INTO PAGOS
		VALUES (@codCliente, CONCAT('ak-std-',FORMAT(@contador, '00000000')), @fechaPedido, @importe, @formaPago, @codPedido);

		SET @contador += 1
	END

	-- Se actualizan algunos pedidos a NULL
	-- Hace que haya pagos que no están asociados a ningún pedido
	-- La idea es buscar a partir de los pedidos del cliente, la fecha y el importe y asociarlos a posteriori
	UPDATE PAGOS
	   SET codPedido = NULL
	 WHERE codPedido IN (18, 93, 118, 124)
	
	SET @codPedido += 1
END

/*
PRINT CONCAT('CODERROR: ', ERROR_NUMBER(),
					 ', DESCRIPCION: ', ERROR_MESSAGE(),
				  	 ', LINEA: ', ERROR_LINE(),
					 ', PROCEDURE: ', ERROR_PROCEDURE())
@@TRANCOUNT
@@ROWCOUNT
SCOPE_IDENTITY
*/