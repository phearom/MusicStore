namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsEnable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "IsEnable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "IsEnable");
        }
    }
}
