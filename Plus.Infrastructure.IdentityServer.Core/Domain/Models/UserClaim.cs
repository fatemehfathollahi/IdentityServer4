

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{ 
    public abstract class UserClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}