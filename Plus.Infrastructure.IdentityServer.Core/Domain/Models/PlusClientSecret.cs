

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientSecret : PlusSecret
    {
        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}