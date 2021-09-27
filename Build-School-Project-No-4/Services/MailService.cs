﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class MailService
    {

        private string gmail_account = "epalmemberservice@gmail.com"; //Gmail帳號
        private string gmail_password = "epalproject2021"; //Gmail密碼
        private string gmail_mail = "epalmemberservice@gmail.com"; //Gmail信箱

        
        //產生驗證碼
        public string GetValidateCode()
        {
            string[] Code ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"
                            , "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y"
                            , "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b"
                            , "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n"
                            , "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string ValidateCode = string.Empty;
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                ValidateCode += Code[rd.Next(Code.Count())];
            }
            return ValidateCode;
        }

        //使用者資料填入驗證信範本
        public string GetRegisterMailBody(string TempString, string UserEmail, string ValidateUrl)
        {
            TempString = TempString.Replace("{{UserEmail}}", UserEmail);
            TempString = TempString.Replace("{{ValidateUrl}}", ValidateUrl);
            return TempString;
        }

        //寄驗證信
        public void SendRegisterMail(string MailBody, string ToEmail)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gmail_mail);
            mail.To.Add(ToEmail);
            mail.Subject = "會員註冊確認信";
            mail.Body = MailBody;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
        }

    }
}