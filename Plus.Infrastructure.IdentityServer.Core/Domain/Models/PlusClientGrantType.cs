
using Plus.Infrastructure.IdentityServer.Core.Domain.Enumeration;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientGrantType
    {
        public int Id { get; set; }
        public GrantType GrantType { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}