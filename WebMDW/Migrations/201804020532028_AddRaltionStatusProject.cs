namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaltionStatusProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModels", "Status_Id", c => c.Guid());
            CreateIndex("dbo.ProjectModels", "Status_Id");
            AddForeignKey("dbo.ProjectModels", "Status_Id", "dbo.StatusModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectModels", "Status_Id", "dbo.StatusModels");
            DropIndex("dbo.ProjectModels", new[] { "Status_Id" });
            DropColumn("dbo.ProjectModels", "Status_Id");
        }
    }
}
