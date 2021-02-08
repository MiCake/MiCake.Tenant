using MiCake.Tenant.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MiCake.Tenant.AspNetCore.Internal
{
    internal class MultiTenantMiddleware
    {
        private readonly RequestDelegate next;

        public MultiTenantMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var multiTenantService = context.RequestServices.GetRequiredService<IMultiTenantService>();
            var accessor = context.RequestServices.GetRequiredService<ITenantContextAccessor>();
            
            // run multi tenant service,and given tenantcontext to accessor.
            accessor.TenantContext = await multiTenantService.Run(context, context.RequestAborted);

            if (next != null)
            {
                await next(context);
            }
        }
    }
}
