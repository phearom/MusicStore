namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "Order");
        }
    }
}
