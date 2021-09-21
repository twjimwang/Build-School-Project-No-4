namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "CityId", "dbo.Cities");
            DropIndex("dbo.Members", new[] { "CityId" });
            AlterColumn("dbo.Members", "CityId", c => c.Int());
            CreateIndex("dbo.Members", "CityId");
            AddForeignKey("dbo.Members", "CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "CityId", "dbo.Cities");
            DropIndex("dbo.Members", new[] { "CityId" });
            AlterColumn("dbo.Members", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "CityId");
            AddForeignKey("dbo.Members", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
    }
}
