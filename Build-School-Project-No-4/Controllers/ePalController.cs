using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Controllers
{
    public class ePalController : Controller
    {
        private readonly ProductService _productService;

        public ePalController()
        {
            _productService = new ProductService();
        }
      
        public ActionResult EPal(int? id)
        {
            var productGet = new ProductService();
            if (!id.HasValue)
            {
                return RedirectToAction("ePal", "ePal", new { id = 1});
            }
            var ProductCards = productGet.GetProductCardsData(id.Value);
            var Games = productGet.GetGamesAll();

            GroupViewModel result = new GroupViewModel
            {
                GameCategory = Games,
                ProductCards = ProductCards
            };

            return View(result);
        }

        

    }
}