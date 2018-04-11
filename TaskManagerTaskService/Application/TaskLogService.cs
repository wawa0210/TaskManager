using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;

namespace TaskManagerTaskService.Application
{
    public class TaskLogService : ITaskLogService
    {
        public Task<EntityTaskLog> AddTaskLogAsync(EntityTaskLog taskLog)
        {
            throw new NotImplementedException();
        }

        public Task<PageBase<EntityTaskLog>> GetPageTaskLogAsync()
        {
            throw new NotImplementedException();
        }
    }
}
