

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class IdentityResourceProperty : Property
    {
        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}