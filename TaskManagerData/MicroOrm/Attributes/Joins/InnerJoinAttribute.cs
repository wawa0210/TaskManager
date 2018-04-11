﻿namespace TaskManagerData.MicroOrm.Attributes.Joins
{
    public class InnerJoinAttribute : JoinAttributeBase
    {
        public InnerJoinAttribute()
        {
        }

        public InnerJoinAttribute(string tableName, string key, string externalKey)
            : base(tableName, key, externalKey)
        {
        }
    }
}
