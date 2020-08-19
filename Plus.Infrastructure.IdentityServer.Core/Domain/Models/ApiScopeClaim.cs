

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiScopeClaim : UserClaim
    {
        public int ApiScopeId { get; set; }
        public ApiScope ApiScope { get; set; }
    }
}