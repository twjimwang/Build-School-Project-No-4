using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.ViewModels;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Repositories;

namespace Build_School_Project_No_4.Services
{
    public class AddToCartService
    {
        private readonly Repository _repo;
        public AddToCartService()
        {
            _repo = new Repository();
        }

        public Orders CreateUnpaidOrder(GroupViewModel AddCartVM, string startTime, int id)
        {
            var cart = AddCartVM.AddCart;
            var timeNow = DateTime.UtcNow;
            //get timestamp + identifier EP-12873472834
            Orders order = new Orders()
            {
                CustomerId = 1,
                ProductId = id,
                Quantity = cart.Rounds,
                UnitPrice = cart.UnitPrice,
                OrderDate = timeNow,
                GameStartDateTime = Convert.ToDateTime(startTime),
                OrderStatusId = 1,
                //add customerid to end when can get customerid
                OrderConfirmation = timeNow.ToString("yyyyMMddHHmmssfffffff")
            };
            return order;
        }

    }
}