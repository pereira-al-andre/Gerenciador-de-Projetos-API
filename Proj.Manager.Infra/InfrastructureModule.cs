using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Infrastructure.Persistence.SQLServer;
using Proj.Manager.Infrastructure.Repositories.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            return services;
        }
    }
}
