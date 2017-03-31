namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "School_ID", "dbo.Schools");
            DropForeignKey("dbo.Students", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.Scores", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Teachers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.CourseStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_ID", "dbo.Courses");
            DropIndex("dbo.CourseStudents", new[] { "Student_ID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_ID" });
            DropIndex("dbo.Scores", new[] { "Student_ID" });
            DropIndex("dbo.Teachers", new[] { "School_ID" });
            DropIndex("dbo.Teachers", new[] { "Course_ID" });
            DropIndex("dbo.Students", new[] { "Class_ID" });
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Schools");
            DropTable("dbo.Scores");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
