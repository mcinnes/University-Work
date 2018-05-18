<?php start_session(); ?>
<?php include 'db.php'; ?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />

</head>
<body>
<!-- Header, footer, and right_content are all in spererate php files, this is to save having to rewrite every page
 -->
<div id="wrap">

       <div class="header">
        <?php include 'header.php'; ?>
        </div>     
            
            
       
       
       <div class="center_content">
       	<div class="left_content">
        	
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>Featured products</div>
        
        	<div class="feat_prod_box">
            
            	<div class="prod_img"><a href="details.php?id=0"><img src="images/flowers/flower1.jpg" alt="" title="" border="0" width="88" height="96" /></a></div>
                
                <div class="prod_det_box">
                	<div class="box_top"></div>
                    <div class="box_center">
                    <div class="prod_title">All things Bright and Beautiful</div>
                    <p class="details">Bright yellow Sunflowers with seasonal flowers in a glass vase.  This arrangement brings a smile to any face and is seasonal and will be changed to suit the season.</p>
                    <a href="details.php?id=0" class="more">- more details -</a>
                    <div class="clear"></div>
                    </div>
                    
                    <div class="box_bottom"></div>
                </div>    
            <div class="clear"></div>
            </div>	
            
            
        	<div class="feat_prod_box">
            
            	<div class="prod_img"><a href="details.php?id=1"><img src="images/flowers/flower2.jpg" alt="" title="" border="0" width="88" height="96"/></a></div>
                
                <div class="prod_det_box">
                	<div class="box_top"></div>
                    <div class="box_center">
                    <div class="prod_title">Bright Basket of Spring Flowers</div>
                    <p class="details">Bright boquet of yellow Spring flowers, perfect to brighten any room.</p>
                    <a href="details.php?id=1" class="more">- more details -</a>
                    <div class="clear"></div>
                    </div>
                    
                    <div class="box_bottom"></div>
                </div>    
            <div class="clear"></div>
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
    

</div>

</body>
</html>