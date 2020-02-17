CREATE TABLE [dbo].[Provinces]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RegionId] INT NOT NULL,
    [Name] VARCHAR(MAX) NOT NULL, 
    [MunicipalityJSON] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Provinces_Regions] FOREIGN KEY ([RegionId]) REFERENCES [Regions]([Id])
)
