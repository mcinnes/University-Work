<? session_start();?>
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
 <div class="new_products">            
            
           <?
           include 'db.php';
           if (is_null($_GET['search'] )) {
             # code... for each item in products get limit 10
            $searchSQL = "SELECT * FROM PRODUCTS";

            $stmt = oci_parse($connect, $searchSQL);

            if(!$stmt) {
               echo "An error occurred in parsing the sql string.\n";
               exit;
            }

            oci_execute($stmt);

            while(oci_fetch_array($stmt)) {
            echo '<div class=new_prod_box">
                        <a href="details.php?id='.oci_result($stmt, "ID").'">'.oci_result($stmt,"NAME").'</a>
                        <div class="new_prod_bg">
                          <h2></h2>
                        <a href="details.php?id='.oci_result($stmt, "ID").'"><img src="images/flowers/'.oci_result($stmt, "PHOTO").'" alt="" title="" class="thumb" border="0" /></a>
                        </div>           
   </div>';

            }

            // Close the connection
            oci_close($connect);


           } else {

            $searchString = urldecode($_GET['search']);
           // $searchSQL = "SELECT * FROM PRODUCTS WHERE lower(NAME) LIKE  lower('$searchString')";
              $searchSQL = "SELECT * FROM PRODUCTS WHERE REGEXP_LIKE(name || description,'".$searchString."','i')"; 
            $stmt = oci_parse($connect, $searchSQL);

            if(!$stmt) {
               echo "An error occurred in parsing the sql string.\n";
               exit;
            }

            oci_execute($stmt);

            while(oci_fetch_array($stmt)) {
            echo '<div class=new_prod_box">
                        <a href="details.php?id='.oci_result($stmt,"ID").'">'.oci_result($stmt,"NAME").'</a>
                        <div class="new_prod_bg">
                          <h2></h2>
                        <a href="details.php?id='.oci_result($stmt,"ID").'"><img src="images/thumb1.gif" alt="" title="" class="thumb" border="0" /></a>
                        </div>           
   </div>';

            }

          }
            // Close the connection
            oci_close($connect); 

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