using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using Proj.Manager.Infrastructure.Repositories.SQLServer.Common;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class TaskRepository : Repository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(SqlServerDBContext context) : base(context)
        {
        }

        public void Delete(Core.Entities.Task entity)
        {
            try
            {
                _DbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
