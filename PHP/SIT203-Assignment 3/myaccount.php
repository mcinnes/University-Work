<? session_start(); ?>
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
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>My Purchase History</div>
        
          <div class="feat_prod_box_details">
            
           
            
                
               <?

               include'db.php';

              $userID = $_SESSION['id'];

              if (!$userID) {
                                 echo "Please Login to view your purchase history.\n"; 

              } else {

              $sql = "SELECT * FROM orders WHERE userID = '$userID'";

              $stmt = oci_parse($connect, $sql); 

              if(!$stmt) {
                 echo "An error occurred in parsing the sql string.\n"; 
                exit; 
              }

              oci_execute($stmt);

              while(oci_fetch_array($stmt)) {

                $prodArray = explode(',', oci_result($stmt,"PRODUCTS"));
                echo "<table class='cart_table'>";
                echo '<h2>Order Number:' . oci_result($stmt,"ID");
                echo date('     d/m/Y', oci_result($stmt,"PURCHASEDATE"));

                 echo ' <tr class="cart_title">
                  <td>Item pic</td>
                  <td>Product name</td>
                    <td>Unit price</td>
                    <td>Qty</td>
                    <td>Total</td> 
                </tr> ';

          foreach ($prodArray as $product) {

                $sql = "SELECT * FROM Products WHERE ID = '$product'";

                 $stmt1 = oci_parse($connect, $sql); 

              if(!$stmt1) {
                 echo "An error occurred in parsing the sql string.\n"; 
                exit; 
              }

              oci_execute($stmt1);

              while(oci_fetch_array($stmt1)) {
                 $title= oci_result($stmt1,"NAME");
                $author = oci_result($stmt1,"DESCRIPTION");
                $price = oci_result($stmt1,"PRICE");
                $id = oci_result($stmt1,"ID"); 
                $total = $qty * $price;
                echo '<tr>
                    <td><a href="details.php"><img src="images/cart_thumb.gif" alt="" title="" border="0" class="cart_thumb" /></a></td>
                    <td>'.$title.'</td>
                    <td>$'.$price.'</td>
                    <td>1</td>
                    <td>$'.$price.'</td>
                </tr>';
                } 
          }
          echo "</table>";


               
              
               }
  

           }

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