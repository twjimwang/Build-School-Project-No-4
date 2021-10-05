using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Services;

namespace Build_School_Project_No_4.Controllers
{
    public class JsonApiController : ApiController
    {
        private readonly ProductService _productService;

        public JsonApiController()
        {
            _productService = new ProductService();
        }

        [AcceptVerbs("GET", "POST")]
        public string getAllCardsJson(int id)
        {
            var cardJson = _productService.GetProductCardsJson(id);

            return cardJson;
        }
    }
}
