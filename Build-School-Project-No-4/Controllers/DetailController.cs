using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.Services;

namespace Build_School_Project_No_4.Controllers
{
    public class DetailController : Controller
    {
        private readonly DetailServices _detailService;
            public DetailController()
        {
            _detailService = new DetailServices();
        }
        // GET: Detail
        //public ActionResult DetailPage(int? productId)
        //{
        //    if (!productId.HasValue)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var detailvm = _detailService.GetPlayerByProductId(productId.Value);
        //    int i2 = 0;
        //    return View();

        //}
        //public ActionResult DetailPage()
        //{
        //    return View();
        //}
    }
}