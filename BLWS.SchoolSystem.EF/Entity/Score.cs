using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class Score : BaseEntity
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// 所属学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>
        public string Teacher { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
    }
}
