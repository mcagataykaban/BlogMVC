namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailSub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmailSubs", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmailSubs", "Email", c => c.String());
        }
    }
}
