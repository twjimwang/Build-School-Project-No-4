using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Controllers
{
    public class DetailController : Controller
    {
        private readonly DetailServices _detailService;
        public DetailController()
        {
            _detailService = new DetailServices();
        }
        [HttpGet]
        public ActionResult DetailPage(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var playerListing = _detailService.FindPlayerListing(id);
            //if (playerListing == null)
            //{
            //    return RedirectToAction("Index");
            //}
            int i2 = 0;
            GroupViewModel groupVM = new GroupViewModel
            {
                Deets = playerListing
            };
            int i = 0;
            return View(groupVM);
        }
        [HttpPost]
        public ActionResult DetailPage()
        {

            return View();

        }
        //public ActionResult DetailPage(int? productId)
        //{
        //    if (!productId.HasValue)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var detailvm = _detailService.GetPlayerByProductId(productId.Value);
        //    return View(detailvm);
        //}
    }
}