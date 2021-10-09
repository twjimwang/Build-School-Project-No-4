using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.DataModels;


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
        private readonly Repository _Repo;

        private IQueryable<Products> Products;
        private IQueryable<Members> Members;
        private IQueryable<GameCategories> Games;
        private IQueryable<Rank> Ranks;
        private IQueryable<Position> Positions;
        private IQueryable<CommentDetails> CommentDetails;
        private IQueryable<ProductPosition> ProductPositions;


        public ProductService()
        {
            _Repo = new Repository();
            Products = _Repo.GetAll<Products>();
            Members = _Repo.GetAll<Members>();
            Games = _Repo.GetAll<GameCategories>();
            Ranks = _Repo.GetAll<Rank>();
            Positions = _Repo.GetAll<Position>();
            CommentDetails = _Repo.GetAll<CommentDetails>();
            ProductPositions = _Repo.GetAll<ProductPosition>();
        }

        public List<ProductViewModel> GetProductData()
        {
            List<ProductViewModel> productsVM = new List<ProductViewModel>();
            foreach(var item in Products)
            {
                productsVM.Add(new ProductViewModel
                {
                    UnitPrice = item.UnitPrice,
                    CreatorImg = item.CreatorImg,
                    Introduction = item.Introduction,
                    RecommendationVoice = item.RecommendationVoice,
                    StarLevel = CommentDetails.FirstOrDefault(x => x.ProductId == 1).StarLevel,
                    MemberName = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).MemberName,
                    GameName = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameName,
                    GameCoverImg = Games.FirstOrDefault(x => x.GameCategoryId == item.GameCategoryId).GameCoverImg,
                    //LineStatus = Members.FirstOrDefault(x => x.MemberId == item.CreatorId).LineStatusId,
                    PositionName = Positions.FirstOrDefault(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == item.ProductId).ProductPositionId)).PositionName,
                    Rank = Ranks.FirstOrDefault(x => x.RankId == 3).RankName
                }) ;
            }
            
            return productsVM;
        }
    }
    
}