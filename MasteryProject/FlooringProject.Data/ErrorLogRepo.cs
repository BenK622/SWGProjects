using FlooringProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Data
{
    public class ErrorLogRepo
    {
        private const string FILENAME = @"DataFiles\Log.txt";

        public void WriteErrortoFile(ErrorModel error)
        {
            using (StreamWriter sw = new StreamWriter(FILENAME, true))
            {
                sw.WriteLine($"{error.date},{error.Message}");
            }
        }
    }
}
