using HrPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrPortal.Data;
using System.Web;
using System.IO;

namespace HrPortal.BLL
{
    public class Operations
    {
        public ApplicantResponse AddApplicant(ApplicantModel applicant, HttpPostedFileBase file)
        {
            var response = new ApplicantResponse();
            var repo = new ApplicantRepository();


            applicant.ApplicantID = GetApplicantID();
               

            var success = repo.AddApplicantToFile(applicant, file);

            if(success == true)
            {
                
                response.success = true;
                response.applicant = applicant;
            }

            return response;
        }


        private int GetApplicantID()
        {
            int applicantId;
            var repo = new ApplicantRepository();

            if(repo.GetAllApplicants().Count < 1)
            {
                applicantId = 1;
            }
            else
            {
                var lastApplicant = repo.GetAllApplicants().Last();
                applicantId = lastApplicant.ApplicantID + 1;
            }

            return applicantId;
        }

        public List<JobModel> GetAllJobs()
        {
            var repo = new JobRepository();
            var jobList = repo.GetAllJobs();

            return jobList;
        }

        public JobResponse GetJobByName(string name)
        {
            var repo = new JobRepository();
            var response = new JobResponse();

            var job = repo.GetJobByName(name);

            if(job == null)
            {
                response.success = false;
            }
            else
            {
                response.success = true;
                response.job = job;
            }

            return response;
        }

        public List<PolicyModel> GetPoliciesForCategory(string category)
        {
            PolicyRepository repo = new PolicyRepository();

            var policies = repo.GetPoliciesByCategory(category);

            return policies;
        }

        public List<CategoryModel> GetCategories()
        {
            var repo = new PolicyRepository();

            var categories = repo.GetAllCategories();

            return categories;
        }


    }
}
