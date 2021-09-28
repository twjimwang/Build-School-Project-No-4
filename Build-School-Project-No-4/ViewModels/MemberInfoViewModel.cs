using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class MemberInfoViewModel
    {

        public int MemberId { get; set; }

        [Display(Name = "Name")]
        public string MemberName { get; set; }

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

        public string Phone { get; set; }

        public string Country { get; set; }

        public int? CityId { get; set; }

        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "TimeZone(UTC)")]
        [Range((-11),11)]
        public int TimeZone { get; set; }

        [Display(Name = "Language")]
        public Language? LanguageId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        [Display(Name = "Avatar")]
        [DataType(DataType.ImageUrl)]
        public string ProfilePicture { get; set; }

        public string LineStatus { get; set; }

        [StringLength(10)]
        public string AuthCode { get; set; }

        public bool? IsAdmin { get; set; }
    }

    public enum Gender
    {
        Female = 0,
        Male = 1,
        Other = 2
    }

    public enum Language
    {
        MandarinChinese = 1,
        Spanish = 2,
        English = 3,
        Hindi = 4,
        Arabic = 5,
        Bengali = 6,
        Portuguese = 7,
        Russian = 8,
        Japanese = 9,
        Turkish = 10,
        Korean = 11,
        French = 12,
        German = 13,
        Vietnamese = 14,
        Italian = 15,
        YueChinese = 16,
        Others = 17
    }
}