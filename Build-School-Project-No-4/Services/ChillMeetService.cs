using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class ChillMeetService
    {
        private readonly Repository _Repo;

        public ChillMeetService()
        {
            _Repo = new Repository();
        }

        public List<ChillMeetViewModel> GetMeetFiles(int? assignMemberId)
        {
            //這樣寫有問題.原因是ToList會佔據記憶體的空間=>最後在ToList
            var MeetLikesAll = _Repo.GetAll<MeetLikes>();
            var MembersAll = _Repo.GetAll<Members>();
            var LanguagesAll = _Repo.GetAll<Language>();

            //找出like所有的會員Id
            var filterLikes = MeetLikesAll.Where(x => x.MemberId == assignMemberId);


            //DataModel轉換 (like的table轉為Member的table)
            //找出重複的memberID (distinct用法只能一個欄位變數)
            List<Members> Memberlikes = new List<Members>();
            foreach (var item in filterLikes)
            {
                Memberlikes.Add(new Members { MemberId = item.LikeId });
            }

            //排除重複的
            var likes = Memberlikes.Select(x => x.MemberId).ToList();
            var memberAlls = MembersAll.Select(x => x.MemberId).ToList();
            var MemberDislike = memberAlls.Except(likes);

            List<Members> resultMembers = new List<Members>();
            List<ChillMeetViewModel> result = new List<ChillMeetViewModel>();

            foreach (var dislike in MemberDislike)
            {
                var y = MembersAll.FirstOrDefault(x => x.MemberId == dislike);

                var mem = new ChillMeetViewModel
                {
                    MemberId = y.MemberId,
                    MemberName = y.MemberName,
                    Gender = y.Gender,
                    Country = y.Country,
                    MeetPicture = y.MeetPicture,
                    UserId = (int)assignMemberId
                };
                result.Add(mem);
            }

            return result;
        }


    }
}