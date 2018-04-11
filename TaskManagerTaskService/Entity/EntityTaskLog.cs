using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManagerTaskService.Entity
{
    public class EntityTaskLog
    {
        /// <summary>
        /// 任务编号: 
        /// </summary>
        [Required(ErrorMessage = "编号不能为空")]
        public long TaskId
        {
            get; set;
        }

        /// <summary>
        /// 组别编号 
        /// </summary>
        [Required(ErrorMessage = "编号不能为空")]
        public long GroupId
        {
            get; set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// RequestUrl
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// RequestJson
        /// </summary>
        public string RequestJson { get; set; }

        /// <summary>
        /// RequestData
        /// </summary>
        public string RequestData { get; set; }

        /// <summary>
        /// RequestData
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// ExcuteStatus
        /// </summary>
        public int ExcuteStatus { get; set; }
    }
}
