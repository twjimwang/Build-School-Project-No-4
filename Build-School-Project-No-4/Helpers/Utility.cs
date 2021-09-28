using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Build_School_Project_No_4.Helpers
{
    public class Utility
    {
        public static List<SelectListItem> getGenderList()
        {
            List<SelectListItem> GenderList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Female", Value = "0" },
                new SelectListItem { Text = "Male", Value = "1" },
                new SelectListItem { Text = "Other", Value = "2" }
            };

            return GenderList;
        }

        public static List<SelectListItem> getLanguageList()
        {
            List<SelectListItem> LanguageList = new List<SelectListItem>
            {
                new SelectListItem{ Text="MandarinChinese", Value="1", Selected = false},
                new SelectListItem{ Text="Spanish", Value="2", Selected = false},
                new SelectListItem{ Text="English", Value="3", Selected = false},
                new SelectListItem{ Text="Hindi", Value="4", Selected = false},
                new SelectListItem{ Text="Arabic", Value="5", Selected = false},
                new SelectListItem{ Text="Bengali", Value="6", Selected = false},
                new SelectListItem{ Text="Portuguese", Value="7", Selected = false},
                new SelectListItem{ Text="Russian", Value="8", Selected = false},
                new SelectListItem{ Text="Japanese", Value="9", Selected = false},
                new SelectListItem{ Text="Turkish", Value="10", Selected = false},
                new SelectListItem{ Text="Korean", Value="11", Selected = false},
                new SelectListItem{ Text="French", Value="12", Selected = false},
                new SelectListItem{ Text="German", Value="13", Selected = false},
                new SelectListItem{ Text="Vietnamese", Value="14", Selected = false},
                new SelectListItem{ Text="Italian", Value="15", Selected = false},
                new SelectListItem{ Text="YueChinese", Value="16", Selected = false},
                new SelectListItem{ Text="Others", Value="17", Selected = false},
            };

            return LanguageList;

        }


    }
}