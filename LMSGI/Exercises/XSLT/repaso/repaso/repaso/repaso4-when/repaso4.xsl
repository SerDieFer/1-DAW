<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!-- Definimos la plantilla que aplicará la transformación al documento XML -->
    <xsl:template match="/">
        <!-- Comenzamos la estructura HTML -->
        <html>
            <head>
                <!-- Título de la página -->
                <title>repaso4</title>
                <!-- Estilos CSS para la página -->
                <style>
                    <!-- 
                    Definimos estilos para la tabla, filas y celdas.
                    -->
                    table {
                        border: 2px solid black; <!-- Borde de la tabla -->
                        display: table; <!-- Mostrar como tabla -->
                        font-family: arial; <!-- Fuente de la tabla -->
                    }
                    tr {
                        display: table-row; <!-- Mostrar como fila de tabla -->
                    }
                    td {
                        font-weight: bold; <!-- Texto en negrita -->
                        padding: 3px; <!-- Espaciado dentro de las celdas -->
                        border: 1px solid black; <!-- Borde de las celdas -->
                        display: table-cell; <!-- Mostrar como celda de tabla -->
                    } 
                </style>
            </head>
            <body>
                <!-- Encabezado principal de la página -->
                <h1>Expediente académico</h1>

                <!-- Mostrar el nombre del alumno -->
                <h3>Alumno: <xsl:value-of select="alumno/@nombre"/></h3>

                <!-- Comenzamos la tabla para las asignaturas -->
                <table>
                    <!-- Fila de encabezado con estilo -->
                    <tr style="font-weight:bold;">
                        <td style="background-color: #9acd32;">Asignatura</td> <!-- Celda de encabezado para "Asignatura" con fondo de color -->
                        <td style="background-color: #9acd32;">Nota</td> <!-- Celda de encabezado para "Nota" con fondo de color -->
                        <td style="background-color: #9acd32;">Descripción</td> <!-- Celda de encabezado para "Descripción" con fondo de color -->
                    </tr>
                    <!-- Iteramos sobre cada asignatura en el XML -->
                    <xsl:for-each select="alumno/expediente/asignatura">
                        <!-- Fila de la tabla para cada asignatura -->
                        <tr>
                            <!-- Celda para el nombre de la asignatura -->
                            <td>
                                <xsl:value-of select="nombre"/>
                            </td>
                            <!-- Celda para la nota de la asignatura -->
                            <td>
                                <xsl:value-of select="nota"/>
                            </td>
                            <!-- Celda para la descripción de la nota -->
                            <td>
                                <!-- Utilizamos xsl:choose para evaluar la nota -->
                                <xsl:choose>
                                    <!-- Condición para nota menor a 5 -->
                                    <xsl:when test="nota &lt; 5"> 
                                        <span style="color:red;"> Suspenso</span> <!-- Texto en rojo para suspenso -->
                                    </xsl:when>
                                    <!-- Condición para nota entre 5 y 7 -->
                                    <xsl:when test="nota &gt;= 5 and nota &lt; 7">
                                        Aprobado
                                    </xsl:when>
                                    <!-- Condición para nota entre 7 y 9 -->
                                    <xsl:when test="nota &gt;= 7 and nota &lt; 9">
                                        Notable
                                    </xsl:when>
                                    <!-- Condición para nota mayor o igual a 9 -->
                                    <xsl:otherwise>
                                        Excelente
                                    </xsl:otherwise>
                                </xsl:choose> 
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
