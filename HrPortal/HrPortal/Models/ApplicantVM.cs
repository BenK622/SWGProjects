using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrPortal.Models
{
    public class ApplicantVM
    {
        public ApplicantModel  applicant { get; set; }
        public JobModel job { get; set; }
      //  public List<string> educationLevel { get; set; }
    }
}