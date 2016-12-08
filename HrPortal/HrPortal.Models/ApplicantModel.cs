using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HrPortal.Models
{
    public class ApplicantModel
    {
        public int ApplicantID { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your phone number")]
        public string PhoneNumber { get; set; }
       
        //these will be set automatically
        public string JobAppliedFor { get; set; }
        //Could have some regex test here for server side validation 
        public string FilePath { get; set; }

    }
}
