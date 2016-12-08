using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Data.Repos
{
    public class ProdRepo : MockRepo
    {
        public ProdRepo() : base("ProdBATZ")
        {
        }

        //private override string _connectionString = ConfigurationManager.ConnectionStrings["ProdBATZ"].ConnectionString;
    }
}
