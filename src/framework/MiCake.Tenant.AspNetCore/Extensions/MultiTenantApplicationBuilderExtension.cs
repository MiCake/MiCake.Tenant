using MiCake.Tenant.AspNetCore.Internal;

namespace Microsoft.AspNetCore.Builder
{
    public static class MultiTenantApplicationBuilderExtension
    {
        /// <summary>
        /// Add multi-tenant middleware to application.
        /// </summary>
        /// <param name="builder"></param>
        public static void UseMultiTenant(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<MultiTenantMiddleware>();
        }
    }
}
