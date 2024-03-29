USE [master]
GO
/****** Object:  Database [UsersAndAwards]    Script Date: 22.09.2019 10:52:29 ******/
CREATE DATABASE [UsersAndAwards]
 CONTAINMENT = NONE
ALTER DATABASE [UsersAndAwards] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndAwards] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UsersAndAwards]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Birth] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAwards]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAwards](
	[IdUser] [uniqueidentifier] NOT NULL,
	[IdAward] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward]
 @ID uniqueidentifier,
 @Title nvarchar(50),
 @Image varbinary(max)
 AS
INSERT INTO Awards(Id,Title,Image)
VALUES (@ID, @Title, @Image) 
GO
/****** Object:  StoredProcedure [dbo].[AddAwardUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAwardUser]
 @idUser uniqueidentifier,
 @idAward uniqueidentifier
 AS
INSERT INTO UsersAwards(IdUser,IdAward)
VALUES (@idUser, @idAward)
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
 @id uniqueidentifier,
 @name nvarchar(50),
 @birth date
 AS
INSERT INTO Users(Id,Name,Birth)
VALUES (@id, @name, @birth)
GO
/****** Object:  StoredProcedure [dbo].[ChangeRole]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeRole]
 @login nvarchar(50),
 @role int
 AS
UPDATE Accounts SET Role=@role WHERE Login=@login
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin]
 @login nvarchar(50)
 AS
SELECT * FROM Accounts WHERE Login=@login
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
 @login nvarchar(50),
 @password nvarchar(MAX),
 @role int
 AS
if NOT EXISTS (SELECT * FROM Accounts WHERE Login=@login)
BEGIN
INSERT INTO Accounts(Login,Password,Role)
VALUES (@login, @password, @role) 
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUser]
 @id uniqueidentifier,
 @name nvarchar(50),
 @birth date
 AS
UPDATE Users SET Name=@name, Birth=@birth WHERE Id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetAllAccounts]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAccounts]
 AS
SELECT * FROM Accounts
GO
/****** Object:  StoredProcedure [dbo].[GetAward]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAward]
 @id uniqueidentifier
 AS
SELECT * FROM Awards WHERE Id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetAwardUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardUser]
 @id uniqueidentifier
 AS
SELECT * FROM UsersAwards WHERE IdAward=@id
GO
/****** Object:  StoredProcedure [dbo].[GetLogin]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLogin]
 @login nvarchar(50)
 AS
SELECT * FROM Accounts WHERE Login=@login
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUser]
 @id uniqueidentifier
 AS
SELECT * FROM Users WHERE Id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetUserAward]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserAward]
 @id uniqueidentifier
 AS
SELECT * FROM UsersAwards WHERE IdUser=@Id
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAward]
    @id uniqueidentifier
AS
DELETE Awards WHERE Id=@id
if EXISTS (SELECT * FROM UsersAwards WHERE IdAward=@id)
BEGIN
DELETE UsersAwards WHERE IdAward=@id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUser]
    @id uniqueidentifier
AS
DELETE Users WHERE Id=@id
if EXISTS (SELECT * FROM UsersAwards WHERE IdUser=@id)
BEGIN
DELETE UsersAwards WHERE IdUser=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllAwards]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllAwards]
AS
SELECT * FROM Awards
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllUsers]
AS
SELECT * FROM Users
GO
/****** Object:  StoredProcedure [dbo].[SetAdmin]    Script Date: 22.09.2019 10:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetAdmin]
AS
if NOT EXISTS (SELECT * FROM Accounts WHERE Login='admin')
BEGIN
INSERT INTO Accounts (Login, Password, Role) VALUES ('admin', '21232f297a57a5a743894a0e4a801fc3', 0)
END
GO
USE [master]
GO
ALTER DATABASE [UsersAndAwards] SET  READ_WRITE 
GO
