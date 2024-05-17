<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!-- Template para el elemento raíz -->
  <xsl:template match="/">
    <html>
      <head>
        <title>Facciones de Warhammer 40k</title>
        <!-- CSS Externo -->
        <link rel="stylesheet" type="text/css" href="Project.css" />
      </head>
      <body>
      <style>
      
      </style>
        <div class="Facciones">
            <!-- Llamada al template para cada facción -->
            <xsl:apply-templates select="warhammer40k/faccion"/>
        </div>
      </body>
    </html>
  </xsl:template>
  
  <!-- Template para cada facción -->
  <xsl:template match="faccion">
    <div class="Faccion">
        <div class="Nombre-Faccion">
            <!-- Nombre de la facción -->
            <h2><xsl:value-of select="@nombre"/></h2>
        </div>
        <div class="Imagen-Faccion">
            <!-- Imagen de la facción -->
            <img src="{foto}" alt="Foto de la facción"/>
        </div>
        <div class="Descripcion-Faccion">
            <!-- Descripción de la facción -->
            <p><xsl:value-of select="descripcion"/></p>
        </div>
        <xsl:if test="subfaccion">
            <div class="Subfacciones">
                <!-- Llamada al template para cada subfacción -->
                <xsl:apply-templates select="subfaccion"/>
            </div>
        </xsl:if>
        <xsl:if test="not(subfaccion)"> 
            <!-- Aplicar plantilla para el líder -->
            <xsl:apply-templates select="lider"/>
            <!-- Aplicar plantilla para la unidad destacada -->
            <xsl:apply-templates select="unidadDestacada"/>
        </xsl:if>
    </div>
  </xsl:template>
  
  <!-- Template para cada subfacción -->
  <xsl:template match="subfaccion">
    <div class="Subfaccion">
        <div class="Nombre-Subfaccion">
            <!-- Nombre de la subfacción -->
            <h3><xsl:value-of select="@nombre"/></h3>
        </div>
        <div class="Imagen-Subfaccion">
            <!-- Imagen de la subfacción -->
            <img src="{foto}" alt="Foto de la subfacción"/>
        </div>
        <div class="Descripcion-Subfaccion">
            <!-- Descripción de la subfacción -->
            <p><xsl:value-of select="descripcion"/></p>
        </div>
        <xsl:if test="capitulo">
            <div class="Capitulos">
                <!-- Llamada al template para cada capitulo -->
                <xsl:apply-templates select="capitulo"/>
            </div>
        </xsl:if>
        <xsl:if test="not(capitulo)"> 
            <!-- Aplicar plantilla para el líder -->
            <xsl:apply-templates select="lider"/>
            <!-- Aplicar plantilla para la unidad destacada -->
            <xsl:apply-templates select="unidadDestacada"/>
        </xsl:if>
    </div>   
  </xsl:template>
  
  <!-- Template para el capitulo -->
  <xsl:template match="capitulo">
    <div class="Capitulo">
        <div class="Nombre-Capitulo">
            <!-- Nombre del capitulo -->
            <h4><xsl:value-of select="@nombre"/></h4>
        </div>
        <div class="Imagen-Capitulo">
            <!-- Imagen del capitulo -->
            <img src="{foto}" alt="Foto del capitulo"/>
        </div>
        <div class="Descripcion-Capitulo">
            <!-- Descripción del capitulo -->
            <p><xsl:value-of select="descripcion"/></p>
        </div>
        <!-- Llamada al template para cada lider -->
        <xsl:apply-templates select="lider"/>
        <!-- Llamada al template para cada unidad destacada -->
        <xsl:apply-templates select="unidadDestacada"/>   
    </div>
  </xsl:template>
  
  <!-- Template para el líder de la subfacción -->
  <xsl:template match="lider">
    <div class="Lider">
        <div class="Nombre-Lider">
            <!-- Nombre del líder -->
            <h5><xsl:value-of select="nombre"/></h5>
        </div>
        <div class="Titulo-Lider">
            <!-- Título del líder -->
            <p><xsl:value-of select="titulo"/></p>
        </div>
        <div class="Habilidades-Lider">
            <!-- Habilidades del líder -->
            <p><xsl:value-of select="habilidades"/></p>
        </div>
        <div class="Foto-Lider">
            <!-- Imagen del líder -->
            <img src="{foto}" alt="Foto del líder"/>
        </div>
    </div>
  </xsl:template>
  
  <!-- Template para la unidad destacada de la subfacción -->
  <xsl:template match="unidadDestacada">
    <div class="Unidad-Destacada">
        <div class="Nombre-UnidadDestacada">
            <!-- Nombre de la unidad destacada -->
            <h5><xsl:value-of select="nombre"/></h5>
        </div>
        <div class="Tipo-UnidadDestacada">
            <!-- Tipo de la unidad destacada -->
            <p><xsl:value-of select="tipo"/></p>
        </div>
        <div class="Descripcion-UnidadDestacada">
            <!-- Descripción de la unidad destacada -->
            <p><xsl:value-of select="descripcion"/></p>
        </div>
        <div class="Foto-UnidadDestacada">
            <!-- Imagen de la unidad destacada -->
            <img src="{foto}" alt="Foto de la unidad destacada"/>
        </div>
    </div>
  </xsl:template>
</xsl:stylesheet>
