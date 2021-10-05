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
            List<Order> Orders = _Repo.GetAll<Order>().ToList();
            List<OrderStatus> OrderStatus = _Repo.GetAll<OrderStatus>().ToList();

            List<OrderViewModel> result = new List<OrderViewModel>();

            //var result = (from o in Orders
            //              join os in OrderStatus on o.OrderStatusId equals os.OrderStatusId)
            foreach (var item in Orders)
            {
                result.Add(new OrderViewModel
                {
                    //OrderStatus = item.OrderStatus,
                    OrderId = item.OrderId,
                    PlayerId = item.CustomerId,
                    OrderDate = item.OrderDate,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice
                });
            }
            return result;
        }
       
    }
}