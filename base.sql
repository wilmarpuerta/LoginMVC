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

