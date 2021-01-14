namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentAuthorAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentAuthor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentAuthor");
        }
    }
}
