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

        // GET: ePal
        public ActionResult ePal()
        {
            var result = _productService.GetProductAll();
            
            return View(result);
        }
        public ActionResult EPalIndex()
        {
            var productGet = new ProductService();
            var abc = productGet.GetProductData();

            GroupViewModel EPalIndexItem = new GroupViewModel
            {
                EPalIndex = abc
            };

            return View(EPalIndexItem);

        }
        public ActionResult Index()
        {
            var result = _productService.GetProductAll();

            return View(result);
        }
    }
}