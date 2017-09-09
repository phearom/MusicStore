namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autorkk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "KK", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "KK");
        }
    }
}
