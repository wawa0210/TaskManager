using System.Data;

namespace TaskManagerData
{
    public interface IDbContextFactory
    {
        IDbConnection GetDbContext();
    }
}