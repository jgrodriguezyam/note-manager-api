/* Using Database sqlserver2008 and Connection String Server=link_jorge_HP\LOCALHOST; Database=NoteManager; User Id=sa; Password=********; */
/* VersionMigration migrating ================================================ */

/* Beginning Transaction */
/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)

/* Committing Transaction */
/* VersionMigration migrated */

/* VersionUniqueMigration migrating ========================================== */

/* Beginning Transaction */
/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)

/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME

/* Committing Transaction */
/* VersionUniqueMigration migrated */

/* VersionDescriptionMigration migrating ===================================== */

/* Beginning Transaction */
/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo Description String */
ALTER TABLE [dbo].[VersionInfo] ADD [Description] NVARCHAR(1024)

/* Committing Transaction */
/* VersionDescriptionMigration migrated */

/* 1: _1_Seed migrating ====================================================== */

/* Beginning Transaction */
/* CreateTable User */
CREATE TABLE [dbo].[User] ([Id] INT NOT NULL IDENTITY(1,1), [UserName] NVARCHAR(250) NOT NULL, [Password] NVARCHAR(250) NOT NULL, [CreatedBy] INT NOT NULL, [ModifiedBy] INT NOT NULL, [CreatedOn] DATETIME NOT NULL, [ModifiedOn] DATETIME NOT NULL, [IsActive] BIT NOT NULL, CONSTRAINT [PK_User] PRIMARY KEY ([Id]))

/* CreateIndex User (UserName) */
CREATE UNIQUE INDEX [IX_User_UserName] ON [dbo].[User] ([UserName] ASC)

/* CreateTable Company */
CREATE TABLE [dbo].[Company] ([Id] INT NOT NULL IDENTITY(1,1), [Name] NVARCHAR(250) NOT NULL, [Address] NVARCHAR(250) NOT NULL, [Colony] NVARCHAR(250) NOT NULL, [City] NVARCHAR(250) NOT NULL, [Rfc] NVARCHAR(250) NOT NULL, [OfficePhone] NVARCHAR(250), [OfficeCellPhone] NVARCHAR(250), [Folio] INT NOT NULL CONSTRAINT [DF_Company_Folio] DEFAULT 0, [CreatedBy] INT NOT NULL, [ModifiedBy] INT NOT NULL, [CreatedOn] DATETIME NOT NULL, [ModifiedOn] DATETIME NOT NULL, [IsActive] BIT NOT NULL, CONSTRAINT [PK_Company] PRIMARY KEY ([Id]))

/* CreateTable Customer */
CREATE TABLE [dbo].[Customer] ([Id] INT NOT NULL IDENTITY(1,1), [Name] NVARCHAR(250) NOT NULL, [LastName] NVARCHAR(250) NOT NULL, [Gender] INT NOT NULL, [Address] NVARCHAR(250) NOT NULL, [Colony] NVARCHAR(250) NOT NULL, [Municipality] NVARCHAR(250) NOT NULL, [HomePhone] NVARCHAR(250), [CellPhone] NVARCHAR(250), [CreatedBy] INT NOT NULL, [ModifiedBy] INT NOT NULL, [CreatedOn] DATETIME NOT NULL, [ModifiedOn] DATETIME NOT NULL, [IsActive] BIT NOT NULL, CONSTRAINT [PK_Customer] PRIMARY KEY ([Id]))

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (1, '2017-09-02T23:48:35', '_1_Seed')
/* Committing Transaction */
/* 1: _1_Seed migrated */

/* Task completed. */
