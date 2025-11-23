USE master
GO

CREATE DATABASE ArmazenaPikomon
GO

Use ArmazenaPikomon
Go

CREATE TABLE Pikomon(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Nome NVARCHAR(30) not null,
	Foto VARBINARY(max) not null,
	tipo NVARCHAR(30) not null,
	Vantagem NVARCHAR(30) not null,
	Fraqueza NVARCHAR(30) not null
)
GO