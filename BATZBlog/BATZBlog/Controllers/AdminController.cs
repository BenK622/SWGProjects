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
    public class AdminController : Controller
    {
        OperationsManager ops = new OperationsManager();

        /***************************************************************
        * Admin Home Section
        ***************************************************************/
        [HttpGet]
        [Authorize(Roles = "Admin, BandMember")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,  BandMember")]
        public ActionResult _AdminBlogPartialView()
        {
            var blogs = new List<BlogPost>();

            blogs = ops.GetAllBlogPosts().OrderByDescending(b => b.BlogId).ToList();

            return PartialView(blogs);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,  BandMember")]
        public ActionResult _AdminStaticPagePartialView()
        {
            var pages = new List<StaticPages>();

            pages = ops.GetAllStaticPages().OrderByDescending(p => p.PageId).ToList();

            return PartialView(pages);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, BandMember")]
        public ActionResult _AdminProductPagePartialView()
        {
            var products = ops.GetAllProducts();

            return PartialView(products);
        }

        [Authorize(Roles = "Admin, BandMember")]
        public ActionResult _AdminTourPagePartialView()
        {
            var tours = new List<Show>();

            tours = ops.GetAllShows().OrderByDescending(s => s.ShowDate).ToList();

            return PartialView(tours);

        }

        /***************************************************************
        * Blog Post Section
        ***************************************************************/
        [Authorize(Roles = "Admin, BandMember")]
        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(BlogPost postToAdd)
        {
            if (ModelState.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());

                if (User.IsInRole("Admin"))
                {

                    postToAdd.AuthorFirstName = currentUser.FirstName;
                    postToAdd.AuthorLastName = currentUser.LastName;
                    postToAdd.StatusOfApproval = StatusOfApproval.Approved;
                }
                else
                {
                    postToAdd.AuthorFirstName = currentUser.FirstName;
                    postToAdd.AuthorLastName = currentUser.LastName;
                    postToAdd.StatusOfApproval = StatusOfApproval.WaitingForApproval;
                }

                ops.Add(postToAdd);
                return RedirectToAction("Index", "Admin");
        }

            return View(postToAdd);

        }

        [HttpGet]
        [Authorize(Roles = "Admin, BandMember")]
        public ActionResult EditPost(int BlogId)
        {
            BlogPost postToEdit = ops.GetBlogByID(BlogId);

            // Need to convert all of the tag names into one string for the TagHolder property
            if (postToEdit.Tags != null)
            {
                foreach (var tag in postToEdit.Tags)
                {
                    postToEdit.TagHolder = $"{postToEdit.TagHolder},{tag.Name}";
                }
            }
            
            return View(postToEdit);
        }

        [HttpPost]
   
        public ActionResult EditPost(BlogPost editedBlogPost)
        {
            if (User.IsInRole("BandMember"))
            {
                editedBlogPost.StatusOfApproval = StatusOfApproval.WaitingForApproval;
            }
            //else
            //{
            //    editedBlogPost.StatusOfApproval = StatusOfApproval.WaitingForApproval;
            //}

            if (ModelState.IsValid)
            {
                ops.Edit(editedBlogPost);
                return RedirectToAction("Index", "Admin");
            }
            return View(editedBlogPost);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePost(int BlogId)
        {
            var post = ops.GetBlogByID(BlogId);
            return View(post);
        }

        [HttpPost]
        public ActionResult DeletePost(BlogPost postToDelete)
        {
            ops.Remove(postToDelete.BlogId);
            return RedirectToAction("Index", "Admin");
        }

        /***************************************************************
        * Static Page Section
        ***************************************************************/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddStaticPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaticPage(StaticPages staticPageToAdd)
        {
            if (ModelState.IsValid)
            {
                ops.AddStaticPage(staticPageToAdd);
                return RedirectToAction("Index", "Admin");
            }
            
            return View(staticPageToAdd);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditStaticPage(int PageId)
        {
            StaticPages staticPageToEdit = ops.GetStaticPageByID(PageId);
            return View(staticPageToEdit);
        }

        [HttpPost]
        public ActionResult EditStaticPage(StaticPages editedStaticPage)
        {
            if (ModelState.IsValid)
            {
                ops.EditStaticPage(editedStaticPage);
                return RedirectToAction("Index", "Admin");
            }

            return View(editedStaticPage);
            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteStaticPage(int PageId)
        {
            var page = ops.GetStaticPageByID(PageId);
            return View(page);
        }

        [HttpPost]
        public ActionResult DeleteStaticPage(StaticPages staticPageToDelete)
        {
            ops.RemoveStaticPage(staticPageToDelete.PageId);
            return RedirectToAction("Index", "Admin");
        }





        /***************************************************************
        * Product Section
        ***************************************************************/

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ops.AddProduct(product, file);

                return RedirectToAction("Index", "Admin");
            }

            return View(product);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int ProductId)
        {
            var product = ops.GetProductById(ProductId);
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            ops.DeleteProduct(product);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int ProductId)
        {
            var product = ops.GetProductById(ProductId);
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfOrders()
        {
            //var orderDashboard = ops.GetOrderDashboard();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult OrderDashboardDisplay()
        {
            var orderDashboard = ops.GetOrderDashboard();
            return View(orderDashboard);
        }


        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase file = null)
        {
            if (ModelState.IsValid)
            {
                ops.EditProduct(product, file);

                return RedirectToAction("Index", "Admin");
            }

            return View(product);
        }
        /***************************************************************
        * Tour/ Shows Section
        ***************************************************************/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddShow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShow(Show showToAdd)
        {
            if (ModelState.IsValid)
            {
                ops.AddShow(showToAdd);
                return RedirectToAction("Index", "Admin");
            }

            return View(showToAdd);

        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditShow(int ShowId)
        {
            var show = ops.GetShowById(ShowId);
            return View(show);
        }

        [HttpPost]
        public ActionResult EditShow(Show editedShow)
        {
            if (ModelState.IsValid)
            {
                ops.EditShow(editedShow);
                return RedirectToAction("Index", "Admin");
            }
            
            return View(editedShow);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteShow(int ShowId)
        {
            var show = ops.GetShowById(ShowId);
            return View(show);
        }

        [HttpPost]
        public ActionResult DeleteShow(Show showToDelete)
        {
            ops.RemoveShow(showToDelete.ShowId);
            return RedirectToAction("Index", "Admin");
        }
    }
}