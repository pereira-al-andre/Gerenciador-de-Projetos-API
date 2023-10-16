using Microsoft.Extensions.DependencyInjection;
using Proj.Manager.Application.Services;
using Proj.Manager.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMembroService, MembroService>();
            services.AddTransient<IProjetoService, ProjetoService>();
            services.AddTransient<ITarefaService, TarefaService>();

            return services;
        }
    }
}
