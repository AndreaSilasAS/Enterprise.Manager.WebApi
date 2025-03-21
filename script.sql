USE [master]
GO
/****** Object:  Database [EnterpriseManager]    Script Date: 11/03/2025 12:40:20 ******/
CREATE DATABASE [EnterpriseManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnterpriseManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EnterpriseManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EnterpriseManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EnterpriseManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EnterpriseManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnterpriseManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnterpriseManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnterpriseManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnterpriseManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnterpriseManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnterpriseManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnterpriseManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnterpriseManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnterpriseManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnterpriseManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnterpriseManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnterpriseManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnterpriseManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnterpriseManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnterpriseManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnterpriseManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EnterpriseManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnterpriseManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnterpriseManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnterpriseManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnterpriseManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnterpriseManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EnterpriseManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnterpriseManager] SET RECOVERY FULL 
GO
ALTER DATABASE [EnterpriseManager] SET  MULTI_USER 
GO
ALTER DATABASE [EnterpriseManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnterpriseManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnterpriseManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnterpriseManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EnterpriseManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EnterpriseManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EnterpriseManager', N'ON'
GO
ALTER DATABASE [EnterpriseManager] SET QUERY_STORE = OFF
GO
USE [EnterpriseManager]
GO
/****** Object:  Schema [Enterprise]    Script Date: 11/03/2025 12:40:20 ******/
CREATE SCHEMA [Enterprise]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/03/2025 12:40:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Exchange] [nvarchar](50) NOT NULL,
	[Ticker] [nvarchar](50) NOT NULL,
	[Isin] [nvarchar](12) NOT NULL,
	[Website] [nvarchar](100) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (1, N'Apple Inc.', N'NASDAQ', N'AAPL', N'US0378331005', N'http://www.apple.com')
INSERT [dbo].[Company] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (2, N'British Airways Plc', N'Pink Sheets', N'BAIRY', N'US1104193065', N'')
INSERT [dbo].[Company] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (3, N'Heineken NV', N'Euronext Amsterdam', N'HEIA', N'NL0000009165', N'')
INSERT [dbo].[Company] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (4, N'Panasonic Corp', N'Tokyo Stock Exchange', N'6752', N'JP3866800000', N'http://www.panasonic.co.jp')
INSERT [dbo].[Company] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (5, N'Porsche Automobil ', N'Deutsche Börse', N'PAH3', N'DE000PAH0038', N'https://www.porsche.com/')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
USE [master]
GO
ALTER DATABASE [EnterpriseManager] SET  READ_WRITE 
GO
