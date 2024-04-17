-- Active: 1713229490129@@b18vxxgzlvikzwupgdyo-mysql.services.clever-cloud.com@3306@b18vxxgzlvikzwupgdyo
CREATE TABLE Admins (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Cedula INT UNIQUE NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Names VARCHAR(45) NOT NULL,
    LastNames VARCHAR(45) NOT NULL,
    PhotoProfile VARCHAR(255) NOT NULL,
    Password VARCHAR(45) NOT NULL,
    LoginAt DATE,
    LogOffAt DATE
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Cedula INT UNIQUE NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Names VARCHAR(45) NOT NULL,
    LastNames VARCHAR(45) NOT NULL,
    PhotoProfile VARCHAR(255) NOT NULL,
    Password VARCHAR(45) NOT NULL,
    LoginAt DATE,
    LogOffAt DATE
);


INSERT INTO Admins (Cedula, Email, Phone, Names, LastNames, PhotoProfile, Password,LoginAt,LogOffAt)
VALUES (123456789, 'wilmar@example.com', '123-456-7890', 'Wilmar', 'Puerta', 'wilmar_profile.jpg', 'password123',NOW(),NOW());


INSERT INTO Admins (Cedula, Email, Phone, Names, LastNames, PhotoProfile, Password,LoginAt,LogOffAt)
VALUES (987654321, 'anthony@example.com', '987-654-3210', 'Anthony', 'Muñoz', 'anthony_profile.jpg', 'password456',NOW(),NOW());

INSERT INTO Employees (Cedula, Email, Phone, Names, LastNames, PhotoProfile,Password,LoginAt,LogOffAt)
VALUES (123456789, 'wilmar@example.com', '123-456-7890', 'Wilmar', 'Puerta', 'wilmar_profile.jpg', 'password123',NOW(),NOW());


INSERT INTO Employees (Cedula, Email, Phone, Names, LastNames, PhotoProfile, Password,LoginAt,LogOffAt)
VALUES (987654321, 'anthony@example.com', '987-654-3210', 'Anthony', 'Muñoz', 'anthony_profile.jpg', 'password456',NOW(),NOW());

