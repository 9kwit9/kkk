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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {


            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "WelCome";


            EmployeeDATA data = new EmployeeDATA();

            data.USERID = "Please input Username";
            data.PASSWORD = "Please input Password";


            //data.Username = "Username";
            //data.Password = "Password";

            return View(data);
        }

        [HttpPost]
        public ActionResult Index(EmployeeDATA data)
        {
            ViewBag.Title = "Login to WorkFlow";
            ViewBag.Head = "WelCome";

            EmployeeDAL dl = new EmployeeDAL();

            bool chk = dl.CheckLogin(data.USERID, data.PASSWORD);


            if (chk==true)
            {
                TempData["USERID"] = data.USERID;
                Session["USERID"] = data.USERID;

               return RedirectToAction("Index","WF");


            }
            else
            {



                data.USERID = "Please input Username";
                data.PASSWORD = "Please input Password";


                return View(data);

            }


        }

    }
}