using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class ProfileEpalService
    {
        public readonly Repository _Repo;

        public ProfileEpalService()
        {
            _Repo = new Repository();
        }




        public List<ProfileViewModel> GetProfiles(int? assignMemberId)
        {

            List<Member> memberAll = _Repo.GetAll<Member>().ToList();
            List<Following> followAll = _Repo.GetAll<Following>().ToList();
            List<RecentVistor> vistorAll = _Repo.GetAll<RecentVistor>().ToList();
            List<Language> languages = _Repo.GetAll<Language>().ToList();

            var selectMemberLanguage = memberAll.Where(x => x.MemberId == assignMemberId).FirstOrDefault();
            var selectlanguage = languages.Where(x => x.LanguageId == selectMemberLanguage.LanguageId).FirstOrDefault();
            var selectmemberId = memberAll.Where(x => x.MemberId == assignMemberId).ToList();
            var selectfollowId = followAll.Where(x => x.MemberId == assignMemberId).ToList();
            var selectfollwersTotal = followAll.Where(x => x.FollowingId == assignMemberId).ToList();
            var selectVistor = vistorAll.Where(x => x.MemberId == assignMemberId).ToList();

            int follingCal = selectfollowId.Count;
            int vistorCal = selectVistor.Count;
            int followersCal = selectfollwersTotal.Count;
            string languageNames = selectlanguage.LanguageName;

            List<ProfileViewModel> result = new List<ProfileViewModel>();
            foreach (var item in selectmemberId)
            {
                result.Add(new ProfileViewModel
                {
                    MemberId = item.MemberId,
                    MemberName = item.MemberName,
                    Gender = item.Gender,
                    ProfilePicture = item.ProfilePicture,
                    FollingsNumber = follingCal,
                    FollowsNumber = followersCal,
                    LanguageName = languageNames,
                    VistorsNumber = vistorCal
                });
            }

            return result;
        }

    }
}