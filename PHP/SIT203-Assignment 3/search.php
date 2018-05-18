<?php

include 'db.php';

//$searchQuery= $_POST["search"]; //or $q=$_REQUEST["q"];

$query ="SELECT * FROM Products WHERE NAME = 'Romantic Red and Pink Roses'";

/* check the sql statement for errors and if errors report them */
$stmt = oci_parse($connect, $query);

if(!$stmt) {
echo "An error occurred in parsing the sql string.\n";
exit;
}

oci_execute($stmt);

//echo oci_result($stmt, "Phone");
while(oci_fetch_array($stmt)) {
$fg1 = oci_result($stmt,"NAME");
//session_start();
$fg2 = oci_result($stmt,"DESCRIPTION");
$fg3 = oci_result($stmt,"ID");
$fg4 = oci_result($stmt,"PRICE");

echo $fg1; 
echo $fg2; 
echo $fg3; 
echo $fg4; 


}


// Close the connection
oci_close($connect); 


?>