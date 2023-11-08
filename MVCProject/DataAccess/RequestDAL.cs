using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVCProject.Models;

namespace MVCProject.DataAccess
{
    public class RequestDAL : Base
    {
        public List<RequestData> GetRequestByUserId(string userid)
        {
            List<RequestData> lstdata = new List<RequestData>();
            SqlCommand comm = new SqlCommand();
            SqlDataReader rd = null;

            SqlConnection conn = new SqlConnection();
            conn = this.ManageSQL();
            comm.Connection = conn;

            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT U.USERID, U.FIRSTNAME, U.DEPARTMENT, U.POSITION, Q.REQCODE, Q.TITLE, Q.DESCRIPTION " +
                "FROM TBLUSERPROFILE U, TBLREQUEST Q WHERE U.USERID = Q.USERID AND U.USERID = '" + userid + "'";

            rd = comm.ExecuteReader();

            if (rd != null && rd.HasRows)
            {
                while (rd.Read())
                {
                    RequestData reqdata = new RequestData();

                    reqdata.USERID = rd["USERID"].ToString();
                    reqdata.FIRSTNAME = rd["FIRSTNAME"].ToString();
                    reqdata.LASTNAME = rd["LASTNAME"].ToString();
                    reqdata.DEPARTMENT = rd["DEPARTMENT"].ToString();
                    reqdata.POSITION = rd["POSITION"].ToString();
                    reqdata.REQCODE = rd["REQCODE"].ToString();
                    reqdata.TITLE = rd["TITLE"].ToString();
                    reqdata.DESCRIPTION = rd["DESCRIPTION"].ToString();

                    lstdata.Add(reqdata);
                }
            }

            return lstdata;
        }
    }
}