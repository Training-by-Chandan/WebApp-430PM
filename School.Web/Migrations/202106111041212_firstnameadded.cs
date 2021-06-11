namespace School.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstnameadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
