﻿using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using Proj.Manager.Infrastructure.Repositories.SQLServer.Common;

namespace Proj.Manager.Infrastructure.Repositories.SQLServer
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(SqlServerDBContext context) : base(context)
        {
        }
    }
}
