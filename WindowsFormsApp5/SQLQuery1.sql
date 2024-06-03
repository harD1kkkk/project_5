--﻿IF OBJECT_ID('dbo.Accounts', 'U') IS NOT NULL  
--  DROP TABLE dbo.Accounts;

--IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL  
--  DROP TABLE dbo.Students;

--IF OBJECT_ID('dbo.Classes', 'U') IS NOT NULL  
--  DROP TABLE dbo.Classes;

--IF OBJECT_ID('dbo.Teachers', 'U') IS NOT NULL  
--  DROP TABLE dbo.Teachers;

--IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL  
--  DROP TABLE dbo.Roles;

--DROP TABLE IF EXISTS Students;
--DROP TABLE IF EXISTS Classes; 
--DROP TABLE IF EXISTS Teachers;
--DROP TABLE IF EXISTS Accounts;
--DROP TABLE IF EXISTS Roles;



CREATE TABLE Teachers (
    teacher_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(255),
    last_name NVARCHAR(255),
);

CREATE TABLE Classes (
    class_id INT IDENTITY(1,1) PRIMARY KEY,
    class_name NVARCHAR(255),
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id)
);

CREATE TABLE Students (
    student_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(255),
    last_name NVARCHAR(255),
    email NVARCHAR(255) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL UNIQUE,
    IsHomeworkDone BIT NOT NULL,
    class_id INT,
    FOREIGN KEY (class_id) REFERENCES Classes(class_id)
);



CREATE TABLE Roles(
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name NVARCHAR(255) NOT NULL
);

CREATE TABLE Accounts(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL UNIQUE,
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);


INSERT INTO Classes (class_name, teacher_id)
VALUES
('A', 1),
('B', 2),
('C', 3),
('D', 4);


INSERT INTO Roles(role_name) VALUES
('Director'),
('Teacher');


INSERT INTO Accounts(name, email, password, role_id) VALUES
('Tomas', 'tomas.gerada@gmail.com', '5dasdsaASd', 1),
('John', 'jason.voorhees@gmail.com', 'GGsurv123', 2),
('Yarik', 'yarik.mudryy@itstep.com', 'ITstepTop124', 2);



INSERT INTO Students (first_name, last_name, email, password, IsHomeworkDone, class_id) VALUES
('John', 'Doe', 'john.doe01@example.com', 'Pass01', 0, 1),
('Jane', 'Smith', 'jane.smith02@example.com', 'Pass02', 0, 1),
('Michael', 'Brown', 'michael.brown03@example.com', 'Pass03', 0, 1),
('Emily', 'Davis', 'emily.davis04@example.com', 'Pass04', 0, 1),
('William', 'Garcia', 'william.garcia05@example.com', 'Pass05', 0, 1),
('Emma', 'Martinez', 'emma.martinez06@example.com', 'Pass06', 0, 1),
('Olivia', 'Hernandez', 'olivia.hernandez07@example.com', 'Pass07', 0, 1),
('Noah', 'Lopez', 'noah.lopez08@example.com', 'Pass08', 0, 1),
('Ava', 'Gonzalez', 'ava.gonzalez09@example.com', 'Pass09', 0, 1),
('Sophia', 'Wilson', 'sophia.wilson10@example.com', 'Pass10', 0, 1),

('Liam', 'Anderson', 'liam.anderson11@example.com', 'Pass11', 0, 2),
('Isabella', 'Thomas', 'isabella.thomas12@example.com', 'Pass12', 0, 2),
('Ethan', 'Taylor', 'ethan.taylor13@example.com', 'Pass13', 0, 2),
('Mason', 'Moore', 'mason.moore14@example.com', 'Pass14', 0, 2),
('Mia', 'Jackson', 'mia.jackson15@example.com', 'Pass15', 0, 2),
('Lucas', 'Martin', 'lucas.martin16@example.com', 'Pass16', 0, 2),
('Charlotte', 'Lee', 'charlotte.lee17@example.com', 'Pass17', 0, 2),
('Benjamin', 'Perez', 'benjamin.perez18@example.com', 'Pass18', 0, 2),
('Amelia', 'Thompson', 'amelia.thompson19@example.com', 'Pass19', 0, 2),
('Elijah', 'White', 'elijah.white20@example.com', 'Pass20', 0, 2),

('Oliver', 'Harris', 'oliver.harris21@example.com', 'Pass21', 0, 3),
('Isaiah', 'Sanchez', 'isaiah.sanchez22@example.com', 'Pass22', 0, 3),
('Harper', 'Clark', 'harper.clark23@example.com', 'Pass23', 0, 3),
('James', 'Ramirez', 'james.ramirez24@example.com', 'Pass24', 0, 3),
('Abigail', 'Lewis', 'abigail.lewis25@example.com', 'Pass25', 0, 3),
('Aiden', 'Robinson', 'aiden.robinson26@example.com', 'Pass26', 0, 3),
('Madison', 'Walker', 'madison.walker27@example.com', 'Pass27', 0, 3),
('Alexander', 'Young', 'alexander.young28@example.com', 'Pass28', 0, 3),
('Victoria', 'Allen', 'victoria.allen29@example.com', 'Pass29', 0, 3),
('Jack', 'King', 'jack.king30@example.com', 'Pass30', 0, 3),

('Lily', 'Wright', 'lily.wright31@example.com', 'Pass31', 0, 4),
('Logan', 'Scott', 'logan.scott32@example.com', 'Pass32', 0, 4),
('Grace', 'Torres', 'grace.torres33@example.com', 'Pass33', 0, 4),
('Joseph', 'Nguyen', 'joseph.nguyen34@example.com', 'Pass34',0, 4),
('Sarah', 'Hill', 'sarah.hill35@example.com', 'Pass35',0, 4),
('Gabriel', 'Flores', 'gabriel.flores36@example.com', 'Pass36',0, 4),
('Sofia', 'Green', 'sofia.green37@example.com', 'Pass37',0, 4),
('Carter', 'Adams', 'carter.adams38@example.com', 'Pass38',0, 4),
('Zoe', 'Nelson', 'zoe.nelson39@example.com', 'Pass39',0, 4),
('Julian', 'Baker', 'julian.baker40@example.com', 'Pass40',0, 4);
