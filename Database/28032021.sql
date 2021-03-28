USE [TeachersCommunity]
GO
/****** Object:  Table [dbo].[AdminTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminTbl](
	[AdminID] [bigint] IDENTITY(1,1) NOT NULL,
	[CredID] [bigint] NOT NULL,
	[AdminName] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_AdminTbl] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnswersTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswersTbl](
	[AnswerID] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionID] [bigint] NOT NULL,
	[TeacherID] [bigint] NOT NULL,
	[Answer] [varchar](500) NOT NULL,
	[AnsweredOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[EnteredOn] [datetime] NULL,
 CONSTRAINT [PK_AnswersTbl] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentsTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentsTbl](
	[AppointmentsID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[SubjectID] [bigint] NULL,
	[TeachersID] [bigint] NULL,
	[AppointmentDate] [date] NOT NULL,
	[AppointmentTime] [datetime] NOT NULL,
	[Description] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [nchar](10) NULL,
	[Approved] [bit] NULL,
 CONSTRAINT [PK_AppointmentsTbl] PRIMARY KEY CLUSTERED 
(
	[AppointmentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CredentialTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CredentialTbl](
	[CredID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsEmailverify] [bit] NOT NULL,
	[IsPhoneVerify] [bit] NOT NULL,
	[PasswordResetCode] [varchar](50) NULL,
	[EmailVerificationCode] [varchar](50) NULL,
	[PhoneVerificationCode] [varchar](50) NULL,
	[EnteredOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_CredentialTbl] PRIMARY KEY CLUSTERED 
(
	[CredID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionTbl](
	[QuestID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NOT NULL,
	[Question] [varchar](500) NOT NULL,
	[AskedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_QuestionTbl] PRIMARY KEY CLUSTERED 
(
	[QuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTbl](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoleTbl] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTbl](
	[StudentID] [bigint] IDENTITY(1,1) NOT NULL,
	[CredID] [bigint] NOT NULL,
	[CountryID] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[HighestQualification] [varchar](50) NULL,
	[CurrentStatus] [varchar](50) NULL,
	[ProfilePic] [varchar](500) NULL,
	[Location] [varchar](50) NULL,
	[EnteredOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_StudentTbl] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudyMaterialTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudyMaterialTbl](
	[MaterialID] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectID] [bigint] NOT NULL,
	[TeacherID] [bigint] NULL,
	[MaterialName] [varchar](50) NOT NULL,
	[MaterialDetails] [varchar](max) NULL,
	[MaterilaLink] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_StudyMaterialTbl] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectTbl](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SubjectTbl] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeachersStudentTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachersStudentTbl](
	[TeachersStudentId] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NULL,
	[TeacherId] [bigint] NULL,
	[IsApprove] [bit] NULL,
 CONSTRAINT [PK_TeachersStudentTbl] PRIMARY KEY CLUSTERED 
(
	[TeachersStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherTbl]    Script Date: 28-03-2021 13:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherTbl](
	[TeacherID] [bigint] IDENTITY(1,1) NOT NULL,
	[CredID] [bigint] NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[EnterdOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[Gender] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[IsOffline] [bit] NULL,
	[OfflineTime] [varchar](50) NULL,
	[IsOnline] [bit] NULL,
	[OnlineTime] [varchar](50) NULL,
	[Days] [varchar](500) NULL,
	[DemoClassURL] [varchar](500) NULL,
 CONSTRAINT [PK_tblTeacher] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CredentialTbl] ON 
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (2, 2, N'a', N'a', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:08:42.270' AS DateTime), CAST(N'2021-03-03T12:08:42.270' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (4, 3, N'abdu@gmail.com', N'asdhj', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:28:22.710' AS DateTime), CAST(N'2021-03-03T12:28:22.710' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (5, 3, N'abdu@gmail.com', N'asdhj', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:28:55.760' AS DateTime), CAST(N'2021-03-03T12:28:55.760' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (6, 2, N'abdu@gmail.com', N'asd', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:31:05.527' AS DateTime), CAST(N'2021-03-03T12:31:05.527' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (7, 2, N'f@f.f', N'f', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:37:44.443' AS DateTime), CAST(N'2021-03-03T12:37:44.443' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (8, 2, N'abdu@g.f', N'345', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T12:39:47.920' AS DateTime), CAST(N'2021-03-03T12:39:47.920' AS DateTime))
GO
INSERT [dbo].[CredentialTbl] ([CredID], [RoleID], [Email], [Password], [IsEmailverify], [IsPhoneVerify], [PasswordResetCode], [EmailVerificationCode], [PhoneVerificationCode], [EnteredOn], [UpdatedOn]) VALUES (9, 3, N'abdu@gmail.com', N'password', 0, 0, NULL, NULL, NULL, CAST(N'2021-03-03T13:10:35.140' AS DateTime), CAST(N'2021-03-03T13:10:35.140' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CredentialTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleTbl] ON 
GO
INSERT [dbo].[RoleTbl] ([RoleID], [RoleName]) VALUES (2, N'Student')
GO
INSERT [dbo].[RoleTbl] ([RoleID], [RoleName]) VALUES (3, N'Teachers')
GO
SET IDENTITY_INSERT [dbo].[RoleTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentTbl] ON 
GO
INSERT [dbo].[StudentTbl] ([StudentID], [CredID], [CountryID], [Name], [Gender], [DOB], [Phone], [HighestQualification], [CurrentStatus], [ProfilePic], [Location], [EnteredOn], [UpdatedOn]) VALUES (2, 8, 0, N'Abdu', N'Male', CAST(N'0001-01-01' AS Date), N'435', NULL, NULL, NULL, N'Nilamel', CAST(N'2021-03-03T12:39:49.627' AS DateTime), CAST(N'2021-03-03T12:39:49.627' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[StudentTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherTbl] ON 
GO
INSERT [dbo].[TeacherTbl] ([TeacherID], [CredID], [FullName], [Location], [EnterdOn], [UpdatedOn], [Gender], [Phone], [DOB], [IsOffline], [OfflineTime], [IsOnline], [OnlineTime], [Days], [DemoClassURL]) VALUES (1, 9, N'Test Teacher', N'Nilamel', CAST(N'2021-03-03T13:10:35.523' AS DateTime), CAST(N'2021-03-03T13:10:35.523' AS DateTime), N'Male', N'9539391527', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TeacherTbl] ([TeacherID], [CredID], [FullName], [Location], [EnterdOn], [UpdatedOn], [Gender], [Phone], [DOB], [IsOffline], [OfflineTime], [IsOnline], [OnlineTime], [Days], [DemoClassURL]) VALUES (2, 9, N'Test Teacher 1 ', N'Kadakkal', CAST(N'2021-03-03T13:10:35.523' AS DateTime), CAST(N'2021-03-03T13:10:35.523' AS DateTime), N'Male', N'9539391527', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TeacherTbl] OFF
GO
ALTER TABLE [dbo].[AdminTbl] ADD  CONSTRAINT [DF_AdminTbl_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[AnswersTbl] ADD  CONSTRAINT [DF_Table_1_AskedOn]  DEFAULT (getdate()) FOR [AnsweredOn]
GO
ALTER TABLE [dbo].[CredentialTbl] ADD  CONSTRAINT [DF_CredentialTbl_IsEmailverify]  DEFAULT ((0)) FOR [IsEmailverify]
GO
ALTER TABLE [dbo].[CredentialTbl] ADD  CONSTRAINT [DF_CredentialTbl_IsPhoneVerify]  DEFAULT ((0)) FOR [IsPhoneVerify]
GO
ALTER TABLE [dbo].[CredentialTbl] ADD  CONSTRAINT [DF_CredentialTbl_EnteredOn]  DEFAULT (getdate()) FOR [EnteredOn]
GO
ALTER TABLE [dbo].[QuestionTbl] ADD  CONSTRAINT [DF_QuestionTbl_AskedOn]  DEFAULT (getdate()) FOR [AskedOn]
GO
ALTER TABLE [dbo].[StudentTbl] ADD  CONSTRAINT [DF_tblStudent_Gender]  DEFAULT ('M') FOR [Gender]
GO
ALTER TABLE [dbo].[StudentTbl] ADD  CONSTRAINT [DF_tblStudent_EnteredOn]  DEFAULT (getdate()) FOR [EnteredOn]
GO
ALTER TABLE [dbo].[StudyMaterialTbl] ADD  CONSTRAINT [DF_StudyMaterialTbl_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TeacherTbl] ADD  CONSTRAINT [DF_tblTeacher_EnterdOn]  DEFAULT (getdate()) FOR [EnterdOn]
GO
ALTER TABLE [dbo].[AdminTbl]  WITH CHECK ADD  CONSTRAINT [FK_AdminTbl_CredentialTbl] FOREIGN KEY([CredID])
REFERENCES [dbo].[CredentialTbl] ([CredID])
GO
ALTER TABLE [dbo].[AdminTbl] CHECK CONSTRAINT [FK_AdminTbl_CredentialTbl]
GO
ALTER TABLE [dbo].[AnswersTbl]  WITH CHECK ADD  CONSTRAINT [FK_AnswersTbl_QuestionTbl] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[QuestionTbl] ([QuestID])
GO
ALTER TABLE [dbo].[AnswersTbl] CHECK CONSTRAINT [FK_AnswersTbl_QuestionTbl]
GO
ALTER TABLE [dbo].[AnswersTbl]  WITH CHECK ADD  CONSTRAINT [FK_AnswersTbl_TeacherTbl] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[TeacherTbl] ([TeacherID])
GO
ALTER TABLE [dbo].[AnswersTbl] CHECK CONSTRAINT [FK_AnswersTbl_TeacherTbl]
GO
ALTER TABLE [dbo].[CredentialTbl]  WITH CHECK ADD  CONSTRAINT [FK_CredentialTbl_RoleTbl] FOREIGN KEY([RoleID])
REFERENCES [dbo].[RoleTbl] ([RoleID])
GO
ALTER TABLE [dbo].[CredentialTbl] CHECK CONSTRAINT [FK_CredentialTbl_RoleTbl]
GO
ALTER TABLE [dbo].[QuestionTbl]  WITH CHECK ADD  CONSTRAINT [FK_QuestionTbl_QuestionTbl] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentTbl] ([StudentID])
GO
ALTER TABLE [dbo].[QuestionTbl] CHECK CONSTRAINT [FK_QuestionTbl_QuestionTbl]
GO
ALTER TABLE [dbo].[StudentTbl]  WITH CHECK ADD  CONSTRAINT [FK_StudentTbl_CredentialTbl] FOREIGN KEY([CredID])
REFERENCES [dbo].[CredentialTbl] ([CredID])
GO
ALTER TABLE [dbo].[StudentTbl] CHECK CONSTRAINT [FK_StudentTbl_CredentialTbl]
GO
ALTER TABLE [dbo].[TeacherTbl]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTbl_CredentialTbl] FOREIGN KEY([CredID])
REFERENCES [dbo].[CredentialTbl] ([CredID])
GO
ALTER TABLE [dbo].[TeacherTbl] CHECK CONSTRAINT [FK_TeacherTbl_CredentialTbl]
GO
