<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<head>
<style>
    .main-container{
        padding-left: 17%;
        padding-right: 17%;
    }
    .main-container h1{
        text-align: center;
        background-color: black;
        color: white;  
    }
    .main-container h2{
        color: firebrick;
        font-size:30px;
    }
    .title{
        display: flex;
        flex-direction: row;
        gap: 14%;
    }
    .name-row li, .quantity-row li, .mesure-row li, .category-row li{
        display: flex;
        flex-direction: cloumn;
        list-style:none;
    }
    .name-row h4, .quantity-row h4, .mesure-row h4, .category-row h4{
        padding-bottom: unset;
        margin-bottom: 5px;
    }
    .name-row ul, .quantity-row ul, .mesure-row ul, .category-row ul{
        display: flex;
        flex-direction: column;
        list-style: none;
        align-items: flex-start;
        padding: 0px;
    }   
    hr{
        position: relative;
        bottom: 82px;
        width: 90%;
        right: 45px;
    }
</style>
</head>
<body>
<div class="main-container">
    <h1>Receta</h1>
    <h2><xsl:value-of select="receta/titulo"/></h2>
    <p>Tiempo de elaboración: <xsl:value-of select="//tiempo_elaboracion"/><xsl:text><!--agrega espacio--> </xsl:text> <xsl:value-of select="//tiempo_elaboracion/@t_medida"/></p>
    <p>Origen: <xsl:value-of select="//cocina"/> </p>
    <p>Especialidad: <xsl:value-of select="//especialidad"/></p>
    <h3>Ingredientes (para <xsl:value-of select="//ingredientes/@comensales"/> personas)</h3>
    <div class="table">
        <div class="title">
            <div class="name-row">
                <h4>Nombre</h4>
                <ul>
                    <xsl:for-each select="//ingredientes/ingrediente">
                        <li>
                            <xsl:value-of select="./nombre"/>
                        </li>
                    </xsl:for-each>
                </ul>
            </div>
            <div class="quantity-row">
                <h4>Cantidad</h4>
                <ul>
                    <xsl:for-each select="//ingredientes/ingrediente">
                        <li>
                            <xsl:value-of select="./cantidad"/>
                        </li>
                    </xsl:for-each>
                </ul>
            </div>
            <div class="mesure-row">
                <h4>Medida</h4>
                <ul>
                    <xsl:for-each select="//ingredientes/ingrediente">
                        <li>
                            <xsl:value-of select="./medida"/>
                        </li>
                    </xsl:for-each>
                </ul>
            </div>
            <div class="category-row">
                <h4>Categoria</h4>
                <ul>
                    <xsl:for-each select="//ingredientes/ingrediente">
                        <li>
                            <xsl:value-of select="./@categoria"/>
                        </li>
                    </xsl:for-each>
                </ul>
            </div>
        </div>
        <hr></hr>
    </div>
    <h3>Proceso</h3>
    <div class="process">
        <ol>
            <xsl:for-each select="//procedimiento/paso">
                <li>
                    <xsl:value-of select="."/>
                </li>
            </xsl:for-each>
        </ol>
    </div>
</div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>