namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        public int CommentDetailId { get; set; }

        public int SatisfyTagId { get; set; }

        public virtual SatisfyTag SatisfyTag { get; set; }
    }
}
