using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CColumn:System.Attribute
    {
        public string  colName { get; set; }
        //public Type type { get; set; }
        public Boolean isKey { get; set; }

        public Boolean isIdentity { get; set; }

        //public CColumn(string colName,Type type, Boolean iskey=false)
        //{
        //    this.colName = colName;
        //    this.isKey = isKey;
        //    this.type = type;
        //}

        public CColumn(string colName, Boolean isKey = false,Boolean isIdentity=false)
        {
            this.colName = colName;
            this.isKey = isKey;
            this.isIdentity = isIdentity;
            //this.type = type;
        }
    }
}
