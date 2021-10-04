using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Build_School_Project_No_4.Services
{
    public class MemberService
    {
        //private MemberRepository _MemberRepo;
        private readonly Repository _Repo;
        public MemberService()
        {
            _Repo = new Repository();            
        }


        public List<MemberViewModel> GetMember()
        {
            List<Members> members = _Repo.GetAll<Members>().ToList();

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
                    //LineStatus = item.LineStatus
                });
            }
            return result;
        }
    }
}