using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerBaseService;
using TaskManagerData.MicroOrm;
using TaskManagerEntity.PageQuery;
using TaskManagerTaskService.Entity;
using TaskManagerTaskService.Enum;
using TaskManagerTaskService.Model;

namespace TaskManagerTaskService.Application
{
    public class GroupService : BaseAppService, IGroupService
    {
        public async Task<EntityGroup> AddGroupAsync(EntityGroup entityGroup)
        {
            var groupRep = GetRepositoryInstance<TableGroup>();
            var checkResult = await groupRep.FindAsync(x => x.Name == entityGroup.Name);
            if (checkResult != null) throw new ArgumentException("该分组已存在，不能重复添加");
            var model = entityGroup.MapTo<TableGroup>();
            var result = await groupRep.InsertAsync(model);
            if (!result) throw new ArgumentException("新增失败");
            entityGroup.Id = model.Id;
            return entityGroup;
        }

        public async Task<bool> DisableGroupAsync(long id)
        {
            var groupRep = GetRepositoryInstance<TableGroup>();

            var model = await GetGroupByIdAsync(id);
            model.Status = (int)EnumStatus.Disable;

            //todo: 同时禁用对应组别的所有任务

            return groupRep.Update<TableGroup>(model, item => new
            {
                item.Status
            });
        }

        private async Task<TableGroup> GetGroupByIdAsync(long id)
        {
            if (id <= 0) throw new ArgumentException("参数不合法");
            var groupRep = GetRepositoryInstance<TableGroup>();

            var model = await groupRep.FindAsync(x => x.Id == id);
            if (model == null) throw new ArgumentException("id错误");
            return model;
        }

        public async Task<EntityGroup> GetGroupAsync(long id)
        {
            var groupRep = GetRepositoryInstance<TableGroup>();
            var result = await groupRep.FindAsync(x => x.Id == id);

            return result?.MapTo<EntityGroup>();
        }

        public async Task<PageBase<EntityGroup>> GetPageGroupAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EntityGroup> UpdateGroupAsync(EntityGroup entityGroup)
        {
            var model = await GetGroupByIdAsync(entityGroup.Id);
            model.Name = entityGroup.Name;
            model.Remark = entityGroup.Remark;
            var groupRep = GetRepositoryInstance<TableGroup>();
            groupRep.Update(model);
            return entityGroup;
        }
    }
}
