using Build_School_Project_No_4.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.Repositories
{
    public class OrderRepository
    {
        EPalContext _ctx;
        public OrderRepository()
        {
            _ctx = new EPalContext();
        }

        public void WriteDataToDB()
        {
            using (EPalContext _ctx = new EPalContext())
            {
                List<Order> Order = new List<Order>
                {
                   new Order { OrderId = 1, CustomerId = 2,OrderStatus="" ,OrderDate =  DateTime.ParseExact("2021-06-03", "yyyy-MM-dd", null),Quality =1,UnitPrice=30 },
                      
                };
                _ctx.Orders.AddRange(Order);
                _ctx.SaveChanges();
            }
        }

        public List<Order> ReadOrder()
        {
            return _ctx.Orders.ToList();
        }
    }
}