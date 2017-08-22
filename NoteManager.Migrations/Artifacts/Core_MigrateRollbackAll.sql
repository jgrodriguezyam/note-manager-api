/* Using Database sqlserver2008 and Connection String Server=sqlsvr; Database=FRATERNITAS_DB; User Id=fraternitasAdmin; Password=********; */
/* 1: _1_Seed reverting ====================================================== */

/* Beginning Transaction */
/* DeleteForeignKey FK_Credit_Customer Credit ()  () */
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Customer]

/* DeleteForeignKey FK_Credit_Solicitude Credit ()  () */
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Solicitude]

/* DeleteTable Credit */
DROP TABLE [dbo].[Credit]

/* DeleteTable Worker */
DROP TABLE [dbo].[Worker]

/* DeleteForeignKey FK_Recommended_User Recommended ()  () */
ALTER TABLE [dbo].[Recommended] DROP CONSTRAINT [FK_Recommended_User]

/* DeleteTable Recommended */
DROP TABLE [dbo].[Recommended]

/* DeleteForeignKey FK_Solicitude_Customer Solicitude ()  () */
ALTER TABLE [dbo].[Solicitude] DROP CONSTRAINT [FK_Solicitude_Customer]

/* DeleteTable Solicitude */
DROP TABLE [dbo].[Solicitude]

/* DeleteForeignKey FK_Answer_Question Answer ()  () */
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Answer_Question]

/* DeleteForeignKey FK_Answer_QuestionOption Answer ()  () */
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Answer_QuestionOption]

/* DeleteForeignKey FK_Answer_SurveyResult Answer ()  () */
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Answer_SurveyResult]

/* DeleteTable Answer */
DROP TABLE [dbo].[Answer]

/* DeleteForeignKey FK_SurveyResult_Survey SurveyResult ()  () */
ALTER TABLE [dbo].[SurveyResult] DROP CONSTRAINT [FK_SurveyResult_Survey]

/* DeleteForeignKey FK_SurveyResult_Customer SurveyResult ()  () */
ALTER TABLE [dbo].[SurveyResult] DROP CONSTRAINT [FK_SurveyResult_Customer]

/* DeleteTable SurveyResult */
DROP TABLE [dbo].[SurveyResult]

/* DeleteForeignKey FK_QuestionOption_Question QuestionOption ()  () */
ALTER TABLE [dbo].[QuestionOption] DROP CONSTRAINT [FK_QuestionOption_Question]

/* DeleteTable QuestionOption */
DROP TABLE [dbo].[QuestionOption]

/* DeleteForeignKey FK_Question_Survey Question ()  () */
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_Survey]

/* DeleteTable Question */
DROP TABLE [dbo].[Question]

/* DeleteTable Survey */
DROP TABLE [dbo].[Survey]

/* DeleteForeignKey FK_CustomerReference_Address CustomerReference ()  () */
ALTER TABLE [dbo].[CustomerReference] DROP CONSTRAINT [FK_CustomerReference_Address]

/* DeleteForeignKey FK_CustomerReference_Customer CustomerReference ()  () */
ALTER TABLE [dbo].[CustomerReference] DROP CONSTRAINT [FK_CustomerReference_Customer]

/* DeleteForeignKey FK_CustomerReference_RelationshipApplicant CustomerReference ()  () */
ALTER TABLE [dbo].[CustomerReference] DROP CONSTRAINT [FK_CustomerReference_RelationshipApplicant]

/* DeleteTable CustomerReference */
DROP TABLE [dbo].[CustomerReference]

/* DeleteTable RelationshipApplicant */
DROP TABLE [dbo].[RelationshipApplicant]

/* DeleteForeignKey FK_Job_JobPosition Job ()  () */
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK_Job_JobPosition]

/* DeleteForeignKey FK_Job_Address Job ()  () */
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK_Job_Address]

/* DeleteForeignKey FK_Job_WorkHoursWeek Job ()  () */
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK_Job_WorkHoursWeek]

/* DeleteForeignKey FK_Job_WorkActivity Job ()  () */
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK_Job_WorkActivity]

/* DeleteForeignKey FK_Job_Customer Job ()  () */
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK_Job_Customer]

/* DeleteTable Job */
DROP TABLE [dbo].[Job]

/* DeleteTable JobPosition */
DROP TABLE [dbo].[JobPosition]

/* DeleteTable WorkActivity */
DROP TABLE [dbo].[WorkActivity]

/* DeleteTable WorkHoursWeek */
DROP TABLE [dbo].[WorkHoursWeek]

