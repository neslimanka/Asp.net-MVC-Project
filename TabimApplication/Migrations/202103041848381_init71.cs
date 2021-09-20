namespace TabimApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init71 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Request", "Email");
        }
    }
}
