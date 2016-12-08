using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountOperations
    {
        public bool MakeWithdrawal(Account account, decimal amountToWithdraw)
        {
            var isSuccessful = false;

            var repo = AccountFactory.CreateAccountRepository();

            var source = repo.GetAccountByNumber(account.AccountNumber);
            if (source != null)
            {
                if (source.Balance >= amountToWithdraw)
                {
                    isSuccessful = repo.Withdrawal(source, amountToWithdraw);
                }
            }

            return isSuccessful;
        }

        public bool MakeDeposit(Account account, decimal amountToDeposit)
        {
            var isSuccessful = false;

            var repo = AccountFactory.CreateAccountRepository();

            var source = repo.GetAccountByNumber(account.AccountNumber);

            if(source != null)
            {
                if(amountToDeposit > 0)
                {
                    isSuccessful = repo.Deposit(source, amountToDeposit);
                }
            }

            return isSuccessful;
        }

        public bool OpenAccount(Account account)
        {
            bool isSuccessful = false;

            var repo = AccountFactory.CreateAccountRepository();

            repo.AddAccount(account);

            return isSuccessful;

        }

        
        public AccountResponse GetAccount(string accountNumber)
        {
            AccountResponse response = new AccountResponse();

            var repo = AccountFactory.CreateAccountRepository();

            var account = repo.GetAccountByNumber(accountNumber);

            if(account != null)
            {
                response.Success = true;
                response.AccountInfo = account;
            }
            else
            {
                response.Message = false;
                response.Message = $"No account found for account number: {accountNumber}";
            }
            return account;
        }
    }
}