/* DeleteForeignKey FK_FinancialInformation_AmountEconomicDepents FinancialInformation ()  () */
ALTER TABLE [dbo].[FinancialInformation] DROP CONSTRAINT [FK_FinancialInformation_AmountEconomicDepents]

/* DeleteForeignKey FK_FinancialInformation_MonthlyIncome FinancialInformation ()  () */
ALTER TABLE [dbo].[FinancialInformation] DROP CONSTRAINT [FK_FinancialInformation_MonthlyIncome]

/* DeleteForeignKey FK_FinancialInformation_MonthlyExpenses FinancialInformation ()  () */
ALTER TABLE [dbo].[FinancialInformation] DROP CONSTRAINT [FK_FinancialInformation_MonthlyExpenses]

/* DeleteForeignKey FK_FinalcialInformation_Bank FinancialInformation ()  () */
ALTER TABLE [dbo].[FinancialInformation] DROP CONSTRAINT [FK_FinalcialInformation_Bank]

/* DeleteTable FinancialInformation */
DROP TABLE [dbo].[FinancialInformation]

/* DeleteTable AmountEconomicDependents */
DROP TABLE [dbo].[AmountEconomicDependents]

/* DeleteTable MonthlyExpenses */
DROP TABLE [dbo].[MonthlyExpenses]

/* DeleteTable MonthlyIncome */
DROP TABLE [dbo].[MonthlyIncome]

/* DeleteTable Bank */
DROP TABLE [dbo].[Bank]

/* DeleteForeignKey FK_DomiciliaryProofFile_Customer DomiciliaryProofFile ()  () */
ALTER TABLE [dbo].[DomiciliaryProofFile] DROP CONSTRAINT [FK_DomiciliaryProofFile_Customer]

/* DeleteTable DomiciliaryProofFile */
DROP TABLE [dbo].[DomiciliaryProofFile]

/* DeleteForeignKey FK_PaymentProofFile_Customer PaymentProofFile ()  () */
ALTER TABLE [dbo].[PaymentProofFile] DROP CONSTRAINT [FK_PaymentProofFile_Customer]

/* DeleteTable PaymentProofFile */
DROP TABLE [dbo].[PaymentProofFile]

/* DeleteForeignKey FK_IDProofFile_Customer IDProofFile ()  () */
ALTER TABLE [dbo].[IDProofFile] DROP CONSTRAINT [FK_IDProofFile_Customer]

/* DeleteTable IDProofFile */
DROP TABLE [dbo].[IDProofFile]

/* DeleteForeignKey FK_AccountStatementFile_Customer AccountStatementFile ()  () */
ALTER TABLE [dbo].[AccountStatementFile] DROP CONSTRAINT [FK_AccountStatementFile_Customer]

/* DeleteTable AccountStatementFile */
DROP TABLE [dbo].[AccountStatementFile]

/* DeleteForeignKey FK_Customer_IDType Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_IDType]

/* DeleteForeignKey FK_Customer_State Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_State]

/* DeleteForeignKey FK_Customer_YearsInUSA Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_YearsInUSA]

/* DeleteForeignKey FK_Customer_Address Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_Address]

/* DeleteForeignKey FK_Customer_PropertyType Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_PropertyType]

/* DeleteForeignKey FK_Customer_BestTimeCall Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_BestTimeCall]

/* DeleteForeignKey FK_Customer_CellPhoneCompany Customer ()  () */
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_CellPhoneCompany]

/* DeleteTable Customer */
DROP TABLE [dbo].[Customer]

/* DeleteTable IDType */
DROP TABLE [dbo].[IDType]

/* DeleteTable YearsInUSA */
DROP TABLE [dbo].[YearsInUSA]

/* DeleteTable PropertyType */
DROP TABLE [dbo].[PropertyType]

/* DeleteTable BestTimeCall */
DROP TABLE [dbo].[BestTimeCall]

/* DeleteTable CellPhoneCompany */
DROP TABLE [dbo].[CellPhoneCompany]

/* DeleteForeignKey FK_Address_State Address ()  () */
ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_State]

/* DeleteTable Address */
DROP TABLE [dbo].[Address]

/* DeleteTable State */
DROP TABLE [dbo].[State]

/* DeleteTable User */
DROP TABLE [dbo].[User]

DELETE FROM [dbo].[VersionInfo] WHERE [Version] = 1
/* Committing Transaction */
/* 1: _1_Seed reverted */

DROP TABLE [dbo].[VersionInfo]
/* Task completed. */
