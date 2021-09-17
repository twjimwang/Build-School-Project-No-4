namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Following
    {
        [Key]
        public int FollowId { get; set; }

        public int MemberId { get; set; }

        public int FollowingId { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member Member1 { get; set; }
    }
}
