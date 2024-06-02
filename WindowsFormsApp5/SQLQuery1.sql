IF OBJECT_ID('dbo.Accounts', 'U') IS NOT NULL  
  DROP TABLE dbo.Accounts;

IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL  
  DROP TABLE dbo.Students;

IF OBJECT_ID('dbo.Classes', 'U') IS NOT NULL  
  DROP TABLE dbo.Classes;

IF OBJECT_ID('dbo.Teachers', 'U') IS NOT NULL  
  DROP TABLE dbo.Teachers;

IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL  
  DROP TABLE dbo.Roles;



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
('Yarik', 'yarik.mudryy@itstep.com', 'ITstepTop124', 2),
('Stepan', 'stepan.bandera@itstep.com', 'Bandera_Top1', 2),
('Mikola', 'mikola.cros@gmail.com', 'crutoiPots228', 2);

INSERT INTO Students (first_name, last_name, email, password, class_id) VALUES
('John', 'Doe', 'john.doe01@example.com', 'Pass01', 1),
('Jane', 'Smith', 'jane.smith02@example.com', 'Pass02', 1),
('Michael', 'Brown', 'michael.brown03@example.com', 'Pass03', 1),
('Emily', 'Davis', 'emily.davis04@example.com', 'Pass04', 1),
('William', 'Garcia', 'william.garcia05@example.com', 'Pass05', 1),
('Emma', 'Martinez', 'emma.martinez06@example.com', 'Pass06', 1),
('Olivia', 'Hernandez', 'olivia.hernandez07@example.com', 'Pass07', 1),
('Noah', 'Lopez', 'noah.lopez08@example.com', 'Pass08', 1),
('Ava', 'Gonzalez', 'ava.gonzalez09@example.com', 'Pass09', 1),
('Sophia', 'Wilson', 'sophia.wilson10@example.com', 'Pass10', 1),

('Liam', 'Anderson', 'liam.anderson11@example.com', 'Pass11', 2),
('Isabella', 'Thomas', 'isabella.thomas12@example.com', 'Pass12', 2),
('Ethan', 'Taylor', 'ethan.taylor13@example.com', 'Pass13', 2),
('Mason', 'Moore', 'mason.moore14@example.com', 'Pass14', 2),
('Mia', 'Jackson', 'mia.jackson15@example.com', 'Pass15', 2),
('Lucas', 'Martin', 'lucas.martin16@example.com', 'Pass16', 2),
('Charlotte', 'Lee', 'charlotte.lee17@example.com', 'Pass17', 2),
('Benjamin', 'Perez', 'benjamin.perez18@example.com', 'Pass18', 2),
('Amelia', 'Thompson', 'amelia.thompson19@example.com', 'Pass19', 2),
('Elijah', 'White', 'elijah.white20@example.com', 'Pass20', 2),

('Oliver', 'Harris', 'oliver.harris21@example.com', 'Pass21', 3),
('Isaiah', 'Sanchez', 'isaiah.sanchez22@example.com', 'Pass22', 3),
('Harper', 'Clark', 'harper.clark23@example.com', 'Pass23', 3),
('James', 'Ramirez', 'james.ramirez24@example.com', 'Pass24', 3),
('Abigail', 'Lewis', 'abigail.lewis25@example.com', 'Pass25', 3),
('Aiden', 'Robinson', 'aiden.robinson26@example.com', 'Pass26', 3),
('Madison', 'Walker', 'madison.walker27@example.com', 'Pass27', 3),
('Alexander', 'Young', 'alexander.young28@example.com', 'Pass28', 3),
('Victoria', 'Allen', 'victoria.allen29@example.com', 'Pass29', 3),
('Jack', 'King', 'jack.king30@example.com', 'Pass30', 3),

('Lily', 'Wright', 'lily.wright31@example.com', 'Pass31', 4),
('Logan', 'Scott', 'logan.scott32@example.com', 'Pass32', 4),
('Grace', 'Torres', 'grace.torres33@example.com', 'Pass33', 4),
('Joseph', 'Nguyen', 'joseph.nguyen34@example.com', 'Pass34', 4),
('Sarah', 'Hill', 'sarah.hill35@example.com', 'Pass35', 4),
('Gabriel', 'Flores', 'gabriel.flores36@example.com', 'Pass36', 4),
('Sofia', 'Green', 'sofia.green37@example.com', 'Pass37', 4),
('Carter', 'Adams', 'carter.adams38@example.com', 'Pass38', 4),
('Zoe', 'Nelson', 'zoe.nelson39@example.com', 'Pass39', 4),
('Julian', 'Baker', 'julian.baker40@example.com', 'Pass40', 4);
