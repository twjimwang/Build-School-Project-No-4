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

        public string GetProductCardsByFilter(FilterItemViewModel FilterVM,int CategoryId)
        {
            var result = new ProductViewModel()
            {
                ProductCards = new List<ProductCard>()
            };

            var category = _repo.GetAll<GameCategories>().FirstOrDefault(x => x.GameCategoryId == CategoryId);
            if (category == null)
            {
                return result.ToString();
            }

            var products = _repo.GetAll<Products>().Where(x => x.GameCategoryId == category.GameCategoryId);
            var CommentDetails = _repo.GetAll<CommentDetails>();
            var ProductPositions = _repo.GetAll<ProductPosition>();
            var Positions = _repo.GetAll<Position>();
            var Ranks = _repo.GetAll<Rank>();
            var Members = _repo.GetAll<Members>();
            var ProductServers = _repo.GetAll<ProductServer>();
            var Servers = _repo.GetAll<Server>();
            var LineStatus = _repo.GetAll<LineStatus>();
            var LanguageName = _repo.GetAll<Language>();
            var todayYear = DateTime.Now.Year;

            var server = FilterVM.Server;
            var language = FilterVM.Language;
            var level = FilterVM.Level;
            var price = FilterVM.UnitPrice;
            var age = FilterVM.Age;
            var gender = FilterVM.Gender;
            var status = FilterVM.Status;

            if(server != null && server.Count > 0)
            {
                server.ForEach(s =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.Server == s).ToList();
                });
            }
            if(language != null && language.Count > 0)
            {
                language.ForEach(l =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.Language == l).ToList();
                });
            }
            if (gender != null && gender.Count > 0)
            {
                gender.ForEach(g =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.GenderId == g).ToList();
                });
            }
            if (status != null && status.Count > 0)
            {
                status.ForEach(s =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.StatusName == s).ToList();
                });
            }
            if (level != null && level.Count > 0)
            {
                level.ForEach(l =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.Rank == l).ToList();
                });
            }
            if (price != null && price.Count > 0)
            {
                price.ForEach(x =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.UnitPrice == x).ToList();
                });
            }
            if (age != null && age.Count > 0)
            {
                age.ForEach(x =>
                {
                    result.ProductCards = result.ProductCards.Where(p => p.Age == x).ToList();
                });
            }
            else
            {
                result.ProductCards = products.Select(p => new ProductCard
                {
                    UnitPrice = p.UnitPrice,
                    CreatorImg = p.CreatorImg,
                    Introduction = p.Introduction,
                    RecommendationVoice = p.RecommendationVoice,
                    LineStatus = LineStatus.First(y => y.LineStatusId == (Members.First(x => x.MemberId == p.CreatorId).LineStatusId)).LineStatusImg,
                    CreatorName = Members.First(x => x.MemberId == p.CreatorId).MemberName,
                    StarLevel = CommentDetails.First(x => x.ProductId == p.ProductId).StarLevel,
                    Rank = Ranks.FirstOrDefault(x => x.RankId == p.RankId) == null ? "No Rank" : Ranks.First(x => x.RankId == p.RankId).RankName,
                    Position = Positions.First(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
                    ProductId = p.ProductId,
                    Server = Servers.First(s => s.ServerId == ((ProductServers.First(y => y.ProductId == p.ProductId).ServerId))).ServerName,
                    Language = LanguageName.First(L => L.LanguageId == (int)Members.First(x => x.MemberId == p.CreatorId).LanguageId).LanguageName,
                    GenderId = (int)Members.First(x => x.MemberId == p.CreatorId).Gender,
                    Age = todayYear - DateTime.Parse(Members.First(x => x.MemberId == p.CreatorId).BirthDay.ToString()).Year,
                    StatusName = LineStatus.First(y => y.LineStatusId == (Members.First(x => x.MemberId == p.CreatorId).LineStatusId)).LineStatusName
                }).ToList();
            }
            result.CategoryId = CategoryId;
            return JsonConvert.SerializeObject(result);
        }
    }
}