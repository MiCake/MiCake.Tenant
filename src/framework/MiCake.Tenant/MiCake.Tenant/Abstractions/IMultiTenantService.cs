using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Abstractions
{
#nullable enable
    /// <summary>
    /// A service for support multi-tenant.
    /// </summary>
    public interface IMultiTenantService
    {
        /// <summary>
        /// According to the request context to complete multi tenant.
        /// <para>
        ///     when the execution is successful, 
        ///     you will access the context information of multi tenant through <see cref="TenantContext"/> by <see cref="ITenantContextAccessor"/>
        /// </para>
        /// </summary>
        /// <returns></returns>
        Task<TenantContext?> Run(object context, CancellationToken cancellationToken = default);
    }
}
