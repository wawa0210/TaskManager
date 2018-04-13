using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CommonLib.Extensions;
using TaskManagerTaskService.Enum;

namespace TaskManagerTaskService.Entity
{
    public class EntityTask
    {
        public EntityTask()
        {
            Id = GuidExtens.GuidToLongId();
            CreateAt = DateTime.Now;
            RequestJson = "";
            Remark = "";
            Desc = "";
            TaskStatus = EnumStatus.Enable;
        }

        /// <summary>
        /// 属性: 
        /// </summary>
        public long Id
        {
            get; set;
        }

        /// <summary>
        /// 组别编号 
        /// </summary>
        [Required(ErrorMessage = "分组编号不能为空")]
        public long GroupId
        {
            get; set;
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        [Required(ErrorMessage = "任务名称不能为空")]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }


        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateAt { get; set; }


        /// <summary>
        /// 任务类别
        /// </summary>
        [Required(ErrorMessage = "任务类别不能为空")]
        public EnumTaskType TaskType { get; set; }

        /// <summary>
        /// RequestVerb
        /// </summary>
        [Required(ErrorMessage = "请求谓词不能为空")]
        public EnumRequestVerb RequestVerb { get; set; }

        /// <summary>
        /// RequestUrl
        /// </summary>
        [Required(ErrorMessage = "请求地址不能为空")]
        public string RequestUrl { get; set; }

        /// <summary>
        /// RequestJson
        /// </summary>
        public string RequestJson { get; set; }

        /// <summary>
        /// RequestData
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// Desc
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// CronExpress
        /// </summary>
        [Required(ErrorMessage = "Cron表达式不能为空")]
        public string CronExpress { get; set; }


        public EnumStatus TaskStatus { get; set; }
    }
}
