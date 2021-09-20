namespace TabimApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Request", "InputStream");
            DropColumn("dbo.Request", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Request", "FileName", c => c.String());
            AddColumn("dbo.Request", "InputStream", c => c.Binary());
        }
    }
}
