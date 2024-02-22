/*
---------------------------------------
-- CREACIÓN | MODIFICACIÓN DE TABLAS --
---------------------------------------
Crea las siguientes tablas:

STREAMERS (codStreamer, nombre, apellidos, pais, edad)
PK: codStreamer (NO se incrementa automáticamente)

TEMATICAS (codTematica, nombre)
PK: codTematica (se incrementa automáticamente)

STREAMERS_TEMATICAS (codStreamer, codTematica, idioma, medio, milesSeguidores)
PK: codStreamer, codTematica
FK: codStreamer  STREAMERS
FK: codTematica  TEMATICAS
*/

CREATE DATABASE REPASO
USE REPASO
GO
CREATE TABLE STREAMERS (
    codStreamer INT,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100),
    pais CHAR(2),
    edad TINYINT NOT NULL

    CONSTRAINT PK_STREAMERS PRIMARY KEY (codStreamer)
    CONSTRAINT CH_STREAMERS_edad CHECK (edad BETWEEN 1 AND 100)
)
GO
CREATE INDEX streamers_name_index
ON STREAMERS (nombre)
GO
CREATE TABLE TEMATICAS (
    codTematica INT IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL

    CONSTRAINT PK_TEMATICAS PRIMARY KEY (codTematica)
)
GO
CREATE INDEX tematica_name_index
ON TEMATICAS (nombre)
GO
CREATE TABLE STREAMERS_TEMATICAS (
    codStreamer INT,
    codTematica INT,
    idioma VARCHAR(100) NOT NULL,
    medio VARCHAR(100) NOT NULL,
    milesSeguidores INT NOT NULL

    CONSTRAINT PK_STREAMERS_TEMATICAS PRIMARY KEY (codStreamer,codTematica),
    CONSTRAINT FK_STREAMERS_TEMATICAS_STREAMERS FOREIGN KEY (codStreamer) 
               REFERENCES STREAMERS(codStreamer),
    CONSTRAINT FK_STREAMERS_TEMATICAS_TEMATICAS FOREIGN KEY (codTematica)
               REFERENCES TEMATICAS(codTematica)
)
GO
CREATE INDEX streamers_tematicas_medio_index
ON STREAMERS_TEMATICAS (codStreamer, medio, milesSeguidores)
GO

/*
-----------------------
-- GESTIÓN DE TABLAS --
-----------------------
Inserta los siguientes STREAMERS:   Inserta los siguientes TEMAS:    Inserta las siguientes TEMATICAS de STREAMERS:
    - Ibai Llanos de España             - Informática                   [STREAMER]           [TEMATICA]     [idioma]   [medio]	  [milesSeguidores]
    - AuronPlay de España               - Tecnología en general         Ibai Llanos	         Variado	      Español	   Twitch     12800
    - Nate Gentile de España            - Gaming                        AuronPlay	           Gaming	        Español    YouTube    29200
    - Linus Tech Tips de Canadá         - Variado                       AuronPlay	           Variado	      Español	   Twitch     14900
    - DYI Perks sin ningún país         - Bricolaje                     Nate Gentile         Informática    Español    YouTube	  2450
    - Alexandre Chappel de Noruega      - Viajes                        Linus Tech Tips      Informática	  Inglés	   YouTube	  15200
    - Tekendo de España                 - Humor                         DYI Perks	           Bricolaje	    Inglés	   YouTube	  4140
    - Caddac Tech de ningún país                                        Alexandre Chappel    Bricolaje	    Inglés	   YouTube	  370
                                                                        Caddac Tech	         Informática	  Inglés	   YouTube    3
*/

GO
INSERT INTO STREAMERS (codStreamer, nombre, apellidos, pais, edad)
VALUES (1, 'Ibai', 'Llanos', 'ES', 28),
       (2, 'AuronPlay', NULL, 'ES', 35),
       (3, 'Nate', 'Gentile', 'ES', 33),
       (4, 'Linus','Tech Tips', 'CA', 37),
       (5, 'DYI Perks', NULL, NULL, 37),
       (6, 'Alexandre', 'Chappel', 'NO', 37),
       (7, 'Tekendo', NULL, 'ES', 26),
       (8, 'Caddac Tech', NULL, NULL, 40),
       (9, 'Abuelo', NULL, NULL, 40)
