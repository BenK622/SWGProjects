using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class InMemAccountRepository : IAccountRepository
    {
        private static List<Account> _accounts;

        public InMemAccountRepository()
        {
            if(_accounts == null)
            {
                _accounts = new List<Account>()
                {
                    new Account() {AccountNumber = "123456", Name="Checking", Balance= 1234.56m, FirstName="Victor", LastName="Pudelski" },
                    new Account() {AccountNumber = "234567", Name="Savings", Balance= 1.99m, FirstName="Randall", LastName="Clapper" },
                    new Account() {AccountNumber = "345678", Name="Whatever", Balance= 4321543.99m, FirstName="Sarah", LastName="Dutkiewicz" },
                    new Account() {AccountNumber = "456789", Name="Another", Balance= 32178.56m, FirstName="Dave", LastName="Balzer" }
                };
            }
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public bool Deposit(Account account, decimal amountToDeposit)
        {
            bool isSuccessful = false;

            var source = GetAccountByNumber(account.AccountNumber);

            if(source != null)
            {
                source.Balance += amountToDeposit;
                isSuccessful = true;
            }

            return isSuccessful;
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<Account> ListAll()
        {
            throw new NotImplementedException();
        }

        public bool Withdrawal(Account account, decimal amountToWithdraw)
        {
            bool isSuccessful = false;

            var source = GetAccountByNumber(account.AccountNumber);
            if (source != null)
            {
                source.Balance -= amountToWithdraw;
                isSuccessful = true;
            }

            return isSuccessful;
        }
    }
}
