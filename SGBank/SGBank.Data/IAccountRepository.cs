using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public interface IAccountRepository
    {
        /// <summary>
        /// get the account by the designated number
        /// </summary>
        /// <param name="accountNumber">account number to retrieve</param>
        /// <returns>account object representing the number</returns>
        Account GetAccountByNumber(string accountNumber);

        /// <summary>
        /// take money from the account
        /// </summary>
        /// <param name="account">where to get the money</param>
        /// <param name="amountToWithdraw">how much to get</param>
        /// <returns>did it work?</returns>
        bool Withdrawal(Account account, decimal amountToWithdraw);

        /// <summary>
        /// put money into the account
        /// </summary>
        /// <param name="account">where to put the money</param>
        /// <param name="amountToDeposit">how much to put in?</param>
        /// <returns>was it able to deposit?</returns>
        bool Deposit(Account account, decimal amountToDeposit);

        List<Account> ListAll();

        void AddAccount(Account account);

    }
}
