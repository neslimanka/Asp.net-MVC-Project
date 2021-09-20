namespace TabimApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Request", "AssessmentStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Request", "AssessmentStatus", c => c.Int(nullable: false));
        }
    }
}
