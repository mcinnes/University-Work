<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />

</head>
<body>
<div id="wrap">

      <div class="header">
        <?php include 'header.php'; ?>
        </div>  
       
       <div class="center_content">
       	<div class="left_content">
        	<div class="crumb_nav">
            <a href="index.php">home</a> &gt;&gt; category name
            </div>
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title=""/></span>Category products</div>
           <!-- new_products is generated via the php function transformToXML using ./cat.xml and ./cookies.xsl -->
           <!-- 

                    //read xsl style
                     $xslDoc = new DOMDocument();
                     $xslDoc->load("cookies.xsl");
                     //read xml file
                     $xmlDoc = new DOMDocument();
                     $xmlDoc->load("cat.xml");
                      
                      //combine xsl and xml
                     $proc = new XSLTProcessor();
                     $proc->importStylesheet($xslDoc);
                     //print to screen
                     echo $proc->transformToXML($xmlDoc);
                 -->
           <div class="new_products">            
                <?php
                     $xslDoc = new DOMDocument();
                     $xslDoc->load("cookies.xsl");
                     $xmlDoc = new DOMDocument();
                     $xmlDoc->load("cat.xml");

                     $proc = new XSLTProcessor();
                     $proc->importStylesheet($xslDoc);
                     echo $proc->transformToXML($xmlDoc);
                ?>
                 
            
            
            </div> 
          
            
        <div class="clear"></div>
        </div><!--end of left content-->
        
        <div class="right_content">
        	        <?php include 'sidebar.php'; ?>

        
        </div><!--end of right content-->
        
        
       
       
       <div class="clear"></div>
       </div><!--end of center content-->
       
              
       <div class="footer">
               <?php include 'footer.php'; ?>

        
       
       </div>
    

</div>

</body>
</html>