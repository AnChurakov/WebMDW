namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullDateTaskModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskModels", "DateEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskModels", "DateEnd", c => c.DateTime(nullable: false));
        }
    }
}
