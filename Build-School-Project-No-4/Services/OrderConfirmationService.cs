using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.Repositories;
using Build_School_Project_No_4.DataModels;
using Build_School_Project_No_4.ViewModels;

namespace Build_School_Project_No_4.Services
{
    public class OrderConfirmationService
    {
        private readonly Repository _repo;
        private readonly OrderConfirmationViewModel _orderVM;
        private readonly EPalContext _ctx;
        public OrderConfirmationService()
        {
            _repo = new Repository();
            _ctx = new EPalContext();
        }

        public bool UpdateOrderStatus(string confirmation)
        {
            var orders = _repo.GetAll<Orders>();

            if (confirmation == null)
            {
                return false;
            }
            using (var tran = _ctx.Database.BeginTransaction())
            {
                try
                {
                    var result = orders.Where(x => x.OrderConfirmation == confirmation).FirstOrDefault();
                    result.OrderStatusId = 4;
                    result.UpdateDateTime = DateTime.Now.ToUniversalTime();
                    _ctx.SaveChanges();
                    tran.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    var err = ex.ToString();
                    return false;
                }
            }

        }
    }
}