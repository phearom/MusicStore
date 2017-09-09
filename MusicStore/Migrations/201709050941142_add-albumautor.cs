namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addalbumautor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumAuthors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlbumAuthors");
        }
    }
}
