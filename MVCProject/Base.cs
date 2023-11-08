using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCProject
{
    public class Base
    {
        public SqlConnection ManageSQL()
        {
            SqlConnection Conn = new SqlConnection();

            string ConnStr = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            Conn.ConnectionString = ConnStr;

            if (Conn != null && Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }

            return Conn;
        }
    }
}