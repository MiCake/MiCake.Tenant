using System;
using System.Collections.Generic;
using System.Linq;

namespace MiCake.Tenant.Diagnostics
{
    public interface ITenantInterceptors
    {
        /// <summary>
        ///     Resolves all <typeparamref name="TInterceptor" /> from all interceptors registered.
        /// </summary>
        /// <typeparam name="TInterceptor"> The interceptor type to resolve. </typeparam>
        /// <returns></returns>
        IEnumerable<TInterceptor> Find<TInterceptor>()
            where TInterceptor : class, ITenantInterceptor;
    }

    internal class TenantInterceptors : ITenantInterceptors
    {
        private readonly Dictionary<Type, IEnumerable<ITenantInterceptor>> _aggregators = new();

        private List<Type> AllInterceptorTypes => new List<Type>()
        {
            typeof(ITenantIdenityRetrieveInterceptor),
            typeof(ITenantInfoRetrieveInterceptor)
        };

        public TenantInterceptors(IEnumerable<ITenantInterceptor> interceptos)
        {
            interceptos ??= new List<ITenantInterceptor>();

            foreach (var interceptorType in AllInterceptorTypes)
            {
                _aggregators.Add(interceptorType, interceptos.Where(s => interceptorType.IsAssignableFrom(s.GetType())));
            }
        }

        IEnumerable<TInterceptor> ITenantInterceptors.Find<TInterceptor>()
        {
            return _aggregators[typeof(TInterceptor)].Cast<TInterceptor>();
        }
    }
}
