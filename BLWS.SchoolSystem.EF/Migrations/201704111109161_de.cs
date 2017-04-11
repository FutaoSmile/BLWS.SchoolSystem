namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "School_ID", "dbo.Schools");
            DropIndex("dbo.Teachers", new[] { "School_ID" });
            AddColumn("dbo.Teachers", "SchoolName", c => c.String());
            DropColumn("dbo.Teachers", "School_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "School_ID", c => c.Int());
            DropColumn("dbo.Teachers", "SchoolName");
            CreateIndex("dbo.Teachers", "School_ID");
            AddForeignKey("dbo.Teachers", "School_ID", "dbo.Schools", "ID");
        }
    }
}
