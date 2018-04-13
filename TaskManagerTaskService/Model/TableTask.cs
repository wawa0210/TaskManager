using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManagerTaskService.Model
{
    [Table("T_Task")]
    public class TableTask
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
        /// 组别编号 
        /// </summary>
        [Column("GroupId")]
        [Description("")]
        public long GroupId
        {
            get; set;
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        [Column("Name")]
        [Description("任务名称")]
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
        /// 更新时间
        /// </summary>
        [Column("UpdateAt")]
        [Description("更新时间")]
        public DateTime UpdateAt { get; set; }


        /// <summary>
        /// 任务类别
        /// </summary>
        [Column("TaskType")]
        [Description("任务类别")]
        public int TaskType { get; set; }

        /// <summary>
        /// RequestVerb
        /// </summary>
        [Column("RequestVerb")]
        [Description("RequestVerb")]
        public string RequestVerb { get; set; }

        /// <summary>
        /// RequestUrl
        /// </summary>
        [Column("RequestUrl")]
        [Description("RequestUrl")]
        public string RequestUrl { get; set; }

        /// <summary>
        /// RequestJson
        /// </summary>
        [Column("RequestJson")]
        [Description("RequestJson")]
        public string RequestJson { get; set; }

        /// <summary>
        /// RequestData
        /// </summary>
        [Column("Remark")]
        [Description("Remark")]
        public string Remark { get; set; }


        /// <summary>
        /// Desc
        /// </summary>
        [Column("Description")]
        [Description("Desc")]
        public string Description { get; set; }

        /// <summary>
        /// CronExpress
        /// </summary>
        [Column("CronExpress")]
        [Description("CronExpress")]
        public string CronExpress { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [Column("Status")]
        [Description("Status")]
        public int Status { get; set; }
    }
}
