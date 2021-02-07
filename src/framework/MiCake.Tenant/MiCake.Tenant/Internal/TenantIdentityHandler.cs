using MiCake.Core.Util;
using MiCake.Tenant.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Internal
{
    internal class TenantIdentityHandler : ITenantIdentityHandler
    {
        private readonly IEnumerable<ITenantIdentityParser> _parsers;

        public TenantIdentityHandler(IEnumerable<ITenantIdentityParser> parsers)
        {
            _parsers = parsers.OrderBy(s => s.Order);
        }

        public async Task<string> GetIdentity(object context, CancellationToken cancellationToken = default)
        {
            CheckValue.NotNull(context, nameof(context));

            string result = null;
            foreach (var parser in _parsers)
            {
                var currentId = await parser.Parse(context, cancellationToken);

                if (!string.IsNullOrWhiteSpace(currentId))
                {
                    result = currentId;
                    break;
                }
            }

            return result;
        }
    }
}
