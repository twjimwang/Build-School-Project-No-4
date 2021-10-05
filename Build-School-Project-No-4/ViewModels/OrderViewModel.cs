using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int PlayerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime GameStartDateTime { get; set; }
        public DateTime GameEndDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string OrderStatus{ get; set; }
        public decimal TotalPrice { get; internal set; }
    }
}