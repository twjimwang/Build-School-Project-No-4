using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class ApiFilterService
    {
        private readonly Repository _repo;

        public ApiFilterService()
        {
            _repo = new Repository();
        }

        public string GetProductCardsByFilter(FilterItemViewModel FilterVM)
        {
            var result = new ProductViewModel()
            {
                ProductCards = new List<ProductCard>()
            };

            var server = FilterVM.Server;
            var language = FilterVM.Language;
            var level = FilterVM.Level;
            var price = FilterVM.UnitPrice;
            var age = FilterVM.Age;
            var gender = FilterVM.Gender;
            var status = FilterVM.Status;
            var categoryId = FilterVM.CategoryId;

            var category = _repo.GetAll<GameCategories>().FirstOrDefault(x => x.GameCategoryId == categoryId);
            var Members = _repo.GetAll<Members>();
            var LineStatus = _repo.GetAll<LineStatus>();
            var CommentDetails = _repo.GetAll<CommentDetails>();
            var ProductPositions = _repo.GetAll<ProductPosition>();
            var Positions = _repo.GetAll<Position>();
            var Ranks = _repo.GetAll<Rank>();
            var ProductServers = _repo.GetAll<ProductServer>();
            var Servers = _repo.GetAll<Server>();
            var LanguageName = _repo.GetAll<Language>();
            var todayYear = DateTime.Now.Year;
            var productsx = _repo.GetAll<Products>();
            var gameCat = _repo.GetAll<GameCategories>();
            var resultxx = (from p in productsx
                            join m in Members on p.CreatorId equals m.MemberId
                            join l in LineStatus on m.LineStatusId equals l.LineStatusId
                            join g in gameCat on p.GameCategoryId equals g.GameCategoryId
                            where g.GameCategoryId == categoryId
                            select new ProductCard 
                            {
                                UnitPrice = p.UnitPrice,
                                LineStatus = l.LineStatusImg,

                            });

            if (category == null)
            {
                return result.ToString();
            }
            var products = _repo.GetAll<Products>().Where(x => x.GameCategoryId == category.GameCategoryId);
            List<int> intersectedList = new List<int>();
            if (status != null && status.Count()>0)
            {
                status.ForEach(x =>
                {
                    //找到他的ID
                    var LinestausId = LineStatus.FirstOrDefault(y => y.LineStatusName == x).LineStatusId;
                    //透過ID與Member做關聯
                    var MemberId = Members.Where(m => m.LineStatusId == LinestausId).Select(y => y.MemberId).ToList();
                    //透過memberId找符合的productId
                    var prod = products.Select(p => p.CreatorId).ToList();
                    //找出交集
                    intersectedList = prod.Intersect(MemberId).ToList();
                });
            }

            
                var productCards = products.Select(p => new ProductCard
                {
                    UnitPrice = p.UnitPrice,
                    CreatorImg = p.CreatorImg,
                    Introduction = p.Introduction,
                    RecommendationVoice = p.RecommendationVoice,
                    LineStatus = LineStatus.FirstOrDefault(y => y.LineStatusId == Members.FirstOrDefault(x => x.MemberId == p.CreatorId).LineStatusId).LineStatusImg,
                    CreatorName = Members.FirstOrDefault(x => x.MemberId == p.CreatorId).MemberName,
                    StarLevel = CommentDetails.FirstOrDefault(x => x.ProductId == p.ProductId).StarLevel,
                    Rank = Ranks.FirstOrDefault(x => x.RankId == p.RankId) == null ? "No Rank" : Ranks.FirstOrDefault(x => x.RankId == p.RankId).RankName,
                    Position = Positions.FirstOrDefault(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
                    ProductId = p.ProductId,
                    Server = Servers.FirstOrDefault(s => s.ServerId == ProductServers.FirstOrDefault(y => y.ProductId == p.ProductId).ServerId).ServerName,
                    Language = LanguageName.FirstOrDefault(L => L.LanguageId == (int)Members.FirstOrDefault(x => x.MemberId == p.CreatorId).LanguageId).LanguageName,
                    GenderId = (int)Members.FirstOrDefault(x => x.MemberId == p.CreatorId).Gender,
                    //Age = todayYear - DateTime.Parse(Members.FirstOrDefault(x => x.MemberId == p.CreatorId).BirthDay.ToString()).Year,
                    //StatusName = LineStatus.FirstOrDefault(y => y.LineStatusId == (Members.FirstOrDefault(x => x.MemberId == p.CreatorId).LineStatusId)).LineStatusName
                }).ToList();
                result.ProductCards = productCards;
            
            
               
            result.CategoryId = categoryId;
           
            return JsonConvert.SerializeObject(result);
        }
    }
}