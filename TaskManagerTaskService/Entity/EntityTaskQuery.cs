using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Enum;

namespace TaskManagerTaskService.Entity
{
    public class EntityTaskQuery : EntityBasePageQuery
    {
        public EntityTaskQuery()
        {

            IsAll = true;
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        public bool IsAll { get; set; }

        public EnumStatus TaskStatus { get; set; }
    }
}
