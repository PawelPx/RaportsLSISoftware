CREATE DATABASE RaportsLSI;

USE RaportsLSI;

CREATE TABLE Raports (
    [RaportID] int,
    [Name] varchar(50),
    [Date] Date,
    [Time] varchar(50),
    [User] varchar(50),
    [Local] varchar(50),
	CONSTRAINT [PK_Persons] PRIMARY KEY ([RaportID])
);

INSERT INTO Raports
VALUES (1, 'Raport1', '2022-10-23', '12:00', 'User1', 'Lokal 1');
INSERT INTO Raports
VALUES (2, 'Raport2', '2022-10-24', '8:00', 'User2', 'Lokal 1');
INSERT INTO Raports
VALUES (3, 'Raport3', '2022-10-25', '8:00', 'User2', 'Lokal 2');
INSERT INTO Raports
VALUES (4, 'Raport4', '2022-10-26', '12:00', 'User3', 'Lokal 2');
INSERT INTO Raports
VALUES (5, 'Raport5', '2022-10-26', '14:00', 'User3', 'Lokal 2');

