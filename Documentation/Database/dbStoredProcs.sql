Use D3BuildMark;
GO

IF OBJECT_ID('spCreateUserProfile') IS NOT NULL
DROP PROC spCreateUserProfile
GO

CREATE PROC spCreateUserProfile
@UserName		varchar(40),
@Password		varchar(40),
@Email			varchar(40),
@Battletag		varchar(40)
AS 
BEGIN TRANSACTION
INSERT INTO UserProfile (UserName, Password, Email, Battletag) VALUES (@UserName, @Password, @Email, @Battletag)
COMMIT
GO

IF OBJECT_ID('spReadUserProfile') IS NOT NULL
DROP PROC spReadUserProfile
GO

CREATE PROC spReadUserProfile
@UserName	varchar(40)
AS 
SELECT UserName, Password, Email, Battletag FROM UserProfile WHERE UserName = @UserName
GO