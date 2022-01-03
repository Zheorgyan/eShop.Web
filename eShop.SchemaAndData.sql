USE [master]
GO
/****** Object:  Database [eShop]    Script Date: 2021-09-05 12:07:44 PM ******/
CREATE DATABASE [eShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\eShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\eShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [eShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [eShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eShop] SET RECOVERY FULL 
GO
ALTER DATABASE [eShop] SET  MULTI_USER 
GO
ALTER DATABASE [eShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eShop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'eShop', N'ON'
GO
ALTER DATABASE [eShop] SET QUERY_STORE = OFF
GO
USE [eShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [eShop]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2021-09-05 12:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[DatePlaced] [datetime] NULL,
	[DateProcessing] [datetime] NULL,
	[DateProcessed] [datetime] NULL,
	[CustomerName] [nvarchar](150) NULL,
	[CustomerAddress] [nvarchar](150) NULL,
	[CustomerCity] [nvarchar](50) NULL,
	[CustomerStateProvince] [nvarchar](50) NULL,
	[CustomerCountry] [nvarchar](50) NULL,
	[AdminUser] [nvarchar](150) NULL,
	[UniqueId] [nvarchar](100) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLineItem]    Script Date: 2021-09-05 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLineItem](
	[LineItemId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_OrderLineItem] PRIMARY KEY CLUSTERED 
(
	[LineItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2021-09-05 12:07:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[Brand] [nvarchar](150) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Price] [float] NOT NULL,
	[ImageLink] [nvarchar](500) NULL,
	[Description] [nvarchar](1500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Product] ([ProductId], [Brand], [Author], [Name], [Price], [ImageLink], [Description]) VALUES (286, N'Прогресс книга', N'Рихтер Джеффри', N'CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#. 4-е изд.', 1825, N'https://cdn1.ozone.ru/s3/multimedia-i/6170125470.jpg', N'Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0.')
INSERT [dbo].[Product] ([ProductId], [Brand], [Author], [Name], [Price], [ImageLink], [Description]) VALUES (291, N'Бомбора', N'Васильев Алексей Николаевич', N'Программирование на C# для начинающих. Особенности языка', 924, N'https://cdn1.ozone.ru/multimedia/1026291302.jpg', N'Вторая часть самоучителя по C#, написанного известным российским автором учебников по программированию Алексеем Васильевым. Она посвященная особенностям языка C# и его практическому применению. Из этой книги вы узнаете, какие основные структурные единицы языка существуют, научитесь писать программы, используя все основные методы и интерфейсы, и овладеете одним из самых востребованных и популярных языков семейства C.')
INSERT [dbo].[Product] ([ProductId], [Brand], [Author], [Name], [Price], [ImageLink], [Description]) VALUES (295, N'Вильямс', N'Джон Скит', N'C# для профессионалов. Тонкости программирования', 2484, N'https://cdn1.ozone.ru/multimedia/1026732931.jpg', N'Книга «C# для профессионалов: тонкости программирования» (C# in Depth) является обновлением предыдущего издания, ставшего бестселлером, с целью раскрытия новых средств языка C# 5, включая решение проблем, которые связаны с написанием сопровождаемого асинхронного кода. Она предлагает уникальные сведения о сложных областях и темных закоулках языка, которые может предоставить только эксперт Джон Скит.')
INSERT [dbo].[Product] ([ProductId], [Brand], [Author], [Name], [Price], [ImageLink], [Description]) VALUES (307, N'БХВ-Петербург', N'Фленов Михаил Е.', N'Библия C#. 5-е изд., перераб. и доп', 770, N'https://cdn1.ozone.ru/s3/multimedia-z/6129084299.jpg', N'Книга посвящена программированию на языке С# для платформы Microsoft .NET, начиная с основ языка и разработки программ для работы в режиме командной строки и заканчивая созданием современных веб-приложений. Материал сопровождается большим количеством практических примеров. Подробно описывается логика выполнения каждого участка программы. Уделено внимание вопросам повторного использования кода. В пятом издании примеры переписаны с учетом современной платформы .NET 5, а вместо прикладных приложений упор делается на веб-приложения. На сайте издательства находятся коды программ, дополнительная справочная информация и копия базы данных для выполнения примеров из книги.')
USE [master]
GO
ALTER DATABASE [eShop] SET  READ_WRITE 
GO
