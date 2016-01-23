Use D3BuildMark;
GO

IF OBJECT_ID('spCreateUser') IS NOT NULL
DROP PROC spCreateUser
GO

CREATE PROC spCreateUser
@GUID			uniqueidentifier,
@UserName		varchar(40)
AS 
BEGIN TRANSACTION
INSERT INTO UserProfile (UserGUID, UserName) 
VALUES 
(
	(SELECT aspnet_Users.UserId FROM aspnet_Users WHERE aspnet_Users.UserId = @GUID), 
	@UserName
)
COMMIT
GO

IF OBJECT_ID('spCreateProfile') IS NOT NULL
DROP PROC spCreateProfile
GO

CREATE PROC spCreateProfile
@GUID			uniqueidentifier,
@Battletag		varchar(40)
AS 
BEGIN TRANSACTION
INSERT INTO UserProfile (UserGUID, Battletag) VALUES 
(
	(SELECT UserProfile.UserGUID FROM UserProfile WHERE UserGUID = @GUID), 
	@Battletag
)
COMMIT
GO

IF OBJECT_ID('spCreateHero') IS NOT NULL
DROP PROC spCreateHero
GO

CREATE PROC spCreateHero
@GUID			uniqueidentifier,
@HeroName		varchar(12),
@HeroClass		varchar(12)
AS 
BEGIN TRANSACTION
INSERT INTO Hero (UserID, HeroName, HeroClass) VALUES 
(
	(SELECT UserProfile.UserID FROM UserProfile WHERE UserGUID = @GUID), 
	@HeroName,
	@HeroClass
)
COMMIT
GO