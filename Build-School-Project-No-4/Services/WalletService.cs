using Build_School_Project_No_4.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Services
{
    public class WalletService
    {

        private readonly Repository _Repo;
        public WalletService()
        {
            //_OrderRepo = new OrderRepository();
            _Repo = new Repository();
        }

        private IQueryable<Order> Orders;
        private IQueryable<Member> Members;
        private IQueryable<OrderStatu>


    }
}