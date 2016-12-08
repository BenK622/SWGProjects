using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Models;
using System.Web;

namespace BATZBlog.Data.Interface
{
    public interface IRepo
    {

        void ResetDbTablesForTesting();
        /***************************************************************
        * Blog Page Section
        ***************************************************************/
        bool Add(BlogPost blogPost);

        Tag GetTagFromTagHolder(string tagHolder);

        List<BlogPost> GetAll();

        bool Remove(int BlogId);

        BlogPost GetById(int BlogId);

        bool Edit(BlogPost blogPost);

        //bool Delete(int blogPostId);

        List<Tag> GetAllTagesInUse();

        Tag GetTagById(int tagId);

        /***************************************************************
        * Static Page Section
        ***************************************************************/

        List<StaticPages> GetAllStaticPages();

        StaticPages GetStaticPageByID(int staticPageId);

        void AddStaticPage(StaticPages staticPageToAdd);

        void EditStaticPage(StaticPages editedStaticPage);

        void RemoveStaticPage(int staticPageToRemove);

        /***************************************************************
        * Albums Section
        ***************************************************************/

        List<Album> GetAllAlbums();
        


        /***************************************************************
        * Products Section
        ***************************************************************/

        List<Product> GetAllProducts();

        Product GetProductByID(int productId);

        bool AddProduct(Product product, HttpPostedFileBase file);

        bool DeleteProduct(Product product);

        bool EditProduct(Product editProduct, HttpPostedFileBase file = null);

        //List<ProductCategory> GetAllProductCategories();

        bool AddOrder(Order order);

        List<Order> GetAllOrders();

        OrderDashboard GetOrderDashboard();

        void EditOrderStatus(Order order);

        Order GetOrderById(int id);

        /***************************************************************
        * MediaLinks Section
        ***************************************************************/

        MediaLink GetHomePageMediaLink(int linkId);

        /***************************************************************
        * Shows Section
        ***************************************************************/
        List<Show> GetAllShows();

        Show GetShowByID(int showId);

        void AddShow(Show showToAdd);

        void EditShow(Show editedShow);

        void RemoveShow(int showToRemove);
    }
}
