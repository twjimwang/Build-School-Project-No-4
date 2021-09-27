namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentDetail
    {
        public int CommentDetailId { get; set; }

        public int ProductId { get; set; }

        public int MemberId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentDate { get; set; }

        public int StarLevel { get; set; }

        public string RecommendContent { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentUpdateDate { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
