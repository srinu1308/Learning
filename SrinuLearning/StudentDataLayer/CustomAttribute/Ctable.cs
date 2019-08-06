using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentDataLayer.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Ctable: System.Attribute
    {
        public string TableName { get; }
        public Ctable(string tableName)
        {
            TableName = tableName;
        }
    }
}
