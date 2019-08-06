using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDataLayer.CustomAttribute;
using StudentDataLayer.Repository;

namespace StudentDataLayer.Models
{
    [Ctable("student")]
    public class Student
    {
        //[CColumn("id",typeof(int),true)]
        [CColumn("id",  true,true)]
        public int id { get; set; }

        //[CColumn("name", typeof(string))]
        [CColumn("name")]
        public string name { get; set; }

        //[CColumn("age", typeof(int))]
        [CColumn("age")]
        public int age { get; set; }

        //[CColumn("sex", typeof(int))]
        [CColumn("sex")]
        public int sex { get; set; }

        //[CColumn("mobile", typeof(int))]
        [CColumn("mobile")]
        public string mobile { get; set; }

        //[CColumn("email", typeof(string))]
        [CColumn("email")]
        public string email { get; set; }

        
    }
}
