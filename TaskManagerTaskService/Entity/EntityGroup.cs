using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManagerTaskService.Enum;

namespace TaskManagerTaskService.Entity
{
    public class EntityGroup
    {
        public EntityGroup()
        {
            CreateAt = DateTime.Now;
            Remark = "";
            GroupStatus = EnumGroupStatus.Enable;
        }
        public long Id { get; set; }

        [Required(ErrorMessage = "分组名称不能为空")]
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public string Remark { get; set; }

        public EnumGroupStatus GroupStatus { get; set; }

    }
}
