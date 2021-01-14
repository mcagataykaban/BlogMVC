namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Articles", name: "IX_User_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Articles", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Articles", name: "ApplicationUserId", newName: "User_Id");
        }
    }
}
