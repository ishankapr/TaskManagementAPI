
CREATE DATABASE [TaskManagement]
 
USE [TaskManagement]

CREATE TABLE [dbo].[Tasks](
	[TaskID] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(100) NULL,
	[Description] NVARCHAR(500) NULL,
	[DueDate] DATETIME NULL,
	[IsCompleted] BIT NOT NULL DEFAULT 0,
	[CreatedDate] DATETIME NOT NULL,
	[CreatedBy] INT NULL,
)
