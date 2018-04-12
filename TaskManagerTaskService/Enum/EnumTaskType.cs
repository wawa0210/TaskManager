using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerTaskService.Enum
{
    public enum EnumTaskType : int
    {
        Exe = 1,

        Http = 2
    }


    public enum EnumRequestVerb : int
    {
        Post = 1,

        Get = 2,

        Patch = 3,

        Put = 4,

    }
}
