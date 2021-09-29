using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        //public ActionResult Edit_Profile()
        //{
        //    return View();
        //}


        [HttpGet]
        public ActionResult Edit_Profile(int? Id)
        {            
            if (Id == null)
            {
                return Content("查無此資料, 請提供會員ID!");
            }
            
            Member emp = _ctx.Members.Find(Id);
            //如果沒有，回傳HttpNotFound
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit_Profile(MemberInfoViewModel MemberInfo)
        public ActionResult Edit_Profile(GroupViewModel EditMember)
        {
            //GroupViewModel -> DM
            //MemberInfoViewModel -> DM
            Member emp = new Member
            {
                MemberName = EditMember.MemberInfo.MemberName,
                Phone = EditMember.MemberInfo.Phone,
                Country = EditMember.MemberInfo.Country,
                Gender = EditMember.MemberInfo.Gender, 
                BirthDay = EditMember.MemberInfo.BirthDay,
                TimeZone = EditMember.MemberInfo.TimeZone,
                LanguageId = EditMember.MemberInfo.LanguageId,
                Bio = EditMember.MemberInfo.Bio,
                Password = EditMember.MemberInfo.Password
            };

            //emp.MemberName = HttpUtility.HtmlEncode(emp.MemberName);
            //emp.Phone = HttpUtility.HtmlEncode(emp.Phone);
            //emp.Country = HttpUtility.HtmlEncode(emp.Country);
            //emp.Gender = Convert.ToInt32(HttpUtility.HtmlEncode(emp.Gender));
            //emp.BirthDay = Convert.ToDateTime(HttpUtility.HtmlEncode(emp.BirthDay));
            //emp.TimeZone = Convert.ToInt32(HttpUtility.HtmlEncode(emp.TimeZone));
            //emp.LanguageId = Convert.ToInt32(HttpUtility.HtmlEncode(emp.LanguageId));
            //emp.Bio = HttpUtility.HtmlEncode(emp.Bio);
            //emp.Password = HttpUtility.HtmlEncode(emp.Password);


            using (var tran = _ctx.Database.BeginTransaction())
            {
                try
                {
                    _ctx.Entry(emp).State = EntityState.Modified;
                    _ctx.SaveChanges();
                    tran.Commit();

                    return Content("寫入資料庫成功");
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    return Content("寫入資料庫失敗:" + ex.ToString());
                }
            }




            //_ctx.Members.Add(emp);
            //_ctx.SaveChanges();


            ////用ModelState.IsValid判斷資料是否通過驗證
            //if (ModelState.IsValid)
            //{
            //    //將emp這個Entity狀態設為Modified,
            //    //當SaveChanges()執行時,會向SQL Server發出Update陳述式命令
            //    db.Entry(emp).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(emp);

        }
    }
}