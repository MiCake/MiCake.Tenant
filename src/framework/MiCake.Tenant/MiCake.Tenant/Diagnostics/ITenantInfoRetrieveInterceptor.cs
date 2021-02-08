using MiCake.Tenant.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Diagnostics
{
    public interface ITenantInfoRetrieveInterceptor : ITenantInterceptor
    {
        /// <summary>
        /// Before get tenant info.It's mean before get tenant info from <see cref="ITenantStore"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task BeforeGetTenantInfo(TenantInfoRetrieveContext context, CancellationToken cancellationToken = default);

        /// <summary>
        /// When retrieved tenant info succeed.
        /// </summary>
        /// <returns></returns>
        Task TenantInfoRetrieveSucceed(ITenantInfo tenantInfo, TenantInfoRetrieveContext context, CancellationToken cancellationToken = default);

        /// <summary>
        /// When retrieved tenant info falied.
        /// </summary>
        /// <returns></returns>
        Task TenantInfoRetrieveFailed(TenantInfoRetrieveContext context, CancellationToken cancellationToken = default);

    }

    /// <summary>
    /// A context for tenant info retrieve.
    /// </summary>
    public class TenantInfoRetrieveContext
    {
        /// <summary>
        /// The tenant id.
        /// </summary>
        public string TenantId { get; set; }

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
