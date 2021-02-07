using MiCake.Tenant.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.AspNetCore.Parsers
{
    public class HttpHeaderParser : ITenantIdentityParser
    {
        public int Order => 0;

        public Task<string> Parse(object context, CancellationToken cancellationToken = default)
        {
            var httpContext = context as HttpContext ?? throw new ArgumentException($"currnet context type is {context.GetType().Name},it must be HttpContext.");

            httpContext.Request.Headers.TryGetValue(MultiTenantConstants.HeaderName, out var matchHeaderValues);
            if (matchHeaderValues.Count > 1)
                throw new ArgumentException($"Only one tenant ID can be filled in, but there is more than one.");

            if (matchHeaderValues.Count == 0)
                return Task.FromResult<string>(null);

            return Task.FromResult(matchHeaderValues[0]);
        }
    }
}