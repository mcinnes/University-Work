<?php
session_start();
include 'db.php';

$uname= strip_tags($_POST["uname"]); //or $q=$_REQUEST["q"];
$pass= strip_tags($_POST["pass"]); //or $q=$_REQUEST["q"];

$salt = 'pepper';
$hashed_value = md5($salt.$pass);

$query ="SELECT * FROM Customers WHERE USERNAME = '$uname' AND PASSWORD = '$hashed_value'";

/* check the sql statement for errors and if errors report them */
$stmt = oci_parse($connect, $query);

if(!$stmt) {
echo "An error occurred in parsing the sql string.\n";
exit;
}

oci_execute($stmt);

//echo oci_result($stmt, "Phone");
while(oci_fetch_array($stmt)) {
$fg1 = oci_result($stmt,"USERNAME");
//session_start();

$_SESSION['username'] = $fg1;
$_SESSION['email'] = oci_result($stmt,"EMAIL");
$_SESSION['phone'] = oci_result($stmt,"PHONE");
$_SESSION['address'] = oci_result($stmt,"ADDRESS");
$_SESSION['loggedIn'] = true;
$_SESSION['id'] = oci_result($stmt,"ID");
header('Location: ' . $_SERVER['HTTP_REFERER'] );

}


// Close the connection
oci_close($connect); 


?>