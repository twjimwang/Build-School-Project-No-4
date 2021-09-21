namespace Build_School_Project_No_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberDM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "Bio", c => c.String());
            AlterColumn("dbo.Members", "LineStatus", c => c.String(maxLength: 50, fixedLength: true));
            //AlterColumn("dbo.Members", "RegistrationDate", c => c.DateTime(nullable: true));
            //AlterColumn("dbo.Members", "TimeZone", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LineStatus", c => c.String(nullable: false, maxLength: 50, fixedLength: true));
            AlterColumn("dbo.Members", "Bio", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Phone", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Members", "RegistrationDate", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.Members", "TimeZone", c => c.Int(nullable: false));
        }
    }
}
