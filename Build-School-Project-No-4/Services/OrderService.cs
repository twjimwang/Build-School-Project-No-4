using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Services
{
    public class OrderService
    {
        private OrderRepository _OrderRepo;
        public OrderService()
        {
            _OrderRepo = new OrderRepository();
        }

        public List<OrderViewModel> Order()
        {
            List<Order> Orders = _OrderRepo.ReadOrder();

            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var item in Orders)
            {
                result.Add(new OrderViewModel
                {
                    OrderStatus = item.OrderStatus,
                    OrderId = item.OrderId,
                    PlayerId = item.CustomerId,
                    OrderDate = item.OrderDate,
                    Quality = item.Quality,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quality * item.UnitPrice
                });
            }
            return result;
        }
       
    }
}