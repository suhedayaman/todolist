USE [todo]
GO
/****** Object:  Table [dbo].[task]    Script Date: 30.08.2019 23:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[todotext] [nvarchar](50) NULL,
	[tododate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[task] ON 

INSERT [dbo].[task] ([id], [todotext], [tododate]) VALUES (6, N'My bestfriend''s birthday!', CAST(N'2019-09-10 00:00:00.000' AS DateTime))
INSERT [dbo].[task] ([id], [todotext], [tododate]) VALUES (7, N'Doctor''s Appointment', CAST(N'2019-08-31 15:00:00.000' AS DateTime))
INSERT [dbo].[task] ([id], [todotext], [tododate]) VALUES (8, N' Business meeting with manager', CAST(N'2019-10-07 15:41:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[task] OFF
