namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorrddkk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "KK");
            DropColumn("dbo.Authors", "DD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "DD", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "KK", c => c.Int(nullable: false));
        }
    }
}
