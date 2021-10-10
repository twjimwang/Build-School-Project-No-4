using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class AddgameViewModel
    {

        public decimal UnitPrice { get; set; }

        
        public string GameAvailableDay { get; set; }

        [DataType(DataType.Time)]
        public DateTime GameStartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime GameEndTime { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public GameCategoryList GameCategoryId { get; set; }

        public int CreatorId { get; set; }

        public string ProductImg { get; set; }

        [DataType(DataType.MultilineText)]
        public string Introduction { get; set; }

        public string CreatorImg { get; set; }

        public string RecommendationVoice { get; set; }

        [Display(Name ="Server")]
        public ServerEum ServerId { get; set; }
        [Display(Name = "Style")]
        public StyleIdEum  StyleId { get; set; }
        [Display(Name = "Position")]
        public PositionEum PositionId { get; set; }
        [Display(Name = "Rank")]
        public RankEum RankId { get; set; }

    }

    public enum GameCategoryList
    {
        LOL = 1,
        NA = 2,
        LAN = 3,
        BR = 4,
        EU_West = 5,
        EU_NorthEast = 6,
        EU_NorthEast = 7,
        EU_NorthEast = 8,
        EU_NorthEast = 9,
        EU_NorthEast = 10,
    }

    public enum ServerEum
    {
        OCE=1,
        NA=2,
        LAN=3,
        BR=4,
        EU_West=5,
        EU_NorthEast =6
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

    public enum RankEum
    {
        Iron = 1,
        Bronze = 2,
        Silver = 3,
        Gold = 4,
        Platinum = 5,
        Diamond = 6
    }
}