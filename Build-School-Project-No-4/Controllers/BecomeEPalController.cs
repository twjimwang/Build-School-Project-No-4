using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class becomeepalController : Controller
    {
        private readonly EPalContext _ctx;

        public becomeepalController()
        {
            _ctx = new EPalContext();
        }

        // GET: BeComeEPal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BecomeEPalPage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult addgame()
        {
            GroupViewModel addgame = new GroupViewModel()
            {
                addgame = new AddgameViewModel()
            };

            AddgameViewModel addVM = new AddgameViewModel()
            {
                planset = new List<ProductPlan>(),

                ServerItems = new List<Server>()
                {
                    new Server() { ServerName = "OCE", ServerId = 1 },
                    new Server() { ServerName = "NA", ServerId = 2 },
                    new Server() { ServerName = "LAN", ServerId = 3 },
                    new Server() { ServerName = "BR", ServerId = 4 },
                    new Server() { ServerName = "EU_West", ServerId = 5 },
                    new Server() { ServerName = "EU_NorthEast", ServerId = 6 }
                },
                ServerId = new List<int>() { 1 }

            };

            List<ProductPlan>  AvailabledayList = new List<ProductPlan>()
            {
                new ProductPlan{ GameAvailableDay = "Monday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Tuesday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Wednesday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Thursday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Friday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Saterday", GameStartTime = null, GameEndTime=null },
                new ProductPlan{ GameAvailableDay = "Sunday", GameStartTime = null, GameEndTime=null }
            };

            addgame.addgame.planset = AvailabledayList;
            //addgame.addgame.AvailabledayList = AvailabledayList;
            ////string JsonDay = JsonConvert.SerializeObject(AvailabledayList);
            ////ViewBag.JsonLocations = JsonDay;
            ///


            return View(addgame);
            //return View("_GameDayPartial", addgame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addgame(GroupViewModel registerVM)
        {
            var mem = _ctx.Members.Find(1);
            if (mem.MemberId == 1)
            {
                using (var tran = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        AddgameViewModel add = new AddgameViewModel()
                        {
                            planset = new List<ProductPlan>(),
                            ServerId = new List<SelectListItem>(),
                            StyleId = new List<StyleIdEum>(),
                            PositionId = new List<ProductPosition>()
                        };

                        //VM -> DM
                        Product product = new Product
                        {
                            GameCategoryId = (int)registerVM.addgame.GameCategoryId,
                            CreatorId = 1,
                            UnitPrice = registerVM.addgame.UnitPrice,
                            ProductImg = registerVM.addgame.ProductImg,
                            Introduction = registerVM.addgame.Introduction,
                            CreatorImg = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/best-girl-cat-names-1606245046.jpg",
                            //CreatorImg = registerVM.addgame.CreatorImg,
                            RecommendationVoice = registerVM.addgame.RecommendationVoice,
                            RankId = (int)registerVM.addgame.RankId
                        };

                        _ctx.Products.Add(product);
                        _ctx.SaveChanges();


                        //List<ServerEum> server = new List<ServerEum>
                        //{
                        //    ServerId = registerVM.addgame.ServerId
                        //};


                        ProductServer serverDB = new ProductServer();
                        var serverSelected = registerVM.addgame.ServerId;
                        foreach (var item in serverSelected)
                        {
                            //.username = comboUserName3.SelectedValue.ToString();
                            serverDB.ProductId = product.ProductId;

                            string selectedItem = item.ToString();
                            int val = int.Parse(selectedItem);
                            serverDB.ServerId = val;
                            ////grp.iscurrent = true;
                            //grp.dateadded = DateTime.Now;
                            _ctx.ProductServers.Add(serverDB);
                            _ctx.SaveChanges();                            
                        }


                        //var serverlist = registerVM.addgame.ServerId;

                        //foreach (var server in serverlist)
                        //{
                        //    ProductServer serverDB = new ProductServer
                        //    {
                        //        ProductId = product.ProductId,
                        //        ServerId = server
                        //    };
                        //};
                        //_ctx.ProductServers.AddRange(serverDB);
                        //_ctx.SaveChanges();






                        //List<ProductPlan> planList = new List<ProductPlan>();
                        //foreach (var item in registerVM.addgame.planset)
                        //{
                        //    planList.Add(new ProductPlan
                        //    {
                        //        GameAvailableDay = pro.GameAvailableDay,
                        //        GameStartTime = pro.GameStartTime,
                        //        GameEndTime = pro.GameEndTime
                        //    });
                        //}
                        //_ctx.ProductPlans.Add(productPlan);
                        //_ctx.SaveChanges();

                        //var result = registerVM.addgame.planset.Where(x => x.GameStartTime != null && x.GameEndTime != null);
                        ////var result = proplan.GameStartTime;
                        //List<ProductPlan> planList = new List<ProductPlan>();
                        //foreach (var item in result)
                        //{
                        //    planList.Add(new ProductPlan
                        //    {
                        //        GameAvailableDay = item.GameAvailableDay,
                        //        GameStartTime = item.GameStartTime,
                        //        GameEndTime = item.GameEndTime
                        //    });
                        //}





                        //List<ProductPlanSet> productplan = new List<ProductPlanSet>
                        //{
                        //    new ProductPlanSet()
                        //    {
                        //    }

                        //};

                        //add.planset = registerVM.planset.;
                        //List<ProductPlan> planList = new List<ProductPlan>();
                        //foreach (var plan in )
                        //{
                        //    planList.Add(new ProductPlan { 

                        //        ProductId = plan.ProductId,
                        //        GameAvailableDay = registerVM.addgame.GameAvailableDay,
                        //        GameStartTime = plan.GameStartTime,
                        //        GameEndTime = plan.GameEndTime
                        //    });

                        //};

                        //        ProductPlan productPlan = new ProductPlan
                        //        {
                        //            GameAvailableDay = registerVM.addgame.GameAvailableDay,
                        //            GameStartTime = registerVM.addgame.GameStartTime,
                        //            GameEndTime = registerVM.addgame.GameEndTime
                        //        };






                        //List<ProductStyle> styleName = new List<ProductStyle>
                        //{
                        //    new ProductStyle
                        //    {
                        //        StyleId = (int)registerVM.addgame.StyleId

                        //    }
                        //};

                        //List<StyleIdEum> stylelist = new List<StyleIdEum>()
                        //{

                        //     = new StyleIdEum();                       

                        //};

                        //foreach (var style in stylelist)
                        //{
                        //    stylelist.Add(new ProductStyle
                        //    {
                        //        ProductId = style.ProductId,
                        //        StyleId = style.StyleId
                        //    });
                        //};


                        //List<ProductStyle> stylelist = registerVM.addgame.StyleId;
                        //foreach (var style in stylelist)
                        //{
                        //    stylelist.Add(new ProductStyle
                        //    {
                        //        ProductId = style.ProductId,
                        //        StyleId = style.StyleId
                        //    });
                        //};




                        List<ProductPosition> positionlist = registerVM.addgame.PositionId;
                        foreach (var position in positionlist)
                        {
                            positionlist.Add(new ProductPosition
                            {
                                ProductId = position.ProductId,
                                PositionId = position.PositionId
                            });
                        };




                        
                        
                        //_ctx.ProductStyles.AddRange(stylelist);
                        _ctx.ProductPositions.AddRange(positionlist);

                        _ctx.SaveChanges();
                        tran.Commit();

                        //ViewData["Message"] = "使用者儲存成功";
                        return Content("創建商品成功");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return Content("創建商品失敗:" + ex.ToString());
                    }
                }
            }

            return Content("此會員不存在");
        }
    }
}