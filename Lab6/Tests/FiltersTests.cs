using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ViewModel;
using Lab3;

namespace Tests
{
    [TestClass]
    public class FiltersTests
    {
        [TestMethod]
        public void Filter1Test1()
        {
            var v = new V2DataCollection("string", 0.0);
            Assert.IsTrue(MainViewModel.Filter1(v));
        }
        [TestMethod]
        public void Filter1Test2()
        {
            var v = new V2DataOnGrid("string", 0.0, new Grid1D (), new Grid1D());
            Assert.IsFalse(MainViewModel.Filter1(v));
        }
        [TestMethod]
        public void Filter2Test1()
        {
            var v = new V2DataOnGrid("string", 0.0, new Grid1D(), new Grid1D());
            Assert.IsTrue(MainViewModel.Filter2(v));
        }
        [TestMethod]
        public void Filter2Test2()
        {
            var v = new V2DataCollection("string", 0.0);
            Assert.IsFalse(MainViewModel.Filter2(v));
        }
    }
}
