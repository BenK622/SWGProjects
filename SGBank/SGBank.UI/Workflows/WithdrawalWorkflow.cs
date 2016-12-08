using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class WithdrawalWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetAmountFromUser();
            ProcessWithdrawal(amount, account);
        }

        private decimal GetAmountFromUser()
        {
            decimal amount;

            bool isValid = false;

            do
            {
                Console.Write("Enter amount to withdraw: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out amount))
                {
                    if (amount <= 0)
                    {
                        Console.WriteLine("The amount must be greater than $0");
                        Console.WriteLine("Please provide a valid amount");
                        Console.ReadLine();
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid amount...");
                    Console.WriteLine("Please provide a valid amount");
                    Console.ReadLine();
                }
            } while (!isValid); 

            return amount;
        }

        private void ProcessWithdrawal(decimal amount, Account account)
        {
            var ops = new AccountOperations();
            var response = ops.MakeWithdrawal(account, amount);

            if (!response.Success)
            {
                Console.WriteLine("Error Occurred!!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move Along...");
                Console.ReadLine();
            }
        }
    }
}
