using SGBank.BLL;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class AppWorkFlow
    {

        public void Execute()
        {
            string accountNumber = GetAccountNumberFromUser();
        }

        private string GetAccountNumberFromUser()
        {
            string accountNumber = "";

            Console.Clear();
            Console.Write("Enter an Account Number: ");
            accountNumber = Console.ReadLine();

            return accountNumber;

        }

        private Account RetrieveAccountByNumber(string accountNumber)
        {
            var ops = new AccountOperations();

            
        }
    }
}
