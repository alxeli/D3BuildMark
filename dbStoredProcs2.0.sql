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
DELETE FROM Hero
	WHERE Hero.UserID = (SELECT UserProfile.UserID FROM UserProfile WHERE UserProfile.UserGUID = @GUID)
	AND Hero.HeroName = @HeroName
	AND hero.HeroClass = @HeroClass
COMMIT
GO

IF OBJECT_ID('AddItem') IS NOT NULL
DROP PROC AddItem
GO
--function to add a single item and link it to the correct build snapshot
CREATE PROC AddItem
	@BuildSnapshotID int,
	@ItemType varchar(9),
	@Name varchar(60),
	@Attributes varchar(500)
AS 
BEGIN TRANSACTION
	INSERT INTO Item (Name, Attributes) 
		VALUES (@Name, @Attributes)

	INSERT INTO BS_Item (BuildSnapshotID, ItemID, ItemType)
		VALUES (@BuildSnapshotID, IDENT_CURRENT('Item'), @ItemType)
COMMIT
GO

IF OBJECT_ID('AddSkill') IS NOT NULL
DROP PROC AddSkill
GO
--function to add a single item and link it to the correct build snapshot
CREATE PROC AddSkill
	@BuildSnapshotID int, 
	@SkillType varchar(9), 
	@Name varchar(60), 
	@Description varchar(200)
AS 
BEGIN TRANSACTION
	INSERT INTO Skill (Name, Description) 
		VALUES (@Name, @Description)

	INSERT INTO BS_Skill (BuildSnapshotID, SkillID, SkillType) 
		VALUES (@BuildSnapshotID, IDENT_CURRENT('Skill'), @SkillType)
COMMIT
GO

IF OBJECT_ID('spCreateBuildMark') IS NOT NULL
DROP PROC spCreateBuildMark
GO
CREATE PROC spCreateBuildMark
	@GUID			uniqueidentifier,
	@Battletag		varchar(40),
	@HeroName		varchar(12),
	@BuildName		varchar(30),

	@ScoreSingle	int,
	@ScoreMultiple	int,
	@Strength		int,
	@Dexterity		int,
	@Intelligence	int,
	@Vitality		int,
	@Damage			int,
	@Toughness		int,
	@Recovery		int,
	@Life			int,
	@Date			datetime
AS
BEGIN TRANSACTION
	INSERT INTO BuildMark (BuildSnapshotID, ScoreSingle, ScoreMultiple, Strength, Dexterity, Intelligence, Vitality, Damage, Toughness, Recovery, Life, Date)
		VALUES
		(
			(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot
				JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
				JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
					WHERE UserProfile.UserGUID = @GUID
					AND UserProfile.Battletag = @Battletag
					AND Hero.HeroName = @HeroName
					AND BuildSnapshot.BuildName = @BuildName),
			@ScoreSingle,
			@ScoreMultiple,
			@Strength,
			@Dexterity,
			@Intelligence,
			@Vitality,
			@Damage,
			@Toughness,
			@Recovery,
			@Life,
			@Date
		)
COMMIT
GO

IF OBJECT_ID('spReadBuildMark') IS NOT NULL
DROP PROC spReadBuildMark
GO
CREATE PROC spReadBuildMark
	@GUID			uniqueidentifier,
	@Battletag		varchar(40),
	@HeroName		varchar(12),
	@BuildName		varchar(30)
AS
BEGIN TRANSACTION
	SELECT BuildMark.ScoreSingle, BuildMark.ScoreMultiple, BuildMark.Strength, BuildMark.Dexterity, 
		BuildMark.Intelligence, BuildMark.Vitality, BuildMark.Damage, BuildMark.Toughness, 
		BuildMark.Recovery, BuildMark.Life, BuildMark.Date 
		FROM BuildMark 
		JOIN BuildSnapshot ON BuildMark.BuildSnapshotID = BuildSnapshot.BuildSnapshotID
		JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
			WHERE UserProfile.UserGUID = @GUID
			AND UserProfile.Battletag = @Battletag
			AND Hero.HeroName = @HeroName
			AND BuildSnapshot.BuildName = @BuildName
COMMIT
GO

IF OBJECT_ID('spUpdateBuildMarkScore') IS NOT NULL
DROP PROC spUpdateBuildMarkScore
GO
CREATE PROC spUpdateBuildMarkScore
	@GUID			uniqueidentifier,
	@Battletag		varchar(40),
	@HeroName		varchar(12),
	@BuildName		varchar(30),

	@ScoreSingle	int,
	@ScoreMultiple	int
