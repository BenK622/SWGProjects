using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrPortal.BLL;
using HrPortal.Models;

namespace HrPortal.Controllers
{
    public class PoliciesController : Controller
    {
        Operations ops = new Operations();

        // GET: Policies
        public ActionResult ViewPolicies()
        {

            return View();
        }

        [HttpGet]
        public ActionResult ManagePolicies()
        {
            CategoryVM categoryVM = new CategoryVM();

            categoryVM.SetCategoryItems(ops.GetCategories());


            return View(categoryVM);
        }
    }
}