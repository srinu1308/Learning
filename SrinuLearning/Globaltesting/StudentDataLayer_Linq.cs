using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDataLayer_LINQ;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Globaltesting
{
    [TestClass]
    public class StudentDataLayer_Linq
    {
        [TestMethod]
        public void TestMethod1()
        {
            string connection=
                System.Configuration.ConfigurationManager.ConnectionStrings["StudentDataLayer_LINQ.Properties.Settings.StudentConnectionString"].ToString();

            DataClasses1DataContext context = new DataClasses1DataContext(connection);
            IQueryable<student> students =context.students;

            foreach (var item in students)
            {
                Console.WriteLine(item.email);
            }

            List<student> listStudents = students.ToList();

            foreach (var item in listStudents)
            {
                Console.WriteLine(item.email);
            }

            var result = (from n in listStudents
                         where n.id > 1
                         select n).FirstOrDefault();

            Console.WriteLine(result.email);

            var result2 = (from n in context.students
                           where n.id > 1
                           select n).FirstOrDefault();

            string mailId = result2.email;


            student objStudent = new student();
            objStudent.age = 30;
            objStudent.email = "itach@gmail.com";
            objStudent.mobile = "9491378870";
            objStudent.name = "itachi";
            context.students.InsertOnSubmit(objStudent);
            context.SubmitChanges();


            foreach (var item in context.students)
            {
                Console.WriteLine(item.email);
            }

            student updateStudent = context.students.Where(x => x.name.Equals("itachi")).FirstOrDefault();
            updateStudent.name = "itachiU";

            context.SubmitChanges();


            foreach (var item in context.students)
            {
                Console.WriteLine(item.email);
            }

            context.students.DeleteOnSubmit(
                context.students.Where(x => x.name.Equals("itachiU")).FirstOrDefault()
                );

            context.SubmitChanges();

            foreach (var item in context.students)
            {
                Console.WriteLine(item.email);
            }

        }
    }
}
