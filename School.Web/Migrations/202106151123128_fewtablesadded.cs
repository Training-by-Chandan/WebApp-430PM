namespace School.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewtablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        RoomNo = c.String(),
                        TeacherId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SubjectCode = c.String(),
                        ClassId = c.Guid(),
                        TeacherId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropIndex("dbo.Subjects", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Classes");
        }
    }
}
