using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
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

            GroupViewModel meetlikes = new GroupViewModel
            {
                MeetMatches = members
            };            
            return View(meetlikes);
        }




        public ActionResult MeetMatches()
        {
            var memberGet = new MemberService();
            var members = memberGet.GetMember();

            return View(members);
        }

    }
}