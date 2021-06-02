namespace Broadway.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parent_Info", "StudentId", c => c.Int());
            CreateIndex("dbo.Parent_Info", "StudentId");
            AddForeignKey("dbo.Parent_Info", "StudentId", "dbo.Student_Info", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parent_Info", "StudentId", "dbo.Student_Info");
            DropIndex("dbo.Parent_Info", new[] { "StudentId" });
            DropColumn("dbo.Parent_Info", "StudentId");
        }
    }
}
