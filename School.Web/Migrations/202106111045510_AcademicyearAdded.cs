namespace School.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcademicyearAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Academic_Year",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        YearName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Academic_Year");
        }
    }
}
