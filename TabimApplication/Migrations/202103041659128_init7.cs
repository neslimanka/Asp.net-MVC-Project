namespace TabimApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "FeedBack", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Request", "FeedBack");
        }
    }
}
