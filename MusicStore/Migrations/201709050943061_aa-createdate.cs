namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aacreatedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumAuthors", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlbumAuthors", "CreateDate");
        }
    }
}
