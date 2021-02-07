using MiCake.Tenant.Diagnostics;
using System.Collections.Generic;

namespace MiCake.Tenant
{
    /// <summary>
    /// A options for MiCake.Tenant.
    /// </summary>
    public class MultiTenantOptions
    {
        /// <summary>
        /// The multi tenant mode type .
        /// <see cref="MultiTenantModeType"/>
        /// </summary>
        public MultiTenantModeType MultiTenantType { get; set; }

        private List<ITenantInterceptor> _interceptors = new List<ITenantInterceptor>();

        /// <summary>
        /// Add a interceptor to multi-tenant system.
        /// </summary>
        /// <param name="interceptor"></param>
        public void AddInterceptor(ITenantInterceptor interceptor)
            => _interceptors.Add(interceptor);

    }
}
