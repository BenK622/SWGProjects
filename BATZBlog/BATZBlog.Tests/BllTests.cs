using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Models;
using BATZBlog.Tests;
using NUnit.Framework;
using BATZBlog.BLL;
using BATZBlog.Data;
using BATZBlog.Data.Factory;

namespace BATZBlog.Tests
{
    [TestFixture]
    public class BllTests
    {
        /*Testing Parameters:
         * There are 4 blog posts
         * There are 4 orders
         * There are 3 products
         * There are 4 shows
         * There is 1 user generated static page
         * */
        OperationsManager ops = new OperationsManager();
        Factory _repo = new Factory();
        //Object For testing Posts 
        BlogPost post = new BlogPost()
        {
            AuthorFirstName = "test",
            AuthorLastName = "test",
            Category = Category.Misc,
            PostBody = "This is a test only a test",
            PostDate = DateTime.Now,
            StatusOfApproval = StatusOfApproval.Approved,
            TagHolder = "tag,testtag",
            Tags = new List<Tag>(),
            Title = "test"


        };

        Order order = new Order()
        {
            CustomerFirstName = "Test",
            CustomerLastName = "Test",
            CustomerCity = "test",
            CustomerState = "test",
            OrderDate = DateTime.Now,
            OrderStatus = OrderStatus.NotShipped,
            ProductId = 2,
            Quantity = 2

        };

        [Test]
        public void TestGetAllPosts()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();
            var posts = _repo.GetAll();
            Assert.AreEqual(4, posts.Count);
        }

        [Test]
        public void TestGetAllShows()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();
            var shows = _repo.GetAllShows();
            Assert.AreEqual(4, shows.Count);
        }

        [Test]
        public void TestGetAllOrders()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();
            var orders = _repo.GetAllShows();
            Assert.AreEqual(4, orders.Count);
        }


        [Test]
        public void TestAddPost()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();
            ops.Add(post);
            var posts = _repo.GetAll();
            Assert.AreEqual(5, posts.Count);
        }

        [Test]
        public void TestDeletePost()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();


            var post = _repo.GetAll().Take(1).First();
            ops.Remove(post.BlogId);
            
            var posts = _repo.GetAll();

            Assert.AreEqual(3, posts.Count);
        }

        [Test]
        public void TestAddOrder()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();
            ops.AddOrder(order);
          
            var orders  = _repo.GetAllOrders();

            Assert.AreEqual(5, orders.Count);
        }

        [Test]
        public void TestAddStaticPage()
        {
            var staticPage = new StaticPages()
            {
                PageBody = "Test teest te te df s",
                Title = "Test"
            };

            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();

            ops.AddStaticPage(staticPage);
            var pages = _repo.GetAllStaticPages();

            Assert.AreEqual(2, pages.Count);
        }

        [Test]
        public void TestDeleteStaticPage()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();

            var page = _repo.GetAllStaticPages().Take(1).First();

            ops.RemoveStaticPage(page.PageId);
            var pages = _repo.GetAllStaticPages();

            Assert.AreEqual(0, pages.Count);
        }

        [Test]
        public void TestAddShow()
        {
            var show = new Show()
            {
                City = "TestCity",
                ShowDate = DateTime.Now,
                State = "test",
                VenueName = "testvenue"
            };

            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();

            ops.AddShow(show);
            
            var shows = _repo.GetAllShows();

            Assert.AreEqual(5, shows.Count);

        }

        [Test]
        public void DeleteShow()
        {
            var _repo = Factory.CreateRepo();
            _repo.ResetDbTablesForTesting();

            var show = _repo.GetAllShows().Take(1).First();
            ops.RemoveShow(show.ShowId);
            var shows = _repo.GetAllShows();

            Assert.AreEqual(3, shows.Count);

        }





    }
}
