namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AlbumAuthors", "AlbumId");
            CreateIndex("dbo.AlbumAuthors", "AuthorId");
            AddForeignKey("dbo.AlbumAuthors", "AlbumId", "dbo.Albums", "AlbumID", cascadeDelete: true);
            AddForeignKey("dbo.AlbumAuthors", "AuthorId", "dbo.Authors", "AuthorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.AlbumAuthors", "AlbumId", "dbo.Albums");
            DropIndex("dbo.AlbumAuthors", new[] { "AuthorId" });
            DropIndex("dbo.AlbumAuthors", new[] { "AlbumId" });
        }
    }
}
