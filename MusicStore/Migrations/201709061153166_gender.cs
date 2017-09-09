namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            AddColumn("dbo.Authors", "GenderID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Authors", "GenderID");
            AddForeignKey("dbo.Authors", "GenderID", "dbo.Genders", "GenderID");
            DropColumn("dbo.Authors", "Sex");
            DropTable("dbo.Sexes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            AddColumn("dbo.Authors", "Sex", c => c.String());
            DropForeignKey("dbo.Authors", "GenderID", "dbo.Genders");
            DropIndex("dbo.Authors", new[] { "GenderID" });
            DropColumn("dbo.Authors", "GenderID");
            DropTable("dbo.Genders");
        }
    }
}
