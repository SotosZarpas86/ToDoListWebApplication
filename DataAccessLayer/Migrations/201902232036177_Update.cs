namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "User_UserID", "dbo.User");
            DropIndex("dbo.Tasks", new[] { "User_UserID" });
            RenameColumn(table: "dbo.Tasks", name: "User_UserID", newName: "UserId");
            AlterColumn("dbo.Tasks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "UserId");
            AddForeignKey("dbo.Tasks", "UserId", "dbo.User", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.User");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            AlterColumn("dbo.Tasks", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "UserId", newName: "User_UserID");
            CreateIndex("dbo.Tasks", "User_UserID");
            AddForeignKey("dbo.Tasks", "User_UserID", "dbo.User", "UserID");
        }
    }
}
