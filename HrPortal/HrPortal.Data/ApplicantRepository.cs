using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrPortal.Models;
using System.Web;
using System.IO;

namespace HrPortal.Data
{
    public class ApplicantRepository
    {
        private string _fileName = "DataFiles/applicants.txt";

        public ApplicantRepository()
        {
            // This code solves the problem between web and local file system.
            if (HttpContext.Current != null)
            {
                _fileName = HttpContext.Current.Server.MapPath("~/" + _fileName);
            }
        }

        public bool AddApplicantToFile(ApplicantModel applicant, HttpPostedFileBase file)
        {
            
            var applicants = GetAllApplicants();

            var fileName = GetFileName(applicant);

            SaveResumeToData(file, fileName);

            applicant.FilePath = fileName;

            applicants.Add(applicant);

            WriteToFile(applicants);

            return true;
        }

        private void WriteToFile(List<ApplicantModel> applicants)
        {
            applicants = applicants.OrderBy(a => a.ApplicantID).ToList();
            using (var writer = new StreamWriter(_fileName, false))
            {
                writer.WriteLine("Id,FirstNAme,LastName,Email,PhoneNumber,Education,Job");

                foreach (ApplicantModel applicant in applicants)
                {
                    writer.WriteLine($"{applicant.ApplicantID},{applicant.FirstName},{applicant.LastName},{applicant.Email},{applicant.PhoneNumber},{applicant.JobAppliedFor},{applicant.FilePath}");
                }
            }
        }


        private string GetFileName(ApplicantModel applicant)
        {
            string fileName = $@"DataFiles/Resume_{applicant.FirstName + applicant.LastName + applicant.ApplicantID.ToString()}.txt";

            return fileName;
        }


        public List<ApplicantModel> GetAllApplicants()
        {
            List<ApplicantModel> applicants = new List<ApplicantModel>();

            if (File.Exists (_fileName))
            {
                using (var reader = File.OpenText(_fileName))
                {
                    //read the header line
                    reader.ReadLine();

                    string inputLine;
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        var columns = inputLine.Split(',');
                        var applicant = new ApplicantModel()
                        {
                            ApplicantID = int.Parse(columns[0]),
                            FirstName = columns[1],
                            LastName = columns[2],
                            Email = columns[3],
                            PhoneNumber = columns[4]

                        };

                        applicants.Add(applicant);
                    }
                }

               
            }
            return applicants;
        }

        public void SaveResumeToData(HttpPostedFileBase file, string fileName)
        {
            var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(" ") + fileName);
            file.SaveAs(filePath);

        }
    }
}

