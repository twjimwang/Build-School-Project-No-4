using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class Edit_ProfileController : Controller
    {
        // GET: Edit_Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit_Profile()
        {
            //RegisterDataAnnotations register = new RegisterDataAnnotations
            //{
            //    Id = 1,
            //    Name = "聖殿祭司",
            //    Password = "myPassword",
            //    Email = "kevin@gmail.com",
            //    HomePage = "http://blog.sina.com.tw",
            //    Gender = Gender.Male,
            //    Birthday = new DateTime(1980, 6, 16),
            //    Birthday2 = new DateTime(1980, 6, 16),
            //    City = 4,
            //    Commutermode = "1",
            //    Comment = "請留下您的意見",
            //    Terms = true
            //};
            //return View(register);
            return View();
        }
    }
}