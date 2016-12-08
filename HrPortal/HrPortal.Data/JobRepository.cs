using HrPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HrPortal.Data
{
    public class JobRepository
    {

        private string _fileName = "DataFiles/jobs.txt";

        public JobRepository()
        {
            // This code solves the problem between web and local file system.
            if (HttpContext.Current != null)
            {
                _fileName = HttpContext.Current.Server.MapPath("~/" + _fileName);
            }
        }

        public List<JobModel> GetAllJobs()
        {
            List<JobModel> jobs = new List<JobModel>();

            using (StreamReader sr = File.OpenText(_fileName))
            {
                string inputLine = "";

                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    JobModel job  = new JobModel()
                    {
                        JobID = inputParts[0],
                        JobName = inputParts[1],
                        JobDescription = inputParts[2]

                    };

                    jobs.Add(job);
                }

            }

            return jobs;
        }

        public JobModel GetJobByName(string jobName)
        {
            var repo = new JobRepository();

            var jobList = repo.GetAllJobs();

            var job = jobList.Where(j => j.JobName == jobName).First();

            return job;
        }

        
    }
}
