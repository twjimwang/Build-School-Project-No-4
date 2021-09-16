namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductPlan
    {
        [Key]
        public int PlanId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string GameAvailableDay { get; set; }

        public TimeSpan GameStartTime { get; set; }

        public TimeSpan GameEndTime { get; set; }

        public virtual Product Product { get; set; }
    }
}
