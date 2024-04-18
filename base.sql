-- Active: 1713229490129@@b18vxxgzlvikzwupgdyo-mysql.services.clever-cloud.com@3306@b18vxxgzlvikzwupgdyo
CREATE TABLE Users(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Cedula INT UNIQUE NOT NULL,
    TipoUser INT NOT NULL, /* 1.Admins,2.Empleados */
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Names VARCHAR(45) NOT NULL,
    LastNames VARCHAR(45) NOT NULL,
    PhotoProfile VARCHAR(255) NOT NULL,
    Password VARCHAR(45) NOT NULL
);

CREATE TABLE TimeRegisters (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdUser INT NOT NULL,
    LoginAt DATETIME,
    LogoutAt DATETIME,
    FOREIGN KEY (IdUser) REFERENCES Users(Id)
);


INSERT INTO Users (Cedula, TipoUser, Email, Phone, Names, LastNames, PhotoProfile, Password)
VALUES (123456789, 1, 'wilmar@example.com', '123-456-7890', 'Wilmar', 'Puerta', 'wilmar_profile.jpg', 'password123');

INSERT INTO Users (Cedula, TipoUser, Email, Phone, Names, LastNames, PhotoProfile, Password)
VALUES (987654321, 1, 'anthony@example.com', '987-654-3210', 'Anthony', 'Muñoz', 'anthony_profile.jpg', 'password456');