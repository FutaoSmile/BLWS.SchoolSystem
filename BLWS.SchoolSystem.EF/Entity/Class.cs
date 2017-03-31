﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLWS.SchoolSystem.EF.Entity
{
    public class Class : BaseEntity
    {

        /// <summary>
        /// 唯一标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 一个班级有N个学生
        /// </summary>
        public virtual List<Student> students { get; set; }
    }
}
