using Plus.Infrastructure.IdentityServer.Models.ApiResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models.ApiResource
{
    public class ApiResourceViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool NonEditable { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public DateTime Created { get; set; } 
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } 

        public IEnumerable<ScopeItem> Scopes { get; set; }
        public IEnumerable<SecretItem> Secrets { get; set; }
        public IEnumerable<ClaimItem> UserClaims { get; set; } 
        public IEnumerable<PropertyItem> Properties { get; set; } 
    }
}
