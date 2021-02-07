namespace MiCake.Tenant
{
    /// <summary>
    /// Multi tenant mode type
    /// </summary>
    public enum MultiTenantModeType
    {
        /// <summary>
        /// One database per tenant
        /// </summary>
        Database,

        /// <summary>
        /// One database for all tenants, separated by shcema
        /// </summary>
        Schema,

        /// <summary>
        /// All users share the database, separated by the tenant-id field in the table.
        /// </summary>
        Table
    }
}
