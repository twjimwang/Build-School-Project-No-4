﻿using Build_School_Project_No_4.Services;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Controllers
{
    public class SettingsAccountController : Controller
    {

        private MemberService _MemberService;
        public SettingsAccountController()
        {
            _MemberService = new MemberService();
        }


        // GET: SettingsAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SettingsAccount()
        {
            List<MemberViewModel> MemberData = _MemberService.GetMember();

            return View(MemberData);
        }
    }
}