GO
INSERT INTO TEMATICAS (nombre)
VALUES ('Informática'),
       ('Tecnología en general'),
       ('Gaming'),
       ('Variado'),
       ('Bricolaje'),
       ('Viajes'),
       ('Humor')
GO
INSERT INTO STREAMERS_TEMATICAS (codStreamer, codTematica, idioma, medio, milesSeguidores)
VALUES (1, 4, 'Español', 'Twitch', 12800),
       (2, 3, 'Español', 'YouTube', 29200),
       (2, 4, 'Español', 'Twitch', 14900),
       (3, 1, 'Español', 'YouTube', 2450),
       (4, 1, 'Inglés', 'YouTube', 15200),
       (5, 5, 'Inglés', 'YouTube', 4140),
       (6, 5, 'Inglés', 'YouTube', 370),
       (8, 1, 'Inglés', 'YouTube', 3)

-----------------
--  CONSULTAS  --
-----------------

-- 01. Nombre de las temáticas que tenemos almacenadas, ordenadas alfabéticamente.

SELECT nombre
  FROM TEMATICAS
 ORDER BY nombre ASC

-- 02. Cantidad de streamers cuyo país es "España".

SELECT COUNT(codStreamer)
  FROM STREAMERS
 WHERE LOWER(pais) = 'es'

-- 03, 04, 05. Nombres de streamers cuya segunda letra no sea una "B" (quizá en minúsculas), de 3 formas distintas.

SELECT nombre
  FROM STREAMERS
 WHERE LOWER(SUBSTRING(nombre,2,1)) <> ('b')

SELECT nombre
  FROM STREAMERS
 WHERE RIGHT(LEFT(nombre, 2),1) NOT IN ('b', 'B')

SELECT nombre
  FROM STREAMERS
 WHERE LOWER(nombre) NOT LIKE ('%b%')


-- 06. Media de suscriptores para los canales cuyo idioma es "Español".

SELECT AVG(milesSeguidores) AS mediaSeguidoresCanalesEspañoles
  FROM STREAMERS_TEMATICAS
 WHERE LOWER(idioma) = 'español'

-- 07. Media de seguidores para los canales cuyo streamer es del país "España".

SELECT AVG(milesSeguidores) AS mediaSeguidoresCanalesDeStreamerEspañol
  FROM STREAMERS_TEMATICAS 
 WHERE codStreamer IN (SELECT codStreamer
                         FROM STREAMERS
                         WHERE UPPER(pais) = 'ES')

 SELECT AVG(milesSeguidores) AS mediaSeguidoresCanalesDeStreamerEspañol
   FROM STREAMERS s,
        STREAMERS_TEMATICAS st
  WHERE s.codStreamer = st.codStreamer
    AND UPPER(pais) = 'ES'

-- 08. Nombre de cada streamer y medio en el que habla, para aquellos que tienen entre 5.000 y 15.000 miles de seguidores, usando BETWEEN.

SELECT s.nombre,
       st.medio
  FROM STREAMERS s,
       STREAMERS_TEMATICAS st
 WHERE s.codStreamer = st.codStreamer
   AND milesSeguidores BETWEEN 5000 AND 15000

-- 09. Nombre de cada streamer y medio en el que habla, para aquellos que tienen entre 5.000 y 15.000 miles de seguidores, sin usar BETWEEN.

SELECT s.nombre,
       st.medio
  FROM STREAMERS s,
       STREAMERS_TEMATICAS st
 WHERE s.codStreamer = st.codStreamer
   AND milesSeguidores > 5000   
   AND milesSeguidores < 15000

-- 10. Nombre de cada temática y nombre de los idiomas en que tenemos canales de esa temática 
    --(quizá ninguno), sin duplicados.

SELECT DISTINCT t.nombre AS nombreTematica,
       st.idioma AS idiomaCanal
  FROM STREAMERS_TEMATICAS st
  LEFT JOIN TEMATICAS t
    ON st.codTematica = t.codTematica
 ORDER BY st.idioma ASC

-- 11. Nombre de cada streamer, nombre de la temática de la que habla y del medio en el que habla de esa temática, usando INNER JOIN.

SELECT s.nombre AS nombreStreamer,
       st.medio AS medioStreamer,
       t.nombre AS nombreTematicaCanal
  FROM TEMATICAS t
 INNER JOIN STREAMERS_TEMATICAS st
    ON t.codTematica = st.codTematica
 INNER JOIN  STREAMERS s
    ON st.codStreamer = s.codStreamer

