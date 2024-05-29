<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <head>
                <title>Ejercicio 06</title>
                <style>
                    .table-first{
                        display: flex;
                        flex-direction: row;
                        gap:45px;
                        width:80%;
                    }

                    ul{
                        display: flex;
                        flex-direction: column;
                        list-style: none;
                        align-items: flex-start;
                        padding: 0px;
                    }
                </style>
            </head>
            <body>
                <h1>Novedades XML</h1>
                <div class="first-header">
                    <!-- Aquí se mostrará el nombre de la primera librería encontrada -->
                    <h3><xsl:value-of select="TEMA/libreria[1]/@nombre"/></h3>
                    <!-- Aquí se mostrará el enlace del primer libro de la primera librería encontrada -->
                    <a href="#"><xsl:value-of select="TEMA/libreria[1]/primer_libro/link_web"/></a>
                </div>
                <div class="table-first">
                    <div class="table-tile">
                        <div class="title">
                            <p>Título</p>
                        </div>
                        <ul>
                            <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                            <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                                <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                                <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                    <li>
                                        <!-- Extrae el valor del elemento nombre_libro -->
                                        <xsl:value-of select="nombre_libro"/>
                                    </li>
                                </xsl:for-each>
                            </xsl:for-each>
                        </ul>
                    </div>

                <div class="author">
                    <div class="title">
                        <p>Autor</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="autores"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>   
                 </div>
                <div class="publishing">
                    <div class="title">
                        <p>Editorial</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="editorial"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>                 
                </div>
                <div class="year">
                    <div class="title">
                        <p>Año</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="año"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>  
                </div>
                <div class="level">
                    <div class="title">
                        <p>Nivel</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="../@nivel"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>                  
                    </div>
                <div class="isbn">
                    <div class="title">
                        <p>ISBN</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="isbn"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>                             
                    </div>
                <div class="price">
                    <div class="title">
                        <p>price</p>
                    </div>
                    <ul>
                        <!-- Selecciona todas las librerías con nombre "Casa Del Libro" -->
                        <xsl:for-each select="TEMA/libreria[@nombre='Casa Del Libro']">
                            <!-- Dentro de cada librería, selecciona todos los elementos que representan libros -->
                            <xsl:for-each select="primer_libro | segundo_libro | tercero_libro">
                                <li>
                                    <!-- Extrae el valor del elemento nombre_libro -->
                                    <xsl:value-of select="precio"/>
                                </li>
                            </xsl:for-each>
                        </xsl:for-each>
                    </ul>   
                </div>
            </div>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
