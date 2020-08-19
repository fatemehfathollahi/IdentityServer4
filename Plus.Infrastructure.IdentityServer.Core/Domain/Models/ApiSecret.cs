

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiSecret : Secret
    {
        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}