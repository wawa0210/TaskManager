using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManagerTaskService.Model
{

    [Table("T_Group")]
    public class TableGroup
    {
        /// <summary>
        /// 属性: 
        /// </summary>
        [Column("Id")]
        [Key]
        [Description("")]
        public long Id
        {
            get; set;
        }

        /// <summary>
        /// 分组名字
        /// </summary>
        [Column("Name")]
        [Description("分组名字")]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateAt")]
        [Description("创建时间")]
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [Description("备注")]
        public string Remark
        {
            get; set;
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        [Column("Status")]
        [Description("当前状态")]
        public int Status { get; set; }
    }
}
