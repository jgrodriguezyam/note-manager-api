/* Using Database sqlserver2008 and Connection String Server=mssql6.gear.host; Database=notemanager; User Id=notemanager; Password=********; */
/* 1: _1_Seed reverting ====================================================== */

/* Beginning Transaction */
/* DeleteTable User */
DROP TABLE [dbo].[User]

/* DeleteTable Company */
DROP TABLE [dbo].[Company]

/* DeleteTable Customer */
DROP TABLE [dbo].[Customer]

DELETE FROM [dbo].[VersionInfo] WHERE [Version] = 1
/* Committing Transaction */
/* 1: _1_Seed reverted */

DROP TABLE [dbo].[VersionInfo]
/* Task completed. */
