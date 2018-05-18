CREATE TABLE products (
  ID number(10) NOT NULL,
  NAME varchar2(255) NOT NULL,
  DESCRIPTION varchar2(255) NOT NULL,
  PRICE binary_double NOT NULL,
  PHOTO number(10) NOT NULL,
  STOCK_LEVEL number(10) NOT NULL,
  WEIGHT binary_double NOT NULL
) ;

--
-- Dumping data for table `products`
--

INSERT INTO products (ID, NAME, DESCRIPTION, PRICE, PHOTO, STOCK_LEVEL, WEIGHT)
 SELECT 0, 'All things Bright and Beautiful', 'Bright yellow Sunflowers with seasonal flowers in a glass vase.  This arrangement brings a smile to any face and is seasonal and will be changed to suit the season.', 85, 0, 0, 0 FROM dual UNION ALL 
 SELECT 0, 'All things Bright and Beautiful', 'Bright yellow Sunflowers with seasonal flowers in a glass vase.  This arrangement brings a smile to any face and is seasonal and will be changed to suit the season.', 85, 0, 0, 0 FROM dual UNION ALL 
 SELECT 1, 'Bright Basket of Spring Flowers', 'Bright boquet of yellow Spring flowers, perfect to brighten any room.', 65, 0, 0, 0 FROM dual UNION ALL 
 SELECT 2, 'Bright Orange Roses', 'This Bright Orange pot of roses are a special surprise for that really special someone.', 85, 0, 0, 0 FROM dual UNION ALL 
 SELECT 3, 'Romantic Red and Pink Roses', 'This Wonderful gift of Red and Pink Roses is available anytime of year and is a Stunning arrangement, especially with a glass vase making it the ultimate gift.', 125, 0, 0, 0 FROM dual UNION ALL 
 SELECT 4, 'Roses and Tulips in a Basket', 'This bouquet of Roses and Tulips in a basket comes with a soft green frame, (basket may be of a different colour).', 75, 0, 0, 0 FROM dual UNION ALL 
 SELECT 5, 'Mixed Bunch Hydrangeas', 'Hydrangeas are lush and wonderful and are available in a mixed bunch of blue, pink and green tones.  This arrangement is seasonal and comes with a soft green frame.  A vase can be included to give the ultimate gift.', 75, 0, 0, 0 FROM dual UNION ALL 
 SELECT 6, 'A Dozen Red Roses', 'A dozen Red Roses is the Perfect gift for your loved one or that Special Someone.  This bouquet comes with a soft green frame and a vase can be included to give the ultimate gift..', 75, 0, 0, 0 FROM dual UNION ALL 
 SELECT 7, 'Orchid Extravaganza', 'This Wonderful bouquet is designed with Premium Flowers to dazzle and delight and arrives beautifully gift wrapped.  Orchids and roses makes a a wonderful gift for any occasion and are available any time of year. A vase can be included to give the ultimat', 75, 0, 0, 0 FROM dual;

CREATE TABLE orders (
  ID number(10) NOT NULL,
  userID number(10) NOT NULL,
  products varchar2(255) NOT NULL,
  date varchar2(255) NOT NULL
) ;

--
-- Dumping data for table `orders`
--

INSERT INTO orders (ID, userID, products, date)
 SELECT 1, 1, '1,1,1,2,3,4,7,6', '1474513861' FROM dual UNION ALL 
 SELECT 2, 1, '1,3,4,3,2,1', '1474769332' FROM dual;

//Unable to Dump the customers table.