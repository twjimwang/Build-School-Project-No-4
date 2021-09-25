using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class MemberLoginViewModel
    {

        public int MemberId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "密碼需大於6個字元")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}