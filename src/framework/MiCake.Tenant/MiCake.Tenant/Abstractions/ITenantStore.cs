using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// Define a store for storing all tenant information.
    /// </summary>
    public interface ITenantStore
    {
        /// <summary>
        /// Get tenant info from store by tenant id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>If the result does not exist, null is returned.</returns>
        Task<ITenantInfo> GetTenantInfo(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add current <see cref="ITenantInfo"/> to store.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> AddTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete current <see cref="ITenantInfo"/> from store.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete current <see cref="ITenantInfo"/> from store by tenant id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteTenantInfoById(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete current <see cref="ITenantInfo"/> from store.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default);
    }
}
