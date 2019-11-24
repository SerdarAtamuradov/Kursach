﻿CREATE TABLE Books
(
	[BookID] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(100) NOT NULL, 
    [Author] NCHAR(100) NOT NULL,
	[Description] NCHAR(1000) NOT NULL,
	[Genre] NCHAR(50) NOT NULL,
	[Price] DECIMAL(16,2) NOT NULL
)