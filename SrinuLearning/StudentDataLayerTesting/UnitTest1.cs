using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDataLayer;
namespace StudentDataLayerTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 obj1 = new Class1();
            obj1.GetStudents();
        }
    }
}
