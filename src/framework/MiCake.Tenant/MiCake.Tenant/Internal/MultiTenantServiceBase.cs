using MiCake.Tenant.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Internal
{
    public class MultiTenantServiceBase<TContext> : IMultiTenantService where TContext : class
    {
        protected MultiTenantOptions TenantOptions { get; set; }

        private readonly ITenantIdentityHandler _identityHandler;
        private readonly ITenantStore _store;
        private readonly ITenantContextAccessor _contextAccessor;

        public MultiTenantServiceBase(
            ITenantIdentityHandler identityHandler,
            ITenantStore tenantStore,
            ITenantContextAccessor contextAccessor)
        {
            _identityHandler = identityHandler;
            _store = tenantStore;
            _contextAccessor = contextAccessor;
        }

        public virtual async Task Run(TContext context, CancellationToken cancellationToken = default)
        {
            var identity = await _identityHandler.GetIdentity(context, cancellationToken);
            if (string.IsNullOrWhiteSpace(identity))
            {

            }

            ITenantInfo tenantInfo = null;
            if (TenantOptions.MultiTenantType != MultiTenantModeType.Table)
            {
                // get identity info from store.
                tenantInfo = await _store.GetTenantInfo(identity, cancellationToken);
                if (tenantInfo == null)
                {

                }
            }

            // generate tenant-context
            var tenantContext = new TenantContext()
            {
                TenantInfo = tenantInfo,
                Options = TenantOptions
            };
            _contextAccessor.TenantContext = tenantContext;
        }

        public async Task Run(object context, CancellationToken cancellationToken = default)
        {
            var currentContext = context as TContext ?? throw new ArgumentException($"Current context type if {context.GetType().Name},but need {typeof(TContext).Name}");
            await Run(currentContext, cancellationToken);
        }
    }
}
