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
using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System.Configuration;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace Build_School_Project_No_4.Controllers
{
    public class MembersController : Controller
    {
        private EPalContext db = new EPalContext();
        private MemberService _MemberService;
        private MailService _MailService;
        public MembersController()
        {
            _MemberService = new MemberService();
            _MailService = new MailService();
        }


        //取得登入者的memberId
        public string GetMemberId()
        {
            var cookie = HttpContext.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            
            string userid = "";
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                userid = ticket.UserData;
                return userid;
            }
            return null;
        }




        //[Authorize]
        public ActionResult profile()
        {
            int memberId;
            bool IsSuccess = true;
            string memId = GetMemberId();
            IsSuccess = int.TryParse(memId, out memberId);

            if(!IsSuccess)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //throw new NotImplementedException();
            }

            try
            {
                var profiles = new ProfileEpalService();
                var profileGetAll = profiles.GetProfiles(memberId);

                GroupViewModel profileContent = new GroupViewModel
                {
                    Profiles = profileGetAll
                };
                return View(profileContent);

            }
            catch(Exception ex)
            {
                return Content("失敗:" + ex.ToString());
            }           

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



        // GET: Cloudinary
        public ActionResult ImageUpload()
        {
            //return PartialView("_AvatarPartial");
            return View();
        }
        [HttpPost]
        public bool SaveImageToServer()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];
                string _apiKey = ConfigurationManager.AppSettings["CloudinaryAPIKey"];
                string _apiSecret = ConfigurationManager.AppSettings["CloudinarySecretKey"];
                string _cloud = ConfigurationManager.AppSettings["CloudinaryAccount"];
                string uploadedImageUrl = string.Empty;
                string fname = string.Empty;
                var myAccount = new Account { ApiKey = _apiKey, ApiSecret = _apiSecret, Cloud = _cloud };
                Cloudinary _cloudinary = new Cloudinary(myAccount);
                _cloudinary.Api.Secure = true;


                //if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                //{
                //    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                //    fname = testfiles[testfiles.Length - 1];
                //}
                //else
                //{
                //    fname = Regex.Replace(file.FileName.Trim(), @"[^0-9a-zA-Z.]+", "_");
                //}

                using (Image img = Image.FromStream(file.InputStream))
                {
                    int imageHeight = 0;
                    int imageWidth = 0;
                    if (img.Height > 320)
                    {
                        var ratio = (double)img.Height / 320;
                        imageHeight = (int)(img.Height / ratio);
                        imageWidth = (int)(img.Width / ratio);
                    }
                    else
                    {
                        imageHeight = img.Height;
                        imageWidth = img.Width;
                    }
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, file.InputStream),
                        Folder = "MyImages",
                        Transformation = new Transformation().Width(imageWidth).Height(imageHeight).Crop("thumb").Gravity("face")
                    };
                    
                    
                    var uploadResult = _cloudinary.Upload(uploadParams);
                    
                    //Failed to deserialize response with status code: NotFound cloudinary
                    //cloudinary Unexpected character encountered while parsing value: <.Path '', line 0, position 0.

                    //uploadedImageUrl = uploadResult?.SecureUri?.AbsoluteUri;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpPost]
        public ActionResult SaveAvatarToDB(int MemberId, string ProfilePicture)
        {

            Members member = db.Members.First(x => x.MemberId == MemberId);

            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    member.ProfilePicture = ProfilePicture;
                    db.SaveChanges();
                    tran.Commit();

                    return Content("寫入資料庫成功");
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    return Content("寫入資料庫失敗:" + ex.ToString());
                }
            }
        }



        [HttpGet]
        [Authorize]
        public ActionResult GetAvatar()
        {
            Members emp = db.Members.Find(int.Parse(GetMemberId()));
            if (emp == null)
            {
                return HttpNotFound();
            }

            GroupViewModel groupMember = new GroupViewModel()
            {
                MemberInfo = new MemberInfoViewModel()
            };

            //DM -> MemberInfoViewModel -> GroupViewModel
            MemberInfoViewModel MemberInfo = new MemberInfoViewModel()
            {
                //MemberId = emp.MemberId,
                ProfilePicture = emp.ProfilePicture
            };

            groupMember.MemberInfo = MemberInfo;
            ViewBag.Avatar = groupMember;
            //TempData["Avatar"] = groupMember;


            //return View("EditProfile");
            return View("EditProfile");
        }


        [HttpGet]
        [Authorize]
        public ActionResult GetAvatarForLayout()
        {
            Members emp = db.Members.Find(int.Parse(GetMemberId()));
            if (emp == null)
            {
                return HttpNotFound();
            }

            GroupViewModel groupMember = new GroupViewModel()
            {
                MemberInfo = new MemberInfoViewModel()
            };

            //DM -> MemberInfoViewModel -> GroupViewModel
            MemberInfoViewModel MemberInfo = new MemberInfoViewModel()
            {
                //MemberId = emp.MemberId,
                ProfilePicture = emp.ProfilePicture
            };

            groupMember.MemberInfo = MemberInfo;
            ViewBag.Avatar = groupMember;

            return View("_Layout_nofooter", groupMember);
        }






        [HttpGet]
        [Authorize]
        public ActionResult EditProfile()
        {
            Members emp = db.Members.Find(int.Parse(GetMemberId()));
            if (emp == null)
            {
                return HttpNotFound();
            }

            if(emp.Gender == null)
            {
                emp.Gender = 0;
            }
            if (emp.LanguageId == null)
            {
                emp.LanguageId = 0;
            }

            GroupViewModel groupMember = new GroupViewModel()
            {
                MemberInfo = new MemberInfoViewModel()
            };

            //DM -> MemberInfoViewModel -> GroupViewModel
            MemberInfoViewModel MemberInfo = new MemberInfoViewModel()
            {
                MemberId = emp.MemberId,
                MemberName = emp.MemberName,
                Phone = emp.Phone,
                Country = emp.Country,
                Gender = (Genders)emp.Gender,
                BirthDay = emp.BirthDay,
                TimeZone = emp.TimeZone,
                LanguageId = (LanguageCategories)emp.LanguageId,
                Bio = emp.Bio,
                Email = emp.Email,
                Password = emp.Password,
                ProfilePicture = emp.ProfilePicture
            };

            groupMember.MemberInfo = MemberInfo;
            ViewBag.Avatar = groupMember.MemberInfo.ProfilePicture;
                        

            return View("EditProfile", groupMember);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "MemberInfo")] GroupViewModel EditMember)
        {   
            //將密碼Hash
            EditMember.MemberInfo.Password = _MemberService.HashPassword(EditMember.MemberInfo.Password);

            //GroupViewModel -> MemberInfoViewModel -> DM
            Members emp = new Members
            {
                MemberId = EditMember.MemberInfo.MemberId,
                MemberName = EditMember.MemberInfo.MemberName,
                Phone = EditMember.MemberInfo.Phone,
                Country = EditMember.MemberInfo.Country,
                Gender = (int)EditMember.MemberInfo.Gender,
                BirthDay = EditMember.MemberInfo.BirthDay,
                TimeZone = EditMember.MemberInfo.TimeZone,
                LanguageId = (int)EditMember.MemberInfo.LanguageId,
                Bio = EditMember.MemberInfo.Bio,
                Email = EditMember.MemberInfo.Email,
                Password = EditMember.MemberInfo.Password
            };

            if (ModelState.IsValid)
            {            
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                        tran.Commit();

                        return Content("寫入資料庫成功");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        return Content("寫入資料庫失敗:" + ex.ToString());
                    }
                }

            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(EditMember);
        }





        [Authorize] 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            //獲取該頁面url的參數資訊
            string returnURL = Request.Params["HTTP_REFERER"];
            int index = returnURL.IndexOf('=');
            returnURL = returnURL.Substring(index + 1);
            //如果參數為空，則跳轉到首頁，否則切回原頁面
            if (string.IsNullOrEmpty(returnURL))
                return Redirect("/Home/HomePage");
            else
                return Redirect(returnURL);
        }





        //宣告使用者在session標示
        public static string LoginUserKey = "UserInfo@CCC";

        //Get: Members/Login
        //[Authorize]
        //[AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //Post: Members/Login
        //[Authorize]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(GroupViewModel loginMember)
        {
            //未通過Model驗證
            if (!ModelState.IsValid)
            {
                return View();
            }

            //驗證登入email.密碼，回傳結果
            string ValidateStr = _MemberService.LoginCheck(loginMember.MemberLogin.Email, loginMember.MemberLogin.Password);

            Members user = _MemberService.GetDataByAccount(loginMember.MemberLogin.Email);

            if (String.IsNullOrEmpty(ValidateStr))
            {
                //通過Model驗證後, 使用HtmlEncode將帳密做HTML編碼, 去除有害的字元
                string email = HttpUtility.HtmlEncode(loginMember.MemberLogin.Email);
                //string password = HashService.MD5Hash(HttpUtility.HtmlEncode(loginVM.Password));

                //建立FormsAuthenticationTicket
                var ticket = new FormsAuthenticationTicket(
                            version: 1,
                            name: user.Email.ToString(), //可以放使用者Id
                            issueDate: DateTime.UtcNow,//現在UTC時間
                            expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                            isPersistent: loginMember.MemberLogin.Remember,// 是否要記住我 true or false
                            userData: user.MemberId.ToString(), //可以放使用者角色名稱
                            cookiePath: FormsAuthentication.FormsCookiePath);

                //加密Ticket
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);

                //Create the cookie.
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);

                ////4.取得original URL.
                //var url = FormsAuthentication.GetRedirectUrl(email, true);

                ////5.導向original URL
                //return Redirect(url);

                //FormsAuthentication.RedirectFromLoginPage(loginMember.Email, true);
                ////TempData["LoginState"] = "Welcome!";
                ////return RedirectToAction("LoginResult");



                //反回原頁面
                //獲取使用者登錄中的資訊
                string loginName = Request["email"];
                string password = Request["password"];

                //把使用者的資訊儲存在session中
                Session[LoginUserKey] = loginMember.MemberLogin.Email;

                //獲取該頁面url的參數資訊
                string returnURL = Request.Params["HTTP_REFERER"];
                int index = returnURL.IndexOf('=');
                returnURL = returnURL.Substring(index + 1);

                //如果參數為空，則跳轉到首頁，否則切回原頁面
                if (string.IsNullOrEmpty(returnURL))
                    return Redirect("/Home/HomePage");
                else
                    return Redirect(returnURL);
            }
            else
            {
                //用TempData儲存登入訊息
                TempData["LoginState"] = ValidateStr;
                //重新導向頁面
                return RedirectToAction("LoginResult");
            }

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
            if (ModelState.IsValid)
            {
                //取得信箱驗證碼
                string AuthCode = _MailService.GetValidateCode();

                //註冊成為新會員
                var member = _MemberService.MemberRigisterData()
                            .Where(m => m.Email == newMember.MemberRegister.Email)
                            .FirstOrDefault();
                if (member == null)
                {
                    //將密碼Hash
                    newMember.MemberRegister.Password = _MemberService.HashPassword(newMember.MemberRegister.Password);

                    //GroupViewModel -> DM
                    Members emp = new Members
                    {
                        Email = newMember.MemberRegister.Email,
                        Password = newMember.MemberRegister.Password,
                        AuthCode = AuthCode
                    };
                    db.Members.Add(emp);
                    db.SaveChanges();
                }
                else
                {
                    //用TempData儲存註冊訊息
                    TempData["RegisterState"] = "此帳號己有人使用，請重新註冊";
                    //重新導向頁面
                    return RedirectToAction("RegisterResult");
                }


                string TempMail = System.IO.File.ReadAllText(Server.MapPath("~/Views/Shared/RegisterEmailTemplate.html"));

                UriBuilder ValidateUrl = new UriBuilder(Request.Url)
                {
                    Path = Url.Action("EmailValidate", "Members", new{
                        Email = newMember.MemberRegister.Email,
                        AuthCode = AuthCode
                    })
                };

                string MailBody = _MailService.GetRegisterMailBody(TempMail, newMember.MemberRegister.Email, ValidateUrl.ToString().Replace("%3F", "?"));

                _MailService.SendRegisterMail(MailBody, newMember.MemberRegister.Email);

                //用TempData儲存註冊訊息
                TempData["RegisterState"] = "註冊成功，請到註冊信箱進行驗證";
                //重新導向頁面
                return RedirectToAction("RegisterResult");

            }

            //未經驗證清空密碼相關欄位
            newMember.MemberRegister.Password = null;

            //獲取使用者登錄中的資訊
            string loginName = Request["email"];
            string password = Request["password"];

            //獲取該頁面url的參數資訊
            string returnURL = Request.Params["HTTP_REFERER"];
            int index = returnURL.IndexOf('=');
            returnURL = returnURL.Substring(index + 1);

            //如果參數為空，則跳轉到首頁，否則切回原頁面
            if (string.IsNullOrEmpty(returnURL))
                return Redirect("/Home/HomePage");
            else
                return Redirect(returnURL);

        }

        //註冊結果
        public ActionResult RegisterResult()
        {
            return View();
        }

        //接收驗證信連結傳進來的Action
        public ActionResult EmailValidate(string Email, string AuthCode)
        {
            ViewData["EmailValidate"] = _MemberService.EmailValidate(Email, AuthCode);
            return RedirectToAction("ePal", "ePal");
        }


























        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.CityId).Include(m => m.Language);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members member = db.Members.Find(id);
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
            ViewBag.LanguageId = new SelectList(db.Language, "LanguageId", "LanguageName");
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,MemberName,RegistrationDate,Email,Password,Phone,Country,CityId,Gender,BirthDay,TimeZone,LanguageId,Bio,ProfilePicture,LineStatus")] Members member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Language, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Language, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,MemberName,RegistrationDate,Email,Password,Phone,Country,CityId,Gender,BirthDay,TimeZone,LanguageId,Bio,ProfilePicture,LineStatus")] Members member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", member.CityId);
            ViewBag.LanguageId = new SelectList(db.Language, "LanguageId", "LanguageName", member.LanguageId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members member = db.Members.Find(id);
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
            Members member = db.Members.Find(id);
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
