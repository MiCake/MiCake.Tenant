namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// A context for currnt tenant.
    /// </summary>
    public class TenantContext
    {
        public MultiTenantOptions Options { get; set; }

        public ITenantInfo TenantInfo { get; set; }
    }
}
