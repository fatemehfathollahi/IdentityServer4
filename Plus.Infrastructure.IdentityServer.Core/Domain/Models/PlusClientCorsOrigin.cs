

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientCorsOrigin
    {
        public int Id { get; set; }
        public string Origin { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}