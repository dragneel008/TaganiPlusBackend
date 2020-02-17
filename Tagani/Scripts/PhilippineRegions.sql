﻿DELETE FROM BARANGAYS;
DELETE FROM MUNICIPALITIES;
DELETE FROM PROVINCES;
DELETE FROM REGIONS;

DBCC CHECKIDENT('Barangays', RESEED, 0);
DBCC CHECKIDENT('Municipalities', RESEED, 0);
DBCC CHECKIDENT('Provinces', RESEED, 0);
DBCC CHECKIDENT('Regions', RESEED, 0);

--EXTRACT KEYS IN JSON FILE
DECLARE @JSON VARCHAR(MAX);
DECLARE @KEYS TABLE (Id VARCHAR(50));

SELECT @JSON = BULKCOLUMN
FROM OPENROWSET
(BULK 'C:\Users\Lee\Downloads\philippine_region_list.json', SINGLE_CLOB)
AS j;

INSERT INTO @KEYS
SELECT [key]
	FROM OPENJSON(@JSON);

DECLARE @CURRENT_KEY VARCHAR(50) = (SELECT TOP 1 Id FROM @KEYS);

WHILE (SELECT COUNT(*) FROM @KEYS) > 0
BEGIN
	--REGION SEED
	DECLARE @PATH VARCHAR(MAX) = '$.' + @CURRENT_KEY;
	DECLARE @REGIONID TABLE (Id INT);

	DECLARE @RName VARCHAR(MAX) = 
	(SELECT TOP 1 value
		FROM OPENJSON(@JSON, @PATH));

	DECLARE @RProv VARCHAR(MAX) = 
	(SELECT value
		FROM OPENJSON(@JSON, @PATH)
		ORDER BY Type
		OFFSET 1 ROW
		FETCH NEXT 1 ROWS ONLY
	);

	INSERT INTO Regions (Name, ProvinceJSON)
	OUTPUT inserted.Id INTO @REGIONID
	SELECT @RName, @RProv;

	--PROVINCE SEED
	DECLARE @PROVINCEID TABLE (Id INT);

	INSERT INTO Provinces (RegionId, Name, MunicipalityJSON)
	OUTPUT inserted.Id INTO  @PROVINCEID
	SELECT (SELECT TOP 1 Id FROM  @REGIONID), [key], value FROM OPENJSON(@RProv);

	--MUNICIPALITIES SEED
	DECLARE @CURRENT_PROVINCE_ID INT = (SELECT TOP 1 Id FROM @PROVINCEID);
	DECLARE @PMUNI VARCHAR(MAX) = (SELECT MunicipalityJSON FROM Provinces WHERE Id = @CURRENT_PROVINCE_ID);
	DECLARE @MUNICIPALITYID TABLE (Id INT);

	SET @PMUNI = (SELECT value FROM OPENJSON(@PMUNI));

	WHILE (SELECT COUNT(*) FROM @PROVINCEID) > 0
	BEGIN
	INSERT INTO Municipalities (ProvinceId, Name, BarangayJSON)
	OUTPUT inserted.Id INTO  @MUNICIPALITYID
	SELECT @CURRENT_PROVINCE_ID, [key], value FROM OPENJSON(@PMUNI);

	DELETE FROM @PROVINCEID WHERE Id = @CURRENT_PROVINCE_ID;
	SET @CURRENT_PROVINCE_ID = (SELECT TOP 1 Id FROM @PROVINCEID);
	SET @PMUNI = (SELECT MunicipalityJSON FROM Provinces WHERE Id = @CURRENT_PROVINCE_ID);
	SET @PMUNI = (SELECT value FROM OPENJSON(@PMUNI));
	END

	--BRGY SEED
	DECLARE @CURRENT_MUNICIPAL_ID INT = (SELECT TOP 1 Id FROM @MUNICIPALITYID);
	DECLARE @MBRGY VARCHAR(MAX) = (SELECT BarangayJSON FROM Municipalities WHERE Id = @CURRENT_MUNICIPAL_ID);
	DECLARE @BARANGAYID TABLE (Id INT);

	SET @MBRGY = (SELECT value FROM OPENJSON(@MBRGY));

	WHILE (SELECT COUNT(*) FROM @MUNICIPALITYID) > 0
	BEGIN
	INSERT INTO Barangays(MunicipalityId, Name)
	OUTPUT inserted.Id INTO  @BARANGAYID
	SELECT @CURRENT_MUNICIPAL_ID, VALUE FROM OPENJSON(@MBRGY);

	DELETE FROM @MUNICIPALITYID WHERE Id = @CURRENT_MUNICIPAL_ID;
	SET @CURRENT_MUNICIPAL_ID = (SELECT TOP 1 Id FROM @MUNICIPALITYID);
	SET @MBRGY = (SELECT BarangayJSON FROM Municipalities WHERE Id = @CURRENT_MUNICIPAL_ID);
	SET @MBRGY = (SELECT value FROM OPENJSON(@MBRGY));
	END
	
	DELETE FROM @KEYS WHERE Id = @CURRENT_KEY;
	SET @CURRENT_KEY  = (SELECT TOP 1 Id FROM @KEYS);
END