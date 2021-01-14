﻿namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailSubAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailSubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailSubs");
        }
    }
}
