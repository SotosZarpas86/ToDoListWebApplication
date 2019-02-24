namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "ID", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "ID");
        }
    }
}
