using System.Threading;
using System.Threading.Tasks;

namespace MiCake.Tenant.Abstractions
{
    /// <summary>
    /// Convert the context(http context) information to the desired tenant id.
    /// <para>
    ///     It will be used by <see cref="ITenantIdentityHandler"/>.
    /// </para>
    /// </summary>
    public interface ITenantIdentityParser
    {
        /// <summary>
        /// The order for currnt parser.
        /// <para>
        ///  A provider with a lower numeric value of <see cref="Order"/> will have its <see cref="Parse"/> called 
        ///  before that of a provider with a higher numeric value of <see cref="Order"/>.
        /// </para>
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Parse the context to the tenant id.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> Parse(object context, CancellationToken cancellationToken = default);
    }
}
