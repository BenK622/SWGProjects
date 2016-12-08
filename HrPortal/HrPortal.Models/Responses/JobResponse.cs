using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class JobResponse
    {
        public JobModel job { get; set; }
        public bool success { get; set; }
    }
}
