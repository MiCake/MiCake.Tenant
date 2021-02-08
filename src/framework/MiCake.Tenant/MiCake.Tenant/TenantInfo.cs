using MiCake.Tenant.Abstractions;

namespace MiCake.Tenant
{
    /// <summary>
    /// A default structure for <see cref="ITenantInfo"/>
    /// </summary>
    public class TenantInfo : ITenantInfo
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string TenantDBConnectionString { get; set; }

        public TenantInfo()
        {
        }
    }
}
