using Microsoft.Extensions.DependencyInjection;
using Proj.Manager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Core
{
    public static class CoreModule
    {
        public static IServiceCollection CoreServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