-- 12. Nombre de cada streamer, nombre de la temática de la que habla y del medio en el que habla de esa temática, usando WHERE.

SELECT s.nombre AS nombreStreamer,
       st.medio AS medioStreamer,
       t.nombre AS nombreTematicaCanal
  FROM STREAMERS s,
       TEMATICAS t,
       STREAMERS_TEMATICAS st
 WHERE s.codStreamer = st.codStreamer
   AND t.codTematica = st.codTematica

-- 13. Nombre de cada streamer, del medio en el que habla y de la temática de la que habla en ese medio, 
-- incluso si de algún streamer no tenemos dato del medio o de la temática.


SELECT s.nombre AS nombreStreamer,
       st.medio AS medioStreamer,
       t.nombre AS nombreTematicaCanal
  FROM STREAMERS s
  LEFT JOIN STREAMERS_TEMATICAS st
    ON s.codStreamer = st.codStreamer
  LEFT JOIN TEMATICAS t
    ON st.codTematica = t.codTematica

-- 14. Nombre de cada medio y cantidad de canales que tenemos anotados en él, ordenado alfabéticamente por el nombre del medio.

SELECT medio,
       COUNT(codStreamer) AS numCanales
  FROM STREAMERS_TEMATICAS
 GROUP BY medio
 ORDER BY medio ASC

-- 15, 16, 17, 18. Medio en el que se emite el canal de más seguidores, de 4 formas distintas.

SELECT medio
  FROM STREAMERS_TEMATICAS
 WHERE milesSeguidores = (SELECT MAX(milesSeguidores)
                            FROM STREAMERS_TEMATICAS)
SELECT TOP(1) medio
  FROM STREAMERS_TEMATICAS
 ORDER BY milesSeguidores DESC

SELECT medio
  FROM STREAMERS_TEMATICAS
 WHERE milesSeguidores >= ALL (SELECT milesSeguidores
                                FROM STREAMERS_TEMATICAS)

-- 19. Categorías de las que tenemos 2 o más canales.

SELECT nombre
  FROM TEMATICAS
 WHERE codTematica IN (SELECT codTematica
                         FROM STREAMERS_TEMATICAS
                     GROUP BY codTematica
                       HAVING COUNT(codStreamer) >= 2)

-- 20. Categorías de las que no tenemos anotado ningún canal, ordenadas alfabéticamente, empleando COUNT.

SELECT t.nombre
  FROM TEMATICAS t
  LEFT JOIN STREAMERS_TEMATICAS st 
    ON t.codTematica = st.codTematica
 GROUP BY t.codTematica, t.nombre
HAVING COUNT(st.codTematica) = 0
 ORDER BY t.nombre ASC;

-- 21. Categorías de las que no tenemos anotado ningún canal, ordenadas alfabéticamente, empleando IN / NOT IN.

SELECT nombre
  FROM TEMATICAS
 WHERE codTematica NOT IN (SELECT codTematica
                             FROM STREAMERS_TEMATICAS)
ORDER BY nombre ASC

-- 22. Categorías de las que no tenemos anotado ningún canal, ordenadas alfabéticamente, empleando ALL / ANY.

SELECT nombre
  FROM TEMATICAS
 WHERE codTematica <> ALL (SELECT codTematica
                             FROM STREAMERS_TEMATICAS)
ORDER BY nombre ASC

-- 23. Categorías de las que no tenemos anotado ningún canal, ordenadas alfabéticamente, empleando EXISTS / NOT EXISTS.

SELECT t.nombre
  FROM TEMATICAS t
 WHERE NOT EXISTS (SELECT st.codStreamer
                     FROM STREAMERS_TEMATICAS st
                    WHERE st.codTematica = t.codTematica)
 ORDER BY t.nombre ASC

-- 24. Tres primeras letras de cada país y tres primeras letras de cada idioma, en una misma lista.

SELECT LEFT(s.pais, 1) AS UnaLetrasPais
  FROM STREAMERS s
 WHERE s.pais IS NOT NULL
 UNION
SELECT LEFT(st.idioma, 3) AS TresLetrasIdioma
  FROM STREAMERS_TEMATICAS st
 WHERE st.idioma IS NOT NULL

