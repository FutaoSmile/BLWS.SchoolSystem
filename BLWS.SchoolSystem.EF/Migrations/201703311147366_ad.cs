namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "Teacher", c => c.String());
            AddColumn("dbo.Scores", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "CourseName");
            DropColumn("dbo.Scores", "Teacher");
        }
    }
}
