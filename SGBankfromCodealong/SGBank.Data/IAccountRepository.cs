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

        bool Deposit(Account account, decimal amountToDeposit);
    }
}
