using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Build_School_Project_No_4.Services
{
   public class ProductService
   {
        private readonly Repository _repo;

        public ProductService()
        {
            _repo = new Repository();
        }

        public ProductViewModel GetProductCardsData(int categoryId)
        {
            var result = new ProductViewModel()
            {
                ProductCards = new List<ProductCard>()
            };
            var category = _repo.GetAll<GameCategory>().FirstOrDefault(x => x.GameCategoryId == categoryId);
            if (category == null)
            {
                return result;
            }
            var products = _repo.GetAll<Product>().Where(x => x.GameCategoryId == category.GameCategoryId).ToList();
            var CommentDetails = _repo.GetAll<CommentDetail>().ToList();
            var ProductPositions = _repo.GetAll<ProductPosition>().ToList();
            var Positions = _repo.GetAll<Position>().ToList();
            var Ranks = _repo.GetAll<Rank>().ToList();
            var Members = _repo.GetAll<Member>().ToList();

            var productCards = products.Select(p => new ProductCard {
                UnitPrice = p.UnitPrice,
                CreatorImg = p.CreatorImg,
                Introduction = p.Introduction,
                RecommendationVoice = p.RecommendationVoice,
                LineStatus = Members.First(x=>x.MemberId == p.CreatorId).LineStatus,
                CreatorName = Members.First(x=>x.MemberId == p.CreatorId).MemberName,
                StarLevel = CommentDetails.First(x => x.ProductId == p.ProductId).StarLevel,
                Rank = Ranks.FirstOrDefault(x=>x.RankId == p.RankId)==null?"No Rank": Ranks.First(x => x.RankId == p.RankId).RankName,
                Position = Positions.First(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
                ProductId = p.ProductId
            }).ToList();

            result.ProductCards = productCards;
            result.CategoryId = categoryId;
            return result;
        }

        public CategoryViewModel GetGamesAllAndDeatils(int categoryId)
        {
            var result = new CategoryViewModel();
            var category = _repo.GetAll<GameCategory>().FirstOrDefault(x => x.GameCategoryId == categoryId);
            if (category == null)
            {
                return result;
            }
            var Games = _repo.GetAll<GameCategory>().ToList();
            result.GameAllName = Games.Select(x => x.GameName).ToList();
            result.CategroyId = categoryId;
            result.GameCoverImg = category.GameCoverImg;
            result.GameTitle = category.GameName;
            return result;
        }

        public string GetProductCardsJson(int categoryId)
        {
            var result = new ProductViewModel()
            {
                ProductCards = new List<ProductCard>()
            };
            var category = _repo.GetAll<GameCategory>().FirstOrDefault(x => x.GameCategoryId == categoryId);
            if (category == null)
            {
                return result.ToString();
            }
            var products = _repo.GetAll<Product>().Where(x => x.GameCategoryId == category.GameCategoryId).ToList();
            var CommentDetails = _repo.GetAll<CommentDetail>().ToList();
            var ProductPositions = _repo.GetAll<ProductPosition>().ToList();
            var Positions = _repo.GetAll<Position>().ToList();
            var Ranks = _repo.GetAll<Rank>().ToList();
            var Members = _repo.GetAll<Member>().ToList();
            var Servers = _repo.GetAll<ProductServer>().ToList();

            var productCards = products.Select(p => new ProductCard
            {
                UnitPrice = p.UnitPrice,
                CreatorImg = p.CreatorImg,
                Introduction = p.Introduction,
                RecommendationVoice = p.RecommendationVoice,
                LineStatus = Members.First(x => x.MemberId == p.CreatorId).LineStatus,
                CreatorName = Members.First(x => x.MemberId == p.CreatorId).MemberName,
                StarLevel = CommentDetails.First(x => x.ProductId == p.ProductId).StarLevel,
                Rank = Ranks.FirstOrDefault(x => x.RankId == p.RankId) == null ? "No Rank" : Ranks.First(x => x.RankId == p.RankId).RankName,
                Position = Positions.First(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
                ProductId = p.ProductId,
                RankId = Ranks.FirstOrDefault(x => x.RankId == p.RankId) == null ? 0 : Ranks.First(x => x.RankId == p.RankId).RankId,
                ServerId = Servers.First(x=> x.ProductId == p.ProductId).ServerId,
                LanguageId = (int)Members.First(x => x.MemberId == p.CreatorId).LanguageId,
                GenderId = (int)Members.First(x => x.MemberId == p.CreatorId).Gender
            }).ToList();
            result.CategoryId = categoryId;
            result.ProductCards = productCards;
            return JsonConvert.SerializeObject(result);
        }
   }
    
}