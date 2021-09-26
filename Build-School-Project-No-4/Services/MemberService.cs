using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;


namespace Build_School_Project_No_4.Services
{
    public class MemberService
    {
        private MemberRepository _MemberRepo;
        public MemberService()
        {
            _MemberRepo = new MemberRepository();
        }

        public List<MemberViewModel> GetMember()
        {
            List<Member> members = _MemberRepo.ReadMember();

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

        public List<GroupViewModel> MemberRigisterData()
        {
            List<Member> members = _MemberRepo.ReadMember();

            List<GroupViewModel> result = new List<GroupViewModel>();
            foreach (var item in members)
            {
                result.Add(new GroupViewModel
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
            List<Member> members = _MemberRepo.ReadMember();

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
            //宣告Hash時所添加的無意義亂數值
            string saltkey = "1q2w3e4r5t6y7u8ui9o0po7tyy";
            //將剛剛宣告的字串與密碼結合
            string saltAndPassword = String.Concat(Password, saltkey);
            //定義SHA256的HASH物件
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            //取得密碼轉換成byte資料
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            //取得Hash後byte資料
            byte[] HashDate = sha256Hasher.ComputeHash(PasswordData);
            //將Hash後byte資料轉換成string
            string Hashresult = Convert.ToBase64String(HashDate);
            //回傳Hash後結果
            return Hashresult;
        }


        //藉由帳號取得單筆資料的方法
        private Member GetDataByAccount(string Email)
        {
            Member Data = new Member();
            ////Sql語法
            //string sql = $@" select * from Members where Account = '{Account}' ";
            //確保程式不會因執行錯誤而整個中斷
            try
            {
                ////開啟資料庫連線
                //conn.Open();
                ////執行Sql指令
                //SqlCommand cmd = new SqlCommand(sql, conn);
                ////取得Sql資料
                //SqlDataReader dr = cmd.ExecuteReader();
                //dr.Read();
                //Data.Account = dr["Account"].ToString();
                //Data.Password = dr["Password"].ToString();
                //Data.Name = dr["Name"].ToString();
                //Data.Email = dr["Email"].ToString();
                //Data.AuthCode = dr["AuthCode"].ToString();
                //Data.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);

                var member = _MemberRepo.ReadMember().Where(m => m.Email == Email).FirstOrDefault();

                Data.Email = member.Email;
                Data.Password = member.Password;
                Data.AuthCode = member.AuthCode;
                Data.IsAdmin = member.IsAdmin;
            }
            catch (Exception ex)
            {
                //查無資料
                Data = null;
            }
            //回傳根據編號所取得的資料
            return Data;
        }


        //信箱驗證碼
        public string EmailValidate(string Email, string AuthCode)
        {
            //取得傳入帳號的會員資料
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
            //回傳驗證訊息
            return ValidateStr;

        }


        //登入帳密確認方法，並回傳驗證後訊息
        public string LoginCheck(string Email, string Password)
        {
            //取得傳入帳號的會員資料
            Member loginMember = GetDataByAccount(Email);
            //判斷是否有此會員
            if (loginMember != null)
            {
                //判斷是否有經過信箱驗證，有經驗證驗證碼欄位會被清空
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

        //進行密碼確認
        public bool PasswordCheck(Member CheckMember, string Password)
        {
            //判斷資料庫裡的密碼資料與傳入密碼資料Hash後是否一樣
            bool result = CheckMember.Password.Equals(HashPassword(Password));
            //回傳結果
            return result;
        }


        //會員權限角色資料
        public string GetRole(string Email)
        {
            //宣告初始角色字串
            string Role = "User";
            //取得傳入帳號的會員資料
            Member loginMember = GetDataByAccount(Email);
            //判斷資料庫欄位，用以確認是否為Admon
            if (loginMember.IsAdmin != null && loginMember.IsAdmin == true)
            {
                Role += ",Admin"; //添加Admin
                return Role;
            }
            return null;

        }

    }
}