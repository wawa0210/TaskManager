using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerEntity.PageQuery;

namespace TaskManagerTaskService.Entity
{
    public class EntityTaskQuery: EntityBasePageQuery
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
    }
}
