using Build_School_Project_No_4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class ChillMeetLikeController : Controller
    {
        // GET: ChillMeetLike
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MeetLikes()
        {
            var memberGet = new MemberService();
            var members = memberGet.GetMember();

            return View(members);
        }
    }
}