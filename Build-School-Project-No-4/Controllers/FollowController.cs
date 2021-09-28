using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class FollowController : Controller
    {
        // GET: Follow
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Followings()
        {
            var memberGet = new FollowService();
            var members = memberGet.GetFollowMember();

            GroupViewModel followSelectMembers = new GroupViewModel
            {
                FollowMembers = members
            };


            return View(followSelectMembers);
        }

    }
}