AS
BEGIN TRANSACTION
	UPDATE BuildMark 
	SET BuildMark.ScoreSingle = @ScoreSingle, BuildMark.ScoreMultiple = @ScoreMultiple 
	WHERE BuildMark.BuildSnapshotID = 
		(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot
			JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
			JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
				WHERE UserProfile.UserGUID = @GUID
				AND UserProfile.Battletag = @Battletag
				AND Hero.HeroName = @HeroName
				AND BuildSnapshot.BuildName = @BuildName)
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
	INSERT INTO BuildSnapshot (HeroID, BuildName)VALUES
	(
		(SELECT Hero.HeroID FROM (Hero JOIN UserProfile ON UserProfile.UserID = Hero.UserID) WHERE Hero.HeroName = @HeroName),
		@BuildName 
	)

	DECLARE @BS_CURRENT_ID_QUERY	int 
	SET @BS_CURRENT_ID_QUERY = IDENT_CURRENT('BuildSnapshot')

	exec AddItem @BS_CURRENT_ID_QUERY, 'Head', @HeadName, @HeadAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Neck', @NeckName, @NeckAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Shoulders', @ShouldersName, @ShouldersAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Gloves', @GlovesName, @GlovesAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Chest', @ChestName, @ChestAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Bracers', @BracersName, @BracersAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Belt', @BeltName, @BeltAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'LeftRing', @LeftRingName, @LeftRingAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'RightRing', @RightRingName, @RightRingAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Pants', @PantsName, @PantsAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'Boots', @BootsName, @BootsAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'LeftHand', @LeftHandName, @LeftHandAtt
	exec AddItem @BS_CURRENT_ID_QUERY, 'RightHand', @RightHandName, @RightHandAtt

	exec AddSkill @BS_CURRENT_ID_QUERY, 'A0', @Act0Name, @Act0Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'A1', @Act1Name, @Act1Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'A2', @Act2Name, @Act2Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'A3', @Act3Name, @Act3Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'A4', @Act4Name, @Act4Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'A5', @Act5Name, @Act5Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'P0', @Pass0Name, @Pass0Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'P1', @Pass1Name, @Pass1Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'P2', @Pass2Name, @Pass2Desc
	exec AddSkill @BS_CURRENT_ID_QUERY, 'P3', @Pass3Name, @Pass3Desc
COMMIT TRANSACTION
GO

IF OBJECT_ID('spDeleteBuildSnapshot') IS NOT NULL
DROP PROC spDeleteBuildSnapshot
GO
CREATE PROC spDeleteBuildSnapshot
	@GUID			uniqueidentifier,
	@HeroName		varchar(12),
	@Battletag		varchar(40),
	@BuildName		varchar(30)
AS 
BEGIN TRANSACTION
	DELETE BS_Item 
	WHERE BS_Item.BuildSnapshotID IN 
		(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot 
			JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
			JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
				WHERE UserProfile.UserGUID = @GUID
				AND UserProfile.Battletag = @Battletag
				AND Hero.HeroName = @HeroName
				AND BuildSnapshot.BuildName = @BuildName)
	DELETE BS_Skill 
	WHERE BS_Skill.BuildSnapshotID IN 
		(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot 
			JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
			JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
				WHERE UserProfile.UserGUID = @GUID
				AND UserProfile.Battletag = @Battletag
				AND Hero.HeroName = @HeroName
				AND BuildSnapshot.BuildName = @BuildName)

	DELETE Item 
	WHERE Item.ItemID NOT IN (SELECT BS_Item.ItemID FROM BS_Item)
	DELETE Skill 
	WHERE Skill.SkillID NOT IN (SELECT BS_Skill.SkillID FROM BS_Skill)
	DELETE BuildMark
	WHERE BuildMark.BuildSnapshotID = 
		(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot 
			JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
			JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
				WHERE UserProfile.UserGUID = @GUID
				AND UserProfile.Battletag = @Battletag
				AND Hero.HeroName = @HeroName
				AND BuildSnapshot.BuildName = @BuildName)
	DELETE BuildSnapshot
	WHERE BuildSnapshot.BuildSnapshotID = 
		(SELECT BuildSnapshot.BuildSnapshotID FROM BuildSnapshot 
			JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
			JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
				WHERE UserProfile.UserGUID = @GUID
				AND UserProfile.Battletag = @Battletag
				AND Hero.HeroName = @HeroName
				AND BuildSnapshot.BuildName = @BuildName)
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
	SELECT BuildSnapshot.BuildName FROM BuildSnapshot 
		JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
			WHERE UserProfile.UserGUID = @GUID
			AND UserProfile.Battletag = @Battletag
			AND Hero.HeroName = @HeroName
