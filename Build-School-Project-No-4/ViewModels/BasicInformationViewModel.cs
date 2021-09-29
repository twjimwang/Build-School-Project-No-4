using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class BasicInformationViewModel
    {
        public string LineStatus { get; set; }

        public decimal UnitPrice { get; set; }

        public string GameAvailableDay { get; set; }

        public DateTime GameStartTime { get; set; }

        public DateTime GameEndTime { get; set; }

        //public List<ProductPlans> ProductPlans { get; set; }
    }
    //public class ProductPlans
    //{
    //       public string GameAvailableDay { get; set; }

    //       public DateTime GameStartTime { get; set; }

    //       public DateTime GameEndTime { get; set; }
    // } 
}