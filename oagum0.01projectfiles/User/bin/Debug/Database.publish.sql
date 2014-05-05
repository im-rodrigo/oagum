﻿/*
Deployment script for Membership

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Membership"
:setvar DefaultFilePrefix "Membership"
:setvar DefaultDataPath "C:\Users\Shaymas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\"
:setvar DefaultLogPath "C:\Users\Shaymas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Email]...';


GO
CREATE TYPE [dbo].[Email]
    FROM NVARCHAR (100) NULL;


GO
PRINT N'Creating [dbo].[Flag]...';


GO
CREATE TYPE [dbo].[Flag]
    FROM BIT NOT NULL;


GO
PRINT N'Creating [dbo].[Name]...';


GO
CREATE TYPE [dbo].[Name]
    FROM NVARCHAR (50) NOT NULL;


GO
PRINT N'Creating [dbo].[Phone]...';


GO
CREATE TYPE [dbo].[Phone]
    FROM NVARCHAR (25) NULL;


GO
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [UserID]               INT            IDENTITY (1000, 1) NOT NULL,
    [UserName]             [dbo].[Name]   NOT NULL,
    [Email]                [dbo].[Email]  NULL,
    [EmailConfirmed]       [dbo].[Flag]   NOT NULL,
    [PasswordHash]         NVARCHAR (100) NULL,
    [SecurityStamp]        NVARCHAR (100) NULL,
    [PhoneNumber]          [dbo].[Phone]  NULL,
    [PhoneNumberConfirmed] [dbo].[Flag]   NOT NULL,
    [TwoFactorEnabled]     [dbo].[Flag]   NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       [dbo].[Flag]   NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [UK_User_UserName] UNIQUE NONCLUSTERED ([UserName] ASC)
);


GO
PRINT N'Creating [dbo].[UserClaim]...';


GO
CREATE TABLE [dbo].[UserClaim] (
    [UserID]     INT            NOT NULL,
    [ClaimID]    INT            IDENTITY (1000, 1) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserClaim_ClaimID] PRIMARY KEY CLUSTERED ([ClaimID] ASC)
);


GO
PRINT N'Creating [dbo].[UserClaim].[IX_UserClaim_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserClaim_UserID]
    ON [dbo].[UserClaim]([UserID] ASC);


GO
PRINT N'Creating [dbo].[UserLogin]...';


GO
CREATE TABLE [dbo].[UserLogin] (
    [UserID]        INT            NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_UserLogin_UserID_LoginProvider_ProviderKey] PRIMARY KEY CLUSTERED ([UserID] ASC, [LoginProvider] ASC, [ProviderKey] ASC)
);


GO
PRINT N'Creating [dbo].[UserLogin].[IX_UserLogin_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserLogin_UserID]
    ON [dbo].[UserLogin]([UserID] ASC);


GO
PRINT N'Creating [dbo].[UserRole]...';


GO
CREATE TABLE [dbo].[UserRole] (
    [RoleID] INT          NOT NULL,
    [Name]   [dbo].[Name] NOT NULL,
    CONSTRAINT [PK_UserRole_RoleID] PRIMARY KEY CLUSTERED ([RoleID] ASC),
    CONSTRAINT [UK_UserRole_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Creating [dbo].[UserUserRole]...';


GO
CREATE TABLE [dbo].[UserUserRole] (
    [UserID] INT NOT NULL,
    [RoleID] INT NOT NULL,
    CONSTRAINT [PK_UserUserRole_UserID_RoleID] PRIMARY KEY CLUSTERED ([UserID] ASC, [RoleID] ASC)
);


GO
PRINT N'Creating [dbo].[UserUserRole].[IX_UserUserRole_UserID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserUserRole_UserID]
    ON [dbo].[UserUserRole]([UserID] ASC);


GO
PRINT N'Creating [dbo].[UserUserRole].[IX_UserUserRole_RoleID]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserUserRole_RoleID]
    ON [dbo].[UserUserRole]([RoleID] ASC);


GO
PRINT N'Creating FK_UserClaim_User...';


GO
ALTER TABLE [dbo].[UserClaim]
    ADD CONSTRAINT [FK_UserClaim_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_UserLogin_User...';


GO
ALTER TABLE [dbo].[UserLogin]
    ADD CONSTRAINT [FK_UserLogin_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_UserUserRole_User...';


GO
ALTER TABLE [dbo].[UserUserRole]
    ADD CONSTRAINT [FK_UserUserRole_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_UserUserRole_UserRole...';


GO
ALTER TABLE [dbo].[UserUserRole]
    ADD CONSTRAINT [FK_UserUserRole_UserRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[UserRole] ([RoleID]) ON DELETE CASCADE;


GO
/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[User] ON;
GO

MERGE INTO [dbo].[User] AS Target
USING (VALUES

    (1, N'admin', N'admin@example.com', 0, N'ACe+kHUdH61ms8NbkXSCXyV34CEP7tjfj93JrtlKRPfShGurFdAujQrmbVA7J9MDbg==',
        N'9771f91d-b4a0-45e0-8971-899b907c5863', NULL, 0, 0, NULL, 0, 0),
    (2, N'demo', N'demo@example.com', 0, N'ACe+kHUdH61ms8NbkXSCXyV34CEP7tjfj93JrtlKRPfShGurFdAujQrmbVA7J9MDbg==',
        N'9771f91d-b4a0-45e0-8971-899b907c5863', NULL, 0, 0, NULL, 0, 0)

) AS Source (
    [UserID],
    [UserName],
    [Email],
    [EmailConfirmed],
    [PasswordHash],
    [SecurityStamp],
    [PhoneNumber],
    [PhoneNumberConfirmed],
    [TwoFactorEnabled],
    [LockoutEndDateUtc],
    [LockoutEnabled],
    [AccessFailedCount]
)
ON Target.[UserID] = Source.[UserID]
-- Update matched rows
WHEN MATCHED THEN
UPDATE SET
    [UserName] = Source.[UserName],
    [Email] = Source.[Email],
    [EmailConfirmed] = Source.[EmailConfirmed],
    [PasswordHash] = Source.[PasswordHash],
    [SecurityStamp] = Source.[SecurityStamp],
    [PhoneNumber] = Source.[PhoneNumber],
    [PhoneNumberConfirmed] = Source.[PhoneNumberConfirmed],
    [TwoFactorEnabled] = Source.[TwoFactorEnabled],
    [LockoutEndDateUtc] = Source.[LockoutEndDateUtc],
    [LockoutEnabled] = Source.[LockoutEnabled],
    [AccessFailedCount] = Source.[AccessFailedCount]
-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (
    [UserID],
    [UserName],
    [Email],
    [EmailConfirmed],
    [PasswordHash],
    [SecurityStamp],
    [PhoneNumber],
    [PhoneNumberConfirmed],
    [TwoFactorEnabled],
    [LockoutEndDateUtc],
    [LockoutEnabled],
    [AccessFailedCount]
)
VALUES (
    [UserID],
    [UserName],
    [Email],
    [EmailConfirmed],
    [PasswordHash],
    [SecurityStamp],
    [PhoneNumber],
    [PhoneNumberConfirmed],
    [TwoFactorEnabled],
    [LockoutEndDateUtc],
    [LockoutEnabled],
    [AccessFailedCount]
);
GO

SET IDENTITY_INSERT [dbo].[User] OFF;
GO
MERGE INTO [dbo].[UserRole] AS Target
USING (VALUES

    (1, N'Administrator'),
    (2, N'Moderator')

) AS Source ([RoleID], [Name])
ON Target.[RoleID] = Source.[RoleID]
-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Name] = Source.[Name]
-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([RoleID], [Name])
VALUES ([RoleID], [Name])
-- Delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO
MERGE INTO [dbo].[UserUserRole] AS Target
USING (VALUES

    (1, 1)

) AS Source ([UserID], [RoleID])
ON Target.[UserID] = Source.[UserID] AND Target.[RoleID] = Source.[RoleID]
WHEN NOT MATCHED BY TARGET THEN
-- Insert new rows
INSERT ([UserID], [RoleID])
VALUES ([UserID], [RoleID]);
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO