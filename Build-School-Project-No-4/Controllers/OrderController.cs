using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.ViewModels;
using System.Web.Security;

namespace Build_School_Project_No_4.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public string GetMemberId()
        {
            var cookie = HttpContext.Request.Cookies.Get(FormsAuthentication.FormsCookieName);

            string userid = "";
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                userid = ticket.UserData;
                return userid;
            }
            return null;
        }
        public ActionResult OrderSummary()
        {
             
            return View();

        }

       
    }
}