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
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>My cart</div>
        
        	<div class="feat_prod_box_details">
            
            <table class="cart_table">
            	<tr class="cart_title">
                	<td>Item pic</td>
                	<td>Product name</td>
                    <td>Unit price</td>
                    <td>Qty</td>
                    <td>Total</td>               
                </tr>
                
            	<tr>
                	<td><a href="details.php"><img src="images/cart_thumb.gif" alt="" title="" border="0" class="cart_thumb" /></a></td>
                	<td>Gift flowers</td>
                    <td>100$</td>
                    <td>1</td>
                    <td>100$</td>               
                </tr>          
            	<tr>
                	<td><a href="details.php"><img src="images/cart_thumb.gif" alt="" title="" border="0" class="cart_thumb" /></a></td>
                	<td>Gift flowers</td>
                    <td>100$</td>
                    <td>1</td>
                    <td>100$</td>               
                </tr>                  
            	<tr>
                	<td><a href="details.php"><img src="images/cart_thumb.gif" alt="" title="" border="0" class="cart_thumb" /></a></td>
                	<td>Gift flowers</td>
                    <td>100$</td>
                    <td>1</td>
                    <td>100$</td>               
                </tr>

                <tr>
                <td colspan="4" class="cart_total"><span class="red">TOTAL SHIPPING:</span></td>
                <td> 250$</td>                
                </tr>  
                
                <tr>
                <td colspan="4" class="cart_total"><span class="red">TOTAL:</span></td>
                <td> 325$</td>                
                </tr>                  
            
            </table>
            <a href="#" class="continue">&lt; continue</a>
            

             <!-- Order form -->
               <div class="form_subtitle">create new account</div>
                 <form name="register" action="#">          
                    <div class="form_row">
                    <label class="contact"><strong>Name:</strong></label>
                    <input type="text" class="contact_input" />
                    </div>  


                    <div class="form_row">
                    <label class="contact"><strong>Address:</strong></label>
                    <input type="text" class="contact_input" />
                    </div> 

                    <div class="form_row">
                    <label class="contact"><strong>Email:</strong></label>
                    <input type="text" class="contact_input" />
                    </div>


                    <div class="form_row">
                    <label class="contact"><strong>Phone:</strong></label>
                    <input type="text" class="contact_input" />
                    </div>
                    
                    <!-- Payment/Shipping is handled by paypal -->
                    <div class="form_row">
                   <a href="https://paypal.com/"> <img src="http://www.nittel.co.uk/images/paynow.png"> </a>
                    </div>                    

                    <div class="form_row">
                        <div class="terms">
                        <input type="checkbox" name="terms" />
                        I agree to the <a href="#">terms &amp; conditions</a>                        </div>
                    </div> 

                    
                    <div class="form_row">
                    <input type="submit" class="register" value="Pay Now" />
                    </div>   
                  </form>     
                
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