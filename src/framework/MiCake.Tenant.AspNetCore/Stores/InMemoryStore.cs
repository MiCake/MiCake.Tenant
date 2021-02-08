using MiCake.Tenant.Abstractions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.AspNetCore.Stores
{
    internal class InMemoryStore : ITenantStore
    {
        private ConcurrentDictionary<string, object> _dic = new ConcurrentDictionary<string, object>();

        public InMemoryStore()
        {
        }

        public InMemoryStore(IEnumerable<ITenantInfo> existedData)
        {
            foreach (var item in existedData)
            {
                _dic.TryAdd(item.TenantId, item);
            }
        }

        public Task<bool> AddTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dic.TryAdd(tenantInfo.TenantId, tenantInfo));
        }

        public Task<bool> DeleteTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dic.TryRemove(tenantInfo.TenantId, out _));
        }

        public Task<bool> DeleteTenantInfoById(string id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dic.TryRemove(id, out _));
        }

        public Task<ITenantInfo> GetTenantInfo(string id, CancellationToken cancellationToken = default)
        {
            _dic.TryGetValue(id, out var value);
            return Task.FromResult((ITenantInfo)value);
        }

        public Task<bool> UpdateTenantInfo(ITenantInfo tenantInfo, CancellationToken cancellationToken = default)
        {
            bool result = true;

            _dic.TryGetValue(tenantInfo.TenantId, out var existValue);
            if (existValue != null)
            {
                result = _dic.TryUpdate(tenantInfo.TenantId, tenantInfo, existValue);
            }

            return Task.FromResult(result);
        }
    }
}
