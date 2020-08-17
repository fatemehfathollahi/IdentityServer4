

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{ 
    public abstract class PlusUserClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}