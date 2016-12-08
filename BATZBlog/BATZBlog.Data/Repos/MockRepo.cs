using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Data.Interface;
using BATZBlog.Models;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Net.Configuration;

namespace BATZBlog.Data.Repos
{
    public class MockRepo : IRepo
    {
        private readonly string _connectionString;

        public MockRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BATZ"].ConnectionString;
        }

        public MockRepo(string connectionString)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        //Blog Post Section
        public bool Add( BlogPost blogPost )
        {
            if(blogPost.TagHolder != null)
            {
                string[] tagStrArr = blogPost.TagHolder.Split( ',' );
                blogPost.Tags = new List<Tag>( );
                foreach(var tagName in tagStrArr)
                {
                    // Get Tab from DB or create new tag and return that
                    var tag = GetTagFromTagHolder( tagName );

                    // Add to List of Tags in the BlogPost object
                    blogPost.Tags.Add( tag );
                }
            }

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddBlogPost";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"AuthorFirstName", blogPost.AuthorFirstName );
                cmd.Parameters.AddWithValue( @"AuthorLastName", blogPost.AuthorLastName );
                cmd.Parameters.AddWithValue( @"BlogCatagory", blogPost.Category );
                cmd.Parameters.AddWithValue( @"PostBody", blogPost.PostBody );
                cmd.Parameters.AddWithValue( @"PostStatus", blogPost.StatusOfApproval );
                cmd.Parameters.AddWithValue( @"PostTitle", blogPost.Title );
                cmd.Parameters.AddWithValue( @"PostDate", blogPost.PostDate );
                SqlParameter param = new SqlParameter( )
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = @"BlogId",
                    SourceColumn = "BlogId",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add( param );
                cmd.ExecuteNonQuery( );
                var newBlogId = int.Parse( param.Value.ToString( ) );

                if(blogPost.Tags != null)
                {
                    foreach(var tag in blogPost.Tags)
                    {
                        AddTagToBridgeTable( tag.TagId, newBlogId );



                    }
                }
            }

