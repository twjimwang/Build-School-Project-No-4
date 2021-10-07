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

            List<Members> memberAll = _Repo.GetAll<Members>().ToList();
            List<Followings> followAll = _Repo.GetAll<Followings>().ToList();
            List<RecentVistors> vistorAll = _Repo.GetAll<RecentVistors>().ToList();
            List<Language> languages = _Repo.GetAll<Language>().ToList();
            List<CommentDetails> commentAll = _Repo.GetAll<CommentDetails>().ToList();
            List<Products> products = _Repo.GetAll<Products>().ToList();

            var selectMemberLanguage = memberAll.Where(x => x.MemberId == assignMemberId).FirstOrDefault();
            var selectlanguage = languages.Where(x => x.LanguageId == selectMemberLanguage.LanguageId).FirstOrDefault();
            var selectmemberId = memberAll.Where(x => x.MemberId == assignMemberId).ToList();
            var selectfollowId = followAll.Where(x => x.MemberId == assignMemberId).ToList();
            var selectfollwersTotal = followAll.Where(x => x.FollowingId == assignMemberId).ToList();
            var selectVistor = vistorAll.Where(x => x.MemberId == assignMemberId).ToList();
            var selectServers = products.Where(x => x.CreatorId == assignMemberId).ToList();
            var selectRecommend = commentAll.Where(x => x.MemberId == assignMemberId).ToList();
            var RecommendList = commentAll.Where(x => x.MemberId == assignMemberId).ToList();

            int follingCal = selectfollowId.Count;
            int vistorCal = selectVistor.Count;
            int followersCal = selectfollwersTotal.Count;
            string languageNames = selectlanguage.LanguageName;
            int serversCal = selectServers.Count;
            int commentCal = selectRecommend.Count;
            decimal avgStar = 0;
            avgStar = starAvgMethod(selectRecommend);

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
                    VistorsNumber = vistorCal,
                    serverNumber = serversCal,
                    commentNumber = commentCal,
                    StarAvg = avgStar
                });
            }

            return result;
        }

        private static decimal starAvgMethod(List<CommentDetails> selectRecommend)
        {
    
            decimal avgStar = 0;
            decimal y = 0;
            foreach (var item in selectRecommend)
            {
                y = item.StarLevel + y;
            }

            if (y != 0)
            {
                avgStar = y / selectRecommend.Count();
            }
           
            return avgStar;
        }

    }
}