using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ViewModel;
using Lab3;

namespace Tests
{
    
    [TestClass]
    public class ViewModelTests
    {
        
        [TestMethod]
        public void CreateTest()
        {
            var vm1 = new MainViewModel(new YesUIServices());
            var vm2 = new MainViewModel(new NoUIServices());
            var vm3 = new MainViewModel(new CancelUIServices());
            Assert.IsNotNull(vm1);
            Assert.IsTrue(vm1.Saved);
            Assert.IsNotNull(vm2);
            Assert.IsTrue(vm2.Saved);
            Assert.IsNotNull(vm3);
            Assert.IsTrue(vm3.Saved);
        }
        [TestMethod]
        public void NewTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.New();
            Assert.IsNotNull(vm);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void Default1Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl2Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default_V2DataCollection();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl3Test()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default_V2DataOnGrid();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void SaveTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            vm.Save();
            Assert.IsTrue(vm.Saved);
        }
        [TestMethod]
        [ExpectedException (typeof(NotImplementedException))]
        public void FailSaveTest()
        {
            var vm = new MainViewModel(new NoUIServices());
            //vm.Default();
            vm.Open();
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void OpenTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            vm.Open();
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void NotOpenTest()
        {
            var vm = new MainViewModel(new CancelUIServices());
            vm.Default();
            vm.Open();
            Assert.IsFalse(vm.Saved);
        }
        
        [TestMethod]
        public void RemoveDCTest()
        {
            var vm = new MainViewModel(new NoUIServices());
            vm.Default();
            vm.CurrV2Data = new V2DataCollection("info 2", 4);
            vm.Remove();
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FailRemoveDCTest()
        {
            var vm = new MainViewModel(new CancelUIServices());
            vm.Default();
            vm.CurrV2Data = new V2DataCollection("info 2", 4);
            vm.Remove();
            vm.Remove();
        }
        [TestMethod]
        public void RemoveDoGTest()
        {
            var vm = new MainViewModel(new NoUIServices());
            vm.Default();
            vm.CurrV2Data = new V2DataOnGrid("info 2", 2, new Grid1D(0, 0), new Grid1D(0, 0));
            vm.Remove();
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FailRemoveDoGTest()
        {
            var vm = new MainViewModel(new CancelUIServices());
            vm.Default();
            vm.CurrV2Data = new V2DataOnGrid("info 2", 2, new Grid1D(0, 0), new Grid1D(0, 0));
            vm.Remove();
            vm.Remove();
        }
        
        [TestMethod]
        public void FailFromFileTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            vm.Save();
            vm.AddFromFile();
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        [ExpectedException (typeof(NotImplementedException))]
        public void FailAddTest()
        {
            var vm = new MainViewModel(new CancelUIServices());
            vm.Default();
            vm.Add();
        }
        [TestMethod]
        public void AvgTest()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            var avg = (vm.Avg as AvgViewModel.CorrectResultViewModel).Value;
            Assert.AreEqual(2.306019, avg, 1e-6);
        }
        [TestMethod]
        public void CloseTest1()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Close();
            Assert.IsTrue(vm.Saved);
        }
        [TestMethod]
        public void CloseTest2()
        {
            var vm = new MainViewModel(new YesUIServices());
            vm.Default();
            vm.Close();
            Assert.IsTrue(vm.Saved);
        }
        [TestMethod]
        public void CloseTest3()
        {
            var vm = new MainViewModel(new NoUIServices());
            vm.Default();
            vm.Close();
            Assert.IsFalse(vm.Saved);
        }

    }
}
