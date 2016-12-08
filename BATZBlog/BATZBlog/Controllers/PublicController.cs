using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BATZBlog.BLL;
using BATZBlog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BATZBlog.Controllers
{
    public class PublicController : Controller
    {
        OperationsManager ops = new OperationsManager( );

        [HttpGet]
        public ActionResult HomePage( )
        {
            HomePageViewModel homePageVM = new HomePageViewModel( );

            // List<BlogPost> hello = new List<BlogPost>();

            // hello = ops.GetAllBlogPosts( );
            homePageVM.blogs = ops.GetAllBlogPosts( );
            homePageVM.blogs =
                        homePageVM.blogs.Where( b => b.StatusOfApproval == StatusOfApproval.Approved )
                                  .OrderByDescending( b => b.BlogId )
                                  .Take( 3 )
                                  .ToList( );

            //See below for a method to bypass going to the db to display the homepage image for testing purposes

            MediaLink homePageImage = new MediaLink( );
            homePageImage.LinkURL = @"/MediaFiles/Images/JaggedArrays.jpg";
            homePageImage.MediaType = MediaType.ImageLink;

            //Homepage is currently set to be the first item in the homepage table
            homePageVM.homeImage = homePageImage;
            // homePageVM.homeImage = ops.GetHomePageImage(1);

            homePageVM.TagCounts = new Dictionary<Tag, int>( );

            foreach(var tag in ops.GetAllTagsInUse( ))
            {
                int counter = ops.GetAllBlogPosts( ).Count( b => b.Tags.Any( t => t.TagId == tag.TagId ) );
                homePageVM.TagCounts.Add( tag, counter );
            }

            return View( homePageVM );
        }

        [HttpGet]
        public ActionResult ViewPost( int BlogId )
        {
            var blog = ops.GetBlogByID( BlogId );
            return View( blog );
        }

        [HttpGet]
        public PartialViewResult StaticLinksPartial( )
        {
            List<StaticPages> staticPages = new List<StaticPages>( );

            staticPages = ops.GetAllStaticPages( );

            staticPages = staticPages.OrderByDescending( s => s.PageId ).ToList( );

            return PartialView( staticPages );
        }

        [HttpGet]
        public ActionResult StaticPageDisplay( int PageId )
        {
            var staticPage = ops.GetStaticPageByID( PageId );

            return View( staticPage );
        }

        [HttpGet]
        public ActionResult DiscographyPage( )
        {
            var albums = ops.GetAllAlbums( ).OrderByDescending( a => a.ReleaseDate ).ToList( );

            return View( albums );
        }

        public ActionResult TourDates( )
        {
            var shows = ops.GetAllShows( ).OrderByDescending( s => s.ShowDate ).ToList( );

            return View( shows );
        }

        [HttpGet]
        public ActionResult SingleShowDisplay( int showId )
        {
            var show = ops.GetShowById( showId );

            return View( show );
        }

        public ActionResult ProductDisplay( )
        {
            var productViewModel = new ProductPageViewModel( );

            productViewModel.products = ops.GetAllProducts( );
            productViewModel.productCategories = ops.GetAllProductCategories( );

            return View( productViewModel );
        }

        public ActionResult ProductDetail( int ProductId )
        {
            var product = ops.GetProductById( ProductId );


            return View( product );
        }

        [HttpGet]
        public ActionResult OrderProduct( int ProductId )
        {
            var orderViewModel = new OrderViewModel( );
            var order = new Order( );
            var manager =
                        new UserManager<ApplicationUser>( new UserStore<ApplicationUser>( new ApplicationDbContext( ) ) );
            var currentUser = manager.FindById( User.Identity.GetUserId( ) );
            orderViewModel.order = order;
            if(User.IsInRole( "Admin" ) || User.IsInRole( "Customer" ) || User.IsInRole( "BandMember" ))
            {
                orderViewModel.order.CustomerFirstName = currentUser.FirstName;
                orderViewModel.order.CustomerLastName = currentUser.LastName;
            }

            orderViewModel.product = ops.GetProductById( ProductId );
            orderViewModel.order.Quantity = 1;

            return View(orderViewModel);
        }

        [HttpPost]
        public ActionResult OrderProduct( OrderViewModel orderViewModel )
        {
            var manager =
                        new UserManager<ApplicationUser>( new UserStore<ApplicationUser>( new ApplicationDbContext( ) ) );
            var currentUser = manager.FindById( User.Identity.GetUserId( ) );

            var order = orderViewModel.order;

            //Set the order details not filled in by a user
            order.OrderDate = DateTime.Now;
            order.ProductId = orderViewModel.product.ProductId;
            order.OrderStatus = OrderStatus.NotShipped;

            //if(User.IsInRole( "Admin" ) || User.IsInRole( "Customer" ) || User.IsInRole( "BandMember" ) ||
            //   User.IsInRole( "ContentWriter" ) && ( order.CustomerFirstName == null || order.CustomerLastName == null ))
            //{
            //    if(order.CustomerFirstName == null && order.CustomerLastName == null)

            if ((User.IsInRole("Admin") || User.IsInRole("Customer") || User.IsInRole("BandMember"))&&(order.CustomerFirstName==null ||order.CustomerLastName==null))

            {
                if(order.CustomerFirstName==null && order.CustomerLastName == null)
                {
                    order.CustomerFirstName = currentUser.FirstName;
                    order.CustomerLastName = currentUser.LastName;
                }
                else if(order.CustomerFirstName == null)
                {
                    order.CustomerFirstName = currentUser.FirstName;
                }
                else
                {
                    order.CustomerLastName = currentUser.LastName;
                }
            }

            if(ModelState.IsValid)
            {
                ops.AddOrder( order );

                //return RedirectToAction( "HomePage" );

                return RedirectToAction("OrderConfirmation", "Public", 
                    new {
                   
                  ProductName = orderViewModel.product.ProductName,
                  CustomerFirstName = orderViewModel.order.CustomerFirstName,
                  CustomerLastName = orderViewModel.order.CustomerLastName,
                   
                  CustomerState = orderViewModel.order.CustomerState
                    });
            }
           
            //return View( orderViewModel );

                return RedirectToAction("ProductDisplay", "Public", null);
        }

        public ActionResult ListofBlogPost( )
        {
            HomePageViewModel homePageVM = new HomePageViewModel( );

            // List<BlogPost> hello = new List<BlogPost>();

            // hello = ops.GetAllBlogPosts( );
            homePageVM.blogs = ops.GetAllBlogPosts( );
            homePageVM.blogs =
                        homePageVM.blogs.Where( b => b.StatusOfApproval == StatusOfApproval.Approved )
                                  .OrderByDescending( b => b.BlogId )
                                  .Take( 3 )
                                  .ToList( );

            //See below for a method to bypass going to the db to display the homepage image for testing purposes

            MediaLink homePageImage = new MediaLink( );
            homePageImage.LinkURL = @"/MediaFiles/Images/SteelPanther.jpg";
            homePageImage.MediaType = MediaType.ImageLink;

            //Homepage is currently set to be the first item in the homepage table
            homePageVM.homeImage = homePageImage;
            // homePageVM.homeImage = ops.GetHomePageImage(1);

            homePageVM.TagCounts = new Dictionary<Tag, int>( );

            foreach(var tag in ops.GetAllTagsInUse( ))
            {
                int counter = ops.GetAllBlogPosts( ).Count( b => b.Tags.Any( t => t.TagId == tag.TagId ) );
                homePageVM.TagCounts.Add( tag, counter );
            }


            return View( homePageVM );
        }

        public ActionResult UpcomingEventsPartial( )
        {
            var shows = ops.GetAllShows( );

            var currentShows = shows.Where( s => s.ShowDate > DateTime.Now ).ToList( );

            currentShows = currentShows.OrderBy( s => s.ShowDate ).Take( 3 ).ToList( );

            return PartialView( currentShows );
        }

        public ActionResult BlogPostCategoriesPartial( )
        {
            var categories = new List<Category>( );
            foreach(Category category in Enum.GetValues( typeof(Category) ))
            {
                categories.Add( category );
            }

            return PartialView( categories );
        }

        public ActionResult BlogPostsByCategory( Category catName )
        {
            var blogs = ops.GetAllBlogPosts( );
            blogs =
                        blogs.Where( b => b.StatusOfApproval == StatusOfApproval.Approved && b.Category == catName )
                             .OrderByDescending( b => b.BlogId )
                             .ToList( );

            return View( blogs );
        }

        public ActionResult GetAllTagsInuse( )
        {
            var tagsDictionary = new Dictionary<Tag, int>( );

            foreach(var tags in ops.GetAllTagsInUse( ))
            {
                int counter = ops.GetAllBlogPosts( ).Count( b => b.Tags.Any( t => t.TagId == tags.TagId ) );
                tagsDictionary.Add( tags, counter );
            }

            return PartialView( tagsDictionary );
        }

        public ActionResult GetBlogsByTag( int tagId )
        {
            var blogByTagViewModel = new BlogByTagViewModel( );

            var tag = ops.GetTagById( tagId );

            blogByTagViewModel.tagName = tag.Name;
            blogByTagViewModel.blogs =
                        ops.GetAllBlogPosts( ).Where( b => b.Tags.Any( t => t.TagId == tagId ) ).ToList( );


            return View( blogByTagViewModel );
        }
        public ActionResult OrderConfirmation(string ProductName,string CustomerFirstName,string CustomerLastName, string CustomerState)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.product = new Product();
            orderViewModel.order = new Order();

            orderViewModel.product.ProductName = ProductName;
    
            orderViewModel.order.CustomerFirstName = CustomerFirstName;
            orderViewModel.order.CustomerLastName = CustomerLastName;
          
            orderViewModel.order.CustomerState = CustomerState;
            return View(orderViewModel);
        }
    }
}