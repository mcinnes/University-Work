<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
<title>Flower Shop</title>
<link rel="stylesheet" type="text/css" href="style.css" /> 
   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>

<script type="text/javascript" src="http://lab.hasanaydogdu.com/validetta/demo/validetta/validetta.js"></script>
  <link href="src/validetta/validetta.min.css" rel="stylesheet" type="text/css" media="screen" >
<style>
            .form-group { position: relative; }
            .loading { display: none; position: absolute; bottom: 10px; left: 260px; }
            .validetta-pending > .loading { display:block; }
        </style>
</head>
<body>
<div id="wrap">

       <div class="header">
       	           <?php include 'header.php'; ?>
 
            
            
       </div> 
       
       
       <div class="center_content">
       	<div class="left_content">
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>Register</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
           Create and account to purchase items.
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">create new account</div>
                 <form id="exm1" method="POST" action="createuser.php">
    <div class="form_row">
        <label>First Name</label>
        <input type="text" name="firstName" data-validetta="required,remote[check_username]">
        <i class="loading fa fa-spinner fa-lg fa-spin"></i>

    </div>
    <div class="form_row">
        <label>Last Name</label>
        <input type="text" name="lastName" data-validetta="required,remote[check_username]">
        <i class="loading fa fa-spinner fa-lg fa-spin"></i>

    </div>
    <div class="form_row">
        <label>Phone Number :</label>
        <input type="text" name="number" data-validetta="number,required">
    </div>
    <div class="form_row">
        <label>Email :</label>
        <input type="text" name="email" data-validetta="email,required">
    </div>
     <div class="form_row">
        <label>Address :</label>
        <input type="text" name="address" data-validetta="email,required">
    </div>
     <div class="form_row">
        <label>Username :</label>
        <input type="text" name="username" data-validetta="required" />
    </div>
    <div class="form_row">
        <label>Password :</label>
        <input type="password" name="password" data-validetta="required" />
    </div>
    <div class="form_row">
        <label>Password again :</label>
        <input type="password" name="pwCheck" data-validetta="required" />
    </div>
   <br>
    <button type="submit">Submit</button>
    <button type="reset">Reset</button>
</form>  
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
<script>
        (function($){
            $('#exm').validetta({
                realTime : false,
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
        });
    </script>
</body>
</html>