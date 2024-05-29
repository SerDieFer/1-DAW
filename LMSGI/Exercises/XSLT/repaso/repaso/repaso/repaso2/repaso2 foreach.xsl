<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!-- Definimos la plantilla que aplicará la transformación -->
    <xsl:template match="/">
        <!-- Creamos la estructura HTML -->
        <html>
            <head>
                <!-- Título de la página -->
                <title>Clientes</title>
                <meta charset="UTF-8"/>
                <!-- Estilos CSS para la tabla y las celdas -->
                <style>
                    table {
                        display: table; <!-- Aseguramos que el elemento se muestra como una tabla -->
                    }
                    td {
                        padding: 5px; <!-- Espaciado dentro de las celdas -->
                        border: 1px solid blue; <!-- Bordes azules para las celdas --> 
                    }
                </style>
            </head>
            <body>
                <!-- Encabezado principal de la página con texto azul -->
                <h1 style="color: blue;">Clientes</h1>
                <!-- Tabla para mostrar los datos de los clientes -->
                <table>
                    <!-- Encabezado de la tabla en negrita -->
                    <tr style="font-weight: bold;">
                        <td>Nombre</td>
                        <td>Dirección</td>
                        <td>Teléfono</td>
                    </tr>
                    <!-- Iteramos sobre cada cliente en el XML -->
                    <xsl:for-each select="clientes/cliente">
                        <!-- Fila de la tabla para cada cliente -->
                        <tr>
                            <!-- Celda para el nombre del cliente -->
                            <td>
                                <xsl:value-of select="nombre"/>
                            </td>
                            <!-- Celda para la dirección del cliente -->
                            <td>
                                <xsl:value-of select="direccion"/> 
                            </td>
                            <!-- Celda para el teléfono del cliente -->
                            <td>
                                <xsl:value-of select="telefono"/> 
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
