<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="UTF-8"/>

  <!-- PLANTILLA PARA EL ELEMENTO RAIZ -->
  <xsl:template match="/">
    <html>
      <head>
        <title>Facciones de Warhammer 40k</title>

        <!-- CARGA ESTILOS -->
        <link rel="stylesheet" type="text/css" href="Project.css"/>

      </head>
      <body>

        <!-- CREA DIV SLIDER -->
        <div id="slider">

          <!-- APLICA PLANTILLAS A CADA ELEMENTO 'FACCION' DENTRO DE 'WARHAMMER40K' -->
          <xsl:apply-templates select="warhammer40k/faccion"/>
        </div>
        
        <!-- CARGA SCRIPT PARA SLIDER -->
        <script src="Project.js"></script>

      </body>
    </html>
  </xsl:template>

  <!-- PLANTILLA PARA EL ELEMENTO 'FACCION' -->
  <xsl:template match="faccion">
    <div class="slide Faction">

      <!-- MUESTRA EL NOMBRE, LA DESCRIPCION, LAS HABILIDADES Y LA IMAGEN DE LA FACCION -->
      <div class="NombreFaccion">
        <h2>

          <!-- CONDICIONES PARA APLICAR ESTILO BASADOS EN EL ATRIBUTO 'NOMBRE' DEPENDIENDO LA FACCION -->
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

      <!-- APLICAMOS PLANTILLA A LOS ELEMENTOS 'LIDER' DENTRO DE 'FACCION' -->
      <xsl:apply-templates select="lider"/>

      <!-- APLICAMOS LA PLANTILLA A LOS ELEMENTOS 'UNIDAD DESTACADA' DENTRO DE 'FACCION' -->
      <xsl:apply-templates select="unidadDestacada"/>

    </div>

  </xsl:template>

  <!-- PLANTILLA PARA EL ELEMENTO 'LIDER' -->
  <xsl:template match="lider">

    <!-- MUESTRA EL NOMBRE, EL TITULO, LAS HABILIDADES Y LA IMAGEN DEL LIDER -->
    <div class="NombreLider"><h3>Lider: <xsl:value-of select="nombre"/></h3></div>
    <div class="TituloLider"><h3>Titulo: <xsl:value-of select="titulo"/></h3></div>
    <div class="DescripcionLider"><xsl:value-of select="habilidades"/></div>
    <div class="ImagenLider"><img src="./Media/Facciones/{../@nombre}/{foto}" alt="{nombre}"/></div>

  </xsl:template>

  <!-- PLANTILLA PARA EL ELEMENTO 'UNIDAD DESTACADA' -->
  <xsl:template match="unidadDestacada">

    <!-- MUESTRA EL NOMBRE, EL TIPO, LA DESCRIPCION Y LA IMAGEN DE LA UNIDAD -->
    <div class="NombreUnidad"><h3>Unidad Destacada: <xsl:value-of select="nombre"/></h3></div>
    <div class="TipoUnidad"><h3>Tipo: <xsl:value-of select="tipo"/></h3></div>
    <div class="DescripcionUnidad"><xsl:value-of select="descripcion"/></div>
    <div class="ImagenUnidad"><img src="./Media/Facciones/{../@nombre}/{foto}" alt="{nombre}"/></div>
    
  </xsl:template>

</xsl:stylesheet>