using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CommonLib.Extensions;
using TaskManagerTaskService.Enum;

namespace TaskManagerTaskService.Entity
{
    public class EntityGroup
    {
        public EntityGroup()
        {
            Id = GuidExtens.GuidToLongId();
            CreateAt = DateTime.Now;
            Remark = "";
            Status = EnumStatus.Enable;
        }
        public long Id { get; set; }

        [Required(ErrorMessage = "分组名称不能为空")]
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public string Remark { get; set; }

        public EnumStatus Status { get; set; }

    }
}
