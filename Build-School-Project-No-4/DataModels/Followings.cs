namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Followings
    {
        [Key]
        public int FollowId { get; set; }

        public int MemberId { get; set; }

        public int FollowingId { get; set; }

        public virtual Members Members { get; set; }

        public virtual Members Members1 { get; set; }
    }
}