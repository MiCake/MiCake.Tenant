using MiCake.Tenant;
using MiCake.Tenant.Abstractions;
using MiCake.Tenant.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MultiTenantServiceCollectionExtension
    {
        /// <summary>
        /// Add Multi-Tenant services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static MiCakeMultiTenantBuilder AddMultiTenant(this IServiceCollection services, Action<MultiTenantOptions> options)
        {
            services.AddMultiTenantCore(options);
            services.TryAddScoped<IMultiTenantService, MultiTenantServiceBase<HttpContext>>();  // for asp net core,the context is HttpContext.

            return new MiCakeMultiTenantBuilder(services);
        }
    }
}
