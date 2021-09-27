namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CommentDetails = new HashSet<CommentDetail>();
            Orders = new HashSet<Order>();
            ProductPlans = new HashSet<ProductPlan>();
            ProductPositions = new HashSet<ProductPosition>();
            ProductServers = new HashSet<ProductServer>();
            ProductStyles = new HashSet<ProductStyle>();
        }

        public int ProductId { get; set; }

        public int GameCategoryId { get; set; }

        public int CreatorId { get; set; }

        public decimal UnitPrice { get; set; }

        [Required]
        public string ProductImg { get; set; }

        public string RecommendationVoice { get; set; }

        [Required]
        public string Introduction { get; set; }

        public int? RankId { get; set; }

        [Required]
        public string CreatorImg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }

        public virtual GameCategory GameCategory { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPlan> ProductPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPosition> ProductPositions { get; set; }

        public virtual Rank Rank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductServer> ProductServers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductStyle> ProductStyles { get; set; }
    }
}
