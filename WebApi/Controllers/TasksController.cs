using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerTaskService.Application;
using TaskManagerTaskService.Entity;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("v0/tasks")]
    public class TasksController : BaseApiController
    {
        public ITaskService TaskService { get; set; }

        /// <summary>
        /// 获得任务详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{taskId}")]
        public async Task<ResponseModel> GetTaskbyIdAsync(long taskId)
        {
            if (taskId<=0) return Fail(ErrorCodeEnum.ParamIsNullArgument);

            return Success(await TaskService.GetTaskAsync(taskId));
        }

        /// <summary>
        /// 分页获得任务信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("pages")]
        public async Task<ResponseModel> GetPageTaskAsync([FromQuery]EntityTaskQuery entityPageQuery)
        {
            var result = await TaskService.GetPageTaskAsync(entityPageQuery);

            return Success(result);
        }

        /// <summary>
        /// 添加任务信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddTaskAsync([FromBody]EntityTask entityTask)
        {
            var result = await TaskService.AddTaskAsync(entityTask);
            return Success(result);
        }

        /// <summary>
        /// 编辑任务信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<ResponseModel> EditTaskAsync([FromBody]EntityTask entityTask)
        {
            if (entityTask.Id <= 0) return Fail(ErrorCodeEnum.ParamIsNullArgument);
            var result = await TaskService.EditTaskAsync(entityTask);
            return Success(result);
        }
    }
}