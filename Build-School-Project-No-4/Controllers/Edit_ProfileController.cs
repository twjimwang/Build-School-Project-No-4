using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class Edit_ProfileController : Controller
    {
        private EPalContext _ctx = new EPalContext();

        //private MemberRepository _MemberRepo;
        private MemberService _MemberService;

        public Edit_ProfileController()
        {
            //_MemberRepo = new MemberRepository();
            _MemberService = new MemberService();
        }

        // GET: Edit_Profile
        public ActionResult Index()
        {
            return View();
        }




        
        public ActionResult Edit_Profile(int? Id)
        {
            //檢查是否有員工Id的判斷
            if (Id == null)
            {
                return Content("查無此資料, 請提供會員ID!");
            }
            //以Id找尋員工資料
            Member emp = _ctx.Members.Find(Id);
            //如果沒有找到員工，回傳HttpNotFound
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);

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
            //return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit_Profile([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] MemberInfoViewModel MemberInfo)
        //{

        //    //GroupViewModel -> DM
        //    //MemberInfoViewModel -> DM
        //    Member emp = new Member
        //    {
        //        Email = MemberInfo.Email,
        //        Password = newMember.Password,
        //        AuthCode = AuthCode
        //    };
        //    db.Members.Add(emp);
        //    db.SaveChanges();


        //    //用ModelState.IsValid判斷資料是否通過驗證
        //    if (ModelState.IsValid)
        //    {
        //        //將emp這個Entity狀態設為Modified,
        //        //當SaveChanges()執行時,會向SQL Server發出Update陳述式命令
        //        db.Entry(emp).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(emp);
        //}
    }
}