using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System;

namespace JLib.Extensions.UnitTests
{
    [TestClass]
    public class NotifyPropertyChangedUtilityTests
    {
        private class propTestClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private int _testProp;
            public int TestProp
            {
                get => this._testProp;
                set => this.RaisePropertyChanged(ref this._testProp , value , this.PropertyChanged);
            }
        }
        [TestMethod]
        public void Test_RaisePropertyChanged()
        {
            int value1 = 0;
            int value2 = 1;

            propTestClass obj = new propTestClass() { TestProp = value1 };
            bool executed = false;
            obj.PropertyChanged += (caller , args) =>
            {
                executed = true;
                Assert.IsTrue(args.PropertyName == nameof(propTestClass.TestProp), "wrong name in eventargs");
                Assert.IsTrue(obj.TestProp == value2 , "wrong value in object");
            };
            obj.TestProp = value2;
            Assert.IsTrue(executed , "property changed event");
        }
    }
}
