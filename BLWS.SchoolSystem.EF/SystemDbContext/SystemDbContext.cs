using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using BLWS.SchoolSystem.EF.Entity;
namespace BLWS.SchoolSystem.EF.SystemDbContext
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext() : base("name=DBConn")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        static SystemDbContext()
        {
            //一：数据库不存在时重新创建数据库[默认]
            Database.SetInitializer(new CreateDatabaseIfNotExists<SystemDbContext>());
            //二：每次启动应用程序时创建数据库
            //Database.SetInitializer<testContext>(new DropCreateDatabaseAlways<SpreadtrumPMMContext>());
            //三：策略三：模型更改时重新创建数据库
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SystemDbContext>());
            //策略四：从不创建数据库 
            //Database.SetInitializer<CodeFirstDBContext>(null);
        }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<ScoreTable> ScoreTables { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teahers { get; set; }


    }
}
