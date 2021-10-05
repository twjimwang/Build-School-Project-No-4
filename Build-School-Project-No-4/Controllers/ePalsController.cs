using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Controllers
{
    public class ePalsController : Controller
    {
        private readonly ProductService _productService;

        public ePalsController()
        {
            _productService = new ProductService();
        }

        public ActionResult ePal(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ePal", "ePals", new { id = 1 });
            }
            var ProductCards = _productService.GetProductCardsData(id.Value);
            var GamesDeatils = _productService.GetGamesAllAndDeatils(id.Value);

            GroupViewModel result = new GroupViewModel
            {
                GamesDetails = GamesDeatils,
                ProductCards = ProductCards
            };
            ViewBag.ProductCard = _productService.GetProductCardsJson(id.Value);
            return View("ePal",result);
        }

        public ActionResult GamesJson(int id)
        {
            ViewBag.ProductCard = _productService.GetProductCardsJson(id);

            return View();
        }
    }
}