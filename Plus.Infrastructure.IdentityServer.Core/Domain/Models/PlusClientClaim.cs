

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}