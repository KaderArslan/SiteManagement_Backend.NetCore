USE [master]
GO
/****** Object:  Database [SiteManagement]    Script Date: 13.06.2022 09:25:47 ******/
CREATE DATABASE [SiteManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SiteManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SiteManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SiteManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SiteManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SiteManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SiteManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SiteManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SiteManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SiteManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SiteManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SiteManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SiteManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SiteManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SiteManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SiteManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SiteManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SiteManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SiteManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SiteManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SiteManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SiteManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SiteManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SiteManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SiteManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SiteManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SiteManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SiteManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SiteManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SiteManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [SiteManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SiteManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SiteManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SiteManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SiteManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SiteManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SiteManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SiteManagement', N'ON'
GO
ALTER DATABASE [SiteManagement] SET QUERY_STORE = OFF
GO
USE [SiteManagement]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 13.06.2022 09:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](50) NOT NULL,
	[AdminSurname] [varchar](50) NOT NULL,
	[AdminTCNum] [char](11) NOT NULL,
	[AdminEmail] [varchar](50) NOT NULL,
	[AdminPassword] [varchar](50) NOT NULL,
	[AdminPhoneNum] [char](11) NOT NULL,
	[AdminCarStatus] [varchar](9) NULL,
	[ApartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 13.06.2022 09:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[ApartmentID] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentBlock] [char](1) NOT NULL,
	[ApartmentIsEmpty] [bit] NOT NULL,
	[ApartmentType] [varchar](5) NOT NULL,
	[ApartmentFloor] [int] NOT NULL,
	[ApartmentNumber] [int] NOT NULL,
	[ApartmentIsOwner] [bit] NOT NULL,
	[ApartmentStartDate] [datetime] NOT NULL,
	[ApartmentEndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[ApartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 13.06.2022 09:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[BillType] [varchar](30) NOT NULL,
	[BillSum] [decimal](6, 2) NOT NULL,
	[BillIsPaid] [bit] NOT NULL,
	[BillDate] [datetime] NOT NULL,
	[ApartmentID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 13.06.2022 09:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTitle] [varchar](50) NOT NULL,
	[MessageText] [varchar](300) NOT NULL,
	[MessageSender] [int] NOT NULL,
	[MessageReceiver] [int] NOT NULL,
	[MessageIsRead] [bit] NOT NULL,
	[MessageDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13.06.2022 09:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserSurname] [varchar](50) NOT NULL,
	[UserTCNum] [char](11) NOT NULL,
	[UserEMail] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[UserPhoneNum] [char](11) NOT NULL,
	[UserCarStatus] [varchar](9) NULL,
	[UserIsActive] [bit] NOT NULL,
	[ApartmentID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_AdminCarStatus]  DEFAULT ((0)) FOR [AdminCarStatus]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserCarStatus]  DEFAULT ((0)) FOR [UserCarStatus]
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Apartment] FOREIGN KEY([ApartmentID])
REFERENCES [dbo].[Apartment] ([ApartmentID])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_Apartment]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Apartment] FOREIGN KEY([ApartmentID])
REFERENCES [dbo].[Apartment] ([ApartmentID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Apartment]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Admin] FOREIGN KEY([MessageSender])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Admin]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([MessageReceiver])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Apartment] FOREIGN KEY([ApartmentID])
REFERENCES [dbo].[Apartment] ([ApartmentID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Apartment]
GO
USE [master]
GO
ALTER DATABASE [SiteManagement] SET  READ_WRITE 
GO
