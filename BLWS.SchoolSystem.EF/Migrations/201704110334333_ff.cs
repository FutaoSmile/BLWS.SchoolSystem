namespace BLWS.SchoolSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        ClassMaster = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Address = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        ClassName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        Class_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.Class_ID)
                .Index(t => t.Class_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Credit = c.String(),
                        Description = c.String(),
                        Property = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        Office = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        School_ID = c.Int(),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.School_ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.School_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        SchoolMaster = c.String(),
                        Address = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        PostCode = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Student_ID })
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Course_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.Scores", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Teachers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Teachers", "School_ID", "dbo.Schools");
            DropForeignKey("dbo.CourseStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_ID", "dbo.Courses");
            DropIndex("dbo.CourseStudents", new[] { "Student_ID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_ID" });
            DropIndex("dbo.Scores", new[] { "Student_ID" });
            DropIndex("dbo.Teachers", new[] { "Course_ID" });
            DropIndex("dbo.Teachers", new[] { "School_ID" });
            DropIndex("dbo.Students", new[] { "Class_ID" });
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Scores");
            DropTable("dbo.Schools");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
