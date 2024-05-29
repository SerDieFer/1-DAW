<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
    <html>

        <head>

            <style>
                    .main-container {
                        padding-left: 17%;
                        padding-right: 17%;
                    }
                    .main-container h2 {
                        color: firebrick;
                        font-size: 30px;
                    }
                    .main-container h3 {
                        color: grey;
                        font-size: 30px;
                    }
                    table {
                        width: 100%;
                        border-collapse: collapse;
                    }
                    th, td {
                        border-bottom: 1px solid grey;
                        padding: 8px;
                        text-align: center;
                    } 
            </style>

        </head>

        <body>
                <div class="main-container">
                    <h2>Libreria</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th>Autor</th>
                                <th>Editorial</th>
                                <th>ISBN</th>
                                <th>Versión Kindle</th>
                                <th>Precio</th>
                            </tr>
                        </thead>
                        <tbody>
                            <xsl:for-each select="libreria/libro">
                                <xsl:sort select="precio"/>
                                <tr>
                                    <td><xsl:value-of select="titulo"/></td>
                                    <td>
                                        <xsl:value-of select="autor/nombre"/>
                                        <xsl:text> </xsl:text>
                                        <xsl:value-of select="autor/apellido"/>
                                    </td>
                                    <td><xsl:value-of select="editorial"/></td>
                                    <td style="text-align:center;"><xsl:value-of select="titulo/@ISBN"/></td>
                                    <td>
                                        <xsl:choose>
                                            <xsl:when test="disponibleKindle = 'true'">Si</xsl:when>
                                            <xsl:otherwise>No</xsl:otherwise>
                                        </xsl:choose>
                                    </td>
                                        <xsl:choose>
                                            <xsl:when test="precio &gt; 20">
                                                <td style="color:green; text-align:center;"><xsl:value-of select="precio"/><xsl:text> </xsl:text><xsl:value-of select="precio/@moneda"/></td>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <td style="color:red; text-align:center;"><xsl:value-of select="precio"/><xsl:text> </xsl:text><xsl:value-of select="precio/@moneda"/></td>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                </tr>
                            </xsl:for-each>
                        </tbody>
                    </table>
                    <h3>Instrucciones de Compra</h3>
                    <div class="instructions">
                        <ol>
                            <xsl:for-each select="//instruccionesCompra/paso">
                                <li><xsl:value-of select="."/></li>
                            </xsl:for-each>
                        </ol>
                    </div>
                </div>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>