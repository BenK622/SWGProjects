﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Models.Responses
{
    public class ProductResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Product product { get; set; }
    }
}
