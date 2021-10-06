using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class AddgameViewModel
    {

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


        public ServerEum ServerId { get; set; }

        public StyleIdEum  StyleId { get; set; }

        public PositionEum PositionId { get; set; }

    }

    public enum ServerEum
    {
        OCE=1,
        NA=2,
        LAN=3,
        BR=4,
        EU_West=5,
        EU_NorthEast
    }
     
    public enum StyleIdEum
    {
        Love_Inting=1,
        Try_Hard=2,
        Hard_Stuck=3,
        Sneaky=4,
        Global_Presence=5,
        One_Shot=6
    }

    public enum PositionEum
    {
        Top =1,
        Jungler=2,
        ADC=3,
        Support=4,
        Middle=5,    
    }
}