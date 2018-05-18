<? session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" />
<script type="text/javascript" src="src/validetta/validetta.js"></script>
  <link href="src/validetta/validetta.css" rel="stylesheet" type="text/css" media="screen" >
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
 <style>
        .demo-container {
            width: 100%;
            max-width: 350px;
            margin: 50px auto;

        form {
            margin: 30px;
        }
        input {
            width: 200px;
            margin: 10px auto;
            display: block;
        }
        }
 </style>
</head>
<body>
<div id="wrap">

       <div class="header">
       	           <?php include 'header.php'; ?>
 
            
            
       </div> 
       
       
       <div class="center_content">
       	<div class="left_content">
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>Checkout</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
            
            </p>
            
              <div class="contact_form">
                <div class="form_subtitle">Enter Billing Details</div>
                 <form id="exm1" method="POST" action="order.php">
    <div class="form_row">
        <label>Name</label>
        <input type="text" name="name" value="<? if ($_SESSION['loggedIn']) { echo $_SESSION['username'];} ?>" data-validetta="required">
    </div>
    <div class="form_row">
        <label>Phone Number:</label>
        <input type="text" name="number" value="<? if ($_SESSION['loggedIn']) { echo $_SESSION['phone'];} ?>" data-validetta="number,required">
    </div>
    <div class="form_row">
        <label>Billing Address:</label>
        <input type="text" name="billing" value="<? if ($_SESSION['loggedIn']) { echo $_SESSION['address'];} ?>" data-validetta="required">
    </div>
    <div class="form_row">
        <label>Shipping address same as Billing Address:</label>
        <input type="checkbox" name="sameShipping" data-validetta="optional">
    </div>
    <div class="form_row">
        <label>Email:</label>
        <input type="text" name="email" value="<? if ($_SESSION['loggedIn']) { echo $_SESSION['email'];} ?>" data-validetta="email,required">
    </div>
    <div class="form_row">
        <label>Comments:</label>
        <textarea name="exm-txt" data-validetta="required"></textarea>
    </div>
</form>  
                </div>  
            
          </div>	
            
        <div class="contact_form">
          <div class="form_subtitle">Enter Payment Details</div>

<div class="demo-container">
        <div class="card-wrapper"></div>

        <div class="form-container active">
            <form  id="cardForm" action="">
                <div class="form_row">
                <label>Card Number:</label>
                <input placeholder="Card number" type="text" name="number">
                </div>
                <div class="form_row">
                <label>Full Name:</label>
                <input placeholder="Full name" type="text" name="name">
                </div>
                <div class="form_row">
                <label>Expiry Date:</label>
                <input placeholder="MM/YY" type="text" name="expiry">
                </div>
                <div class="form_row">
                <label>CVC:</label>
                <input placeholder="CVC" type="text" name="cvc">
                </div>
            </form>
        </div>
    </div>
    <button type="submit" onclick="replaceDiv()">Submit</button>

          </div>

            
<!-- if not logged in then make them register, save order in single col, dateinseconds.1,3,2,3,3,3,3/dateinseconds.2.2.2.2.1.1/ -->
            
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
    <script src="src/card.js"></script>

<script>
        new Card({
            form: document.getElementById('cardForm'),
            container: '.card-wrapper'
        });
    </script>
<script type="text/javascript">
(function($){
    $('#exm1').validetta({
        realTime : true,
        onValid : function( event ){
            event.preventDefault(); // if you dont break submit and if form doesnt have error, page will post
            alert('Success');
        },
        validators: {
            remote : {
                check_username : {
                    type : 'POST',
                    url : 'data/validator.php',
                    datatype : 'json'
                }
            }
        }
    });
});</script>
</body>
</html>