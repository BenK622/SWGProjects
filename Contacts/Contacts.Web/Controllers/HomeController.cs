using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Data;
using Contacts.Models;

namespace Contacts.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repo = Factory.CreateContactRepository();
            var contacts = repo.GetAll();

            return View(contacts);
        }

        public ActionResult AddContact()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            var repo = Factory.CreateContactRepository();
            repo.Add(contact);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteContact()
        {
            int contactId = int.Parse(Request.Form["ContactId"]);

            var repo = Factory.CreateContactRepository();
            repo.Delete(contactId);

            return View("Index", repo.GetAll());
        }
    }
}