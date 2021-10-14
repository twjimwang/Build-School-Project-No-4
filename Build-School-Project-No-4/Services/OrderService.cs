using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Services
{
    public class OrderService
    {
        //private OrderRepository _OrderRepo;
        private readonly Repository _Repo;
        public OrderService()
        {
            //_OrderRepo = new OrderRepository();
            _Repo = new Repository();
        }

        public List<OrderViewModel> Order()
        {
            List<Orders> Orders = _Repo.GetAll<Orders>().ToList();

            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var item in Orders)
            {
                result.Add(new OrderViewModel
                {
                    //OrderStatus = item.OrderStatus,
                    OrderId = item.OrderId,
                    PlayerId = item.CustomerId,
                    OrderDate = item.OrderDate,
                    Quality = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice
                });
            }
            return result;
        }
       
    }
}