using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    class AccountFileRepositoryTests
    {

        public void OpenAccountTest()
        {
            AccountFileRepository repo = new AccountFileRepository();

            var account = new Account();
            //figure out how to test from videos
        }
        
        
        
    }
}
