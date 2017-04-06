using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class Teacher : BaseEntity
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 教师名字
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 办公室
        /// </summary>
        public string Office { get; set; }
        /// <summary>
        /// 一个教师只属于一个学校
        /// </summary>
        public virtual School School{get;set;}
    }
}
