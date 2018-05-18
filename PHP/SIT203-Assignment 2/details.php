<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />
	<link rel="stylesheet" href="lightbox.css" type="text/css" media="screen" />
	
	<script src="js/prototype.js" type="text/javascript"></script>
	<script src="js/scriptaculous.js?load=effects" type="text/javascript"></script>
	<script src="js/lightbox.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/java.js"></script>
</head>
<body>
<?php $flowerID = $_GET['id']; ?>
<?php $xml=simplexml_load_file("cat.xml") or die("Error: Cannot create object"); ?>

<!-- 
Gets id of plant needed from the url passed from category.php
$flowerID = $_GET['id']; //note should strip characters

Uses simple php xml processor as it is simpler for this task than using xsl

$xml=simplexml_load_file("cat.xml") or die("Error: Cannot create object");
 -->

<div id="wrap">
<div class="header">
        <?php include 'header.php'; ?>
</div>  
       
       
       <div class="center_content">
       	<div class="left_content">
        	<div class="crumb_nav">
            <!-- echo $xml->PLANT[(int)$flowerID]->NAME -->
            <a href="index.php">home</a> &gt;&gt; <? echo $xml->PLANT[(int)$flowerID]->NAME ?>
            </div>
            <!-- echo $xml->PLANT[(int)$flowerID]->NAME -->
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span><? echo $xml->PLANT[(int)$flowerID]->NAME ?> </div>
        
        	<div class="feat_prod_box_details">
            
            	<div class="prod_img"><a href="details.php"><img src="images/flowers/<? echo $xml->PLANT[(int)$flowerID]->PHOTO ?>" alt="" title="" border="0" width="200" height="200"/></a>
                <br /><br />
                <!-- <a href="images/flowers/<? echo $xml->PLANT[(int)$flowerID]->PHOTO ?>" -->
                <a href="images/flowers/<? echo $xml->PLANT[(int)$flowerID]->PHOTO ?>" rel="lightbox"><img src="images/zoom.gif" alt="" title="" border="0" /></a>
                </div>
    
                
                <div class="prod_det_box">
                	<div class="box_top"></div>
                    <div class="box_center">
                    <div class="prod_title">Details</div>
                    <p class="details"><? echo $xml->PLANT[(int)$flowerID]->DESC ?> </p>
                    <div class="price"><strong>PRICE:</strong> <span class="red"> <? echo $xml->PLANT[(int)$flowerID]->PRICE ?></span></div>
                    <span class="colors"><img src="images/color1.gif" alt="" title="" border="0" /></span>
                    <span class="colors"><img src="images/color2.gif" alt="" title="" border="0" /></span>
                    <span class="colors"><img src="images/color3.gif" alt="" title="" border="0" /></span>                    </div>
                    <a href="details.php" class="more"><img src="images/order_now.gif" alt="" title="" border="0" /></a>
                    <div class="clear"></div>
                    </div>
                    
                    <div class="box_bottom"></div>
                </div>    
            <div class="clear"></div>
            
              
            <div id="demo" class="demolayout">

                <ul id="demo-nav" class="demolayout">
                <li><a class="" href="#tab2">Related Products</a></li>
                </ul>
    
            <div class="tabs-container">
            
                    <!-- Uses same code from category.php to load results from the xml file using xsl -->
                            <div style="display: block;" class="tab" id="tab2">
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
                            </div>	
            
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
<script type="text/javascript">

var tabber1 = new Yetii({
id: 'demo'
});

</script>
</html>