use
CargoMangementSytem
go
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(100),
    Address VARCHAR(200)
)
use
CargoMangementSytem

go
CREATE TABLE Cargo (
    CargoId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    CargoName VARCHAR(100) NOT NULL,
    Weight DECIMAL(10,2) NOT NULL,
    CargoType VARCHAR(50),
    
    FOREIGN KEY (CustomerId)
    REFERENCES Customer(CustomerId)
);
use 
CargoMangementSytem

go
CREATE TABLE DeliveryStatus (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    StatusName VARCHAR(50) NOT NULL,
    Descriptions Varchar(200) NOT NULL
);

use
CargoMangementSytem

go
CREATE TABLE Shipment (
    ShipmentId INT PRIMARY KEY IDENTITY(1,1),

    CargoId INT NOT NULL,
    StatusId INT NOT NULL,

    ShipmentDate DATE NOT NULL,
    Destination VARCHAR(100) NOT NULL,
    ExpectedDelivery DATE,

    FOREIGN KEY (CargoId)
    REFERENCES Cargo(CargoId),

    FOREIGN KEY (StatusId)
    REFERENCES DeliveryStatus(StatusId)
);

INSERT INTO Customer(FullName, Phone, Email, Address)
VALUES
('Rakia Mohamed','615555555','Gaashaan@gmail.com','Mogadishu'),
('Amina Omar','617777777','Dina@gmail.com','Hargeisa'),
('Muna Mohamed','617890989','bocor@gmail.com','Mogadishu'),
('deca Mohamed','612345678','Urur@gmail.com','Boosaaso'),
('ismaacil Omar','613456787','ciloow@gmail.com','Mogdishu')

Select * from Customer

INSERT INTO Cargo(CustomerId, CargoName, Weight, CargoType)
VALUES
(1,'Electronics',25.5,'Fragile'),
(2,'Furniture',500,'Jiif'),
(3,'Furniture',300,'Fadhi'),
(4,'Electronic',199,'Laptop')

INSERT INTO Cargo(CustomerId, CargoName, Weight, CargoType)
VALUES
(5,'Electronic',500,'vialage')
select * from Cargo

INSERT INTO Shipment
(CargoId, StatusId, ShipmentDate, Destination, ExpectedDelivery)
VALUES
(1,1,'2026-06-17','Gaalcacyo','2026-06-25'),
(2,2,'2026-06-17','Nairobi','2026-06-23'),
(3,3,'2026-06-17','Burco','2026-06-23'),
(4,4,'2026-06-17','Kismaayo','2026-06-23'),
(5,5,'2026-06-17','Nairobi','2026-06-23')

select * from Shipment

INSERT INTO DeliveryStatus(StatusName, Descriptions)
VALUES
('Pending', 'Shipment has not started yet'),
('In Transit', 'Shipment is on the way'),
('Delivered', 'Shipment reached destination'),
('Cancelled', 'Shipment was cancelled');


INSERT INTO DeliveryStatus(StatusName, Descriptions)
VALUES
('Cancelled','Shipment was Cancelled')

select * from  DeliveryStatus
Select * from Customer
select * from Cargo
select * from Shipment



use
CargoMangementSytem
go
CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY(1,1),

    UserName VARCHAR(100) UNIQUE NOT NULL,

    Password VARCHAR(60) NOT NULL,

    Role VARCHAR(80) NOT NULL
);

INSERT INTO Users(UserName,Password,Role)
VALUES
('admin','admin123','Admin'),
('staff','staff123','Staff');
select * from Users


