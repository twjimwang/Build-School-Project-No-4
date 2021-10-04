namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPosition")]
    public partial class ProductPosition
    {
        public int ProductPositionId { get; set; }

        public int ProductId { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual Products Products { get; set; }
    }
}
