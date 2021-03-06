﻿using MiCake.Tenant.Abstractions;
using MiCake.Tenant.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MiCake.Tenant
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add core multi-tenant services to <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiTenantCore(this IServiceCollection services, Action<MultiTenantOptions> options)
        {
            services.AddSingleton<ITenantContextAccessor, TenantContextAccessor>();
            services.AddSingleton<ITenantIdentityHandler, TenantIdentityHandler>();
            services.Configure(options);

            return services;
        }
    }
}
