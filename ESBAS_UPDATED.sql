USE ESBAS_UPDATED_SQL_INTERNSHIP

IF OBJECT_ID('dbo.Events_Users','U') IS NOT NULL
	DROP TABLE dbo.Events_Users;

IF OBJECT_ID('dbo.Events', 'U') IS NOT NULL
    DROP TABLE dbo.Events;

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;

IF OBJECT_ID('dbo.Event_Location','U') IS NOT NULL
	DROP TABLE dbo.Event_Location;

IF OBJECT_ID('dbo.Event_Type','U') IS NOT NULL
	DROP TABLE dbo.Event_Type;

IF OBJECT_ID('dbo.User_Department','U') IS NOT NULL
	DROP TABLE dbo.User_Department;

IF OBJECT_ID('dbo.User_IsOfficeEmployee','U') IS NOT NULL
	DROP TABLE dbo.User_IsOfficeEmployee;

IF OBJECT_ID('dbo.User_Gender','U') IS NOT NULL
	DROP TABLE dbo.User_Gender;

/* Normalizasyon tablolarý */

CREATE TABLE Event_Type(

T_ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(100) NOT NULL,

);

CREATE TABLE Event_Location(

L_ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(100) NOT NULL

);

CREATE TABLE User_Department(

D_ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(100) NOT NULL

);

CREATE TABLE User_IsOfficeEmployee(

I_ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(100) NOT NULL

);

CREATE TABLE User_Gender(

G_ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(100) NOT NULL

);

CREATE TABLE Events (

    EventID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Location VARCHAR(200) NOT NULL,
    EventDateTime DATETIME NOT NULL,
	Event_Status BIT NOT NULL,
	T_ID INT FOREIGN KEY REFERENCES Event_Type(T_ID),
	L_ID INT FOREIGN KEY REFERENCES Event_Location(L_ID),

);

CREATE TABLE Users (

    UserID INT PRIMARY KEY IDENTITY(1,1),
	CardID INT UNIQUE,
    FullName VARCHAR(100) NOT NULL,
    Department VARCHAR(100) NOT NULL,
    IsOfficeEmployee VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
	D_ID INT FOREIGN KEY REFERENCES User_Department(D_ID),
	I_ID INT FOREIGN KEY REFERENCES User_IsOfficeEmployee(I_ID),
	G_ID INT FOREIGN KEY REFERENCES User_Gender(G_ID),
);

CREATE TABLE Events_Users(

	ID INT PRIMARY KEY IDENTITY(1,1),
	EventID INT FOREIGN KEY REFERENCES Events(EventID),
	CardID INT FOREIGN KEY REFERENCES Users(CardID),
	
);

ALTER TABLE Events
ADD Status BIT DEFAULT 1; 

ALTER TABLE Users
ADD Status BIT DEFAULT 1;

ALTER TABLE Events_Users
ADD Status BIT DEFAULT 1;

ALTER TABLE Event_Type
ADD Status BIT DEFAULT 1;

ALTER TABLE Event_Location
ADD Status BIT DEFAULT 1;

ALTER TABLE User_Department
ADD Status BIT DEFAULT 1;

ALTER TABLE User_IsOfficeEmployee
ADD Status BIT DEFAULT 1;

ALTER TABLE User_Gender
ADD Status BIT DEFAULT 1;


INSERT INTO Event_Type(Name) VALUES
('Conference'),
('Webinar'),
('Meeting'),
('Workshop'),
('Party');

INSERT INTO Event_Location(Name) VALUES
('Meeting Room'),
('Garden'),
('Izmir');

INSERT INTO User_Department(Name) VALUES
('Human Resources'),
('Information Technologies'),
('Customer Relations');

INSERT INTO User_IsOfficeEmployee(Name) VALUES
('Office'),
('Field');

INSERT INTO User_Gender(Name) VALUES
('Male'),
('Female');


INSERT INTO Events (Name,Type, Location, EventDateTime,T_ID,L_ID,Event_Status) VALUES
('Innovation-Focused Culture Development Training Program', 'Education', 'Meeting Room', '2024-06-24 09:00:00',3,1,1),
('Orientation For Interns', 'Meeting', 'Meeting Room', '2024-08-02 08:00:00',1,2,1),
('Innovation-Focused Culture Development Training Program', 'Education', 'Meeting Room', '2024-07-09 08:00:00',2,3,1);


INSERT INTO Users (CardID , FullName, Department, IsOfficeEmployee, Gender,D_ID,G_ID,I_ID) VALUES
(5666260, 'Cengizhan Kaya', 'IT', 'Office','Male',2,1,1),
(5605224,'Selman Emre Erol', 'IT', 'Office', 'Male',2,1,1),
(5358069, 'Atalay Beyazýt', 'IT', 'Office' ,'Male',2,1,1),
(5733290, 'Ceren Sezmen', 'CR', 'Office','Female',3,2,1);


INSERT INTO Events_Users(EventID,CardID) VALUES
(2,5666260),
(2,5605224),
(3,5358069),
(3,5733290);

SELECT * FROM Event_Type;

SELECT * FROM Event_Location;

SELECT * FROM User_Department;

SELECT * FROM User_IsOfficeEmployee;

SELECT * FROM User_Gender;

SELECT * FROM Events;

SELECT * FROM Users;

SELECT * FROM Events_Users;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 1;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 2;

SELECT EU.EventID,EU.CardID
FROM Events_Users AS EU
INNER JOIN Users AS U ON EU.CardID = U.CardID
WHERE EU.EventID = 3;