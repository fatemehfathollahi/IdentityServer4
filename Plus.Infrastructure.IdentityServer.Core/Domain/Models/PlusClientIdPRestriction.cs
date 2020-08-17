

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientIdPRestriction
    {
        public int Id { get; set; }
        public string Provider { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}