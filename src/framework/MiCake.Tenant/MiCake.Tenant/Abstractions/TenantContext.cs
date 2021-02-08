namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// A context for currnt tenant.
    /// </summary>
    public class TenantContext
    {
        /// <summary>
        /// Current options for mulit-tenant.
        /// </summary>
        public MultiTenantOptions Options { get; set; }

        /// <summary>
        /// The <see cref="ITenantInfo"/> for current context.
        /// </summary>
        public ITenantInfo TenantInfo { get; set; }
    }
}
