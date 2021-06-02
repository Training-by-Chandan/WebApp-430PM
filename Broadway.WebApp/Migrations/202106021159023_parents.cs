namespace Broadway.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parent_Info",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentName = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parent_Info");
        }
    }
}
