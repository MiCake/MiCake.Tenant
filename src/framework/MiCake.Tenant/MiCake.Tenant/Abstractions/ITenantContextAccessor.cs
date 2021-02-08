namespace MiCake.Tenant.Abstractions
{
#nullable enable
    /// <summary>
    /// Provides access to the current <see cref="TenantContext"/>, if one is available.
    /// </summary>
    public interface ITenantContextAccessor
    {
        /// <summary>
        /// Gets or sets the current <see cref="TenantContext"/>
        /// Returns null if there is no active.
        /// </summary>
        TenantContext? TenantContext { get; set; }
    }
}
