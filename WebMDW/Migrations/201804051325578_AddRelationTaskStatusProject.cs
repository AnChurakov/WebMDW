namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationTaskStatusProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "Status_Id", c => c.Guid());
            AddColumn("dbo.ProjectModels", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.TaskModels", "Status_Id");
            AddForeignKey("dbo.TaskModels", "Status_Id", "dbo.StatusModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskModels", "Status_Id", "dbo.StatusModels");
            DropIndex("dbo.TaskModels", new[] { "Status_Id" });
            DropColumn("dbo.ProjectModels", "Price");
            DropColumn("dbo.TaskModels", "Status_Id");
        }
    }
}
