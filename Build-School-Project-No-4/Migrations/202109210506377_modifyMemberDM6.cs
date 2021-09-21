namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Members", new[] { "CityId" });
            AlterColumn("dbo.Members", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "TimeZone", c => c.Int());
            CreateIndex("dbo.Members", "CityId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "CityId" });
            AlterColumn("dbo.Members", "TimeZone", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "CityId", c => c.Int());
            CreateIndex("dbo.Members", "CityId");
        }
    }
}
