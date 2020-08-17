



namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusIdentityClaim : PlusUserClaim
    {
        public int IdentityResourceId { get; set; }
        public PlusIdentityResource IdentityResource { get; set; }
    }
}