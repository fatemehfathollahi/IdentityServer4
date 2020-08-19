



namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ClientProperty : Property
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}