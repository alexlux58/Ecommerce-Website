IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'EMedicine')
BEGIN
    CREATE DATABASE EMedicine;
END;

USE EMedicine;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users(
	ID INT IDENTITY(1,1) PRIMARY KEY, 
	FirstName VARCHAR(100), 
	LastName VARCHAR(100), 
	Password VARCHAR(100), 
	Email VARCHAR(100), 
	Fund DECIMAL(18,2),
	Type VARCHAR(100),
	Status INT,
	CreatedOn Datetime);
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicines]') AND type in (N'U'))
BEGIN
	CREATE TABLE Medicines(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100),
	Manufacturer VARCHAR(100),
	UnitPrice DECIMAL(18,2),
	Discount DECIMAL(18,2),
	Quantity INT,
	ExpDate Datetime,
	ImageUrl VARCHAR(100),
	Status INT);
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cart]') AND type in (N'U'))
BEGIN				
	CREATE TABLE Cart(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT,
	MedicineID INT,
	UnitPrice DECIMAL(18,2),
	Discount DECIMAL(18,2),
	Quantity INT,
	TotalPrice DECIMAL(18,2));
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
	CREATE TABLE Orders(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	UserID INT,
	OrderNo VARCHAR(100),
	OrderTotal DECIMAL(18,2),
	OrderStatus VARCHAR(100));
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type in (N'U'))
BEGIN
	CREATE TABLE OrderItems(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	OrderID INT,
	MedicineID INT,
	UnitPrice DECIMAL(18,2),
	Discount DECIMAL(18,2),
	Quantity INT,
	TotalPrice DECIMAL(18,2));
END;

SELECT * FROM Users;
SELECT * FROM Medicines;
SELECT * FROM Cart;
SELECT * FROM Orders;
SELECT * FROM OrderItems;