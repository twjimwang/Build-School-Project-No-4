using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class ProductViewModel
    {
        public string GameName { get; set; }

        public string GameCoverImg { get; set; }

        public string MemberName { get; set; }

        public string LineStatus { get; set; }

        public decimal UnitPrice { get; set; }
    
        public string RecommendationVoice { get; set; }
   
        public string Introduction { get; set; }

        public string Rank { get; set; }

        public string CreatorImg { get; set; }

        public int StarLevel { get; set; }

        public string PositionName { get; set; }

        public string ProductPlans { get; set; }
    }
}