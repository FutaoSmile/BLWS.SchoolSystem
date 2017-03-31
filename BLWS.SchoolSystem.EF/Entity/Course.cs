using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class Course : BaseEntity
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 一门课程有N个学生
        /// </summary>
        public virtual List<Student> Students { get; set; }
        /// <summary>
        /// 一门课程有N个老师
        /// </summary>
        public virtual List<Teacher> Teachers { get; set; }
    }
}
