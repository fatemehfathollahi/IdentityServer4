
namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public abstract class Property
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}