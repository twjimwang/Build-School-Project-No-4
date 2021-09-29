using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Repositories
{
    public class DetailRepository
    {
        private readonly EPalContext _ctx;
        public DetailRepository()
        {
            _ctx = new EPalContext();
        }

        public EPalContext GetAlla()
        {
            return _ctx;
        }
        public Product GetProductByProductId(int prodId)
        {
            var product = _ctx.Products.FirstOrDefault(x => x.ProductId == prodId);
            return product;
        }
        public List<Product> GetProductInfo()
        {
            var productinfo = _ctx.Products.ToList();
            return productinfo;
        }
         public List<Member> GetPlayerInfo()
        {
            var member = _ctx.Members.ToList();
            return member;
        }
        public List<GameCategory> GetGameInfo()
        {
            var gameinfo = _ctx.GameCategories.ToList();
            return gameinfo;
        }

    }
}