<?session_start();?>
<? include'db.php';?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
<div id="wrap">
        <script type="text/javascript" src="scripts/jquery-1.8.2.min.js"></script>

<script src="js/card/jquery.card.js"></script>

      <div class="header">
        <?php include 'header.php'; ?>
        </div>  
     
       <div class="center_content">
       	<div class="left_content">
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>My cart</div>
        
        	<div class="feat_prod_box_details">
            
           
            <table class="cart_table">
            	<tr class="cart_title">
                	<td>Item pic</td>
                	<td>Product name</td>
                    <td>Unit price</td>
                    <td>Qty</td>
                    <td>Total</td> 
                    <td>Remove</td>              
                </tr>
                
            	 <?

            $cart = $_SESSION['cart'];
            if ($cart) {
              $items = explode(',',$cart);
              $contents = array();
              foreach ($items as $item) {
                $contents[$item] = (isset($contents[$item])) ? $contents[$item] + 1 : 1;
              }

            $total = 0;
            foreach ($contents as $id=>$qty) {

              $sql = "SELECT * FROM Products WHERE ID = '$id'";

              $stmt = oci_parse($connect, $sql); 

              if(!$stmt) {
                 echo "An error occurred in parsing the sql string.\n"; 
                exit; 
              }

              oci_execute($stmt);

              while(oci_fetch_array($stmt)) {

                $title= oci_result($stmt,"NAME");
                $author = oci_result($stmt,"DESCRIPTION");
                $price = oci_result($stmt,"PRICE");
                $id = oci_result($stmt,"ID"); 
                $total = $qty * $price;
                echo '<tr>
                    <td><a href="details.php"><img src="images/cart_thumb.gif" alt="" title="" border="0" class="cart_thumb" /></a></td>
                    <td>'.$title.'</td>
                    <td>$'.$price.'</td>
                    <td>'.$qty.'</td>
                    <td>$'.$total.'</td>
                    <td><a href="#" onclick="removeItem()"><img src="images/remove.png" alt="" title="" border="0" class="cart_thumb" /></a></td>

                </tr>';
              
            }
        }
          } else {
            echo "<h2> No items in your cart!</h2>";
          }

            

            ?>         
            
            </table>
            <a href="#" class="continue">&lt; Continue Shopping</a>
            <a href="checkout.php" class="checkout">Checkout &gt;</a>

</div>

                
            
              
 <!-- Order form -->
              

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
<script>
function removeItem(str) {
   
        var xmlhttp = new XMLHttpRequest();
      
        xmlhttp.open("GET", "cart/cart_update.php?action=delete&id=" + <? echo $id;?>, true);
        xmlhttp.send();
        location.reload();

}
</script>
</body>
</html>