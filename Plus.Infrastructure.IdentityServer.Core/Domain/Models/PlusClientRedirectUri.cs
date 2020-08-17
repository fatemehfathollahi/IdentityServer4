

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientRedirectUri
    {
        public int Id { get; set; }
        public string RedirectUri { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}