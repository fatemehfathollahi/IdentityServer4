
namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiResourceProperty : Property
    {
        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}