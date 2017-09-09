namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class limageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "ImageUrl");
        }
    }
}
