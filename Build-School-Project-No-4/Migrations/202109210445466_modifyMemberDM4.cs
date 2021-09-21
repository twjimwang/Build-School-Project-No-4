namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "CityId", "dbo.Cities");
            AddForeignKey("dbo.Members", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "CityId", "dbo.Cities");
            AddForeignKey("dbo.Members", "CityId", "dbo.Cities", "CityId");
        }
    }
}
