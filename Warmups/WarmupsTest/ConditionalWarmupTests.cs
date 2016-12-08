using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warmups;
using NUnit.Framework;

namespace WarmupsTest
{
    [TestFixture]
    class ConditionalWarmupTests
    {
        ConditionalWarmups obj = new Warmups.ConditionalWarmups();

        [TestCase("kitten",1,"ktten")]
        [TestCase("kitten",0,"itten")]
        [TestCase("kitten",4,"kittn")]
        public void MissingCharTest(string str, int n, string expected)
        {
            string actual = obj.MissingChar(str, n);

            Assert.AreEqual(actual, expected);
        }

        [TestCase("hi there", true)]
        [TestCase("hi", true)]
        [TestCase("high up",false)]
        public void StartHiTest(string str, bool expected)
        {
            bool actual = obj.StartHi(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("adelbc", "abc")]
        [TestCase("adelHello","aHello")]
        [TestCase("adedbc","adedbc")]
        public void RemoveDelTest(string str, string expected)
        {
            string actual = obj.RemoveDel(str);


            Assert.AreEqual(expected, actual);
        }

    }
}
