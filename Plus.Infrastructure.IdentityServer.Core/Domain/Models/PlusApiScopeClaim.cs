

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiScopeClaim : PlusUserClaim
    {
        public int ApiScopeId { get; set; }
        public PlusApiScope ApiScope { get; set; }
    }
}