USE [UserDatabase]
GO

/****** Object:  Table [dbo].[User]    Script Date: 5/2/2022 9:19:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL
) ON [PRIMARY]
GO


