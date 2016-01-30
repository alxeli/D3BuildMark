--1 run this script
--2 run aspnet_regsql on D3BuildMark db
--3 run stored procs script
--4 run member connect script
--5 register new user 
--5 retrieve GUID from db
--6 update test code with this GUID

USE master;
GO

IF  DB_ID('D3BuildMark') IS NOT NULL
DROP DATABASE D3BuildMark;
GO

CREATE DATABASE D3BuildMark;
GO

USE D3BuildMark;

CREATE TABLE Skill
(
	SkillID			int				CONSTRAINT	Skill_PK			PRIMARY KEY IDENTITY,
	Name			varchar(60)		NOT NULL,
	Description		varchar(200)	NOT NULL
);
ALTER TABLE Skill
	ADD CONSTRAINT unique_S UNIQUE(Name, Description);

CREATE TABLE SkillList
(
	SkillListID		int				CONSTRAINT	SkillList_PK		PRIMARY KEY IDENTITY,
	Active0ID		int				CONSTRAINT	A0_FK_SL			REFERENCES Skill(SkillID),
	Active1ID		int				CONSTRAINT	A1_FK_SL			REFERENCES Skill(SkillID),
	Active2ID		int				CONSTRAINT	A2_FK_SL			REFERENCES Skill(SkillID),
	Active3ID		int				CONSTRAINT	A3_FK_SL			REFERENCES Skill(SkillID),
	Active4ID		int				CONSTRAINT	A4_FK_SL			REFERENCES Skill(SkillID),
	Active5ID		int				CONSTRAINT	A5_FK_SL			REFERENCES Skill(SkillID),
	Passive0ID		int				CONSTRAINT	P0_FK_SL			REFERENCES Skill(SkillID),
	Passive1ID		int				CONSTRAINT	P1_FK_SL			REFERENCES Skill(SkillID),
	Passive2ID		int				CONSTRAINT	P2_FK_SL			REFERENCES Skill(SkillID),
	Passive3ID		int				CONSTRAINT	P3_FK_SL			REFERENCES Skill(SkillID)
);

CREATE TABLE Item
(
	ItemID			int				CONSTRAINT	Item_PK				PRIMARY KEY IDENTITY,
	Name			varchar(60)		NOT NULL,
	Attributes		varchar(500)	NOT NULL
);

ALTER TABLE Item
	ADD CONSTRAINT unique_I UNIQUE(Name, Attributes);

CREATE TABLE ItemList
(
	ItemListID		int				CONSTRAINT	ItemList_PK		PRIMARY KEY IDENTITY,
	HeadID			int				CONSTRAINT	Head_FK_IL		REFERENCES Item(ItemID),
	NeckID			int				CONSTRAINT	Neck_FK_IL		REFERENCES Item(ItemID),
	ShouldersID		int				CONSTRAINT	Shoulders_FK_IL	REFERENCES Item(ItemID),
	GlovesID		int				CONSTRAINT	Gloves_FK_IL	REFERENCES Item(ItemID),
	ChestID			int				CONSTRAINT	Chest_FK_IL		REFERENCES Item(ItemID),
	BracersID		int				CONSTRAINT	Bracers_FK_IL	REFERENCES Item(ItemID),
	BeltID			int				CONSTRAINT	Belt_FK_IL		REFERENCES Item(ItemID),
	LeftRingID		int				CONSTRAINT	LeftRing_FK_IL	REFERENCES Item(ItemID),
	RightRingID		int				CONSTRAINT	RightRing_FK_IL	REFERENCES Item(ItemID),
	PantsID			int				CONSTRAINT	Pants_FK_IL		REFERENCES Item(ItemID),
	BootsID			int				CONSTRAINT	Boots_FK_IL		REFERENCES Item(ItemID),
	LeftHandID		int				CONSTRAINT	LeftHand_FK_IL	REFERENCES Item(ItemID),
	RightHandID		int				CONSTRAINT	RightHand_FK_IL	REFERENCES Item(ItemID)
);

CREATE TABLE BuildMark
(
	BuildMarkID		int				CONSTRAINT	BuildMark_PK		PRIMARY KEY IDENTITY,
  --BuildSnapshotID	int				CONSTRAINT	BuildSnapshot_FK 	REFERENCES BuildSnapshot(BuildSnapshotID), (added later)
	Score			varchar(20)		NOT NULL,
	Damage			varchar(20)		NOT NULL,
	Toughness		varchar(20)		NOT NULL,
	Date			DateTime		NOT NULL
);

CREATE TABLE UserProfile
(
	UserID			int				CONSTRAINT	User_PK				PRIMARY KEY IDENTITY,
	UserGUID		uniqueidentifier, --CONSTRAINT	UserGUID_FK_aU		REFERENCES aspnet_Users(UserId), (add later in dbMembCon.sql)
	UserName		varchar(40)		NOT NULL	CONSTRAINT UserName_UNQ		UNIQUE(UserName),
	Battletag		varchar(40)
);

CREATE TABLE Hero
(
	HeroID			int				CONSTRAINT	Hero_PK				PRIMARY KEY IDENTITY,
	UserID			int				CONSTRAINT	User_FK_UP			REFERENCES UserProfile(UserID),
	HeroName		varchar(12)		NOT NULL,
	HeroClass		varchar(12)		NOT NULL
);

CREATE TABLE BuildSnapshot
(
	BuildSnapshotID	int				CONSTRAINT	BuildSnapshot_PK	PRIMARY KEY IDENTITY,
	HeroID			int				CONSTRAINT	Hero_FK_BS			REFERENCES Hero(HeroID),
	BuildMarkID		int				CONSTRAINT	BuildMark_FK_BS		REFERENCES BuildMark(BuildMarkID),
	SkillListID		int				CONSTRAINT	SkillList_FK_BS		REFERENCES SkillList(SkillListID),
	ItemListID		int				CONSTRAINT	ItemList_FK_BS		REFERENCES ItemList(ItemListID),
	BuildName		varchar(30)		NOT NULL
);

--now add that BuildMark foreign key...
ALTER TABLE BuildMark
ADD BuildSnapshotID int
GO

ALTER TABLE BuildMark
ADD CONSTRAINT BuildSnapshot_FK
FOREIGN KEY (BuildSnapshotID)
REFERENCES BuildSnapshot(BuildSnapshotID)
GO


Create Role DBManagement;
GO

Grant Select, Insert, Update, Delete, Execute
To DBManagement;
GO

DROP LOGIN DBManager;
GO

CREATE LOGIN DBManager WITH PASSWORD = 'DBManager',
	DEFAULT_DATABASE = D3BuildMark;
GO

CREATE USER DBManager FOR LOGIN DBManager;
GO

Alter Role DBManagement Add Member DBManager;
GO