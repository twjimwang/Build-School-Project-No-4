namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentDetail()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentDetailId { get; set; }

        public int ProductId { get; set; }

        public int MemberId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentDate { get; set; }

        public int StarLevel { get; set; }

        public string RecommendContent { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentUpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
