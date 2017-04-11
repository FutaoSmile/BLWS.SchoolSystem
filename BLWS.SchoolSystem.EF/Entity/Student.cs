using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class Student : BaseEntity
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNO { get; set; }
        /// <summary>
        /// 学生名字
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学生家庭住址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 所属班级名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
