namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shutuperror : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            RenameColumn(table: "dbo.Like", name: "LikedPost_Id", newName: "PostId");
            AlterColumn("dbo.Like", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Like", "PostId");
            AddForeignKey("dbo.Like", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostId" });
            AlterColumn("dbo.Like", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Like", name: "PostId", newName: "LikedPost_Id");
            CreateIndex("dbo.Like", "LikedPost_Id");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id");
        }
    }
}
