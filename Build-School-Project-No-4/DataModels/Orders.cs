namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime GameStartDateTime { get; set; }

        public DateTime? GameEndDateTime { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderConfirmation { get; set; }

        public virtual Members Members { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual OrderStatus OrderStatus1 { get; set; }

        public virtual Products Products { get; set; }
    }
}
