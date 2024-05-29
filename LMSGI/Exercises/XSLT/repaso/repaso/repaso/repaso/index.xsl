<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
    <head>
        <link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'></link>
        <link href='https://fonts.googleapis.com/css?family=Bebas Neue' rel='stylesheet'></link>

        <title>Ryanair</title>
        <style>
            img{
                width: 29%;
                padding: 33px;
            }
            h1{
                text-align: center;
            }
            #flight-h3{
                color:#F1C933;
                font-family: Bebas Neue;
                font-size: 35px;
                padding: 0px;
                padding-left: 25px;
            }
            div h3{
                padding:10px;
                font-size: 24px;
            }
            .container{
                background-color: #073590;
                display: grid;
                gap: 1px;
                width: 61%;
                margin-left: 19%;
                margin-right: 21%;          
            }
            .type-flight{
                display: flex;
                align-items: end;
            }
            #roundLogo{
                width: 7%;
                padding: 20px;
            }
            .number-aeroline{
                display:flex;
                gap: 33%;
                justify-content: center;
                background-color: #F1C933;
            }
            .number-aeroline h3{
                color: #073590;
                font-family: roboto;
            }
            .departure{
                display: flex;
                justify-content: space-evenly;
            }
            .title-flights{
                width:50%;
                background-color: #073590;
                align-content: center;
                text-align: center;
                font-family: Bebas Neue;
                color: white;
            }
            .title-flights h3{
              color: #F1C933;
              font-size: 33px;
            }
            .flight-details{
                width:50%;
                background-color: #F4F4F4;
            }
            .flight-details h3 {
                font-family:roboto;
                color: #073590;
            }
            
            .arrival{
                display: flex;
                justify-content: space-evenly;
            }
            .duration-landing{
                display: flex;
                gap: 33%;
                justify-content: center;
                background-color: #F1C933;
            }
            .duration-landing h3{
                color: #073590;
                font-family: roboto;
            }
        </style>
    </head>
    <body>
        <h1><img src="ryanair.png" alt="ryanair logo"/></h1>

        <xsl:for-each select = "vuelos/vuelo">
            <div class="container" style="border: 1px solid black;">
                <div class="type-flight">
                    <img src="logoryanair.png" alt="ryanair png" srcset="" id="roundLogo"/>
                    <h3 id="flight-h3">Vuelo<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./numero_vuelo"/></h3>
                </div>

                <div class="number-aeroline"  style="border: 1px solid black;">
                    <h3>Num Vuelo:<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./numero_vuelo"/></h3>
                    <h3>Hora:<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./salida/hora"/></h3>
                </div>

                <div class="departure"  style="border: 1px solid black;">
                    <div class="title-flights">
                        <h3>Salida</h3>
                    </div>
                        <div class="flight-details" >
                        <h3>Aeropuerto:<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./salida/aeropuerto"/></h3>
                        <h3>Ciudad: <xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./salida/ciudad"/></h3>
                        <h3>Fecha: <xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./salida/fecha"/></h3>
                        </div>
                </div>

                <div class="arrival"  style="border: 1px solid black;">

                    <div class="title-flights">
                        <h3>Llegada</h3>
                    </div>
                        <div class="flight-details">
                        <h3>Aeropuerto:<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./llegada/aeropuerto"/></h3>
                        <h3>Ciudad: <xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./llegada/ciudad"/></h3>
                        <h3>Fecha: <xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./llegada/hora"/></h3>
                        </div>
                </div>
                
                <div class="duration-landing"  style="border: 1px solid black;">
                    <h3>Duración: <xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./duracion"/></h3>
                    <h3>Precio:<xsl:text><!--agrega espacio--> </xsl:text><xsl:value-of select="./precio"/></h3>
                </div>
            </div>                    
            <br/><br/><br/>
            </xsl:for-each> 
    </body>
</html>
</xsl:template>
</xsl:stylesheet>