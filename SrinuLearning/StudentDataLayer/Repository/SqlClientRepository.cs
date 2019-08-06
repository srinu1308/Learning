using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StudentDataLayer.CustomAttribute;
using System.Reflection;

namespace StudentDataLayer.Repository
{
    public abstract class SqlClientRepository<T> : IRepository<T> where T:new()
    {
        protected SqlConnection _sqlConnection;

        public SqlClientRepository(string connectionString)
        {

            _sqlConnection = SqlServerDBConnection.GetSqlServerDBConnection(connectionString);
        }
        public virtual IEnumerable<T> List
        {
            get
            {
                List<T> _list = new List<T>();

                try
                {
                    Type t = typeof(T);

                    Ctable attrTable = (Ctable)Attribute.GetCustomAttribute(t, typeof(Ctable));
                    string tablename = attrTable.TableName;

                    string sqlQuery = "select * from " + tablename;

                    if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    {
                        _sqlConnection.Open();
                    }

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        T custObj = new T();

                        PropertyInfo[] properties = typeof(T).GetProperties();

                        foreach (var item in properties)
                        {
                            CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                            string columnName = cColumn.colName;
                            Boolean isKey = cColumn.isKey;

                            item.SetValue(custObj, reader[columnName], null);
                        }

                        _list.Add(custObj);
                    }
                }
                finally
                {
                    _sqlConnection.Close();
                }

                return _list;
            }
        }

        public virtual void Add(T entity)
        {
            try
            {


                Type t = typeof(T);


                Ctable attrTable = (Ctable)Attribute.GetCustomAttribute(t, typeof(Ctable));
                string tablename = attrTable.TableName;

                string strColNames = string.Empty;
                string strColValues = string.Empty;

                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }

                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (var item in properties)
                {
                    CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                    string columnName = cColumn.colName;
                    Boolean isKey = cColumn.isKey;
                    Boolean isIdentity = cColumn.isIdentity;

                    if (isIdentity)
                        continue;

                    if (!item.PropertyType.IsValueType)
                    {
                        strColValues = strColValues
                            + "'"
                            + item.GetValue(entity)
                            + "'"
                            + ",";
                    }
                    else
                    {
                        strColValues = strColValues + item.GetValue(entity) + ",";
                    }

                    strColNames = strColNames + columnName + ",";

                }

                strColNames = strColNames.Trim(new char[] { ',' });
                strColValues = strColValues.Trim(new char[] { ',' });

                string sqlQuery = "insert into " + tablename
                    + "(" + strColNames + ") values ("
                    + strColValues + ")";

                SqlCommand cmd = new SqlCommand(sqlQuery, _sqlConnection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                Boolean hasKey = false;
                Type t = typeof(T);


                Ctable attrTable = (Ctable)Attribute.GetCustomAttribute(t, typeof(Ctable));
                string tablename = attrTable.TableName;

                string strColNames = string.Empty;
                string strColValues = string.Empty;

                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }

                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (var item in properties)
                {
                    CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                    string columnName = cColumn.colName;
                    Boolean isKey = cColumn.isKey;
                    Boolean isIdentity = cColumn.isIdentity;

                    if (!isKey)
                        continue;
                    else
                    {
                        hasKey = true;

                        if (!item.PropertyType.IsValueType)
                        {
                            strColValues = strColValues +
                                columnName +
                                " = "
                                + "'"
                                + item.GetValue(entity)
                                + "'"
                                + " and ";
                        }
                        else
                        {
                            strColValues = strColValues
                                + columnName
                                + " = "
                                + item.GetValue(entity) + " and ";
                        }
                    }
                }

                if (hasKey)
                {
                    strColValues = strColValues.TrimEnd(new char[] { 'a', 'n', 'd', ' ' });

                    string sqlQuery = "delete from " + tablename + " where "
                    + strColValues;

                    SqlCommand cmd = new SqlCommand(sqlQuery, _sqlConnection);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("you can not delete without key");
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
        
        
        }

        public virtual T FindByID(Object key)
        {
            T custObj = new T();

            try
            {
                Boolean hasKey = false;
                Type t = typeof(T);


                Ctable attrTable = (Ctable)Attribute.GetCustomAttribute(t, typeof(Ctable));
                string tablename = attrTable.TableName;

                string strColNames = string.Empty;
                string strColValues = string.Empty;

                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }

                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (var item in properties)
                {
                    CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                    string columnName = cColumn.colName;
                    Boolean isKey = cColumn.isKey;
                    Boolean isIdentity = cColumn.isIdentity;

                    if (!isKey)
                        continue;
                    else
                    {
                        hasKey = true;

                        if (!item.PropertyType.IsValueType)
                        {
                            strColValues = strColValues +
                                columnName +
                                " = "
                                + "'"
                                + key
                                + "'"
                                + " and ";
                        }
                        else
                        {
                            strColValues = strColValues
                                + columnName
                                + " = "
                                + key + " and ";
                        }
                    }



                }

                if (hasKey)
                {
                    strColValues = strColValues.TrimEnd(new char[] { 'a', 'n', 'd', ' ' });

                    string sqlQuery = "select * from " + tablename + " where "
                    + strColValues;

                    SqlCommand cmd = new SqlCommand(sqlQuery, _sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        PropertyInfo[] properties1 = typeof(T).GetProperties();

                        foreach (var item in properties1)
                        {
                            CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                            string columnName = cColumn.colName;
                            Boolean isKey = cColumn.isKey;

                            item.SetValue(custObj, reader[columnName], null);
                        }

                    }

                }
                else
                {
                    throw new Exception("you can not delete without key");
                }
            }
            finally
            {
                _sqlConnection.Close();
            }

            return custObj;
        }

        public virtual void Update(T entity)
        {
            try {
                Type t = typeof(T);

                Ctable attrTable = (Ctable)Attribute.GetCustomAttribute(t, typeof(Ctable));
                string tablename = attrTable.TableName;

                string strWhere = string.Empty;
                string strColValues = string.Empty;

                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }

                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (var item in properties)
                {
                    CColumn cColumn = (CColumn)Attribute.GetCustomAttribute(item, typeof(CColumn));
                    string columnName = cColumn.colName;
                    Boolean isKey = cColumn.isKey;
                    Boolean isIdentity = cColumn.isIdentity;

                    if (isIdentity)
                    {
                        if (!item.PropertyType.IsValueType)
                        {
                            strWhere = strWhere + columnName + " = "
                                + "'"
                                + item.GetValue(entity)
                                + "'"
                                + ",";
                        }
                        else
                        {
                            strWhere = strWhere + columnName + " = " + item.GetValue(entity) + ",";
                        }
                        continue;
                    }


                    if (!item.PropertyType.IsValueType)
                    {
                        strColValues = strColValues + columnName + " = "
                            + "'"
                            + item.GetValue(entity)
                            + "'"
                            + ",";
                    }
                    else
                    {
                        strColValues = strColValues + columnName + " = "
                            + item.GetValue(entity) + ",";
                    }
                }

                strColValues = strColValues.Trim(new char[] { ',' });
                strWhere = strWhere.Trim(new char[] { ',' });

                string sqlQuery = "update " + tablename
                    + " set "
                    + strColValues
                    + " where "
                    + strWhere;


                SqlCommand cmd = new SqlCommand(sqlQuery, _sqlConnection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            }
    }
}
