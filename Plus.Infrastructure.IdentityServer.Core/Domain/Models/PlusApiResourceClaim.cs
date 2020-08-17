namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiResourceClaim : PlusUserClaim
    {
        public int ApiResourceId { get; set; }
        public PlusApiResource ApiResource { get; set; }
    }
}