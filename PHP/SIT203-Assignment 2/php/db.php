<?php

/*
The database table we use in this example looks like this:
id FirstName LastName Age Hometown Job
1 Mary Doss 42 Geelong High school teacher
2 Robert Dew 40 Newport Piano Teacher
3 Justin Rough 34 Geelong University Lecturer
*/

$uname=$_POST["uname"]; //or $q=$_REQUEST["q"];
$pass=$_POST["pass"]; //or $q=$_REQUEST["q"];

/* Set oracle user login and password info */
$dbuser = ""; /* your deakin login */
$dbpass = ""; /* your oracle access password */
$db = "SSID";
$connect = oci_connect($dbuser, $dbpass, $db);

if (!$connect) {
echo "An error occurred connecting to the database";
exit;
}

/* build sql statement using form data */
$query ="SELECT * FROM Customers WHERE USERNAME = '$uname'";

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

$_SESSION['username'] = $fg1; 
}


// Close the connection
oci_close($connect); 
?>