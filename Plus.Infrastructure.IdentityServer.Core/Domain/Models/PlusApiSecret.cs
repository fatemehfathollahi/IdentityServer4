

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiSecret : PlusSecret
    {
        public int ApiResourceId { get; set; }
        public PlusApiResource ApiResource { get; set; }
    }
}