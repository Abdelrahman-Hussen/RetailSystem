﻿using RetailSystem.Infrastructure.Reposatory;
using Microsoft.Extensions.DependencyInjection;

namespace RetailSystem.Infrastructure.DI
{
    public static class Bootstrap
    {
        public static IServiceCollection InfrastructureStrapping(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
