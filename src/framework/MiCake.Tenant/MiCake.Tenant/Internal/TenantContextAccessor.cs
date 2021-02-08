using MiCake.Tenant.Abstractions;
using System.Threading;

namespace MiCake.Tenant.Internal
{
#nullable enable
    internal class TenantContextAccessor : ITenantContextAccessor
    {
        internal static AsyncLocal<TenantContext?> _asyncLocalContext = new AsyncLocal<TenantContext?>();

        public TenantContext? TenantContext
        {
            get => _asyncLocalContext.Value;
            set => _asyncLocalContext.Value = value;
        }
    }
}
