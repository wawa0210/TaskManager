using System.Data;

namespace TaskManagerData
{
    public class DapperDbContext : IDapperDbContext
    {
        public DapperDbContext(IDbConnection connection)
        {
            InnerConnection = connection;
        }

        protected readonly IDbConnection InnerConnection;

        public virtual IDbConnection Connection => InnerConnection;

        public void Dispose()
        {
            if (InnerConnection != null && InnerConnection.State != ConnectionState.Closed)
            {
                InnerConnection.Close();
                InnerConnection.Dispose();
            }
            
        }
    }
}
