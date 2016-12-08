using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups;

namespace WarmupsTest
{
    [TestFixture]
    public class StringWarmupsTest
    {
        StringWarmups obj = new StringWarmups();

        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expected)
        {
            string actual = obj.SayHi(name);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Alice", "Yo", "AliceYoYoAlice")]
        [TestCase("What", "Up", "WhatUpUpWhat")]
        public void AbbaTest(string a, string b, string expected)
        {
            string actual = obj.Abba(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("i", "Yay", "<i>Yay<i>")]
        [TestCase("i", "Hello","<i>Hello<i>")]
        [TestCase("cite","Yay","<cite>Yay<cite>")]
        public void MakeTagsTest(string tag, string content, string expected)
        {
            string actual = obj.MakeTags(tag, content);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("<<>>","Yay","<<Yay>>")]
        public void InsertWordTest(string container, string word, string expected)
        {
            string actual = obj.InsertWord(container, word);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello","lololo")]
        public void MultipleEndingsTest(string str, string expected)
        {
            string actual = obj.MultipleEndings(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("WooHoo","Woo")]
        [TestCase("HelloThere","Hello")]
        [TestCase("abcdef","abc")]
        public void FirstHalfTest(string str, string expected)
        {
            string actual = obj.FirstHalf(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello","llo")]
        [TestCase("away","aay")]
        [TestCase("abed","abed")]
        public void TweakFrontTest(string str, string expected)
        {
            string actual = obj.TweakFront(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void HasBadTest(string str, bool expected)
        {
            bool actual = obj.HasBad(str);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("Hello","loHel")]
        public void RotateRight2Test(string str, string expected)
        {
            string actual = obj.RotateRight2(str);

            Assert.AreEqual(actual, expected);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwo_Test(string str, int n, string expected)
        {
            string actual = obj.TakeTwoFromPosition(str, n);

            Assert.AreEqual(actual, expected);
        }


    }
}
