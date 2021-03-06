USE [master]
GO
/****** Object:  Database [BATZ]    Script Date: 12/1/2016 2:17:08 PM ******/
CREATE DATABASE [BATZ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BATZ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BATZ.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BATZ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BATZ_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BATZ] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BATZ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BATZ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BATZ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BATZ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BATZ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BATZ] SET ARITHABORT OFF 
GO
ALTER DATABASE [BATZ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BATZ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BATZ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BATZ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BATZ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BATZ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BATZ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BATZ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BATZ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BATZ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BATZ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BATZ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BATZ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BATZ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BATZ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BATZ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BATZ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BATZ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BATZ] SET  MULTI_USER 
GO
ALTER DATABASE [BATZ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BATZ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BATZ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BATZ] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BATZ] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BATZ]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](100) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[AlbumCoverImage] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlbumTrack]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AlbumTrack](
	[AlbumTrackId] [int] IDENTITY(1,1) NOT NULL,
	[TrackName] [varchar](50) NOT NULL,
	[AlbumId] [int] NOT NULL,
	[TrackFilePath] [varchar](50) NULL,
 CONSTRAINT [PK_AlbumTrack] PRIMARY KEY CLUSTERED 
(
	[AlbumTrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[PostDate] [date] NOT NULL,
	[PostBody] [varchar](max) NOT NULL,
	[AuthorId] [int] NULL,
	[CatagoryId] [int] NOT NULL,
	[StatusofApproval] [int] NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorys](
	[CatagoryId] [int] IDENTITY(1,1) NOT NULL,
	[CatagoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CatagoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MediaLinks]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MediaLinks](
	[MediaLinkId] [int] IDENTITY(1,1) NOT NULL,
	[MediaLinkURL] [varchar](max) NOT NULL,
	[MediaType] [int] NOT NULL,
	[MediaLinkName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MediaLinks] PRIMARY KEY CLUSTERED 
(
	[MediaLinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MediaLinksBlogs]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaLinksBlogs](
	[MediaLinkId] [int] NOT NULL,
	[BlogId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaTypes]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MediaTypes](
	[MediaTypeId] [int] IDENTITY(1,1) NOT NULL,
	[MediaType] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CustomerFirstName] [varchar](50) NOT NULL,
	[CustomerCity] [varchar](50) NOT NULL,
	[CustomerState] [varchar](50) NOT NULL,
	[CustomerLastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PageTags]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageTags](
	[PageId] [int] NOT NULL,
	[TagId] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostTags]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTags](
	[BlogId] [int] NULL,
	[TagId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductDescription] [varchar](max) NULL,
	[Price] [money] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductImagePath] [varchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shows]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shows](
	[ShowId] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[ShowDate] [date] NOT NULL,
 CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED 
(
	[ShowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaticPages]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaticPages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[PageBody] [varchar](max) NOT NULL,
 CONSTRAINT [PK_StaticPages] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([AlbumId], [AlbumName], [ReleaseDate], [AlbumCoverImage]) VALUES (1, N'TestAlbum', CAST(N'2016-10-01' AS Date), N'/MediaFiles/AlbumCover1.jpg')
SET IDENTITY_INSERT [dbo].[Albums] OFF
SET IDENTITY_INSERT [dbo].[AlbumTrack] ON 

INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (1, N'TestSong', 1, N'/MediaFiles/albumtTrack1.mp3')
INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (2, N'Tessssssst', 1, N'/MediaFiles/albumTrack2.mp3')
SET IDENTITY_INSERT [dbo].[AlbumTrack] OFF
SET IDENTITY_INSERT [dbo].[BlogPosts] ON 

INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorId], [CatagoryId], [StatusofApproval]) VALUES (2, N'Upcoming Show!', CAST(N'2016-11-29' AS Date), N'Bacon ipsum dolor amet porchetta t-bone pork chop brisket swine kielbasa bacon meatloaf cow. Tongue tenderloin swine bacon doner pig andouille ham hock kielbasa tail beef tri-tip filet mignon. Porchetta burgdoggen flank tenderloin. Short loin cupim rump, fatback prosciutto picanha tail kevin. Boudin chicken spare ribs ham hock tenderloin alcatra venison rump leberkas tail chuck.

Hamburger short loin leberkas porchetta. Jowl cupim jerky biltong strip steak. Burgdoggen chicken frankfurter, t-bone prosciutto shoulder porchetta brisket filet mignon kevin. Spare ribs fatback rump tri-tip chuck. Beef ribs shoulder salami strip steak landjaeger jowl capicola picanha jerky leberkas tongue bacon sausage chicken beef. Pork belly sirloin tongue hamburger swine pork loin jowl short loin shankle meatloaf pastrami filet mignon flank leberkas kevin. Leberkas pork kevin, meatball pork chop beef ribs filet mignon doner pancetta tenderloin ham hock.

Swine alcatra chuck pork belly tenderloin jowl. Alcatra pork chop pastrami, ball tip spare ribs chicken tenderloin pork belly cupim tongue kevin short loin rump burgdoggen. Sausage jerky meatball porchetta. Filet mignon pork belly chicken biltong doner pork loin ball tip burgdoggen jowl. Ham hock cow biltong fatback. Beef ribs kevin rump burgdoggen drumstick, andouille meatball kielbasa shankle pork chop fatback tri-tip ground round landjaeger. Ball tip bresaola sausage, tail pork belly t-bone chicken sirloin spare ribs boudin.', NULL, 1, 1)
INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorId], [CatagoryId], [StatusofApproval]) VALUES (3, N'Some Exciting news!', CAST(N'2016-11-20' AS Date), N'Bacon ipsum dolor amet cupim bresaola venison sirloin turducken. Pastrami sausage bresaola, tenderloin meatloaf pig tri-tip. Fatback boudin turducken short loin bacon tail flank landjaeger shank. Rump kevin filet mignon, meatloaf prosciutto pork chop bacon landjaeger. Brisket chuck ground round cow porchetta.

Landjaeger andouille jerky, cow ground round chuck alcatra brisket shank prosciutto bresaola pancetta tail bacon. Chicken jowl ball tip brisket salami rump, andouille shank bresaola. Frankfurter swine corned beef shankle sausage alcatra. Jerky short ribs pork belly, bresaola ribeye picanha burgdoggen sirloin frankfurter prosciutto salami boudin rump pastrami cupim. Short loin andouille drumstick swine kevin.', NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([CatagoryId], [CatagoryName]) VALUES (1, N'Posts')
SET IDENTITY_INSERT [dbo].[Categorys] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ProductId], [Quantity], [CustomerFirstName], [CustomerCity], [CustomerState], [CustomerLastName]) VALUES (1, CAST(N'2016-11-30' AS Date), 2, 2, N'Benjamin', N'Cleveland Heights', N'OH - Ohio', N'Kraus')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductCategoryName]) VALUES (1, N'Clothing')
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductCategoryName]) VALUES (2, N'Albums')
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (2, N'Ryan Tshirt', N'Great T-shirt with ryans face. Great for frightening children', 15.0000, 1, N'/MediaFiles/Images/ryanface.jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (4, N'Jacob T-Shirt', N'Whoa who put this guy on a t-shirt. Great way to keep the ladies away', 15.0000, 1, N'/MediaFiles/Images/jacobface.jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (5, N'Album 1', N'Great album', 20.0000, 2, N'/MediaFiles/AlbumCover1.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Shows] ON 

INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (2, N'Akron Civic', N'Akron', N'Ohio', CAST(N'2016-12-20' AS Date))
INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (3, N'NationWideArena', N'Columbus', N'ohio', CAST(N'2016-11-15' AS Date))
SET IDENTITY_INSERT [dbo].[Shows] OFF
ALTER TABLE [dbo].[AlbumTrack]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTrack_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[AlbumTrack] CHECK CONSTRAINT [FK_AlbumTrack_Albums]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPost_Author]
GO
ALTER TABLE [dbo].[MediaLinksBlogs]  WITH CHECK ADD  CONSTRAINT [FK_MediaLinksBlogs_BlogPosts] FOREIGN KEY([BlogId])
REFERENCES [dbo].[BlogPosts] ([BlogId])
GO
ALTER TABLE [dbo].[MediaLinksBlogs] CHECK CONSTRAINT [FK_MediaLinksBlogs_BlogPosts]
GO
ALTER TABLE [dbo].[MediaLinksBlogs]  WITH CHECK ADD  CONSTRAINT [FK_MediaLinksBlogs_MediaLinks] FOREIGN KEY([MediaLinkId])
REFERENCES [dbo].[MediaLinks] ([MediaLinkId])
GO
ALTER TABLE [dbo].[MediaLinksBlogs] CHECK CONSTRAINT [FK_MediaLinksBlogs_MediaLinks]
GO
ALTER TABLE [dbo].[PageTags]  WITH CHECK ADD  CONSTRAINT [FK_PageTag_StaticPages] FOREIGN KEY([PageId])
REFERENCES [dbo].[StaticPages] ([PageId])
GO
ALTER TABLE [dbo].[PageTags] CHECK CONSTRAINT [FK_PageTag_StaticPages]
GO
ALTER TABLE [dbo].[PageTags]  WITH CHECK ADD  CONSTRAINT [FK_PageTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[PageTags] CHECK CONSTRAINT [FK_PageTag_Tag]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_BlogPost] FOREIGN KEY([BlogId])
REFERENCES [dbo].[BlogPosts] ([BlogId])
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTag_BlogPost]
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[PostTags] CHECK CONSTRAINT [FK_PostTag_Tag]
GO
/****** Object:  StoredProcedure [dbo].[AddBlogPost]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddBlogPost]
(
--@AuthorFirstName varchar(50),
--@AuthorLastName varchar(50),
--@AuthorUserName varchar(50),
@BlogCatagory int,
@PostBody varchar(MAX),
@PostStatus int,
@PostTitle varchar(50),
@PostDate date

)AS
--Delete a Blog Post By Id
   -- DECLARE @AuthorId int
	--INSERT INTO Authors(FirstName,LastName,UserName)
	--VALUES(@AuthorFirstName,@AuthorLastName,@AuthorUserName)

	--SET @AuthorId=(
	    -- SELECT AuthorId
	    -- FROM Authors 
	   --  WHERE FirstName=@AuthorFirstName)

	INSERT INTO BlogPosts(Title,PostDate,PostBody,CatagoryId,StatusOfApproval)
	VALUES (@PostTitle,@PostDate,@PostBody,@BlogCatagory,@PostStatus)

	


GO
/****** Object:  StoredProcedure [dbo].[AddMediaLink]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddMediaLink]
(
@BlogId int,
@MediaType int,
@MediaLink varchar(MAX)
)AS

INSERT INTO MediaLinks(MediaLinkURL,MediaType)
VALUES(@MediaLink,@MediaType)

DECLARE @MediaLinkId int;
SET @MediaLinkId=(SELECT MediaLinkId
FROM MediaLinks
WHERE MediaLinks.MediaLinkURL=@MediaLink)

INSERT INTO MediaLinksBlogs(MediaLinkId,BlogId)
VALUES(@MediaLinkId,@BlogId)



GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]( 
	@ProductId int, 
	@ProductName varchar(50), 
	@ProductDescription varchar(max), 
	@Price money,
	@CategoryId int,
	@ProductImagePath varchar(max)
) AS 
BEGIN
	INSERT INTO Products (ProductName, ProductDescription, Price, CategoryId, ProductImagePath)
	VALUES (@ProductName, @ProductDescription, @Price, @CategoryId, @ProductImagePath)

	SET @ProductId = SCOPE_IDENTITY();
END


GO
/****** Object:  StoredProcedure [dbo].[AddProductOrder]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProductOrder](
	@OrderDate date, 
	@ProductId int, 
	@Quantity int,
	@CustomerFirstName varchar(50),
	@CustomerLastName varchar(50),
	@CustomerState varchar(50),
	@CustomerCity varchar(50)
) AS 
BEGIN
	INSERT INTO Orders (OrderDate, ProductId, Quantity, CustomerFirstName, CustomerLastName, CustomerCity, CustomerState)
	VALUES (@OrderDate, @ProductId, @Quantity, @CustomerFirstName, @CustomerLastName, @CustomerCity, @CustomerState)

END

GO
/****** Object:  StoredProcedure [dbo].[AddShow]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddShow] 
	-- Add the parameters for the stored procedure here
	@Date date,
	@Venue varchar(50),
	@City varchar(50),
	@State varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Shows(ShowDate,VenueName,City,[State])
	VALUES (@Date,@Venue,@City,@State)
END

GO
/****** Object:  StoredProcedure [dbo].[AddStaticPage]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:

CREATE PROCEDURE [dbo].[AddStaticPage]
(

@Title varchar(50),
@PageBody varchar(MAX)
)AS
INSERT INTO StaticPages(Title,PageBody)
VALUES(@Title,@PageBody)



GO
/****** Object:  StoredProcedure [dbo].[AddTag]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTag]
(
@BlogId int,

@Name int
)AS

INSERT INTO  Tags(Name)
VALUES(@Name)
DECLARE @TagId int 
SET @TagId=(
SELECT TagId
FROM Tags
WHERE Tags.Name=@Name
)
INSERT INTO PostTags(BlogId,TagId)
VALUES(@BlogId,@TagId)





GO
/****** Object:  StoredProcedure [dbo].[DeleteBlogPost]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBlogPost]
(
@BlogId int
)AS
--Delete a Blog Post By Id

	Delete BlogPosts
	Where BlogId = @BlogId;



GO
/****** Object:  StoredProcedure [dbo].[DeleteMediaLink]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMediaLink]
(
@BlogId int,

@MediaLinkId int
)AS

Delete MediaLinks
	  WHERE MediaLinkId=@MediaLinkId




DELETE MediaLinksBlogs
		WHERE MediaLinksBlogs.BlogId=@BlogId AND MediaLinksBlogs.MediaLinkId=@MediaLinkId



GO
/****** Object:  StoredProcedure [dbo].[DeleteShow]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteShow] 
	-- Add the parameters for the stored procedure here
	@ShowId	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Shows where ShowId = @ShowId
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteStaticPage]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Delete Static Page

CREATE PROCEDURE [dbo].[DeleteStaticPage]
(
@PageId int

)AS

DELETE StaticPages
WHERE PageId=@PageId



GO
/****** Object:  StoredProcedure [dbo].[DeleteTag]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTag]
(
@BlogId int,

@TagId int
)AS

DELETE Tags
	  WHERE TagId=@TagId




DELETE PostTags

		WHERE PostTags.BlogId=@BlogId AND  PostTags.TagId=@TagId



GO
/****** Object:  StoredProcedure [dbo].[EditBlogPost]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditBlogPost]
(
@BlogId int,
--@AuthorId int, 
--@AuthorFirstName varchar(50),
--AuthorLastName varchar(50),
--@AuthorUserName varchar(50),
@BlogCatagory int,
@PostBody varchar(MAX),
@PostStatus int,
@PostTitle varchar(50),
@PostDate date

)AS
--Delete a Blog Post By Id
	--UPDATE Authors
	--SET FirstName=@AuthorFirstName,
	  --  LastName=@AuthorLastName,
		--UserName=@AuthorUserName
		--WHERE AuthorId=@AuthorId
		--UPDATE BlogPosts
		--SET Title=@PostTitle,
		--    PostDate=@PostDate,
		--	PostBody=@PostBody,
		--	CatagoryId=@BlogCatagory,
		--	StatusOfApproval=@PostStatus,
			--AuthorId=@AuthorId
			--WHERE BlogId=@BlogId

	
		UPDATE BlogPosts
		SET Title=@PostTitle,
		    PostDate=@PostDate,
			PostBody=@PostBody,
			CatagoryId=@BlogCatagory,
			StatusOfApproval=@PostStatus
		
			WHERE BlogId=@BlogId


GO
/****** Object:  StoredProcedure [dbo].[EditMediaLink]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditMediaLink]
(
@BlogId int,
@MediaType int,
@MediaLink varchar(MAX),
@MediaLinkId int
)AS

Update MediaLinks
      SET MediaLinkURL=@MediaLink,
      MediaType=@MediaType
	  WHERE MediaLinkId=@MediaLinkId




UPDATE MediaLinksBlogs
SET MediaLinkId=@MediaLinkId,
		BlogId=@BlogId
		WHERE MediaLinksBlogs.BlogId=@BlogId AND  MediaLinksBlogs.MediaLinkId=@MediaLinkId



GO
/****** Object:  StoredProcedure [dbo].[EditShow]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditShow] 
	-- Add the parameters for the stored procedure here
	@ShowId int,
	@Date date,
	@Venue varchar(50),
	@City varchar(50),
	@State varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Shows
		SET ShowDate=@Date,
		    VenueName=@Venue,
			City=@City,
			[State]=@State
		
			WHERE ShowId=@ShowId
END

GO
/****** Object:  StoredProcedure [dbo].[EditStaticPage]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Edit Static Page

CREATE PROCEDURE [dbo].[EditStaticPage]
(
@PageId int,
@Title varchar(50),
@PageBody varchar(MAX)
)AS
UPDATE StaticPages
SET  
Title=@Title,
PageBody=@PageBody
WHERE PageId=@PageId



GO
/****** Object:  StoredProcedure [dbo].[EditTag]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditTag]
(
@BlogId int,
@TagId int,
@Name int
)AS

UPDATE Tags
SET Name=@Name
WHERE TagId=@TagId

UPDATE PostTags
SET BlogId=@BlogId,
TagId=TagId







GO
/****** Object:  StoredProcedure [dbo].[PopulateAlbumTracks]    Script Date: 12/1/2016 2:17:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PopulateAlbumTracks](@AlbumId int)
AS
BEGIN
SELECT * FROM AlbumTrack WHERE @AlbumId = "AlbumId"
END


GO
USE [master]
GO
ALTER DATABASE [BATZ] SET  READ_WRITE 
GO
