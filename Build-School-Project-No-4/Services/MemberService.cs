using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Build_School_Project_No_4.Services
{
    public class MemberService
    {
        //private MemberRepository _MemberRepo;
        private readonly Repository _Repo;
        public MemberService()
        {
            _Repo = new Repository();            
        }


        public List<MemberViewModel> GetMember()
        {
            List<Member> members = _Repo.GetAll<Member>().ToList();

            List<MemberViewModel> result = new List<MemberViewModel>();
            foreach (var item in members)
            {
                result.Add(new MemberViewModel{
                    MemberId = item.MemberId,
                    MemberName = item.MemberName,
                    RegistrationDate = item.RegistrationDate,
                    Email = item.Email,
                    Password = item.Password,
                    Phone = item.Phone,
                    Country = item.Country,
                    CityId = item.CityId,
                    Gender = item.Gender,
                    BirthDay = item.BirthDay,
                    TimeZone = item.TimeZone,
                    LanguageId = item.LanguageId,
                    Bio = item.Bio,
                    ProfilePicture = item.ProfilePicture,
                    LineStatus = item.LineStatus,
                });
            }
            return result;
        }

        //public List<MemberInfoViewModel> EditMemberInfo()
        //{
        //    List<Member> members = _Repo.GetAll<Member>().ToList();

        //    List<MemberInfoViewModel> result = new List<MemberInfoViewModel>();
        //    foreach (var item in members)
        //    {
        //        result.Add(new MemberInfoViewModel
        //        {
        //            MemberId = item.MemberId,
        //            MemberName = item.MemberName,
        //            RegistrationDate = item.RegistrationDate,
        //            Email = item.Email,
        //            Password = item.Password,
        //            Phone = item.Phone,
        //            Country = item.Country,
        //            CityId = item.CityId,
        //            Gender = item.Gender,
        //            BirthDay = item.BirthDay,
        //            TimeZone = item.TimeZone,
        //            LanguageId = item.LanguageId,
        //            Bio = item.Bio,
        //            ProfilePicture = item.ProfilePicture,
        //            LineStatus = item.LineStatus,
        //        });
        //    }
        //    return result;
        //}




        public List<MemberRegisterViewModel> MemberRigisterData()
        {
            List<Member> members = _Repo.GetAll<Member>().ToList();

            List<MemberRegisterViewModel> result = new List<MemberRegisterViewModel>();

            foreach (var item in members)
            {
                result.Add(new MemberRegisterViewModel
                {
                    MemberId = item.MemberId,
                    RegistrationDate = item.RegistrationDate,
                    Email = item.Email,
                    Password = item.Password,
                    AuthCode = item.AuthCode,
                    IsAdmin = item.IsAdmin
                });
            }
            return result;
        }

        public List<Member> MemberLoginData()
        {
            List<Member> members = _Repo.GetAll<Member>().ToList();

            List<Member> result = new List<Member>();
            foreach (var item in members)
            {
                result.Add(new Member
                {
                    MemberId = item.MemberId,
                    RegistrationDate = item.RegistrationDate,
                    Email = item.Email,
                    Password = item.Password
                });
            }
            return result;
        }


        //Hash密碼
        public string HashPassword(string Password)
        {
            string saltkey = "1q2w3e4r5t6y7u8ui9o0po7tyy";
            string saltAndPassword = String.Concat(Password, saltkey);
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashDate = sha256Hasher.ComputeHash(PasswordData);
            string Hashresult = Convert.ToBase64String(HashDate);
            return Hashresult;
        }


        //由email取得單筆資料
        public Member GetDataByAccount(string Email)
        {
            Member Data = new Member();
            try
            {
                var member = _Repo.GetAll<Member>().ToList().Where(m => m.Email == Email).FirstOrDefault();

                Data.MemberId = member.MemberId;
                Data.MemberName = member.MemberName;
                Data.Email = member.Email;
                Data.Password = member.Password;
                Data.AuthCode = member.AuthCode;
                Data.IsAdmin = member.IsAdmin;
            }
            catch (Exception ex)
            {
                Data = null;
            }
            return Data;
        }


        //信箱驗證碼
        public string EmailValidate(string Email, string AuthCode)
        {
            //取得傳入email的會員資料
            Member ValidateMember = GetDataByAccount(Email);

            //宣告驗證後訊息字串
            string ValidateStr = string.Empty;
            if (ValidateMember != null)
            {
                //判斷傳入驗證碼與資料庫中是否相同
                if (ValidateMember.AuthCode == AuthCode)
                {                    
                    //將資料庫的驗證碼設為空                    
                    using(EPalContext _ctx = new EPalContext())
                    {
                        var m = _ctx.Members.ToList().Find(x => x.Email.Equals(Email));
                        try
                        {
                            //var member = _MemberRepo.ReadMember().Where(m => m.Email == Email).FirstOrDefault();
                            m.AuthCode = string.Empty;
                            _ctx.SaveChanges();

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message.ToString());
                        }

                        ValidateStr = "註冊信箱驗證成功，請從Log In登入";
                    }
                }
                else
                {
                    ValidateStr = "驗證碼錯誤，請重新確認或再註冊";
                }
            }
            else
            {
                ValidateStr = "傳送資料有誤，請重新確認或再註冊";
            }
            return ValidateStr;
        }


        //登入帳密確認
        public string LoginCheck(string Email, string Password)
        {
            //取得傳入帳號的會員資料
            Member loginMember = GetDataByAccount(Email);
            //判斷是否有此會員
            if (loginMember != null)
            {
                //判斷是否有經過信箱驗證，有經驗證後，驗證碼欄位會被清空
                if (String.IsNullOrWhiteSpace(loginMember.AuthCode))
                {
                    //進行帳號密碼確認
                    if (PasswordCheck(loginMember, Password))
                    {
                        return "";
                    }
                    else
                    {
                        return "密碼輸入錯誤";
                    }
                }
                else
                {
                    return "此帳號尚未經過Email驗證，請去收信";
                }
            }
            else
            {
                return "無此會員帳號，請去註冊";
            }
        }

        //密碼確認
        public bool PasswordCheck(Member CheckMember, string Password)
        {
            //判斷資料庫裡的密碼資料與傳入密碼資料Hash後是否一樣
            bool result = CheckMember.Password.Equals(HashPassword(Password));
            return result;
        }


        //判斷會員權限角色
        public string GetRole(string Email)
        {
            string Role = "User";
            Member loginMember = GetDataByAccount(Email);
            //判斷資料庫欄位，用以確認是否為Admin
            if (loginMember.IsAdmin != null && loginMember.IsAdmin == true)
            {
                Role += ",Admin"; 
                return Role;
            }
            return null;

        }

    }
}