namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationProjectTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModelTaskModels",
                c => new
                    {
                        ProjectModel_Id = c.Guid(nullable: false),
                        TaskModel_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectModel_Id, t.TaskModel_Id })
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.TaskModels", t => t.TaskModel_Id, cascadeDelete: true)
                .Index(t => t.ProjectModel_Id)
                .Index(t => t.TaskModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectModelTaskModels", "TaskModel_Id", "dbo.TaskModels");
            DropForeignKey("dbo.ProjectModelTaskModels", "ProjectModel_Id", "dbo.ProjectModels");
            DropIndex("dbo.ProjectModelTaskModels", new[] { "TaskModel_Id" });
            DropIndex("dbo.ProjectModelTaskModels", new[] { "ProjectModel_Id" });
            DropTable("dbo.ProjectModelTaskModels");
        }
    }
}
