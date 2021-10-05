using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.ViewModels;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Services
{
    public class AddToCartService
    {
        //private readonly AddToCartViewModel addVM;
        //public AddToCartService()
        //{
        //    addVM = new AddToCartViewModel();
        //}

        public Order CreateUnpaidOrder(GroupViewModel AddCartVM, string startTime, int id)
        {
            var orderid = AddCartVM.AddCart.OrderId;
            //var result = 
            return null;
        }

    }
}