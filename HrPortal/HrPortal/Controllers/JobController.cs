using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrPortal.BLL;
using HrPortal.Models;

namespace HrPortal.Controllers
{
    public class JobController : Controller
    {
        Operations ops = new Operations();
        
        // GET: Job
        public ActionResult Index()
        {
            var list = ops.GetAllJobs();

            return View(list);
        }

        [HttpGet]
        public ActionResult Apply(string JobName)
        {
            var jobApply = ops.GetJobByName(JobName);
    
            ApplicantVM applicantVM = new ApplicantVM() { job = jobApply.job };

            return View(applicantVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(ApplicantVM applicantVM, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                
                var jobResponse = ops.GetJobByName(applicantVM.job.JobName);

                applicantVM.applicant.JobAppliedFor = jobResponse.job.JobName;

                var applicantResponse = ops.AddApplicant(applicantVM.applicant, file);

                return RedirectToAction("ApplyConfirm");
            }
            else
            {
                return View(applicantVM);
            }
        }

        [HttpGet]
        public ActionResult ApplyConfirm(ApplicantResponse applicantResponse)
        {
            return View(applicantResponse);
        }



    }
}