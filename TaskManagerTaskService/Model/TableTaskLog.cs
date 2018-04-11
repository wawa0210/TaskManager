using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManagerTaskService.Model
{
    [Table("T_Task_Log")]
    public class TableTaskLog
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
        /// 任务编号: 
        /// </summary>
        [Column("TaskId")]
        [Description("")]
        public long TaskId
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
        /// 开始时间
        /// </summary>
        [Column("BeginTime")]
        [Description("开始时间")]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("EndTime")]
        [Description("结束时间")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// RequestUrl
        /// </summary>
        [Column("RequestUrl")]
        [Description("请求地址")]
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
        [Column("RequestData")]
        [Description("RequestData")]
        public string RequestData { get; set; }

        /// <summary>
        /// RequestData
        /// </summary>
        [Column("Remark")]
        [Description("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// ExcuteStatus
        /// </summary>
        [Column("ExcuteStatus")]
        [Description("ExcuteStatus")]
        public int ExcuteStatus { get; set; }
    }
}
