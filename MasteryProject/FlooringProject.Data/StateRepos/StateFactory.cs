using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FlooringProject.Data
{
    public static class StateFactory
    {
        public static IStateRepository CreateStateRepository()
        {
            IStateRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemStateRepository();
                    break;
                case "PROD":
                    repo = new FileStateRepository();
                    break;
                default:
                    throw new Exception("I don't know that mode!");
            }

            return repo;
        }
    }
}
