using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
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
            var ProductPosition = _repo.GetAll<ProductPosition>();
            var products = _repo.GetAll<Product>().Where(x => x.GameCategoryId == categoryId).ToList();
            var productCards = products.Select(p => new ProductCard {
                UnitPrice = p.UnitPrice,
                CreatorImg = p.CreatorImg,
                Introduction = p.Introduction,
                RecommendationVoice = p.RecommendationVoice,
                LineStatus = _repo.GetAll<Member>().First(x=>x.MemberId == p.CreatorId).LineStatus,
                CreatorName = _repo.GetAll<Member>().First(x=>x.MemberId == p.CreatorId).MemberName,
                StarLevel = _repo.GetAll<CommentDetail>().FirstOrDefault(x=>x.ProductId == p.ProductId).StarLevel,
                Rank = _repo.GetAll<Rank>().FirstOrDefault(x=>x.RankId == p.RankId).RankName,
                Position = _repo.GetAll<Position>().FirstOrDefault(y => y.PositionId == (ProductPosition.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
            }).ToList();

            result.ProductCards = productCards;
            result.GameCoverImg = category.GameCoverImg;
            result.GameTitle = category.GameName;
            result.CategroyId = categoryId;
            return result;
        }

        public ProductViewModel GetGamesAll()
        {
            var result = new ProductViewModel();
            result.GameAll = _repo.GetAll<GameCategory>().Select(x => x.GameName).ToList();
            return result;
        }
    }
    
}