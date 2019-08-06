using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentDataLayer.Repository
{
    public interface IEntity
    {
        void fill(SqlDataReader reader);
    }
}
