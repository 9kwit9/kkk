using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVCProject.Models;

namespace MVCProject.DataAccess
{
    public class EmployeeDAL : Base
    {
        public bool CheckLogin(string userid, string password)
        {
            bool result = false;


            SqlCommand comm = new SqlCommand();
            SqlDataReader rd = null;

            #region connection Database
                SqlConnection con = new SqlConnection();
                con = ManageSQL();
                comm.Connection = con;
            #endregion

            #region Send Query
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT Count(*) AS C FROM tbluser WHERE userid='" + userid + "' AND password='" + password + "'";
            #endregion

            #region Return Data
                rd = comm.ExecuteReader();

                if (rd != null && rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int i = Convert.ToInt32(rd["C"].ToString());

                        if (i == 1)
                        {
                            return true;
                        }
                    }
                }
            #endregion

            return result;
        }

        public EmployeeDATA GetUserInfo(string userid)
        {
            EmployeeDATA empdata = null;

            SqlCommand comm = new SqlCommand();
            SqlDataReader rd = null;

            #region connection Database
            SqlConnection con = new SqlConnection();
            con = ManageSQL();
            comm.Connection = con;
            #endregion

            #region Send Query
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM tbluserprofile WHERE userid='" + userid + "'";
            #endregion

            #region Return Data
            rd = comm.ExecuteReader();

            if (rd != null && rd.HasRows)
            {
                while (rd.Read())
                {
                    empdata = new EmployeeDATA();

                    empdata.USERID = rd["USERID"].ToString();
                    empdata.FIRSTNAME = rd["FIRSTNAME"].ToString();
                    empdata.LASTNAME = rd["LASTNAME"].ToString();
                    empdata.POSITION = rd["POSITION"].ToString();
                    empdata.DEPARTMENT = rd["DEPARTMENT"].ToString();
                    empdata.MOBILE = rd["MOBILE"].ToString();
                }
            }
            #endregion

            return empdata;
        }
    }
}