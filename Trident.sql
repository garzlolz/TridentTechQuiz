USE [master]
GO
/****** Object:  Database [TridentTech]    Script Date: 2024/2/23 下午 07:04:22 ******/
CREATE DATABASE [TridentTech]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TridentTech', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQL2019\MSSQL\DATA\TridentTech.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TridentTech_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQL2019\MSSQL\DATA\TridentTech_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TridentTech] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TridentTech].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TridentTech] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TridentTech] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TridentTech] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TridentTech] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TridentTech] SET ARITHABORT OFF 
GO
ALTER DATABASE [TridentTech] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TridentTech] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TridentTech] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TridentTech] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TridentTech] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TridentTech] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TridentTech] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TridentTech] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TridentTech] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TridentTech] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TridentTech] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TridentTech] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TridentTech] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TridentTech] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TridentTech] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TridentTech] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TridentTech] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TridentTech] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TridentTech] SET  MULTI_USER 
GO
ALTER DATABASE [TridentTech] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TridentTech] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TridentTech] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TridentTech] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TridentTech] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TridentTech] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TridentTech] SET QUERY_STORE = OFF
GO
USE [TridentTech]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/2/23 下午 07:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[class_selections]    Script Date: 2024/2/23 下午 07:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class_selections](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_class_selections] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 2024/2/23 下午 07:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [nvarchar](20) NOT NULL,
	[class_description] [nvarchar](200) NULL,
	[end_at] [nvarchar](4) NOT NULL,
	[start_at] [nvarchar](4) NOT NULL,
	[member_id] [int] NULL,
 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[members]    Script Date: 2024/2/23 下午 07:04:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[member_account] [nvarchar](100) NOT NULL,
	[member_password] [nvarchar](100) NOT NULL,
	[member_name] [nvarchar](10) NOT NULL,
	[member_email] [nvarchar](50) NOT NULL,
	[is_teacher] [bit] NOT NULL,
 CONSTRAINT [PK_members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240216093254_init', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240219143343_Remove_Teacher', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240219144650_Update_Member', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240220134537_Add_ClassSelections', N'8.0.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240220143101_Update_MemberStringLength', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[members] ON 
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (2, N'123qwe', N'123qwe', N'Teacher1', N'teatcher@email.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (3, N'123qwee', N'123qwe', N'Teacher2', N'teatcher@email.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (4, N'string', N'string', N'string', N'string', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (5, N'testaccount', N'testpassword', N'Test Name', N'test@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (6, N'rdiJ_Zd8AS', N'testpassword', N'Test Name', N'test@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (7, N'>imn?&?KgU', N'testpassword', N'Test Name', N'test@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (8, N'e^hG_U4kFK', N'testpassword', N'Test Name', N'test@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (9, N'$jc&eaN9FI', N'$QN4WF7Fv^', N'UKG8', N'HIM0W@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (10, N'c8qJ_sSjKU', N'cwP7#HNaYW', N'9$UY', N's&7Gi@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (11, N'V%We)kL)d+', N'U6gE<O^72U', N'c)WZ', N'XXylx@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (12, N')lR(Hg@kW%', N'+gl7HIxfZ!', N'v)Wz', N'HFA7@@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (13, N'!q>!jcmSZ$', N'_qbSV&s<oX', N'$Nxm', N'<%HUO@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (14, N'0?a@>?f%U0', N'dG58UZyS3?', N'Bo!N', N'+Q#_x@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (15, N'existingaccount', N'testpassword', N'Test Name', N'test@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (16, N'W0<<o4ElgX', N'OB8m9X^M2S', N'ea+o', N'CzUPt@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (17, N'%%n+z>9Mb9', N'vGjbK<g_As', N'2v)A', N'io+6f@example.com', 1)
GO
INSERT [dbo].[members] ([id], [member_account], [member_password], [member_name], [member_email], [is_teacher]) VALUES (18, N'wgj%d<cwSA', N'V&d7%wK9@K', N'dnGC', N'_FoFy@example.com', 1)
GO
SET IDENTITY_INSERT [dbo].[members] OFF
GO
/****** Object:  Index [IX_class_selections_class_id]    Script Date: 2024/2/23 下午 07:04:22 ******/
CREATE NONCLUSTERED INDEX [IX_class_selections_class_id] ON [dbo].[class_selections]
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_class_selections_MemberId]    Script Date: 2024/2/23 下午 07:04:22 ******/
CREATE NONCLUSTERED INDEX [IX_class_selections_MemberId] ON [dbo].[class_selections]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_classes_member_id]    Script Date: 2024/2/23 下午 07:04:22 ******/
CREATE NONCLUSTERED INDEX [IX_classes_member_id] ON [dbo].[classes]
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[classes] ADD  DEFAULT (N'') FOR [end_at]
GO
ALTER TABLE [dbo].[classes] ADD  DEFAULT (N'') FOR [start_at]
GO
ALTER TABLE [dbo].[class_selections]  WITH CHECK ADD  CONSTRAINT [FK_class_selections_classes_class_id] FOREIGN KEY([class_id])
REFERENCES [dbo].[classes] ([id])
GO
ALTER TABLE [dbo].[class_selections] CHECK CONSTRAINT [FK_class_selections_classes_class_id]
GO
ALTER TABLE [dbo].[class_selections]  WITH CHECK ADD  CONSTRAINT [FK_class_selections_members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[members] ([id])
GO
ALTER TABLE [dbo].[class_selections] CHECK CONSTRAINT [FK_class_selections_members_MemberId]
GO
ALTER TABLE [dbo].[classes]  WITH CHECK ADD  CONSTRAINT [FK_classes_members_member_id] FOREIGN KEY([member_id])
REFERENCES [dbo].[members] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[classes] CHECK CONSTRAINT [FK_classes_members_member_id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_selections', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'member_id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_selections', @level2type=N'COLUMN',@level2name=N'MemberId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所屬課程Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'class_selections', @level2type=N'COLUMN',@level2name=N'class_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'class_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'課程描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'class_description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下課時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'end_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上課時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'start_at'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員 Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'classes', @level2type=N'COLUMN',@level2name=N'member_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'member_account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'member_password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'member_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-mail' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'member_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否為老師' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'members', @level2type=N'COLUMN',@level2name=N'is_teacher'
GO
USE [master]
GO
ALTER DATABASE [TridentTech] SET  READ_WRITE 
GO
