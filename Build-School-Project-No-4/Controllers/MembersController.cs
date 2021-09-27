﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Controllers
{
    public class MembersController : Controller
    {
        private EPalContext db = new EPalContext();


        //private MemberRepository _MemberRepo;
        private MemberService _MemberService;
        public MembersController()
        {
            //_MemberRepo = new MemberRepository();
            _MemberService = new MemberService();
        }

        public ActionResult CreateSeed()
        {
            //_MemberRepo.WriteDataToDB();

            return Content("寫入資料庫成功!");
        }

        public ActionResult ReadMember()
        {
            List<MemberViewModel> MemberData = _MemberService.GetMember();

            return View(MemberData);
        }

        public string test()
        {
            return "<p>" + User.Identity.Name + "您好<p>";
        }


        //Get: Members/Login
        public ActionResult Login()
        {
            return View();
        }
        //Post: Members/Login
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {            
            var member = _MemberService.GetMember()
                        .Where(m => m.Email == Email && m.Password == Password)
                        .FirstOrDefault();

            GroupViewModel MemberData = new GroupViewModel
            {
                MemberData = member
            };

            if (MemberData == null)
            {
                ViewBag.Message = "帳號密碼錯誤";
                //return View();
                return RedirectToAction("Page404", "Page404");
            }
            //Session["loginEmail"] = member.Email;
            //Session["WelCome"] = member.Email + "歡迎光臨";
            FormsAuthentication.RedirectFromLoginPage(Email, true);
            //return RedirectToAction("ePal", "ePal");
            return RedirectToAction("RecommenedController", "Recommend");
            //return RedirectToAction("test");
            //return View();
        }



        //Get:Members/Register
        public ActionResult Register()
        {
            return View();
        }
        //Post:Members/Register
        [HttpPost]
        public ActionResult Register([Bind(Include ="Email, Password")] MemberViewModel newMember)
        {
            if (ModelState.IsValid == false)
            {
                //return View(newMember);
                return View();
            }
            var member = _MemberService.GetMember()
                        .Where(m => m.Email == newMember.Email)
                        .FirstOrDefault();
            if (member == null)
            {
                //GroupViewModel meetlikes = new GroupViewModel
                //{
                //    MeetMatches = members
                //};

                Member emp = new Member
                {
                   Email = newMember.Email,
                   Password = newMember.Password
                };

                db.Members.Add(emp);
                //db.Members.Add(new Member { RegistrationDate = DateTime.Now});
                db.SaveChanges();
                //return RedirectToAction("Edit_Profile", "Edit_Profile");
                return RedirectToAction("HomePage", "Home");
            }

            ViewBag.Message = "帳號己有人使用";
            return RedirectToAction("ePal", "ePal");



        }




        ////Get: Members/Login
        //public ActionResult Login()
        //{
        //    return View();
        //}
        ////Post: Members/Login
        //[HttpPost]
        //public ActionResult Login(string Email, string Password)
        //{
        //    var member = db.Members
        //        .Where(m => m.Email == Email && m.Password == Password)
        //        .FirstOrDefault();
        //    if (member == null)
        //    {
        //        ViewBag.Message = "帳號密碼錯誤";
        //        return View();
        //    }
        //    Session["loginEmail"] = member.Email;
        //    //Session["WelCome"] = member.Email + "歡迎光臨";
        //    FormsAuthentication.RedirectFromLoginPage(Email, true);
        //    //return RedirectToAction("ePal", "ePal");
        //    return RedirectToAction("RecommenedController", "Recommend");
        //    //return RedirectToAction("test");
        //    //return View();
        //}


        ////Get:Members/Register
        //public ActionResult Register()
        //{
        //    return View();
        //}
        ////Post:Members/Register
        //[HttpPost]
        //public ActionResult Register(Member newMember)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View();
        //    }
        //    var member = db.Members
        //        .Where(m => m.Email == newMember.Email)
        //        .FirstOrDefault();
        //    if (member == null)
        //    {
        //        db.Members.Add(newMember);
        //        //db.Members.Add(new Member { RegistrationDate = DateTime.Now});
        //        db.SaveChanges();
        //        //return RedirectToAction("Edit_Profile", "Edit_Profile");
        //        return RedirectToAction("HomePage", "Home");
        //    }

        //    ViewBag.Message = "帳號己有人使用";
        //    return RedirectToAction("ePal", "ePal");
        //}








        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.City).Include(m => m.Language);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName");
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,MemberName,RegistrationDate,Email,Password,Phone,Country,CityId,Gender,BirthDay,TimeZone,LanguageId,Bio,ProfilePicture,LineStatus")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,MemberName,RegistrationDate,Email,Password,Phone,Country,CityId,Gender,BirthDay,TimeZone,LanguageId,Bio,ProfilePicture,LineStatus")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
