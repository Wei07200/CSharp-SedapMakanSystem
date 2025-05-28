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

CREATE TABLE Orders 
(
    OrderID nvarchar(50) PRIMARY KEY not null,
    CustomerID nvarchar(50) FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    OrderStatus VARCHAR(50),
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
    [Status] VARCHAR(50),
    RequestDate DATE,
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
('U005','Ilio','lio771','R04','lio0771@mail.com','0129876121');
('U006','Mira','mira123','R04','mira123@mail.com','0172345678'),
('U007','Tariq','tariq789','R04','tariq789@mail.com','0163456789'),
('U008','Lena','lena456','R04','lena456@mail.com','0154567890'),
('U009','Ezra','ezra321','R04','ezra321@mail.com','0185678901'),
('U010','Nico','nico654','R04','nico654@mail.com','0136789012');



INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus) VALUES
('O01', 'U004', '2024-05-15', 80.00, 'Completed'),
('O02', 'U005', '2024-08-21', 55.50, 'Pending'),
('O03', 'U006', '2024-10-30', 120.00, 'Cancelled'),
('O04', 'U007', '2025-01-10', 98.25, 'Completed'),
('O05', 'U008', '2025-03-05', 67.75, 'Processing');

INSERT INTO Refund (RefundID, OrderID, UserID, [Status], RequestDate) VALUES
('R01', 'O01', 'U004', 'Approved', '2025-03-20'),
('R02', 'O03', 'U005', 'Pending', '2024-08-25'),
('R03', 'O05', 'U006', 'Rejected', '2024-11-02');

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
('T005', 'W08', 'Credut Card', 100.00, '2025-03-05');

