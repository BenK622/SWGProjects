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
        AccountOperations ops = new AccountOperations();

        [Test]
        public void MakeWithdrawal()
        {
            
            Account account = new Account() { AccountNumber = "123456", Balance = 1234.56m };
            Assert.IsTrue(ops.MakeWithdrawal(account, 200));
        }

        [Test]
        public void MakeDepositTest()
        {
            Account account = new Account() { AccountNumber = "123456", Balance = 1234.56m };
            Assert.IsTrue(ops.MakeDeposit(account, 1500));
        }
        
    }
}
