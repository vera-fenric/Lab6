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
            var vm = new MainViewModel();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsNotNull(vm.MyDataItemView);
            Assert.IsTrue(vm.Saved);
        }
        [TestMethod]
        public void NewTest()
        {
            var vm = new MainViewModel();
            vm.New();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsTrue(vm.Saved);
        }

        [TestMethod]
        public void Default1Test()
        {
            var vm = new MainViewModel();
            vm.Default();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl2Test()
        {
            var vm = new MainViewModel();
            vm.Default_V2DataCollection();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
            Assert.IsFalse(vm.Saved);
        }

        [TestMethod]
        public void Defautl3Test()
        {
            var vm = new MainViewModel();
            vm.Default_V2DataOnGrid();
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.MyMainCollection);
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
        
        [TestMethod]
        public void RemoveDCTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.Remove(new V2DataCollection("info 2", 4));
            Assert.IsTrue((s as BoolViewModel.CorrectResultViewModel).Value);
        }
        [TestMethod]
        public void RemoveDoGTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.Remove(new V2DataOnGrid("info 2", 2, new Grid1D(0, 0), new Grid1D(0, 0)));
            Assert.IsTrue((s as BoolViewModel.CorrectResultViewModel).Value);
        }

        [TestMethod]
        public void InvalidRemoveTest()
        {
            var vm = new MainViewModel();
            vm.Default();
            var s = vm.Remove(new V2DataCollection("info 1", 1));
            //Assert.ThrowsException(vm.Remove(new V2DataCollection("info 1", 1)));
        }
        
        
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

        [TestMethod]
        public void SetCurTest()
        {
            var vm = new MainViewModel();
            //vm.Default();
            
            var s = vm.SetCur(new V2DataCollection("info 1", 1)) as BoolViewModel.CorrectResultViewModel;
            Assert.IsTrue(s.Value);
        }
        [TestMethod]
        public void InvalidSetCurTest()
        {
            var vm = new MainViewModel();
            var s = vm.SetCur(null) as BoolViewModel.ErrorResultViewModel;
            Assert.IsNotNull(s);
        }
        [TestMethod]
        public void InvalidAddTest()
        {
            var vm = new MainViewModel();
            //vm.Default();
            var s = vm.Add() as BoolViewModel.ErrorResultViewModel;
            Assert.IsNotNull(s);
        }
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
