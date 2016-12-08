using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class ApplicantResponse
    {
        public ApplicantModel applicant { get; set; }
        public bool success { get; set; }
    }
}
