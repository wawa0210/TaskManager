using System;
using System.Data;

namespace TaskManagerData
{
    public interface IDapperDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
