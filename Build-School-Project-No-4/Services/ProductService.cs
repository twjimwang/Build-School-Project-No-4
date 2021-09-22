using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.Repositories;
using ProductPlan = Build_School_Project_No_4.DataModels.ProductPlan;


namespace Build_School_Project_No_4.Services
{
    //public class ProductService
    //{
    //    public ProductRepository _ePalRepo;

    //    public ProductService()
    //    {
    //        _ePalRepo = new ProductRepository();
    //    }

    //    public List<ProductViewModel> GetProductData()
    //    {
    //        List<Product> Products = _ePalRepo.ReadProductData();
    //        List<Member> Members = _ePalRepo.ReadMembersData();
    //        List<CommentDetail> CommentDetails = _ePalRepo.ReadCommentDetailData();
    //        List<Rank> Ranks = _ePalRepo.ReadRanksData();
    //        List<GameCategory> Games = _ePalRepo.ReadGamesData();
    //        List<Server> Servers = _ePalRepo.ReadServersData();
    //        List<Position> Positions = _ePalRepo.ReadPositionData();
    //        List<ProductPlan> ProductPlans = _ePalRepo.ReadProductPlanData();

    //        List<ProductViewModel> productsVM = new List<ProductViewModel>();
    //        foreach(var item in Products)
    //        {
    //            productsVM.Add(new ProductViewModel
    //            {
    //                UnitPrice = item.UnitPrice
    //            });
    //        }
    //        return productsVM;
    //    }

    //}
   public class ProductService
   {
        private readonly ProductRepository _Repo;

        // private IQueryable<Product> Products;
        // private IQueryable<Member> Members;
        // private IQueryable<GameCategory> Games;
        // private IQueryable<Rank> Ranks;
        // private IQueryable<Position> Positions;
        // private IQueryable<CommentDetail> CommentDetails;
        // private IQueryable<ProductPosition> ProductPositions;


        public ProductService()
        {
            _Repo = new ProductRepository();
            // Products = _Repo.GetAll<Product>();
            // Members = _Repo.GetAll<Member>();
            // Games = _Repo.GetAll<GameCategory>();
            // Ranks = _Repo.GetAll<Rank>();
            // Positions = _Repo.GetAll<Position>();
            // CommentDetails = _Repo.GetAll<CommentDetail>();
            // ProductPositions = _Repo.GetAll<ProductPosition>();
        }

        public List<ProductViewModel> GetProductData()
        {
            List<ProductViewModel> productsVM = new List<ProductViewModel>();
            var products = _Repo.GetAll<Product>().ToList();
            var productPlans = _Repo.GetAll<ProductPlan>().Where(x => products.Select(y => y.ProductId).Contains(x.ProductId)).ToList();
            var gameCategories = _Repo.GetAll<GameCategory>()
                .Where(x=>products.Select(y=>y.GameCategoryId).Distinct().Contains(x.GameCategoryId))
                .ToList();
            var commentDetails = _Repo.GetAll<CommentDetail>()
                .Where(x=>products.Select(y=>y.ProductId).Contains(x.ProductId))
                .ToList();
            var members = _Repo.GetAll<Member>().Where(x=>commentDetails.Select(y=>y.MemberId).Contains(x.MemberId)).ToList();
            var positions = _Repo.GetAll<Position>().ToList();
            var productPositions = _Repo.GetAll<ProductPosition>().Where(x => products.Select(y => y.ProductId).Contains(x.ProductId)).ToList();
            var ranks = _Repo.GetAll<Rank>().Where(x=>products.Select(y=>y.RankId).Distinct().Contains(x.RankId)).ToList();
            var res = products.Select(prod => new ProductViewModel
            {
                GameName = gameCategories.First(x => x.GameCategoryId == prod.GameCategoryId).GameName,
                GameCoverImg = gameCategories.First(x => x.GameCategoryId == prod.GameCategoryId).GameCoverImg,
                MemberName = members.First(x => x.MemberId == prod.CreatorId).MemberName,
                LineStatus = members.First(x => x.MemberId == prod.CreatorId).LineStatus,
                UnitPrice = prod.UnitPrice,
                RecommendationVoice = prod.RecommendationVoice,
                Introduction = prod.Introduction,
                Rank = ranks.First(x => x.RankId == prod.RankId).RankName,
                CreatorImg = prod.CreatorImg,
                StarLevel = (int)commentDetails.Where(x => x.ProductId == prod.ProductId).Average(x => x.StarLevel),
                PositionName = positions.Where(position => productPositions.Where(x => x.ProductId == prod.ProductId).Select(x => x.PositionId).Contains(position.PositionId))
                    .Select(x => x.PositionName).ToList(),
                ProductPlans = productPlans.Where(x => x.ProductId == prod.ProductId).Select(plan => new AvailableTime
                {
                    AvailableDay = plan.GameAvailableDay,
                    StartTime = plan.GameStartTime,
                    EndTime = plan.GameEndTime
                }).ToList()
            }).ToList();
            
            // foreach(var item in products)
            // {
            //     productsVM.Add(new ProductViewModel
            //     {
            //         UnitPrice = item.UnitPrice,
            //         CreatorImg = item.CreatorImg,
            //         Introduction = item.Introduction,
            //         RecommendationVoice = item.RecommendationVoice,
            //         StarLevel = CommentDetails.FirstOrDefault(x => x.ProductId == 1).StarLevel,
            //         MemberName = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).MemberName,
            //         GameName = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameName,
            //         GameCoverImg = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameCoverImg,
            //         LineStatus = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).LineStatus,
            //         PositionName = Positions.FirstOrDefault(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == item.ProductId).ProductPositionId)).PositionName,
            //         Rank = Ranks.FirstOrDefault(x => x.RankId == 3).RankName
            //     }) ;
            // }
            
            return res;
        }
    }
    
}