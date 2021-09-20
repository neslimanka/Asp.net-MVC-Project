namespace TabimApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "InputStream", c => c.Binary());
            AddColumn("dbo.Request", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Request", "FileName");
            DropColumn("dbo.Request", "InputStream");
        }
    }
}
