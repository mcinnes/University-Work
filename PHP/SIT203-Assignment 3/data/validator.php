<?php

$response = array( 'valid' => false, 'message' => 'Sorry, Something went wrong!');
if( isset($_POST['username']) ) {

  if ( $_POST['username'] !== 'validetta' ) {
    $response = array( 'valid' => false, 'message' => 'This username is already taken!' );
  } else {
    $response = array( 'valid' => true );
  }

}
echo json_encode($response);; 

?>