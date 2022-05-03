USE [UserDatabase]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 5/2/2022 8:35:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NULL
) ON [PRIMARY]
GO


