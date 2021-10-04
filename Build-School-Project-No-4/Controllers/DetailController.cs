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
        public DetailController()
        {
            _detailService = new DetailServices();
            _ctx = new EPalContext();
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
            var xxx = id;
            var gameStartTime = Convert.ToDateTime(startTime);
            Order unpaid = new Order()
            {
                Quality = AddCartVM.AddCart.Rounds,
                UnitPrice = AddCartVM.AddCart.UnitPrice,
                CustomerId = 1,
                ProductId = AddCartVM.AddCart.PlayerId,
                OrderDate = DateTime.Now,
                GameStartDateTime = gameStartTime,
                GameEndDateTime = new DateTime(2000,1,1,1,1,1),
                OrderStatus = "unpaid",
                UpdateDateTime = new DateTime(2000, 1, 1, 1, 1, 1),
               
            };
            using (var tran = _ctx.Database.BeginTransaction())
            {
                try
                {
                    _ctx.Orders.Add(unpaid);
                    _ctx.SaveChanges();
                    tran.Commit();
                    return Content("add success");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return Content("add failed" + ex.ToString());
                }
            }
            //var gamePrice = _detailService.FindPlayerListing(id).UnitPrice;
            //return View(AddCartVM);
            
            //return ("hi");
        }

    }
}