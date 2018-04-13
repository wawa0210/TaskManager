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
        [HttpGet, Authorize]
        [Route("{taskId}")]
        public async Task<ResponseModel> GetTaskbyIdAsync(long taskId)
        {
            if (taskId<=0) return Fail(ErrorCodeEnum.ParamIsNullArgument);

            return Success(await TaskService.GetTaskAsync(taskId));
        }

        /// <summary>
        /// 添加新闻信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddTaskAsync([FromBody]EntityTask entityTask)
        {
            var result = await TaskService.AddTaskAsync(entityTask);
            return Success(result);
        }
    }
}