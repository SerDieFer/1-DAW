<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!-- Definimos la plantilla que aplicará la transformación -->
    <xsl:template match="/">
        <!-- Creamos la estructura HTML -->
        <html>
            <head>
                <!-- Título de la página -->
                <title>Repaso3</title>
                <!-- Estilos CSS para la página -->
                <style>
                    h1 {
                        text-align: center; <!-- El texto se alinea en el centro --> 
                        background-color: black; <!-- El fondo de color negro --> 
                        color: white;  <!-- La letra de color blanco --> 
                    }
                    h2 {
                        color: red; <!--  El título de la receta en color rojo -->
                    }
                    td {
                        padding: 5px; <!-- Espaciado dentro de las celdas -->
                    }
                </style>
            </head>

            <body>
                <!-- Encabezado principal de la página -->
                <h1>Receta</h1>

                <!-- Iteramos sobre el nodo raíz, aunque en este caso no es necesario -->
                <xsl:for-each select="/">
                    <!-- Título de la receta -->
                    <h2><xsl:value-of select="receta/titulo"/></h2>

                    <!-- Detalles de la receta -->
                    <p>Tiempo elaboración: <xsl:value-of select="receta/tiempo_elaboracion"/> minutos</p>
                    <p>Origen: <xsl:value-of select="receta/cocina"/></p>
                    <p>Especialidad: <xsl:value-of select="receta/especialidad"/></p>

                    <!-- Encabezado para la sección de ingredientes -->
                    <h3>Ingredientes (para <xsl:value-of select="receta/ingredientes/@comensales"/> personas)</h3>
                </xsl:for-each>

                <!-- Tabla para listar los ingredientes -->
                <table>
                    <!-- Encabezado de la tabla en negrita y con borde inferior -->
                    <tr style="font-weight: bold;">
                        <td style="padding: 5px; border-bottom: 1px solid grey;">Nombre</td>
                        <td style="padding: 5px; border-bottom: 1px solid grey;">Cantidad</td>
                        <td style="padding: 5px; border-bottom: 1px solid grey;">Medida</td>
                        <td style="padding: 5px; border-bottom: 1px solid grey;">Categoria</td>
                    </tr>
                    <!-- Iteramos sobre cada ingrediente en el XML -->
                    <xsl:for-each select="receta/ingredientes/ingrediente">
                        <!-- Fila de la tabla para cada ingrediente -->
                        <tr>
                            <!-- Celda para el nombre del ingrediente -->
                            <td>
                                <xsl:value-of select="nombre"/>
                            </td>
                            <!-- Celda para la cantidad del ingrediente -->
                            <td>
                                <xsl:value-of select="cantidad"/> 
                            </td>
                            <!-- Celda para la medida del ingrediente -->
                            <td>
                                <xsl:value-of select="medida"/> 
                            </td>
                            <!-- Celda para la categoría del ingrediente -->
                            <td>
                                <xsl:value-of select="@categoria"/> <!-- El @ indica un atributo -->
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>

                <!-- Sección del procedimiento -->
                <h4>Proceso</h4>
                <ol>
                    <!-- Iteramos sobre cada paso en el procedimiento -->
                    <xsl:for-each select="receta/procedimiento/paso">
                        <!-- Cada paso se muestra como un elemento de lista -->
                        <li><xsl:value-of select="."/></li> <!-- El punto (.) selecciona el contenido del nodo actual -->
                    </xsl:for-each>
                </ol>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
