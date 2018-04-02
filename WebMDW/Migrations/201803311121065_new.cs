namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PriorityModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TaskModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.StageModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.StatusModels", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StatusModels", "Name", c => c.String());
            AlterColumn("dbo.StageModels", "Name", c => c.String());
            AlterColumn("dbo.ProjectModels", "Name", c => c.String());
            AlterColumn("dbo.TaskModels", "Name", c => c.String());
            AlterColumn("dbo.PriorityModels", "Name", c => c.String());
        }
    }
}
