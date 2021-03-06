USE [master]
GO
/****** Object:  Database [ProjectSem3DB]    Script Date: 5/23/2021 9:52:42 PM ******/
CREATE DATABASE [ProjectSem3DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectSem3DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjectSem3DB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectSem3DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjectSem3DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectSem3DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectSem3DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectSem3DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProjectSem3DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectSem3DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectSem3DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjectSem3DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectSem3DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectSem3DB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectSem3DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectSem3DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectSem3DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectSem3DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectSem3DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjectSem3DB]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[About_Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [text] NULL,
	[Title] [text] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_AboutUs] PRIMARY KEY CLUSTERED 
(
	[About_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ad_Package]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ad_Package](
	[Package_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_AdPackage] [text] NULL,
	[Period] [int] NULL,
	[Price] [money] NULL,
	[Description] [text] NULL,
	[StatusBuy] [bit] NULL,
	[PostNumber] [int] NULL,
 CONSTRAINT [PK_Ad_Package] PRIMARY KEY CLUSTERED 
(
	[Package_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [text] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[City_Id] [varchar](50) NOT NULL,
	[Name] [text] NULL,
	[Region_Id] [varchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[City_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Country_Id] [varchar](50) NOT NULL,
	[Name] [text] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Country_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[Image_Id] [int] IDENTITY(1,1) NOT NULL,
	[Property_Id] [int] NULL,
	[News_Id] [int] NULL,
	[Name] [varchar](250) NULL,
 CONSTRAINT [PK_Property_Image] PRIMARY KEY CLUSTERED 
(
	[Image_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Invoice_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Created] [date] NOT NULL,
	[Total] [money] NOT NULL,
	[Payment_Id] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Member_Id] [int] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mailbox]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mailbox](
	[Mail_Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[Message] [text] NULL,
	[Property_Id] [int] NULL,
 CONSTRAINT [PK_Mailbox] PRIMARY KEY CLUSTERED 
(
	[Mail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[Member_Id] [int] IDENTITY(1,1) NOT NULL,
	[Role_Id] [int] NULL,
	[Username] [varchar](250) NOT NULL,
	[Password] [varchar](250) NULL,
	[FullName] [varchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Photo] [varchar](250) NULL,
	[Create_Date] [date] NOT NULL,
	[Verify_Code] [varchar](10) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Member_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member_Package_Detail]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member_Package_Detail](
	[Member_Id] [int] NOT NULL,
	[Package_Id] [int] NOT NULL,
	[Payment_Id] [int] NULL,
	[Expiry_Date] [date] NULL,
 CONSTRAINT [PK_Account_Package_Detail] PRIMARY KEY CLUSTERED 
(
	[Member_Id] ASC,
	[Package_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[News](
	[News_Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](250) NULL,
	[Description] [text] NULL,
	[Category_Id] [int] NULL,
	[Created_Date] [date] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[News_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[News_Category]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[News_Category](
	[News_Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_News_Category] PRIMARY KEY CLUSTERED 
(
	[News_Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[Payment_Id] [int] IDENTITY(1,1) NOT NULL,
	[Payment_Method] [varchar](50) NULL,
	[Total_Price] [text] NULL,
	[Paypal_Card] [varchar](50) NULL,
	[Member_Id] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Payment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Property]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property](
	[Property_Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [text] NOT NULL,
	[City_Id] [varchar](50) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[GoogleMap] [text] NULL,
	[Price] [money] NOT NULL,
	[Bed_Number] [int] NOT NULL,
	[Room_Number] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Area] [float] NOT NULL,
	[Sold_Date] [date] NULL,
	[Upload_Date] [date] NOT NULL,
	[Build_Year] [date] NOT NULL,
	[Status_Id] [int] NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Member_Id] [int] NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Property_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Region]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Region](
	[Region_Id] [varchar](50) NOT NULL,
	[Name] [text] NULL,
	[Country_Id] [varchar](50) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Region_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Role_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setting](
	[NumTopProperty] [int] NULL,
	[NumPopularLocation] [int] NULL,
	[NumNews] [int] NULL,
	[NumPopularAgent] [int] NULL,
	[NumProperty] [int] NULL,
	[NumMaxImageProperty] [int] NULL,
	[NumMaxImageNews] [int] NULL,
	[NumSatisfiedCustomer] [int] NULL,
	[Phone] [varchar](250) NULL,
	[Email] [varchar](250) NULL,
	[Address] [varchar](250) NULL,
	[Description] [text] NULL,
	[Services] [varchar](250) NULL,
	[AboutUsTitle] [varchar](250) NULL,
	[ThumbnailWebsite] [text] NULL,
	[ThumbnailAboutUs] [text] NULL,
	[ThumbnailHome] [text] NULL,
	[Reviews] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/23/2021 9:52:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status](
	[Status_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AboutUs] ON 

INSERT [dbo].[AboutUs] ([About_Id], [Question], [Title], [Description]) VALUES (1, N'WHO WE ARE', N'The experts in local and international property', N'We have over 15 year experience, Over 20,000 people work for us in more than 70 countries all over the world. Learn more about our work! Lorem ipsum vive dolor sit amet.

Viverra feugiat. Pellen tesque libero ut justo, ultrices in ligula. Semper at tempufddfel lorem ipsum.')
SET IDENTITY_INSERT [dbo].[AboutUs] OFF
SET IDENTITY_INSERT [dbo].[Ad_Package] ON 

INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (1, N'Private Announce No1', 90, 59.0000, N'Advertising Package for private individuals. List your property for sale or rent. Get multilingual exposure. Target international investors. Advertisement publication period is 3 months (90 days).', NULL, 5)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (2, N'Private Announce Unlimited No1', 365, 99.0000, N'Advertising Package for private individuals. List your property for sale or rent. Get multilingual exposure. Target international investors. It allows to list the property for an Unlimited Period of time until it is sold or rented.', NULL, 5)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (3, N'Private Announce No2', 90, 119.0000, N'Advertising package for Private individuals. List your property for sale or rent. Get multilingual exposure. Target international investors. Allow to publish 10 advertisements for period 3 months (90 days).', NULL, 10)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (4, N'Private Announce Unlimited No2', 365, 159.0000, N'Advertising Package for Private individuals. List your property for sale or rent. Get multilingual exposure. Target international investors. It allows to list 10 properties offers for an Unlimited Period of time until they are sold or rented.', NULL, 10)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (5, N'Profi Neo', 60, 59.0000, N'Advertising package for Professionals & Companies allow to publish an unlimited number of ads within the limit of 2 ads simultaneously accessible to visitors during 2 months. Include professional & company presentation page listed in all multi-lingual real estate related companies international directory for Unlimited Time.', NULL, 3)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (6, N'Profi Classic', 120, 99.0000, N'Advertising package for Professionals & Companies allow to publish an unlimited number of ads within the limit of 7 ads simultaneously accessible to visitors during 4 months. Include professional & company presentation page listed in all multi-lingual real estate related companies international directory for Unlimited Time.', NULL, 6)
INSERT [dbo].[Ad_Package] ([Package_Id], [Name_AdPackage], [Period], [Price], [Description], [StatusBuy], [PostNumber]) VALUES (7, N'Integral Pro', 180, 139.0000, N'Advertising package for Professionals & Companies allow to publish an unlimited number of ads within the limit of 12 ads simultaneously accessible to visitors during 6 months. Include professional & company presentation page listed in all multi-lingual real estate related companies international directory for Unlimited Time.', NULL, 9)
SET IDENTITY_INSERT [dbo].[Ad_Package] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (1, N'Office Space')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (2, N'Shops')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (3, N'Commercial Land')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (4, N'Industrial')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (5, N'House')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (6, N'Apartments')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (7, N'Villas')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (8, N'Businesses for Sale')
INSERT [dbo].[Category] ([Category_Id], [Name]) VALUES (9, N'Rent and Lease')
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'jp_kan_cb', N'Chiba', N'jp_kan')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'jp_kan_tko', N'Tokyo', N'jp_kan')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'kr_south_in', N'Incheon', N'kr_south')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'kr_south_seo', N'Seoul', N'kr_south')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'usa_midwest_nd', N'North Dakota', N'usa_midwest')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'usa_midwest_oh', N'Ohio', N'usa_midwest')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'usa_north_ny', N'New York', N'usa_north')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'usa_north_pa', N'Pennsylvania', N'usa_north')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'vn_north_hn', N'Ha Noi', N'vn_north')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'vn_south_ct', N'Can Tho', N'vn_south')
INSERT [dbo].[City] ([City_Id], [Name], [Region_Id]) VALUES (N'vn_south_hcm', N'Ho Chi Minh', N'vn_south')
INSERT [dbo].[Country] ([Country_Id], [Name]) VALUES (N'jp', N'Japan')
INSERT [dbo].[Country] ([Country_Id], [Name]) VALUES (N'kr', N'South Korea')
INSERT [dbo].[Country] ([Country_Id], [Name]) VALUES (N'usa', N'America')
INSERT [dbo].[Country] ([Country_Id], [Name]) VALUES (N'vn', N'VietNam')
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (1, 1, NULL, N'image1.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (2, 4, NULL, N'image2.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (3, 5, NULL, N'image3.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (4, 6, NULL, N'image4.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (5, 7, NULL, N'image5.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (6, 8, NULL, N'image6.jpg')
INSERT [dbo].[Image] ([Image_Id], [Property_Id], [News_Id], [Name]) VALUES (7, 9, NULL, N'image7.jpg')
SET IDENTITY_INSERT [dbo].[Image] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (1, 1, N'admin1', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Admin Handsome', N'0123456789', N'thu951252@gmail.com', 1, NULL, CAST(N'2001-09-16' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (2, 1, N'admin2', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Admin Pretty', N'03216544987', N'adminpretty@gmail.com', 1, NULL, CAST(N'1999-12-16' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (3, 2, N'vingroup', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'VinGroup', N'0325146987', N'vin@gmail.com', 1, NULL, CAST(N'2000-04-23' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (5, 2, N'agent2', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Agent 2 ', N'0213564879', N'agent2@gmail.com', 1, NULL, CAST(N'1998-06-13' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (6, 3, N'seller1', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Seller 1 ', N'0152346987', N'seller1@gmail.com', 1, NULL, CAST(N'1996-12-06' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (7, 3, N'seller2', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Seller 2', N'0214536982', N'seller2@gmail.com', 0, NULL, CAST(N'1992-12-09' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (8, 3, N'seller3', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Seller 3', N'0326521458', N'seller1@gmail.com', 1, NULL, CAST(N'1995-06-06' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (10, 4, N'customer1', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Customer 1', N'0354751761', N'customer1@gmail.com', 1, NULL, CAST(N'1998-03-06' AS Date), NULL)
INSERT [dbo].[Member] ([Member_Id], [Role_Id], [Username], [Password], [FullName], [Phone], [Email], [Status], [Photo], [Create_Date], [Verify_Code]) VALUES (11, 4, N'customer2', N'$2y$12$0Hi8DPs/eUX8Rq6Y0bvpsup2X/w9QKmctUT2GARkLXeX6d2GfSAVi', N'Customer 2', N'0653215689', N'customer2@gmail.com', 1, NULL, CAST(N'1998-04-06' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Member] OFF
INSERT [dbo].[Member_Package_Detail] ([Member_Id], [Package_Id], [Payment_Id], [Expiry_Date]) VALUES (1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (1, N'Melbourne builder Vaughan Constructions ', N'usa_north_ny', N'4A Manor St, Brighton, Vic 3186', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3147.5305512970863!2d144.98753681517863!3d-37.918034179733695!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad66f3398220f03%3A0x320a6c6e09918167!2s4A%20Manor%20St%2C%20Brighton%20VIC%203186%2C%20%C3%9Ac!5e0!3m2!1svi!2s!4v1621436400940!5m2!1svi!2s', 111.0000, 3, 5, N'Rent', 512, NULL, CAST(N'2020-11-20' AS Date), CAST(N'2018-01-01' AS Date), 1, 5, 3, N'Prominently positioned so close to sand and sea in one of Brighton???s most exclusive streets, featuring 81 foot frontage to Manor Street, this spectacular 5 bedroom, 4.5 bathroom (plus self-contained poolside pavilion) masterpiece is simply breathtaking in scope.
Live the Bayside life you love with style, substance and sophistication, enhanced by a floodlit tennis court and resort-inspired showpiece pool')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (4, N'Nick Scali Building', N'usa_north_pa', N'6 Edward Street, Kew, Vic 3101

', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3152.036796948459!2d145.05374401517543!3d-37.81260707975258!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad641646b6d05b7%3A0xda8e1ef420d045e4!2s6%20Edward%20St%2C%20Kew%20VIC%203101%2C%20%C3%9Ac!5e0!3m2!1svi!2s!4v1621438140927!5m2!1svi!2s', 211.0000, 4, 4, N'Sale', 1216, CAST(N'2021-05-08' AS Date), CAST(N'2021-01-13' AS Date), CAST(N'2018-03-03' AS Date), 5, 7, 5, N'Proudly established on a significant 1216 sq m approx. block, this completely original five bedroom home has no overlays in one of Kew''s finest streets within the exclusive Sackville Ward.')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (5, N'GRAVITAS ARISUGAWA', N'jp_kan_tko', N'3-8-2 MinamiAzabu, Minato', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2706.6464816517864!2d139.7284054352593!3d35.650210433514374!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x60188b0a5fa75479%3A0xc7c06de09c369143!2sMinamiazabu%203-Chome%20Nursery%20Room!5e0!3m2!1svi!2s!4v1621438237151!5m2!1svi!2s', 342.0000, 3, 6, N'Rent', 94, NULL, CAST(N'2021-02-16' AS Date), CAST(N'2019-05-05' AS Date), 1, 5, 6, N'- Stunning entrance atrium  
??? 3.3m high ceilings in living-dining floor  
??? Spacious open sky terrace  
??? Wide frontage (approx. 15m)  
??? Flat access garage with parking for 3 cars  
??? Magnificent entertainment space and collection room  ')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (6, N'WHOLE BUILDING HOUSE', N'jp_kan_cb', N'Futawa higashi, Funabashi-shi', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3240.0733043607747!2d140.00210921511206!3d35.699813680189926!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x60187fe5c40e7d41%3A0xa1954102077121e9!2sHIGASHI-FUNABASHI%20STATION!5e0!3m2!1svi!2s!4v1621438299910!5m2!1svi!2s', 120.0000, 2, 2, N'Rent', 45, NULL, CAST(N'2021-05-10' AS Date), CAST(N'2020-12-03' AS Date), 1, 9, 5, N'5 minutes walking distance to Shin-Keisei Line Futawamukoudai Station (400m), 1 minute walking distance to a supermarket: Maruetsu (33m), 5 minutes walking distance to TSUTAYA Sakigaoka Store (400m), 9 minutes walking distance to Funabashi Futawa Hospital (750m), 2 minutes walking distance to Funabashi Aozora nursery (180m) 6 minutes walking distance to Funabashi Municipal Misaki Elementary School (500m)')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (7, N'Takanawa the residence', N'jp_kan_tko', N'Takanawa, Minato-ku', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10828.815302025765!2d139.7284303538609!3d35.63375811697772!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x60188a552bb014f3%3A0xe59c8b7291b44bc6!2sTakanawadai%20Elementary%20School!5e0!3m2!1svi!2s!4v1621438404400!5m2!1svi!2s', 300.0000, 5, 6, N'Sale', 200, NULL, CAST(N'2020-12-30' AS Date), CAST(N'2016-02-03' AS Date), 1, 6, 1, N'8 minutes walk from "Shirokanedai" station on the Tokyo Metro Namboku Line and Toei Mita Line
6 minutes walk from Takanawadai Station on the Toei Asakusa Line')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (8, N'Dongyang Building', N'kr_south_seo', N'518, Samseong-ro, Gangnam-gu
Seoul Si, Seoul Si', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3164.982258922713!2d127.05403161516608!3d37.5083365798088!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x357ca41482429821%3A0x1f8d55a01af01377!2s518%20Samseong-ro%2C%20Samseong%201(il)-dong%2C%20Gangnam-gu%2C%20Seoul%2C%20H%C3%A0n%20Qu%E1%BB%91c!5e0!3m2!1svi!2s!4v1621438435097!5m2!1svi!2s', 320.0000, 6, 8, N'Sale', 252, CAST(N'2021-03-15' AS Date), CAST(N'2021-01-11' AS Date), CAST(N'2018-03-01' AS Date), 5, 8, 5, N'518, Samseong-ro, Gangnam-gu
Seoul Si, Seoul Si')
INSERT [dbo].[Property] ([Property_Id], [Title], [City_Id], [Address], [GoogleMap], [Price], [Bed_Number], [Room_Number], [Type], [Area], [Sold_Date], [Upload_Date], [Build_Year], [Status_Id], [Category_Id], [Member_Id], [Description]) VALUES (9, N'Ultra high-rise tower apartment', N'kr_south_seo', N'36 Yeoui-dong, Yeongdeungpo-gu', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3164.481857399326!2d126.92420991516641!3d37.520137079806595!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x357c9f161b074965%3A0x1b807211e08a5b7d!2s36%20Yeoui-dong%2C%20Yeongdeungpo-gu%2C%20Seoul%2C%20H%C3%A0n%20Qu%E1%BB%91c!5e0!3m2!1svi!2s!4v1621438464217!5m2!1svi!2s', 134.0000, 2, 3, N'Sale', 100, NULL, CAST(N'2021-03-02' AS Date), CAST(N'2005-06-01' AS Date), 2, 5, 7, N'1bedroom & 1bathroom luxury apartment in a beautiful modern high rise apartment building located in Yeoido. The apartment  has everything you will need in your new home ')
SET IDENTITY_INSERT [dbo].[Property] OFF
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'jp_hok', N'Hokkaido', N'jp')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'jp_kan', N'Kanto', N'jp')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'jp_shi', N'Shikoku', N'jp')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'kr_south', N'South Korea', N'kr')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'usa_midwest', N'Midwest', N'usa')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'usa_north', N'Northeast USA', N'usa')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'vn_north', N'North VietNam', N'vn')
INSERT [dbo].[Region] ([Region_Id], [Name], [Country_Id]) VALUES (N'vn_south', N'South VietNam', N'vn')
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Role_Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Role_Id], [Name]) VALUES (2, N'Agent')
INSERT [dbo].[Role] ([Role_Id], [Name]) VALUES (3, N'Private Seller')
INSERT [dbo].[Role] ([Role_Id], [Name]) VALUES (4, N'Customer')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Status_Id], [Name]) VALUES (1, N'Ativate')
INSERT [dbo].[Status] ([Status_Id], [Name]) VALUES (2, N'Deactivate')
INSERT [dbo].[Status] ([Status_Id], [Name]) VALUES (4, N'Pending')
INSERT [dbo].[Status] ([Status_Id], [Name]) VALUES (5, N'Sold')
INSERT [dbo].[Status] ([Status_Id], [Name]) VALUES (7, N'Rented')
SET IDENTITY_INSERT [dbo].[Status] OFF
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Region] FOREIGN KEY([Region_Id])
REFERENCES [dbo].[Region] ([Region_Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Region]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_News] FOREIGN KEY([News_Id])
REFERENCES [dbo].[News] ([News_Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_News]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Property_Image_Property] FOREIGN KEY([Property_Id])
REFERENCES [dbo].[Property] ([Property_Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Property_Image_Property]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Member] FOREIGN KEY([Member_Id])
REFERENCES [dbo].[Member] ([Member_Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Member]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Payment] FOREIGN KEY([Payment_Id])
REFERENCES [dbo].[Payment] ([Payment_Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Payment]
GO
ALTER TABLE [dbo].[Mailbox]  WITH CHECK ADD  CONSTRAINT [FK_Mailbox_Property] FOREIGN KEY([Property_Id])
REFERENCES [dbo].[Property] ([Property_Id])
GO
ALTER TABLE [dbo].[Mailbox] CHECK CONSTRAINT [FK_Mailbox_Property]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Role] FOREIGN KEY([Role_Id])
REFERENCES [dbo].[Role] ([Role_Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Role]
GO
ALTER TABLE [dbo].[Member_Package_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Account_Package_Detail_Account] FOREIGN KEY([Member_Id])
REFERENCES [dbo].[Member] ([Member_Id])
GO
ALTER TABLE [dbo].[Member_Package_Detail] CHECK CONSTRAINT [FK_Account_Package_Detail_Account]
GO
ALTER TABLE [dbo].[Member_Package_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Account_Package_Detail_Ad_Package] FOREIGN KEY([Package_Id])
REFERENCES [dbo].[Ad_Package] ([Package_Id])
GO
ALTER TABLE [dbo].[Member_Package_Detail] CHECK CONSTRAINT [FK_Account_Package_Detail_Ad_Package]
GO
ALTER TABLE [dbo].[Member_Package_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Member_Package_Detail_Payment] FOREIGN KEY([Payment_Id])
REFERENCES [dbo].[Payment] ([Payment_Id])
GO
ALTER TABLE [dbo].[Member_Package_Detail] CHECK CONSTRAINT [FK_Member_Package_Detail_Payment]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_News_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[News_Category] ([News_Category_Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_News_Category]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Category_Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Category]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_City] FOREIGN KEY([City_Id])
REFERENCES [dbo].[City] ([City_Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_City]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Member] FOREIGN KEY([Member_Id])
REFERENCES [dbo].[Member] ([Member_Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Member]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Status] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Status_Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Status]
GO
ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_Region_Country] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Country_Id])
GO
ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_Region_Country]
GO
USE [master]
GO
ALTER DATABASE [ProjectSem3DB] SET  READ_WRITE 
GO
