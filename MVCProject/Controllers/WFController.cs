using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.DataAccess;
using Newtonsoft.Json;

namespace MVCProject.Controllers
{
    public class WFController : Controller
    {
        //
        // GET: /WF/
        public ActionResult Index()
        {
            EmployeeDATA empData = new EmployeeDATA();
            RequestData reqData = new RequestData();

            if (Session["USERID"] != null)
            {
                EmployeeDAL dl = new EmployeeDAL();

                string userid = Session["USERID"].ToString();

                empData = dl.GetUserInfo(userid);

                if (empData != null)
                {
                    RequestDAL dal = new RequestDAL();

                    List<RequestData> lstdata = dal.GetRequestByUserId(userid);
                    
                    reqData.LSTREQ = lstdata;

                    string json = JsonConvert.SerializeObject(reqData);

                    reqData = JsonConvert.DeserializeObject<RequestData>(json);

                    if (reqData.LSTREQ.Count > 0)
                    {
                        ViewData["REQDATA"] = reqData.LSTREQ;
                    }
                }
            }
            return View();
        }
	}
}