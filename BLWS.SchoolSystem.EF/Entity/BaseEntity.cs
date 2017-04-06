using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
   public class BaseEntity
    {
        public BaseEntity()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            CreateBy = "Admin_Create";
            UpdateBy = "Admin_Update";
        }
        /// <summary>
        /// 该数据的创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 该条数据的创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 该条数据的更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 该条数据的更新人
        /// </summary>
        public string UpdateBy { get; set; }
    }
}
