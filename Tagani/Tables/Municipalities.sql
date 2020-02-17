CREATE TABLE [dbo].[Municipalities]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProvinceId] INT NOT NULL, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [BarangayJSON] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Municipalities_Provinces] FOREIGN KEY ([ProvinceId]) REFERENCES [Provinces]([Id])
)
