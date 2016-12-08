USE BATZ
GO

/* Truncate Bridge tables testing */
DELETE FROM AlbumTrack
DELETE FROM PostTags
DELETE FROM ProductCategories


/* Truncate tables for testing */
DELETE FROM Categorys
DELETE FROM Orders
DELETE FROM Products
DELETE FROM Shows
DELETE FROM Albums
DELETE FROM Tags
DELETE FROM StaticPages
DELETE FROM BlogPosts


/* Populate tables for testing */
SET IDENTITY_INSERT [dbo].[Albums] ON 
INSERT [dbo].[Albums] ([AlbumId], [AlbumName], [ReleaseDate], [AlbumCoverImage]) VALUES (1, N'TestAlbum', CAST(N'2016-10-01' AS Date), N'/MediaFiles/AlbumCover1.jpg')
INSERT [dbo].[Albums] ([AlbumId], [AlbumName], [ReleaseDate], [AlbumCoverImage]) VALUES (5, N'Another Test Album', CAST(N'2015-10-01' AS Date), N'/MediaFiles/AlbumCover1.jpg')
SET IDENTITY_INSERT [dbo].[Albums] OFF 

SET IDENTITY_INSERT [dbo].[BlogPosts] ON 
INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorFirstName], [CatagoryId], [StatusofApproval], [AuthorLastName]) VALUES (11, N'New Album', CAST(N'2016-12-05' AS Date), N'<p>We have a new album thats coming out. Give it a listen you''ll really like it.&nbsp;</p>', N'Admin', 3, 1, N'Admin')
INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorFirstName], [CatagoryId], [StatusofApproval], [AuthorLastName]) VALUES (12, N'Upcoming Show!', CAST(N'2016-12-05' AS Date), N'<p>Bacon ipsum dolor amet hamburger meatloaf burgdoggen tail swine ham capicola andouille chuck strip steak shankle porchetta. Alcatra sausage kevin, jowl pancetta rump swine filet mignon. Fatback shoulder brisket biltong beef ribs short loin flank hamburger rump kevin jowl turkey bacon bresaola short ribs. Rump hamburger ham, beef t-bone landjaeger leberkas jowl salami ground round chuck.</p>
<p>&nbsp;</p>
<p>Pastrami ham biltong, pork belly beef brisket jowl tail ground round porchetta pork chop meatball tongue corned beef short loin. Andouille tongue pancetta strip steak meatloaf ham cow bacon kielbasa brisket alcatra bresaola capicola jerky. Bresaola tri-tip brisket, pork chop turkey chuck t-bone sausage sirloin flank fatback leberkas. Beef pancetta leberkas, pig bresaola jowl swine tri-tip flank shankle. Frankfurter capicola jowl, picanha spare ribs beef swine flank strip steak kevin brisket venison short ribs. Filet mignon sirloin leberkas andouille t-bone, pastrami swine short ribs meatloaf ground round prosciutto turducken chuck beef ribs.</p>', N'Admin', 1, 1, N'Admin')
INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorFirstName], [CatagoryId], [StatusofApproval], [AuthorLastName]) VALUES (13, N'New Product!', CAST(N'2016-12-05' AS Date), N'<p>We have an exciting new product in the store you should check out!</p>', N'Admin', 2, 1, N'Admin')
INSERT [dbo].[BlogPosts] ([BlogId], [Title], [PostDate], [PostBody], [AuthorFirstName], [CatagoryId], [StatusofApproval], [AuthorLastName]) VALUES (17, N'test post', CAST(N'2016-12-05' AS Date), N'<p>more test content on this post</p>', N'BandMember', 1, 3, N'BandMember')
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF

SET IDENTITY_INSERT [dbo].[Categorys] ON 
INSERT [dbo].[Categorys] ([CatagoryId], [CatagoryName]) VALUES (1, N'Posts')
SET IDENTITY_INSERT [dbo].[Categorys] OFF 

