namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Members", new[] { "CityId" });
            DropIndex("dbo.Members", new[] { "LanguageId" });
            AlterColumn("dbo.Members", "CityId", c => c.Int());
            AlterColumn("dbo.Members", "LanguageId", c => c.Int());
            CreateIndex("dbo.Members", "CityId");
            CreateIndex("dbo.Members", "LanguageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "LanguageId" });
            DropIndex("dbo.Members", new[] { "CityId" });
            AlterColumn("dbo.Members", "LanguageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "LanguageId");
            CreateIndex("dbo.Members", "CityId");
        }
    }
}
