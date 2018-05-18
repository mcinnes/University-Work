<?
session_start();
  //$_SESSION['cart'] = '';


$cart = $_SESSION['cart'];
$action = $_GET['action'];
switch ($action) {
  case 'add':
    if ($cart) {
      $cart .= ','.$_GET['id'];
    } else {
      $cart = $_GET['id'];
    }
    break;
  case 'delete':
    if ($cart) {
      $items = explode(',',$cart);
      $newcart = '';
      foreach ($items as $item) {
        if ($_GET['id'] != $item) {
          if ($newcart != '') {
            $newcart .= ','.$item;
          } else {
            $newcart = $item;
          }
        } //end of if
      } //end of foreach
      $cart = $newcart;
    }//end of if
    break;
}//end of switch
$_SESSION['cart'] = $cart;


?>