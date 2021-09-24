using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Build_School_Project_No_4.DataModels
{
    public partial class EPalContext : DbContext
    {
        public EPalContext()
            : base("name=EPalContext")
        {
        }

        public virtual DbSet<Chatlist> Chatlists { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentDetail> CommentDetails { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<GameCategory> GameCategories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LiveChat> LiveChats { get; set; }
        public virtual DbSet<MeetLike> MeetLikes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ProductPlan> ProductPlans { get; set; }
        public virtual DbSet<ProductPosition> ProductPositions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductServer> ProductServers { get; set; }
        public virtual DbSet<ProductStyle> ProductStyles { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<RecentVistor> RecentVistors { get; set; }
        public virtual DbSet<SatisfyTag> SatisfyTags { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Style> Styles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentDetail>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.CommentDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.GameCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Chatlists)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Chatlists1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CommentDetails)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Followings)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.FollowingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Followings1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.FollowingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.LiveChats)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.LiveReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.LiveChats1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.LiveSenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MeetLikes)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.LikeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MeetLikes1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.RecentVistors)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.RecentVistors1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.RecentVistorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageType>()
                .HasMany(e => e.Chatlists)
                .WithRequired(e => e.MessageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageType>()
                .HasMany(e => e.LiveChats)
                .WithRequired(e => e.MessageType)
                .HasForeignKey(e => e.LiveMessageTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.ProductPositions)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CommentDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductPlans)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductPositions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductServers)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductStyles)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisfyTag>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.SatisfyTag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Server>()
                .HasMany(e => e.ProductServers)
                .WithRequired(e => e.Server)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Style>()
                .HasMany(e => e.ProductStyles)
                .WithRequired(e => e.Style)
                .WillCascadeOnDelete(false);
        }
    }
}
