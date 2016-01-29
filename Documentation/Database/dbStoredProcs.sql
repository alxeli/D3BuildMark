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
INSERT INTO ItemList (HeadID, ShouldersID, NeckID, GlovesID, ChestID, BracersID, BeltID, LeftRingID, RightRingID, PantsID, BootsID, LeftHandID, RightHandID)
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
IF ((SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName) IS NULL)
	RAISERROR('Hero was not previously added', 16, 1);
IF ((SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName) IS NULL)
	ROLLBACK TRANSACTION;
ELSE 
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