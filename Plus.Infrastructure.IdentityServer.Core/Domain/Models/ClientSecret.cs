

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ClientSecret : Secret
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}