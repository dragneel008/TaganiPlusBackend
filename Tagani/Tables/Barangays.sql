CREATE TABLE [dbo].[Barangays]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MunicipalityId] INT NOT NULL, 
    [Name] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Barangays_Municipalities] FOREIGN KEY ([MunicipalityId]) REFERENCES [Municipalities]([Id])
)
