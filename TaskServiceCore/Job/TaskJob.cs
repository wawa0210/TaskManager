using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskServiceCore.Job
{
    /// <summary>
    /// 任务执行类
    /// </summary>
    public class TaskJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var taskid = Convert.ToInt32(context.JobDetail.Key.Name);

        }
    }
}
