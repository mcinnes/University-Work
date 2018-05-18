<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
    <xsl:for-each select="CATALOG/PLANT1">
    <div class="new_prod_box">
                        <a href="details.php"><xsl:value-of select="ZONE"/></a>
                        <div class="new_prod_bg">
                          <h2>fucking penut</h2>
                        <a href="details.php"><img src="images/thumb1.gif" alt="" title="" class="thumb" border="0" /></a>
                        </div>           
   </div>
    </xsl:for-each>
</xsl:template>
</xsl:stylesheet>