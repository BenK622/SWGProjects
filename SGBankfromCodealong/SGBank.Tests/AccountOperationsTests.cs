using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    class AccountOperationsTests
    {
        [Test]
        public void MakeWithdrawal()
        {
            AccountOperations ops = new AccountOperations();
            Account account = new Account() { AccountNumber = "123456", Balance = 1234.56m };
            var response = ops.MakeWithdrawal(account, 200);
            Assert.IsTrue(response.Success);
            Console.WriteLine($"New Balance is {response.AccountInfo.Balance}");
        }
    }
}
