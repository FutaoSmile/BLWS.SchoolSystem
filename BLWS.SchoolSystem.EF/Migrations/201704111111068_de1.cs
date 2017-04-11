namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseStudents", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.CourseStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Teachers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Scores", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Students", "Class_ID", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_ID" });
            DropIndex("dbo.Teachers", new[] { "Course_ID" });
            DropIndex("dbo.Scores", new[] { "Student_ID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_ID" });
            DropIndex("dbo.CourseStudents", new[] { "Student_ID" });
            DropColumn("dbo.Students", "Class_ID");
            DropColumn("dbo.Teachers", "Course_ID");
            DropColumn("dbo.Scores", "Student_ID");
            DropTable("dbo.CourseStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Student_ID });
            
            AddColumn("dbo.Scores", "Student_ID", c => c.Int());
            AddColumn("dbo.Teachers", "Course_ID", c => c.Int());
            AddColumn("dbo.Students", "Class_ID", c => c.Int());
            CreateIndex("dbo.CourseStudents", "Student_ID");
            CreateIndex("dbo.CourseStudents", "Course_ID");
            CreateIndex("dbo.Scores", "Student_ID");
            CreateIndex("dbo.Teachers", "Course_ID");
            CreateIndex("dbo.Students", "Class_ID");
            AddForeignKey("dbo.Students", "Class_ID", "dbo.Classes", "ID");
            AddForeignKey("dbo.Scores", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Teachers", "Course_ID", "dbo.Courses", "ID");
            AddForeignKey("dbo.CourseStudents", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudents", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
        }
    }
}