-- 25, 26, 27, 28. Tres primeras letras de países que coincidan con las tres primeras letras de un idioma, sin duplicados, de cuatro formas distintas.

SELECT DISTINCT LEFT(pais, 3) AS letrasPais
  FROM STREAMERS s
 INNER JOIN STREAMERS_TEMATICAS st
    ON s.codStreamer = st.codStreamer
 WHERE LEFT(s.pais, 3) = LEFT(st.idioma, 3)

SELECT DISTINCT LEFT(pais, 3) AS letrasPais
  FROM STREAMERS
 WHERE LEFT(pais, 3) IN (SELECT LEFT(idioma, 3)
                           FROM STREAMERS_TEMATICAS)

SELECT DISTINCT LEFT(pais, 3) AS letrasPais
  FROM STREAMERS
 WHERE LEFT(pais, 3) = ANY (SELECT LEFT(idioma, 3)
                             FROM STREAMERS_TEMATICAS)

SELECT DISTINCT LEFT(s.pais, 3) AS letrasPais
FROM STREAMERS s
WHERE EXISTS (SELECT *
                FROM STREAMERS_TEMATICAS st
               WHERE st.codStreamer = s.codStreamer
                 AND LEFT(st.idioma, 3) = LEFT(s.pais, 3))

-- 29. Nombre de streamer, nombre de medio y nombre de temática, para los canales que están por encima de la media de suscriptores.

SELECT s.nombre,
       st.medio,
       t.nombre
  FROM STREAMERS s,
       STREAMERS_TEMATICAS st,
       TEMATICAS t
 WHERE s.codStreamer = st.codStreamer
   AND t.codTematica = st.codTematica
   AND st.milesSeguidores > (SELECT AVG(milesSeguidores) 
                               FROM STREAMERS_TEMATICAS)

-- 30. Nombre de streamer y medio, para los canales que hablan de la temática "Bricolaje".

SELECT s.nombre,
       st.medio
  FROM STREAMERS s,
       STREAMERS_TEMATICAS st,
       TEMATICAS t
 WHERE s.codStreamer = st.codStreamer
   AND t.codTematica = st.codTematica
   AND LOWER(t.nombre) = 'bricolaje'

-- 31. Crea una tabla de "juegos". Para cada juego querremos un código (clave primaria), un nombre (hasta 20 letras, no nulo) y una referencia al streamer que más habla de él (clave ajena a la tabla "streamers").

CREATE TABLE JUEGOS (
    codJuego INT,
    nombre VARCHAR(20) NOT NULL,
    codStreamer INT

    CONSTRAINT PK_JUEGOS PRIMARY KEY (codJuego)
    CONSTRAINT FK_JUEGOS_STREAMERS FOREIGN KEY (codStreamer)
               REFERENCES STREAMERS(codStreamer)
)   

-- 32. Añade a la tabla de juegos la restricción de que el código debe ser 1000 o superior.

ALTER TABLE JUEGOS 
ADD CONSTRAINT CK_JUEGOS_codJuego CHECK (codJuego >= 1000)


-- 33. Añade 3 datos de ejemplo en la tabla de juegos. Para uno indicarás todos los campos, para otro no indicarás el streamer, ayudándote de NULL, y para el tercero no indicarás el streamer porque no detallarás todos los nombres de los campos.

INSERT INTO JUEGOS (codJuego, nombre, codStreamer)
VALUES (1001, 'NombreJuego1', 1);

INSERT INTO JUEGOS (codJuego, nombre, codStreamer)
VALUES (1002, 'NombreJuego2', NULL);

INSERT INTO JUEGOS
VALUES (1003, 'NombreJuego3', NULL);

SELECT *
FROM JUEGOS

-- 34. Borra el segundo dato de ejemplo que has añadido en la tabla de juegos, a partir de su código.

DELETE FROM JUEGOS
WHERE codJuego = 1002

-- 35. Muestra el nombre de cada juego junto al nombre del streamer que más habla de él, si existe. Los datos aparecerán ordenados por nombre de juego y, en caso de coincidir éste, por nombre de streamer.

SELECT j.nombre AS nombreJuegos,
       s.nombre AS nombreStreamer
  FROM JUEGOS j,
       STREAMERS s
 WHERE j.codStreamer = s.codStreamer

-- 36. Modifica el último dato de ejemplo que has añadido en la tabla de juegos, para que sí tenga asociado un streamer que hable de él.

