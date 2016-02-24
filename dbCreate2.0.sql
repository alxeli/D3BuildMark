--1 run this script
--2 run aspnet_regsql on D3BuildMark db
--3 run stored procs script
--4 run member connect script

USE master;
GO

IF  DB_ID('D3BuildMark') IS NOT NULL
DROP DATABASE D3BuildMark;
GO

CREATE DATABASE D3BuildMark;
GO

USE D3BuildMark;

CREATE TABLE BuildSnapshot
(
	BuildSnapshotID	int				CONSTRAINT	BuildSnapshot_PK	PRIMARY KEY IDENTITY,
	--HeroID		int				CONSTRAINT	Hero_FK_H			REFERENCES Hero(HeroID) ON DELETE CASCADE,
	BuildName		varchar(30)		NOT NULL
);

CREATE TABLE Skill
(
	SkillID			int				CONSTRAINT	Skill_PK			PRIMARY KEY IDENTITY,
	Name			varchar(60)		NOT NULL,
	Description		varchar(200)	NOT NULL
	--CONSTRAINT unique_S UNIQUE(Name, Description)
);

CREATE TABLE BS_Skill
(
	BuildSnapshotID		int			CONSTRAINT	BSS_BS_FK		REFERENCES BuildSnapshot(BuildSnapshotID),
	SkillID				int			CONSTRAINT	BSS_Skill_FK	REFERENCES Skill(SkillID),
	SkillType			varchar(2)	NOT NULL
);

CREATE TABLE Item 
(
	ItemID			int				CONSTRAINT	Item_PK			PRIMARY KEY IDENTITY ,
	Name			varchar(60)		NOT NULL,
	Attributes		varchar(500)	NOT NULL
	--CONSTRAINT unique_I UNIQUE(Name, Attributes)
);

CREATE TABLE BS_Item
(
	BuildSnapshotID		int			CONSTRAINT	BSI_BS_FK		REFERENCES BuildSnapshot(BuildSnapshotID),
	ItemID				int			CONSTRAINT	BSI_Item_FK		REFERENCES Item(ItemID),
	ItemType			varchar(9)	NOT NULL
);

CREATE TABLE BuildMark
(
	BuildMarkID		int				CONSTRAINT	BuildMark_PK		PRIMARY KEY IDENTITY,
	BuildSnapshotID	int				CONSTRAINT	BuildSnapshot_FK 	REFERENCES BuildSnapshot(BuildSnapshotID),
	Score			int				NOT NULL,
	Damage			int				NOT NULL,
	Toughness		int				NOT NULL,
	Recovery		int				NOT NULL,
	PrimaryAtt		int				NOT NULL,
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
	UserID			int				CONSTRAINT	User_FK_UP			REFERENCES UserProfile(UserID) ON DELETE CASCADE,
	HeroName		varchar(12)		NOT NULL,
	HeroClass		varchar(12)		NOT NULL
);

ALTER TABLE BuildSnapshot
ADD HeroID int
GO

ALTER TABLE BuildSnapshot
ADD CONSTRAINT Hero_FK_H
FOREIGN KEY (HeroID)
REFERENCES Hero(HeroID)
GO

ALTER TABLE BuildSnapshot
ADD CONSTRAINT BS_hero_name_UNQ
UNIQUE (HeroID, BuildName)
GO



--Create Role DBManagement;
--GO

--Grant Select, Insert, Update, Delete, Execute
--To DBManagement;
--GO

--DROP LOGIN DBManager;
--GO

--CREATE LOGIN DBManager WITH PASSWORD = 'DBManager',
--	DEFAULT_DATABASE = D3BuildMark;
--GO

--CREATE USER DBManager FOR LOGIN DBManager;
--GO

--Alter Role DBManagement Add Member DBManager;
--GO