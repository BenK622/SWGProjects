using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Data.Factory;
using BATZBlog.Models;
using BATZBlog.Data.Interface;
using System.Web;

namespace BATZBlog.BLL
{
    public class OperationsManager
    {
        private IRepo _repo;

        public OperationsManager( )
        {
            _repo = Factory.CreateRepo();
        }

        /***************************************************************
        * Blog Post Section
        ***************************************************************/
        public List<BlogPost> GetAllBlogPosts()
        {
           return  _repo.GetAll();
        }

        public BlogPost GetBlogByID(int blogId)
        {
            return _repo.GetById(blogId);
        }

        public void Add(BlogPost blogPost)
        {
            _repo.Add(blogPost);
        }

        public void Edit(BlogPost blogPost)
        {
            _repo.Edit(blogPost);
        }

        public void Remove(int blogPostToRemove)
        {
            _repo.Remove(blogPostToRemove);
        }

        public MediaLink GetHomePageImage(int mediaId)
        {
           return _repo.GetHomePageMediaLink(mediaId);
        }

        public List<Tag> GetAllTagsInUse()
        {
            return _repo.GetAllTagesInUse();
        }

        public Tag GetTagById(int tagId)
        {
            return _repo.GetTagById(tagId);
        }

        /***************************************************************
        * Static Pages Section
        ***************************************************************/
        public List<StaticPages> GetAllStaticPages()
        {
            List<StaticPages> staticPages = new List<StaticPages>();

           staticPages = _repo.GetAllStaticPages();

            return staticPages;
        }

        public StaticPages GetStaticPageByID(int staticPageId)
        {
            StaticPages staticPage = new StaticPages();

            staticPage = _repo.GetStaticPageByID(staticPageId);

            return staticPage;
        }

        public void AddStaticPage(StaticPages staticPageToAdd)
        {
            _repo.AddStaticPage(staticPageToAdd);
            
        }

        public void EditStaticPage(StaticPages editedStaticPage)
        {
            _repo.EditStaticPage(editedStaticPage);
        }

        public void RemoveStaticPage(int staticPageToRemove)
        {
            _repo.RemoveStaticPage(staticPageToRemove);
        }


        /***************************************************************
        * Product Section
        ***************************************************************/

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return _repo.GetProductByID(productId);
        }

        public void AddProduct(Product product, HttpPostedFileBase file)
        {
            product.ProductImagePath = $@"\MediaFiles\Product_{product.ProductName}.jpg";

            var success = _repo.AddProduct(product, file);

        }

        public List<ProductCategory> GetAllProductCategories()
        {
            var productCategories = new List<ProductCategory>();

            foreach (ProductCategory productCategory in Enum.GetValues(typeof(ProductCategory)))
            {
                productCategories.Add(productCategory);
            }

            return productCategories;
            //return _repo.GetAllProductCategories();
        }

        public void AddOrder(Order order)
        {
            var success = _repo.AddOrder(order);
        }

        public void DeleteProduct(Product product)
        {

            var success = _repo.DeleteProduct(product);
        }

        public void EditProduct(Product product, HttpPostedFileBase file = null)
        {
            var success = _repo.EditProduct(product, file);
        }

        public List<Order> GetAllOrders()
        {
           return  _repo.GetAllOrders();
        }

        public OrderDashboard GetOrderDashboard()
        {
            return _repo.GetOrderDashboard();
        }

        public Order GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }

        public void EditOrderStatus(Order order)
        {
            _repo.EditOrderStatus(order);
        }

        /***************************************************************
        * Album Section
        ***************************************************************/
        public List<Album> GetAllAlbums()
        {
            return _repo.GetAllAlbums();
        }


        /***************************************************************
        * Show Section
        ***************************************************************/
        public List<Show> GetAllShows()
        {
            return _repo.GetAllShows();
        }

        public Show GetShowById(int showId)
        {
            return _repo.GetShowByID(showId);
        }

        public void AddShow(Show showToAdd)
        {
            _repo.AddShow(showToAdd);

        }

        public void EditShow(Show editedShow)
        {
            _repo.EditShow(editedShow);
        }

        public void RemoveShow(int showToRemove)
        {
            _repo.RemoveShow(showToRemove);
        }


    }
}