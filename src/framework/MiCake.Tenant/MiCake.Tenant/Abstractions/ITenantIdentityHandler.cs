using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// Defined a hanlder for multi tenant.It's used for get tenant-id from context(http context).
    /// </summary>
    public interface ITenantIdentityHandler
    {
        /// <summary>
        /// Get the tenant id from http context.
        /// </summary>
        /// <returns></returns>
        Task<string> GetIdentity(object context, CancellationToken cancellationToken = default);
    }
}
