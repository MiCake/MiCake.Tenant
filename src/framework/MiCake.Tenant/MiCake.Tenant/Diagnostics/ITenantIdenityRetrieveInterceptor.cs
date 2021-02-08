using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Diagnostics
{
    public interface ITenantIdenityRetrieveInterceptor : ITenantInterceptor
    {
        /// <summary>
        /// When retrieved tenant id succeed.
        /// </summary>
        /// <returns></returns>
        Task IdentityRetrieveSucceed(string tenantId, TenantIdentityRetrieveContext context, CancellationToken cancellationToken = default);

        /// <summary>
        /// When retrieved tenant id falied.
        /// </summary>
        /// <returns></returns>
        Task IdentityRetrieveFailed(TenantIdentityRetrieveContext context, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// A context for tenant identity retrieve.
    /// </summary>
    public class TenantIdentityRetrieveContext
    {
        /// <summary>
        /// The context of current request.
        /// </summary>
        public object Context { get; set; }

        /// <summary>
        /// <see cref="MultiTenantOptions"/>
        /// </summary>
        public MultiTenantOptions Options { get; set; }

    }
}
