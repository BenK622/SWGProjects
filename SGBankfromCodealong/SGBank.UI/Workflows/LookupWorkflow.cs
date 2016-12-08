using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class LookupWorkflow
    {
        public void Execute()
        {
            string accountNumber = GetAccountNumberFromUser();
            Execute(accountNumber);
        }

        public void Execute(string accountNumber)
        {
            var account = RetrieveAccountByNumber(accountNumber);

            if (account != null)
            {
                DisplayAccount(account);
            }
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
            var response = ops.GetAccount(accountNumber);
            if (response.Success)
            {
                return response.AccountInfo;
            }
            else
            {
                Console.WriteLine("Error Occurred!!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move Along...");
                Console.ReadLine();
            }

            return null;
        }

        private void DisplayAccount(Account account)
        {
            DisplayAccountMenu(account);
        }

        private void DisplayAccountInformation(Account account)
        {
            Console.Clear();
            Console.WriteLine("Account Information");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Person: {account.FirstName} {account.LastName}");
            Console.WriteLine($"Balance: {account.Balance:C}");
            Console.WriteLine();
        }

        private void DisplayAccountMenu(Account account)
        {
            string input = "";
            do
            {
                DisplayAccountInformation(account);

                Console.WriteLine("1. Withdrawal");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Update Account Info");
                Console.WriteLine("5. Close Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input, account);
                }
            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice, Account account)
        {
            switch (choice)
            {
                case "1":
                    WithdrawalWorkflow withdrawWF = new WithdrawalWorkflow();
                    withdrawWF.Execute(account);
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                    Console.WriteLine("This option is not implemented");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine($"{choice} is not valid!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }

            Execute(account.AccountNumber);
        }

    }
}