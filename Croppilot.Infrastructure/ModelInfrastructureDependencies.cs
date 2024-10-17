using Croppilot.Infrastructure.Generics.Implementation;
using Croppilot.Infrastructure.Generics.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croppilot.Infrastructure
{
    public static class ModelInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return service;
        }
    }
}
