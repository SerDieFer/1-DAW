<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<head>
<title>Ejemplo 2 de XSLT</title>
</head>
<body>
<xsl:for-each select = "/receta">
<h1>
    <xsl:value-of select="./titulo" />
</h1>
</xsl:for-each>
</body>
</html>
</xsl:template>
</xsl:stylesheet>