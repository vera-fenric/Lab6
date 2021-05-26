using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ViewModel;
using Lab3;

namespace Tests
{
    [TestClass]
    public class CanDoTests
    {
        [TestMethod]
        public void CanSaveTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            Assert.IsFalse(vm.CanSave());
        }
        [TestMethod]
        public void CanSave2Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.New();
            Assert.IsFalse(vm.CanSave());
        }
        [TestMethod]
        public void CanSave3Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            Assert.IsTrue(vm.CanSave());
        }
        [TestMethod]
        public void CanDeleteTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            Assert.IsFalse(vm.CanDelete());
        }
        [TestMethod]
        public void CanDelete2Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.CurrV2Data = new V2DataCollection("info 1", 0.0);
            Assert.IsTrue(vm.CanDelete());
        }
        [TestMethod]
        public void CanAddTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            Assert.IsFalse(vm.CanAdd());
        }
        [TestMethod]
        public void CanAdd2Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.CurrV2DataCollection = new V2DataCollection("info 1", 0.0);
            Assert.IsTrue(vm.CanAdd());
        }
    }
}
