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
    [Route("v0/groups")]
    public class GroupController : BaseApiController
    {
        public IGroupService GroupService { get; set; }


        /// <summary>
        /// 获得分组详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{groupId}")]
        public async Task<ResponseModel> GetGroupbyIdAsync(long groupId)
        {
            if (groupId <= 0) return Fail(ErrorCodeEnum.ParamIsNullArgument);

            return Success(await GroupService.GetGroupAsync(groupId));
        }

        /// <summary>
        /// 添分组信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddGrooupAsync([FromBody]EntityGroup entityGroup)
        {
            var result = await GroupService.AddGroupAsync(entityGroup);
            return Success(result);
        }

    }
}