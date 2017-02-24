USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 1:14:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 1:14:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[name] [varchar](255) NULL,
	[shift] [varchar](255) NULL,
	[specialty] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([name], [stylist_id], [id]) VALUES (N'lkdsfsadf', 7, 5)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([name], [shift], [specialty], [id]) VALUES (N'Keely', N'close', N'hair', 6)
INSERT [dbo].[stylists] ([name], [shift], [specialty], [id]) VALUES (N'dsf', N'', N'', 7)
INSERT [dbo].[stylists] ([name], [shift], [specialty], [id]) VALUES (N'dsfas', N'sadf', N'dsf', 8)
INSERT [dbo].[stylists] ([name], [shift], [specialty], [id]) VALUES (N'dfsd', N'', N'', 9)
SET IDENTITY_INSERT [dbo].[stylists] OFF
