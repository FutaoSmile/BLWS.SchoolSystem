namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ScoreTables", "Score", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ScoreTables", "Score", c => c.Double(nullable: false));
        }
    }
}
