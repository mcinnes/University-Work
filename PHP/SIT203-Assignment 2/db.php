<?php

/*
The database table we use in this example looks like this:
id FirstName LastName Age Hometown Job
1 Mary Doss 42 Geelong High school teacher
2 Robert Dew 40 Newport Piano Teacher
3 Justin Rough 34 Geelong University Lecturer
*/



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
//$query ="SELECT * FROM Customers WHERE USERNAME = '$uname' AND PASSWORD = '$pass'";


?>