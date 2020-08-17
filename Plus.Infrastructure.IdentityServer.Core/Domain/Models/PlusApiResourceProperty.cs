
namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiResourceProperty : PlusProperty
    {
        public int ApiResourceId { get; set; }
        public PlusApiResource ApiResource { get; set; }
    }
}