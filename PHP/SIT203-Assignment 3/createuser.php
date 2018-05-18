<?
include'db.php';

$uname= strip_tags($_POST["username"]); //or $q=$_REQUEST["q"];
$pass= strip_tags($_POST["password"]); //or $q=$_REQUEST["q"];
$firstName= strip_tags($_POST["firstName"]); //or $q=$_REQUEST["q"];
$lastName= strip_tags($_POST["lastName"]); //or $q=$_REQUEST["q"];
$email = strip_tags($_POST["email"]);
$phone= strip_tags($_POST["number"]); //or $q=$_REQUEST["q"];
$address= strip_tags($_POST["address"]); //or $q=$_REQUEST["q"];

$salt = 'pepper';
$hashed_value = md5($salt.$pass);
echo $hashed_value;
//I know this is really bad but I couldnt get Oracle to CREATE SEQUENCE id START WITH 1; so this will have to do for now.
$ID = rand(10,25);

$query = "INSERT INTO Customers (ID, FIRSTNAME, LASTNAME, USERNAME, PASSWORD, ADDRESS, EMAIL, PHONE, ORDERS) VALUES ('$ID', '$firstName', '$lastName', '$uname', '$hashed_value', '$address', '$email', '$phone', '')";

$stmt = oci_parse($connect, $query);

if(!$stmt) {
echo "An error occurred in parsing the sql string.\n";
exit;
}

oci_execute($stmt);

// Close the connection
oci_close($connect); 




?>

