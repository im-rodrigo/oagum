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
