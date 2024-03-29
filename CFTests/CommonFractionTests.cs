using Microsoft.VisualStudio.TestTools.UnitTesting;
using CF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Tests
{
    [TestClass()]
    public class CommonFractionTests
    {
        [TestMethod()]
        public void ToStringTest1()
        {
            Assert.AreEqual("2/3", new CommonFraction(2, 3).ToString());
        }

        [TestMethod()]
        public void ToStringTest2()
        {
            Assert.AreEqual("1/6", (new CommonFraction(-1, 3) - new CommonFraction(-1, 2)).ToString());
        }

        [TestMethod()]
        public void ToStringTest3()
        {
            Assert.AreEqual("1", (new CommonFraction(1, 2) * new CommonFraction(2, 1)).ToString());
        }

        [TestMethod()]
        public void ToStringTest4()
        {
            Assert.AreEqual("0", (new CommonFraction(0, 3) / new CommonFraction(10, 1)).ToString());
        }
    }
}