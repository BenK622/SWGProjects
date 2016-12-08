using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private const string FILENAME = @"DataFiles\accounts.txt";

        public Account GetAccountByNumber(string accountNumber)
        {
            var accounts = ReadFromFile();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public bool Withdrawal(Account account, decimal amountToWithdraw)
        {
            bool isSuccess = false;

            var accounts = ReadFromFile();
            var accountToChange = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);

            if (accountToChange != null)
            {
                accountToChange.Balance -= amountToWithdraw;
                WriteToFile(accounts);
                isSuccess = true;
            }

            return isSuccess;
        }

        public bool Deposit(Account account, decimal amountToDeposit)
        {
            bool isSuccessful = false;

            var accounts = ReadFromFile();

            var accountToChange = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);

            if(accountToChange != null)
            {
                accountToChange.Balance -= amountToDeposit;
                WriteToFile(accounts);
                isSuccessful = true;
            }
            return isSuccessful;
        }

        private List<Account> ReadFromFile()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";
                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    Account newAccount = new Account()
                    {
                        AccountNumber = inputParts[0],
                        Name = inputParts[1],
                        FirstName = inputParts[2],
                        LastName = inputParts[3],
                        Balance = decimal.Parse(inputParts[4])
                    };

                    accounts.Add(newAccount);
                }
            }

            return accounts;
        }

        private void WriteToFile(List<Account> accounts)
        {
            using (StreamWriter sw = new StreamWriter(FILENAME, false))
            {
                foreach (var account in accounts)
                {
                    sw.WriteLine($"{account.AccountNumber},{account.Name},{account.FirstName},{account.LastName},{account.Balance}");
                }
            }
        }
    }
}
