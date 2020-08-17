



namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClientProperty : PlusProperty
    {
        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}