using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void CreateTest()
        {
            var vm = new MainViewModel();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm._MyMainCollection);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void NewTest()
        {
            var vm = new MainViewModel();
            vm.New();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm._MyMainCollection);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void Default1Test()
        {
            var vm = new MainViewModel();
            vm.Default();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm._MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl2Test()
        {
            var vm = new MainViewModel();
            vm.Default_V2DataCollection();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm._MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl3Test()
        {
            var vm = new MainViewModel();
            vm.Default_V2DataOnGrid();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm._MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void SaveTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.SaveToFile("savefile.txt");
            Assert.IsTrue((s as BoolViewModel.CorrectResultViewModel).Value);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void OpenTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.OpenFile("openfile.txt");
            Assert.IsTrue((s as BoolViewModel.CorrectResultViewModel).Value);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void NotOpenTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.OpenFile("notopenfile.txt");
            Assert.IsNotNull((s as BoolViewModel.ErrorResultViewModel));
        }
        /*
        [TestMethod]
        public void RemoveTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.Remove(???);
            Assert.IsTrue(s);
        }
        
        [TestMethod]
        public void InvalidRemoveTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.Remove(???);
            Assert.IsFalse(s);
        }
        */
        
        [TestMethod]
        public void AddFromFileTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.AddFromFile("AddFromFile.txt") as BoolViewModel.CorrectResultViewModel;
            Assert.IsTrue(s.Value);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void BadAddFromFileTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.AddFromFile("BadAddFromFile.txt") as BoolViewModel.ErrorResultViewModel;
            Assert.IsNotNull(s);
        }

        /*
        [TestMethod]
        public void MinMaxTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var min = vm.Min as AvgViewModel.CorrectResultViewModel;
            var max = vm.Max as AvgViewModel.CorrectResultViewModel;
            Assert.IsTrue(min != null);
            Assert.IsTrue(max != null);
            Assert.AreEqual(0.0, min, 1e-6);
            Assert.AreEqual(5.0, max, 1e-6);
        }
        [TestMethod]
        public void InvalidMinMaxTest()
        {
            var vm = new MainViewModel();
            var min = vm.Min as AvgViewModel.ErrorResultViewModel;
            var max = vm.Max as AvgViewModel.ErrorResultViewModel;
            Assert.IsTrue(min != null);
            Assert.IsTrue(max != null);
        }
        */
        [TestMethod]
        public void AvgTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var avg = (vm.Avg as AvgViewModel.CorrectResultViewModel).Value;
            Assert.AreEqual(2.306019, avg, 1e-6);
        }

    }
}
