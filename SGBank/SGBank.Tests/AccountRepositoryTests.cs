using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    class AccountRepositoryTests
    {
        [Test]
        public void WithdrawMoney()
        {
            InMemAccountRepository repo = new InMemAccountRepository();
            var account = new Account() { AccountNumber = "456789" };
            Assert.IsTrue(repo.Withdrawal(account, 100m));
        }
    }
}
