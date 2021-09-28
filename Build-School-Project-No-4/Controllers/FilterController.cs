using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }

        ///<summary>
        /// 此方法會先在其它方法之前執行
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //如果使用者未登錄(已登錄者資訊會保存在session中)
            if (Session[MembersController.LoginUserKey] == null)
            {
                //跳轉到帶有原頁面網址作為地址參數的登錄頁面
                string path = filterContext.HttpContext.Request.Path;//原原頁的地址
                filterContext.Result = Redirect("/Members/Login?ReturnUrl=" + path);
            }
        }

    }
}