            return true;
        }

        private void AddTagToBridgeTable( int tagId, int newblogId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddTagToBridgeTable";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"TagId", tagId );
                cmd.Parameters.AddWithValue( @"BlogId", newblogId );

                cmd.ExecuteNonQuery( );
            }
        }

        public Tag GetTagFromTagHolder( string tagHolder )
        {
            Tag tag = GetTagByName( tagHolder );

            if(tag == null)
            {
                tag = new Tag { Name = tagHolder };
                AddTag( tag );
                tag = GetTagByName( tagHolder );
            }

            return tag;
        }

        public bool Edit( BlogPost blogPost )
        {
            DeleteTagFromBridgeTable( blogPost.BlogId );

            if(blogPost.TagHolder != null)
            {
                string[] tagStrArr = blogPost.TagHolder.Split( ',' );
                blogPost.Tags = new List<Tag>( );
                foreach(var tagName in tagStrArr)
                {
                    // Get Tab from DB or create new tag and return that
                    var tag = GetTagFromTagHolder( tagName );

                    // Add to List of Tags in the BlogPost object
                    blogPost.Tags.Add( tag );
                }
            }

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditBlogPost";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );
                cmd.Parameters.AddWithValue( @"BlogId", blogPost.BlogId );
                cmd.Parameters.AddWithValue( @"BlogCatagory", blogPost.Category );
                cmd.Parameters.AddWithValue( @"PostBody", blogPost.PostBody );
                cmd.Parameters.AddWithValue( @"PostStatus", blogPost.StatusOfApproval );
                cmd.Parameters.AddWithValue( @"PostTitle", blogPost.Title );
                cmd.Parameters.AddWithValue( @"PostDate", blogPost.PostDate );
                cmd.ExecuteNonQuery( );

                if(blogPost.Tags != null)
                {
                    foreach(var tag in blogPost.Tags)
                    {
                        AddTagToBridgeTable( tag.TagId, blogPost.BlogId );
                    }
                }
            }

            return true;
        }

        public List<BlogPost> GetAll( )
        {
            List<BlogPost> blogPosts = new List<BlogPost>( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );

                cmd.CommandText = @"SELECT B.BlogId,B.Title,B.PostBody,B.PostDate,B.StatusofApproval,B.CatagoryId, AuthorFirstName

									FROM BlogPosts B";

                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        blogPosts.Add( PopulateFromDataReader( dr ) );
                    }
                }
            }

            return blogPosts;
        }

        public BlogPost GetById( int blogId )
        {
            var allBlogPost = GetAll( );
            var blogPost = allBlogPost.FirstOrDefault( b => b.BlogId == blogId );
            return blogPost;
        }

        public bool Remove( int blogId )
        {
            // Remove entries from BlogPostTags bring table before removing the BlogPost
            DeleteTagFromBridgeTable( blogId );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteBlogPost";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );

                cmd.ExecuteNonQuery( );
            }

            return true;
        }

        private BlogPost PopulateFromDataReader( SqlDataReader dr )
        {
            BlogPost blogPost = new BlogPost( );
            blogPost.StatusOfApproval = new StatusOfApproval( );
            blogPost.Category = new Category( );

            blogPost.BlogId = (int) dr["BlogId"];
            blogPost.Title = dr["Title"].ToString( );
            blogPost.PostBody = dr["PostBody"].ToString( );
            blogPost.Tags = GetListOfTagsById( blogPost.BlogId );

            blogPost.AuthorFirstName = dr["AuthorFirstName"].ToString();

            if (dr["PostDate"] != DBNull.Value)

                blogPost.PostDate = (DateTime) dr["PostDate"];
            blogPost.StatusOfApproval = (StatusOfApproval) dr["StatusOfApproval"];
            blogPost.Category = (Category) dr["CatagoryId"];


            return blogPost;
        }

        public BlogPost GetBlogPostByID( int blogId )
        {
            var blogPosts = GetAll( );
            var specificPost = blogPosts.FirstOrDefault( b => b.BlogId == blogId );
            return specificPost;
        }

        //public bool Delete(int blogPostId)
        //{
        //    // Remove entries from BlogPostTags bring table before removing the BlogPost
        //    DeleteTagFromBridgeTable(blogPostId);

        //    using (var cn = new SqlConnection(_connectionString))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.CommandText = "DeleteBlogPost";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Connection = cn;
        //        cn.Open();

        //        cmd.Parameters.AddWithValue(@"BlogId", blogPostId);

        //        cmd.ExecuteNonQuery();

        //    }

        //    return true;
        //}
        /***************************************************************
                * Media Links Section
                ***************************************************************/

        private List<MediaLink> GetListOfMediaLinksById( int blogId )
        {
            List<MediaLink> listOfAllMediaLinks = getAllMediaLinks( );
            var specificList = listOfAllMediaLinks.FindAll( l => l.BlogId == blogId );
            return specificList;
        }

        private List<MediaLink> getAllMediaLinks( )
        {
            List<MediaLink> mediaLinks = new List<MediaLink>( );
            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"SELECT MLB.BlogId,M.MediaLinkId,M.MediaLinkURL,M.MediaType
									FROM MediaLinksBlogs MLB
									INNER JOIN MediaLinks M
									ON MLB.MediaLinkId=M.MediaLinkId";

                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        mediaLinks.Add( convertToMediaLink( dr ) );
                    }
                }
            }


            return mediaLinks;
        }

        //Getting homepage image from db- explicitly getting the row with Id 1
        public MediaLink GetHomePageMediaLink( int linkId )
        {
            MediaLink homePageImage = new MediaLink( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );

                cmd.CommandText = @"SELECT * FROM MediaLinks m WHERE m.MediaLinkId = '1'";

                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        homePageImage.LinkId = (int) dr["MediaLinkId"];
                        homePageImage.LinkURL = dr["MediaLinkURL"].ToString( );
                        ;
                        homePageImage.MediaType = (MediaType) dr["MediaType"];
                    }
                }
            }

            return homePageImage;
        }

        private MediaLink convertToMediaLink( SqlDataReader dr )
        {
            MediaLink link = new MediaLink( );
            link.BlogId = (int) dr["BlogId"];
            link.LinkId = (int) dr["MediaLinkId"];
            link.LinkURL = dr["MediaLinkURL"].ToString( );
            link.MediaType = (MediaType) dr["MediaType"];
            return link;
        }

        public void editMediaLink( MediaLink mediaLink, int blogId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditMediaLink";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );
                cmd.Parameters.AddWithValue( @"MediaType", mediaLink.MediaType );
                cmd.Parameters.AddWithValue( @"MediaLink", mediaLink.LinkURL );
                cmd.Parameters.AddWithValue( @"MediaLinkId", mediaLink.LinkId );
                cmd.ExecuteNonQuery( );
            }
        }

        public void AddMediaLink( MediaLink mediaLink, int blogId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddMediaLink";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );
                cmd.Parameters.AddWithValue( @"MediaType", mediaLink.MediaType );
                cmd.Parameters.AddWithValue( @"MediaLink", mediaLink.LinkURL );

                cmd.ExecuteNonQuery( );
            }
        }

        public void DeleteMediaLink( int mediaId, int blogId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteMediaLink";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );

                cmd.Parameters.AddWithValue( @"MediaLinkId", mediaId );

                cmd.ExecuteNonQuery( );
            }
        }

        /***************************************************************
                * Tags Section
                ***************************************************************/

        public List<Tag> GetListOfTagsById( int blogId )
        {
            List<Tag> tags = new List<Tag>( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText =
                            //@"select t.TagId, t.Name, t.Count from Tags t join PostTags p on t.TagId = p.TagId where p.BlogId = @BLOGID";
                            @"select t.TagId, t.Name from Tags t join PostTags p on t.TagId = p.TagId where p.BlogId = @BLOGID";
                cmd.Parameters.AddWithValue( @"BLOGID", blogId );
                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        tags.Add( convertToTag( dr ) );
                    }
                }
            }

            return tags;
        }

        public List<Tag> GetAllTags( )
        {
            List<Tag> tags = new List<Tag>( );
            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"select * from Tags";
                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        tags.Add( convertToTag( dr ) );
                    }
                }
            }

            return tags;
        }

        public Tag GetTagByName( string name )
        {
            return GetAllTags( ).FirstOrDefault( t => t.Name == name );
        }

        public Tag convertToTag( SqlDataReader dr )
        {
            Tag tag = new Tag( );
            tag.Name = dr["Name"].ToString( );
            tag.TagId = (int) dr["TagId"];
            return tag;
        }

        public void AddTag( Tag tag )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddTag";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"Name", tag.Name );

                cmd.ExecuteNonQuery( );
            }
        }

        public void DeleteTag( int blogId, int tagId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteTag";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );
                cmd.Parameters.AddWithValue( @"TagId", tagId );

                cmd.ExecuteNonQuery( );
            }
        }

        // This will delete all entries from the PostTags table based on a given blog post id
        private void DeleteTagFromBridgeTable( int blogId )
        {
            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"DELETE FROM PostTags WHERE BlogId = @BLOGID";
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BLOGID", blogId );

                cmd.ExecuteNonQuery( );
            }
        }

        private void EditTag( Tag t, int blogId )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditTag";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"BlogId", blogId );
                cmd.Parameters.AddWithValue( @"Name", t.Name );
                cmd.Parameters.AddWithValue( @"TagId", t );

                cmd.ExecuteNonQuery( );
            }
        }

        public List<Tag> GetAllTagesInUse( )
        {
            List<Tag> tags = new List<Tag>( );
            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"SELECT DISTINCT Tags.TagId, Tags.Name, Count(PostTags.TagId) AS TimesInUse FROM Tags
									Inner Join PostTags ON PostTags.TagId = Tags.TagId
									GROUP BY Tags.TagId, Tags.Name
									ORDER BY TimesInUse DESC";
                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        tags.Add( convertToTag( dr ) );
                    }
                }
            }

            return tags;
        }

        public Tag GetTagById( int tagId )
        {
            return GetAllTags( ).FirstOrDefault( t => t.TagId == tagId );
        }

        /***************************************************************
                * Static Pages Section
                ***************************************************************/

        public List<StaticPages> GetAllStaticPages( )
        {
            List<StaticPages> staticPages = new List<StaticPages>( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"Select * FROM StaticPages";

                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        staticPages.Add( convertToStaticPage( dr ) );
                    }
                }
            }

            return staticPages;
        }

        public StaticPages GetStaticPageByID( int staticPageId )
        {
            var staticpage = GetAllStaticPages( ).FirstOrDefault( s => s.PageId == staticPageId );
            return staticpage;
        }

        public void AddStaticPage( StaticPages staticPageToAdd )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddStaticPage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"Title", staticPageToAdd.Title );
                cmd.Parameters.AddWithValue( @"PageBody", staticPageToAdd.PageBody );


                cmd.ExecuteNonQuery( );
            }
        }

        public void EditStaticPage( StaticPages editedStaticPage )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditStaticPage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"PageId", editedStaticPage.PageId );
                cmd.Parameters.AddWithValue( @"Title", editedStaticPage.Title );
                cmd.Parameters.AddWithValue( @"PageBody", editedStaticPage.PageBody );


                cmd.ExecuteNonQuery( );
            }
        }

        public void RemoveStaticPage( int staticPageToRemove )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteStaticPage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"PageId", staticPageToRemove );


                cmd.ExecuteNonQuery( );
            }
        }

        private StaticPages convertToStaticPage( SqlDataReader dr )
        {
            StaticPages staticPage = new StaticPages( )
            {
                PageBody = dr["PageBody"].ToString( ),
                PageId = (int) dr["PageID"],
                Title = dr["Title"].ToString( )
            };

            return staticPage;
        }

        /***************************************************************
        *                       Album Section
        ***************************************************************/

        public List<Album> GetAllAlbums( )
        {
            List<Album> albums = new List<Album>( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"Select * FROM Albums";

                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        albums.Add( convertToAlbum( dr ) );
                    }
                }
            }

            return albums;
        }

        private Album convertToAlbum( SqlDataReader dr )
        {
            var album = new Album( )
            {
                AlbumId = (int) dr["AlbumId"],
                AlbumName = dr["AlbumName"].ToString( ),
                AlbumCoverImage = dr["AlbumCoverImage"].ToString( ),
                ReleaseDate = (DateTime) dr["ReleaseDate"],
                Tracks = new List<AlbumTrack>( )
            };

            //Populate Track list here
            album.Tracks = PopulateAlbumTracks( album.AlbumId );

            return album;
        }

        private List<AlbumTrack> PopulateAlbumTracks( int albumId )
        {
            List<AlbumTrack> tracks = new List<AlbumTrack>( );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "PopulateAlbumTracks";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );


                cmd.Parameters.AddWithValue( @"AlbumId", albumId );

                cmd.ExecuteNonQuery( );


                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        tracks.Add( convertToTrack( dr ) );
                    }
                }
            }

            return tracks;
        }

        private AlbumTrack convertToTrack( SqlDataReader dr )
        {
            var track = new AlbumTrack( )
            {
                AlbumTrackId = (int) dr["AlbumTrackId"],
                TrackName = dr["TrackName"].ToString( ),
                TrackFilePath = dr["TrackFilePath"].ToString( )
            };

            return track;
        }

        /***************************************************************
                *                       Show Section
                ***************************************************************/

        public List<Show> GetAllShows( )
        {
            List<Show> shows = new List<Show>( );

            using(SqlConnection cn = new SqlConnection( _connectionString ))
            {
                SqlCommand cmd = new SqlCommand( );
                cmd.CommandText = @"Select * FROM Shows";

                cmd.Connection = cn;
                cn.Open( );

                using(SqlDataReader dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        shows.Add( convertToShow( dr ) );
                    }
                }
            }

            return shows;
        }

        public Show GetShowByID( int showId )
        {
            var show = GetAllShows( ).FirstOrDefault( s => s.ShowId == showId );
            return show;
        }

        public void AddShow( Show showToAdd )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddShow";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"Date", showToAdd.ShowDate );
                cmd.Parameters.AddWithValue( @"Venue", showToAdd.VenueName );
                cmd.Parameters.AddWithValue( @"City", showToAdd.City );
                cmd.Parameters.AddWithValue( @"State", showToAdd.State );

                cmd.ExecuteNonQuery( );
            }
        }

        public void EditShow( Show editedShow )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditShow";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"Date", editedShow.ShowDate );
                cmd.Parameters.AddWithValue( @"Venue", editedShow.VenueName );
                cmd.Parameters.AddWithValue( @"City", editedShow.City );
                cmd.Parameters.AddWithValue( @"State", editedShow.State );
                cmd.Parameters.AddWithValue( @"ShowId", editedShow.ShowId );

                cmd.ExecuteNonQuery( );
            }
        }

        public void RemoveShow( int showToRemove )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteShow";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"ShowId", showToRemove );

                cmd.ExecuteNonQuery( );
            }
        }

        private Show convertToShow( SqlDataReader dr )
        {
            var show = new Show( )
            {
                ShowId = (int) dr["ShowId"],
                ShowDate = (DateTime) dr["ShowDate"],
                City = dr["City"].ToString( ),
                State = dr["State"].ToString( ),
                VenueName = dr["VenueName"].ToString( )
            };

            return show;
        }

        /***************************************************************
                *                       Products/Orders Section
                ***************************************************************/

        public List<Product> GetAllProducts( )
        {
            List<Product> products = new List<Product>( );
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = @"SELECT * FROM Products";

                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        var product = new Product( );

                        product = ConvertToProduct( dr );

                        products.Add( product );
                    }
                }
            }

            return products;
        }

        private Product ConvertToProduct( SqlDataReader dr )
        {
            var product = new Product( )
            {
                ProductId = (int) dr["ProductId"],
                ProductName = dr["ProductName"].ToString( ),
                ProductDescription = dr["ProductDescription"].ToString( ),
                Price = (decimal) dr["Price"],
                ProductCategory = (ProductCategory) dr["CategoryId"],
                ProductImagePath = dr["ProductImagePath"].ToString( )
            };

            return product;
        }

        public Product GetProductByID( int productId )
        {
            var products = GetAllProducts( );

            return products.FirstOrDefault( m => m.ProductId == productId );
        }

        public void SavePictureToData( HttpPostedFileBase file, string fileName )
        {
            var filePath = Path.Combine( System.Web.HttpContext.Current.Server.MapPath( " " ) + fileName );

            filePath = filePath.Replace( "\\Admin", string.Empty );

            file.SaveAs( filePath );
        }

        public bool AddProduct( Product product, HttpPostedFileBase file )
        {
            SavePictureToData( file, product.ProductImagePath );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"ProductId", product.ProductId );
                cmd.Parameters.AddWithValue( @"ProductName", product.ProductName );
                cmd.Parameters.AddWithValue( @"ProductDescription", product.ProductDescription );
                cmd.Parameters.AddWithValue( @"Price", product.Price );
                cmd.Parameters.AddWithValue( @"CategoryId", product.ProductCategory );
                cmd.Parameters.AddWithValue( @"ProductImagePath", product.ProductImagePath );


                cmd.ExecuteNonQuery( );
            }

            return true;
        }

        public bool DeleteProduct( Product product )
        {
            DeleteFile( product.ProductImagePath );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "DeleteProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"ProductId", product.ProductId );

                cmd.ExecuteNonQuery( );
            }

            return true;
        }

        private void DeleteFile( string productImagePath )
        {
            var filePath = Path.Combine( System.Web.HttpContext.Current.Server.MapPath( " " ) + productImagePath );
            filePath = filePath.Replace( "\\Admin", string.Empty );
            File.Delete( filePath );
        }

        public bool EditProduct( Product editProduct, HttpPostedFileBase file = null )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"ProductId", editProduct.ProductId );
                cmd.Parameters.AddWithValue( @"ProductName", editProduct.ProductName );
                cmd.Parameters.AddWithValue( @"ProductDescription", editProduct.ProductDescription );
                cmd.Parameters.AddWithValue( @"Price", editProduct.Price );
                cmd.Parameters.AddWithValue( @"CategoryId", editProduct.ProductCategory );
                cmd.Parameters.AddWithValue( @"ProductImagePath", editProduct.ProductImagePath );


                cmd.ExecuteNonQuery( );
            }

            //Delete old file and replace with new one if they uploaded a file
            if(file != null)
            {
                var oldProduct = GetProductByID( editProduct.ProductId );

                DeleteFile( oldProduct.ProductImagePath );

                SavePictureToData( file, editProduct.ProductImagePath );
            }

            return true;
        }

        //public List<ProductCategory> GetAllProductCategories()
        //{
        //    List<ProductCategory> productCategories = new List<ProductCategory>();
        //    using (var cn = new SqlConnection(_connectionString))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.CommandText = @"SELECT * FROM ProductCategories";

        //        cmd.Connection = cn;
        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                var productCategory = new ProductCategory();

        //                productCategory = ConvertToProductCategory(dr);

        //                productCategories.Add(productCategory);
        //            }
        //        }
        //    }

        //    return productCategories;
        //}

        //private ProductCategory ConvertToProductCategory(SqlDataReader dr)
        //{
        //    var productCategory = new ProductCategory()
        //    {
        //        ProductCategoryId = (int)dr["ProductCategoryId"],
        //        ProductCategoryName = dr["ProductCategoryName"].ToString()

        //    };

        //    return productCategory;
        //}
        public bool AddOrder( Order order )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "AddProductOrder";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"OrderDate", order.OrderDate );
                cmd.Parameters.AddWithValue( @"ProductId", order.ProductId );
                cmd.Parameters.AddWithValue( @"Quantity", order.Quantity );
                cmd.Parameters.AddWithValue( @"CustomerFirstName", order.CustomerFirstName );
                cmd.Parameters.AddWithValue( @"CustomerLastName", order.CustomerLastName );
                cmd.Parameters.AddWithValue( @"CustomerCity", order.CustomerCity );
                cmd.Parameters.AddWithValue( @"CustomerState", order.CustomerState );
                cmd.Parameters.AddWithValue( @"OrderStatus", order.OrderStatus );

                cmd.ExecuteNonQuery( );
            }

            return true;
        }

        public List<Order> GetAllOrders( )
        {
            List<Order> orders = new List<Order>( );
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = @"SELECT * FROM Orders";

                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        var order = new Order( );

                        order = ConvertToOrder( dr );

                        orders.Add( order );
                    }
                }
            }

            return orders;
        }

        private Order ConvertToOrder( SqlDataReader dr )
        {
            var order = new Order( )
            {
                OrderId = (int) dr["OrderId"],
                OrderDate = (DateTime) dr["OrderDate"],
                ProductId = (int) dr["ProductId"],
                CustomerCity = dr["CustomerCity"].ToString( ),
                CustomerFirstName = dr["CustomerFirstName"].ToString( ),
                CustomerLastName = dr["CustomerLastName"].ToString( ),
                CustomerState = dr["CustomerState"].ToString( ),
                Quantity = (int) dr["Quantity"],
                OrderStatus = (OrderStatus) dr["OrderStatus"]
            };

            return order;
        }

        public Order GetOrderById( int id )
        {
            var orders = GetAllOrders( );

            return orders.FirstOrDefault( o => o.OrderId == id );
        }

        public void EditOrderStatus( Order order )
        {
            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "EditOrderStatus";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                cmd.Parameters.AddWithValue( @"OrderId", order.OrderId );
                cmd.Parameters.AddWithValue( @"OrderStatus", order.OrderStatus );


                cmd.ExecuteNonQuery( );
            }
        }

        public OrderDashboard GetOrderDashboard( )
        {
            OrderDashboard orderDashboard = new OrderDashboard( )
            {
                //TotalSales = GetTotalSales( ),
                SalesByCategory = GetSalesByCategory( ),
                SalesByItem = GetSalesByItem( ),
                SalesByMonthYear = GetSalesByMonthYear( ),
            };

            return orderDashboard;
        }

        private Dictionary<string, int> GetSalesByMonthYear( )
        {
            Dictionary<string, int> salesByMonthYear = new Dictionary<string, int>( );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "SalesByMonthYear";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        salesByMonthYear.Add( (dr["SalesMonth"].ToString( ) + "-" + dr["SalesYear"].ToString()) , Convert.ToInt32( (decimal) dr["MoneyMade"] ) );
                    }
                }
            }

            return salesByMonthYear;
        }

        private Dictionary<string, int> GetSalesByItem( )
        {
            Dictionary<string, int> salesByItem = new Dictionary<string, int>( );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "SalesByItem";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        salesByItem.Add( dr["ProductName"].ToString( ), Convert.ToInt32( (decimal) dr["MoneyMade"] ) );
                    }
                }
            }

            return salesByItem;
        }

        private Dictionary<ProductCategory, int> GetSalesByCategory( )
        {
            Dictionary<ProductCategory, int> salesByCat = new Dictionary<ProductCategory, int>( );

            using(var cn = new SqlConnection( _connectionString ))
            {
                var cmd = new SqlCommand( );
                cmd.CommandText = "SalesByCategory";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open( );

                using(var dr = cmd.ExecuteReader( ))
                {
                    while (dr.Read( ))
                    {
                        salesByCat.Add( (ProductCategory) dr["ProductCategory"],
                                        Convert.ToInt32( (decimal) dr["MoneyMade"] ) );
                    }
                }
            }

            return salesByCat;
        }

        //private int GetTotalSales( )
        //{
        //    int totalSales = 0;

        //    using(var cn = new SqlConnection( _connectionString ))
        //    {
        //        var cmd = new SqlCommand( );
        //        cmd.CommandText = "TotalSales";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Connection = cn;
        //        cn.Open( );

        //        using(var dr = cmd.ExecuteReader( ))
        //        {
        //            while (dr.Read( ))
        //            {
        //                totalSales = Convert.ToInt32( (decimal) dr["TotalSales"] );
        //            }
        //        }
        //    }

        //    return totalSales;
        //}


         public void ResetDbTablesForTesting()
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "ResetTablesForTesting";

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    } //end of class
} // end of namespace




