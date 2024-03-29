USE [master]
GO
/****** Object:  Database [MyDriveDB]    Script Date: 10.10.2019 19:05:13 ******/
CREATE DATABASE [MyDriveDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyDriveDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MyDriveDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyDriveDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MyDriveDB_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyDriveDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyDriveDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyDriveDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyDriveDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyDriveDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyDriveDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyDriveDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyDriveDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyDriveDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyDriveDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyDriveDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyDriveDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyDriveDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyDriveDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyDriveDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyDriveDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyDriveDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyDriveDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyDriveDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyDriveDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyDriveDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyDriveDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyDriveDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyDriveDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyDriveDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyDriveDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyDriveDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyDriveDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyDriveDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyDriveDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MyDriveDB]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogsByCars]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogsByCars](
	[IdCar] [uniqueidentifier] NOT NULL,
	[IdBlog] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogsByUsers]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogsByUsers](
	[Nickname] [nvarchar](25) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [uniqueidentifier] NOT NULL,
	[Brand] [nvarchar](25) NOT NULL,
	[Model] [nvarchar](25) NOT NULL,
	[Manuf] [date] NOT NULL,
	[Power] [int] NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarsByUsers]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarsByUsers](
	[Nickname] [nvarchar](25) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[IdComment] [uniqueidentifier] NOT NULL,
	[IdBlog] [uniqueidentifier] NOT NULL,
	[Nickname] [nvarchar](25) NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [uniqueidentifier] NOT NULL,
	[SendNick] [nvarchar](25) NOT NULL,
	[RecNick] [nvarchar](25) NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscribe]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribe](
	[Nick] [nvarchar](25) NOT NULL,
	[SubscribeNick] [nvarchar](25) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Nickname] [nvarchar](25) NOT NULL,
	[Avatar] [varbinary](max) NULL,
	[Name] [nvarchar](25) NULL,
	[Surname] [nvarchar](25) NULL,
	[Birth] [date] NULL,
	[City] [nvarchar](25) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BlogsToCar]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BlogsToCar]
 @IdCar uniqueidentifier,
 @IdBlog uniqueidentifier
 AS
