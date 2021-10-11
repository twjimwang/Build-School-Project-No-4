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

        public List<ProductViewModel>GetProductCardsByFilter(FilterItemViewModel FilterVM)
        {
            var server = FilterVM.Server;
            var language = FilterVM.Language;
            var level = FilterVM.Level;
            var price = FilterVM.UnitPrice;
            var age = FilterVM.Age;
            var gender = FilterVM.Gender;
            var status = FilterVM.Status;

            var products = _repo.GetAll<Products>();
            var CommentDetails = _repo.GetAll<CommentDetails>();
            var ProductPositions = _repo.GetAll<ProductPosition>();
            var Positions = _repo.GetAll<Position>();
            var Ranks = _repo.GetAll<Rank>();
            var Members = _repo.GetAll<Members>();
            var ProductServers = _repo.GetAll<ProductServer>();
            var Servers = _repo.GetAll<Server>();
            var LineStatus = _repo.GetAll<LineStatus>();
            var Languages = _repo.GetAll<Language>();
            var todayYear = DateTime.Now.Year;

            if(server != null && server.Count > 0)
            {
                server.ForEach(s =>
                {
                    Servers = Servers.Where(x => x.ServerName == s);
                });
            }
            if(language != null && language.Count > 0)
            {
                language.ForEach(l =>
                {
                    Languages = Languages.Where(x => x.LanguageName == l);
                });
            }
            if (gender != null && gender.Count > 0)
            {
                gender.ForEach(g =>
                {
                    Members = Members.Where(x => x.Gender == g);
                });
            }
            if (status != null && status.Count > 0)
            {
                status.ForEach(s =>
                {
                    
                });
            }
            if (level != null && level.Count > 0)
            {
                level.ForEach(l =>
                {
                    Ranks = Ranks.Where(x => x.RankName == l);
                });
            }

            return null;
        }
    }
}