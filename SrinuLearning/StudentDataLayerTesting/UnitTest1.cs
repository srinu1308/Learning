using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDataLayer;
using StudentDataLayer.Models;
using StudentDataLayer.Repository;
using System.Configuration;
using System.Collections.Generic;

namespace StudentDataLayerTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Class1 obj1 = new Class1();
            //obj1.GetStudents();
            string connectionString = ConfigurationManager
                .ConnectionStrings["studentmdfconnection"].ConnectionString;

            StudentRepository repo = new StudentRepository(connectionString);

            IEnumerable<Student> students1 = repo.List;

            Student student = new Student();
            student.id = 2;
            student.age = 30;
            student.email = "yahiko@gmail.com";
            student.mobile = "9491378866";
            student.name = "yahiko";
            student.sex = 1;

            repo.Update(student);

            IEnumerable<Student> students=repo.List;

            
        }
    }
}