COMMIT TRANSACTION
GO

IF OBJECT_ID('spUpdateBuildSnapshotName') IS NOT NULL
DROP PROC spUpdateBuildSnapshotName
GO
CREATE PROC spUpdateBuildSnapshotName
@GUID			uniqueidentifier,
@Battletag		varchar(40),
@HeroName		varchar(12),
@BuildName		varchar(30),
@NewName		varchar(30)
AS
BEGIN TRANSACTION
UPDATE BuildSnapshot 
SET BuildSnapshot.BuildName = @NewName
FROM BuildSnapshot 
	JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
	JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
		WHERE UserProfile.UserGUID = @GUID
		AND UserProfile.Battletag = @Battletag
		AND Hero.HeroName = @HeroName
		AND BuildSnapshot.BuildName = @BuildName
COMMIT TRANSACTION
GO

IF OBJECT_ID('spReadItems') IS NOT NULL
DROP PROC spReadItems
GO
CREATE PROC spReadItems
@GUID			uniqueidentifier,
@Battletag		varchar(40),
@HeroName		varchar(12),
@BuildName		varchar(30)
AS
BEGIN TRANSACTION
	SELECT BS_Item.ItemType, Item.Name, Item.Attributes FROM Item
		JOIN BS_Item ON Item.ItemID = BS_Item.ItemID
		JOIN BuildSnapshot ON BS_Item.BuildSnapshotID = BuildSnapshot.BuildSnapshotID
		JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
			WHERE UserProfile.UserGUID = @GUID
			AND UserProfile.Battletag = @Battletag
			AND Hero.HeroName = @HeroName
			AND BuildSnapshot.BuildName = @BuildName
COMMIT TRANSACTION
GO

IF OBJECT_ID('spReadSkills') IS NOT NULL
DROP PROC spReadSkills
GO
CREATE PROC spReadSkills
@GUID			uniqueidentifier,
@Battletag		varchar(40),
@HeroName		varchar(12),
@BuildName		varchar(30)
AS
BEGIN TRANSACTION
	SELECT BS_Skill.SkillType, Skill.Name, Skill.Description FROM Skill
		JOIN BS_Skill ON Skill.SkillID = BS_Skill.SkillID
		JOIN BuildSnapshot ON BS_Skill.BuildSnapshotID = BuildSnapshot.BuildSnapshotID
		JOIN Hero ON BuildSnapshot.HeroID = Hero.HeroID
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID 
			WHERE UserProfile.UserGUID = @GUID
			AND UserProfile.Battletag = @Battletag
			AND Hero.HeroName = @HeroName
			AND BuildSnapshot.BuildName = @BuildName
	ORDER BY BS_Skill.SkillType ASC
COMMIT TRANSACTION
GO

IF OBJECT_ID('spSearchHeroNames') IS NOT NULL
DROP PROC spSearchHeroNames
GO
CREATE PROC spSearchHeroNames
@HeroName		varchar(12)
AS SELECT UserProfile.UserGUID, UserProfile.UserName, UserProfile.Battletag, Hero.HeroName, Hero.HeroClass FROM Hero 
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID
		WHERE Hero.HeroName LIKE CONCAT('%', @HeroName, '%')
GO

IF OBJECT_ID('spSearchClassNames') IS NOT NULL
DROP PROC spSearchClassNames
GO
CREATE PROC spSearchClassNames
@ClassName		varchar(12)
AS SELECT UserProfile.UserGUID, UserProfile.UserName, UserProfile.Battletag, Hero.HeroName, Hero.HeroClass FROM Hero 
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID
		WHERE Hero.HeroClass LIKE CONCAT('%', @ClassName, '%')
GO

IF OBJECT_ID('spSearchBattletags') IS NOT NULL
DROP PROC spSearchBattletags
GO
CREATE PROC spSearchBattletags
@Battletag varchar(40)
AS SELECT UserProfile.UserGUID, UserProfile.UserName, UserProfile.Battletag, Hero.HeroName, Hero.HeroClass FROM Hero 
		JOIN UserProfile ON Hero.UserID = UserProfile.UserID
		WHERE UserProfile.Battletag LIKE CONCAT('%', @Battletag, '%')
GO

