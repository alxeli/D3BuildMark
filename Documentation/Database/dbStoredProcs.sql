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
UPDATE UserProfile 
SET UserProfile.Battletag = COALESCE(@Battletag, Battletag)
WHERE UserProfile.UserGUID = @GUID
COMMIT
GO

IF OBJECT_ID('spReadProfile') IS NOT NULL
DROP PROC spReadProfile
GO
CREATE PROC spReadProfile
@GUID			uniqueidentifier
AS 
BEGIN TRANSACTION
SELECT UserProfile.UserName, UserProfile.Battletag FROM UserProfile WHERE UserProfile.UserGUID = @GUID
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

IF OBJECT_ID('spReadHeroes') IS NOT NULL
DROP PROC spReadHeroes
GO
CREATE PROC spReadHeroes
@GUID			uniqueidentifier,
@Battletag		varchar(40)
AS 
BEGIN TRANSACTION
SELECT Hero.HeroName, Hero.HeroClass FROM Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID 
	WHERE UserProfile.UserGUID = @GUID 
COMMIT
GO

IF OBJECT_ID('spDeleteHero') IS NOT NULL
DROP PROC spDeleteHero
GO
CREATE PROC spDeleteHero
@GUID			uniqueidentifier,
@HeroName		varchar(12),
@HeroClass		varchar(12)
AS 
BEGIN TRANSACTION
DELETE FROM Hero WHERE Hero.UserID = (SELECT UserProfile.UserID FROM UserProfile WHERE UserProfile.UserGUID = @GUID) AND Hero.HeroName = @HeroName AND hero.HeroClass = @HeroClass 
COMMIT
GO

--IF OBJECT_ID('spDeleteHeroTrigger') IS NOT NULL
--DROP TRIGGER spDeleteHeroTrigger
--GO
--CREATE TRIGGER spDeleteHeroTrigger
--ON Hero
--FOR DELETE
--AS
--BEGIN TRANSACTION
--DECLARE @HeroToDelete int
--SELECT @HeroToDelete = HeroID FROM Deleted
--DELETE FROM BuildSnapshot WHERE BuildSnapshot.HeroID = @HeroToDelete
--COMMIT
--GO

--IF OBJECT_ID('spDeleteBuildSnapshotTrigger') IS NOT NULL
--DROP TRIGGER spDeleteBuildSnapshotTrigger
--GO
--CREATE TRIGGER spDeleteBuildSnapshotTrigger
--ON BuildSnapshot
--FOR DELETE
--AS
--BEGIN TRANSACTION
--DECLARE @ItemListToDelete int
--DECLARE @SkillListToDelete int
--SELECT @ItemListToDelete = ItemListID FROM Deleted
--SELECT @SkillListToDelete = SkillListID FROM Deleted
--DELETE FROM ItemList WHERE ItemList.ItemListID = @ItemListToDelete
--DELETE FROM SkillList WHERE SkillList.SkillListID = @SkillListToDelete
--COMMIT
--GO

--IF OBJECT_ID('spDeleteItemListTrigger') IS NOT NULL
--DROP TRIGGER spDeleteItemListTrigger
--GO
--CREATE TRIGGER spDeleteItemListTrigger
--ON ItemList
--FOR DELETE
--AS
--BEGIN TRANSACTION
--DECLARE @HeadToDelete int
--DECLARE @NeckToDelete int
--DECLARE @ShouldersToDelete int
--DECLARE @GlovesToDelete int
--DECLARE @ChestToDelete int
--DECLARE @BracersToDelete int
--DECLARE @BeltToDelete int
--DECLARE @LeftRingToDelete int
--DECLARE @RightRingToDelete int
--DECLARE @PantsToDelete int
--DECLARE @BootsToDelete int
--DECLARE @LeftHandToDelete int
--DECLARE @RightHandToDelete int
--SELECT @HeadToDelete = HeadID FROM Deleted
--SELECT @NeckToDelete = NeckID FROM Deleted
--SELECT @ShouldersToDelete = ShouldersID FROM Deleted
--SELECT @GlovesToDelete = GlovesID FROM Deleted
--SELECT @ChestToDelete = ChestID FROM Deleted
--SELECT @BracersToDelete = BracersID FROM Deleted
--SELECT @BeltToDelete = BeltID FROM Deleted
--SELECT @LeftRingToDelete = LeftRingID FROM Deleted
--SELECT @RightRingToDelete = RightRingID FROM Deleted
--SELECT @PantsToDelete = PantsID FROM Deleted
--SELECT @BootsToDelete = BootsID FROM Deleted
--SELECT @LeftHandToDelete = LeftHandID FROM Deleted
--SELECT @RightHandToDelete = RightHandID FROM Deleted
--DELETE FROM Item WHERE Item.ItemID = @HeadToDelete
--DELETE FROM Item WHERE Item.ItemID = @NeckToDelete
--DELETE FROM Item WHERE Item.ItemID = @ShouldersToDelete
--DELETE FROM Item WHERE Item.ItemID = @GlovesToDelete
--DELETE FROM Item WHERE Item.ItemID = @ChestToDelete
--DELETE FROM Item WHERE Item.ItemID = @BracersToDelete
--DELETE FROM Item WHERE Item.ItemID = @BeltToDelete
--DELETE FROM Item WHERE Item.ItemID = @LeftRingToDelete
--DELETE FROM Item WHERE Item.ItemID = @RightRingToDelete
--DELETE FROM Item WHERE Item.ItemID = @PantsToDelete
--DELETE FROM Item WHERE Item.ItemID = @BootsToDelete
--DELETE FROM Item WHERE Item.ItemID = @LeftHandToDelete
--DELETE FROM Item WHERE Item.ItemID = @RightHandToDelete
--DELETE FROM Item WHERE Item.ItemID = @HeadToDelete
--COMMIT
--GO

