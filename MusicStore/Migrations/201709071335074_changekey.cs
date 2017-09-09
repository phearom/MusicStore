namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changekey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Localizes");
            AlterColumn("dbo.Localizes", "LocalizeKey", c => c.String(nullable: false, maxLength: 25, unicode: false));
            AddPrimaryKey("dbo.Localizes", new[] { "LocalizeKey", "LanguageKey" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Localizes");
            AlterColumn("dbo.Localizes", "LocalizeKey", c => c.String(nullable: false, maxLength: 5, unicode: false));
            AddPrimaryKey("dbo.Localizes", new[] { "LocalizeKey", "LanguageKey" });
        }
    }
}
