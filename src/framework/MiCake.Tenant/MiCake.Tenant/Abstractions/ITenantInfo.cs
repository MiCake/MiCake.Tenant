namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// Define the basic information of the tenant.
    /// <para>
    ///     You can inherit the interface to implement your own structure.
    /// </para>
    /// </summary>
    public interface ITenantInfo
    {
        /// <summary>
        /// The name of the tenant.
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Unique identity of the tenant.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The database connection string of the tenant.
        /// </summary>
        public string TenantDBConnectionString { get; set; }
    }
}
