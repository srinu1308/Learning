using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesForJScript.Business;

namespace ServicesForJScript.Repository
{
    public class StudentRepository
    {
        private Students listStudents { get; set; }

        public Students GetStudents()
        {
            listStudents = new Students();

            Student student = new Student();
            student.Name = "srinu";
            student.Age = 29;
            student.Sex = 1;
            student.MailID = "srinu.vadapalli664@gmail.com";

            listStudents.Add(student);

            student = new Student();
            student.Name = "srinu2";
            student.Age = 30;
            student.Sex = 1;
            student.MailID = "srinu2.vadapalli664@gmail.com";

            listStudents.Add(student);

            student = new Student();
            student.Name = "srinu3";
            student.Age = 31;
            student.Sex = 1;
            student.MailID = "srinu3.vadapalli664@gmail.com";

            listStudents.Add(student);


            return listStudents;
        }
    }
}