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
        /// 学分
        /// </summary>
        public string Credit { get; set; }
        /// <summary>
        /// 课程介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 课程属性
        /// </summary>
        public string Property { get; set; }
    }
}