INSERT INTO BlogsByCars(IdCar,IdBlog)
VALUES (@IdCar, @IdBlog)
GO
/****** Object:  StoredProcedure [dbo].[BlogsToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BlogsToUser]
 @Nick nvarchar(25),
 @Id uniqueidentifier
 AS
INSERT INTO BlogsByUsers(Nickname,Id)
VALUES (@Nick, @Id) 
GO
/****** Object:  StoredProcedure [dbo].[CarsToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CarsToUser]
 @Nick nvarchar(25),
 @Id uniqueidentifier
 AS
INSERT INTO CarsByUsers(Nickname,Id)
VALUES (@Nick,@Id)
GO
/****** Object:  StoredProcedure [dbo].[ChangeRole]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeRole]
 @Nick nvarchar(25),
 @role int
 AS
UPDATE Users SET Role=@role WHERE Nickname=@Nick
GO
/****** Object:  StoredProcedure [dbo].[CheckSubscribeToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckSubscribeToUser]
@Nick nvarchar(25),
@Subsnick nvarchar(25)
AS
SELECT * FROM Subscribe WHERE Nick=@Nick AND SubscribeNick=@Subsnick
GO
/****** Object:  StoredProcedure [dbo].[CreateBlogCar]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBlogCar]
 @Id uniqueidentifier,
 @Title nvarchar(50),
 @Text nvarchar(1000)
 AS
INSERT INTO Blogs(Id,Title,Text)
VALUES (@Id, @Title, @Text)
GO
/****** Object:  StoredProcedure [dbo].[CreateBlogUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBlogUser]
 @Id uniqueidentifier,
 @Title nvarchar(50),
 @Text nvarchar(1000)
 AS
INSERT INTO Blogs(Id,Title,Text)
VALUES (@Id, @Title, @Text) 
GO
/****** Object:  StoredProcedure [dbo].[CreateCar]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCar]
 @Id uniqueidentifier,
 @Brand nvarchar(25),
 @Model nvarchar(25),
 @Manuf date,
 @Power int,
 @Image varbinary(MAX)
 AS
INSERT INTO Cars(Id,Brand,Model,Manuf,Power,Image)
VALUES (@Id,@Brand,@Model,@Manuf,@Power,@Image)
GO
/****** Object:  StoredProcedure [dbo].[CreateComment]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateComment]
 @IdComment uniqueidentifier,
 @IdBlog uniqueidentifier,
 @Nick nvarchar(25),
 @Text nvarchar(1000)
 AS
INSERT INTO Comments(IdComment,IdBlog,Nickname,Text)
VALUES (@IdComment, @IdBlog,@Nick,@Text) 
GO
/****** Object:  StoredProcedure [dbo].[CreateMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateMessage]
 @IdMessage uniqueidentifier,
 @SendNick nvarchar(25),
 @RecNick nvarchar(25),
 @Text nvarchar(1000)
 AS
INSERT INTO Message(Id,SendNick,RecNick,Text)
VALUES (@IdMessage,@SendNick,@RecNick,@Text) 
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
 @Login nvarchar(25),
 @Password nvarchar(50),
 @Avatar varbinary(max)
AS
if NOT EXISTS (SELECT * FROM Users WHERE Nickname=@Login)
INSERT INTO Users(Nickname,Avatar,Password,Role)
VALUES (@Login,@Avatar,@Password,1)
GO
/****** Object:  StoredProcedure [dbo].[DeleteBlogCar]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBlogCar]
@IdBlog uniqueidentifier,
@IdCar uniqueidentifier
AS
DELETE BlogsByCars WHERE IdCar=@IdCar
DELETE Blogs WHERE Id=@IdBlog
DELETE Comments WHERE IdBlog=@IdBlog
GO
/****** Object:  StoredProcedure [dbo].[DeleteBlogUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBlogUser]
@IdBlog uniqueidentifier,
@Nick nvarchar(25)
AS
DELETE BlogsByUsers WHERE Nickname=@Nick
DELETE Blogs WHERE Id=@IdBlog
DELETE Comments WHERE IdBlog=@IdBlog
GO
/****** Object:  StoredProcedure [dbo].[DeleteCar]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCar]
@Id uniqueidentifier
AS
DELETE Cars WHERE Id=@Id
DELETE CarsByUsers WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMessage]
@Id uniqueidentifier
AS
DELETE Message WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
@Nick nvarchar(25)
AS
DELETE Users WHERE Nickname=@Nick
DELETE Subscribe WHERE Nick=@Nick
DELETE Subscribe WHERE SubscribeNick=@Nick
DELETE BlogsByUsers WHERE Nickname=@Nick
DELETE CarsByUsers WHERE Nickname=@Nick
DELETE Comments WHERE Nickname=@Nick
DELETE Message WHERE SendNick=@Nick
DELETE Message WHERE RecNick=@Nick
GO
/****** Object:  StoredProcedure [dbo].[EditBlog]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditBlog]
 @Id uniqueidentifier,
 @Title nvarchar(50),
 @Text nvarchar(1000)
AS
UPDATE Blogs SET Title=@Title, Text=@Text WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[EditMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditMessage]
 @Id uniqueidentifier,
 @Text nvarchar(1000)
AS
UPDATE Message SET Text=@Text WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUser]
 @Oldnickname nvarchar(25),
 @Nickname nvarchar(25),
 @Avatar varbinary(max),
 @Name nvarchar(25),
 @Surname nvarchar(25),
 @Birth date,
 @City nvarchar(25)
AS
UPDATE Users SET Nickname=@Nickname, Avatar=@Avatar, Name=@Name, Surname=@Surname, Birth=@Birth, City=@City  WHERE Nickname=@Oldnickname
UPDATE Subscribe SET Nick=@Nickname WHERE Nick=@Oldnickname
UPDATE Subscribe SET SubscribeNick=@Nickname WHERE SubscribeNick=@Oldnickname
UPDATE BlogsByUsers SET Nickname=@Nickname WHERE Nickname=@Oldnickname
UPDATE CarsByUsers SET Nickname=@Nickname WHERE Nickname=@Oldnickname
UPDATE Comments SET Nickname=@Nickname WHERE Nickname=@Oldnickname
UPDATE Message SET SendNick=@Nickname WHERE SendNick=@Oldnickname
UPDATE Message SET RecNick=@Nickname WHERE RecNick=@Oldnickname
GO
/****** Object:  StoredProcedure [dbo].[GetAllCars]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCars]
AS
SELECT * FROM Cars
GO
/****** Object:  StoredProcedure [dbo].[GetAllMeMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMeMessage]
@RecNick nvarchar(25)
AS
SELECT * FROM Message WHERE RecNick=@RecNick
GO
/****** Object:  StoredProcedure [dbo].[GetAllMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMessage]
AS
SELECT * FROM Message
GO
/****** Object:  StoredProcedure [dbo].[GetAllMyMessage]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMyMessage]
@SendNick nvarchar(25)
AS
SELECT * FROM Message WHERE SendNick=@SendNick
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetAllUsers]
 AS
SELECT * FROM Users WHERE Nickname!='admin'
GO
/****** Object:  StoredProcedure [dbo].[GetBlogById]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBlogById]
 @Id uniqueidentifier
 AS
SELECT * FROM Blogs WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetCarBlogs]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCarBlogs]
 @IdCar uniqueidentifier
 AS
 SELECT * FROM BlogsByCars WHERE IdCar=@IdCar
GO
/****** Object:  StoredProcedure [dbo].[GetCarById]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCarById]
 @Id uniqueidentifier
 AS
SELECT * FROM Cars WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetCommentsBlog]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCommentsBlog]
@IdBlog uniqueidentifier
AS
SELECT * FROM Comments WHERE IdBlog=@IdBlog
GO
/****** Object:  StoredProcedure [dbo].[GetCountSubscribeToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCountSubscribeToUser]
@Subsnick nvarchar(25)
AS
SELECT Nick FROM Subscribe WHERE SubscribeNick=@Subsnick
GO
/****** Object:  StoredProcedure [dbo].[GetCountUsersToSubscribe]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCountUsersToSubscribe]
@Nick nvarchar(25)
AS
SELECT SubscribeNick FROM Subscribe WHERE Nick=@Nick
GO
/****** Object:  StoredProcedure [dbo].[GetLogin]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLogin]
 @Login nvarchar(25)
 AS
SELECT * FROM Users WHERE Nickname=@Login
GO
/****** Object:  StoredProcedure [dbo].[GetMessageById]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessageById]
 @Id uniqueidentifier
 AS
SELECT * FROM Message WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[GetUserBlogs]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserBlogs]
 @Nickname nvarchar(25)
 AS
SELECT * FROM BlogsByUsers WHERE Nickname=@Nickname
GO
/****** Object:  StoredProcedure [dbo].[GetUserByNick]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByNick]
 @Nick nvarchar(25)
 AS
SELECT * FROM Users WHERE Nickname=@Nick
GO
/****** Object:  StoredProcedure [dbo].[GetUserCars]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserCars]
 @Nickname nvarchar(25)
 AS
SELECT * FROM CarsByUsers WHERE Nickname=@Nickname
GO
/****** Object:  StoredProcedure [dbo].[GetUserRoleByNick]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRoleByNick]
 @Nick nvarchar(25)
 AS
SELECT * FROM Users WHERE Nickname=@Nick
GO
/****** Object:  StoredProcedure [dbo].[SearchBlog]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchBlog]
@Search nvarchar(25)
AS
SELECT * FROM Blogs WHERE Title LIKE '%'+@Search+'%' or Text LIKE '%'+@Search+'%'
GO
/****** Object:  StoredProcedure [dbo].[SearchUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchUser]
@Search nvarchar(25)
AS
SELECT * FROM Users WHERE Nickname LIKE '%'+@Search+'%' and Nickname!='admin'
GO
/****** Object:  StoredProcedure [dbo].[SetAdmin]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetAdmin]
AS
if NOT EXISTS (SELECT * FROM Users WHERE Nickname='admin')
BEGIN
INSERT INTO Users(Nickname, Password, Role) VALUES ('admin', '21232f297a57a5a743894a0e4a801fc3', 0)
END
GO
/****** Object:  StoredProcedure [dbo].[SubscribeToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubscribeToUser]
 @Nick nvarchar(25),
 @Subsnick nvarchar(25)
 AS
INSERT INTO Subscribe(Nick,SubscribeNick)
VALUES (@Nick, @Subsnick) 
GO
/****** Object:  StoredProcedure [dbo].[UnSubscribeToUser]    Script Date: 10.10.2019 19:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UnSubscribeToUser]
 @Nick nvarchar(25),
 @Subsnick nvarchar(25)
AS
DELETE Subscribe WHERE Nick=@Nick AND SubscribeNick=@Subsnick
GO
USE [master]
GO
ALTER DATABASE [MyDriveDB] SET  READ_WRITE 
GO
