<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />
<script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
<div id="wrap">

       <div class="header">
        <?php include 'header.php'; ?>
        </div>  
       
       
       <div class="center_content">
       	<div class="left_content">
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>Contact Us</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
             Please contact us if you have any queries about our store and our products.
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">All fields are required</div>          
                    <div class="form_row">
                    <label class="contact"><strong>Name:</strong></label>
                    <input type="text" name="name" class="contact_input" />
                    </div>  

                    <div class="form_row">
                    <label class="contact"><strong>Email:</strong></label>
                    <input type="text" name="email" class="contact_input" />
                    </div>


                    <div class="form_row">
                    <label class="contact"><strong>Phone:</strong></label>
                    <input type="text" name="phone" class="contact_input" />
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>Company:</strong></label>
                    <input type="text" name="company" class="contact_input" />
                    </div>


                    <div class="form_row">
                    <label class="contact"><strong>Message:</strong></label>
                    <textarea class="contact_textarea" name="message" ></textarea>
                    </div>

                    <div class="form_row">
                    <div class="g-recaptcha" data-sitekey="6LeLPwgUAAAAAIZVnrYgEhBcZanTuh5eB06dLMVx"></div>
                    </div>
                    
                    <div class="form_row">
                    <a href="#" class="contact">Send</a>                    </div>      
                </div>  
            
          </div>	
            
              

            

            
        <div class="clear"></div>
        </div><!--end of left content-->
        
        <div class="right_content">
        
                	<div class="languages_box">
            <span class="red">Languages:</span>
            <a href="#"><img src="images/au.gif" alt="" title="" border="0" height="12px" width="15px"/></a>
            <!-- commented by Shang 09/07/2013 
            <a href="#" class="selected"><img src="images/gb.gif" alt="" title="" border="0" /></a>
            <a href="#"><img src="images/de.gif" alt="" title="" border="0" /></a> -->
            </div>
                <div class="currency">
                <span class="red">Currency: </span>
                <!-- commented by shang 09/07/2013 
                <a href="#">GBP</a>
                <a href="#">EUR</a> -->
                <a href="#" class="selected">AUD</a>
                </div>
                
              <div class="cart">
                  <div class="title"><span class="title_icon"><img src="images/cart.gif" alt="" title="" /></span>My cart</div>
                  <div class="home_cart_content">
                  3 x items | <span class="red">TOTAL: 100$</span>
                  </div>
                  <a href="cart.php" class="view_cart">view cart</a>
              
              </div>
        
             <div class="title"><span class="title_icon"><img src="images/bullet3.gif" alt="" title="" /></span>About Our Shop</div> 
             <div class="about">
             <p>
             <img src="images/about.gif" alt="" title="" class="right" />
             Flowershop has quickly become renowned as one of Geelong's most prestigious and luxurious retail flower stores, and this has been successfully translated to our online flower shop. The same service, quality and range we provide to our retail shoppers is also extended to our online community. <!-- reference: Flower Temple, availalbe at <http://www.flowertemple.com.au/aboutflowertemple.aspx>, accessed 09/07/2013)-->  
             </p>
             
             </div>
             
             <div class="right_box">
             
             <div class="title"><span class="title_icon"><img src="images/bullet4.gif" alt="" title="" /></span>Promotions</div> 
                    <div class="new_prod_box">
                        <a href="details.php">Bright Basket of Spring Flowers</a>
                        <div class="new_prod_bg">
                        <span class="new_icon"><img src="images/promo_icon.gif" alt="" title="" /></span>
                        <a href="details.php"><img src="images/flowers/flower2.jpg" alt="" title="" class="thumb" border="0" width="88" height="96"/></a>
                        </div>           
                    </div>
                    
                    <div class="new_prod_box">
                        <a href="details.php">Romantic Red and Pink Roses</a>
                        <div class="new_prod_bg">
                        <span class="new_icon"><img src="images/promo_icon.gif" alt="" title="" /></span><a href="details.php"><img src="images/flowers/flower4.jpg" alt="" title="" class="thumb" border="0" width="88" height="96"/></a></div>           
                    </div>                    
                                           
                    
                    <!-- commented by Shang 09/07/2013 
                    <div class="new_prod_box">
                        <a href="details.php">product name</a>
                        <div class="new_prod_bg">
                        <span class="new_icon"><img src="images/promo_icon.gif" alt="" title="" /></span>
                        <a href="details.php"><img src="images/thumb3.gif" alt="" title="" class="thumb" border="0" /></a>
                        </div>           
                    </div> -->                
             
             </div>
             
             <div class="right_box">
             
             	<div class="title"><span class="title_icon"><img src="images/bullet5.gif" alt="" title="" /></span>Categories</div> 
                
                <ul class="list">
                <li><a href="#">accesories</a></li>
                <li><a href="#">flower gifts</a></li>
                <li><a href="#">specials</a></li>
                <li><a href="#">hollidays gifts</a></li>
                <li><a href="#">accesories</a></li>
                <li><a href="#">flower gifts</a></li>
                <li><a href="#">specials</a></li>
                <li><a href="#">hollidays gifts</a></li>
                <li><a href="#">accesories</a></li>
                <li><a href="#">flower gifts</a></li>
                <li><a href="#">specials</a></li>                                              
                </ul>
                
             	<!-- commented by Shang 09/07/2013 
             	<div class="title"><span class="title_icon"><img src="images/bullet6.gif" alt="" title="" /></span>Partners</div> 
                
                <ul class="list">
                <li><a href="#">accesories</a></li>
                <li><a href="#">flower gifts</a></li>
                <li><a href="#">specials</a></li>
                <li><a href="#">hollidays gifts</a></li>
                <li><a href="#">accesories</a></li>
                <li><a href="#">flower gifts</a></li>
                <li><a href="#">specials</a></li>
                <li><a href="#">hollidays gifts</a></li>
                <li><a href="#">accesories</a></li>                              
                </ul>  -->     
             
             </div>         
             
        
        </div><!--end of right content-->
        
        
       
       
       <div class="clear"></div>
       </div><!--end of center content-->
       
              
       <div class="footer">
                <?php include 'footer.php'; ?>

       
       </div>
    

</div>

</body>
</html>