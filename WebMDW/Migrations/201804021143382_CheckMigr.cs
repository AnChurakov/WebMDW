namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckMigr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModels", "DateEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModels", "DateEnd", c => c.DateTime(nullable: false));
        }
    }
}