SET IDENTITY_INSERT [dbo].[Orders] ON 
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ProductId], [Quantity], [CustomerFirstName], [CustomerCity], [CustomerState], [CustomerLastName], [OrderStatus]) VALUES (1, CAST(N'2016-11-30' AS Date), 2, 2, N'Benjamin', N'Cleveland Heights', N'OH - Ohio', N'Kraus', 2)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ProductId], [Quantity], [CustomerFirstName], [CustomerCity], [CustomerState], [CustomerLastName], [OrderStatus]) VALUES (2, CAST(N'2016-12-05' AS Date), 2, 3, N'June', N'C hts', N'Oh ', N'bug', 1)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ProductId], [Quantity], [CustomerFirstName], [CustomerCity], [CustomerState], [CustomerLastName], [OrderStatus]) VALUES (4, CAST(N'2016-12-06' AS Date), 4, 2, N'June', N'Cleveland', N'Oh', N'Bug', 0)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ProductId], [Quantity], [CustomerFirstName], [CustomerCity], [CustomerState], [CustomerLastName], [OrderStatus]) VALUES (6, CAST(N'2016-11-15' AS Date), 5, 1, N'Tester', N'test', N'test', N'Testing', 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (2, N'Ryan Tshirt', N'Great T-shirt with ryans face. Great for frightening children', 15.0000, 1, N'/MediaFiles/Images/ryanface.jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (4, N'Jacob T-Shirt', N'Whoa who put this guy on a t-shirt. Great way to keep the ladies away', 15.0000, 1, N'/MediaFiles/Images/jacobface.jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId], [ProductImagePath]) VALUES (5, N'Album 1', N'Great album', 20.0000, 2, N'/MediaFiles/AlbumCover1.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Shows] ON
INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (2, N'Akron Civic', N'Akron', N'Ohio', CAST(N'2016-12-20' AS Date))
INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (3, N'NationWideArena', N'Columbus', N'ohio', CAST(N'2016-11-15' AS Date))
INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (4, N'The SoftwareGuild', N'Akron', N'Oh', CAST(N'2016-12-25' AS Date))
INSERT [dbo].[Shows] ([ShowId], [VenueName], [City], [State], [ShowDate]) VALUES (5, N'The Q', N'Cleveland', N'Oh', CAST(N'2016-12-20' AS Date))
SET IDENTITY_INSERT [dbo].[Shows] OFF

SET IDENTITY_INSERT [dbo].[StaticPages] ON
INSERT [dbo].[StaticPages] ([PageId], [Title], [PageBody]) VALUES (2, N'Upcoming Tour', N'<p>This is an upcoming tour&nbsp;</p>')
SET IDENTITY_INSERT [dbo].[StaticPages] OFF

SET IDENTITY_INSERT [dbo].[Tags] ON
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (1, N'work')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (2, N'please')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (3, N'p')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (4, N'b')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (5, N'a')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (6, N'b')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (7, N'a')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (8, N'c')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (9, N'band')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (10, N'batz')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (11, N'awesome')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (12, N'travellling')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (13, N'this')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (14, N'status')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (15, N'member')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (16, N'rules')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (17, N'cool')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (18, N'taggy')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (19, N'shows')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (20, N'music')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (21, N'album')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (22, N'newsongs')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (23, N'tag')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (24, N'dsf')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (25, N'sd')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (26, N'sdf')
INSERT [dbo].[Tags] ([TagId], [Name]) VALUES (27, N'show')
SET IDENTITY_INSERT [dbo].[Tags] OFF


/* Populate Bridge tables for testing */
SET IDENTITY_INSERT [dbo].[AlbumTrack] ON
INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (1, N'TestSong', 1, N'/MediaFiles/albumtTrack1.mp3')
INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (2, N'Tessssssst', 1, N'/MediaFiles/albumTrack2.mp3')
INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (6, N'Ashing in the BackSeat', 5, N'/MediaFiles/albumTrack2.mp3')
INSERT [dbo].[AlbumTrack] ([AlbumTrackId], [TrackName], [AlbumId], [TrackFilePath]) VALUES (9, N'Well, thats one way to do it', 5, N'/MediaFiles/albumTrack2.mp3')
SET IDENTITY_INSERT [dbo].[AlbumTrack] OFF

INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (11, 21)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (12, 19)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (12, 20)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (11, 22)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (13, 20)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (13, 21)
INSERT [dbo].[PostTags] ([BlogId], [TagId]) VALUES (17, 23)

SET IDENTITY_INSERT [dbo].[ProductCategories] ON
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductCategoryName]) VALUES (1, N'Clothing')
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductCategoryName]) VALUES (2, N'Albums')
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF