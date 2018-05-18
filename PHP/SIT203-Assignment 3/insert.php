
<?
include 'db.php';
$args = array(
  array('ID' => '0','NAME' => 'All things Bright and Beautiful','DESCRIPTION' => 'Bright yellow Sunflowers with seasonal flowers in a glass vase.  This arrangement brings a smile to any face and is seasonal and will be changed to suit the season.','PRICE' => '85','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '0','NAME' => 'All things Bright and Beautiful','DESCRIPTION' => 'Bright yellow Sunflowers with seasonal flowers in a glass vase.  This arrangement brings a smile to any face and is seasonal and will be changed to suit the season.','PRICE' => '85','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '1','NAME' => 'Bright Basket of Spring Flowers','DESCRIPTION' => 'Bright boquet of yellow Spring flowers, perfect to brighten any room.','PRICE' => '65','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '2','NAME' => 'Bright Orange Roses','DESCRIPTION' => 'This Bright Orange pot of roses are a special surprise for that really special someone.','PRICE' => '85','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '3','NAME' => 'Romantic Red and Pink Roses','DESCRIPTION' => 'This Wonderful gift of Red and Pink Roses is available anytime of year and is a Stunning arrangement, especially with a glass vase making it the ultimate gift.','PRICE' => '125','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '4','NAME' => 'Roses and Tulips in a Basket','DESCRIPTION' => 'This bouquet of Roses and Tulips in a basket comes with a soft green frame, (basket may be of a different colour).','PRICE' => '75','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '5','NAME' => 'Mixed Bunch Hydrangeas','DESCRIPTION' => 'Hydrangeas are lush and wonderful and are available in a mixed bunch of blue, pink and green tones.  This arrangement is seasonal and comes with a soft green frame.  A vase can be included to give the ultimate gift.','PRICE' => '75','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '6','NAME' => 'A Dozen Red Roses','DESCRIPTION' => 'A dozen Red Roses is the Perfect gift for your loved one or that Special Someone.  This bouquet comes with a soft green frame and a vase can be included to give the ultimate gift..','PRICE' => '75','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0'),
  array('ID' => '7','NAME' => 'Orchid Extravaganza','DESCRIPTION' => 'This Wonderful bouquet is designed with Premium Flowers to dazzle and delight and arrives beautifully gift wrapped.  Orchids and roses makes a a wonderful gift for any occasion and are available any time of year. A vase can be included to give the ultimat','PRICE' => '75','PHOTO' => '0','STOCK_LEVEL' => '0','WEIGHT' => '0')
);

?>
<?
$i=0; $keys=''; $vals='';
foreach ($args as $key => $value) {
       if($i==0){
         $keys .= ''.$key;
         $vals .= ':'.$key;
       }
       $keys .= ', '.$key;
       $vals .= ', :'.$key;
       $i++;
 }
$sql = 'INSERT INTO '. 'Products' .' ('.$keys.') VALUES ('.$vals.') ';
$stmt = oci_parse($connect, $sql);
foreach ($args as $key => $value) {
      oci_bind_by_name($stmt, $key, $args[$key]) ;
    }
oci_execute($stmt);
?>