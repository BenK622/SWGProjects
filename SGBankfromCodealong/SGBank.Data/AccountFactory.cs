using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public static class AccountFactory
    {
        public static IAccountRepository CreateAccountRepository()
        {
            IAccountRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemAccountRepository();
                    break;
                case "PROD":
                    repo = new FileAccountRepository();
                    break;
                default:
                    throw new Exception("I don't know that mode!");
            }

            return repo;
        }
    }
}
