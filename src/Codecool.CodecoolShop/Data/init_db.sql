DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS ProductCategory;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS OrderHistory;
DROP TABLE IF EXISTS OrderHistoryItemList;



CREATE TABLE Products
(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(255),
DefaultPrice DECIMAL (20,2),
Description TEXT,
ProductCategory TEXT,
Supplier TEXT
);

CREATE TABLE ProductCategory
(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name TEXT,
Department TEXT,
Description TEXT
);

CREATE TABLE Supplier
(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name TEXT,
Description TEXT
);

CREATE TABLE OrderHistory
(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Order_date DateTime,
Total_price DECIMAL(20,2)
);

CREATE TABLE OrderHistoryItemList
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Item_name TEXT,
	Item_Price DECIMAL(20,2),
	Quantity INT,
	Order_history_id INT
);


INSERT INTO Supplier VALUES ('Malm', 'Beds, desks and drawers.');
INSERT INTO Supplier VALUES ('Kallax', 'Lamps and shelves.');
INSERT INTO Supplier VALUES ('Dekad', 'Alarm clocks.');
INSERT INTO Supplier VALUES ('Lack', 'BDesks and shelves.');
INSERT INTO Supplier VALUES ('Strandomon', 'Comfort armchair.');
INSERT INTO Supplier VALUES ('Nolmyra', 'Armchairs, cabinets.');
INSERT INTO Supplier VALUES ('Hektar', 'Lamp and office chairs.');
INSERT INTO Supplier VALUES ('Markus', 'Office chairs.');


INSERT INTO ProductCategory VALUES ('Lamp', 'Bedroom', 'It is a lamp.');
INSERT INTO ProductCategory VALUES ('Bed', 'Bedroom', 'It is a bed.');
INSERT INTO ProductCategory VALUES ('Drawer', 'Bedroom', 'it is a drawer.');
INSERT INTO ProductCategory VALUES ('Wardrobe', 'Bedroom', 'it is a wardrobe.');
INSERT INTO ProductCategory VALUES ('Alarm clock', 'Bedroom', 'It is an alarm clock.');
INSERT INTO ProductCategory VALUES ('Bedsidetable', 'Bedroom', 'It is a bedsidetable.');
INSERT INTO ProductCategory VALUES ('Desk', 'Office', 'It is a desk.');
INSERT INTO ProductCategory VALUES ('Office chair', 'Office', 'It is an office chair');
INSERT INTO ProductCategory VALUES ('Desk', 'Livingroom', 'It is a desk.');
INSERT INTO ProductCategory VALUES ('Shelf', 'Livingroom', 'It is a shelf.');
INSERT INTO ProductCategory VALUES ('Armchair', 'Livingroom', 'It is an armchair');
INSERT INTO ProductCategory VALUES ('Cabinet', 'Livingroom', 'It is an cabinet');

INSERT INTO Products VALUES ('Dekad alarm clock', 2990, 'This little white clock will wake you up every morning.', 'BAlarmClock', 'dekad');
INSERT INTO Products VALUES ('Kallax lamp', 11990, 'This nice Kallax lamp will be lighten up your room.', 'BLamp', 'kallax');
INSERT INTO Products VALUES ('Kallax wardrobe', 16990, 'You can store many clothes in this wardrobe.', 'BWardrobe', 'kallax');
INSERT INTO Products VALUES ('Malm bed', 109990, 'This bed has a storage under the matress.', 'BBed', 'malm');
INSERT INTO Products VALUES ('Malm bedsidetable', 10900, 'A perfect match for your Malm bed.', 'BBedsidetable', 'malm');
INSERT INTO Products VALUES ('Malm drawer', 24990, 'You can store your favourite clothes in it.', 'BDrawer', 'malm');
INSERT INTO Products VALUES ('"Lack desk', 15990, 'You can even store your favourite magazines on it.', 'LDesk', 'lack');
INSERT INTO Products VALUES ('Lack shelf', 5990, 'A floating shelf, perfect match for your Lack desk.', 'LShelf', 'lack');
INSERT INTO Products VALUES ('Nolmyra cabinet', 24990, 'Nice looking cabinet into your livingroom.', 'LCabinet', 'nolmyra');
INSERT INTO Products VALUES ('Strandomon armchair', 59990, 'A yellow, comfortable armchair to your livingroom.', 'LArmChair', 'strandomon');
INSERT INTO Products VALUES ('Hektar lamp', 12990, 'Low-energy lamp with bright light.', 'OLamp', 'hektar');
INSERT INTO Products VALUES ('Kallax desk', 39990, 'A nice looking desk with shelves.', 'ODesk', 'kallax');
INSERT INTO Products VALUES ('Markus office chair', 29990, 'Our most popular office chair.', 'Ochair', 'markus');
INSERT INTO Products VALUES ('Hektar office chair', 39990, 'Comfortable officechair to your home.', 'Ochair', 'hektar');
INSERT INTO Products VALUES ('Malm desk', 22990, 'A big office desk, which can boost your productivity.', 'Ochair', 'malm');


SELECT * FROM Products;
SELECT * FROM Supplier;
SELECT * FROM OrderHistory;
SELECT * FROM OrderHistoryItemList;