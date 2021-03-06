
CREATE DATABASE [WordDB]
CREATE TABLE [dbo].[OurWords](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
 CONSTRAINT [PK_OurWords] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO
SET IDENTITY_INSERT [dbo].[OurWords] ON 

INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (11, N'cat', N'Animals', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (12, N'cow', N'Animals', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (13, N'Fox', N'Animals', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (14, N'OX', N'Animals', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (15, N'lion', N'Animals', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (16, N'tiger', N'Animals', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (17, N'zebra', N'Animals', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (18, N'giraffe', N'Animals', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (19, N'batterfly', N'Animals', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (20, N'hyena', N'Animals', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (21, N'kangaro', N'Animals', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (22, N'chettah', N'Animals', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (23, N'Egypt', N'Countries', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (24, N'Sudan', N'Countries', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (25, N'Turkey', N'Countries', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (26, N'canada', N'Countries', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (27, N'morroco', N'Countries', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (28, N'alegria', N'Countries', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (29, N'tunisia', N'Countries', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (30, N'libya', N'Countries', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (31, N'swizerland', N'Countries', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (32, N'portugal

', N'Countries', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (33, N'England', N'Countries', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (34, N'maldevies', N'Countries', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (35, N'doctor', N'Jobs', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (36, N'engineer', N'Jobs', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (37, N'teacher', N'Jobs', N'Easy')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (38, N'dentist', N'Jobs', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (39, N'actor', N'Jobs', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (40, N'', NULL, NULL)
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (41, N'footballer', N'Jobs', N'Medium')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (42, N'carpenter', N'Jobs', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (43, N'pharmacist', N'Jobs', N'Hard')
INSERT [dbo].[OurWords] ([ID], [Word], [Category], [Level]) VALUES (44, N'Accountant', N'Jobs', N'Hard')
SET IDENTITY_INSERT [dbo].[OurWords] OFF

