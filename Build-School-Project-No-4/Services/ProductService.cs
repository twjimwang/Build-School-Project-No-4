using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.Repositories;


namespace Build_School_Project_No_4.Services
{
   public class ProductService
   {
        private readonly ProductRepository _repo;

        private IQueryable<Product> Products;
        private IQueryable<Member> Members;
        private IQueryable<GameCategory> Games;
        private IQueryable<Rank> Ranks;
        private IQueryable<Position> Positions;
        private IQueryable<CommentDetail> CommentDetails;
        private IQueryable<ProductPosition> ProductPositions;


        public ProductService()
        {
            _repo = new ProductRepository();
        }

        public List<ProductViewModel> GetProductData()
        {
            Products = _repo.GetAll<Product>();
            Members = _repo.GetAll<Member>();
            Games = _repo.GetAll<GameCategory>();
            Ranks = _repo.GetAll<Rank>();
            Positions = _repo.GetAll<Position>();
            CommentDetails = _repo.GetAll<CommentDetail>();
            ProductPositions = _repo.GetAll<ProductPosition>();

            var productsVM = new List<ProductViewModel>()
            {
              
            };

            foreach (var item in Products)
            {
                productsVM.Add(new ProductViewModel
                {
                    
                    //UnitPrice = item.UnitPrice,
                    //CreatorImg = item.CreatorImg,
                    //Introduction = item.Introduction,
                    //RecommendationVoice = item.RecommendationVoice,
                    //StarLevel = CommentDetails.FirstOrDefault(x => x.ProductId == item.ProductId).StarLevel,
                    //MemberName = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).MemberName,
                    //GameName = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameName,
                    //GameCoverImg = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameCoverImg,
                    //LineStatus = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).LineStatus,
                    //Position = Positions.FirstOrDefault(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == item.ProductId).PositionId)).PositionName,
                    //Rank = Ranks.FirstOrDefault(x => x.RankId == item.RankId).RankName
                });
            }
            
            return productsVM;
        }

        public ProductViewModel GetProductAll()
        {
            var result = new ProductViewModel();
            var Games = _repo.GetAll<GameCategory>().Select(x=>x.GameName).ToList();
            result.GameAll = Games;
            return result;
        }
    }
    
}