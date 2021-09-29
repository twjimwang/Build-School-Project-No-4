using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class BasicInformationController : Controller
    {

        private readonly EPalContext _ctx;

        public BasicInformationController()
        {
            _ctx = new EPalContext();
        }

        // GET: BasicInformation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BasicInformation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(GroupViewModel registerVM)
        {
            var mem = _ctx.Members.Find(1);
            if(mem.MemberId == 1 )
            {
                //Member memnber = new Member
                //{
                //    LineStatus = registerVM.BasicInformation.LineStatus
                //};

                Product product = new Product
                {
                    GameCategoryId = registerVM.BasicInformation.GameCategoryId,
                    CreatorId = 1,
                    UnitPrice = registerVM.BasicInformation.UnitPrice,
                    ProductImg = registerVM.BasicInformation.ProductImg,
                    Introduction = registerVM.BasicInformation.Introduction,
                    CreatorImg = registerVM.BasicInformation.CreatorImg
                };

                //ProductPlan productPlan = new ProductPlan
                //{
                //    ProductId = 20,
                //    GameAvailableDay = registerVM.BasicInformation.GameAvailableDay,
                //    GameStartTime = registerVM.BasicInformation.GameStartTime,
                //    GameEndTime = registerVM.BasicInformation.GameEndTime
                //};

                //List<ProductPlan> productPlan = new List<ProductPlan>
                //{
                //    new ProductPlan{
                //      GameAvailableDay = registerVM.ProductPlans.GameAvailableDay,
                //     GameStartTime = registerVM.GameStartTime,
                //     GameEndTime = registerVM.GameEndTime
                //    }

                //};



                try
                {
                    //_ctx.Members.Add(memnber);
                    //_ctx.SaveChanges();
                    //_ctx.ProductPlans.Add(productPlan);
                    //_ctx.SaveChanges();
                    _ctx.Products.Add(product);
                    _ctx.SaveChanges();

                    //tran.Commit();
                    //ViewData["Message"] = "使用者儲存成功";
                    return Content("儲存成功");
                }
                catch (Exception ex)
                {

                    return Content("使用者儲存失敗:" + ex.ToString());
                }
            }
            //if(ModelState.IsValid)
            //{               

            //    Member memnber = new Member
            //    {
            //        LineStatus = registerVM.BasicInformation.LineStatus
            //    };

            //    Product product = new Product
            //    {
            //        UnitPrice = registerVM.BasicInformation.UnitPrice
            //    };

            //    //List<ProductPlan> productPlan = new List<ProductPlan>
            //    //{
            //    //    new ProductPlan{
            //    //      GameAvailableDay = registerVM.ProductPlans.GameAvailableDay,
            //    //     GameStartTime = registerVM.GameStartTime,
            //    //     GameEndTime = registerVM.GameEndTime
            //    //    }

            //    //};
            //    ProductPlan productPlan = new ProductPlan
            //    {
            //        GameAvailableDay = registerVM.BasicInformation.GameAvailableDay,
            //        GameStartTime = registerVM.BasicInformation.GameStartTime,
            //        GameEndTime = registerVM.BasicInformation.GameEndTime
            //    };

            
            //        try
            //        {
            //            _ctx.Members.Add(memnber);
            //        _ctx.SaveChanges();
            //        _ctx.Products.Add(product);
            //        _ctx.SaveChanges();
            //        _ctx.ProductPlans.Add(productPlan);
            //        _ctx.SaveChanges();
            //        //tran.Commit();
            //        ViewData["Message"] = "使用者儲存成功";
            //            return Content("儲存成功");
            //        }
            //        catch(Exception ex)
            //        {
                       
            //            ViewData["Message"] = "使用者儲存失敗" + ex.ToString();
            //        }
                   
                       
            //}

            ////GroupViewModel result = new GroupViewModel()
            ////{
            ////    BasicInformation = registerVM
            ////};
            ////return View(registerVM);
            return Content("此會員不存在");
        }
      }
}