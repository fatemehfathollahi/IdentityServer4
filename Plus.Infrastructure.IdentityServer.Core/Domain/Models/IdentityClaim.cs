



namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class IdentityClaim : UserClaim
    {
        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}