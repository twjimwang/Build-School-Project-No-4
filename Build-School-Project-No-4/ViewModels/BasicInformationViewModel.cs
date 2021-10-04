using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class BasicInformationViewModel
    {
        //public  int PlanId { get; set; }

        public decimal UnitPrice { get; set; }

        public string GameAvailableDay { get; set; }

        public DateTime GameStartTime { get; set; }

        public DateTime GameEndTime { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int GameCategoryId { get; set; }

        public int CreatorId { get; set; }

        public string ProductImg { get; set; }

        public string Introduction { get; set; }

        public string CreatorImg { get; set; }

        public string ServerName { get; set; }
        public string StyleName { get; set; }

        public string PositionName { get; set; }



        //public List<ProductPlans> ProductPlans { get; set; }
    }
    //public class ProductPlans
    //{
    //       public string GameAvailableDay { get; set; }

    //       public DateTime GameStartTime { get; set; }

    //       public DateTime GameEndTime { get; set; }
    // } 
}