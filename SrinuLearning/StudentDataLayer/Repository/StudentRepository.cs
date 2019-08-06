using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDataLayer.Models;

namespace StudentDataLayer.Repository
{
    public class StudentRepository : SqlClientRepository<Student>
    {
        public StudentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
