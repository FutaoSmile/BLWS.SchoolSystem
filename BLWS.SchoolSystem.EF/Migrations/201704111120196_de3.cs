namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScoreTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentNO = c.String(),
                        StudentName = c.String(),
                        CourseName = c.String(),
                        Score = c.Double(nullable: false),
                        TeacherName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Scores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        StudentName = c.String(),
                        Teacher = c.String(),
                        CourseName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.ScoreTables");
        }
    }
}
