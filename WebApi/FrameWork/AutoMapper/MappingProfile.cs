using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerTaskService.Entity;
using TaskManagerTaskService.Model;

namespace WebApi.FrameWork.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TableTask, EntityTask>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.GroupId, y => y.MapFrom(z => z.GroupId))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.CreateAt, y => y.MapFrom(z => z.CreateAt))
            .ForMember(x => x.UpdateAt, y => y.MapFrom(z => z.UpdateAt))
            .ForMember(x => x.TaskType, y => y.MapFrom(z => z.TaskType))
            .ForMember(x => x.RequestVerb, y => y.MapFrom(z => z.RequestVerb))
            .ForMember(x => x.RequestUrl, y => y.MapFrom(z => z.RequestUrl))
            .ForMember(x => x.RequestJson, y => y.MapFrom(z => z.RequestJson))
            .ForMember(x => x.Remark, y => y.MapFrom(z => z.Remark))
            .ForMember(x => x.Desc, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.CronExpress, y => y.MapFrom(z => z.CronExpress))
            .ForMember(x => x.TasStatus, y => y.MapFrom(z => z.Status))
            .ForAllOtherMembers(x => x.Ignore());

            CreateMap<EntityTask, TableTask>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.GroupId, y => y.MapFrom(z => z.GroupId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.CreateAt, y => y.MapFrom(z => z.CreateAt))
                .ForMember(x => x.UpdateAt, y => y.MapFrom(z => z.UpdateAt))
                .ForMember(x => x.TaskType, y => y.MapFrom(z => z.TaskType))
                .ForMember(x => x.RequestVerb, y => y.MapFrom(z => z.RequestVerb))
                .ForMember(x => x.RequestUrl, y => y.MapFrom(z => z.RequestUrl))
                .ForMember(x => x.RequestJson, y => y.MapFrom(z => z.RequestJson))
                .ForMember(x => x.Remark, y => y.MapFrom(z => z.Remark))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Desc))
                .ForMember(x => x.CronExpress, y => y.MapFrom(z => z.CronExpress))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.TasStatus))
                .ForAllOtherMembers(x => x.Ignore());

            // CreateMap<TableNews, EntityListNews>();
            //.ForMember(x => x.NewsId, y => y.MapFrom(z => z.NewsId))
            //.ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            //.ForMember(x => x.ShortContent, y => y.MapFrom(z => z.ShortContent))
            //.ForMember(x => x.HrefUrl, y => y.MapFrom(z => z.HrefUrl))
            //.ForMember(x => x.CreateTime, y => y.MapFrom(z => z.CreateTime))
            //.ForMember(x => x.IsEnable, y => y.MapFrom(z => z.IsEnable))
            //.ForMember(x => x.Media, y => y.MapFrom(z => z.Media))
            //.ForMember(x => x.NewsType, y => y.MapFrom(z => z.NewsType))
            //.ForAllOtherMembers(x => x.Ignore());
        }
    }
}
