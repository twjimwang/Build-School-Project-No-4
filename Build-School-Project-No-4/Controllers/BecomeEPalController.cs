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
                ServerItems = new List<Server>(),
                ServerSelectedId = new List<int>(),
                PositionItems = new List<Position>(),
                PositionSelectedId = new List<int>(),
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

            List<Server> ServerList = new List<Server>()
            {
                new Server() { ServerId = 1, ServerName = "OCE" },
                new Server() { ServerId = 2, ServerName = "NA" },
                new Server() { ServerId = 3, ServerName = "LAN" },
                new Server() { ServerId = 4, ServerName = "BR" },
                new Server() { ServerId = 5, ServerName = "EU_West" },
                new Server() { ServerId = 6, ServerName = "EU_NorthEast" }
            };
            List<int> defaultServer = new List<int>() { 1 };

            List<Position> PositionList = new List<Position>()
            {
                new Position() { PositionId = 1, PositionName = "Top" },
                new Position() { PositionId = 2, PositionName = "Jungler" },
                new Position() { PositionId = 3, PositionName = "ADC" },
                new Position() { PositionId = 4, PositionName = "Support" },
                new Position() { PositionId = 5, PositionName = "Middle" }
            };
            List<int> defaultPosition = new List<int>() { 1 };

            List<Style> StyleList = new List<Style>()
            {
                new Style() { StyleId = 1, StyleName = "Love_Inting" },
                new Style() { StyleId = 2, StyleName = "Try_Hard" },
                new Style() { StyleId = 3, StyleName = "Hard_Stuck" },
                new Style() { StyleId = 4, StyleName = "Global_Presence" },
                new Style() { StyleId = 5, StyleName = "One_Shot" }
            };
            List<int> defaultStyle = new List<int>() { 1 };



            addgame.addgame.planset = AvailabledayList;
            addgame.addgame.ServerItems = ServerList;
            addgame.addgame.ServerSelectedId = defaultServer;
            addgame.addgame.PositionItems = PositionList;
            addgame.addgame.PositionSelectedId = defaultPosition;
            addgame.addgame.StyleItems = StyleList;
            addgame.addgame.StyleSelectedId = defaultStyle;
            //addgame.addgame.AvailabledayList = AvailabledayList;
            ////string JsonDay = JsonConvert.SerializeObject(AvailabledayList);
            ////ViewBag.JsonLocations = JsonDay;


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
                            ServerItems = new List<Server>(),
                            ServerSelectedId = new List<int>(),
                            PositionItems = new List<Position>(),
                            PositionSelectedId = new List<int>(),
                            StyleItems = new List<Style>(),
                            StyleSelectedId = new List<int>(),

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



                        //server
                        ProductServer serverDB = new ProductServer();
                        var serverSelected = registerVM.addgame.ServerSelectedId;
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


                        //position
                        ProductPosition positionDB = new ProductPosition();
                        var positionSelected = registerVM.addgame.PositionSelectedId;
                        foreach (var item in positionSelected)
                        {
                            //.username = comboUserName3.SelectedValue.ToString();
                            positionDB.ProductId = product.ProductId;

                            string selectedItem = item.ToString();
                            int val = int.Parse(selectedItem);
                            positionDB.PositionId = val;
                            ////grp.iscurrent = true;
                            //grp.dateadded = DateTime.Now;
                            _ctx.ProductPositions.Add(positionDB);
                            _ctx.SaveChanges();
                        }


                        //style
                        ProductStyle styleDB = new ProductStyle();
                        var styleSelected = registerVM.addgame.StyleSelectedId;
                        foreach (var item in styleSelected)
                        {
                            //.username = comboUserName3.SelectedValue.ToString();
                            styleDB.ProductId = product.ProductId;

                            string selectedItem = item.ToString();
                            int val = int.Parse(selectedItem);
                            styleDB.StyleId = val;
                            ////grp.iscurrent = true;
                            //grp.dateadded = DateTime.Now;
                            _ctx.ProductStyles.Add(styleDB);
                            _ctx.SaveChanges();
                        }





                        //product plan
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