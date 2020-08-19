namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiResourceClaim : UserClaim
    {
        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}