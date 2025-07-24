Create database OOP

use OOP;

CREATE TABLE Roles
(
    RoleID nvarchar(50) PRIMARY KEY not null,
    RoleName VARCHAR(50) NOT NULL
);

CREATE TABLE Users(
    UserID nvarchar(50) PRIMARY KEY Not Null,
    Username VARCHAR(50) NOT NULL,
    Passwords VARCHAR(50) NOT NULL,
    RoleID  nvarchar(50) FOREIGN KEY REFERENCES Roles(RoleID),
    EmailAddress nVARCHAR(100),
    ContactNo nVARCHAR(15),
);

CREATE TABLE MenuCategory 
(
    CategoryID nvarchar(50) PRIMARY KEY not null,
    [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE MenuItems 
(
    ItemID nvarchar(50) PRIMARY KEY not null,
    CategoryID nvarchar(50) FOREIGN KEY REFERENCES MenuCategory(CategoryID),
    ChefID nvarchar(50) FOREIGN KEY REFERENCES Users(UserID),
    [Name] VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2),
    IsAvailable Bit,
);
ALTER TABLE MenuItems
ALTER COLUMN IsAvailable NVARCHAR(50);
CREATE TABLE Orders 
(
    OrderID nvarchar(50) PRIMARY KEY not null,
    CustomerID nvarchar(50) FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    OrderStatus VARCHAR(50) DEFAULT 'In Progress',
);



CREATE TABLE OrderItems 
(
    OrderItemID nvarchar(50) PRIMARY KEY not null,
    OrderID nvarchar(50) FOREIGN KEY REFERENCES Orders(OrderID),
    ItemID nvarchar(50) FOREIGN KEY REFERENCES MenuItems(ItemID),
    Quantity INT,
);

CREATE TABLE Refund 
(
    RefundID nvarchar(50) PRIMARY KEY not null,
    OrderID nvarchar(50) FOREIGN KEY REFERENCES Orders(OrderID),
    UserID nvarchar(50) FOREIGN KEY REFERENCES Users(UserID),
    [Status] VARCHAR(50) DEFAULT 'Pending',
    RequestDate DATE,
	TotalAmount DECIMAL(10,2),
);


CREATE TABLE Feedback 
(
    FeedbackID NVARCHAR(50) PRIMARY KEY not null,
    UserID NVARCHAR(50) FOREIGN KEY REFERENCES Users(UserID),
    Feedback NVARCHAR(MAX),
    [Date] DATE,
    Response NVARCHAR(MAX),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
);
ALTER TABLE Feedback
ALTER COLUMN Response VARCHAR(255) NULL;

CREATE TABLE EWallet 
(
    WalletID NVARCHAR(50) PRIMARY KEY not null,
    Balance DECIMAL(10, 2),
    UserID NVARCHAR(50) FOREIGN KEY REFERENCES Users(UserID),
);

CREATE TABLE EWalletTransactions 
(
    TransactionID NVARCHAR(50) PRIMARY KEY not null,
    WalletID NVARCHAR(50) FOREIGN KEY REFERENCES EWallet(WalletID),
    [Type] NVARCHAR(50),
    Amount DECIMAL(10, 2),
    TransactionDate DATE,
);
INSERT INTO Roles("RoleID", "RoleName") VALUES
('R01', 'Admin'),
('R02', 'Manager'),
('R03', 'Chef'),
('R04', 'Customer');


INSERT into Users("UserId","Username","Passwords","RoleID","EmailAddress","ContactNo")values
('U001','dcs','admin0907','R01','dcs5577@mail.com','0129229218'),
('U002','cch','cch0054','R02','cch@mail.com','019221297'),
('U003','CheFie','Fie123','R03','chefie0@mail.com','0102287613'),
('U004','Kula','kula012','R04','kUla00@mail.com','0145890123'),
('U005','Ilio','lio771','R04','lio0771@mail.com','0129876121'),
('U006','Mira','mira123','R04','mira123@mail.com','0172345678'),
('U007','Tariq','tariq789','R04','tariq789@mail.com','0163456789'),
('U008','Lena','lena456','R04','lena456@mail.com','0154567890'),
('U009','Ezra','ezra321','R04','ezra321@mail.com','0185678901'),
('U010','Nico','nico654','R04','nico654@mail.com','0136789012');


INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus) VALUES
('O001', 'U004', '2024-05-15', 80.00, 'Completed'),
('O002', 'U005', '2024-08-21', 55.50, 'In Progress'),
('O003', 'U006', '2024-10-30', 120.00, 'Completed'),
('O004', 'U007', '2025-01-10', 98.25, 'Completed'),
('O005', 'U008', '2025-03-05', 67.75, 'In Progress'),
('O006', 'U009', '2025-04-10', 75.00, 'Completed'),
('O007', 'U010', '2025-04-15', 110.25, 'In Progress'),
('O008', 'U004', '2025-05-01', 92.50, 'In Progress'),
('O009', 'U005', '2025-05-12', 60.00, 'Completed'),
('O010', 'U006', '2025-05-25', 85.75, 'Completed');



