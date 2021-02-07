using Microsoft.Extensions.DependencyInjection;
using System;

namespace MiCake.Tenant.AspNetCore
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMultiTenant(this IServiceCollection services, Action<MultiTenantOptions> options)
        {
            services.AddMultiTenantCore(options);

            return services;
        }
    }
}
