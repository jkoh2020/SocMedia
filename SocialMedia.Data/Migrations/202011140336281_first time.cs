namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firsttime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "Post_Id" });
            DropColumn("dbo.Comment", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Post_Id", c => c.Int());
            CreateIndex("dbo.Comment", "Post_Id");
            AddForeignKey("dbo.Comment", "Post_Id", "dbo.Post", "Id");
        }
    }
}
