USE master
GO

IF EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'BurgerShop'
)
DROP DATABASE BurgerShop

-------------------------------------------------------

IF EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'BurgerShop'
)
-- if you are not able to drop your DB,
--   use this:
ALTER DATABASE BurgerShop
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO


-------------------------------------------------------

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'BurgerShop')
CREATE DATABASE BurgerShop
GO


USE BurgerShop
GO

-------------------------------------------------------
-- Drop all tables --
IF OBJECT_ID('Customer','U') IS NOT NULL
DROP TABLE Customer
GO

IF OBJECT_ID('Branch','U') IS NOT NULL
DROP TABLE Branch
GO

IF OBJECT_ID('FoodOrder','U') IS NOT NULL
DROP TABLE FoodOrder
GO

IF OBJECT_ID('OrderBurger','U') IS NOT NULL
DROP TABLE OrderBurger
GO

IF OBJECT_ID('Burger','U') IS NOT NULL
DROP TABLE Burger
GO

IF OBJECT_ID('OrderExtra','U') IS NOT NULL
DROP TABLE OrderExtra
GO

IF OBJECT_ID('Extra','U') IS NOT NULL
DROP TABLE Extra
GO

IF OBJECT_ID('OrderSide','U') IS NOT NULL
DROP TABLE OrderSide
GO

IF OBJECT_ID('Side','U') IS NOT NULL
DROP TABLE Side
GO

-------------------------------------------------------
CREATE TABLE Customer(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	fname nvarchar(50),
	lname nvarchar(50),
	phone nvarchar(15),
	email nvarchar(50),
	bdate date DEFAULT CONVERT(DATE, GETDATE(),105) -- 14-05-1998
)

CREATE TABLE Branch(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	branchName nvarchar(50) unique,
	street nvarchar(50),
	houseNum int,
	city nvarchar(50),
	phone nvarchar(15),
	openingHrs nvarchar(50)
)


CREATE TABLE Extra(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	mealName NVARCHAR(50),
	mealDescription nvarchar(50),
	imageFileName  nvarchar(200),
	price float,
	calories int
)

CREATE TABLE Side(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	mealName NVARCHAR(50),
	mealDescription nvarchar(50),
	imageFileName  nvarchar(200),
	price float,
	calories int
)

CREATE TABLE FoodOrder(
	 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	customerId int FOREIGN KEY REFERENCES Customer(id),
	orderDate date DEFAULT CONVERT(DATE, GETDATE(),105)
)

CREATE TABLE Burger(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	mealName NVARCHAR(50),
	mealDescription nvarchar(50),
	imageFileName  nvarchar(200),
	price float,
	calories int
)

CREATE TABLE OrderBurger(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	burgerId int FOREIGN KEY REFERENCES Burger(id),
	orderId int FOREIGN KEY REFERENCES FoodOrder(id)
)


CREATE TABLE OrderExtra(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	extraId int FOREIGN KEY REFERENCES Extra(id),
	OrderBurgerId int FOREIGN KEY REFERENCES OrderBurger(id)
)

CREATE TABLE OrderSide(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	sideId int FOREIGN KEY REFERENCES Side(id),
	orderId int FOREIGN KEY REFERENCES FoodOrder(id)
)

-------------------------------------------------------------------

--SELECT prodName, 
--		ProductCategory.categoryName,
--			 prodDescription, imageFileName, price, calories
--FROM Product RIGHT JOIN ProductCategory
--      ON Product.prodCategory = ProductCategory.id




INSERT INTO Customer VALUES
('John', 'Doe', '052-3456677', 'jd@gmail.com','1998-03-21'),
('Kate', 'Klein', '052-3456677', 'kk@gmail.com', '2001-05-15'),
('Mike', 'Shoval', '052-3456677', 'ms@gmail.com', '2002-07-21' ),
('Inbal', 'Doe', '052-3456677', 'id@gmail.com', '1999-09-30'),
('Liat', 'Doron', '052-3456677', 'ld@gmail.com', '1993-08-24');
select * from Customer



--------------
INSERT INTO Burger VALUES
('small', '160g', 'https://onmykidsplate.com/wp-content/uploads/2020/01/Healthy-Beef-and-Veggie-Burgers-photo-2-500x375.jpg', 40,400),
('medium', '220g', 'https://wolt-menu-images-cdn.wolt.com/menu-images/619cf1f2758322d938b2e9c8/4dbe4dfe-5280-11ec-898b-f60760ca887c_fto04646.jpeg', 50,600),
('large', '440g', 'https://groundbeefrecipes.com/wp-content/uploads/double-bacon-cheeseburger-recipe-6.jpg', 60,800);


select * from Burger

--------

--------------
INSERT INTO Side VALUES
('chips', 'yay', 'https://www.thespruceeats.com/thmb/fFY-wqOwGKO16rTH8YwdnSUWoNQ=/2667x2667/smart/filters:no_upscale()/best-twice-cooked-chip-recipe-434891-hero-01-5d90eb5142b042e1b71e2c3bcce9c5c9.jpg', 20,50),
('onion', 'round', 'https://www.mashed.com/img/gallery/crispy-fried-onion-rings-recipe/l-intro-1652370714.jpg', 25,60),
('nuggets', 'chickken', 'https://bakeitwithlove.com/wp-content/uploads/2021/05/Air-Fryer-Chicken-Nuggets-sq.jpg', 30,70),
('pera', 'not healty', 'https://heninthekitchen.com/wp-content/uploads/2020/11/IMG_8060-2small.jpg', 15,70),
('zero cola', 'not healty eather', 'https://www.foodbusinessnews.net/ext/resources/2019/10/CokeZeroSugarMini_Embedded.jpg', 15,1);


select * from Side


--------------
INSERT INTO Extra VALUES
('cheese', 'creamy', 'https://media.istockphoto.com/photos/the-cheddar-cheese-picture-id685847528', 8,30),
('ham', 'not cosher', 'https://media02.stockfood.com/largepreviews/NDI1NTk1OQ==/00137289-Slice-of-Ham.jpg', 10,27),
('tomato', 'its a tomato', 'https://media.istockphoto.com/photos/tomato-slice-isolated-on-white-background-picture-id1181261144', 5,10),
('letter', 'its a leter', 'https://thumbs.dreamstime.com/b/green-leaf-lettuce-9069329.jpg', 2,1);


select * from Extra

--------------

INSERT INTO FoodOrder VALUES
(1, '2011-01-1'),
(3, '2012-02-2'),
(3, '2013-03-3');

select * from FoodOrder

--------------

INSERT INTO OrderSide VALUES
(1,1),
(2,1),
(2,2);

select * from OrderSide
--------------


INSERT INTO OrderBurger VALUES
(1,1),
(2,1),
(2,2);

select * from OrderBurger


INSERT INTO OrderExtra VALUES
(1,1),
(2,1),
(2,2);

select * from OrderExtra
--------------

INSERT INTO Branch VALUES
('hot burgers','haarbaah',2,'tel-aviv','0548879522','10:00-22:00'),
('hot hot burgers','haborsa',2,'tel-aviv','0548879522','10:00-22:00');

SELECT * FROM Branch

