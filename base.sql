-- Active: 1713229490129@@b18vxxgzlvikzwupgdyo-mysql.services.clever-cloud.com@3306@b18vxxgzlvikzwupgdyo
CREATE TABLE Employees(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Cedula INT UNIQUE NOT NULL,
    TipoUser INT NOT NULL, /* 1.Empleados,2.Admins */
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Names VARCHAR(45) NOT NULL,
    LastNames VARCHAR(45) NOT NULL,
    PhotoProfile VARCHAR(255) NOT NULL,
    Password VARCHAR(45) NOT NULL,


);

CREATE TABLE TimeRegisters (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    id_employee INT NOT NULL,
    LoginAt DATETIME,
    LogOffAt DATETIME,
    FOREIGN KEY (id_employee) REFERENCES Employees(Id)
);





INSERT INTO Employees (Cedula, Email, Phone, Names, LastNames, PhotoProfile,Password,LoginAt,LogOffAt)
VALUES (123456789, 'wilmar@example.com', '123-456-7890', 'Wilmar', 'Puerta', 'wilmar_profile.jpg', 'password123',NOW(),NOW());

INSERT INTO Employees (Cedula, Email, Phone, Names, LastNames, PhotoProfile, Password,LoginAt,LogOffAt)
VALUES (987654321, 'anthony@example.com', '987-654-3210', 'Anthony', 'Muñoz', 'anthony_profile.jpg', 'password456',NOW(),NOW());

