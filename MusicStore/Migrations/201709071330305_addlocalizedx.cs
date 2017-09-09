namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlocalizedx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageKey = c.String(nullable: false, maxLength: 5, unicode: false),
                        LanguageValue = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageKey);
            
            CreateTable(
                "dbo.Localizes",
                c => new
                    {
                        LocalizeKey = c.String(nullable: false, maxLength: 5, unicode: false),
                        LanguageKey = c.String(nullable: false, maxLength: 5, unicode: false),
                        LocalizeValue = c.String(),
                    })
                .PrimaryKey(t => new { t.LocalizeKey, t.LanguageKey })
                .ForeignKey("dbo.Languages", t => t.LanguageKey, cascadeDelete: true)
                .Index(t => t.LanguageKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Localizes", "LanguageKey", "dbo.Languages");
            DropIndex("dbo.Localizes", new[] { "LanguageKey" });
            DropTable("dbo.Localizes");
            DropTable("dbo.Languages");
        }
    }
}