INSERT INTO Refund (RefundID, OrderID, UserID, [Status], RequestDate,TotalAmount) VALUES
('R01', 'O001', 'U004', 'Approved', '2024-05-17',80.00),
('R02', 'O002', 'U005', 'Pending', '2024-08-25',55.50),
('R03', 'O009', 'U005', 'Rejected', '2025-05-13',60.00),
('R04', 'O008', 'U004', 'Pending', '2025-05-02',92.50),
('R05', 'O007', 'U010', 'Pending', '2025-04-18',110.25);

INSERT INTO Feedback (FeedbackID, UserID, Feedback, [Date], Response, Rating) VALUES
('F001', 'U004', 'Good experience!', '2024-05-16', 'Thank you!', 5),
('F002', 'U005', 'Had to wait long.', '2024-08-22', 'Sorry for the late.', 3),
('F003', 'U006', 'Item was wrong.', '2024-10-31', null, 2),
('F004', 'U007', 'Perfect delivery.', '2025-01-11', null, 5),
('F005', 'U008', 'Food was ok.', '2025-03-06', null, 4),
('F006', 'U004', 'Great service, quick delivery!', '2024-11-12', 'Thanks for the feedback!', 5),
('F007', 'U005', 'Product was not as expected.', '2024-12-03', 'We are sorry to hear that. Please contact support.', 2),
('F008', 'U006', 'The delivery was a bit slow.', '2025-01-14', 'We appreciate your patience and feedback.', 3),
('F009', 'U007', 'Everything was perfect, will order again!', '2025-02-05', null, 5),
('F010', 'U008', 'Quality of food could improve.', '2025-03-10', 'We will work on improving quality.', 3),
('F011', 'U009', 'Enjoyed the food, will recommend to friends!', '2025-04-02', 'Thank you for the recommendation!', 5),
('F012', 'U010', 'Order was incorrect, missing items.', '2025-04-12', 'Sorry for the inconvenience. We’ll resolve it promptly.', 2),
('F013', 'U004', 'The food was cold when it arrived.', '2025-04-17', null, 2),
('F014', 'U005', 'Loved the food, but delivery was delayed.', '2025-05-04', 'We apologize for the delay. Thanks for your understanding!', 4),
('F015', 'U006', 'Good, but could use more variety in menu.', '2025-05-20', null, 3);

INSERT INTO EWallet (WalletID, Balance, UserID) VALUES
('W01', 180.00, 'U001'),
('W02', 150.00, 'U002'),
('W03', 200.00, 'U003'),
('W04', 50, 'U004'),
('W05', 50, 'U005'),
('W06', 150, 'U006'),
('W07', 150, 'U007'),
('W08', 0, 'U008'),
('W09', 0, 'U009'),
('W10', 0, 'U010');

INSERT INTO EWalletTransactions (TransactionID, WalletID, [Type], Amount, TransactionDate) VALUES
('T001', 'W04', 'Online Banking', 50.00, '2024-05-14'),
('T002', 'W05', 'Ewallet', 50.00, '2024-08-21'),
('T003', 'W06', 'Ewallet', 20.00, '2024-11-02'),
('T004', 'W07', 'Online Banking', 60.00, '2025-01-09'),
('T005', 'W08', 'Cash', 100.00, '2025-03-05');

INSERT INTO MenuCategory (CategoryID,Name)VALUES
('C01','Vegetarian'),
('C02','Italian'),
('C03','Western'),
('C04','Local'),
('C05','Beverages');

INSERT INTO Users (UserID, Username, Passwords, RoleID, EmailAddress, ContactNo) VALUES
('U011', 'gordon', 'bestChef', 'R03', 'gordon@mail.com', '0153456791'),
('U012', 'chePau', 'pa0405', 'R03', 'chePau@mail.com', '0143005611');

INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES
('V001', 'C01', 'U003', 'Pumpkin Soup', 10.50, 'Yes'),
('V002', 'C01', 'U003', 'Grilled Tofu Salad', 12.00, 'Yes'),
('V003', 'C01', 'U003', 'Stir-fried Broccoli', 6.50, 'Yes'),
('V004', 'C01', 'U003', 'Vegetable Fried Rice', 8.00, 'Yes'),
('V005', 'C01', 'U003', 'Tofu Lettuce Wraps', 8.00, 'Yes');

-- Italian (CategoryID = 'C02')
INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES
('I001', 'C02', 'U012', 'Spaghetti Carbonara', 12.00, 'Yes'),
('I002', 'C02', 'U012', 'Margherita Pizza', 11.00, 'Yes'),
('I003', 'C02', 'U012', 'Lasagna', 13.50, 'Yes'),
('I004', 'C02', 'U012', 'Fettuccine Alfredo', 12.50, 'Yes');

-- Western (CategoryID = 'C03')
INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES
('W001', 'C03', 'U011', 'Grilled Chicken Chop', 14.00, 'Yes'),
('W002', 'C03', 'U011', 'Fish and Chips', 13.00, 'Yes'),
('W003', 'C03', 'U011', 'Beef Steak', 20.00, 'Yes'),
('W004', 'C03', 'U011', 'Roast Lamb', 22.00, 'Yes'),
('W005', 'C03', 'U011', 'Chicken Pie', 10.00, 'Yes');

-- Local (CategoryID = 'C04')
INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES
('L001', 'C04', 'U003', 'Nasi Lemak', 9.00, 'Yes'),
('L002', 'C04', 'U003', 'Nasi Ayam Gepuk', 10.00, 'Yes'),
('L003', 'C04', 'U003', 'Roti Canai', 5.00, 'Yes'),
('L004', 'C04', 'U003', 'Mee Goreng', 8.50, 'Yes'),
('L005', 'C04', 'U003', 'Laksa', 9.50, 'Yes');

-- Beverages (CategoryID = 'C05')
INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES
('B001', 'C05', 'U003', 'Teh Tarik', 5.00, 'Yes'),
('B002', 'C05', 'U003', 'Iced Lemon Tea', 3.50, 'Yes'),
('B003', 'C05', 'U012', 'Watermelon Juice', 8.50, 'Yes'),
('B004', 'C05', 'U012', 'Fresh Orange Juice', 8.50, 'Yes'),
('B005', 'C05', 'U011', 'Spanish Latte', 10.50, 'Yes');

ALTER TABLE MenuItems
ADD ImagePath VARCHAR(255);

UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\TehTarik.png' WHERE ItemID = 'B001';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\LemonTea.png' WHERE ItemID = 'B002';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\WJuice.png' WHERE ItemID = 'B003';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\OJuice.png' WHERE ItemID = 'B004';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\Spanish.png' WHERE ItemID = 'B005';

--Add image path for Italian
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\SCarbo.png' WHERE ItemID = 'I001';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\Pizza.png' WHERE ItemID = 'I002';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\Lasag.png' WHERE ItemID = 'I003';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\FAlfre.png' WHERE ItemID = 'I004';

--Add image path for Vegetarian
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\PumpSoup.png' WHERE ItemID = 'V001';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\TofuSalad.png' WHERE ItemID = 'V002';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\Broc.png' WHERE ItemID = 'V003';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final oop\Final oop\OOP_MANAGER\MenuItemsImages\FriedRice.png' WHERE ItemID = 'V004';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\LettuceWrap.png' WHERE ItemID = 'V005';

--ADd image path for western
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\ChickenChop.png' WHERE ItemID = 'W001';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\FishChips.png' WHERE ItemID = 'W002';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\BeefSteak.png' WHERE ItemID = 'W003';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\RoastLamb.png' WHERE ItemID = 'W004';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final oop\Final oop\OOP_MANAGER\' WHERE ItemID = 'W005';

--Update status of order
UPDATE Orders SET OrderStatus = 'Cooking' WHERE OrderID = 'O01';
UPDATE Orders SET OrderStatus = 'Cooking' WHERE OrderID = 'O02';
UPDATE Orders SET OrderStatus = 'Cooking' WHERE OrderID = 'O04';

--Add image for local
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\NasiLemak.png' WHERE ItemID = 'L001';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\NasiAyamGepuk.png' WHERE ItemID = 'L002';
UPDATE MenuItems SET ImagePath = 'C:\Users\weiha\OneDrive\Desktop\Final\Backup_Manager\OOP_MANAGER\MenuItemsImages\Laksa.png' WHERE ItemID = 'L005';
