
namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientPostLogoutRedirectUri
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}