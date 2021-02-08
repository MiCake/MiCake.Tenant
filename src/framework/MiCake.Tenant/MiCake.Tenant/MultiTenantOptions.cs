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
        /// The multi tenant mode type.
        /// <see cref="MultiTenantModeType"/>
        /// </summary>
        public MultiTenantModeType MultiTenantType { get; set; }

        /// <summary>
        /// Interceptors for multi tenant.
        /// </summary>
        public List<ITenantInterceptor> Interceptors { get; } = new List<ITenantInterceptor>();
    }
}
