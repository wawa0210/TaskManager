using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;

namespace TaskManagerTaskService.Application
{
    public interface ITaskLogService
    {
        // add edit select 

        Task<EntityTaskLog> AddTaskLogAsync(EntityTaskLog taskLog);


        Task<PageBase<EntityTaskLog>> GetPageTaskLogAsync();

    }
}
