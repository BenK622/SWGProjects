using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Data.Interface;
using BATZBlog.Data.Repos;

namespace BATZBlog.Data.Factory
{
    public class Factory
    {
        public static IRepo CreateRepo()
        {
            IRepo repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToUpper();
            switch (mode)
            {
                case "TEST":
                    repo = new MockRepo();
                    break;
                case "PROD":
                    repo = new ProdRepo();
                    break;
                default:
                    throw new NotImplementedException( );
            }

            return repo;
        }
    }
}