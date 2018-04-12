using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;

namespace TaskManagerTaskService.Application
{
    public interface ITaskService
    {
        Task<EntityTask> AddTaskAsync(EntityTask entityTask);

        Task<EntityTask> EditTaskAsync(EntityTask entityTask);

        Task<EntityTask> GetTaskAsync(long taskId);

        Task<PageBase<EntityTask>> GetPageTaskAsync(EntityTaskQuery entityTaskQuery);

        Task DisableTaskAsync(long taskId);

    }
}
