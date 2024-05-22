<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="UTF-8"/>

  <xsl:template match="/"> <!-- Plantilla Elemento Raiz -->
    <html>
      <head>
        <title>Facciones de Warhammer 40k</title>
        <link rel="stylesheet" type="text/css" href="Project.css"/> <!-- Carga Estilos -->
      </head>
      <body>
        <div id="slider"> <!-- Crea Div Slider -->
          <xsl:apply-templates select="warhammer40k/faccion"/> <!-- Aplica Cada Faccion / Foreach -->
        </div>
        <script src="Project.js"></script> <!-- Carga Script Slider -->
      </body>
    </html>
  </xsl:template>

  <xsl:template match="faccion"> <!-- Plantilla Faccion -->
    <div class="slide Faction">
      <div class="NombreFaccion">
        <h2>
          <xsl:if test="@nombre = 'Humanidad'">
            <xsl:attribute name="style">color: blue;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Necrones'">
            <xsl:attribute name="style">color: green;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Orkos'">
            <xsl:attribute name="style">color: red;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Tiránidos'">
            <xsl:attribute name="style">color: purple;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Tau'">
            <xsl:attribute name="style">color: orange;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Caos'">
            <xsl:attribute name="style">color: black;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Drukhari'">
            <xsl:attribute name="style">color: darkred;</xsl:attribute>
          </xsl:if>
          <xsl:if test="@nombre = 'Aeldari'">
            <xsl:attribute name="style">color: teal;</xsl:attribute>
          </xsl:if>
          Faccion ~ <xsl:value-of select="@nombre"/>
        </h2>
      </div>
      <div class="DescripcionFaccion"><xsl:value-of select="descripcion"/></div>
      <div class="ImagenFaccion"><img src="./Media/Facciones/{@nombre}/{foto}" alt="{@nombre}"/></div>
      <xsl:apply-templates select="lider"/>
      <xsl:apply-templates select="unidadDestacada"/>
    </div>
  </xsl:template>

  <xsl:template match="lider"> <!-- Plantilla Lider -->
    <div class="NombreLider"><h3>Lider: <xsl:value-of select="nombre"/></h3></div>
    <div class="TituloLider"><h3>Titulo: <xsl:value-of select="titulo"/></h3></div>
    <div class="DescripcionLider"><xsl:value-of select="habilidades"/></div>
    <div class="ImagenLider"><img src="./Media/Facciones/{../@nombre}/{foto}" alt="{nombre}"/></div>
  </xsl:template>

  <xsl:template match="unidadDestacada"> <!-- Plantilla Unidad -->
    <div class="NombreUnidad"><h3>Unidad Destacada: <xsl:value-of select="nombre"/></h3></div>
    <div class="TipoUnidad"><h3>Tipo: <xsl:value-of select="tipo"/></h3></div>
    <div class="DescripcionUnidad"><xsl:value-of select="descripcion"/></div>
    <div class="ImagenUnidad"><img src="./Media/Facciones/{../@nombre}/{foto}" alt="{nombre}"/></div>
  </xsl:template>

</xsl:stylesheet>