CREATE DATABASE EmployeeDB;

USE [EmployeeDb]
GO

CREATE TABLE [dbo].[Employee](
[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[FirstName] [nvarchar](40) NOT NULL,
[Age] [int] NOT NULL,
[Salary] [money] NOT NULL
)
GO

INSERT INTO Employee(FirstName, Age, Salary)
VALUES('Jimmy', 70, 90000),
('Sandy', 50, 45000),
('Allen', 25, 30000)
GO

SELECT * FROM Employee