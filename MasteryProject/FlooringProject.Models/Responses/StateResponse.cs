using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Models
{
    public class StateResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public State State { get; set; }
    }
}