--IF OBJECT_ID('spDeleteSkillListTrigger') IS NOT NULL
--DROP TRIGGER spDeleteSkillListTrigger
--GO
--CREATE TRIGGER spDeleteSkillListTrigger
--ON SkillList
--FOR DELETE
--AS
--BEGIN TRANSACTION
--DECLARE @Active0ToDelete int
--DECLARE @Active1ToDelete int
--DECLARE @Active2ToDelete int
--DECLARE @Active3ToDelete int
--DECLARE @Active4ToDelete int
--DECLARE @Active5ToDelete int
--DECLARE @Passive0ToDelete int
--DECLARE @Passive1ToDelete int
--DECLARE @Passive2ToDelete int
--DECLARE @Passive3ToDelete int
--SELECT @Active0ToDelete = Active0ID FROM Deleted
--SELECT @Active1ToDelete = Active1ID FROM Deleted
--SELECT @Active2ToDelete = Active2ID FROM Deleted
--SELECT @Active3ToDelete = Active3ID FROM Deleted
--SELECT @Active4ToDelete = Active4ID FROM Deleted
--SELECT @Active5ToDelete = Active5ID FROM Deleted
--SELECT @Passive0ToDelete = Passive0ID FROM Deleted
--SELECT @Passive1ToDelete = Passive1ID FROM Deleted
--SELECT @Passive2ToDelete = Passive2ID FROM Deleted
--SELECT @Passive3ToDelete = Passive3ID FROM Deleted
--DELETE FROM Skill WHERE Skill.SkillID = @Active0ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Active1ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Active2ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Active3ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Active4ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Active5ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Passive0ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Passive1ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Passive2ToDelete
--DELETE FROM Skill WHERE Skill.SkillID = @Passive3ToDelete
--COMMIT
--GO

IF OBJECT_ID('spCreateBuildSnapshot') IS NOT NULL
DROP PROC spCreateBuildSnapshot
GO
CREATE PROC spCreateBuildSnapshot
@GUID			uniqueidentifier,
@HeroName		varchar(12),
@BuildName		varchar(30),

@HeadName		varchar(60),
@HeadAtt		varchar(500),
@NeckName		varchar(60),
@NeckAtt		varchar(500),
@ShouldersName	varchar(60),
@ShouldersAtt	varchar(500),
@GlovesName		varchar(60),
@GlovesAtt		varchar(500),
@ChestName		varchar(60),
@ChestAtt		varchar(500),
@BracersName	varchar(60),
@BracersAtt		varchar(500),
@BeltName		varchar(60),
@BeltAtt		varchar(500),
@LeftRingName	varchar(60),
@LeftRingAtt	varchar(500),
@RightRingName	varchar(60),
@RightRingAtt	varchar(500),
@PantsName		varchar(60),
@PantsAtt		varchar(500),
@BootsName		varchar(60),
@BootsAtt		varchar(500),
@LeftHandName	varchar(60),
@LeftHandAtt	varchar(500),
@RightHandName	varchar(60),
@RightHandAtt	varchar(500),

@Act0Name		varchar(60),
@Act0Desc		varchar(200),
@Act1Name		varchar(60),
@Act1Desc		varchar(200),
@Act2Name		varchar(60),
@Act2Desc		varchar(200),
@Act3Name		varchar(60),
@Act3Desc		varchar(200),
@Act4Name		varchar(60),
@Act4Desc		varchar(200),
@Act5Name		varchar(60),
@Act5Desc		varchar(200),
@Pass0Name		varchar(60),
@Pass0Desc		varchar(200),
@Pass1Name		varchar(60),
@Pass1Desc		varchar(200),
@Pass2Name		varchar(60),
@Pass2Desc		varchar(200),
@Pass3Name		varchar(60),
@Pass3Desc		varchar(200)

