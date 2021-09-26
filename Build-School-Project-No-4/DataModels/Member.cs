namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Chatlists = new HashSet<Chatlist>();
            Chatlists1 = new HashSet<Chatlist>();
            CommentDetails = new HashSet<CommentDetail>();
            Followings = new HashSet<Following>();
            Followings1 = new HashSet<Following>();
            LiveChats = new HashSet<LiveChat>();
            LiveChats1 = new HashSet<LiveChat>();
            MeetLikes = new HashSet<MeetLike>();
            MeetLikes1 = new HashSet<MeetLike>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            RecentVistors = new HashSet<RecentVistor>();
            RecentVistors1 = new HashSet<RecentVistor>();
        }

        public int MemberId { get; set; }

        [StringLength(50)]
        public string MemberName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public int? CityId { get; set; }

        public int? Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        public int? TimeZone { get; set; }

        public int? LanguageId { get; set; }

        public string Bio { get; set; }

        public string ProfilePicture { get; set; }

        [StringLength(50)]
        public string LineStatus { get; set; }

        [StringLength(10)]
        public string AuthCode { get; set; }

        public bool? IsAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chatlist> Chatlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chatlist> Chatlists1 { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Following> Followings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Following> Followings1 { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiveChat> LiveChats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiveChat> LiveChats1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetLike> MeetLikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetLike> MeetLikes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecentVistor> RecentVistors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecentVistor> RecentVistors1 { get; set; }
    }
}
