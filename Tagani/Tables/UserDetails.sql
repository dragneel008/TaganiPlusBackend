CREATE TABLE [dbo].[UserDetails]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [Gender] INT NOT NULL, 
    [HomeNumber] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NOT NULL, 
    [MailingAddressLine1] VARCHAR(MAX) NOT NULL, 
    [MailingAddressLine2] VARCHAR(MAX) NULL, 
    [Province] VARCHAR(50) NOT NULL, 
    [Municipality] VARCHAR(50) NOT NULL, 
    [Barangay] VARCHAR(50) NOT NULL, 
    [PostalCode] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(50) NULL, 
    CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY ([Id]) REFERENCES [Users]([Id])
)
