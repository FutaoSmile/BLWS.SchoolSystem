namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentNO", c => c.String());
            AddColumn("dbo.Teachers", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "CourseName");
            DropColumn("dbo.Students", "StudentNO");
        }
    }
}
