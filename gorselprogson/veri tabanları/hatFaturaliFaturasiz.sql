USE [master]
GO
/****** Object:  Database [hatFaturaliFaturasizzDb]    Script Date: 14.05.2023 19:28:20 ******/
CREATE DATABASE [hatFaturaliFaturasizzDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hatFaturaliFaturasizzDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\hatFaturaliFaturasizzDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hatFaturaliFaturasizzDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\hatFaturaliFaturasizzDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hatFaturaliFaturasizzDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET RECOVERY FULL 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET  MULTI_USER 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'hatFaturaliFaturasizzDb', N'ON'
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [hatFaturaliFaturasizzDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14.05.2023 19:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hatFaturaliFaturasizzs]    Script Date: 14.05.2023 19:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hatFaturaliFaturasizzs](
	[MusteriId] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAd] [nvarchar](max) NULL,
	[MusteriSoyad] [nvarchar](max) NULL,
	[MusteriFaturaliFaturasiz] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.hatFaturaliFaturasizzs] PRIMARY KEY CLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [hatFaturaliFaturasizzDb] SET  READ_WRITE 
GO
