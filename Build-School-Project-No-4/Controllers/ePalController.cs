using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.Services;

namespace Build_School_Project_No_4.Controllers
{
    public class ePalController : Controller
    {
        // GET: ePal
        public ActionResult ePal()
        {
            return View();
        }
        public ActionResult EPalIndex()
        {
            var productGet = new ProductService();
            var abc = productGet.GetProductData();
            return View(abc);
            
        }
    }
}