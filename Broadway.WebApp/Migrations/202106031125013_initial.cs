namespace Broadway.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        Gender = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        HashedPassword = c.String(),
                        Email = c.String(),
                        UserType = c.Int(nullable: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Gender = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Student", "UserId", "dbo.Users");
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Users");
            DropTable("dbo.Student");
        }
    }
}
