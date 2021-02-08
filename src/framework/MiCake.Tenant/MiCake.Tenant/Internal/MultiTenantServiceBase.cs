using MiCake.Tenant.Abstractions;
using MiCake.Tenant.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Internal
{
#nullable enable
    public class MultiTenantServiceBase<TContext> : IMultiTenantService where TContext : class
    {
        protected MultiTenantOptions TenantOptions { get; set; }

        protected virtual InterceptorOperator CurrentInterceptorOperator { get; set; }

        private readonly ITenantIdentityHandler _identityHandler;
        private readonly ITenantStore _store;

        private readonly ILogger<MultiTenantServiceBase<TContext>> _logger;

        public MultiTenantServiceBase(
            IOptions<MultiTenantOptions> options,
            ITenantIdentityHandler identityHandler,
            ITenantStore tenantStore,
            ILoggerFactory loggerFactory)
        {
            TenantOptions = options.Value;

            _identityHandler = identityHandler;
            _store = tenantStore;
            _logger = loggerFactory.CreateLogger<MultiTenantServiceBase<TContext>>();

            CurrentInterceptorOperator = new InterceptorOperator(new TenantInterceptors(TenantOptions.Interceptors));
        }

        public virtual async Task<TenantContext?> Run(TContext context, CancellationToken cancellationToken = default)
        {
            TenantContext? tenantContext = null;

            var identity = await _identityHandler.GetIdentity(context, cancellationToken);
            if (string.IsNullOrWhiteSpace(identity))
            {
                _logger.LogWarning("The application is config multi-tenant,but current context is not found tenant-id.");

                await CurrentInterceptorOperator.IdentityFalid(context, TenantOptions, cancellationToken);
                return tenantContext;
            }

            await CurrentInterceptorOperator.IdentitySucceed(identity, context, TenantOptions, cancellationToken);

            ITenantInfo tenantInfo = null;
            if (TenantOptions.MultiTenantType != MultiTenantModeType.Table)
            {
                await CurrentInterceptorOperator.BeforeGetTenantInfo(identity, context, TenantOptions, cancellationToken);

                // get identity info from store.
                tenantInfo = await _store.GetTenantInfo(identity, cancellationToken);
                if (tenantInfo == null)
                {
                    _logger.LogWarning($"The application is config multi-tenant,but cannot find tenant info from store with tenant-id:[{identity}].");

                    await CurrentInterceptorOperator.TenantInfoFailed(identity, context, TenantOptions, cancellationToken);
                    return tenantContext;
                }

                await CurrentInterceptorOperator.TenantInfoSucceed(tenantInfo, context, TenantOptions, cancellationToken);
            }

            // generate tenant-context
            tenantContext = new TenantContext()
            {
                TenantInfo = tenantInfo,
                Options = TenantOptions
            };
            return tenantContext;
        }

        public Task<TenantContext?> Run(object context, CancellationToken cancellationToken = default)
        {
            var currentContext = context as TContext ?? throw new ArgumentException($"Current context type if {context.GetType().Name},but need {typeof(TContext).Name}");
            return Run(currentContext, cancellationToken);
        }
    }
}
