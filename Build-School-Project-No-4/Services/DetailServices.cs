using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.ViewModels;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Services
{
    public class DetailServices
    {
        private readonly DetailRepository _repo;
        public DetailServices()
        {
            _repo = new DetailRepository();
        }

        public DetailViewModel GetPlayerByProductId(int productId)
        {
            var playerData = new DetailViewModel();

            var product = _repo.GetProductByProductId(productId);
            var productinfo = _repo.GetProductInfo();

            var playerinfo = _repo.GetPlayerInfo();
            var gameInfo = _repo.GetGameInfo();

            var result = (from p in productinfo
                         join pl in playerinfo on p.CreatorId equals pl.MemberId
                         join g in gameInfo on p.GameCategoryId equals g.GameCategoryId
                         where p.ProductId == productId
                         select new DetailViewModel
                         {
                             MemberName = pl.MemberName,
                             UnitPrice = (double)p.UnitPrice,
                             Recording = p.RecommendationVoice,
                             Intro = p.Introduction,
                             PlayerPic = p.CreatorImg,
                             GameScreenshot = p.ProductImg,
                             GameName = g.GameName,
                             GameBackdrop = g.GameCoverImg

                         }).FirstOrDefault();


            return result;
        }
    }
}