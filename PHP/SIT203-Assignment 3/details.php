<?session_start();?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />
	<link rel="stylesheet" href="lightbox.css" type="text/css" media="screen" />
	
    <script type="text/javascript" src="js/java.js"></script>
</head>
<body>

<?php 

$flowerID = $_GET['id']; 

if (!$flowerID) {
 echo "Please select a flower arrangement";
} else {


include 'db.php';

$query ="SELECT * FROM Products WHERE ID = '$flowerID'";

/* check the sql statement for errors and if errors report them */
$stmt = oci_parse($connect, $query);

if(!$stmt) {
echo "An error occurred in parsing the sql string.\n";
exit;
}

oci_execute($stmt);

//echo oci_result($stmt, "Phone");
while(oci_fetch_array($stmt)) {
$fID = oci_result($stmt,"ID");
$fName = oci_result($stmt,"NAME");
$fDesc = oci_result($stmt,"DESCRIPTION");
$fPrice = oci_result($stmt,"PRICE");
$fPhoto = oci_result($stmt,"PHOTO");
$fStockLevel = oci_result($stmt,"STOCK_LEVEL");
$fWeight = oci_result($stmt,"WEIGHT");

}

// Close the connection
oci_close($connect); 
}
?>
<span id="itemID" style="display:none;"><?echo $fID;?></span>


<div id="wrap">
<div class="header">
        <?php include 'header.php'; ?>
</div>  
       
       
       <div class="center_content">
       	<div class="left_content">
        	<div class="crumb_nav">
            <!-- echo $xml->PLANT[(int)$flowerID]->NAME -->
            <a href="index.php">home</a>  <? echo $fName; ?>
            </div>
            <!-- echo $xml->PLANT[(int)$flowerID]->NAME -->
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span><? echo $fName; ?> </div>
        
        	<div class="feat_prod_box_details">
            
            	<div class="prod_img"><a href="details.php"><img src="images/flowers/<? echo $fPhoto; ?>" alt="" title="" border="0" width="200" height="200"/></a>
                <br /><br />
                <!-- <a href="images/flowers/<? echo $xml->PLANT[(int)$flowerID]->PHOTO ?>" -->
                <a href="images/flowers/<? echo $fPhoto; ?>" rel="lightbox"><img src="images/zoom.gif" alt="" title="" border="0" /></a>
                </div>
    
                
                <div class="prod_det_box">
                	<div class="box_top"></div>
                    <div class="box_center">
                    <div class="prod_title">Details</div>
                    <p class="details"><? echo $fDesc; ?> </p>
                    <div class="price"><strong>PRICE:</strong> <span class="red"> $<? echo $fPrice; ?></span></div>
                    <span class="colors"><img src="images/color1.gif" alt="" title="" border="0" /></span>
                    <span class="colors"><img src="images/color2.gif" alt="" title="" border="0" /></span>
                    <span class="colors"><img src="images/color3.gif" alt="" title="" border="0" /></span>                    </div>
                    <a href="#" class="link" onclick="addToCart()"><img src="http://www.bulletproofback.com/images/add_to_cart.png" alt="" title="" border="0" style="margin-top:20px; width: 150px; height: 70px; margin-bottom: 20px;"/></a>
                    <div class="clear"></div>
                    </div>
                    
                </div>    
            <div class="clear"></div>
            
              
            <div id="demo" class="demolayout">

                <ul id="demo-nav" class="demolayout">
                <li><a class="" href="#tab2">Related Products</a></li>
                </ul>
    
            <div class="tabs-container">
            
                    <!-- Uses same code from category.php to load results from the xml file using xsl -->
                            <div style="display: block;" class="tab" id="tab2">
                


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



<script>
function addToCart(str) {
   
        var xmlhttp = new XMLHttpRequest();
      
        xmlhttp.open("GET", "cart/cart_update.php?action=add&id=" + <? echo $fID;?>, true);
        xmlhttp.send();
location.reload();


}
</script>

</html>