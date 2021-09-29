using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Security;
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Controllers
{
    public class MembersController : Controller
    {
        private EPalContext db = new EPalContext();


        //private MemberRepository _MemberRepo;
        private MemberService _MemberService;
        private MailService _MailService;
        public MembersController()
        {
            //_MemberRepo = new MemberRepository();
            _MemberService = new MemberService();
            _MailService = new MailService();
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



        //登出Action
        [Authorize] //設定此Action須登入
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
            //return View();
            ////使用者登出
            ////Cookie名稱
            //string cookieName = WebConfigurationManager.AppSettings["CookieName"].ToString();
            ////清除Cookie
            //HttpCookie cookie = new HttpCookie(cookieName);
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //cookie.Values.Clear();
            //Response.Cookies.Set(cookie);
            ////重新導向至登入Action
            //return RedirectToAction("Login");
        }





        //宣告使用者在session的標示
        public static string LoginUserKey = "UserInfo@CCC";

        //Get: Members/Login
        //[Authorize]
        //[AllowAnonymous]
        public ActionResult Login(string Email)
        {
            //返回原頁面
            //獲取使用者登錄中的資訊
            string loginName = Request["email"];
            string password = Request["password"];

            //把使用者的資訊儲存在session中
            Session[LoginUserKey] = _MemberService.GetDataByAccount(Email);

            //獲取該頁面url的參數資訊
            string returnURL = Request.Params["HTTP_REFERER"];
            int index = returnURL.IndexOf('=');
            returnURL = returnURL.Substring(index + 1);

            //如果參數為空，則跳轉到首頁，否則切回原頁面
            if (string.IsNullOrEmpty(returnURL))
                return Redirect("/Home/HomePage");
            else
                return Redirect(returnURL);
            //return Redirect(Request.QueryString["URL"]);



            //return View();
            //return RedirectToAction("ePal", "ePal");
        }

        //Post: Members/Login
        //[Authorize]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(GroupViewModel loginMember)
        {
            //v3
            //一.未通過Model驗證
            if (!ModelState.IsValid)
            {
                return View();
            }

            //驗證登入email.密碼，回傳結果
            string ValidateStr = _MemberService.LoginCheck(loginMember.Email, loginMember.Password);

            if (String.IsNullOrEmpty(ValidateStr))
            {
                //二.通過Model驗證後, 使用HtmlEncode將帳密做HTML編碼, 去除有害的字元
                string email = HttpUtility.HtmlEncode(loginMember.Email);
                //string password = HashService.MD5Hash(HttpUtility.HtmlEncode(loginVM.Password));

                //1.建立FormsAuthenticationTicket
                var ticket = new FormsAuthenticationTicket(
                            version: 1,
                            name: loginMember.Email.ToString(), //可以放使用者Id
                            issueDate: DateTime.UtcNow,//現在UTC時間
                            expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                            isPersistent: loginMember.Remember,// 是否要記住我 true or false
                            userData: loginMember.MemberId.ToString(), //可以放使用者角色名稱
                            cookiePath: FormsAuthentication.FormsCookiePath);

                //2.加密Ticket
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);

                //3.Create the cookie.
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);

                ////4.取得original URL.
                //var url = FormsAuthentication.GetRedirectUrl(email, true);

                ////5.導向original URL
                //return Redirect(url);

                FormsAuthentication.RedirectFromLoginPage(loginMember.Email, true);
                //TempData["LoginState"] = "Welcome!";
                //return RedirectToAction("LoginResult");




                //獲取使用者登錄中的資訊
                string loginName = Request["email"];
                string password = Request["password"];

                //把使用者的資訊儲存在session中
                Session[LoginUserKey] = loginMember.Email;

                //獲取該頁面url的參數資訊
                string returnURL = Request.Params["HTTP_REFERER"];
                int index = returnURL.IndexOf('=');
                returnURL = returnURL.Substring(index + 1);

                //如果參數為空，則跳轉到首頁，否則切回原頁面
                if (string.IsNullOrEmpty(returnURL))
                    return Redirect("/Home/HomePage");
                else
                    return Redirect(returnURL);
                //return Redirect(Request.QueryString["URL"]);


            }
            else
            {
                //用TempData儲存登入訊息
                TempData["LoginState"] = "登入資訊有誤，請重新登入";
                //重新導向頁面
                return RedirectToAction("LoginResult");
            }






            //v2
            ////判斷驗證結果是否有錯誤訊息
            //if (String.IsNullOrEmpty(ValidateStr))
            //{
            //    //無錯誤訊息則登入
            //    ////先藉由Service取得登入者角色資料
            //    //string RoleData = _MemberService.GetRole(loginMember.Email);
            //    //設定JWT
            //    JwtService jwtService = new JwtService();
            //    //從Web.Config撈出資料
            //    //Cookie名稱
            //    string cookieName = WebConfigurationManager.AppSettings["CookieName"].ToString();
            //    string Token = jwtService.GenerateToken(loginMember.Email);
            //    //產生一個Cookie
            //    HttpCookie cookie = new HttpCookie(cookieName);
            //    //設定單值
            //    cookie.Value = Server.UrlEncode(Token);
            //    //寫到用戶端
            //    Response.Cookies.Add(cookie);
            //    //設定Cookie期限
            //    Response.Cookies[cookieName].Expires = DateTime.Now.AddMinutes(Convert.ToInt32(WebConfigurationManager.AppSettings["ExpireMinutes"]));

            //    //重新導向頁面
            //    //FormsAuthentication.RedirectFromLoginPage(loginMember.Email, true);
            //    //TempData["LoginState"] = User.Identity.Name;
            //    TempData["LoginState"] = "成功";

            //    //return Redirect("~/Members/LoginResult");
            //    //return RedirectToAction("ePal", "ePal");
            //    return RedirectToAction("LoginResult");
            //}
            //else
            //{
            //    //用TempData儲存登入訊息
            //    TempData["LoginState"] = "登入資訊有誤，請重新登入";
            //    //重新導向頁面
            //    return RedirectToAction("LoginResult");

            //    ////有驗證錯誤訊息，加入頁面模型中
            //    //ModelState.AddModelError("", ValidateStr);
            //    ////將資料回填至View中
            //    //return View(loginMember);
            //}




            //v1
            //var member = _MemberService.MemberLoginData()
            //.Where(m => m.Email == Email && m.Password == Password)
            //.FirstOrDefault();
            ////DM -> VM
            //GroupViewModel MemberData = new GroupViewModel
            //{
            //    Email = member.Email,
            //    Password = member.Password
            //};

            //if (MemberData == null)
            //{
            //    ViewBag.Message = "帳號密碼錯誤";
            //    //return View();
            //    return RedirectToAction("Page404", "Page404");
            //}
            ////Session["loginEmail"] = member.Email;
            ////Session["WelCome"] = member.Email + "歡迎光臨";
            //FormsAuthentication.RedirectFromLoginPage(Email, true);
            //return RedirectToAction("RecommenedController", "Recommend");
            ////return View();

        }

        //[Authorize]
        //登入結果
        public ActionResult LoginResult()
        {
            
            return View();
        }








        //[AllowAnonymous]
        //Get:Members/Register
        public ActionResult Register()
        {
            return View();
        }

        //Post:Members/Register
        //[AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(GroupViewModel newMember)
        {
            MemberViewModel mem = new MemberViewModel();
            //判斷頁面資料是否都經過驗證
            if (ModelState.IsValid)
            {
                ////將頁面資料中的密碼欄位填入
                //newMember.MemberDM.Password = newMember.Password;
                //取得信箱驗證碼
                string AuthCode = _MailService.GetValidateCode();
                ////將信箱驗證碼填入
                //newMember.MemberDM.AuthCode = AuthCode;


                //註冊成為新會員
                var member = _MemberService.MemberRigisterData()
                            .Where(m => m.Email == newMember.Email)
                            .FirstOrDefault();
                if (member == null)
                {
                    //將密碼Hash
                    newMember.Password = _MemberService.HashPassword(newMember.Password);

                    //GroupViewModel -> DM
                    Member emp = new Member
                    {
                        Email = newMember.Email,
                        Password = newMember.Password,
                        AuthCode = AuthCode
                    };
                    db.Members.Add(emp);

                    db.SaveChanges();
                    //using (var tran = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        db.Members.Add(emp);
                    //        //db.Members.Add(new Member { RegistrationDate = DateTime.Now});
                    //        db.SaveChanges();
                    //        //ViewData["Message"] = "使用者註冊成功";
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        tran.Rollback();
                    //        TempData["RegisterState"] = "註冊失敗" + ex.ToString();
                    //        return RedirectToAction("RegisterResult");
                    //    }

                    //    //return RedirectToAction("Edit_Profile", "Edit_Profile");
                    //    //return RedirectToAction("HomePage", "Home");

                    //    ////轉向RegisterResult頁面呈現註冊結果，但路由不變動
                    //    //return View("RegisterResult");
                    //}
                }
                else
                {
                    //ViewBag.Message = "帳號己有人使用";
                    //return RedirectToAction("ePal", "ePal");
                    //用TempData儲存註冊訊息
                    TempData["RegisterState"] = "此帳號己有人使用，請重新註冊";
                    //重新導向頁面
                    return RedirectToAction("RegisterResult");
                }



                //取得驗證信範本
                string TempMail = System.IO.File.ReadAllText(Server.MapPath("~/Views/Shared/RegisterEmailTemplate.html"));
                //宣告Email驗證用的Url
                UriBuilder ValidateUrl = new UriBuilder(Request.Url)
                {
                    Path = Url.Action("EmailValidate", "Members", new{
                        Email = newMember.Email,
                        AuthCode = AuthCode
                    })
                };
                //藉由Service將使用者資料填入驗證信範本，使用者收到驗證信後，會自動導向/Members/EmailValidate的view
                string MailBody = _MailService.GetRegisterMailBody(TempMail, newMember.Email, ValidateUrl.ToString().Replace("%3F", "?"));

                //呼叫Service寄出驗證信的方法
                _MailService.SendRegisterMail(MailBody, newMember.Email);


                //用TempData儲存註冊訊息
                TempData["RegisterState"] = "註冊成功，請到註冊信箱進行驗證";
                //重新導向頁面
                return RedirectToAction("RegisterResult");

            }

            //未經驗證清空密碼相關欄位
            newMember.Password = null;
            ////將資料回填至view中
            //return view(newmember);
            //return RedirectToAction("HomePage", "Home");
            //用TempData儲存註冊訊息
            TempData["RegisterState"] = "註冊Email或密碼資訊不符要求，請重新註冊";
            //重新導向頁面
            return RedirectToAction("RegisterResult");

        }

        //註冊結果
        public ActionResult RegisterResult()
        {
            return View();
        }

        //接收驗證信連結傳進來的Action
        public ActionResult EmailValidate(string Email, string AuthCode)
        {
            //用ViewData儲存，使用Service進行信箱驗證後的結果訊息
            ViewData["EmailValidate"] = _MemberService.EmailValidate(Email, AuthCode);
            return View();
        }





        //備份
        ////Get: Members/Login
        //public ActionResult Login()
        //{
        //    return View();
        //}
        ////Post: Members/Login
        //[HttpPost]
        //public ActionResult Login(string Email, string Password)
        //{
        //    var member = _MemberService.MemberLogin()
        //                .Where(m => m.Email == Email && m.Password == Password)
        //                .FirstOrDefault();

        //    GroupViewModel MemberData = new GroupViewModel
        //    {
        //        MemberLogin = member
        //    };

        //    if (MemberData == null)
        //    {
        //        ViewBag.Message = "帳號密碼錯誤";
        //        //return View();
        //        return RedirectToAction("Page404", "Page404");
        //    }
        //    //Session["loginEmail"] = member.Email;
        //    //Session["WelCome"] = member.Email + "歡迎光臨";
        //    FormsAuthentication.RedirectFromLoginPage(Email, true);
        //    //return RedirectToAction("ePal", "ePal");
        //    return RedirectToAction("RecommenedController", "Recommend");
        //    //return RedirectToAction("test");
        //    //return View();
        //}

        ////Get:Members/Register
        //public ActionResult Register2()
        //{
        //    return View();
        //}
        ////Post:Members/Register
        //[HttpPost]
        //public ActionResult Register2([Bind(Include = "Email, Password")] MemberViewModel newMember)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        //return View(newMember);
        //        return View();
        //    }
        //    var member = _MemberService.MemberRigisterData()
        //                .Where(m => m.Email == newMember.Email)
        //                .FirstOrDefault();
        //    if (member == null)
        //    {
        //        //GroupViewModel meetlikes = new GroupViewModel
        //        //{
        //        //    MeetMatches = members
        //        //};

        //        //VM -> DM
        //        Member emp = new Member
        //        {
        //            Email = newMember.Email,
        //            Password = newMember.Password
        //        };

        //        db.Members.Add(emp);
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