AS 
BEGIN TRANSACTION
INSERT INTO Skill (Name, Description) VALUES(@Act0Name, @Act0Desc)
INSERT INTO Skill (Name, Description) VALUES(@Act1Name, @Act1Desc)
INSERT INTO Skill (Name, Description) VALUES(@Act2Name, @Act2Desc)
INSERT INTO Skill (Name, Description) VALUES(@Act3Name, @Act3Desc)
INSERT INTO Skill (Name, Description) VALUES(@Act4Name, @Act4Desc)
INSERT INTO Skill (Name, Description) VALUES(@Act5Name, @Act5Desc)
INSERT INTO Skill (Name, Description) VALUES(@Pass0Name, @Pass0Desc)
INSERT INTO Skill (Name, Description) VALUES(@Pass1Name, @Pass1Desc)
INSERT INTO Skill (Name, Description) VALUES(@Pass2Name, @Pass2Desc)
INSERT INTO Skill (Name, Description) VALUES(@Pass3Name, @Pass3Desc)

--insert all foreign keys to Skills based on descriptions which are unique for every skill
INSERT INTO SkillList (Active0ID, Active1ID, Active2ID, Active3ID, Active4ID, Active5ID, Passive0ID, Passive1ID, Passive2ID, Passive3ID)
VALUES
(
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act0Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act1Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act2Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act3Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act4Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Act5Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Pass0Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Pass1Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Pass2Desc),
	(SELECT Skill.SkillID FROM Skill WHERE Skill.Description = @Pass3Desc)
) 

INSERT INTO Item (Name, Attributes) VALUES(@HeadName, @HeadAtt)
INSERT INTO Item (Name, Attributes) VALUES(@NeckName, @NeckAtt)
INSERT INTO Item (Name, Attributes) VALUES(@ShouldersName, @ShouldersAtt)
INSERT INTO Item (Name, Attributes) VALUES(@GlovesName, @GlovesAtt)
INSERT INTO Item (Name, Attributes) VALUES(@ChestName, @ChestAtt)
INSERT INTO Item (Name, Attributes) VALUES(@BracersName, @BracersAtt)
INSERT INTO Item (Name, Attributes) VALUES(@BeltName, @BeltAtt)
INSERT INTO Item (Name, Attributes) VALUES(@LeftRingName, @LeftRingAtt)
INSERT INTO Item (Name, Attributes) VALUES(@RightRingName, @RightRingAtt)
INSERT INTO Item (Name, Attributes) VALUES(@PantsName, @PantsAtt)
INSERT INTO Item (Name, Attributes) VALUES(@BootsName, @BootsAtt)
INSERT INTO Item (Name, Attributes) VALUES(@LeftHandName, @LeftHandAtt)
INSERT INTO Item (Name, Attributes) VALUES(@RightHandName, @RightHandAtt)

--insert all foreign keys to Items based on Attributes which are unique for every skill
INSERT INTO ItemList (HeadID, NeckID, ShouldersID, GlovesID, ChestID, BracersID, BeltID, LeftRingID, RightRingID, PantsID, BootsID, LeftHandID, RightHandID)
VALUES
(
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @HeadAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @NeckAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @ShouldersAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @GlovesAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @ChestAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @BracersAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @BeltAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @LeftRingAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @RightRingAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @PantsAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @BootsAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @LeftHandAtt),
	(SELECT Item.ItemID FROM Item WHERE Item.Attributes = @RightHandAtt)
) 
--IF ((SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName) IS NULL)
--	RAISERROR('Hero was not previously added', 16, 1);
--IF ((SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName) IS NULL)
--	ROLLBACK TRANSACTION;
--ELSE 
	INSERT INTO BuildSnapshot (HeroID, SkillListID, ItemListID, BuildName) VALUES
	(
		--finds all hero id's that match user id and hero name
		(SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName),
		IDENT_CURRENT('SkillList'),
		IDENT_CURRENT('ItemList'),
		@BuildName
	)
COMMIT TRANSACTION
GO

