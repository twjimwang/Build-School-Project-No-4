using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class MemberService
    {
        private MemberRepository _MemberRepo;
        public MemberService()
        {
            _MemberRepo = new MemberRepository();
        }

        public List<MemberViewModel> GetMember()
        {
            List<Member> members = _MemberRepo.ReadMember();

            List<MemberViewModel> result = new List<MemberViewModel>();
            foreach (var item in members)
            {
                result.Add(new MemberViewModel{
                    MemberId = item.MemberId,
                    MemberName = item.MemberName,
                    RegistrationDate = item.RegistrationDate,
                    Email = item.Email,
                    Password = item.Password,
                    Phone = item.Phone,
                    Country = item.Country,
                    CityId = item.CityId,
                    Gender = item.Gender,
                    BirthDay = item.BirthDay,
                    TimeZone = item.TimeZone,
                    LanguageId = item.LanguageId,
                    Bio = item.Bio,
                    ProfilePicture = item.ProfilePicture,
                    LineStatus = item.LineStatus,


                });
            }
            return result;
        }
    }
}