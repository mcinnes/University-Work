<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
    <xsl:for-each select="CATALOG/PLANT">
     <div class="new_prod_box">
                        <a href="details.php"><xsl:value-of select="NAME/COMMON"/></a>
                        <div class="new_prod_bg">
                        <a href="details.php"><img alt="" title=""><xsl:attribute name="src">
            <xsl:value-of select="PHOTO//@src"/>
          </xsl:attribute> </img></a>
                        </div>           
   </div>
    </xsl:for-each>
</xsl:template>
</xsl:stylesheet>