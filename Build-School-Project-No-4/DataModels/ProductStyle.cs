namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductStyle")]
    public partial class ProductStyle
    {
        public int ProductStyleId { get; set; }

        public int ProductId { get; set; }

        public int StyleId { get; set; }

        public virtual Products Products { get; set; }

        public virtual Style Style { get; set; }
    }
}
