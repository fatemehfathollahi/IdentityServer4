

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusIdentityResourceProperty : PlusProperty
    {
        public int IdentityResourceId { get; set; }
        public PlusIdentityResource IdentityResource { get; set; }
    }
}