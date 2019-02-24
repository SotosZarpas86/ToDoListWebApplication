namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_UserID", "dbo.User");
            DropIndex("dbo.Tasks", new[] { "User_UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Tasks");
        }
    }
}
