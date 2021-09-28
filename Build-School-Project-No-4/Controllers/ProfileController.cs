using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProFile()
        {
            var profiles = new ProfileEpalService();
            var profileGetAll = profiles.GetProfiles();

            GroupViewModel profileContent = new GroupViewModel
            {
                Profiles = profileGetAll
            };
            return View(profileContent);
        }

    }
}