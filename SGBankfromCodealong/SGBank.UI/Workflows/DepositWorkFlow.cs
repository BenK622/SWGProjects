using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class DepositWorkFlow
    {
        public void Execute()
        {
            decimal amount = GetUserDeposit();


        }

        private decimal GetUserDeposit()
        {
            Console.Write("Please enter the amount you would like to deposit");
            decimal amount = decimal Console.ReadLine();
        }
    }
}
