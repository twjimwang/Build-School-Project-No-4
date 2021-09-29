using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class BasicInformation
    {

        private readonly Repository _basicInformationRepository;
        public BasicInformation()
        {
            _basicInformationRepository = new Repository();
        }

        //public BasicInformationViewModel CeateBasicInformation()
        //{

        //    return View();
        //}

    }
}