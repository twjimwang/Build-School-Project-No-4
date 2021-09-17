namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        public int PlayerId { get; set; }

        public int ProductId { get; set; }

        public int Quality { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public DateTime GameStartDateTime { get; set; }

        public DateTime GameEndDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStatus { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
