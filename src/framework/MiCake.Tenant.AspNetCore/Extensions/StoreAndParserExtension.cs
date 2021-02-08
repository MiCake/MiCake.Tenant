using MiCake.Tenant;
using MiCake.Tenant.Abstractions;
using MiCake.Tenant.AspNetCore;
using MiCake.Tenant.AspNetCore.Parsers;
using MiCake.Tenant.AspNetCore.Stores;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StoreAndParserExtension
    {
        /// <summary>
        /// Use memory as a repository for tenant information.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MiCakeMultiTenantBuilder UseMemoryStore(this MiCakeMultiTenantBuilder builder)
        {
            builder.Services.TryAddSingleton<ITenantStore, InMemoryStore>();
            return builder;
        }

        /// <summary>
        /// Use memory as a repository for tenant information with existed initialization data.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="initializationData">Initialization data to be preheated.</param>
        /// <returns></returns>
        public static MiCakeMultiTenantBuilder UseMemoryStore(this MiCakeMultiTenantBuilder builder, IEnumerable<ITenantInfo> initializationData)
        {
            builder.Services.TryAddSingleton<ITenantStore>(factory =>
            {
                return new InMemoryStore(initializationData);
            });
            return builder;
        }

        /// <summary>
        /// Add the HTTP header parser to the tenant parser set.
        /// <para>
        ///     The parser identifies the value of the header named <see cref="MultiTenantConstants.HeaderName"/> in the HTTP request as tenant-id.
        /// </para>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MiCakeMultiTenantBuilder AddHttpHeaderParser(this MiCakeMultiTenantBuilder builder)
        {
            builder.Services.AddSingleton<ITenantIdentityParser, HttpHeaderParser>();
            return builder;
        }
    }
}
