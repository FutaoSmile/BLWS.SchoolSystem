
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class School : BaseEntity
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 校长名字
        /// </summary>
        public string SchoolMaster { get; set; }
        /// <summary>
        /// 学校地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 学校电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 学校邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 学校邮编
        /// </summary>
        public string PostCode { get; set; }
    }
}
