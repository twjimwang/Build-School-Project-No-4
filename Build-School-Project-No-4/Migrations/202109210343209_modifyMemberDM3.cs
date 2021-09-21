namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "MemberName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "ProfilePicture", c => c.String());
            AlterColumn("dbo.Members", "Gender", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "ProfilePicture", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Members", "Gender", c => c.Int(nullable: false));
        }
    }
}
