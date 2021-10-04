using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class productPlanViewModel
    {
        //public int PlanId { get; set; }

        public int ProductId { get; set; }

        public string GameAvailableDay { get; set; }

        public DateTime GameStartTime { get; set; }

        public DateTime GameEndTime { get; set; }
    }
}