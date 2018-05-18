<?php

include 'db.php';

$uname=$_POST["uname"]; //or $q=$_REQUEST["q"];
$pass=$_POST["pass"]; //or $q=$_REQUEST["q"];

$query ="SELECT * FROM Customers WHERE USERNAME = '$uname' AND PASSWORD = '$pass'";

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
$_SESSION['loggedIn'] = true;
header('Location: ../ass1.php');
echo $fg1; 


}


// Close the connection
oci_close($connect); 


?>