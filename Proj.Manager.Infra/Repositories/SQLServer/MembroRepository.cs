using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using Proj.Manager.Infrastructure.Repositories.SQLServer.Common;
using System;
using System.Linq.Expressions;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        public MembroRepository(SqlServerDBContext context) : base(context)
        {
        }
    }
}
