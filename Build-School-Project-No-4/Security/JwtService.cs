using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Build_School_Project_No_4.Security
{
    public class JwtService
    {
        //Token
        public string GenerateToken(string Email)
        {
            JwtObject jwtObject = new JwtObject
            {
                Email = Email,
                //Role = Role,
                Expire = DateTime.Now.AddMinutes(Convert.ToInt32(WebConfigurationManager.AppSettings["ExpireMinutes"])).ToString()
            };

            //從Web.Config取得密鑰
            string SecretKey = WebConfigurationManager.AppSettings["SecretKey"].ToString();
            //JWT的內容
            var payload = jwtObject;
            //將資料加密為Token
            var token = JWT.Encode(payload, Encoding.UTF8.GetBytes(SecretKey), JwsAlgorithm.HS512);
            return token;
        }
    }
}