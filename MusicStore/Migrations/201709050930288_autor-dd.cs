namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autordd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "DD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "DD");
        }
    }
}
