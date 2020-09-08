
using Plus.Infrastructure.IdentityServer.Core.Domain.Enumeration;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ClientGrantType
    {
        public int Id { get; set; }
        public string GrantType { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}