using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommonLib.Extensions;
using Dapper;
using TaskManagerBaseService;
using TaskManagerData.MicroOrm.SqlGenerator;
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
            CheckTaskCronExpress(entityTask);

            var taskRep = GetRepositoryInstance<TableTask>();
            var checkResult = await taskRep.FindAsync(x => x.Name == entityTask.Name);
            if (checkResult != null) throw new ArgumentException("该任务已存在，不能重复添加");

            var groupInfo = await GroupService.GetGroupAsync(entityTask.GroupId);
            if (groupInfo == null) throw new ArgumentException("该任务所属类别不存在");

            var model = entityTask.MapTo<TableTask>();
            var result = await taskRep.InsertAsync(model);
            if (!result) throw new ArgumentException("任务新增失败");
            entityTask.Id = model.Id;
            return entityTask;
        }

        private static void CheckTaskCronExpress(EntityTask entityTask)
        {
            if (!entityTask.CronExpress.IsValidateCronExpress()) throw new ArgumentException("Cron表达式不正确");
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

        public async Task<EntityTask> EditTaskAsync(EntityTask entityTask)
        {
            CheckTaskCronExpress(entityTask);

            var taskRep = GetRepositoryInstance<TableTask>();
            var checkResult = await taskRep.FindAsync(x => x.Name == entityTask.Name && x.Id != entityTask.Id);
            if (checkResult != null) throw new ArgumentException("任务名称重复");

            var groupInfo = await GroupService.GetGroupAsync(entityTask.GroupId);
            if (groupInfo == null) throw new ArgumentException("该任务所属类别不存在");
            var model = entityTask.MapTo<TableTask>();

            taskRep.Update(model);

            return entityTask;
        }

        public async Task<PageBase<EntityTask>> GetPageTaskAsync(EntityTaskQuery entityTaskQuery)
        {
            var result = new PageBase<EntityTask>
            {
                CurrentPage = entityTaskQuery.CurrentPage,
                PageSize = entityTaskQuery.PageSize
            };

            var strTotalSql = new StringBuilder();
            var strSql = new StringBuilder();

            //计算总数
            strTotalSql.Append(@"        
                            SELECT  COUNT(1)
                            FROM    T_Task  where 1=1  ");

            if (!entityTaskQuery.IsAll)
            {
                strTotalSql.Append(" and Status = @isEnable ");
            }
            if (!string.IsNullOrEmpty(entityTaskQuery.Name))
            {
                strTotalSql.Append(" and  Name like @name ");
            }

            //分页信息
            strSql.Append(@";  SELECT 
                               Id ,
                               GroupId ,
                               Name ,
                               CreateAt ,
                               UpdateAt ,
                               TaskType ,
                               RequestVerb ,
                               RequestUrl ,
                               Remark,
                               Description,
                               CronExpress,
                               Status FROM T_Task where 1=1 ");

            if (!entityTaskQuery.IsAll)
            {
                strSql.Append(" and Status=@isEnable ");
            }

            if (!string.IsNullOrEmpty(entityTaskQuery.Name))
            {
                strSql.Append(" and  Name like @name ");
            }


            strSql.Append(@"
                            order by CreateAt desc
                        ");
            strSql.Append(@" limit @startIndex,@pageSize ");

            var paras = new DynamicParameters(new
            {
                isEnable = entityTaskQuery.TaskStatus,
                name = "%" + entityTaskQuery.Name + "%",
                startIndex = (entityTaskQuery.CurrentPage - 1) * entityTaskQuery.PageSize,
                pageSize = entityTaskQuery.PageSize
            });
            var taskRep = GetRepositoryInstance<TableTask>();

            var sqlQuery = new SqlQuery(strSql.ToString(), paras);
            var listResult = await taskRep.FindAllAsync(sqlQuery);
            result.Items = Mapper.Map<List<TableTask>, List<EntityTask>>(listResult.AsList());
            result.TotalCounts = taskRep.Connection.ExecuteScalar<int>(strTotalSql.ToString(), paras);
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityTaskQuery.PageSize * 1.0)));
            return result;
        }

        public async Task<EntityTask> GetTaskAsync(long taskId)
        {
            var taskRep = GetRepositoryInstance<TableTask>();
            var result = await taskRep.FindAsync(x => x.Id == taskId);
            return result.MapTo<EntityTask>();
        }
    }
}
