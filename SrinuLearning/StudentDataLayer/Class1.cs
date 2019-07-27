using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StudentDataLayer
{
    public class Class1
    {

        public void GetStudents()
        {
            SqlConnection conn = null;
            string connectionString = ConfigurationManager
                .ConnectionStrings["studentmdfconnection"].ConnectionString;

            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from student";
                SqlDataReader reader=cmd.ExecuteReader();

                while(reader.Read())
                {
                    string name = reader.GetString(1);
                }
            }
        }
    }
}
