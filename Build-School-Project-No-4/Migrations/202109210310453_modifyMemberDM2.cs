namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Country", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Country", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
