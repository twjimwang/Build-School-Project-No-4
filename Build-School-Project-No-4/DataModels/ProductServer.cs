namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductServer")]
    public partial class ProductServer
    {
        public int ProductServerId { get; set; }

        public int ProductId { get; set; }

        public int ServerId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Server Server { get; set; }
    }
}
