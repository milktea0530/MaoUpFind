USE [master]
GO
/****** Object:  Database [MaoUpFind]    Script Date: 2021/6/29 上午 04:16:34 ******/
CREATE DATABASE [MaoUpFind]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MaoUpFind', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaoUpFind.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MaoUpFind_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaoUpFind_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MaoUpFind] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MaoUpFind].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MaoUpFind] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MaoUpFind] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MaoUpFind] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MaoUpFind] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MaoUpFind] SET ARITHABORT OFF 
GO
ALTER DATABASE [MaoUpFind] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MaoUpFind] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MaoUpFind] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MaoUpFind] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MaoUpFind] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MaoUpFind] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MaoUpFind] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MaoUpFind] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MaoUpFind] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MaoUpFind] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MaoUpFind] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MaoUpFind] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MaoUpFind] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MaoUpFind] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MaoUpFind] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MaoUpFind] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MaoUpFind] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MaoUpFind] SET RECOVERY FULL 
GO
ALTER DATABASE [MaoUpFind] SET  MULTI_USER 
GO
ALTER DATABASE [MaoUpFind] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MaoUpFind] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MaoUpFind] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MaoUpFind] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MaoUpFind] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MaoUpFind] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MaoUpFind', N'ON'
GO
ALTER DATABASE [MaoUpFind] SET QUERY_STORE = OFF
GO
USE [MaoUpFind]
GO
/****** Object:  Table [dbo].[一般會員資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[一般會員資料](
	[編號] [int] IDENTITY(1,1) NOT NULL,
	[會員編號] [int] NULL,
	[會員名字] [nvarchar](30) NULL,
	[會員暱稱] [nvarchar](30) NULL,
	[會員電話] [varchar](20) NULL,
	[會員信箱] [nvarchar](50) NULL,
	[公開聯絡] [varchar](1) NULL,
	[聯絡地區_市] [int] NULL,
	[聯絡地區_區] [int] NULL,
	[聯絡時段] [nvarchar](100) NULL,
 CONSTRAINT [PK_一般會員資料] PRIMARY KEY CLUSTERED 
(
	[編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[刊登協尋]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[刊登協尋](
	[協尋編號] [int] IDENTITY(1,1) NOT NULL,
	[協尋單號] [int] NULL,
	[寵物編號] [int] NULL,
	[協尋狀態] [varchar](1) NULL,
	[會員編號] [int] NULL,
	[會員暱稱] [nvarchar](30) NULL,
	[會員電話] [varchar](20) NULL,
	[走失地點_市] [int] NULL,
	[走失地點_區] [int] NULL,
	[走失地點_全] [nvarchar](100) NULL,
	[備註] [nvarchar](150) NULL,
	[是否結案] [varchar](1) NULL,
	[建立時間] [datetime] NULL,
	[更新時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[協尋編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[刊登認養]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[刊登認養](
	[認養編號] [int] IDENTITY(1,1) NOT NULL,
	[認養單號] [int] NULL,
	[寵物編號] [int] NULL,
	[認養狀態] [varchar](1) NULL,
	[會員編號] [int] NULL,
	[會員暱稱] [nvarchar](30) NULL,
	[會員電話] [varchar](20) NULL,
	[寵物所在地點_市] [int] NULL,
	[寵物所在地點_區] [int] NULL,
	[寵物所在地點_全] [nvarchar](100) NULL,
	[刊登原因] [nvarchar](500) NULL,
	[備註] [nvarchar](150) NULL,
	[結束時間] [datetime] NULL,
	[是否結案] [varchar](1) NULL,
	[建立時間] [datetime] NULL,
	[更新時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[認養編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[地區]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[地區](
	[地區編號] [int] IDENTITY(1,1) NOT NULL,
	[城市編號] [int] NULL,
	[地區名稱] [nvarchar](30) NULL,
	[備註] [nvarchar](50) NULL,
	[是否啟用] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[地區編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[城市]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[城市](
	[城市編號] [int] IDENTITY(1,1) NOT NULL,
	[城市名稱] [nvarchar](30) NULL,
	[備註] [nvarchar](50) NULL,
	[是否啟用] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[城市編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[急迫性]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[急迫性](
	[急迫性編號] [int] IDENTITY(1,1) NOT NULL,
	[急迫性名稱] [nvarchar](30) NULL,
	[備註] [nvarchar](50) NULL,
	[是否啟用] [varchar](1) NULL,
	[排序] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[急迫性編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[按讚資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[按讚資料](
	[按讚編號] [int] IDENTITY(1,1) NOT NULL,
	[留言編號] [int] NULL,
	[按讚會員編號] [int] NULL,
	[按讚時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[按讚編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[留言板]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[留言板](
	[留言編號] [int] IDENTITY(1,1) NOT NULL,
	[來源編號] [int] NULL,
	[會員編號] [int] NULL,
	[留言內容] [nvarchar](500) NULL,
	[留言日期] [datetime] NULL,
	[按讚數] [int] NULL,
	[是否公開] [varchar](1) NULL,
	[是否被檢舉] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[留言編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[動物別]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[動物別](
	[動物別編號] [int] IDENTITY(1,1) NOT NULL,
	[動物別名稱] [nvarchar](50) NULL,
	[備註] [nvarchar](100) NULL,
	[是否啟用] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[動物別編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[動物品種]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[動物品種](
	[品種編號] [int] IDENTITY(1,1) NOT NULL,
	[動物別編號] [int] NOT NULL,
	[品種名稱] [nvarchar](50) NULL,
	[備註] [nvarchar](100) NULL,
	[是否啟用] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[品種編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[帳號資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[帳號資料](
	[會員編號] [int] IDENTITY(1,1) NOT NULL,
	[會員種類] [int] NULL,
	[會員帳號] [varchar](30) NULL,
	[會員密碼] [varchar](30) NULL,
	[帳號開通] [varchar](1) NULL,
	[收到通知] [varchar](1) NULL,
	[違規次數] [int] NULL,
	[建立時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[會員編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[通報資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[通報資料](
	[通報編號] [int] IDENTITY(1,1) NOT NULL,
	[通報單號] [varchar](30) NOT NULL,
	[會員編號] [int] NULL,
	[會員暱稱] [nvarchar](30) NULL,
	[會員電話] [varchar](20) NULL,
	[通報標題] [nvarchar](30) NULL,
	[狀況概述] [nvarchar](500) NULL,
	[通報時間] [datetime] NULL,
	[通報地點_市] [int] NULL,
	[通報地點_區] [int] NULL,
	[發生地點_全] [nvarchar](100) NULL,
	[急迫性編號] [int] NULL,
	[附件一] [nvarchar](500) NULL,
	[附件二] [nvarchar](500) NULL,
	[附件三] [nvarchar](500) NULL,
	[是否結案] [varchar](1) NULL,
	[建立時間] [datetime] NULL,
	[更新時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[通報編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[會員違規紀錄]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[會員違規紀錄](
	[違規紀錄編號] [int] IDENTITY(1,1) NOT NULL,
	[留言編號] [int] NULL,
	[違規行為編號] [int] NULL,
	[違規時間] [datetime] NULL,
	[懲罰結束時間] [datetime] NULL,
	[備註] [nvarchar](100) NULL,
	[是否成立] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[違規紀錄編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[違規行為]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[違規行為](
	[違規行為編號] [int] IDENTITY(1,1) NOT NULL,
	[違規行為名稱] [nvarchar](100) NULL,
	[懲罰天數] [int] NULL,
	[備註] [nvarchar](100) NULL,
	[是否啟用] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[違規行為編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[醫院會員資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[醫院會員資料](
	[編號] [int] IDENTITY(1,1) NOT NULL,
	[會員編號] [int] NULL,
	[醫院名字] [nvarchar](30) NULL,
	[醫院電話] [varchar](20) NULL,
	[醫院信箱] [nvarchar](50) NULL,
	[聯絡人] [nvarchar](1) NULL,
	[所在地點_市] [int] NULL,
	[所在地點_區] [int] NULL,
	[所在地點_全] [nvarchar](100) NULL,
	[備註] [nvarchar](100) NULL,
	[營業時間] [nvarchar](100) NULL,
 CONSTRAINT [PK_醫院會員資料] PRIMARY KEY CLUSTERED 
(
	[編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[寵物資料]    Script Date: 2021/6/29 上午 04:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[寵物資料](
	[寵物編號] [int] IDENTITY(1,1) NOT NULL,
	[動物別編號] [int] NULL,
	[品種編號] [int] NULL,
	[晶片號碼] [varchar](50) NULL,
	[寵物稱呼] [nvarchar](50) NULL,
	[寵物年紀] [int] NULL,
	[寵物性別] [varchar](1) NULL,
	[健康狀況] [nvarchar](500) NULL,
	[附件一] [nvarchar](500) NULL,
	[附件二] [nvarchar](500) NULL,
	[附件三] [nvarchar](500) NULL,
	[建立時間] [datetime] NULL,
	[更新時間] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[寵物編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[地區] ON 

INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (1, 1, N'東區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (2, 1, N'南區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (3, 1, N'北區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (4, 1, N'中西區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (5, 1, N'安南區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (6, 1, N'安平區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (7, 1, N'東山區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (8, 1, N'白河區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (9, 1, N'七股區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (10, 1, N'永康區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (11, 1, N'新營區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (12, 1, N'後壁區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (13, 1, N'學甲區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (14, 1, N'歸仁區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (15, 1, N'龍崎區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (16, 1, N'善化區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (17, 1, N'新化區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (18, 1, N'佳里區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (19, 1, N'仁德區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (20, 1, N'麻豆區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (21, 1, N'新市區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (22, 1, N'柳營區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (23, 1, N'關廟區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (24, 1, N'鹽水區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (25, 1, N'官田區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (26, 1, N'將軍區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (27, 1, N'六甲區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (28, 1, N'下營區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (29, 1, N'楠西區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (30, 1, N'安定區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (31, 1, N'西港區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (32, 1, N'左鎮區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (33, 1, N'山上區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (34, 1, N'大內區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (35, 1, N'玉井區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (36, 1, N'南化區', N'', N'1')
INSERT [dbo].[地區] ([地區編號], [城市編號], [地區名稱], [備註], [是否啟用]) VALUES (37, 1, N'北門區', N'', N'1')
SET IDENTITY_INSERT [dbo].[地區] OFF
GO
SET IDENTITY_INSERT [dbo].[城市] ON 

INSERT [dbo].[城市] ([城市編號], [城市名稱], [備註], [是否啟用]) VALUES (1, N'台南市', N'', N'1')
INSERT [dbo].[城市] ([城市編號], [城市名稱], [備註], [是否啟用]) VALUES (2, N'高雄市', N'', N'1')
SET IDENTITY_INSERT [dbo].[城市] OFF
GO
SET IDENTITY_INSERT [dbo].[急迫性] ON 

INSERT [dbo].[急迫性] ([急迫性編號], [急迫性名稱], [備註], [是否啟用], [排序]) VALUES (1, N'需急救(需要立即處置)', N'', N'1', 1)
INSERT [dbo].[急迫性] ([急迫性編號], [急迫性名稱], [備註], [是否啟用], [排序]) VALUES (2, N'危急(有潛在性生命危險)', N'', N'1', 2)
INSERT [dbo].[急迫性] ([急迫性編號], [急迫性名稱], [備註], [是否啟用], [排序]) VALUES (3, N'
緊急(狀況可能惡化)', N'', N'1', 3)
INSERT [dbo].[急迫性] ([急迫性編號], [急迫性名稱], [備註], [是否啟用], [排序]) VALUES (4, N'次緊急(慢性病或某些疾病之合併症)', N'', N'1', 4)
INSERT [dbo].[急迫性] ([急迫性編號], [急迫性名稱], [備註], [是否啟用], [排序]) VALUES (5, N'非緊急', N'', N'1', 5)
SET IDENTITY_INSERT [dbo].[急迫性] OFF
GO
USE [master]
GO
ALTER DATABASE [MaoUpFind] SET  READ_WRITE 
GO
