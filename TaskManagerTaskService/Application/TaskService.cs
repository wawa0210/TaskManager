using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerBaseService;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;
using TaskManagerTaskService.Enum;
using TaskManagerTaskService.Model;

namespace TaskManagerTaskService.Application
{
    public class TaskService : BaseAppService, ITaskService
    {
        public IGroupService GroupService { get; set; }

        public async Task<EntityTask> AddTaskAsync(EntityTask entityTask)
        {
            var taskRep = GetRepositoryInstance<TableTask>();
            var checkResult = await taskRep.FindAsync(x => x.Name == entityTask.Name);
            if (checkResult != null) throw new ArgumentException("该任务已存在，不能重复添加");

            var groupInfo = GroupService.GetGroupAsync(entityTask.GroupId);
            if (groupInfo == null) throw new ArgumentException("该任务所属类别不存在");

            var model = entityTask.MapTo<TableTask>();
            var result = await taskRep.InsertAsync(model);
            if (!result) throw new ArgumentException("任务新增失败");
            entityTask.Id = model.Id;
            return entityTask;
        }

        public async Task DisableTaskAsync(long taskId)
        {
            var taskRep = GetRepositoryInstance<TableTask>();
            var model = await taskRep.FindAsync(x => x.Id == taskId);
            if (model == null) throw new ArgumentException("taskId错误");
            model.Status = (int)EnumStatus.Disable;
            //todo: 同时禁用对应组别的所有任务

            taskRep.Update<TableGroup>(model, item => new
            {
                item.Status
            });

        }

        public Task<EntityTask> EditTaskAsync(EntityTask entityTask)
        {
            throw new NotImplementedException();
        }

        public Task<PageBase<EntityTask>> GetPageTaskAsync(EntityTaskQuery entityTaskQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<EntityTask> GetTaskAsync(long taskId)
        {
            var taskRep = GetRepositoryInstance<TableTask>();
            var result = await taskRep.FindAsync(x => x.Id == taskId);
            return result.MapTo<EntityTask>();
        }
    }
}
