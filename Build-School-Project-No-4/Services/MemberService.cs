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
                    RegistrationDate = item.RegistrationDate,
                    Email = item.Email,
                    Phone = item.Phone,
                    Password = item.Password,
                    MemberName = item.MemberName,
                    BirthDay = item.BirthDay,

                });
            }
            return result;
        }
    }
}