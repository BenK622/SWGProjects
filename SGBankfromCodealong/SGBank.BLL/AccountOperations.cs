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
        public AccountResponse MakeWithdrawal(Account account, decimal amountToWithdraw)
        {
            AccountResponse response = new AccountResponse();

            var isSuccessful = false;

            var repo = AccountFactory.CreateAccountRepository();

            var source = repo.GetAccountByNumber(account.AccountNumber);
            if (source != null)
            {
                if (source.Balance >= amountToWithdraw)
                {
                    isSuccessful = repo.Withdrawal(source, amountToWithdraw);

                    if (isSuccessful)
                    {
                        response.Success = true;
                        response.AccountInfo = source;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Withdraw failed";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Not enough money in the account";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Could not find account";
            }

            return response;
        }

        public AccountResponse GetAccount(string accountNumber)
        {
            AccountResponse response = new AccountResponse();

            var repo = AccountFactory.CreateAccountRepository();
            var account = repo.GetAccountByNumber(accountNumber);

            if (account != null)
            {
                response.Success = true;
                response.AccountInfo = account;
            }
            else
            {
                response.Success = false;
                response.Message = $"No Account found for account number: {accountNumber}";
            }

            return response;
        }

        public AccountResponse MakeDeposit(Account account, decimal amountToDeposit)
        {
            var response = new AccountResponse();

            var isSuccessful = false; 

            var repo = AccountFactory.CreateAccountRepository();

            var source = repo.GetAccountByNumber(account.AccountNumber);

            if (source != null)
            {
                isSuccessful = repo.Deposit(account, amountToDeposit);

                if (isSuccessful)
                {
                    response.Success = true;
                    response.AccountInfo = source;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cant perform function";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "That account does not exist";
            }

            return response;
        }
    }
}
