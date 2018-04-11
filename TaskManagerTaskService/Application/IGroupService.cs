using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;

namespace TaskManagerTaskService.Application
{
    public interface IGroupService
    {
        Task<EntityGroup> AddGroupAsync(EntityGroup entityGroup);

        Task<EntityGroup> GetGroupAsync(long id);

        Task<EntityGroup> UpdateGroupAsync(EntityGroup entityGroup);

        Task<bool> DisableGroupAsync(long id);

        Task<PageBase<EntityGroup>> GetPageGroupAsync();
    }
}
