using MiCake.Tenant.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Diagnostics
{
    public class InterceptorOperator
    {
        private readonly ITenantInterceptors _interceptors;

        public InterceptorOperator(ITenantInterceptors interceptors)
        {
            _interceptors = interceptors;
        }

        /// <summary>
        /// Exec <see cref="ITenantIdenityRetrieveInterceptor.IdentityRetrieveSucceed(string, TenantIdentityRetrieveContext, CancellationToken)"/> of all registed interceptors.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task IdentitySucceed(string tenantId, object context, MultiTenantOptions options, CancellationToken cancellationToken = default)
        {
            var idInterceptors = _interceptors.Find<ITenantIdenityRetrieveInterceptor>();

            if (idInterceptors.Count() == 0)
                return;

            var retrieveContext = new TenantIdentityRetrieveContext()
            {
                Context = context,
                Options = options
            };

            foreach (var idInterceptor in idInterceptors)
            {
                await idInterceptor.IdentityRetrieveSucceed(tenantId, retrieveContext, cancellationToken);
            }
        }

        /// <summary>
        /// Exec <see cref="ITenantIdenityRetrieveInterceptor.IdentityRetrieveFailed(TenantIdentityRetrieveContext, CancellationToken)"/> of all registed interceptors.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task IdentityFalid(object context, MultiTenantOptions options, CancellationToken cancellationToken = default)
        {
            var idInterceptors = _interceptors.Find<ITenantIdenityRetrieveInterceptor>();

            if (idInterceptors.Count() == 0)
                return;

            var retrieveContext = new TenantIdentityRetrieveContext()
            {
                Context = context,
                Options = options
            };

            foreach (var idInterceptor in idInterceptors)
            {
                await idInterceptor.IdentityRetrieveFailed(retrieveContext, cancellationToken);
            }
        }

        /// <summary>
        /// Exec <see cref="ITenantInfoRetrieveInterceptor.BeforeGetTenantInfo(TenantInfoRetrieveContext, CancellationToken)"/> of all registed interceptors.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task BeforeGetTenantInfo(string tenantId, object context, MultiTenantOptions options, CancellationToken cancellationToken = default)
        {
            var infoInterceptors = _interceptors.Find<ITenantInfoRetrieveInterceptor>();

            if (infoInterceptors.Count() == 0)
                return;

            var retrieveContext = new TenantInfoRetrieveContext()
            {
                TenantId = tenantId,
                Context = context,
                Options = options
            };

            foreach (var infoInterceptor in infoInterceptors)
            {
                await infoInterceptor.BeforeGetTenantInfo(retrieveContext, cancellationToken);
            }
        }

        /// <summary>
        /// Exec <see cref="ITenantInfoRetrieveInterceptor.TenantInfoRetrieveFailed(TenantInfoRetrieveContext, CancellationToken)"/> of all registed interceptors.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task TenantInfoFailed(string tenantId, object context, MultiTenantOptions options, CancellationToken cancellationToken = default)
        {
            var infoInterceptors = _interceptors.Find<ITenantInfoRetrieveInterceptor>();

            if (infoInterceptors.Count() == 0)
                return;

            var retrieveContext = new TenantInfoRetrieveContext()
            {
                TenantId = tenantId,
                Context = context,
                Options = options
            };

            foreach (var infoInterceptor in infoInterceptors)
            {
                await infoInterceptor.TenantInfoRetrieveFailed(retrieveContext, cancellationToken);
            }
        }

        /// <summary>
        /// Exec <see cref="ITenantInfoRetrieveInterceptor.TenantInfoRetrieveSucceed(Abstractions.ITenantInfo, TenantInfoRetrieveContext, CancellationToken)"/> of all registed interceptors.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task TenantInfoSucceed(ITenantInfo tenantInfo, object context, MultiTenantOptions options, CancellationToken cancellationToken = default)
        {
            var infoInterceptors = _interceptors.Find<ITenantInfoRetrieveInterceptor>();

            if (infoInterceptors.Count() == 0)
                return;

            var retrieveContext = new TenantInfoRetrieveContext()
            {
                TenantId = tenantInfo.TenantId,
                Context = context,
                Options = options
            };

            foreach (var infoInterceptor in infoInterceptors)
            {
                await infoInterceptor.TenantInfoRetrieveSucceed(tenantInfo, retrieveContext, cancellationToken);
            }
        }
    }
}
