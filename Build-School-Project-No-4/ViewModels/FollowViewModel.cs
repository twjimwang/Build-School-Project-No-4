using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class FollowViewModel
    {
        public int FollowId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int? Gender { get; set; }
        public string LineStatus { get; set; }
    }
}