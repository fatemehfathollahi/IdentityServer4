
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiScope
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public List<PlusApiScopeClaim> UserClaims { get; set; }

        public int ApiResourceId { get; set; }
        public PlusApiResource ApiResource { get; set; }
    }
}