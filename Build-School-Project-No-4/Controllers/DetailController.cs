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
        private readonly EPalContext _ctx;
        private readonly DetailServices _detailService;
        private readonly AddToCartService _cartService;
        public DetailController()
        {
            _detailService = new DetailServices();
            _ctx = new EPalContext();
            _cartService = new AddToCartService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DetailPage(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var playerListing = _detailService.FindPlayerListing(id);
            if (playerListing == null)
            {
                return RedirectToAction("NotFound");
            }
            GroupViewModel groupVM = new GroupViewModel
            {
                Deets = playerListing
            };
            return View(groupVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailPage(GroupViewModel AddCartVM, string startTime, int id)
        {
            var unpaid = _cartService.CreateUnpaidOrder(AddCartVM, startTime, id);

            //bool isSuccess;
            //if (isSuccess)
            //{
            //    //return RedirectToAction("Checkout", new { Confirmation = confirmation, AA = 123 });
            //}

            using (var tran = _ctx.Database.BeginTransaction())
            {
                try
                {
                    _ctx.Orders.Add(unpaid);
                    _ctx.SaveChanges();
                    tran.Commit();
                    var confirmation = unpaid.OrderConfirmation;
                    return RedirectToAction("Checkout" ,new { Confirmation = confirmation});
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return Content("add failed" + ex.ToString());
                }
            }

        }
        [HttpGet]
        public ActionResult Checkout(string confirmation)
        {

            int i = 0;
            return View();
        }

    }
}