using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class AccountFileRepository : IAccountRepository
    {
        private const string FILEPATH = @"DataFiles\Accounts.txt";

        public void AddAccount(Account account)
        {
            using (StreamWriter sr = new StreamWriter(FILEPATH, true))
            {
                sr.WriteLine(account.AccountNumber + "," + account.Name +"," + account.Balance);
            }
        }

        public bool Deposit(Account account, decimal amountToDeposit)
        {
            var isSuccessful = false;
            var source = GetAccountByNumber(account.AccountNumber);

            source.Balance += amountToDeposit;

            var accountList = ListAll();
            foreach (var acc in accountList.Where(a => a.AccountNumber == source.AccountNumber))
            {
                acc.Balance = source.Balance;
            }

          
           
            using (StreamWriter sw = new StreamWriter(FILEPATH))
            {
                foreach (var acc in accountList)
                {
                    sw.WriteLine(acc.AccountNumber + "," + acc.Name + "," + acc.Balance);
                }
                isSuccessful = true;
            }

            return isSuccessful;
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            var accountList = ListAll();

            var account = accountList.FirstOrDefault(a => a.AccountNumber == accountNumber);

            return account;
        }

        public List<Account> ListAll()
        {
            List <Account> accounts = new List<Account>();

            using (StreamReader sr = File.OpenText(FILEPATH))
            {
                string inputLine;

                while((inputLine = sr.ReadLine()) != null)
                {
                    var accountPieces = inputLine.Split(',');

                    var account = new Account();
                    account.AccountNumber = accountPieces[0];
                    account.Name = accountPieces[1];
                    account.Balance = int.Parse(accountPieces[2]);

                    accounts.Add(account);

                }
            }

            return accounts;
        }

        public bool Withdrawal(Account account, decimal amountToWithdraw)
        {
            bool isSuccessful = false;

            using(StreamReader sr = File.OpenText(FILEPATH))
            {
                string accountnum = account.AccountNumber;

            }

            return isSuccessful;
        }
    }
}
