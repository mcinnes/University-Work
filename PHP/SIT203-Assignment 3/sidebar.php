<link href="css/search.css" rel="stylesheet" />

        <script type="text/javascript" src="scripts/jquery-1.8.2.min.js"></script>
        <script type="text/javascript" src="scripts/jquery.mockjax.js"></script>
        <script type="text/javascript" src="src/jquery.autocomplete.js"></script>
        <script type="text/javascript" src="scripts/countries.js"></script>
        <script type="text/javascript" src="scripts/demo.js"></script>

        <!-- Sidebar.php -->
<div class="languages_box">
            <span class="red">Languages:</span>
            
            <a href="#"><img src="images/au.gif" alt="" title="" border="0" height="12px" width="15px"/></a>
           
            </div>
                <div class="currency">
                <span class="red">Currency: </span>
                
                <a href="#" class="selected">AUD</a>
                </div>
                
                <!-- 
session_start(); 
if($_SESSION['logged']){ 
    echo 'Welcome, '.$_SESSION['username']; 
    print user name in sidebar
} 
?> -->


              <div class="cart">
                  <div class="title"><span class="title_icon"><img src="images/cart.gif" alt="" title="" /></span>My cart</div> 
                  <br>
                  <div class="home_cart_content">
                    <? echo writeShoppingCart(); ?>
                  </div>
              
              </div>
               


 
                <div class="title">Account</div> 
        <div class="user">
        <? 
          if (isset($_SESSION['loggedIn'])){
            echo "<h2>Welcome  ".$_SESSION['username'] . "</h2>";
            echo '<a href="logout.php"><input type="button" name="submit" value="Logout"></a><br>';
            echo "<br><br>";
          } else { 
            echo'
     <form action="login.php" method="post">
     <div class="form_row">
    User Name:
    <input type="text" name="uname"><br><br>
    </div>
         <div class="form_row">
    Password:
    <input type="password" name="pass"><br><br>
    </div>
             <div class="form_row">

    <input type="submit" name="submit" value="Login">
    </div>
</form>
<br> <br>';
          //echo "Welcome Guest!";
        }
      ?>
        </div>

                <div class="title">Search</div> 

       <div class="search">
 <form action="category.php" method="get">
            <input type="text" name="search" id="autocomplete-ajax" style="position: absolute; z-index: 2; background: white;"/>
                    <div id="selection"></div>  
            <input type="submit" value="Search">
  </form>
        </div>
        <br>
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
             </div> 
             <?
 function writeShoppingCart() {
  $cart = $_SESSION['cart'];
  if (!$cart) {
      return '<p>You have no items in your shopping cart</p>';
  } else {
    // Parse the cart session variable
    $items = explode(',',$cart);
    $s = (count($items) > 1) ? 's':'';
    return '<p>You have <a href="cart.php">'.count($items).' item'.$s.' in your shopping cart</a></p>';
  }
}
?>