IF OBJECT_ID('spReadBuildSnapshot') IS NOT NULL
DROP PROC spReadBuildSnapshot
GO
CREATE PROC spReadBuildSnapshot
@GUID			uniqueidentifier,
@Battletag		varchar(40),
@HeroName		varchar(12)
AS
BEGIN TRANSACTION
	(SELECT * FROM 
	(SELECT BuildSnapshot.BuildName FROM BuildSnapshot JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE UserProfile.UserGUID = @GUID AND Hero.HeroName = @HeroName) AS BuildName,

	(SELECT Item.Name AS HeadName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.HeadID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS HeadName, 
	(SELECT Item.Attributes AS HeadAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.HeadID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS HeadAtt,

	(SELECT Item.Name AS NeckName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.NeckID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS NeckName, 
	(SELECT Item.Attributes AS NeckAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.NeckID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS NeckAtt,

	(SELECT Item.Name AS ShouldersName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.ShouldersID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS ShouldersName, 
	(SELECT Item.Attributes AS ShouldersAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.ShouldersID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS ShouldersAtt,

	(SELECT Item.Name AS GlovesName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.GlovesID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS GlovesName, 
	(SELECT Item.Attributes AS GlovesAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.GlovesID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS GlovesAtt,

	(SELECT Item.Name AS ChestName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.ChestID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS ChestName, 
	(SELECT Item.Attributes AS ChestAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.ChestID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS ChestAtt,

	(SELECT Item.Name AS BracersName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BracersID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BracersName, 
	(SELECT Item.Attributes AS BracersAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BracersID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BracersAtt,

	(SELECT Item.Name AS BeltName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BeltID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BeltName, 
	(SELECT Item.Attributes AS BeltAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BeltID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BeltAtt,

	(SELECT Item.Name AS LeftRingName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.LeftRingID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS LeftRingName, 
	(SELECT Item.Attributes AS LeftRingAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.LeftRingID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS LeftRingAtt,

	(SELECT Item.Name AS RightRingName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.RightRingID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS RightRingName, 
	(SELECT Item.Attributes AS RightRingAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.RightRingID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS RightRingAtt,

	(SELECT Item.Name AS PantsName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.PantsID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS PantsName, 
	(SELECT Item.Attributes AS PantsAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.PantsID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS PantsAtt,

	(SELECT Item.Name AS BootsName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BootsID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BootsName, 
	(SELECT Item.Attributes AS BootsAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.BootsID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS BootsAtt,

	(SELECT Item.Name AS LeftHandName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.LeftHandID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS LeftHandName, 
	(SELECT Item.Attributes AS LeftHandAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.LeftHandID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS LeftHandAtt,

	(SELECT Item.Name AS RightHandName FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.RightHandID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS RightHandName, 
	(SELECT Item.Attributes AS RightHandAtt FROM Item WHERE Item.ItemID = --Select just one item from this item list
		(SELECT ItemList.RightHandID FROM ItemList WHERE ItemList.ItemListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.ItemListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS RightHandAtt,


	(SELECT Skill.Name AS a0Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active0ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a0Name,
	(SELECT Skill.Description AS a0Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active0ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a0Descr,

	(SELECT Skill.Name AS a1Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active1ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a1Name,
	(SELECT Skill.Description AS a1Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active1ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a1Descr,

	(SELECT Skill.Name AS a2Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active2ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a2Name,
	(SELECT Skill.Description AS a2Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active2ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a2Descr,

	(SELECT Skill.Name AS a3Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active3ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a3Name,
	(SELECT Skill.Description AS a3Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active3ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a3Descr,

	(SELECT Skill.Name AS a4Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active4ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a4Name,
	(SELECT Skill.Description AS a4Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active4ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a4Descr,

	(SELECT Skill.Name AS a5Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active5ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a5Name,
	(SELECT Skill.Description AS a5Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Active5ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS a5Descr,

	(SELECT Skill.Name AS p0Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive0ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p0Name,
	(SELECT Skill.Description AS p0Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive0ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p0Descr,

	(SELECT Skill.Name AS p1Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive1ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p1Name,
	(SELECT Skill.Description AS p1Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive1ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p1Descr,

	(SELECT Skill.Name AS p2Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive2ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p2Name,
	(SELECT Skill.Description AS p2Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive2ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p2Descr,

	(SELECT Skill.Name AS p3Name FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive3ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p3Name,
	(SELECT Skill.Description AS p3Descr FROM Skill WHERE Skill.SkillID = --Select just one item from this item list
		(SELECT SkillList.Passive3ID FROM SkillList WHERE SkillList.SkillListID = --Select just one build snapshot from this build snapshot
			(SELECT BuildSnapshot.SkillListID FROM BuildSnapshot WHERE BuildSnapshot.HeroID = --select just one hero from this profile
				(SELECT Hero.HeroID FROM Hero JOIN UserProfile ON Hero.UserID = UserProfile.UserID WHERE Hero.HeroName = @HeroName AND UserProfile.UserGUID = @GUID)))) AS p3Descr) 
COMMIT TRANSACTION
GO