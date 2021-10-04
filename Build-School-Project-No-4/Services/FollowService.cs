using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.ViewModels;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Services
{
    public class FollowService
    {
        private readonly Repository _Repo;

        public FollowService()
        {
            _Repo = new Repository();
        }

        public List<FollowViewModel> GetFollowMember()
        {

            List<Member> membersAll = _Repo.GetAll<Member>().ToList();
            List<Following> follows = _Repo.GetAll<Following>().ToList();

            int testFollowID = 1;
            int testFollowID2 = 16;
            var selectMemberID = membersAll.Where(x => x.MemberId == testFollowID || x.MemberId == testFollowID2).ToList();

            List<FollowViewModel> result = new List<FollowViewModel>();
            foreach (var item in selectMemberID)
            {
                result.Add(new FollowViewModel
                {
                    MemberId = item.MemberId,
                    MemberName = item.MemberName,
                    Gender = item.Gender,
                    //LineStatus = item.LineStatus,
                    ProfilePicture = item.ProfilePicture
                });
            }
            return result;
        }

    }
}