UPDATE JUEGOS
SET codStreamer = 1
FROM JUEGOS
WHERE codJuego = 1003

-- 37. Crea una tabla "juegosStreamers", volcando en ella el nombre de cada juego (con el alias "juego") y el nombre del streamer que habla de él (con el alias "streamer").

CREATE TABLE JUEGOS_STREAMERS (
  juego VARCHAR(20),
  streamer VARCHAR(100)
)

UPDATE js
SET js.juego = j.nombre,
    js.streamer = s.nombre
FROM JUEGOS_STREAMERS js,
     JUEGOS j,
     STREAMERS s
WHERE js.juego = j.nombre
  AND js.streamer = s.nombre
    
-- 38. Añade a la tabla "juegosStreamers" un campo "fechaPrueba".

ALTER TABLE JUEGOS_STREAMERS 
ADD fechaPrueba SMALLDATETIME

-- 39. Pon la fecha de hoy (prefijada, sin usar GetDate) en el campo "fechaPrueba" de todos los registros de la tabla "juegosStreamers".

INSERT INTO JUEGOS_STREAMERS (fechaPrueba)
VALUES ('2024-02-22 00:00:00')

SELECT *
FROM JUEGOS_STREAMERS

-- 40. Muestra juego, streamer y fecha de ayer (día anterior al valor del campo "fechaPrueba") para todos los registros de la tabla "juegosStreamers".



-- 41. Muestra todos los datos de los registros de la tabla "juegosStreamers" que sean del año actual de 2 formas distintas (por ejemplo, usando comodines o funciones de cadenas).



-- 42. Elimina la columna "streamer" de la tabla "juegosStreamers".

ALTER TABLE JUEGOS_STREAMERS
DROP COLUMN streamer


-- 43. Vacía la tabla de "juegosStreamers", conservando su estructura.

DELETE FROM JUEGOS_STREAMERS
TRUNCATE TABLE JUEGOS_STREAMERS

-- 44. Elimina por completo la tabla de "juegosStreamers".

DROP TABLE JUEGOS_STREAMERS

-- 45. Borra los canales del streamer "Caddac Tech".



-- 46. Muestra la diferencia entre el canal con más seguidores y la media, mostrada en millones de seguidores. Usa el alias "diferenciaMillones".

-- 47. Medios en los que tienen canales los creadores de código "ill", "ng" y "ltt", sin duplicados, usando IN (pero no en una subconsulta).

-- 48. Medios en los que tienen canales los creadores de código "ill", "ng" y "ltt", sin duplicados, sin usar IN.

-- 49. Nombre de streamer y nombre del medio en el que habla, para aquellos de los que no conocemos el país.

-- 50. Nombre del streamer y medio de los canales que sean del mismo medio que el canal de Ibai Llanos que tiene 12800 miles de seguidores (puede aparecer el propio Ibai Llanos).

-- 51. Nombre del streamer y medio de los canales que sean del mismo medio que el canal de Ibai Llanos que tiene 12800 miles de seguidores (sin incluir a Ibai Llanos).

-- 52. Nombre de cada streamer, medio y temática, incluso si para algún streamer no aparece ningún canal o para alguna temática no aparece ningún canal.

-- 53. Nombre de medio y nombre de cada temática, como parte de una única lista (quizá desordenada).

-- 54. Nombre de medio y nombre de cada temática, como parte de una única lista ordenada alfabéticamente.

-- 55. Nombre de medio y cantidad media de suscriptores en ese medio, para los que están por encima de la media de suscriptores de los canales.

-- 56. Nombre de los streamers que emiten en YouTube y que o bien hablan en español o bien sus miles de seguidores están por encima de 12.000.

-- 57. Añade información ficticia sobre ti: datos como streamer, temática sobre la que supuestamente y medio en el que hablas sobre ella, sin indicar cantidad de seguidores. Crea una consulta que muestre todos esos datos a partir de tu código.

-- 58. Muestra el nombre de cada streamer, medio en el que emite y cantidad de seguidores, en millones, redondeados a 1 decimal.

-- 59. Muestra el nombre de cada streamer y el país de origen. Si no se sabe este dato, deberá aparecer "(País desconocido)".

-- 60. Muestra, para cada streamer, su nombre, el medio en el que emite (precedido por "Emite en: ") y el idioma de su canal (precedido por "Idioma: ")
