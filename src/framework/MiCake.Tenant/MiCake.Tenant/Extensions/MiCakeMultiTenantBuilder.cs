using Microsoft.Extensions.DependencyInjection;

namespace MiCake.Tenant
{
    /// <summary>
    /// The config builder for MiCake.Tenant.
    /// </summary>
    public class MiCakeMultiTenantBuilder
    {
        public IServiceCollection Services { get; }

        public MiCakeMultiTenantBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
